using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class ENTIDAD_INSUMO
    {
        public string ID_Insumo { get; set; }
        public string Nombre { get; set; }
        public string ID_Unidad_Medida { get; set; }
        public decimal Precio_Unitario { get; set; }
        public string ID_Clasificacion { get; set; }
    }
}
