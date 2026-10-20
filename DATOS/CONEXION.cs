using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace DATOS
{
    public static class CONEXION
    {
        // Nombre de la cadena de conexión definida en App.config (proyecto RESTAURANTE)
        private const string NOMBRE_CADENA = "RestauranteBD";

        // Lee la cadena de conexión desde App.config
        public static string Cadena
        {
            get
            {
                ConnectionStringSettings cadena = ConfigurationManager.ConnectionStrings[NOMBRE_CADENA];
                if (cadena == null)
                    throw new InvalidOperationException("No se encontró la cadena de conexión '" + NOMBRE_CADENA + "' en App.config.");
                return cadena.ConnectionString;
            }
        }

        // Cada operación crea (y cierra con using) su propia conexión
        public static SqlConnection Crear()
        {
            return new SqlConnection(Cadena);
        }

        // Devuelve el último código con el formato prefijo + dígitos (ej. C0001, P00001).
        // Dentro de una transacción bloquea la tabla para que dos cajas no generen el mismo código.
        public static string Ultimo_Codigo(SqlConnection connection, SqlTransaction transaccion,
                                           string tabla, string columna, string prefijo, int digitos)
        {
            string patron = prefijo + string.Concat(Enumerable.Repeat("[0-9]", digitos));
            string query = "SELECT MAX(" + columna + ") FROM " + tabla + " WITH (UPDLOCK, HOLDLOCK) " +
                           "WHERE " + columna + " LIKE @Patron";
            using (SqlCommand cmd = new SqlCommand(query, connection, transaccion))
            {
                cmd.Parameters.AddWithValue("@Patron", patron);
                object resultado = cmd.ExecuteScalar();
                return resultado == DBNull.Value ? null : (string)resultado;
            }
        }
    }
}
