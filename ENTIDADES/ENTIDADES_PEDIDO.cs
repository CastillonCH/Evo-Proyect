using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class ENTIDADES_PEDIDO
    {
        public string ID_Pedido {  get; set; }
        public string ID_Cliente {  get; set; }
        public DateTime Fec_Pedido { get; set; }
        public string Estado_Pedido { get; set; }
        public string Observaciones {  get; set; }
    }
}
