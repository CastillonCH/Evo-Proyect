using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class ENTIDAD_EMPLEADO
    {
        public string ID_Empleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono {  get; set; }
        public string Email { get; set; }
        public DateTime Fec_Contratacion {  get; set; }
        public string ID_Rol {  get; set; }
    }
}
