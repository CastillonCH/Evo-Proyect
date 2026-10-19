namespace ENTIDADES
{
    // Una línea del carrito: producto + cantidad
    public class ENTIDAD_LINEA_PEDIDO
    {
        public ENTIDAD_PRODUCTO_CAJA Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Descuento_Unitario { get; set; }   // lo llena CalculadoraPedido
        public string Descuento_Aplicado { get; set; }    // nombre de la regla usada

        public decimal Precio_Final { get { return Producto.Precio - Descuento_Unitario; } }
        public decimal Subtotal { get { return Producto.Precio * Cantidad; } }
        public decimal Total { get { return Precio_Final * Cantidad; } }
    }
}
