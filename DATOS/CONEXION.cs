using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace DATOS
{
    public static class CONEXION
    {
        // Cadena de conexión estática para la base de datos
        public static SqlConnection cn = new SqlConnection
            ("Server=Infinity;Database=RestauranteBD;Trusted_Connection=True;");
    }
}
