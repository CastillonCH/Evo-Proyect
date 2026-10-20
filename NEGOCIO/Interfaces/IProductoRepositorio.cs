using System.Collections.Generic;
using ENTIDADES;

namespace NEGOCIO
{
    // SOLID: DIP – La Caja pide los productos a este contrato; DATOS_PLATO lo implementa.
    public interface IProductoRepositorio
    {
        List<ENTIDAD_PRODUCTO_CAJA> Cargar_Productos_Venta();
    }
}
