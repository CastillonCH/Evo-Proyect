# Reparto de la exposición (5 integrantes · 5 minutos)

| # | Integrante | Pantalla(s) | Principio / tema | Archivos para mostrar |
|---|------------|-------------|------------------|------------------------|
| 1 | Integrante 1 | Login, Menú principal, Clientes | **DIP** | `FrmLogin.cs`, `FrmPrincipal.cs`, `Cliente.cs`, `NEGOCIO/Interfaces/IClienteRepositorio.cs`, `FabricaServicios.cs` |
| 2 | Integrante 2 | Caja (POS) | **OCP** | `FrmCaja.cs`, `NEGOCIO/Descuentos/*`, `NEGOCIO/Comprobantes/*` |
| 3 | Integrante 3 | Cocina | Estados del pedido y tiempo real | `FrmCocina.cs`, `NEGOCIO/Servicios/EstadosPedido.cs`, `sp_Pedidos_Cocina` |
| 4 | Integrante 4 | Inventario | **SRP** | `FrmInventario.cs`, `NEGOCIO/Servicios/ServicioInventario.cs`, `CalculadoraPedido.cs` |
| 5 | Integrante 5 | Reportes | Datos para el gerente | `FrmReportes.cs`, `DATOS/DATOS_REPORTE.cs`, SPs `sp_Reporte_*` |

Cada guion dura entre 45 y 60 segundos leído a ritmo normal (unas 120–150 palabras).

---

## Integrante 1 – Login, Menú y Clientes (DIP)

> "Nuestro proceso empieza con el **login**. Cada usuario tiene un perfil: Cajero, Cocina o Administrador. La contraseña se guarda como hash SHA256 en la tabla `Usuario`. Según el perfil, el **menú** muestra solo lo que esa persona necesita: el cajero ve Caja y Clientes; la cocina, solo Cocina; y el administrador, todo. Las pantallas se abren dentro del panel derecho, con el usuario, el perfil y la sede en la cabecera.
>
> En **Clientes** aplicamos el principio de **Inversión de Dependencias**. Antes el formulario hacía `new DATOS_CLIENTE()` y quedaba amarrado a SQL Server. Ahora recibe por el constructor la interfaz `IClienteRepositorio`, que está en la capa de negocio. La clase `FabricaServicios` es el único lugar que decide qué implementación usar. Además, el código del cliente se genera solo, la búsqueda funciona por varios campos y, si intentamos borrar un cliente con pedidos, el sistema avisa en lugar de caerse."

**Mostrar:** `Cliente.cs` líneas 14–23 y `FabricaServicios.cs` línea 11.

---

## Integrante 2 – Caja (OCP)

> "La **Caja** es el corazón del proceso. El cajero arma el pedido con botones grandes; los productos con promoción llevan una etiqueta naranja, por ejemplo **-20 %**. El sistema aplica la promoción vigente según las fechas de la tabla `Promocion` y calcula el total en vivo. Luego se eligen el tipo de pedido, el cliente opcional, el método de pago y el comprobante.
>
> Aquí aplicamos el principio **Abierto/Cerrado**. Cada descuento es una clase que implementa `IReglaDescuento`: SinDescuento, DescuentoPromocion y DescuentoClienteFrecuente. Si mañana queremos un 'Martes 2x1', creamos una clase nueva y la registramos en `FabricaServicios`, sin modificar la calculadora. Lo mismo pasa con `IComprobante`: la Boleta acepta 'Cliente varios' y la Factura exige un RUC de 11 dígitos y desglosa el IGV. Al presionar **COBRAR**, todo se guarda en una sola transacción y se imprime el comprobante."

**Mostrar:** `NEGOCIO/Descuentos/IReglaDescuento.cs` y `FabricaServicios.cs` líneas 19–34.

---

## Integrante 3 – Cocina

> "Cuando el cajero cobra, el pedido aparece **automáticamente** en la pantalla de **Cocina**, sin comandas de papel. Los pedidos del día de la sede se ordenan en cuatro columnas: Pendiente, En preparación, Listo y Entregado. Cada tarjeta muestra el número de pedido, la hora, los platos, el tipo de pedido y las observaciones, por ejemplo 'Sin cebolla'.
>
> El cocinero avanza el pedido con un solo botón. El orden de los estados está en la clase `EstadosPedido`, así que la pantalla no decide las reglas. La pantalla se **actualiza sola cada 10 segundos** con un Timer, y el color de la tarjeta indica el tiempo de espera: verde si lleva menos de 10 minutos, amarillo entre 10 y 20, y rojo si pasa de 20. Así el equipo sabe qué pedido atender primero."

**Mostrar:** `FrmCocina.cs` (método `Crear_Tarjeta` y `Color_Por_Espera`).

---

## Integrante 4 – Inventario (SRP)

> "Cada plato tiene una **receta** en la tabla `Plato_Insumo`. La convertimos de texto ('500g') a número, en la unidad del insumo: 0.5 kg. Cuando se vende un plato, los insumos se **descuentan solos** del inventario de la sede.
>
> Aquí aplicamos el principio de **Responsabilidad Única**. `ServicioInventario` solo se encarga del inventario: calcula el consumo según la receta, verifica si alcanza el stock y registra los abastecimientos. `CalculadoraPedido` solo calcula montos, y `ServicioVenta` solo coordina el cobro. Si cambia la forma de calcular el IGV, no tocamos el inventario.
>
> En esta pantalla vemos el stock por sede: lo que está bajo el mínimo aparece en **rojo**. También registramos el ingreso de mercadería de un proveedor, que suma stock, y con 'Ver consumo' mostramos cuánto gasta un producto."

**Mostrar:** `NEGOCIO/Servicios/ServicioInventario.cs` líneas 21–44.

---

## Integrante 5 – Reportes

> "Para el **gerente** tenemos la pantalla de **Reportes**. Arriba están los indicadores: ventas del periodo, número de pedidos, ticket promedio e insumos bajo el mínimo. Abajo, cuatro gráficos y una tabla construidos sobre las vistas que ya tenía la base de datos: ventas por sede, platos más pedidos, horas pico, efectividad de las promociones y el top de clientes VIP.
>
> Como las vistas originales no permitían filtrar, creamos procedimientos almacenados con la misma lógica y con filtro por **sede** y **rango de fechas**. Por ejemplo, al elegir 'Hoy' vemos la venta que acabamos de hacer en la demo, y con 'Todo el histórico' vemos los más de mil quinientos pedidos registrados. Así el gerente toma decisiones con datos del momento y no con un Excel del día anterior."

**Mostrar:** `FrmReportes.cs` (método `Cargar_Reportes`) y `database/02_cambios_spyci.sql` (sección de reportes).
