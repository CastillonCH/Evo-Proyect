using System;
using ENTIDADES;

namespace NEGOCIO
{
    // SOLID: OCP – Nueva regla agregada sin tocar las demás: % de descuento si el cliente ya tiene N compras.
    public class DescuentoClienteFrecuente : IReglaDescuento
    {
        private readonly int _comprasMinimas;
        private readonly decimal _porcentaje;

        public DescuentoClienteFrecuente(int comprasMinimas, decimal porcentaje)
        {
            _comprasMinimas = comprasMinimas;
            _porcentaje = porcentaje;
        }

        public string Nombre { get { return "Cliente frecuente"; } }

        public decimal Descuento_Unitario(ENTIDAD_LINEA_PEDIDO linea, ENTIDAD_PEDIDO_CAJA pedido)
        {
            if (pedido.Compras_Cliente < _comprasMinimas)
                return 0m;
            return Math.Round(linea.Producto.Precio * _porcentaje / 100m, 2);
        }
    }
}
