using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class ENTIDAD_PROMOCION
    {
        public string ID_Promocion { get; set; }
        public string Nom_Promocion { get; set; }
        public DateTime Fec_Inicio { get; set; }
        public DateTime Fec_Fin { get; set; }
        public decimal Descuento { get; set; }
    }
}
