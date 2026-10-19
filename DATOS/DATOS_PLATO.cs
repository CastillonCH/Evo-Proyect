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
    public class DATOS_PLATO : IProductoRepositorio
    {
        public void Agregar_Plato(ENTIDAD_PLATO plato)
        {
            string query = "INSERT INTO Plato (ID_Plato, Nom_Plato, Des_Plato, Prec_Original, ID_Promocion) " +
                   "VALUES (@ID_Plato, @Nom_Plato, @Des_Plato, @Prec_Original, @ID_Promocion)";
            try
            {
                using (SqlConnection connection = CONEXION.Crear())
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID_Plato", plato.ID_Plato);
                        cmd.Parameters.AddWithValue("@Nom_Plato", plato.Nom_Plato);
                        cmd.Parameters.AddWithValue("@Des_Plato", plato.Des_Plato);
                        cmd.Parameters.AddWithValue("@Prec_Original", plato.Prec_Original);

                        if (plato.ID_Promocion == null)
                            cmd.Parameters.AddWithValue("@ID_Promocion", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@ID_Promocion", plato.ID_Promocion);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el plato: " + ex.Message, ex);
            }
        }

        public void Modificar_Plato(ENTIDAD_PLATO plato)
        {
            string query = "UPDATE Plato SET Nom_Plato = @Nom_Plato, Des_Plato = @Des_Plato, " +
                           "Prec_Original = @Prec_Original, ID_Promocion = @ID_Promocion " +
                           "WHERE ID_Plato = @ID_Plato";
            try
            {
                using (SqlConnection connection = CONEXION.Crear())
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID_Plato", plato.ID_Plato);
                        cmd.Parameters.AddWithValue("@Nom_Plato", plato.Nom_Plato);
                        cmd.Parameters.AddWithValue("@Des_Plato", plato.Des_Plato);
                        cmd.Parameters.AddWithValue("@Prec_Original", plato.Prec_Original);
                        cmd.Parameters.AddWithValue("@ID_Promocion", plato.ID_Promocion);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el plato: " + ex.Message, ex);
            }
        }

        public void Eliminar_Plato(string idPlato)
        {
            string query = "DELETE FROM Plato WHERE ID_Plato = @ID_Plato";
            try
            {
                using (SqlConnection connection = CONEXION.Crear())
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID_Plato", idPlato);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el plato: " + ex.Message, ex);
            }
        }

        public DataTable Cargar_Plato()
        {
            string query = "SELECT ID_Plato, Nom_Plato, Des_Plato, Prec_Original, ID_Promocion FROM Plato";
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

        public DataTable Cargar_Promociones()
        {
            string query = "SELECT ID_Promocion, Nom_Promocion FROM Promocion";
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

        // Productos para la Caja, con los datos de su promoción (si tiene)
        public List<ENTIDAD_PRODUCTO_CAJA> Cargar_Productos_Venta()
        {
            string query = "SELECT p.ID_Plato, p.Nom_Plato, p.Prec_Original, p.ID_Promocion, " +
                           "pr.Nom_Promocion, pr.Descuento, pr.Fec_Inicio, pr.Fec_Fin " +
                           "FROM Plato p LEFT JOIN Promocion pr ON p.ID_Promocion = pr.ID_Promocion " +
                           "WHERE p.Prec_Original IS NOT NULL ORDER BY p.Nom_Plato";
            try
            {
                List<ENTIDAD_PRODUCTO_CAJA> productos = new List<ENTIDAD_PRODUCTO_CAJA>();
                using (SqlConnection connection = CONEXION.Crear())
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                bool tienePromo = dr["ID_Promocion"] != DBNull.Value && dr["Fec_Inicio"] != DBNull.Value;
                                productos.Add(new ENTIDAD_PRODUCTO_CAJA
                                {
                                    ID_Plato = dr["ID_Plato"].ToString(),
                                    Nom_Plato = dr["Nom_Plato"].ToString(),
                                    Precio = Convert.ToDecimal(dr["Prec_Original"]),
                                    ID_Promocion = tienePromo ? dr["ID_Promocion"].ToString() : null,
                                    Nom_Promocion = tienePromo ? dr["Nom_Promocion"].ToString() : null,
                                    Porc_Descuento = tienePromo ? Convert.ToDecimal(dr["Descuento"]) : 0m,
                                    Promo_Inicio = tienePromo ? (DateTime?)Convert.ToDateTime(dr["Fec_Inicio"]) : null,
                                    Promo_Fin = tienePromo ? (DateTime?)Convert.ToDateTime(dr["Fec_Fin"]) : null
                                });
                            }
                        }
                    }
                }
                return productos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar los productos de venta: " + ex.Message, ex);
            }
        }
    }
}
