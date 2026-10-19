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
    public class DATOS_PLATO_INSUMO
    {
        // Método para agregar un nuevo Plato-Insumo
        public void Agregar_PlatoInsumo(ENTIDADES.ENTIDAD_PLATO_INSUMO platoInsumo)
        {
            string query = "INSERT INTO Plato_Insumo (ID_Plato, ID_Insumo, Cant_Necesaria, Procedimiento) " +
                           "VALUES (@ID_Plato, @ID_Insumo, @Cant_Necesaria, @Procedimiento)";

            try
            {
                using (SqlConnection connection = CONEXION.Crear())
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID_Plato", platoInsumo.ID_Plato);
                        cmd.Parameters.AddWithValue("@ID_Insumo", platoInsumo.ID_Insumo);
                        cmd.Parameters.AddWithValue("@Cant_Necesaria", platoInsumo.Cant_Necesaria);
                        cmd.Parameters.AddWithValue("@Procedimiento", platoInsumo.Procedimiento);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el plato-insumo: " + ex.Message, ex);
            }
        }

        // Método para modificar un Plato-Insumo existente
        public void Modificar_PlatoInsumo(ENTIDADES.ENTIDAD_PLATO_INSUMO platoInsumo)
        {
            string query = "UPDATE Plato_Insumo SET Cant_Necesaria = @Cant_Necesaria, Procedimiento = @Procedimiento " +
                           "WHERE ID_Plato = @ID_Plato AND ID_Insumo = @ID_Insumo";

            try
            {
                using (SqlConnection connection = CONEXION.Crear())
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID_Plato", platoInsumo.ID_Plato);
                        cmd.Parameters.AddWithValue("@ID_Insumo", platoInsumo.ID_Insumo);
                        cmd.Parameters.AddWithValue("@Cant_Necesaria", platoInsumo.Cant_Necesaria);
                        cmd.Parameters.AddWithValue("@Procedimiento", platoInsumo.Procedimiento);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el plato-insumo: " + ex.Message, ex);
            }
        }

        // Método para eliminar un Plato-Insumo
        public void Eliminar_PlatoInsumo(string idPlato, string idInsumo)
        {
            string query = "DELETE FROM Plato_Insumo WHERE ID_Plato = @ID_Plato AND ID_Insumo = @ID_Insumo";

            try
            {
                using (SqlConnection connection = CONEXION.Crear())
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID_Plato", idPlato);
                        cmd.Parameters.AddWithValue("@ID_Insumo", idInsumo);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el plato-insumo: " + ex.Message, ex);
            }
        }

        // Método para cargar todos los Plato-Insumos
        public DataTable Cargar_PlatoInsumo()
        {
            string query = "SELECT ID_Plato, ID_Insumo, Cant_Necesaria, Procedimiento FROM Plato_Insumo";

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
                throw new Exception("Error al cargar los platos-insumos: " + ex.Message, ex);
            }
        }
        // Método para cargar los platos desde la base de datos
        public DataTable CargarPlatos()
        {
            string query = "SELECT ID_Plato, Nom_Plato FROM Plato";

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
                throw new Exception("Error al cargar los platos: " + ex.Message, ex);
            }
        }

        // Método para cargar los insumos desde la base de datos
        public DataTable CargarInsumos()
        {
            string query = "SELECT ID_Insumo, Nombre FROM Insumo";

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
                throw new Exception("Error al cargar los insumos: " + ex.Message, ex);
            }
        }
    }
}
