using System.Collections.Generic;
using System.Data;
using ENTIDADES;

namespace NEGOCIO
{
    // SOLID: DIP – ServicioVenta registra la venta a través de este contrato (la transacción la resuelve DATOS).
    public interface IVentaRepositorio
    {
        DataTable Cargar_MetodosPago();

        // Guarda Pedido + Detalle_Pedido + Venta + Detalle_Venta y descuenta el inventario: todo o nada
        ENTIDAD_RESULTADO_VENTA Registrar_Venta(ENTIDAD_PEDIDO_CAJA pedido, ENTIDAD_RESUMEN_PEDIDO resumen,
                                                string tipoComprobante, List<ENTIDAD_CONSUMO_INSUMO> consumos);
    }
}
