using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class ENTIDAD_DETALLE_PEDIDO
    {
        public string ID_Detalle_Pedido { get; set; }
        public string ID_Pedido { get; set; }
        public string ID_Plato { get; set; }
        public string  Cantidad { get; set; }
        public string Pre_Unitario_Final {  get; set; }
    }
}
