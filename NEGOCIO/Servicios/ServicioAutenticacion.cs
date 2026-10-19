using System;
using System.Security.Cryptography;
using System.Text;
using ENTIDADES;

namespace NEGOCIO
{
    // SOLID: SRP – Solo verifica usuario y contraseña (hash SHA256).
    // SOLID: DIP – Recibe IUsuarioRepositorio; no sabe si los usuarios están en SQL Server u otro lugar.
    public class ServicioAutenticacion
    {
        private readonly IUsuarioRepositorio _usuarios;

        public ServicioAutenticacion(IUsuarioRepositorio usuarios)
        {
            _usuarios = usuarios;
        }

        // Devuelve el usuario si las credenciales son correctas; null en caso contrario
        public ENTIDAD_USUARIO Iniciar_Sesion(string usuario, string clave)
        {
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrEmpty(clave))
                throw new InvalidOperationException("Ingrese usuario y contraseña.");

            ENTIDAD_USUARIO encontrado = _usuarios.Buscar_Usuario(usuario.Trim());
            if (encontrado == null || !encontrado.Activo)
                return null;

            bool claveCorrecta = string.Equals(encontrado.Clave_Hash, Calcular_Hash(clave), StringComparison.OrdinalIgnoreCase);
            return claveCorrecta ? encontrado : null;
        }

        // Mismo resultado que en SQL: CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', 'clave'), 2)
        public static string Calcular_Hash(string clave)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(clave));
                return BitConverter.ToString(bytes).Replace("-", "");
            }
        }
    }
}
