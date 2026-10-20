using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ENTIDADES;

namespace NEGOCIO
{
    // SOLID: SRP – Todo lo que es "inventario": cuánto consume un pedido según la receta,
    // si alcanza el stock y el registro de abastecimientos.
    // SOLID: DIP – Recibe IInventarioRepositorio por constructor.
    public class ServicioInventario
    {
        private readonly IInventarioRepositorio _repositorio;

        public ServicioInventario(IInventarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        // Suma la receta (Plato_Insumo) de cada línea x cantidad, agrupado por insumo
        public List<ENTIDAD_CONSUMO_INSUMO> Calcular_Consumo(string idSede, IEnumerable<ENTIDAD_LINEA_PEDIDO> lineas)
        {
            Dictionary<string, ENTIDAD_CONSUMO_INSUMO> consumos = new Dictionary<string, ENTIDAD_CONSUMO_INSUMO>();

            foreach (ENTIDAD_LINEA_PEDIDO linea in lineas)
            {
                foreach (ENTIDAD_RECETA_INSUMO item in _repositorio.Cargar_Receta(linea.Producto.ID_Plato))
                {
                    if (!consumos.ContainsKey(item.ID_Insumo))
                    {
                        consumos[item.ID_Insumo] = new ENTIDAD_CONSUMO_INSUMO
                        {
                            ID_Insumo = item.ID_Insumo,
                            Nom_Insumo = item.Nom_Insumo,
                            Unidad = item.Unidad,
                            Stock_Actual = _repositorio.Obtener_Stock(idSede, item.ID_Insumo)
                        };
                    }
                    consumos[item.ID_Insumo].Cantidad_Requerida += item.Cant_Necesaria * linea.Cantidad;
                }
            }
            return consumos.Values.ToList();
        }

        // Insumos que no alcanzan para el pedido
        public List<ENTIDAD_CONSUMO_INSUMO> Insumos_Faltantes(string idSede, IEnumerable<ENTIDAD_LINEA_PEDIDO> lineas)
        {
            return Calcular_Consumo(idSede, lineas).Where(c => !c.Alcanza).ToList();
        }

        // Consumo de 1 unidad de un producto (botón "Ver consumo")
        public List<ENTIDAD_CONSUMO_INSUMO> Consumo_De_Producto(string idSede, ENTIDAD_PRODUCTO_CAJA producto)
        {
            ENTIDAD_LINEA_PEDIDO linea = new ENTIDAD_LINEA_PEDIDO { Producto = producto, Cantidad = 1 };
            return Calcular_Consumo(idSede, new[] { linea });
        }

        public DataTable Cargar_Inventario(string idSede) { return _repositorio.Cargar_Inventario(idSede); }
        public DataTable Cargar_Sedes() { return _repositorio.Cargar_Sedes(); }
        public DataTable Cargar_Proveedores() { return _repositorio.Cargar_Proveedores(); }
        public DataTable Cargar_Insumos() { return _repositorio.Cargar_Insumos(); }
        public int Contar_Stock_Bajo(string idSede) { return _repositorio.Contar_Stock_Bajo(idSede); }

        public void Registrar_Abastecimiento(ENTIDAD_ABASTECIMIENTO abastecimiento)
        {
            if (string.IsNullOrEmpty(abastecimiento.ID_Sede))
                throw new InvalidOperationException("Seleccione la sede.");
            if (string.IsNullOrEmpty(abastecimiento.ID_Proveedor))
                throw new InvalidOperationException("Seleccione el proveedor.");
            if (abastecimiento.Detalles.Count == 0)
                throw new InvalidOperationException("Agregue al menos un insumo.");
            if (abastecimiento.Detalles.Any(d => d.Cantidad <= 0 || d.Precio_Unitario < 0))
                throw new InvalidOperationException("Las cantidades deben ser mayores a cero.");

            _repositorio.Registrar_Abastecimiento(abastecimiento);
        }
    }
}
