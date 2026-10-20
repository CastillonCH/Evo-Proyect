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
    public class DATOS_PEDIDO : IPedidoRepositorio
    {
        public void Agregar_Pedido(ENTIDADES_PEDIDO pedido)
        {
            // Cambiar "Empleado" por "Pedido" en la consulta SQL
            string query = "INSERT INTO Pedido (ID_Pedido, ID_Cliente, Fec_Pedido, Estado_Pedido, Observaciones) " +
                           "VALUES (@ID_Pedido, @ID_Cliente, @Fec_Pedido, @Estado_Pedido, @Observaciones)";

            try
            {
                using (SqlConnection connection = CONEXION.Crear())
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID_Pedido", pedido.ID_Pedido);
                        cmd.Parameters.AddWithValue("@ID_Cliente", pedido.ID_Cliente);
                        cmd.Parameters.AddWithValue("@Fec_Pedido", pedido.Fec_Pedido);
                        cmd.Parameters.AddWithValue("@Estado_Pedido", pedido.Estado_Pedido);
                        cmd.Parameters.AddWithValue("@Observaciones", pedido.Observaciones);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el pedido: " + ex.Message, ex);
            }
        }

        public void Modificar_Pedido(ENTIDADES.ENTIDADES_PEDIDO pedido)
        {
            string query = "UPDATE Pedido SET ID_Cliente = @ID_Cliente, Fec_Pedido = @Fec_Pedido, " +
                           "Estado_Pedido = @Estado_Pedido, Observaciones = @Observaciones WHERE ID_Pedido = @ID_Pedido";

            try
            {
                using (SqlConnection connection = CONEXION.Crear())
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Usamos parámetros para evitar inyección SQL
                        cmd.Parameters.AddWithValue("@ID_Pedido", pedido.ID_Pedido);
                        cmd.Parameters.AddWithValue("@ID_Cliente", pedido.ID_Cliente);
                        cmd.Parameters.AddWithValue("@Fec_Pedido", pedido.Fec_Pedido);
                        cmd.Parameters.AddWithValue("@Estado_Pedido", pedido.Estado_Pedido);
                        cmd.Parameters.AddWithValue("@Observaciones", pedido.Observaciones);

                        connection.Open(); // Abrir conexión
                        cmd.ExecuteNonQuery(); // Ejecutar la consulta
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el pedido: " + ex.Message, ex); // Manejo de errores
            }
        }

        public void Eliminar_Pedido(string idPedido)
        {
            string query = "DELETE FROM Pedido WHERE ID_Pedido = @ID_Pedido";

            try
            {
                using (SqlConnection connection = CONEXION.Crear())
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Usamos parámetros para evitar inyección SQL
                        cmd.Parameters.AddWithValue("@ID_Pedido", idPedido);

                        connection.Open(); // Abrir conexión
                        cmd.ExecuteNonQuery(); // Ejecutar la consulta
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el pedido: " + ex.Message, ex); // Manejo de errores
            }
        }

        public DataTable Cargar_Pedido()
        {
            // La consulta SQL ahora carga los datos de la tabla Pedido en lugar de la tabla Empleado
            string query = "SELECT ID_Pedido, ID_Cliente, Fec_Pedido, Estado_Pedido, Observaciones FROM Pedido";

            try
            {
                using (SqlConnection connection = CONEXION.Crear())
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt); // Llenamos el DataTable con los datos obtenidos de la consulta
                            return dt; // Devolvemos el DataTable con los pedidos
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Capturamos cualquier excepción y lanzamos un error con un mensaje descriptivo
                throw new Exception("Error al cargar los pedidos: " + ex.Message, ex);
            }
        }
        public DataTable Cargar_Cliente()
        {
            string query = "SELECT ID_Cliente, Nom_Cliente FROM Cliente";

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
                throw new Exception("Error al cargar los clientes: " + ex.Message, ex);
            }
        }

        // Pedidos del día de una sede para la pantalla de Cocina (SP en 02_cambios_spyci.sql)
        public List<ENTIDAD_PEDIDO_COCINA> Cargar_Pedidos_Cocina(string idSede, DateTime fecha)
        {
            try
            {
                List<ENTIDAD_PEDIDO_COCINA> pedidos = new List<ENTIDAD_PEDIDO_COCINA>();
                using (SqlConnection connection = CONEXION.Crear())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Pedidos_Cocina", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID_Sede", idSede);
                        cmd.Parameters.AddWithValue("@Fecha", fecha.Date);
                        connection.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                pedidos.Add(new ENTIDAD_PEDIDO_COCINA
                                {
                                    ID_Pedido = dr["ID_Pedido"].ToString(),
                                    Fec_Pedido = Convert.ToDateTime(dr["Fec_Pedido"]),
                                    Estado_Pedido = dr["Estado_Pedido"].ToString(),
                                    Tipo_Pedido = dr["Tipo_Pedido"].ToString(),
                                    Cliente = dr["Cliente"].ToString(),
                                    Observaciones = dr["Observaciones"].ToString(),
                                    Detalle = dr["Detalle"].ToString()
                                });
                            }
                        }
                    }
                }
                return pedidos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar los pedidos de cocina: " + ex.Message, ex);
            }
        }

        public void Cambiar_Estado(string idPedido, string nuevoEstado)
        {
            try
            {
                using (SqlConnection connection = CONEXION.Crear())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Cambiar_Estado_Pedido", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID_Pedido", idPedido);
                        cmd.Parameters.AddWithValue("@Estado", nuevoEstado);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cambiar el estado del pedido: " + ex.Message, ex);
            }
        }
    }
}
