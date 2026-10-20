using System.Collections.Generic;
using DATOS;
using NEGOCIO;

namespace RESTAURANTEFINAL
{
    // SOLID: DIP – "Composition root": el ÚNICO lugar donde se eligen las clases concretas de DATOS.
    // Formularios y servicios solo reciben interfaces (IClienteRepositorio, IVentaRepositorio, ...).
    public class FabricaServicios
    {
        public IClienteRepositorio Clientes { get; } = new DATOS_CLIENTE();
        public IProductoRepositorio Productos { get; } = new DATOS_PLATO();
        public IPedidoRepositorio Pedidos { get; } = new DATOS_PEDIDO();
        public IVentaRepositorio Ventas { get; } = new DATOS_VENTA();
        public IInventarioRepositorio Inventario { get; } = new DATOS_INVENTARIO();
        public IUsuarioRepositorio Usuarios { get; } = new DATOS_USUARIO();
        public IReporteRepositorio Reportes { get; } = new DATOS_REPORTE();

        // SOLID: OCP – para agregar un descuento nuevo solo se añade su clase a esta lista
        public List<IReglaDescuento> Reglas_Descuento()
        {
            return new List<IReglaDescuento>
            {
                new SinDescuento(),
                new DescuentoPromocion(),
                new DescuentoClienteFrecuente(10, 5m)   // 5 % desde la compra n.º 10
            };
        }

        // SOLID: OCP – un comprobante nuevo (ej. Nota de Venta) se agrega aquí sin tocar la Caja
        public List<IComprobante> Comprobantes()
        {
            return new List<IComprobante> { new Boleta(), new Factura() };
        }

        public ServicioAutenticacion Crear_Servicio_Autenticacion()
        {
            return new ServicioAutenticacion(Usuarios);
        }

        public ServicioInventario Crear_Servicio_Inventario()
        {
            return new ServicioInventario(Inventario);
        }

        public ServicioVenta Crear_Servicio_Venta()
        {
            return new ServicioVenta(new CalculadoraPedido(Reglas_Descuento()),
                                     Crear_Servicio_Inventario(), Ventas, Clientes);
        }
    }
}
