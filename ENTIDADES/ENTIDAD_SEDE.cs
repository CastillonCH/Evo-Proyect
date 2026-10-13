using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class ENTIDAD_SEDE
    {
        public string ID_Sede { get; set; }
        public string Nom_Sede { get; set; }
        public string Dir_Sede { get; set; }
        public string Tel_Sede { get; set; } 
        public DateTime Hora_Apertura { get; set; }
        public DateTime Hora_Cierre { get; set; }
    }
}
