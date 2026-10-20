namespace ENTIDADES
{
    public class ENTIDAD_USUARIO
    {
        public int ID_Usuario { get; set; }
        public string ID_Empleado { get; set; }
        public string Nombre_Empleado { get; set; }
        public string Usuario { get; set; }
        public string Clave_Hash { get; set; }
        public string Perfil { get; set; }      // Administrador / Cajero / Cocina
        public string ID_Sede { get; set; }
        public string Nom_Sede { get; set; }
        public bool Activo { get; set; }
    }
}
