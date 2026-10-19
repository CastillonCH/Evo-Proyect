using ENTIDADES;

namespace NEGOCIO
{
    // Regla por defecto: precio normal
    public class SinDescuento : IReglaDescuento
    {
        public string Nombre { get { return "Sin descuento"; } }

        public decimal Descuento_Unitario(ENTIDAD_LINEA_PEDIDO linea, ENTIDAD_PEDIDO_CAJA pedido)
        {
            return 0m;
        }
    }
}
