using System.Collections.Generic;
using System.Data;
using ENTIDADES;

namespace NEGOCIO
{
    // SOLID: DIP – ServicioInventario trabaja con este contrato, no con SqlCommand.
    public interface IInventarioRepositorio
    {
        List<ENTIDAD_RECETA_INSUMO> Cargar_Receta(string idPlato);
        decimal Obtener_Stock(string idSede, string idInsumo);
        DataTable Cargar_Inventario(string idSede);
        DataTable Cargar_Sedes();
        DataTable Cargar_Proveedores();
        DataTable Cargar_Insumos();
        void Registrar_Abastecimiento(ENTIDAD_ABASTECIMIENTO abastecimiento);
        int Contar_Stock_Bajo(string idSede);
    }
}
