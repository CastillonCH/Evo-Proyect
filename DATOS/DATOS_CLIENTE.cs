using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using ENTIDADES;
using NEGOCIO;
using System.Data;
using System.Data.SqlClient;

namespace DATOS
{
    public class DATOS_CLIENTE : IClienteRepositorio
    {
        public void Agregar_Cliente(ENTIDAD_CLIENTE cliente)
        {
            try
            {
                using (SqlConnection connection = CONEXION.Crear())
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
                throw new Exception("Error al agregar cliente: " + ex.Message, ex);
            }
        }

        public DataTable Cargar_Cliente()
        {
            try
            {
                using (SqlConnection connection = CONEXION.Crear())
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
                throw new Exception("Error al cargar los datos de clientes: " + ex.Message, ex);
            }
        }
        public void Eliminar_Cliente(string idCliente)
        {
            try
            {
                using (SqlConnection connection = CONEXION.Crear())
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
                throw new Exception("Error al eliminar cliente: " + ex.Message, ex);
            }
        }
        public void Modificar_Cliente(ENTIDAD_CLIENTE cliente)
        {
            try
            {
                using (SqlConnection connection = CONEXION.Crear())
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
                throw new Exception("Error al modificar cliente: " + ex.Message, ex);
            }
        }

        // Último código con formato C0000 (para generar el siguiente)
        public string Ultimo_Codigo()
        {
            try
            {
                using (SqlConnection connection = CONEXION.Crear())
                {
                    connection.Open();
                    return CONEXION.Ultimo_Codigo(connection, null, "Cliente", "ID_Cliente", "C", 4);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el último código de cliente: " + ex.Message, ex);
            }
        }

        // Número de compras (ventas) del cliente, para el descuento de cliente frecuente
        public int Contar_Compras(string idCliente)
        {
            string query = "SELECT COUNT(*) FROM Venta v INNER JOIN Pedido p ON v.ID_Pedido = p.ID_Pedido " +
                           "WHERE p.ID_Cliente = @ID_Cliente";
            try
            {
                using (SqlConnection connection = CONEXION.Crear())
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID_Cliente", idCliente);
                        connection.Open();
                        return (int)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al contar las compras del cliente: " + ex.Message, ex);
            }
        }
    }
}
