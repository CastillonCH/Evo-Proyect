using System;

namespace ENTIDADES
{
    // Lo que devuelve el cobro: códigos generados y montos
    public class ENTIDAD_RESULTADO_VENTA
    {
        public string ID_Pedido { get; set; }
        public string ID_Venta { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo_Comprobante { get; set; }
        public ENTIDAD_RESUMEN_PEDIDO Resumen { get; set; }
    }
}
