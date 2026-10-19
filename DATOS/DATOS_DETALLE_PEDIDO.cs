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
    public class DATOS_DETALLE_PEDIDO
    {
        // Agregar un detalle de pedido
        public void Agregar_Detalle_Pedido(ENTIDADES.ENTIDAD_DETALLE_PEDIDO detallePedido)
        {
            string query = "Agregar_Detalle_Pedido"; // Procedimiento almacenado

            try
            {
                using (SqlConnection connection = CONEXION.Crear())
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure; // Especificamos que es un procedimiento almacenado

                        // Agregar los parámetros correspondientes al procedimiento almacenado
                        cmd.Parameters.AddWithValue("@ID_Detalle_Pedido", detallePedido.ID_Detalle_Pedido);
                        cmd.Parameters.AddWithValue("@ID_Pedido", detallePedido.ID_Pedido);
                        cmd.Parameters.AddWithValue("@ID_Plato", detallePedido.ID_Plato);
                        cmd.Parameters.AddWithValue("@Cantidad", detallePedido.Cantidad);
                        cmd.Parameters.AddWithValue("@Pre_Unitario_Final", detallePedido.Pre_Unitario_Final);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el detalle de pedido: " + ex.Message, ex);
            }
        }

        // Modificar un detalle de pedido
        public void Modificar_Detalle_Pedido(ENTIDADES.ENTIDAD_DETALLE_PEDIDO detallePedido)
        {
            string query = "Modificar_Detalle_Pedido"; // Procedimiento almacenado

            try
            {
                using (SqlConnection connection = CONEXION.Crear())
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure; // Especificamos que es un procedimiento almacenado

                        // Agregar los parámetros correspondientes al procedimiento almacenado
                        cmd.Parameters.AddWithValue("@ID_Detalle_Pedido", detallePedido.ID_Detalle_Pedido);
                        cmd.Parameters.AddWithValue("@ID_Pedido", detallePedido.ID_Pedido);
                        cmd.Parameters.AddWithValue("@ID_Plato", detallePedido.ID_Plato);
                        cmd.Parameters.AddWithValue("@Cantidad", detallePedido.Cantidad);
                        cmd.Parameters.AddWithValue("@Pre_Unitario_Final", detallePedido.Pre_Unitario_Final);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el detalle de pedido: " + ex.Message, ex);
            }
        }

        // Eliminar un detalle de pedido
        public void Eliminar_Detalle_Pedido(string idDetallePedido)
        {
            string query = "Eliminar_Detalle_Pedido"; // Procedimiento almacenado

            try
            {
                using (SqlConnection connection = CONEXION.Crear())
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure; // Especificamos que es un procedimiento almacenado

                        // Agregar el parámetro correspondiente al procedimiento almacenado
                        cmd.Parameters.AddWithValue("@ID_Detalle_Pedido", idDetallePedido);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el detalle de pedido: " + ex.Message, ex);
            }
        }

        // Cargar los detalles de un pedido específico
        public DataTable Cargar_Detalle_Pedido(string idPedido = null)
        {
            string query = "Cargar_Detalle_Pedido"; // Procedimiento almacenado

            try
            {
                using (SqlConnection connection = CONEXION.Crear())
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure; // Especificamos que es un procedimiento almacenado

                        // Agregar el parámetro si es necesario
                        if (!string.IsNullOrEmpty(idPedido))
                        {
                            cmd.Parameters.AddWithValue("@ID_Pedido", idPedido);
                        }

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
                throw new Exception("Error al cargar los detalles del pedido: " + ex.Message, ex);
            }
        }

        // Cargar todos los platos en el ComboBox
        public DataTable Cargar_Plato()
        {
            string query = "cargar_plato"; // Procedimiento almacenado

            try
            {
                using (SqlConnection connection = CONEXION.Crear())
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure; // Especificamos que es un procedimiento almacenado

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

        // Cargar todos los pedidos en el ComboBox
        public DataTable Cargar_Pedido()
        {
            string query = "cargar_pedido"; // Procedimiento almacenado

            try
            {
                using (SqlConnection connection = CONEXION.Crear())
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure; // Especificamos que es un procedimiento almacenado

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
                throw new Exception("Error al cargar los pedidos: " + ex.Message, ex);
            }
        }
    }
}
