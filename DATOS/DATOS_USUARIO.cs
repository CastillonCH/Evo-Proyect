using System;
using System.Data;
using System.Data.SqlClient;
using ENTIDADES;
using NEGOCIO;

namespace DATOS
{
    public class DATOS_USUARIO : IUsuarioRepositorio
    {
        // Busca el usuario con su empleado y sede (SP en 02_cambios_spyci.sql)
        public ENTIDAD_USUARIO Buscar_Usuario(string usuario)
        {
            try
            {
                using (SqlConnection connection = CONEXION.Crear())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Buscar_Usuario", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Usuario", usuario);
                        connection.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (!dr.Read())
                                return null;

                            return new ENTIDAD_USUARIO
                            {
                                ID_Usuario = Convert.ToInt32(dr["ID_Usuario"]),
                                ID_Empleado = dr["ID_Empleado"].ToString(),
                                Nombre_Empleado = dr["Nombre_Empleado"].ToString(),
                                Usuario = dr["Usuario"].ToString(),
                                Clave_Hash = dr["Clave_Hash"].ToString(),
                                Perfil = dr["Perfil"].ToString(),
                                ID_Sede = dr["ID_Sede"] == DBNull.Value ? null : dr["ID_Sede"].ToString(),
                                Nom_Sede = dr["Nom_Sede"] == DBNull.Value ? "Todas las sedes" : dr["Nom_Sede"].ToString(),
                                Activo = Convert.ToBoolean(dr["Activo"])
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el usuario: " + ex.Message, ex);
            }
        }
    }
}
