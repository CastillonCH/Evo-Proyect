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
    public class DATOS_EMPLEADO
    {
        public void Agregar_Empleado(ENTIDAD_EMPLEADO empleado)
        {
            string query = "Agregar_Empleado"; // Procedimiento almacenado

            try
            {
                using (SqlConnection connection = new SqlConnection(CONEXION.cn.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure; // Especificamos que es un procedimiento almacenado

                        // Agregar los parámetros correspondientes al procedimiento almacenado
                        cmd.Parameters.AddWithValue("@ID_Empleado", empleado.ID_Empleado);
                        cmd.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                        cmd.Parameters.AddWithValue("@Apellido", empleado.Apellido);
                        cmd.Parameters.AddWithValue("@Telefono", empleado.Telefono);
                        cmd.Parameters.AddWithValue("@Email", empleado.Email);
                        cmd.Parameters.AddWithValue("@Fec_Contratacion", empleado.Fec_Contratacion);
                        cmd.Parameters.AddWithValue("@ID_Rol", empleado.ID_Rol);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el empleado: " + ex.Message);
            }
        }

        public void Modificar_Empleado(ENTIDAD_EMPLEADO empleado)
        {
            string query = "Modificar_Empleado"; // Procedimiento almacenado

            try
            {
                using (SqlConnection connection = new SqlConnection(CONEXION.cn.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure; // Especificamos que es un procedimiento almacenado

                        // Agregar los parámetros correspondientes al procedimiento almacenado
                        cmd.Parameters.AddWithValue("@ID_Empleado", empleado.ID_Empleado);
                        cmd.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                        cmd.Parameters.AddWithValue("@Apellido", empleado.Apellido);
                        cmd.Parameters.AddWithValue("@Telefono", empleado.Telefono);
                        cmd.Parameters.AddWithValue("@Email", empleado.Email);
                        cmd.Parameters.AddWithValue("@Fec_Contratacion", empleado.Fec_Contratacion);
                        cmd.Parameters.AddWithValue("@ID_Rol", empleado.ID_Rol);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el empleado: " + ex.Message);
            }
        }

        public void Eliminar_Empleado(string idEmpleado)
        {
            string query = "Eliminar_Empleado"; // Procedimiento almacenado

            try
            {
                using (SqlConnection connection = new SqlConnection(CONEXION.cn.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure; // Especificamos que es un procedimiento almacenado

                        // Agregar el parámetro correspondiente al procedimiento almacenado
                        cmd.Parameters.AddWithValue("@ID_Empleado", idEmpleado);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el empleado: " + ex.Message);
            }
        }

        public DataTable Cargar_Empleado()
        {
            string query = "Cargar_Empleado"; // Procedimiento almacenado

            try
            {
                using (SqlConnection connection = new SqlConnection(CONEXION.cn.ConnectionString))
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
                throw new Exception("Error al cargar los empleados: " + ex.Message);
            }
        }
        public DataTable Cargar_Roles()
        {
            string query = "cargar_roles"; // Procedimiento almacenado

            try
            {
                using (SqlConnection connection = new SqlConnection(CONEXION.cn.ConnectionString))
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
                throw new Exception("Error al cargar los roles: " + ex.Message);
            }
        }

    }
}
