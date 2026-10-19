using System.Collections.Generic;
using ENTIDADES;

namespace NEGOCIO
{
    // Boleta: el cliente es opcional ("Cliente varios") y se muestra solo el total
    public class Boleta : IComprobante
    {
        public string Tipo { get { return "Boleta"; } }
        public bool Requiere_RUC { get { return false; } }

        public string Validar(ENTIDAD_PEDIDO_CAJA pedido)
        {
            return null;
        }

        public List<string> Lineas_Cliente(ENTIDAD_PEDIDO_CAJA pedido)
        {
            string cliente = string.IsNullOrWhiteSpace(pedido.Nom_Cliente) ? "Cliente varios" : pedido.Nom_Cliente;
            return new List<string> { "Cliente: " + cliente };
        }

        public List<string> Lineas_Totales(ENTIDAD_RESUMEN_PEDIDO resumen)
        {
            return new List<string> { "TOTAL: S/ " + resumen.Total.ToString("N2") };
        }
    }
}
