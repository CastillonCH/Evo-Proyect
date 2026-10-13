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
    public class DATOS_PLATO
    {
        public void Agregar_Plato(ENTIDAD_PLATO plato)
        {
            string query = "INSERT INTO Plato (ID_Plato, Nom_Plato, Des_Plato, Prec_Original, ID_Promocion) " +
                   "VALUES (@ID_Plato, @Nom_Plato, @Des_Plato, @Prec_Original, @ID_Promocion)";
            try
            {
                using (SqlConnection connection = new SqlConnection(CONEXION.cn.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID_Plato", plato.ID_Plato);
                        cmd.Parameters.AddWithValue("@Nom_Plato", plato.Nom_Plato);
                        cmd.Parameters.AddWithValue("@Des_Plato", plato.Des_Plato);
                        cmd.Parameters.AddWithValue("@Prec_Original", plato.Prec_Original);

                        if (plato.ID_Promocion == null)
                            cmd.Parameters.AddWithValue("@ID_Promocion", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@ID_Promocion", plato.ID_Promocion);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el plato: " + ex.Message);
            }
        }

        public void Modificar_Plato(ENTIDAD_PLATO plato)
        {
            string query = "UPDATE Plato SET Nom_Plato = @Nom_Plato, Des_Plato = @Des_Plato, " +
                           "Prec_Original = @Prec_Original, ID_Promocion = @ID_Promocion " +
                           "WHERE ID_Plato = @ID_Plato";
            try
            {
                using (SqlConnection connection = new SqlConnection(CONEXION.cn.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID_Plato", plato.ID_Plato);
                        cmd.Parameters.AddWithValue("@Nom_Plato", plato.Nom_Plato);
                        cmd.Parameters.AddWithValue("@Des_Plato", plato.Des_Plato);
                        cmd.Parameters.AddWithValue("@Prec_Original", plato.Prec_Original);
                        cmd.Parameters.AddWithValue("@ID_Promocion", plato.ID_Promocion);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el plato: " + ex.Message);
            }
        }

        public void Eliminar_Plato(string idPlato)
        {
            string query = "DELETE FROM Plato WHERE ID_Plato = @ID_Plato";
            try
            {
                using (SqlConnection connection = new SqlConnection(CONEXION.cn.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID_Plato", idPlato);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el plato: " + ex.Message);
            }
        }

        public DataTable Cargar_Plato()
        {
            string query = "SELECT ID_Plato, Nom_Plato, Des_Plato, Prec_Original, ID_Promocion FROM Plato";
            try
            {
                using (SqlConnection connection = new SqlConnection(CONEXION.cn.ConnectionString))
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
                throw new Exception("Error al cargar los platos: " + ex.Message);
            }
        }

        public DataTable Cargar_Promociones()
        {
            string query = "SELECT ID_Promocion, Nom_Promocion FROM Promocion";
            try
            {
                using (SqlConnection connection = new SqlConnection(CONEXION.cn.ConnectionString))
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
                throw new Exception("Error al cargar las promociones: " + ex.Message);
            }
        }
    }
}
