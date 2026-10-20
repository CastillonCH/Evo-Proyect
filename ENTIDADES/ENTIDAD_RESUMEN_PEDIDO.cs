namespace ENTIDADES
{
    // Montos calculados del pedido (los precios ya incluyen IGV)
    public class ENTIDAD_RESUMEN_PEDIDO
    {
        public decimal Subtotal { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }
        public decimal Base_Imponible { get; set; }
        public decimal IGV { get; set; }
    }
}
