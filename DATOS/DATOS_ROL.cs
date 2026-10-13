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
    public class DATOS_ROL
    {
        // Método para agregar un nuevo rol
        public void Agregar_Rol(ENTIDAD_ROL rol)
        {
            string query = "INSERT INTO Rol (ID_Rol, ID_Departamento, Nom_Rol, Salario) " +
                           "VALUES (@ID_Rol, @ID_Departamento, @Nom_Rol, @Salario)";
            try
            {
                using (SqlConnection connection = new SqlConnection(CONEXION.cn.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.Add("@ID_Rol", SqlDbType.VarChar).Value = rol.ID_Rol;
                        cmd.Parameters.Add("@ID_Departamento", SqlDbType.VarChar).Value = rol.ID_Departamento;
                        cmd.Parameters.Add("@Nom_Rol", SqlDbType.VarChar).Value = rol.Nom_Rol;
                        cmd.Parameters.Add("@Salario", SqlDbType.Decimal).Value = rol.Salario;

                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                // Manejo más específico de errores de SQL
                throw new Exception("Error al agregar el rol en la base de datos: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Manejo de errores generales
                throw new Exception("Error inesperado al agregar el rol: " + ex.Message);
            }
        }

        // Método para modificar un rol existente
        public void Modificar_Rol(ENTIDAD_ROL rol)
        {
            string query = "UPDATE Rol SET ID_Departamento = @ID_Departamento, Nom_Rol = @Nom_Rol, " +
                           "Salario = @Salario WHERE ID_Rol = @ID_Rol";
            try
            {
                using (SqlConnection connection = new SqlConnection(CONEXION.cn.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID_Rol", rol.ID_Rol);
                        cmd.Parameters.AddWithValue("@ID_Departamento", rol.ID_Departamento);
                        cmd.Parameters.AddWithValue("@Nom_Rol", rol.Nom_Rol);
                     
                        cmd.Parameters.AddWithValue("@Salario", rol.Salario);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el rol: " + ex.Message);
            }
        }

        // Método para eliminar un rol
        public void Eliminar_Rol(string idRol)
        {
            string query = "DELETE FROM Rol WHERE ID_Rol = @ID_Rol";
            try
            {
                using (SqlConnection connection = new SqlConnection(CONEXION.cn.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID_Rol", idRol);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el rol: " + ex.Message);
            }
        }

        // Método para cargar todos los roles
        public DataTable Cargar_Roles()
        {
            string query = "SELECT ID_Rol, ID_Departamento, Nom_Rol, Salario FROM Rol";
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
                throw new Exception("Error al cargar los roles: " + ex.Message);
            }
        }

        // Método para cargar los departamentos
        public DataTable Cargar_Departamentos()
        {
            string query = "SELECT ID_Departamento, Nom_Departamento FROM Departamento";
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
                throw new Exception("Error al cargar los departamentos: " + ex.Message);
            }
        }
    }
}
