using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ENTIDADES;
using NEGOCIO;

namespace DATOS
{
    public class DATOS_INVENTARIO : IInventarioRepositorio
    {
        // Receta de un plato con la cantidad en la unidad del insumo
        public List<ENTIDAD_RECETA_INSUMO> Cargar_Receta(string idPlato)
        {
            string query = "SELECT pi.ID_Plato, pi.ID_Insumo, i.Nombre, um.Nom_Unidad_Medida, pi.Cant_Necesaria " +
                           "FROM Plato_Insumo pi " +
                           "INNER JOIN Insumo i ON pi.ID_Insumo = i.ID_Insumo " +
                           "LEFT JOIN Unidad_Medida um ON i.ID_Unidad_Medida = um.ID_Unidad_Medida " +
                           "WHERE pi.ID_Plato = @ID_Plato";
            try
            {
                List<ENTIDAD_RECETA_INSUMO> receta = new List<ENTIDAD_RECETA_INSUMO>();
                using (SqlConnection connection = CONEXION.Crear())
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID_Plato", idPlato);
                        connection.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                receta.Add(new ENTIDAD_RECETA_INSUMO
                                {
                                    ID_Plato = dr["ID_Plato"].ToString(),
                                    ID_Insumo = dr["ID_Insumo"].ToString(),
                                    Nom_Insumo = dr["Nombre"].ToString(),
                                    Unidad = dr["Nom_Unidad_Medida"].ToString(),
                                    Cant_Necesaria = dr["Cant_Necesaria"] == DBNull.Value ? 0m : Convert.ToDecimal(dr["Cant_Necesaria"])
                                });
                            }
                        }
                    }
                }
                return receta;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar la receta: " + ex.Message, ex);
            }
        }

        public decimal Obtener_Stock(string idSede, string idInsumo)
        {
            string query = "SELECT Cant_Total FROM Inventario WHERE ID_Sede = @ID_Sede AND ID_Insumo = @ID_Insumo";
            try
            {
                using (SqlConnection connection = CONEXION.Crear())
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID_Sede", idSede);
                        cmd.Parameters.AddWithValue("@ID_Insumo", idInsumo);
                        connection.Open();
                        object stock = cmd.ExecuteScalar();
                        return stock == null || stock == DBNull.Value ? 0m : Convert.ToDecimal(stock);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar el stock: " + ex.Message, ex);
            }
        }

        // Stock por sede con unidad, mínimo y estado (SP en 02_cambios_spyci.sql)
        public DataTable Cargar_Inventario(string idSede)
        {
            try
            {
                using (SqlConnection connection = CONEXION.Crear())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Inventario_Sede", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID_Sede", idSede);
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
                throw new Exception("Error al cargar el inventario: " + ex.Message, ex);
            }
        }

        public DataTable Cargar_Sedes()
        {
            return Cargar_Tabla("SELECT ID_Sede, Nom_Sede FROM Sede ORDER BY ID_Sede", "las sedes");
        }

        public DataTable Cargar_Proveedores()
        {
            return Cargar_Tabla("SELECT ID_Proveedor, Nom_Proveedor FROM Proveedor ORDER BY Nom_Proveedor", "los proveedores");
        }

        public DataTable Cargar_Insumos()
        {
            return Cargar_Tabla("SELECT i.ID_Insumo, i.Nombre, um.Nom_Unidad_Medida AS Unidad, i.Precio_Unitario " +
                                "FROM Insumo i LEFT JOIN Unidad_Medida um ON i.ID_Unidad_Medida = um.ID_Unidad_Medida " +
                                "ORDER BY i.Nombre", "los insumos");
        }

        // Abastecimiento + Detalle_Abastecimiento + suma al Inventario, en una sola transacción
        public void Registrar_Abastecimiento(ENTIDAD_ABASTECIMIENTO abastecimiento)
        {
            using (SqlConnection connection = CONEXION.Crear())
            {
                connection.Open();
                SqlTransaction transaccion = connection.BeginTransaction();
                try
                {
                    string idAbastecimiento = GeneradorCodigo.Siguiente(
                        CONEXION.Ultimo_Codigo(connection, transaccion, "Abastecimiento", "ID_Abastecimiento", "AB", 5), "AB", 5);
                    string ultimoDetalle = CONEXION.Ultimo_Codigo(connection, transaccion, "Detalle_Abastecimiento", "ID_Detalle", "DA", 5);

                    string queryCabecera = "INSERT INTO Abastecimiento (ID_Abastecimiento, Fecha_Abastecimiento, ID_Sede) " +
                                           "VALUES (@ID_Abastecimiento, @Fecha, @ID_Sede)";
                    using (SqlCommand cmd = new SqlCommand(queryCabecera, connection, transaccion))
                    {
                        cmd.Parameters.AddWithValue("@ID_Abastecimiento", idAbastecimiento);
                        cmd.Parameters.AddWithValue("@Fecha", abastecimiento.Fecha_Abastecimiento);
                        cmd.Parameters.AddWithValue("@ID_Sede", abastecimiento.ID_Sede);
                        cmd.ExecuteNonQuery();
                    }

                    foreach (ENTIDAD_DETALLE_ABASTECIMIENTO detalle in abastecimiento.Detalles)
                    {
                        string idDetalle = GeneradorCodigo.Siguiente(ultimoDetalle, "DA", 5);
                        ultimoDetalle = idDetalle;

                        // Inserta el detalle y suma el stock (si el insumo no existe en la sede, crea la fila)
                        string queryDetalle =
                            "INSERT INTO Detalle_Abastecimiento (ID_Detalle, ID_Abastecimiento, ID_Insumo, Cantidad, Precio_Unitario, ID_Proveedor, Comentario) " +
                            "VALUES (@ID_Detalle, @ID_Abastecimiento, @ID_Insumo, @Cantidad, @Precio, @ID_Proveedor, @Comentario); " +
                            "UPDATE Inventario SET Cant_Total = Cant_Total + @Cantidad WHERE ID_Sede = @ID_Sede AND ID_Insumo = @ID_Insumo; " +
                            "IF @@ROWCOUNT = 0 INSERT INTO Inventario (ID_Sede, ID_Insumo, Cant_Total) VALUES (@ID_Sede, @ID_Insumo, @Cantidad);";
                        using (SqlCommand cmd = new SqlCommand(queryDetalle, connection, transaccion))
                        {
                            cmd.Parameters.AddWithValue("@ID_Detalle", idDetalle);
                            cmd.Parameters.AddWithValue("@ID_Abastecimiento", idAbastecimiento);
                            cmd.Parameters.AddWithValue("@ID_Insumo", detalle.ID_Insumo);
                            cmd.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                            cmd.Parameters.AddWithValue("@Precio", detalle.Precio_Unitario);
                            cmd.Parameters.AddWithValue("@ID_Proveedor", abastecimiento.ID_Proveedor);
                            cmd.Parameters.AddWithValue("@Comentario", (object)abastecimiento.Comentario ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@ID_Sede", abastecimiento.ID_Sede);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaccion.Commit();
                    abastecimiento.ID_Abastecimiento = idAbastecimiento;
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    throw new Exception("No se registró el abastecimiento: " + ex.Message, ex);
                }
            }
        }

        // Cantidad de insumos bajo el mínimo (idSede = null: todas las sedes)
        public int Contar_Stock_Bajo(string idSede)
        {
            string query = "SELECT COUNT(*) FROM Inventario WHERE Cant_Total < Stock_Minimo " +
                           "AND (@ID_Sede IS NULL OR ID_Sede = @ID_Sede)";
            try
            {
                using (SqlConnection connection = CONEXION.Crear())
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID_Sede", (object)idSede ?? DBNull.Value);
                        connection.Open();
                        return (int)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al contar el stock bajo: " + ex.Message, ex);
            }
        }

        private DataTable Cargar_Tabla(string query, string descripcion)
        {
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
                throw new Exception("Error al cargar " + descripcion + ": " + ex.Message, ex);
            }
        }
    }
}
