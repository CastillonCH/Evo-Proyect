namespace ENTIDADES
{
    // Cuánto de un insumo necesita un pedido y cuánto hay en la sede
    public class ENTIDAD_CONSUMO_INSUMO
    {
        public string ID_Insumo { get; set; }
        public string Nom_Insumo { get; set; }
        public string Unidad { get; set; }
        public decimal Cantidad_Requerida { get; set; }
        public decimal Stock_Actual { get; set; }

        public bool Alcanza { get { return Stock_Actual >= Cantidad_Requerida; } }
    }
}
