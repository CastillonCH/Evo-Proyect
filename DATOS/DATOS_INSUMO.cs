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
    public class DATOS_INSUMO
    {
        public void Agregar_Insumo(ENTIDAD_INSUMO insumo)
        {
            string query = "Agregar_Insumo";  // Procedimiento almacenado Agregar_Insumo
            try
            {
                using (SqlConnection connection = CONEXION.Crear())
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;  // Definir el tipo de comando como StoredProcedure
                        cmd.Parameters.AddWithValue("@ID_Insumo", insumo.ID_Insumo);
                        cmd.Parameters.AddWithValue("@Nombre", insumo.Nombre);
                        cmd.Parameters.AddWithValue("@ID_Unidad_Medida", insumo.ID_Unidad_Medida);
                        cmd.Parameters.AddWithValue("@Precio_Unitario", insumo.Precio_Unitario);
                        cmd.Parameters.AddWithValue("@ID_Clasificacion", insumo.ID_Clasificacion);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el insumo: " + ex.Message, ex);
            }
        }

        public void Modificar_Insumo(ENTIDAD_INSUMO insumo)
        {
            string query = "Modificar_Insumo";  // Procedimiento almacenado Modificar_Insumo
            try
            {
                using (SqlConnection connection = CONEXION.Crear())
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;  // Definir el tipo de comando como StoredProcedure
                        cmd.Parameters.AddWithValue("@ID_Insumo", insumo.ID_Insumo);
                        cmd.Parameters.AddWithValue("@Nombre", insumo.Nombre);
                        cmd.Parameters.AddWithValue("@ID_Unidad_Medida", insumo.ID_Unidad_Medida);
                        cmd.Parameters.AddWithValue("@Precio_Unitario", insumo.Precio_Unitario);
                        cmd.Parameters.AddWithValue("@ID_Clasificacion", insumo.ID_Clasificacion);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el insumo: " + ex.Message, ex);
            }
        }

        public void Eliminar_Insumo(string idInsumo)
        {
            string query = "Eliminar_Insumo";  // Procedimiento almacenado Eliminar_Insumo
            try
            {
                using (SqlConnection connection = CONEXION.Crear())
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;  // Definir el tipo de comando como StoredProcedure
                        cmd.Parameters.AddWithValue("@ID_Insumo", idInsumo);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el insumo: " + ex.Message, ex);
            }
        }

        public DataTable Cargar_Insumo()
        {
            string query = "Cargar_Insumos";  // Procedimiento almacenado Cargar_Insumos
            try
            {
                using (SqlConnection connection = CONEXION.Crear())
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;  // Definir el tipo de comando como StoredProcedure
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

       
        public DataTable Cargar_Unidad_Medida()
        {
            string query = "cargar_unidad_medida";  // Procedimiento almacenado Cargar_Unidad_Medida
            try
            {
                using (SqlConnection connection = CONEXION.Crear())
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;  // Definir el tipo de comando como StoredProcedure
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
                throw new Exception("Error al cargar las unidades de medida: " + ex.Message, ex);
            }
        }

        public DataTable Cargar_Clasificacion()
        {
            string query = "cargar_clasificacion";  // Procedimiento almacenado Cargar_Clasificacion
            try
            {
                using (SqlConnection connection = CONEXION.Crear())
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;  // Definir el tipo de comando como StoredProcedure
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
                throw new Exception("Error al cargar las clasificaciones: " + ex.Message, ex);
            }
        }

    }
}
