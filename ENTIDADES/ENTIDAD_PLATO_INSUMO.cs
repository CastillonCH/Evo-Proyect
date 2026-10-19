using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class ENTIDAD_PLATO_INSUMO
    {
        public string ID_Plato {  get; set; }
        public string ID_Insumo { get; set; }
        public decimal Cant_Necesaria { get; set; }
        public string Procedimiento { get; set; }
    }
}
