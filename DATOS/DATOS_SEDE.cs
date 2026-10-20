using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using ENTIDADES;
using System.Data;
using System.Data.SqlClient;

namespace DATOS
{
    public class DATOS_SEDE
    {
        public void Agregar_Sede(ENTIDAD_SEDE sede)
        {
            string query = "INSERT INTO Sede (ID_Sede, Nom_Sede, Dir_Sede, Tel_Sede, Hora_Apertura, Hora_Cierre) " +
                           "VALUES (@ID_Sede, @Nom_Sede, @Dir_Sede, @Tel_Sede, @Hora_Apertura, @Hora_Cierre)";

            try
            {
                using (SqlConnection connection = CONEXION.Crear())
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Configurar los parámetros
                        cmd.Parameters.AddWithValue("@ID_Sede", sede.ID_Sede);
                        cmd.Parameters.AddWithValue("@Nom_Sede", sede.Nom_Sede);
                        cmd.Parameters.AddWithValue("@Dir_Sede", sede.Dir_Sede);
                        cmd.Parameters.AddWithValue("@Tel_Sede", sede.Tel_Sede);
                        cmd.Parameters.AddWithValue("@Hora_Apertura", sede.Hora_Apertura);
                        cmd.Parameters.AddWithValue("@Hora_Cierre", sede.Hora_Cierre);

                        // Abrir conexión y ejecutar el comando
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar sede: " + ex.Message, ex);
            }
        }

        public DataTable Cargar_Sede()
        {
            string query = "SELECT ID_Sede, Nom_Sede, Dir_Sede, Tel_Sede, Hora_Apertura, Hora_Cierre FROM Sede";

            try
            {
                using (SqlConnection connection = CONEXION.Crear())
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar los datos de las sedes: " + ex.Message, ex);
            }
        }

        public void Eliminar_Sede(string idSede)
        {
            string query = "DELETE FROM Sede WHERE ID_Sede = @ID_Sede";

            try
            {
                using (SqlConnection connection = CONEXION.Crear())
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID_Sede", idSede);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar sede: " + ex.Message, ex);
            }
        }

        public void Modificar_Sede(ENTIDAD_SEDE sede)
        {
            string query = "UPDATE Sede SET Nom_Sede = @Nom_Sede, Dir_Sede = @Dir_Sede, Tel_Sede = @Tel_Sede, " +
                           "Hora_Apertura = @Hora_Apertura, Hora_Cierre = @Hora_Cierre WHERE ID_Sede = @ID_Sede";

            try
            {
                using (SqlConnection connection = CONEXION.Crear())
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID_Sede", sede.ID_Sede);
                        cmd.Parameters.AddWithValue("@Nom_Sede", sede.Nom_Sede);
                        cmd.Parameters.AddWithValue("@Dir_Sede", sede.Dir_Sede);
                        cmd.Parameters.AddWithValue("@Tel_Sede", sede.Tel_Sede);
                        cmd.Parameters.AddWithValue("@Hora_Apertura", sede.Hora_Apertura);
                        cmd.Parameters.AddWithValue("@Hora_Cierre", sede.Hora_Cierre);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar sede: " + ex.Message, ex);
            }
        }
    }
}
