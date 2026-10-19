using System;
using System.Data;

namespace NEGOCIO
{
    // SOLID: DIP – Reportes depende de este contrato. idSede = null significa "todas las sedes".
    public interface IReporteRepositorio
    {
        DataTable Cargar_Sedes();
        DataTable KPIs(string idSede, DateTime desde, DateTime hasta);
        DataTable Ventas_Por_Sede(DateTime desde, DateTime hasta);
        DataTable Platos_Mas_Pedidos(string idSede, DateTime desde, DateTime hasta);
        DataTable Horas_Pico(string idSede, DateTime desde, DateTime hasta);
        DataTable Top_Clientes(string idSede, DateTime desde, DateTime hasta);
        DataTable Efectividad_Promociones(string idSede, DateTime desde, DateTime hasta);
    }
}
