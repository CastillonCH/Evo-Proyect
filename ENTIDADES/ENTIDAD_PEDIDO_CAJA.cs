using System;
using System.Collections.Generic;

namespace ENTIDADES
{
    // Pedido que arma el cajero antes de cobrar
    public class ENTIDAD_PEDIDO_CAJA
    {
        public string ID_Sede { get; set; }
        public string ID_Cliente { get; set; }
        public string Nom_Cliente { get; set; }
        public int Compras_Cliente { get; set; }
        public string Tipo_Pedido { get; set; }      // Comer aquí / Para llevar / Delivery
        public string ID_Metodo_Pago { get; set; }
        public string Observaciones { get; set; }
        public string RUC { get; set; }
        public string Razon_Social { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public List<ENTIDAD_LINEA_PEDIDO> Lineas { get; set; } = new List<ENTIDAD_LINEA_PEDIDO>();
    }
}
