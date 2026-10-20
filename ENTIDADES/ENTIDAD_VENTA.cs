using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class ENTIDAD_VENTA
    {
        public string ID_Venta { get; set; }
        public string  ID_Pedido { get; set; }
        public DateTime Fec_Venta { get; set; }
        public decimal Monto_Total {  get; set; }
        public string ID_Metodo_Pago {  get; set; }
        public string ID_Sede {  get; set; }
    }
}
