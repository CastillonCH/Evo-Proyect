using System;
using System.Collections.Generic;
using ENTIDADES;

namespace NEGOCIO
{
    // SOLID: DIP – La pantalla de Cocina solo conoce este contrato.
    public interface IPedidoRepositorio
    {
        List<ENTIDAD_PEDIDO_COCINA> Cargar_Pedidos_Cocina(string idSede, DateTime fecha);
        void Cambiar_Estado(string idPedido, string nuevoEstado);
    }
}
