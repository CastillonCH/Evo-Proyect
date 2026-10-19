using System.Data;
using ENTIDADES;

namespace NEGOCIO
{
    // SOLID: DIP – Formularios y servicios dependen de este contrato, no de DATOS_CLIENTE ni de SQL Server.
    public interface IClienteRepositorio
    {
        DataTable Cargar_Cliente();
        void Agregar_Cliente(ENTIDAD_CLIENTE cliente);
        void Modificar_Cliente(ENTIDAD_CLIENTE cliente);
        void Eliminar_Cliente(string idCliente);
        string Ultimo_Codigo();
        int Contar_Compras(string idCliente);
    }
}
