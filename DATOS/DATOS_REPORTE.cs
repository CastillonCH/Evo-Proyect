using System;
using System.Data;
using System.Data.SqlClient;
using NEGOCIO;

namespace DATOS
{
    // Cada reporte es un SP (02_cambios_spyci.sql) basado en las vistas existentes,
    // con filtro de sede (NULL = todas) y rango de fechas
    public class DATOS_REPORTE : IReporteRepositorio
    {
        public DataTable Cargar_Sedes()
        {
            string query = "SELECT ID_Sede, Nom_Sede FROM Sede ORDER BY ID_Sede";
            try
            {
                using (SqlConnection connection = CONEXION.Crear())
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar las sedes: " + ex.Message, ex);
            }
        }

        public DataTable KPIs(string idSede, DateTime desde, DateTime hasta)
        {
            return Ejecutar_Reporte("sp_Reporte_KPIs", idSede, desde, hasta);
        }

        public DataTable Ventas_Por_Sede(DateTime desde, DateTime hasta)
        {
            return Ejecutar_Reporte("sp_Reporte_Ventas_Por_Sede", null, desde, hasta);
        }

        public DataTable Platos_Mas_Pedidos(string idSede, DateTime desde, DateTime hasta)
        {
            return Ejecutar_Reporte("sp_Reporte_Platos_Mas_Pedidos", idSede, desde, hasta);
        }

        public DataTable Horas_Pico(string idSede, DateTime desde, DateTime hasta)
        {
            return Ejecutar_Reporte("sp_Reporte_Horas_Pico", idSede, desde, hasta);
        }

        public DataTable Top_Clientes(string idSede, DateTime desde, DateTime hasta)
        {
            return Ejecutar_Reporte("sp_Reporte_Top_Clientes", idSede, desde, hasta);
        }

        public DataTable Efectividad_Promociones(string idSede, DateTime desde, DateTime hasta)
        {
            return Ejecutar_Reporte("sp_Reporte_Efectividad_Promociones", idSede, desde, hasta);
        }

        private DataTable Ejecutar_Reporte(string procedimiento, string idSede, DateTime desde, DateTime hasta)
        {
            try
            {
                using (SqlConnection connection = CONEXION.Crear())
                {
                    using (SqlCommand cmd = new SqlCommand(procedimiento, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID_Sede", (object)idSede ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Desde", desde.Date);
                        cmd.Parameters.AddWithValue("@Hasta", hasta.Date);
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
                throw new Exception("Error al cargar el reporte: " + ex.Message, ex);
            }
        }
    }
}
