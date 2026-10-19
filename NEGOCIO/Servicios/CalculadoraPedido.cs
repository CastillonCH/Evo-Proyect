using System;
using System.Collections.Generic;
using System.Linq;
using ENTIDADES;

namespace NEGOCIO
{
    // SOLID: SRP – Solo calcula montos (subtotal, descuento, IGV y total). No toca la BD ni la pantalla.
    // SOLID: OCP – Recibe una lista de IReglaDescuento; agregar un descuento no cambia esta clase.
    public class CalculadoraPedido
    {
        public const decimal TASA_IGV = 0.18m;

        private readonly List<IReglaDescuento> _reglas;

        public CalculadoraPedido(IEnumerable<IReglaDescuento> reglas)
        {
            _reglas = reglas.ToList();
        }

        public ENTIDAD_RESUMEN_PEDIDO Calcular(ENTIDAD_PEDIDO_CAJA pedido)
        {
            ENTIDAD_RESUMEN_PEDIDO resumen = new ENTIDAD_RESUMEN_PEDIDO();

            foreach (ENTIDAD_LINEA_PEDIDO linea in pedido.Lineas)
            {
                // Se aplica la regla que da el mayor descuento (los descuentos no se acumulan)
                linea.Descuento_Unitario = 0m;
                linea.Descuento_Aplicado = null;
                foreach (IReglaDescuento regla in _reglas)
                {
                    decimal descuento = regla.Descuento_Unitario(linea, pedido);
                    if (descuento > linea.Descuento_Unitario)
                    {
                        linea.Descuento_Unitario = Math.Min(descuento, linea.Producto.Precio);
                        linea.Descuento_Aplicado = regla.Nombre;
                    }
                }

                resumen.Subtotal += linea.Subtotal;
                resumen.Descuento += linea.Descuento_Unitario * linea.Cantidad;
            }

            // Los precios incluyen IGV: el IGV se "extrae" del total
            resumen.Total = resumen.Subtotal - resumen.Descuento;
            resumen.Base_Imponible = Math.Round(resumen.Total / (1 + TASA_IGV), 2);
            resumen.IGV = resumen.Total - resumen.Base_Imponible;
            return resumen;
        }
    }
}
