using System.Linq;
using System.Text.RegularExpressions;
using ENTIDADES;

namespace NEGOCIO
{
    // SOLID: SRP – Solo valida los datos de un cliente; no guarda ni muestra mensajes.
    public static class ValidadorCliente
    {
        // Devuelve el primer error encontrado o null si el cliente es válido
        public static string Validar(ENTIDAD_CLIENTE cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.ID_Cliente))
                return "El código del cliente es obligatorio.";
            if (string.IsNullOrWhiteSpace(cliente.Nom_Cliente) || string.IsNullOrWhiteSpace(cliente.Ape_Cliente))
                return "Ingrese nombres y apellidos.";
            if (!Regex.IsMatch(cliente.Tel_Cliente ?? "", @"^\d{6,15}$"))
                return "El teléfono debe tener solo números (6 a 15 dígitos).";
            if (!string.IsNullOrWhiteSpace(cliente.Email) &&
                !Regex.IsMatch(cliente.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return "Ingrese un correo válido.";
            return null;
        }

        public static bool Es_RUC_Valido(string ruc)
        {
            return ruc != null && ruc.Length == 11 && ruc.All(char.IsDigit);
        }
    }
}
