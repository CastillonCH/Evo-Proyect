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
    public class DATOS_PROMOCION
    {
        public void Agregar_Promocion(ENTIDAD_PROMOCION promocion)
        {
            string query = "INSERT INTO Promocion (ID_Promocion, Nom_Promocion, Fec_Inicio, Fec_Fin, Descuento) " +
                           "VALUES (@ID_Promocion, @Nom_Promocion, @Fec_Inicio, @Fec_Fin, @Descuento)";
            try
            {
                using (SqlConnection connection = CONEXION.Crear())
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID_Promocion", promocion.ID_Promocion);
                        cmd.Parameters.AddWithValue("@Nom_Promocion", promocion.Nom_Promocion);
                        cmd.Parameters.AddWithValue("@Fec_Inicio", promocion.Fec_Inicio);
                        cmd.Parameters.AddWithValue("@Fec_Fin", promocion.Fec_Fin);
                        cmd.Parameters.AddWithValue("@Descuento", promocion.Descuento);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar la promoción: " + ex.Message, ex);
            }
        }

        public void Modificar_Promocion(ENTIDAD_PROMOCION promocion)
        {
            string query = "UPDATE Promocion SET Nom_Promocion = @Nom_Promocion, Fec_Inicio = @Fec_Inicio, Fec_Fin = @Fec_Fin, Descuento = @Descuento WHERE ID_Promocion = @ID_Promocion";
            try
            {
                using (SqlConnection connection = CONEXION.Crear())
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID_Promocion", promocion.ID_Promocion);
                        cmd.Parameters.AddWithValue("@Nom_Promocion", promocion.Nom_Promocion);
                        cmd.Parameters.AddWithValue("@Fec_Inicio", promocion.Fec_Inicio);
                        cmd.Parameters.AddWithValue("@Fec_Fin", promocion.Fec_Fin);
                        cmd.Parameters.AddWithValue("@Descuento", promocion.Descuento);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar la promoción: " + ex.Message, ex);
            }
        }

        public void Eliminar_Promocion(string idPromocion)
        {
            string query = "DELETE FROM Promocion WHERE ID_Promocion = @ID_Promocion";
            try
            {
                using (SqlConnection connection = CONEXION.Crear())
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID_Promocion", idPromocion);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la promoción: " + ex.Message, ex);
            }
        }

        public DataTable Cargar_Promocion()
        {
            string query = "SELECT ID_Promocion, Nom_Promocion, Fec_Inicio, Fec_Fin, Descuento FROM Promocion";
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
                throw new Exception("Error al cargar las promociones: " + ex.Message, ex);
            }
        }
    }
}
