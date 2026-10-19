using System;
using ENTIDADES;

namespace NEGOCIO
{
    // SOLID: OCP – Aplica Promocion.Descuento (%) solo si la fecha del pedido está entre Fec_Inicio y Fec_Fin.
    public class DescuentoPromocion : IReglaDescuento
    {
        public string Nombre { get { return "Promoción"; } }

        public decimal Descuento_Unitario(ENTIDAD_LINEA_PEDIDO linea, ENTIDAD_PEDIDO_CAJA pedido)
        {
            if (!Esta_Vigente(linea.Producto, pedido.Fecha))
                return 0m;
            return Math.Round(linea.Producto.Precio * linea.Producto.Porc_Descuento / 100m, 2);
        }

        // También lo usa la Caja para pintar el "badge" de promoción
        public static bool Esta_Vigente(ENTIDAD_PRODUCTO_CAJA producto, DateTime fecha)
        {
            return producto.ID_Promocion != null
                && producto.Promo_Inicio.HasValue && producto.Promo_Fin.HasValue
                && fecha.Date >= producto.Promo_Inicio.Value.Date
                && fecha.Date <= producto.Promo_Fin.Value.Date;
        }
    }
}
