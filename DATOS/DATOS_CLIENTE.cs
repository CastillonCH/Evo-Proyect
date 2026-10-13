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
    public class DATOS_CLIENTE
    {
        public void Agregar_Cliente(ENTIDAD_CLIENTE cliente)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(CONEXION.cn.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("Agregar_Cliente", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ID_Cliente", cliente.ID_Cliente);
                        cmd.Parameters.AddWithValue("@Nom_Cliente", cliente.Nom_Cliente);
                        cmd.Parameters.AddWithValue("@Ape_Cliente", cliente.Ape_Cliente);
                        cmd.Parameters.AddWithValue("@Tel_Cliente", cliente.Tel_Cliente);
                        cmd.Parameters.AddWithValue("@Email", cliente.Email);
                        cmd.Parameters.AddWithValue("@Dir_Cliente", cliente.Dir_Cliente);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar cliente: " + ex.Message);
            }
        }

        public DataTable Cargar_Cliente()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(CONEXION.cn.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("Cargar_Clientes", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Usar SqlDataAdapter para llenar el DataTable con los resultados del procedimiento almacenado
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            connection.Open();
                            da.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar los datos de clientes: " + ex.Message);
            }
        }
        public void Eliminar_Cliente(string idCliente)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(CONEXION.cn.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("Eliminar_Cliente", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Agregar el parámetro para el ID del cliente
                        cmd.Parameters.AddWithValue("@ID_Cliente", idCliente);

                        // Abrir la conexión y ejecutar el procedimiento almacenado
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar cliente: " + ex.Message);
            }
        }
        public void Modificar_Cliente(ENTIDAD_CLIENTE cliente)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(CONEXION.cn.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("Modificar_Cliente", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Agregar los parámetros correspondientes al procedimiento almacenado
                        cmd.Parameters.AddWithValue("@ID_Cliente", cliente.ID_Cliente);
                        cmd.Parameters.AddWithValue("@Nom_Cliente", cliente.Nom_Cliente);
                        cmd.Parameters.AddWithValue("@Ape_Cliente", cliente.Ape_Cliente);
                        cmd.Parameters.AddWithValue("@Tel_Cliente", cliente.Tel_Cliente);
                        cmd.Parameters.AddWithValue("@Email", cliente.Email);
                        cmd.Parameters.AddWithValue("@Dir_Cliente", cliente.Dir_Cliente);

                        // Abrir la conexión y ejecutar el procedimiento almacenado
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar cliente: " + ex.Message);
            }
        }
    }
}