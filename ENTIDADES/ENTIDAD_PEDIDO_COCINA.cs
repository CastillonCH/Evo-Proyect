using System;

namespace ENTIDADES
{
    // Pedido como lo ve la cocina (tarjeta)
    public class ENTIDAD_PEDIDO_COCINA
    {
        public string ID_Pedido { get; set; }
        public DateTime Fec_Pedido { get; set; }
        public string Estado_Pedido { get; set; }
        public string Tipo_Pedido { get; set; }
        public string Cliente { get; set; }
        public string Observaciones { get; set; }
        public string Detalle { get; set; }      // "2 x Hamburguesa Clasica" (una línea por plato)
    }
}
