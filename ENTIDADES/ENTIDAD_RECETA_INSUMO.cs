namespace ENTIDADES
{
    // Un insumo de la receta de un plato (Plato_Insumo), en la unidad del insumo
    public class ENTIDAD_RECETA_INSUMO
    {
        public string ID_Plato { get; set; }
        public string ID_Insumo { get; set; }
        public string Nom_Insumo { get; set; }
        public string Unidad { get; set; }
        public decimal Cant_Necesaria { get; set; }
    }
}
