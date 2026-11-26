# Principios SOLID aplicados en SPYC:I

Arquitectura en capas:

```
RESTAURANTE (formularios)  ──►  NEGOCIO (servicios, reglas, interfaces)  ◄──  DATOS (SQL Server)
          │                                  │                                        │
          └──────────────── ENTIDADES (clases de datos compartidas) ◄─────────────────┘
```

Las interfaces de **NEGOCIO** las implementa **DATOS**; por eso la dependencia apunta hacia NEGOCIO.
`FabricaServicios` es el único lugar donde se juntan las capas.

En el código, cada clase clave lleva un comentario `// SOLID: SRP | OCP | DIP – ...`.
Para encontrarlas todas: **Ctrl+Shift+F → `SOLID:`**.

---

## SRP – Principio de Responsabilidad Única

> *Una clase debe tener una sola razón para cambiar.*

### 1. `CalculadoraPedido` solo calcula montos

**Archivo:** `NEGOCIO/Servicios/CalculadoraPedido.cs` · **líneas 8–49**

```csharp
// SOLID: SRP – Solo calcula montos (subtotal, descuento, IGV y total). No toca la BD ni la pantalla.
public class CalculadoraPedido
{
    public const decimal TASA_IGV = 0.18m;
    ...
    public ENTIDAD_RESUMEN_PEDIDO Calcular(ENTIDAD_PEDIDO_CAJA pedido)
    {
        foreach (ENTIDAD_LINEA_PEDIDO linea in pedido.Lineas)
        {
            foreach (IReglaDescuento regla in _reglas)        // mejor descuento por línea
            { ... }
            resumen.Subtotal += linea.Subtotal;
            resumen.Descuento += linea.Descuento_Unitario * linea.Cantidad;
        }
        resumen.Total = resumen.Subtotal - resumen.Descuento;
        resumen.Base_Imponible = Math.Round(resumen.Total / (1 + TASA_IGV), 2);
        resumen.IGV = resumen.Total - resumen.Base_Imponible;
        return resumen;
    }
}
```

**Explicación:** la calculadora no guarda en la BD, no muestra mensajes y no descuenta inventario.
Si cambia la tasa del IGV o la forma de redondear, solo se modifica esta clase.
La Caja la usa para mostrar el total en vivo y `ServicioVenta` la usa al cobrar.

### 2. `ServicioInventario` solo sabe de inventario

**Archivo:** `NEGOCIO/Servicios/ServicioInventario.cs` · **líneas 21–44**

```csharp
// Suma la receta (Plato_Insumo) de cada línea x cantidad, agrupado por insumo
public List<ENTIDAD_CONSUMO_INSUMO> Calcular_Consumo(string idSede, IEnumerable<ENTIDAD_LINEA_PEDIDO> lineas)
{
    foreach (ENTIDAD_LINEA_PEDIDO linea in lineas)
        foreach (ENTIDAD_RECETA_INSUMO item in _repositorio.Cargar_Receta(linea.Producto.ID_Plato))
        {
            ...
            consumos[item.ID_Insumo].Cantidad_Requerida += item.Cant_Necesaria * linea.Cantidad;
        }
    return consumos.Values.ToList();
}
```

**Explicación:** calcular cuánto consume un pedido según la receta y validar el stock es una sola responsabilidad.
La usan la Caja (aviso de stock), `ServicioVenta` (descuento) y la pantalla de Inventario ("Ver consumo").

**Otras clases SRP:**
- `GeneradorCodigo`: arma `C0001`, `P00001`...
- `ValidadorCliente`: valida nombre, teléfono, email y RUC.
- `ServicioAutenticacion`: compara el hash SHA256.
- `ServicioVenta`: coordina el cobro, pero delega los cálculos y el inventario.
- `EstadosPedido`: define el orden Pendiente → En preparación → Listo → Entregado.

---

## OCP – Principio Abierto/Cerrado

> *Abierto para extender, cerrado para modificar.*

### 1. Descuentos: `IReglaDescuento`

**Archivo:** `NEGOCIO/Descuentos/IReglaDescuento.cs` · **líneas 5–13**

```csharp
// SOLID: OCP – Cada descuento es una clase que implementa esta interfaz.
public interface IReglaDescuento
{
    string Nombre { get; }
    decimal Descuento_Unitario(ENTIDAD_LINEA_PEDIDO linea, ENTIDAD_PEDIDO_CAJA pedido);
}
```

**Archivo:** `NEGOCIO/Descuentos/DescuentoClienteFrecuente.cs` · **líneas 6–26** (regla agregada sin tocar las demás)

```csharp
public class DescuentoClienteFrecuente : IReglaDescuento
{
    public decimal Descuento_Unitario(ENTIDAD_LINEA_PEDIDO linea, ENTIDAD_PEDIDO_CAJA pedido)
    {
        if (pedido.Compras_Cliente < _comprasMinimas)
            return 0m;
        return Math.Round(linea.Producto.Precio * _porcentaje / 100m, 2);
    }
}
```

**Archivo:** `FabricaServicios.cs` · **líneas 19–28** (único punto donde se registran)

```csharp
public List<IReglaDescuento> Reglas_Descuento()
{
    return new List<IReglaDescuento>
    {
        new SinDescuento(),
        new DescuentoPromocion(),               // según Promocion.Fec_Inicio / Fec_Fin / Descuento
        new DescuentoClienteFrecuente(10, 5m)   // 5 % desde la compra n.º 10
    };
}
```

**Explicación:** para crear un descuento nuevo (por ejemplo, "Martes 2x1") se escribe otra clase que implemente `IReglaDescuento` y se agrega a esta lista.
`CalculadoraPedido` recorre las reglas sin saber cuáles son, así que **no se modifica**.

### 2. Comprobantes: `IComprobante` (Boleta / Factura)

**Archivos:** `NEGOCIO/Comprobantes/IComprobante.cs` (líneas 8–21), `Factura.cs` (líneas 7–39), `FabricaServicios.cs` (líneas 30–34)

```csharp
public interface IComprobante
{
    string Tipo { get; }
    bool Requiere_RUC { get; }
    string Validar(ENTIDAD_PEDIDO_CAJA pedido);               // Factura: RUC de 11 dígitos
    List<string> Lineas_Cliente(ENTIDAD_PEDIDO_CAJA pedido);
    List<string> Lineas_Totales(ENTIDAD_RESUMEN_PEDIDO resumen); // Factura: desglosa IGV 18 %
}
```

**Explicación:** la Caja trabaja con `IComprobante` y no pregunta si es Boleta o Factura.
Una "Nota de Venta" sería una clase nueva agregada en `FabricaServicios.Comprobantes()`, sin tocar `FrmCaja` ni `ServicioVenta`.

---

## DIP – Principio de Inversión de Dependencias

> *Los módulos de alto nivel dependen de abstracciones, no de clases concretas.*

### 1. La abstracción vive en NEGOCIO

**Archivo:** `NEGOCIO/Interfaces/IClienteRepositorio.cs` · **líneas 6–15**

```csharp
// SOLID: DIP – Formularios y servicios dependen de este contrato, no de DATOS_CLIENTE ni de SQL Server.
public interface IClienteRepositorio
{
    DataTable Cargar_Cliente();
    void Agregar_Cliente(ENTIDAD_CLIENTE cliente);
    void Modificar_Cliente(ENTIDAD_CLIENTE cliente);
    void Eliminar_Cliente(string idCliente);
    string Ultimo_Codigo();
    int Contar_Compras(string idCliente);
}
```

### 2. DATOS la implementa

**Archivo:** `DATOS/DATOS_CLIENTE.cs` · **línea 14**

```csharp
public class DATOS_CLIENTE : IClienteRepositorio
```

### 3. El formulario la recibe por constructor

**Archivo:** `Cliente.cs` · **líneas 14–23**

```csharp
// SOLID: DIP – el formulario depende de la interfaz IClienteRepositorio, no de DATOS_CLIENTE.
private readonly IClienteRepositorio _repositorio;

public Cliente(IClienteRepositorio repositorio)
{
    InitializeComponent();
    _repositorio = repositorio;
}
```

**Antes** el formulario hacía `private DATOS_CLIENTE datosCliente = new DATOS_CLIENTE();` y quedaba atado a SQL Server.

### 4. Un solo lugar arma las dependencias: `FabricaServicios` (composition root)

**Archivo:** `FabricaServicios.cs` · **líneas 7–17** y `Program.cs`

```csharp
public class FabricaServicios
{
    public IClienteRepositorio Clientes { get; } = new DATOS_CLIENTE();
    public IVentaRepositorio Ventas { get; } = new DATOS_VENTA();
    ...
    public ServicioVenta Crear_Servicio_Venta()
    {
        return new ServicioVenta(new CalculadoraPedido(Reglas_Descuento()),
                                 Crear_Servicio_Inventario(), Ventas, Clientes);
    }
}
```

**Explicación:** `Cliente`, `FrmCaja`, `FrmCocina` y `ServicioVenta` reciben interfaces.
Para usar otra base de datos, o un repositorio falso en pruebas, solo cambia `FabricaServicios`; los formularios y servicios no se tocan.

---

## Bonus: la venta "todo o nada"

**Archivo:** `DATOS/DATOS_VENTA.cs` · **líneas 193–300** (`Registrar_Venta`)

`BeginTransaction()` (línea 199) → inserta Pedido, Venta, Detalle_Pedido y Detalle_Venta → descuenta Inventario solo si alcanza (`Cant_Total >= @Cantidad`) → `Commit()` (línea 283).
Si cualquier paso falla, se ejecuta `Rollback()` (línea 296) y no queda nada a medias.
