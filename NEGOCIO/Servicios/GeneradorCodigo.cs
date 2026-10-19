namespace NEGOCIO
{
    // SOLID: SRP – Su única responsabilidad es armar el siguiente código con el formato de la BD.
    // Ej.: Siguiente("C1000", "C", 4) = "C1001";  Siguiente("P01501", "P", 5) = "P01502"
    public static class GeneradorCodigo
    {
        public static string Siguiente(string ultimoCodigo, string prefijo, int digitos)
        {
            int numero = 0;
            if (!string.IsNullOrEmpty(ultimoCodigo) && ultimoCodigo.StartsWith(prefijo))
                int.TryParse(ultimoCodigo.Substring(prefijo.Length), out numero);

            return prefijo + (numero + 1).ToString().PadLeft(digitos, '0');
        }
    }
}
