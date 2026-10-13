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
    public class DATOS_VENTA
    {
        public void Agregar_Venta(ENTIDAD_VENTA venta)
        {
            string query = "INSERT INTO Venta (ID_Venta, ID_Pedido, Fec_Venta, Monto_Total, ID_Metodo_Pago, ID_Sede) " +
                           "VALUES (@ID_Venta, @ID_Pedido, @Fec_Venta, @Monto_Total, @ID_Metodo_Pago, @ID_Sede)";
            try
            {
                using (SqlConnection connection = new SqlConnection(CONEXION.cn.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID_Venta", venta.ID_Venta);
                        cmd.Parameters.AddWithValue("@ID_Pedido", venta.ID_Pedido);
                        cmd.Parameters.AddWithValue("@Fec_Venta", venta.Fec_Venta);
                        cmd.Parameters.AddWithValue("@Monto_Total", venta.Monto_Total);
                        cmd.Parameters.AddWithValue("@ID_Metodo_Pago", venta.ID_Metodo_Pago);
                        cmd.Parameters.AddWithValue("@ID_Sede", venta.ID_Sede);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar la venta: " + ex.Message);
            }
        }

        public void Modificar_Venta(ENTIDAD_VENTA venta)
        {
            string query = "UPDATE Venta SET ID_Pedido = @ID_Pedido, Fec_Venta = @Fec_Venta, " +
                           "Monto_Total = @Monto_Total, ID_Metodo_Pago = @ID_Metodo_Pago, ID_Sede = @ID_Sede " +
                           "WHERE ID_Venta = @ID_Venta";
            try
            {
                using (SqlConnection connection = new SqlConnection(CONEXION.cn.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID_Venta", venta.ID_Venta);
                        cmd.Parameters.AddWithValue("@ID_Pedido", venta.ID_Pedido);
                        cmd.Parameters.AddWithValue("@Fec_Venta", venta.Fec_Venta);
                        cmd.Parameters.AddWithValue("@Monto_Total", venta.Monto_Total);
                        cmd.Parameters.AddWithValue("@ID_Metodo_Pago", venta.ID_Metodo_Pago);
                        cmd.Parameters.AddWithValue("@ID_Sede", venta.ID_Sede);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar la venta: " + ex.Message);
            }
        }

        public void Eliminar_Venta(string idVenta)
        {
            string query = "DELETE FROM Venta WHERE ID_Venta = @ID_Venta";
            try
            {
                using (SqlConnection connection = new SqlConnection(CONEXION.cn.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID_Venta", idVenta);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la venta: " + ex.Message);
            }
        }

        public DataTable Cargar_Ventas()
        {
            string query = "SELECT ID_Venta, ID_Pedido, Fec_Venta, Monto_Total, ID_Metodo_Pago, ID_Sede FROM Venta";
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
                throw new Exception("Error al cargar las ventas: " + ex.Message);
            }
        }
        // Método para cargar los pedidos
        public DataTable Cargar_Pedidos()
        {
            string query = "SELECT ID_Pedido, Fec_Pedido FROM Pedido"; // Suponiendo que tienes una tabla Pedido
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
                throw new Exception("Error al cargar los pedidos: " + ex.Message);
            }
        }

        // Método para cargar los métodos de pago
        public DataTable Cargar_MetodosPago()
        {
            string query = "SELECT ID_Metodo_Pago, Nom_Metodo_Pago FROM Metodo_Pago"; // Suponiendo que tienes una tabla MetodoPago
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
                throw new Exception("Error al cargar los métodos de pago: " + ex.Message);
            }
        }

        // Método para cargar las sedes
        public DataTable Cargar_Sedes()
        {
            string query = "SELECT ID_Sede, Nom_Sede FROM Sede"; // Suponiendo que tienes una tabla Sede
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
                throw new Exception("Error al cargar las sedes: " + ex.Message);
            }
        }
    }
}
