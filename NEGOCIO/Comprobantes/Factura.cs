using System.Collections.Generic;
using ENTIDADES;

namespace NEGOCIO
{
    // Factura: exige RUC de 11 dígitos y razón social, y desglosa el IGV (18 %)
    public class Factura : IComprobante
    {
        public string Tipo { get { return "Factura"; } }

        public string Validar(ENTIDAD_PEDIDO_CAJA pedido)
        {
            if (!ValidadorCliente.Es_RUC_Valido(pedido.RUC))
                return "Para emitir factura ingrese un RUC de 11 dígitos.";
            if (string.IsNullOrWhiteSpace(pedido.Razon_Social))
                return "Para emitir factura ingrese la razón social.";
            return null;
        }

        public List<string> Lineas_Cliente(ENTIDAD_PEDIDO_CAJA pedido)
        {
            return new List<string>
            {
                "RUC: " + pedido.RUC,
                "Razón social: " + pedido.Razon_Social
            };
        }

        public List<string> Lineas_Totales(ENTIDAD_RESUMEN_PEDIDO resumen)
        {
            return new List<string>
            {
                "Op. gravada: S/ " + resumen.Base_Imponible.ToString("N2"),
                "IGV (18 %): S/ " + resumen.IGV.ToString("N2"),
                "TOTAL: S/ " + resumen.Total.ToString("N2")
            };
        }
    }
}
