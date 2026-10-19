/* =====================================================================
   SPYC:I – Cambios sobre la BD "restaurante"
   Ejecutar DESPUÉS de restaurante.sql. Es idempotente: se puede correr
   varias veces sin error y no borra datos existentes.
   ===================================================================== */
USE [restaurante];
GO
SET NOCOUNT ON;
GO

/* ---------------------------------------------------------------------
   1. PEDIDO: observaciones más largas, tipo de pedido y sede
   --------------------------------------------------------------------- */
IF COL_LENGTH('dbo.Pedido', 'Observaciones') < 200
    ALTER TABLE dbo.Pedido ALTER COLUMN Observaciones VARCHAR(200) NULL;
GO

IF COL_LENGTH('dbo.Pedido', 'Tipo_Pedido') IS NULL
    ALTER TABLE dbo.Pedido ADD Tipo_Pedido VARCHAR(20) NOT NULL
        CONSTRAINT DF_Pedido_Tipo_Pedido DEFAULT ('Comer aquí') WITH VALUES;
GO

IF OBJECT_ID('dbo.CK_Pedido_Tipo_Pedido', 'C') IS NULL
    ALTER TABLE dbo.Pedido ADD CONSTRAINT CK_Pedido_Tipo_Pedido
        CHECK (Tipo_Pedido IN ('Comer aquí', 'Para llevar', 'Delivery'));
GO

IF COL_LENGTH('dbo.Pedido', 'ID_Sede') IS NULL
    ALTER TABLE dbo.Pedido ADD ID_Sede VARCHAR(20) NULL
        CONSTRAINT FK_Pedido_Sede FOREIGN KEY REFERENCES dbo.Sede (ID_Sede);
GO

-- La sede de los pedidos existentes se toma de su venta
UPDATE p SET p.ID_Sede = v.ID_Sede
FROM dbo.Pedido p
INNER JOIN dbo.Venta v ON v.ID_Pedido = p.ID_Pedido
WHERE p.ID_Sede IS NULL;
GO

-- Estados estándar: Pendiente → En preparación → Listo → Entregado (o Anulado)
UPDATE dbo.Pedido SET Estado_Pedido = 'Entregado' WHERE Estado_Pedido = 'Completado';
UPDATE dbo.Pedido SET Estado_Pedido = 'Anulado'   WHERE Estado_Pedido = 'Cancelado';
GO

IF OBJECT_ID('dbo.CK_Pedido_Estado', 'C') IS NULL
    ALTER TABLE dbo.Pedido ADD CONSTRAINT CK_Pedido_Estado
        CHECK (Estado_Pedido IN ('Pendiente', 'En preparación', 'Listo', 'Entregado', 'Anulado'));
GO

-- Cliente genérico para boletas sin cliente registrado
IF NOT EXISTS (SELECT 1 FROM dbo.Cliente WHERE ID_Cliente = 'C0000')
    INSERT INTO dbo.Cliente (ID_Cliente, Nom_Cliente, Ape_Cliente, Tel_Cliente, Email, Dir_Cliente)
    VALUES ('C0000', 'Cliente', 'varios', NULL, NULL, NULL);
GO

/* ---------------------------------------------------------------------
   2. VENTA: datos del comprobante (Boleta / Factura)
   --------------------------------------------------------------------- */
IF COL_LENGTH('dbo.Venta', 'Tipo_Comprobante') IS NULL
    ALTER TABLE dbo.Venta ADD Tipo_Comprobante VARCHAR(20) NULL;
IF COL_LENGTH('dbo.Venta', 'RUC') IS NULL
    ALTER TABLE dbo.Venta ADD RUC VARCHAR(11) NULL;
IF COL_LENGTH('dbo.Venta', 'Razon_Social') IS NULL
    ALTER TABLE dbo.Venta ADD Razon_Social VARCHAR(100) NULL;
GO

/* ---------------------------------------------------------------------
   3. INVENTARIO: stock decimal (para descontar 0.25 kg) y stock mínimo
   --------------------------------------------------------------------- */
IF EXISTS (SELECT 1 FROM sys.columns
           WHERE object_id = OBJECT_ID('dbo.Inventario') AND name = 'Cant_Total'
             AND system_type_id = TYPE_ID('int'))
BEGIN
    -- El DEFAULT original tiene nombre automático: se quita, se cambia el tipo y se vuelve a crear
    DECLARE @default SYSNAME, @sql NVARCHAR(300);
    SELECT @default = dc.name
    FROM sys.default_constraints dc
    INNER JOIN sys.columns c ON c.object_id = dc.parent_object_id AND c.column_id = dc.parent_column_id
    WHERE dc.parent_object_id = OBJECT_ID('dbo.Inventario') AND c.name = 'Cant_Total';

    IF @default IS NOT NULL
    BEGIN
        SET @sql = N'ALTER TABLE dbo.Inventario DROP CONSTRAINT ' + QUOTENAME(@default);
        EXEC sp_executesql @sql;
    END

    ALTER TABLE dbo.Inventario ALTER COLUMN Cant_Total DECIMAL(10, 3) NULL;
    ALTER TABLE dbo.Inventario ADD CONSTRAINT DF_Inventario_Cant_Total DEFAULT (0) FOR Cant_Total;
END
GO

IF COL_LENGTH('dbo.Inventario', 'Stock_Minimo') IS NULL
    ALTER TABLE dbo.Inventario ADD Stock_Minimo DECIMAL(10, 3) NOT NULL
        CONSTRAINT DF_Inventario_Stock_Minimo DEFAULT (20) WITH VALUES;
GO

/* ---------------------------------------------------------------------
   4. PLATO_INSUMO: Cant_Necesaria de texto ("500g") a decimal,
      expresada en la unidad del insumo (500g de un insumo en kg = 0.5).
      El texto original se conserva en Cant_Necesaria_Texto.
   --------------------------------------------------------------------- */
IF EXISTS (SELECT 1 FROM sys.columns
           WHERE object_id = OBJECT_ID('dbo.Plato_Insumo') AND name = 'Cant_Necesaria'
             AND system_type_id = TYPE_ID('varchar'))
BEGIN
    EXEC sp_rename 'dbo.Plato_Insumo.Cant_Necesaria', 'Cant_Necesaria_Texto', 'COLUMN';
    ALTER TABLE dbo.Plato_Insumo ADD Cant_Necesaria DECIMAL(10, 3) NULL;
END
GO

IF COL_LENGTH('dbo.Plato_Insumo', 'Cant_Necesaria_Texto') IS NOT NULL
BEGIN
    -- Separa número y unidad del texto: "500g" -> 500 | "g";  "2 unidades" -> 2 | "unidades"
    ;WITH Partes AS (
        SELECT pi.ID_Plato, pi.ID_Insumo, um.Nom_Unidad_Medida AS Unidad_Insumo,
               TRY_CAST(REPLACE(LEFT(LTRIM(pi.Cant_Necesaria_Texto),
                        PATINDEX('%[^0-9.,]%', LTRIM(pi.Cant_Necesaria_Texto) + 'x') - 1), ',', '.') AS DECIMAL(10, 3)) AS Numero,
               LOWER(LTRIM(SUBSTRING(LTRIM(pi.Cant_Necesaria_Texto),
                        PATINDEX('%[^0-9.,]%', LTRIM(pi.Cant_Necesaria_Texto) + 'x'), 50))) AS Unidad_Texto
        FROM dbo.Plato_Insumo pi
        INNER JOIN dbo.Insumo i ON i.ID_Insumo = pi.ID_Insumo
        LEFT JOIN dbo.Unidad_Medida um ON um.ID_Unidad_Medida = i.ID_Unidad_Medida
        WHERE pi.Cant_Necesaria IS NULL AND pi.Cant_Necesaria_Texto IS NOT NULL
    )
    UPDATE pi SET pi.Cant_Necesaria =
        CASE
            WHEN p.Unidad_Texto IN ('g', 'gr', 'gramos')  AND p.Unidad_Insumo = 'Kilogramos' THEN p.Numero / 1000
            WHEN p.Unidad_Texto IN ('ml', 'mililitros')   AND p.Unidad_Insumo = 'Litros'     THEN p.Numero / 1000
            WHEN p.Unidad_Texto IN ('kg', 'kilogramos')   AND p.Unidad_Insumo = 'Gramos'     THEN p.Numero * 1000
            WHEN p.Unidad_Texto IN ('l', 'litros')        AND p.Unidad_Insumo = 'Mililitros' THEN p.Numero * 1000
            ELSE p.Numero
        END
    FROM dbo.Plato_Insumo pi
    INNER JOIN Partes p ON p.ID_Plato = pi.ID_Plato AND p.ID_Insumo = pi.ID_Insumo;
END
GO

/* ---------------------------------------------------------------------
   5. USUARIO: acceso al sistema por perfil (clave en SHA256)
   --------------------------------------------------------------------- */
IF OBJECT_ID('dbo.Usuario', 'U') IS NULL
    CREATE TABLE dbo.Usuario (
        ID_Usuario  INT IDENTITY(1, 1) NOT NULL CONSTRAINT PK_Usuario PRIMARY KEY,
        ID_Empleado VARCHAR(20) NOT NULL CONSTRAINT FK_Usuario_Empleado REFERENCES dbo.Empleado (ID_Empleado),
        Usuario     VARCHAR(30) NOT NULL CONSTRAINT UQ_Usuario_Usuario UNIQUE,
        Clave_Hash  CHAR(64)    NOT NULL,
        Perfil      VARCHAR(20) NOT NULL CONSTRAINT CK_Usuario_Perfil CHECK (Perfil IN ('Administrador', 'Cajero', 'Cocina')),
        ID_Sede     VARCHAR(20) NULL CONSTRAINT FK_Usuario_Sede REFERENCES dbo.Sede (ID_Sede),
        Activo      BIT NOT NULL CONSTRAINT DF_Usuario_Activo DEFAULT (1)
    );
GO

-- Usuarios de prueba (todos en la Sede Central S001): admin/admin123, caja/caja123, cocina/cocina123
IF NOT EXISTS (SELECT 1 FROM dbo.Usuario WHERE Usuario = 'admin')
    INSERT INTO dbo.Usuario (ID_Empleado, Usuario, Clave_Hash, Perfil, ID_Sede)
    VALUES ('E0001', 'admin', CONVERT(CHAR(64), HASHBYTES('SHA2_256', 'admin123'), 2), 'Administrador', 'S001');
IF NOT EXISTS (SELECT 1 FROM dbo.Usuario WHERE Usuario = 'caja')
    INSERT INTO dbo.Usuario (ID_Empleado, Usuario, Clave_Hash, Perfil, ID_Sede)
    VALUES ('E0010', 'caja', CONVERT(CHAR(64), HASHBYTES('SHA2_256', 'caja123'), 2), 'Cajero', 'S001');
IF NOT EXISTS (SELECT 1 FROM dbo.Usuario WHERE Usuario = 'cocina')
    INSERT INTO dbo.Usuario (ID_Empleado, Usuario, Clave_Hash, Perfil, ID_Sede)
    VALUES ('E0008', 'cocina', CONVERT(CHAR(64), HASHBYTES('SHA2_256', 'cocina123'), 2), 'Cocina', 'S001');
GO

/* ---------------------------------------------------------------------
   6. DATOS PARA LA DEMO (solo se agregan si no existen)
   --------------------------------------------------------------------- */
-- Promoción vigente en 2026 (las del script original vencieron en 2025)
IF NOT EXISTS (SELECT 1 FROM dbo.Promocion WHERE ID_Promocion = 'P006')
    INSERT INTO dbo.Promocion (ID_Promocion, Nom_Promocion, Fec_Inicio, Fec_Fin, Descuento)
    VALUES ('P006', 'Promo SPYC:I', '2026-01-01', '2026-12-31', 20.00);

UPDATE dbo.Plato SET ID_Promocion = 'P006'
WHERE ID_Plato IN ('D002', 'D004') AND ISNULL(ID_Promocion, '') <> 'P006';
GO

-- Proveedores (la tabla venía vacía)
IF NOT EXISTS (SELECT 1 FROM dbo.Proveedor WHERE ID_Proveedor = 'PR001')
    INSERT INTO dbo.Proveedor (ID_Proveedor, Nom_Proveedor, Dir_Proveedor, Tel_Proveedor, Email)
    VALUES ('PR001', 'Distribuidora Andina SAC', 'Av. Industrial 450', '014567890', 'ventas@andina.com');
IF NOT EXISTS (SELECT 1 FROM dbo.Proveedor WHERE ID_Proveedor = 'PR002')
    INSERT INTO dbo.Proveedor (ID_Proveedor, Nom_Proveedor, Dir_Proveedor, Tel_Proveedor, Email)
    VALUES ('PR002', 'Carnes del Sur EIRL', 'Jr. Los Olivos 120', '017894561', 'pedidos@carnesdelsur.com');
IF NOT EXISTS (SELECT 1 FROM dbo.Proveedor WHERE ID_Proveedor = 'PR003')
    INSERT INTO dbo.Proveedor (ID_Proveedor, Nom_Proveedor, Dir_Proveedor, Tel_Proveedor, Email)
    VALUES ('PR003', 'Verduras Frescas SAC', 'Mercado Mayorista Pto. 33', '013216549', 'contacto@verdurasfrescas.com');
GO

-- Cada sede debe tener fila de inventario para los insumos usados en recetas
INSERT INTO dbo.Inventario (ID_Sede, ID_Insumo, Cant_Total, Stock_Minimo)
SELECT s.ID_Sede, r.ID_Insumo, 50, 20
FROM dbo.Sede s
CROSS JOIN (SELECT DISTINCT ID_Insumo FROM dbo.Plato_Insumo) r
WHERE NOT EXISTS (SELECT 1 FROM dbo.Inventario inv
                  WHERE inv.ID_Sede = s.ID_Sede AND inv.ID_Insumo = r.ID_Insumo);
GO

/* ---------------------------------------------------------------------
   7. PROCEDIMIENTOS ALMACENADOS PARA LOS PROCESOS NUEVOS
   --------------------------------------------------------------------- */

-- Login: usuario con su empleado y sede
CREATE OR ALTER PROCEDURE dbo.sp_Buscar_Usuario
    @Usuario VARCHAR(30)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT u.ID_Usuario, u.ID_Empleado, e.Nombre + ' ' + e.Apellido AS Nombre_Empleado,
           u.Usuario, u.Clave_Hash, u.Perfil, u.ID_Sede, s.Nom_Sede, u.Activo
    FROM dbo.Usuario u
    INNER JOIN dbo.Empleado e ON e.ID_Empleado = u.ID_Empleado
    LEFT JOIN dbo.Sede s ON s.ID_Sede = u.ID_Sede
    WHERE u.Usuario = @Usuario;
END
GO

-- Cocina: pedidos del día de una sede con su detalle en texto
CREATE OR ALTER PROCEDURE dbo.sp_Pedidos_Cocina
    @ID_Sede VARCHAR(20),
    @Fecha   DATE
AS
BEGIN
    SET NOCOUNT ON;
    SELECT p.ID_Pedido, p.Fec_Pedido, p.Estado_Pedido, p.Tipo_Pedido,
           ISNULL(c.Nom_Cliente + ' ' + c.Ape_Cliente, 'Cliente varios') AS Cliente,
           ISNULL(p.Observaciones, '') AS Observaciones,
           ISNULL((SELECT STRING_AGG(CONCAT(dp.Cantidad, ' x ', pl.Nom_Plato), CHAR(13) + CHAR(10))
                          WITHIN GROUP (ORDER BY dp.ID_Detalle_Pedido)
                   FROM dbo.Detalle_Pedido dp
                   INNER JOIN dbo.Plato pl ON pl.ID_Plato = dp.ID_Plato
                   WHERE dp.ID_Pedido = p.ID_Pedido), '') AS Detalle
    FROM dbo.Pedido p
    LEFT JOIN dbo.Cliente c ON c.ID_Cliente = p.ID_Cliente
    WHERE p.ID_Sede = @ID_Sede
      AND p.Fec_Pedido >= @Fecha AND p.Fec_Pedido < DATEADD(DAY, 1, @Fecha)
      AND p.Estado_Pedido <> 'Anulado'
    ORDER BY p.Fec_Pedido;
END
GO

-- Cocina: avanzar el estado de un pedido
CREATE OR ALTER PROCEDURE dbo.sp_Cambiar_Estado_Pedido
    @ID_Pedido VARCHAR(20),
    @Estado    VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    IF @Estado NOT IN ('Pendiente', 'En preparación', 'Listo', 'Entregado', 'Anulado')
    BEGIN
        RAISERROR('Estado de pedido no válido.', 16, 1);
        RETURN;
    END

    UPDATE dbo.Pedido SET Estado_Pedido = @Estado WHERE ID_Pedido = @ID_Pedido;
    IF @@ROWCOUNT = 0
        RAISERROR('El pedido no existe.', 16, 1);
END
GO

-- Inventario de una sede con unidad, mínimo y estado
CREATE OR ALTER PROCEDURE dbo.sp_Inventario_Sede
    @ID_Sede VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT inv.ID_Insumo, i.Nombre AS Insumo, cl.Nom_Clasificacion AS Clasificacion,
           um.Nom_Unidad_Medida AS Unidad, inv.Cant_Total AS Stock, inv.Stock_Minimo,
           CASE WHEN inv.Cant_Total < inv.Stock_Minimo THEN 'Bajo mínimo' ELSE 'OK' END AS Estado
    FROM dbo.Inventario inv
    INNER JOIN dbo.Insumo i ON i.ID_Insumo = inv.ID_Insumo
    LEFT JOIN dbo.Clasificacion cl ON cl.ID_Clasificacion = i.ID_Clasificacion
    LEFT JOIN dbo.Unidad_Medida um ON um.ID_Unidad_Medida = i.ID_Unidad_Medida
    WHERE inv.ID_Sede = @ID_Sede
    ORDER BY CASE WHEN inv.Cant_Total < inv.Stock_Minimo THEN 0 ELSE 1 END, i.Nombre;
END
GO

/* Reportes: misma lógica que las vistas existentes, pero con filtro de
   sede (@ID_Sede NULL = todas) y rango de fechas (ambos días incluidos). */

-- KPIs: ventas, número de pedidos y ticket promedio
CREATE OR ALTER PROCEDURE dbo.sp_Reporte_KPIs
    @ID_Sede VARCHAR(20) = NULL,
    @Desde   DATE,
    @Hasta   DATE
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ISNULL(SUM(v.Monto_Total), 0) AS Total_Ventas,
           COUNT(v.ID_Venta)             AS Num_Pedidos,
           ISNULL(AVG(v.Monto_Total), 0) AS Ticket_Promedio
    FROM dbo.Venta v
    WHERE v.Fec_Venta >= @Desde AND v.Fec_Venta < DATEADD(DAY, 1, @Hasta)
      AND (@ID_Sede IS NULL OR v.ID_Sede = @ID_Sede);
END
GO

-- Basado en la vista ventas_por_sede
CREATE OR ALTER PROCEDURE dbo.sp_Reporte_Ventas_Por_Sede
    @ID_Sede VARCHAR(20) = NULL,
    @Desde   DATE,
    @Hasta   DATE
AS
BEGIN
    SET NOCOUNT ON;
    SELECT s.Nom_Sede, ISNULL(SUM(v.Monto_Total), 0) AS total_ventas
    FROM dbo.Sede s
    LEFT JOIN dbo.Venta v ON v.ID_Sede = s.ID_Sede
         AND v.Fec_Venta >= @Desde AND v.Fec_Venta < DATEADD(DAY, 1, @Hasta)
    WHERE (@ID_Sede IS NULL OR s.ID_Sede = @ID_Sede)
    GROUP BY s.ID_Sede, s.Nom_Sede
    ORDER BY s.ID_Sede;
END
GO

-- Basado en la vista platos_mas_pedidos (top 10)
CREATE OR ALTER PROCEDURE dbo.sp_Reporte_Platos_Mas_Pedidos
    @ID_Sede VARCHAR(20) = NULL,
    @Desde   DATE,
    @Hasta   DATE
AS
BEGIN
    SET NOCOUNT ON;
    SELECT TOP 10 p.Nom_Plato, SUM(dp.Cantidad) AS total_pedidos
    FROM dbo.Detalle_Pedido dp
    INNER JOIN dbo.Plato p ON dp.ID_Plato = p.ID_Plato
    INNER JOIN dbo.Pedido ped ON dp.ID_Pedido = ped.ID_Pedido
    WHERE ped.Fec_Pedido >= @Desde AND ped.Fec_Pedido < DATEADD(DAY, 1, @Hasta)
      AND (@ID_Sede IS NULL OR ped.ID_Sede = @ID_Sede)
      AND ped.Estado_Pedido <> 'Anulado'
    GROUP BY p.Nom_Plato
    ORDER BY total_pedidos DESC;
END
GO

-- Basado en la vista Vista_Mapa_Calor_Horas_Pico (agrupado por hora)
CREATE OR ALTER PROCEDURE dbo.sp_Reporte_Horas_Pico
    @ID_Sede VARCHAR(20) = NULL,
    @Desde   DATE,
    @Hasta   DATE
AS
BEGIN
    SET NOCOUNT ON;
    SELECT DATEPART(HOUR, p.Fec_Pedido) AS Hora,
           COUNT(DISTINCT p.ID_Pedido)  AS CantidadPedidos,
           SUM(dp.Cantidad)             AS PlatosServidos
    FROM dbo.Pedido p
    INNER JOIN dbo.Detalle_Pedido dp ON p.ID_Pedido = dp.ID_Pedido
    WHERE p.Fec_Pedido >= @Desde AND p.Fec_Pedido < DATEADD(DAY, 1, @Hasta)
      AND (@ID_Sede IS NULL OR p.ID_Sede = @ID_Sede)
    GROUP BY DATEPART(HOUR, p.Fec_Pedido)
    ORDER BY Hora;
END
GO

-- Basado en la vista Vista_Top_Clientes_VIP (sin "Cliente varios")
CREATE OR ALTER PROCEDURE dbo.sp_Reporte_Top_Clientes
    @ID_Sede VARCHAR(20) = NULL,
    @Desde   DATE,
    @Hasta   DATE
AS
BEGIN
    SET NOCOUNT ON;
    SELECT TOP 10 (c.Nom_Cliente + ' ' + c.Ape_Cliente) AS Cliente,
           COUNT(v.ID_Venta)  AS Frecuencia,
           SUM(v.Monto_Total) AS TotalGastado,
           MAX(v.Fec_Venta)   AS UltimaVisita
    FROM dbo.Cliente c
    INNER JOIN dbo.Pedido p ON c.ID_Cliente = p.ID_Cliente
    INNER JOIN dbo.Venta v ON p.ID_Pedido = v.ID_Pedido
    WHERE c.ID_Cliente <> 'C0000'
      AND v.Fec_Venta >= @Desde AND v.Fec_Venta < DATEADD(DAY, 1, @Hasta)
      AND (@ID_Sede IS NULL OR v.ID_Sede = @ID_Sede)
    GROUP BY c.ID_Cliente, c.Nom_Cliente, c.Ape_Cliente
    ORDER BY TotalGastado DESC;
END
GO

-- Basado en la vista Vista_Efectividad_Promociones (agrupado por promoción)
CREATE OR ALTER PROCEDURE dbo.sp_Reporte_Efectividad_Promociones
    @ID_Sede VARCHAR(20) = NULL,
    @Desde   DATE,
    @Hasta   DATE
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ISNULL(prom.Nom_Promocion, 'Venta Organica') AS Promocion,
           SUM(dp.Cantidad)                          AS UnidadesVendidas,
           SUM(dp.Cantidad * dp.Pre_Unitario_Final)  AS TotalIngresos
    FROM dbo.Plato pl
    LEFT JOIN dbo.Promocion prom ON pl.ID_Promocion = prom.ID_Promocion
    INNER JOIN dbo.Detalle_Pedido dp ON pl.ID_Plato = dp.ID_Plato
    INNER JOIN dbo.Pedido p ON dp.ID_Pedido = p.ID_Pedido
    WHERE (prom.ID_Promocion IS NULL
           OR (p.Fec_Pedido >= prom.Fec_Inicio AND p.Fec_Pedido < DATEADD(DAY, 1, prom.Fec_Fin)))
      AND p.Fec_Pedido >= @Desde AND p.Fec_Pedido < DATEADD(DAY, 1, @Hasta)
      AND (@ID_Sede IS NULL OR p.ID_Sede = @ID_Sede)
    GROUP BY prom.Nom_Promocion
    ORDER BY TotalIngresos DESC;
END
GO

/* ---------------------------------------------------------------------
   8. RESUMEN
   --------------------------------------------------------------------- */
SELECT 'Usuarios' AS Objeto, COUNT(*) AS Cantidad FROM dbo.Usuario
UNION ALL SELECT 'Recetas sin cantidad convertida', COUNT(*) FROM dbo.Plato_Insumo WHERE Cant_Necesaria IS NULL
UNION ALL SELECT 'Insumos bajo el mínimo', COUNT(*) FROM dbo.Inventario WHERE Cant_Total < Stock_Minimo;
GO
