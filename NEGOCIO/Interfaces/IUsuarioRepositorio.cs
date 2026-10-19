using ENTIDADES;

namespace NEGOCIO
{
    // SOLID: DIP – ServicioAutenticacion busca usuarios a través de este contrato.
    public interface IUsuarioRepositorio
    {
        ENTIDAD_USUARIO Buscar_Usuario(string usuario);
    }
}
