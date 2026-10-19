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
    public class DATOS_VENTA : IVentaRepositorio
    {
        public void Agregar_Venta(ENTIDAD_VENTA venta)
        {
            string query = "INSERT INTO Venta (ID_Venta, ID_Pedido, Fec_Venta, Monto_Total, ID_Metodo_Pago, ID_Sede) " +
                           "VALUES (@ID_Venta, @ID_Pedido, @Fec_Venta, @Monto_Total, @ID_Metodo_Pago, @ID_Sede)";
            try
            {
                using (SqlConnection connection = CONEXION.Crear())
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
                throw new Exception("Error al agregar la venta: " + ex.Message, ex);
            }
        }

        public void Modificar_Venta(ENTIDAD_VENTA venta)
        {
            string query = "UPDATE Venta SET ID_Pedido = @ID_Pedido, Fec_Venta = @Fec_Venta, " +
                           "Monto_Total = @Monto_Total, ID_Metodo_Pago = @ID_Metodo_Pago, ID_Sede = @ID_Sede " +
                           "WHERE ID_Venta = @ID_Venta";
            try
            {
                using (SqlConnection connection = CONEXION.Crear())
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
                throw new Exception("Error al modificar la venta: " + ex.Message, ex);
            }
        }

        public void Eliminar_Venta(string idVenta)
        {
            string query = "DELETE FROM Venta WHERE ID_Venta = @ID_Venta";
            try
            {
                using (SqlConnection connection = CONEXION.Crear())
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
                throw new Exception("Error al eliminar la venta: " + ex.Message, ex);
            }
        }

        public DataTable Cargar_Ventas()
        {
            string query = "SELECT ID_Venta, ID_Pedido, Fec_Venta, Monto_Total, ID_Metodo_Pago, ID_Sede FROM Venta";
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
                throw new Exception("Error al cargar las ventas: " + ex.Message, ex);
            }
        }
        // Método para cargar los pedidos
        public DataTable Cargar_Pedidos()
        {
            string query = "SELECT ID_Pedido, Fec_Pedido FROM Pedido"; // Suponiendo que tienes una tabla Pedido
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
                throw new Exception("Error al cargar los pedidos: " + ex.Message, ex);
            }
        }

        // Método para cargar los métodos de pago
        public DataTable Cargar_MetodosPago()
        {
            string query = "SELECT ID_Metodo_Pago, Nom_Metodo_Pago FROM Metodo_Pago"; // Suponiendo que tienes una tabla MetodoPago
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
                throw new Exception("Error al cargar los métodos de pago: " + ex.Message, ex);
            }
        }

        // Método para cargar las sedes
        public DataTable Cargar_Sedes()
        {
            string query = "SELECT ID_Sede, Nom_Sede FROM Sede"; // Suponiendo que tienes una tabla Sede
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
                throw new Exception("Error al cargar las sedes: " + ex.Message, ex);
            }
        }

        // Registra toda la venta en UNA transacción: si algo falla no se guarda nada (todo o nada)
        public ENTIDAD_RESULTADO_VENTA Registrar_Venta(ENTIDAD_PEDIDO_CAJA pedido, ENTIDAD_RESUMEN_PEDIDO resumen,
                                                       string tipoComprobante, List<ENTIDAD_CONSUMO_INSUMO> consumos)
        {
            using (SqlConnection connection = CONEXION.Crear())
            {
                connection.Open();
                SqlTransaction transaccion = connection.BeginTransaction();
                try
                {
                    // 1. Códigos nuevos (las tablas quedan bloqueadas hasta el COMMIT)
                    string idPedido = GeneradorCodigo.Siguiente(
                        CONEXION.Ultimo_Codigo(connection, transaccion, "Pedido", "ID_Pedido", "P", 5), "P", 5);
                    string idVenta = GeneradorCodigo.Siguiente(
                        CONEXION.Ultimo_Codigo(connection, transaccion, "Venta", "ID_Venta", "V", 5), "V", 5);
                    string ultimoDP = CONEXION.Ultimo_Codigo(connection, transaccion, "Detalle_Pedido", "ID_Detalle_Pedido", "DP", 5);
                    string ultimoDV = CONEXION.Ultimo_Codigo(connection, transaccion, "Detalle_Venta", "ID_Detalle_Venta", "DV", 5);

                    // 2. Pedido (entra a cocina como Pendiente)
                    string queryPedido = "INSERT INTO Pedido (ID_Pedido, ID_Cliente, Fec_Pedido, Estado_Pedido, Observaciones, Tipo_Pedido, ID_Sede) " +
                                         "VALUES (@ID_Pedido, @ID_Cliente, @Fecha, 'Pendiente', @Observaciones, @Tipo_Pedido, @ID_Sede)";
                    using (SqlCommand cmd = new SqlCommand(queryPedido, connection, transaccion))
                    {
                        cmd.Parameters.AddWithValue("@ID_Pedido", idPedido);
                        cmd.Parameters.AddWithValue("@ID_Cliente", pedido.ID_Cliente);
                        cmd.Parameters.AddWithValue("@Fecha", pedido.Fecha);
                        cmd.Parameters.AddWithValue("@Observaciones", (object)pedido.Observaciones ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Tipo_Pedido", pedido.Tipo_Pedido);
                        cmd.Parameters.AddWithValue("@ID_Sede", pedido.ID_Sede);
                        cmd.ExecuteNonQuery();
                    }

                    // 3. Venta (cabecera del comprobante)
                    string queryVenta = "INSERT INTO Venta (ID_Venta, ID_Pedido, Fec_Venta, Monto_Total, ID_Metodo_Pago, ID_Sede, Tipo_Comprobante, RUC, Razon_Social) " +
                                        "VALUES (@ID_Venta, @ID_Pedido, @Fecha, @Monto_Total, @ID_Metodo_Pago, @ID_Sede, @Tipo_Comprobante, @RUC, @Razon_Social)";
                    using (SqlCommand cmd = new SqlCommand(queryVenta, connection, transaccion))
                    {
                        cmd.Parameters.AddWithValue("@ID_Venta", idVenta);
                        cmd.Parameters.AddWithValue("@ID_Pedido", idPedido);
                        cmd.Parameters.AddWithValue("@Fecha", pedido.Fecha);
                        cmd.Parameters.AddWithValue("@Monto_Total", resumen.Total);
                        cmd.Parameters.AddWithValue("@ID_Metodo_Pago", pedido.ID_Metodo_Pago);
                        cmd.Parameters.AddWithValue("@ID_Sede", pedido.ID_Sede);
                        cmd.Parameters.AddWithValue("@Tipo_Comprobante", tipoComprobante);
                        cmd.Parameters.AddWithValue("@RUC", (object)pedido.RUC ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Razon_Social", (object)pedido.Razon_Social ?? DBNull.Value);
                        cmd.ExecuteNonQuery();
                    }

                    // 4. Detalle_Pedido y Detalle_Venta (una fila por producto)
                    foreach (ENTIDAD_LINEA_PEDIDO linea in pedido.Lineas)
                    {
                        string idDetallePedido = GeneradorCodigo.Siguiente(ultimoDP, "DP", 5);
                        string idDetalleVenta = GeneradorCodigo.Siguiente(ultimoDV, "DV", 5);
                        ultimoDP = idDetallePedido;
                        ultimoDV = idDetalleVenta;

                        string queryDetalle =
                            "INSERT INTO Detalle_Pedido (ID_Detalle_Pedido, ID_Pedido, ID_Plato, Cantidad, Pre_Unitario_Final) " +
                            "VALUES (@ID_DP, @ID_Pedido, @ID_Plato, @Cantidad, @Precio); " +
                            "INSERT INTO Detalle_Venta (ID_Detalle_Venta, ID_Detalle_Pedido, Tipo_Documento, ID_Venta, ID_Plato, Precio, Cant) " +
                            "VALUES (@ID_DV, @ID_DP, @Tipo_Comprobante, @ID_Venta, @ID_Plato, @Precio, @Cantidad)";
                        using (SqlCommand cmd = new SqlCommand(queryDetalle, connection, transaccion))
                        {
                            cmd.Parameters.AddWithValue("@ID_DP", idDetallePedido);
                            cmd.Parameters.AddWithValue("@ID_DV", idDetalleVenta);
                            cmd.Parameters.AddWithValue("@ID_Pedido", idPedido);
                            cmd.Parameters.AddWithValue("@ID_Venta", idVenta);
                            cmd.Parameters.AddWithValue("@ID_Plato", linea.Producto.ID_Plato);
                            cmd.Parameters.AddWithValue("@Cantidad", linea.Cantidad);
                            cmd.Parameters.AddWithValue("@Precio", linea.Precio_Final);
                            cmd.Parameters.AddWithValue("@Tipo_Comprobante", tipoComprobante);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // 5. Descuento de insumos según la receta (solo si alcanza el stock)
                    foreach (ENTIDAD_CONSUMO_INSUMO consumo in consumos)
                    {
                        string queryStock = "UPDATE Inventario SET Cant_Total = Cant_Total - @Cantidad " +
                                            "WHERE ID_Sede = @ID_Sede AND ID_Insumo = @ID_Insumo AND Cant_Total >= @Cantidad";
                        using (SqlCommand cmd = new SqlCommand(queryStock, connection, transaccion))
                        {
                            cmd.Parameters.AddWithValue("@Cantidad", consumo.Cantidad_Requerida);
                            cmd.Parameters.AddWithValue("@ID_Sede", pedido.ID_Sede);
                            cmd.Parameters.AddWithValue("@ID_Insumo", consumo.ID_Insumo);
                            if (cmd.ExecuteNonQuery() == 0)
                                throw new InvalidOperationException("Stock insuficiente de " + consumo.Nom_Insumo + ".");
                        }
                    }

                    transaccion.Commit();

                    return new ENTIDAD_RESULTADO_VENTA
                    {
                        ID_Pedido = idPedido,
                        ID_Venta = idVenta,
                        Fecha = pedido.Fecha,
                        Tipo_Comprobante = tipoComprobante,
                        Resumen = resumen
                    };
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    throw new Exception("No se registró la venta: " + ex.Message, ex);
                }
            }
        }
    }
}
