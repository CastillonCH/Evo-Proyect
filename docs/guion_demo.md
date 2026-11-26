# Guion de la demo en vivo (5 minutos)

## Antes de empezar (preparación, fuera del tiempo)

1. Restaurar la BD **desde cero**: `restaurante.sql` y luego `database/02_cambios_spyci.sql` (ver README).
   Así los códigos y cantidades coinciden con este guion.
2. Revisar el servidor en `App.config`, compilar y abrir la app (F5). Debe aparecer el **login**.
3. Pantalla en 1280×800 o más.

> Si ensayaron antes, los códigos serán otros (P01503, V01502…) y el stock será menor. Para volver al estado inicial, ejecuten otra vez los dos scripts.

Datos de partida (Sede Central, `S001`):

| Producto | Precio | Promoción | Precio final |
|----------|-------:|-----------|-------------:|
| Hamburguesa Clasica (D002) | S/ 16.66 | Promo SPYC:I (−20 %) | S/ 13.33 |
| Tacos de Pollo (D004) | S/ 62.09 | Promo SPYC:I (−20 %) | S/ 49.67 |

| Insumo (S001) | Stock inicial | Receta usada en la venta | Stock final |
|---------------|--------------:|--------------------------|------------:|
| Lechuga (g) | 448 | 2×50 + 1×50 | **298** |
| Tomate en Rodajas (g) | 323 | 2×50 + 1×50 | **173** |
| Pan para Hamburguesa (piezas) | 407 | 2×2 | **403** |
| Carne de Hamburguesa (kg) | 68 | 2×0.25 | **67.5** |
| Cebolla (g) | 2000 | 2×20 | **1960** |
| Pechuga de Pollo (kg) | 20 | 1×0.3 | **19.7 → en rojo (mínimo 20)** |

---

## Minuto 0:00 – 0:40 · Login como cajero (Integrante 1)

1. Usuario **`caja`** / contraseña **`caja123`** → **INGRESAR**.
2. Mostrar la cabecera: *Carmen Sanchez Gonzalez · Cajero · Sede Central*.
   El menú solo muestra **Caja** y **Clientes**, y la Caja se abre automáticamente.
3. *(Opcional, 10 s)* Probar una contraseña incorrecta antes: aparece "Usuario o contraseña incorrectos."

## Minuto 0:40 – 2:00 · Venta de 2 productos con promoción (Integrante 2)

1. Señalar la etiqueta naranja **-20%** en *Hamburguesa Clasica*.
2. Clic **2 veces** en **Hamburguesa Clasica** → carrito: `2 × 26.66 (Promoción)`.
3. En *Buscar* escribir `tacos` → clic en **Tacos de Pollo** → `1 × 49.67`.
4. Mostrar los botones **+ / − / ✕** (sumar uno y quitarlo).
5. **Tipo de pedido:** *Para llevar*. **Cliente:** *(Cliente varios)*. **Comprobante:** *Boleta*. **Método de pago:** *Efectivo*.
6. **Observaciones:** `Sin cebolla`.
7. Señalar los totales: **Subtotal S/ 95.41 · Descuento − S/ 19.08 · TOTAL S/ 76.33**.
8. *(Opcional, 15 s)* Cambiar a **Factura**: aparecen *RUC* y *Razón social*. Si se cobra sin RUC: "Para emitir factura ingrese un RUC de 11 dígitos." Volver a **Boleta**.

## Minuto 2:00 – 2:30 · Cobro y boleta

1. **COBRAR** → mensaje "Venta registrada: **V01501** · Pedido **P01502** enviado a cocina."
2. Se abre la vista previa del comprobante: BOLETA, pedido P01502, 2 líneas con su promoción, TOTAL S/ 76.33.
   *(Si la PC no tiene impresora, el comprobante se muestra en un cuadro de texto.)*
3. Decir: "Pedido, detalle, venta, detalle de venta y descuento de inventario se guardaron en **una sola transacción**."

## Minuto 2:30 – 3:20 · Cocina (Integrante 3)

1. **Cerrar sesión** → usuario **`cocina`** / **`cocina123`**.
2. La pantalla Cocina muestra **P01502** en *Pendiente (1)* con cabecera **verde** (0 min), los platos, *Para llevar · Cliente varios* y *Obs: Sin cebolla*.
3. **Iniciar preparación ▶** → pasa a *En preparación*.
4. **Marcar como listo ▶** → *Listo*.
5. **Entregar ✔** → *Entregado* (gris).
6. Decir: "Se actualiza sola cada 10 segundos; si un pedido pasa de 10 minutos se pone amarillo y después de 20, rojo."

## Minuto 3:20 – 4:15 · El inventario bajó (Integrante 4)

1. **Cerrar sesión** → usuario **`admin`** / **`admin123`**.
2. La cabecera muestra en rojo **"⚠ 1 insumo(s) bajo el mínimo"**. Clic en la alerta → abre **Inventario**.
3. Sede Central: **Pechuga de Pollo 19.7** en **rojo** (*Bajo mínimo*). Buscar `lechuga` → **298** (antes 448).
4. **Registrar abastecimiento:** Proveedor *Carnes del Sur EIRL* · Insumo *Pechuga de Pollo* · Cantidad **10** → **Agregar** → **Registrar ingreso** → "Abastecimiento AB00001 registrado".
   La Pechuga sube a **29.7** y sale del rojo.
5. **Consumo por receta:** elegir *Hamburguesa Clasica* → **Ver consumo** → 2 piezas de pan, 0.25 kg de carne, 50 g de lechuga, 50 g de tomate, 20 g de cebolla, y todo con "Sí" en *Alcanza*.

## Minuto 4:15 – 5:00 · Reporte actualizado (Integrante 5)

1. Menú **Reportes** (filtro *Todas las sedes*, fechas **Hoy**).
2. KPIs: **Ventas S/ 76.33 · N.º de pedidos 1 · Ticket promedio S/ 76.33 · Insumos bajo el mínimo 0** (ya se abasteció).
3. Gráficos: *Ventas por sede* → solo Sede Central. *Platos más pedidos* → Hamburguesa 2, Tacos 1. *Promociones* → "Promo SPYC:I" S/ 76.33.
4. Clic en **Todo el histórico** → los gráficos se llenan con los ~1 500 pedidos de la BD. Cerrar con: "De la caja al reporte en menos de 5 minutos, sin papel ni Excel."

---

## Plan B (si algo falla en vivo)

| Problema | Qué hacer |
|----------|-----------|
| "No se pudo conectar con la base de datos" | Revisar `Server=` en `RESTAURANTEFINAL.exe.config` (o `App.config`) y que el servicio SQL Server esté iniciado. |
| "Stock insuficiente…" al cobrar | Es el aviso del sistema (se puede explicar como funcionalidad). Para seguir: Inventario → registrar abastecimiento del insumo indicado. |
| Los códigos no son P01502 / V01501 | Ya se hicieron ventas antes; no afecta la demo. Para reiniciar, ejecutar otra vez los dos scripts. |
| No hay impresora | El comprobante se muestra en un cuadro de texto. |
