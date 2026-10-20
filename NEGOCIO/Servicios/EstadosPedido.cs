namespace NEGOCIO
{
    // SOLID: SRP – Solo conoce el orden de los estados de un pedido en cocina.
    public static class EstadosPedido
    {
        public const string PENDIENTE = "Pendiente";
        public const string EN_PREPARACION = "En preparación";
        public const string LISTO = "Listo";
        public const string ENTREGADO = "Entregado";
        public const string ANULADO = "Anulado";

        // Pendiente → En preparación → Listo → Entregado (null si ya no avanza)
        public static string Siguiente(string estado)
        {
            switch (estado)
            {
                case PENDIENTE: return EN_PREPARACION;
                case EN_PREPARACION: return LISTO;
                case LISTO: return ENTREGADO;
                default: return null;
            }
        }
    }
}
