using System;
using System.Collections.Generic;

namespace ENTIDADES
{
    // Ingreso de mercadería a una sede (Abastecimiento + Detalle_Abastecimiento)
    public class ENTIDAD_ABASTECIMIENTO
    {
        public string ID_Abastecimiento { get; set; }
        public DateTime Fecha_Abastecimiento { get; set; } = DateTime.Now;
        public string ID_Sede { get; set; }
        public string ID_Proveedor { get; set; }
        public string Comentario { get; set; }
        public List<ENTIDAD_DETALLE_ABASTECIMIENTO> Detalles { get; set; } = new List<ENTIDAD_DETALLE_ABASTECIMIENTO>();
    }

    public class ENTIDAD_DETALLE_ABASTECIMIENTO
    {
        public string ID_Insumo { get; set; }
        public string Nom_Insumo { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio_Unitario { get; set; }
    }
}
