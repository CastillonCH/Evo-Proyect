/* =====================================================================
   SPYC:I – Prueba del flujo completo (venta → detalle → stock descontado)
   Ejecutar DESPUÉS de restaurante.sql y 02_cambios_spyci.sql.
   Todo ocurre dentro de una transacción que termina en ROLLBACK:
   la BD queda exactamente igual que antes de la prueba.
   ===================================================================== */
USE [restaurante];
SET NOCOUNT ON;
SET XACT_ABORT ON;

BEGIN TRANSACTION;

-- Datos de la prueba: 2 x Hamburguesa Clasica (D002) + 1 x Tacos de Pollo (D004) en la Sede Central
DECLARE @Sede VARCHAR(20) = 'S001';
DECLARE @Lineas TABLE (ID_Plato VARCHAR(20), Cantidad INT);
INSERT INTO @Lineas VALUES ('D002', 2), ('D004', 1);

-- 1. Stock antes de la venta
DECLARE @StockAntes TABLE (ID_Insumo VARCHAR(20), Cant_Total DECIMAL(10, 3));
INSERT INTO @StockAntes SELECT ID_Insumo, Cant_Total FROM dbo.Inventario WHERE ID_Sede = @Sede;

-- 2. Consumo esperado según la receta (Plato_Insumo x cantidad)
DECLARE @Consumo TABLE (ID_Insumo VARCHAR(20), Cantidad DECIMAL(10, 3));
INSERT INTO @Consumo
SELECT pi.ID_Insumo, SUM(pi.Cant_Necesaria * l.Cantidad)
FROM @Lineas l INNER JOIN dbo.Plato_Insumo pi ON pi.ID_Plato = l.ID_Plato
GROUP BY pi.ID_Insumo;

-- 3. Precio final con la promoción vigente (igual que DescuentoPromocion + CalculadoraPedido)
DECLARE @Detalle TABLE (Fila INT IDENTITY(1, 1), ID_Plato VARCHAR(20), Cantidad INT, Precio_Final DECIMAL(10, 2));
INSERT INTO @Detalle (ID_Plato, Cantidad, Precio_Final)
SELECT l.ID_Plato, l.Cantidad,
       p.Prec_Original - CASE WHEN CAST(GETDATE() AS DATE) BETWEEN CAST(pr.Fec_Inicio AS DATE) AND CAST(pr.Fec_Fin AS DATE)
                              THEN ROUND(p.Prec_Original * pr.Descuento / 100, 2) ELSE 0 END
FROM @Lineas l
INNER JOIN dbo.Plato p ON p.ID_Plato = l.ID_Plato
LEFT JOIN dbo.Promocion pr ON pr.ID_Promocion = p.ID_Promocion;

DECLARE @Total DECIMAL(10, 2) = (SELECT SUM(Precio_Final * Cantidad) FROM @Detalle);

-- 4. Códigos nuevos con el formato de la BD (P00001, V00001, DP00001, DV00001)
DECLARE @NumPedido INT = (SELECT ISNULL(MAX(CAST(SUBSTRING(ID_Pedido, 2, 5) AS INT)), 0) + 1 FROM dbo.Pedido WHERE ID_Pedido LIKE 'P[0-9][0-9][0-9][0-9][0-9]');
DECLARE @NumVenta INT = (SELECT ISNULL(MAX(CAST(SUBSTRING(ID_Venta, 2, 5) AS INT)), 0) + 1 FROM dbo.Venta WHERE ID_Venta LIKE 'V[0-9][0-9][0-9][0-9][0-9]');
DECLARE @NumDP INT = (SELECT ISNULL(MAX(CAST(SUBSTRING(ID_Detalle_Pedido, 3, 5) AS INT)), 0) FROM dbo.Detalle_Pedido WHERE ID_Detalle_Pedido LIKE 'DP[0-9][0-9][0-9][0-9][0-9]');
DECLARE @NumDV INT = (SELECT ISNULL(MAX(CAST(SUBSTRING(ID_Detalle_Venta, 3, 5) AS INT)), 0) FROM dbo.Detalle_Venta WHERE ID_Detalle_Venta LIKE 'DV[0-9][0-9][0-9][0-9][0-9]');
DECLARE @Pedido VARCHAR(20) = 'P' + RIGHT('00000' + CAST(@NumPedido AS VARCHAR(5)), 5);
DECLARE @Venta VARCHAR(20) = 'V' + RIGHT('00000' + CAST(@NumVenta AS VARCHAR(5)), 5);

-- 5. Venta: Pedido + Venta + Detalle_Pedido + Detalle_Venta + descuento de Inventario
INSERT INTO dbo.Pedido (ID_Pedido, ID_Cliente, Fec_Pedido, Estado_Pedido, Observaciones, Tipo_Pedido, ID_Sede)
VALUES (@Pedido, 'C0000', GETDATE(), 'Pendiente', 'Sin cebolla', 'Para llevar', @Sede);

INSERT INTO dbo.Venta (ID_Venta, ID_Pedido, Fec_Venta, Monto_Total, ID_Metodo_Pago, ID_Sede, Tipo_Comprobante)
VALUES (@Venta, @Pedido, GETDATE(), @Total, 'MP001', @Sede, 'Boleta');

INSERT INTO dbo.Detalle_Pedido (ID_Detalle_Pedido, ID_Pedido, ID_Plato, Cantidad, Pre_Unitario_Final)
SELECT 'DP' + RIGHT('00000' + CAST(@NumDP + Fila AS VARCHAR(5)), 5), @Pedido, ID_Plato, Cantidad, Precio_Final FROM @Detalle;

INSERT INTO dbo.Detalle_Venta (ID_Detalle_Venta, ID_Detalle_Pedido, Tipo_Documento, ID_Venta, ID_Plato, Precio, Cant)
SELECT 'DV' + RIGHT('00000' + CAST(@NumDV + Fila AS VARCHAR(5)), 5), 'DP' + RIGHT('00000' + CAST(@NumDP + Fila AS VARCHAR(5)), 5),
       'Boleta', @Venta, ID_Plato, Precio_Final, Cantidad
FROM @Detalle;

UPDATE inv SET inv.Cant_Total = inv.Cant_Total - c.Cantidad
FROM dbo.Inventario inv INNER JOIN @Consumo c ON c.ID_Insumo = inv.ID_Insumo
WHERE inv.ID_Sede = @Sede AND inv.Cant_Total >= c.Cantidad;

IF @@ROWCOUNT <> (SELECT COUNT(*) FROM @Consumo)
    THROW 50001, 'FALLO: algún insumo no tenía stock suficiente.', 1;

-- 6. Verificaciones
IF (SELECT COUNT(*) FROM dbo.Detalle_Pedido WHERE ID_Pedido = @Pedido) <> 2
    THROW 50002, 'FALLO: Detalle_Pedido no tiene 2 líneas.', 1;
IF (SELECT COUNT(*) FROM dbo.Detalle_Venta WHERE ID_Venta = @Venta) <> 2
    THROW 50003, 'FALLO: Detalle_Venta no tiene 2 líneas.', 1;
IF (SELECT SUM(Cantidad * Pre_Unitario_Final) FROM dbo.Detalle_Pedido WHERE ID_Pedido = @Pedido) <> (SELECT Monto_Total FROM dbo.Venta WHERE ID_Venta = @Venta)
    THROW 50004, 'FALLO: el total de la venta no coincide con el detalle.', 1;
IF EXISTS (SELECT 1 FROM @Consumo c
           INNER JOIN @StockAntes a ON a.ID_Insumo = c.ID_Insumo
           INNER JOIN dbo.Inventario inv ON inv.ID_Insumo = c.ID_Insumo AND inv.ID_Sede = @Sede
           WHERE inv.Cant_Total <> a.Cant_Total - c.Cantidad)
    THROW 50005, 'FALLO: el stock no bajó según la receta.', 1;

-- El pedido aparece en cocina y avanza de estado
DECLARE @Cocina TABLE (ID_Pedido VARCHAR(20), Fec_Pedido DATETIME, Estado_Pedido VARCHAR(20), Tipo_Pedido VARCHAR(20),
                       Cliente VARCHAR(101), Observaciones VARCHAR(200), Detalle NVARCHAR(MAX));
DECLARE @Hoy DATE = CAST(GETDATE() AS DATE);
INSERT INTO @Cocina EXEC dbo.sp_Pedidos_Cocina @ID_Sede = @Sede, @Fecha = @Hoy;
IF NOT EXISTS (SELECT 1 FROM @Cocina WHERE ID_Pedido = @Pedido AND Estado_Pedido = 'Pendiente')
    THROW 50006, 'FALLO: el pedido no aparece en cocina.', 1;

EXEC dbo.sp_Cambiar_Estado_Pedido @ID_Pedido = @Pedido, @Estado = 'En preparación';
EXEC dbo.sp_Cambiar_Estado_Pedido @ID_Pedido = @Pedido, @Estado = 'Listo';
EXEC dbo.sp_Cambiar_Estado_Pedido @ID_Pedido = @Pedido, @Estado = 'Entregado';
IF (SELECT Estado_Pedido FROM dbo.Pedido WHERE ID_Pedido = @Pedido) <> 'Entregado'
    THROW 50007, 'FALLO: el estado no avanzó.', 1;

-- 7. Resultado
SELECT @Pedido AS Pedido, @Venta AS Venta, @Total AS Total;
SELECT d.ID_Plato, p.Nom_Plato, d.Cantidad, d.Precio_Final FROM @Detalle d INNER JOIN dbo.Plato p ON p.ID_Plato = d.ID_Plato;
SELECT i.Nombre AS Insumo, a.Cant_Total AS Stock_Antes, c.Cantidad AS Consumo, inv.Cant_Total AS Stock_Despues,
       CASE WHEN inv.Cant_Total < inv.Stock_Minimo THEN 'Bajo mínimo' ELSE 'OK' END AS Estado
FROM @Consumo c
INNER JOIN @StockAntes a ON a.ID_Insumo = c.ID_Insumo
INNER JOIN dbo.Inventario inv ON inv.ID_Insumo = c.ID_Insumo AND inv.ID_Sede = @Sede
INNER JOIN dbo.Insumo i ON i.ID_Insumo = c.ID_Insumo
ORDER BY i.Nombre;
EXEC dbo.sp_Reporte_KPIs @ID_Sede = @Sede, @Desde = @Hoy, @Hasta = @Hoy;

PRINT 'PRUEBA OK: venta, detalle, cocina y descuento de stock verificados.';

ROLLBACK TRANSACTION;   -- la BD queda como estaba
PRINT 'ROLLBACK realizado: no se guardó ningún dato de la prueba.';
