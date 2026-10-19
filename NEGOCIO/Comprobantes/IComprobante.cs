using System.Collections.Generic;
using ENTIDADES;

namespace NEGOCIO
{
    // SOLID: OCP – Boleta y Factura implementan esta interfaz. Un comprobante nuevo
    // (ej. Nota de Venta) sería otra clase, sin cambiar la Caja ni ServicioVenta.
    public interface IComprobante
    {
        string Tipo { get; }

        // true si la Caja debe pedir RUC y razón social
        bool Requiere_RUC { get; }

        // Devuelve el mensaje de error o null si el pedido cumple los requisitos del comprobante
        string Validar(ENTIDAD_PEDIDO_CAJA pedido);

        // Líneas que se imprimen en el comprobante
        List<string> Lineas_Cliente(ENTIDAD_PEDIDO_CAJA pedido);
        List<string> Lineas_Totales(ENTIDAD_RESUMEN_PEDIDO resumen);
    }
}
