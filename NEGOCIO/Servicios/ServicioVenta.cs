using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ENTIDADES;

namespace NEGOCIO
{
    // SOLID: SRP – Coordina el cobro: valida, calcula, revisa stock y manda registrar la venta.
    //        No sabe calcular descuentos (CalculadoraPedido) ni descontar insumos (ServicioInventario).
    // SOLID: DIP – Todas sus dependencias llegan por constructor como abstracciones o servicios.
    public class ServicioVenta
    {
        public const string CLIENTE_VARIOS = "C0000";

        private readonly CalculadoraPedido _calculadora;
        private readonly ServicioInventario _inventario;
        private readonly IVentaRepositorio _ventas;
        private readonly IClienteRepositorio _clientes;

        public ServicioVenta(CalculadoraPedido calculadora, ServicioInventario inventario,
                             IVentaRepositorio ventas, IClienteRepositorio clientes)
        {
            _calculadora = calculadora;
            _inventario = inventario;
            _ventas = ventas;
            _clientes = clientes;
        }

        public DataTable Cargar_MetodosPago() { return _ventas.Cargar_MetodosPago(); }

        // Asigna (o quita, con idCliente = null) el cliente del pedido y cuenta sus compras previas
        public void Asignar_Cliente(ENTIDAD_PEDIDO_CAJA pedido, string idCliente, string nombre)
        {
            pedido.ID_Cliente = idCliente;
            pedido.Nom_Cliente = nombre;
            pedido.Compras_Cliente = string.IsNullOrEmpty(idCliente) ? 0 : _clientes.Contar_Compras(idCliente);
        }

        public ENTIDAD_RESUMEN_PEDIDO Calcular(ENTIDAD_PEDIDO_CAJA pedido)
        {
            return _calculadora.Calcular(pedido);
        }

        public List<ENTIDAD_CONSUMO_INSUMO> Insumos_Faltantes(ENTIDAD_PEDIDO_CAJA pedido)
        {
            return _inventario.Insumos_Faltantes(pedido.ID_Sede, pedido.Lineas);
        }

        public ENTIDAD_RESULTADO_VENTA Cobrar(ENTIDAD_PEDIDO_CAJA pedido, IComprobante comprobante)
        {
            if (pedido.Lineas.Count == 0)
                throw new InvalidOperationException("Agregue al menos un producto.");
            if (string.IsNullOrEmpty(pedido.ID_Sede))
                throw new InvalidOperationException("El usuario no tiene una sede asignada.");
            if (string.IsNullOrEmpty(pedido.ID_Metodo_Pago))
                throw new InvalidOperationException("Seleccione el método de pago.");
            if (string.IsNullOrEmpty(pedido.Tipo_Pedido))
                throw new InvalidOperationException("Seleccione el tipo de pedido.");

            string error = comprobante.Validar(pedido);
            if (error != null)
                throw new InvalidOperationException(error);

            if (string.IsNullOrEmpty(pedido.ID_Cliente))
                pedido.ID_Cliente = CLIENTE_VARIOS;

            pedido.Fecha = DateTime.Now;
            ENTIDAD_RESUMEN_PEDIDO resumen = _calculadora.Calcular(pedido);

            List<ENTIDAD_CONSUMO_INSUMO> consumos = _inventario.Calcular_Consumo(pedido.ID_Sede, pedido.Lineas);
            List<ENTIDAD_CONSUMO_INSUMO> faltantes = consumos.Where(c => !c.Alcanza).ToList();
            if (faltantes.Count > 0)
                throw new InvalidOperationException("Stock insuficiente de: " +
                    string.Join(", ", faltantes.Select(f => f.Nom_Insumo)));

            return _ventas.Registrar_Venta(pedido, resumen, comprobante.Tipo, consumos);
        }
    }
}
