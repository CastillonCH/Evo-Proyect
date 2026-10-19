using System;

namespace ENTIDADES
{
    // Producto (plato) tal como se muestra en la Caja, con los datos de su promoción
    public class ENTIDAD_PRODUCTO_CAJA
    {
        public string ID_Plato { get; set; }
        public string Nom_Plato { get; set; }
        public decimal Precio { get; set; }
        public string ID_Promocion { get; set; }
        public string Nom_Promocion { get; set; }
        public decimal Porc_Descuento { get; set; }   // Promocion.Descuento (ej. 20.00 = 20 %)
        public DateTime? Promo_Inicio { get; set; }
        public DateTime? Promo_Fin { get; set; }
    }
}
