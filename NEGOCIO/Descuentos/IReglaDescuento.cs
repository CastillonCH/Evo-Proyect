using ENTIDADES;

namespace NEGOCIO
{
    // SOLID: OCP – Cada descuento es una clase que implementa esta interfaz.
    // Para agregar un descuento nuevo se crea otra clase; CalculadoraPedido no se modifica.
    public interface IReglaDescuento
    {
        string Nombre { get; }

        // Descuento en soles por cada unidad de la línea (0 si la regla no aplica)
        decimal Descuento_Unitario(ENTIDAD_LINEA_PEDIDO linea, ENTIDAD_PEDIDO_CAJA pedido);
    }
}
