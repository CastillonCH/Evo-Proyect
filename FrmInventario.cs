using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ENTIDADES;
using NEGOCIO;

namespace RESTAURANTEFINAL
{
    // Stock por sede, alertas de stock mínimo, abastecimiento y consumo de un producto según su receta
    public partial class FrmInventario : Form
    {
        private readonly ServicioInventario _servicio;
        private readonly IProductoRepositorio _productos;
        private readonly ENTIDAD_USUARIO _usuario;
        private readonly List<ENTIDAD_DETALLE_ABASTECIMIENTO> _items = new List<ENTIDAD_DETALLE_ABASTECIMIENTO>();
        private bool _cargando;

        // SOLID: DIP – recibe ServicioInventario (que a su vez usa IInventarioRepositorio)
        public FrmInventario(ServicioInventario servicio, IProductoRepositorio productos, ENTIDAD_USUARIO usuario)
        {
            InitializeComponent();
            _servicio = servicio;
            _productos = productos;
            _usuario = usuario;

            Estilo.Grid(dgvInventario);
            Estilo.Grid(dgvItems);
            Estilo.Grid(dgvConsumo);
        }

        private void FrmInventario_Load(object sender, EventArgs e)
        {
            try
            {
                _cargando = true;
                cboSede.DataSource = _servicio.Cargar_Sedes();
                cboSede.DisplayMember = "Nom_Sede";
                cboSede.ValueMember = "ID_Sede";
                if (_usuario.ID_Sede != null)
                    cboSede.SelectedValue = _usuario.ID_Sede;
                cboSede.Enabled = _usuario.Perfil == "Administrador";   // solo el administrador cambia de sede

                cboProveedor.DataSource = _servicio.Cargar_Proveedores();
                cboProveedor.DisplayMember = "Nom_Proveedor";
                cboProveedor.ValueMember = "ID_Proveedor";

                cboInsumo.DataSource = _servicio.Cargar_Insumos();
                cboInsumo.DisplayMember = "Nombre";
                cboInsumo.ValueMember = "ID_Insumo";

                cboProductoConsumo.DataSource = _productos.Cargar_Productos_Venta();
                cboProductoConsumo.DisplayMember = "Nom_Plato";
                _cargando = false;

                cboInsumo_SelectedIndexChanged(null, EventArgs.Empty);
                Cargar_Inventario();
            }
            catch (Exception ex)
            {
                _cargando = false;
                MessageBox.Show("Error al cargar el inventario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string Sede_Seleccionada()
        {
            return cboSede.SelectedValue as string;
        }

        // ---------------------------------------------------------------- Stock
        private void Cargar_Inventario()
        {
            try
            {
                dgvInventario.DataSource = _servicio.Cargar_Inventario(Sede_Seleccionada());
                AyudaCRUD.Encabezados(dgvInventario, "ID_Insumo", "Código", "Insumo", "Insumo", "Clasificacion", "Clasificación",
                                      "Unidad", "Unidad", "Stock", "Stock", "Stock_Minimo", "Stock mínimo", "Estado", "Estado");
                dgvInventario.Columns["Stock"].DefaultCellStyle.Format = "#,0.###";
                dgvInventario.Columns["Stock_Minimo"].DefaultCellStyle.Format = "#,0.###";
                Aplicar_Filtro();

                int bajos = _servicio.Contar_Stock_Bajo(Sede_Seleccionada());
                lblResumen.ForeColor = bajos > 0 ? Estilo.Rojo : Estilo.Verde;
                lblResumen.Text = bajos > 0 ? "⚠ " + bajos + " insumo(s) bajo el mínimo" : "✔ Stock en orden";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el inventario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Aplicar_Filtro()
        {
            DataTable tabla = dgvInventario.DataSource as DataTable;
            if (tabla == null)
                return;

            string filtro = AyudaCRUD.Filtro_Texto(txtBuscar.Text, "ID_Insumo", "Insumo", "Clasificacion");
            if (chkSoloBajos.Checked)
                filtro = (filtro == "" ? "" : "(" + filtro + ") AND ") + "Estado = 'Bajo mínimo'";
            tabla.DefaultView.RowFilter = filtro;
        }

        // Pinta en rojo lo que está bajo el mínimo
        private void dgvInventario_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow fila in dgvInventario.Rows)
            {
                if (fila.Cells["Estado"].Value.ToString() == "Bajo mínimo")
                {
                    fila.DefaultCellStyle.BackColor = Estilo.RojoClaro;
                    fila.DefaultCellStyle.ForeColor = Estilo.Rojo;
                    fila.DefaultCellStyle.Font = Estilo.FuenteNegrita;
                    fila.DefaultCellStyle.SelectionBackColor = Estilo.Rojo;   // sigue en rojo aunque esté seleccionada
                    fila.DefaultCellStyle.SelectionForeColor = Color.White;
                }
            }
        }

        private void cboSede_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_cargando)
                Cargar_Inventario();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Aplicar_Filtro();
        }

        private void chkSoloBajos_CheckedChanged(object sender, EventArgs e)
        {
            Aplicar_Filtro();
        }

        // ---------------------------------------------------------------- Abastecimiento
        private void cboInsumo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView insumo = cboInsumo.SelectedItem as DataRowView;
            if (_cargando || insumo == null)
                return;
            lblUnidad.Text = insumo["Unidad"].ToString();
            nudPrecio.Value = Math.Min(nudPrecio.Maximum, Convert.ToDecimal(insumo["Precio_Unitario"]));
        }

        private void btnAgregarItem_Click(object sender, EventArgs e)
        {
            DataRowView insumo = cboInsumo.SelectedItem as DataRowView;
            if (insumo == null)
            {
                MessageBox.Show("Seleccione un insumo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string idInsumo = insumo["ID_Insumo"].ToString();
            ENTIDAD_DETALLE_ABASTECIMIENTO item = _items.FirstOrDefault(i => i.ID_Insumo == idInsumo);
            if (item == null)
            {
                _items.Add(new ENTIDAD_DETALLE_ABASTECIMIENTO
                {
                    ID_Insumo = idInsumo,
                    Nom_Insumo = insumo["Nombre"].ToString(),
                    Cantidad = (int)nudCantidad.Value,
                    Precio_Unitario = nudPrecio.Value
                });
            }
            else
            {
                item.Cantidad += (int)nudCantidad.Value;
                item.Precio_Unitario = nudPrecio.Value;
            }
            Mostrar_Items();
        }

        private void btnQuitarItem_Click(object sender, EventArgs e)
        {
            if (dgvItems.CurrentRow != null)
            {
                _items.RemoveAt(dgvItems.CurrentRow.Index);
                Mostrar_Items();
            }
        }

        private void Mostrar_Items()
        {
            dgvItems.Rows.Clear();
            foreach (ENTIDAD_DETALLE_ABASTECIMIENTO item in _items)
                dgvItems.Rows.Add(item.Nom_Insumo, item.Cantidad, item.Precio_Unitario.ToString("N2"));
        }

        private void btnRegistrarAbastecimiento_Click(object sender, EventArgs e)
        {
            ENTIDAD_ABASTECIMIENTO abastecimiento = new ENTIDAD_ABASTECIMIENTO
            {
                ID_Sede = Sede_Seleccionada(),
                ID_Proveedor = cboProveedor.SelectedValue as string,
                Comentario = string.IsNullOrWhiteSpace(txtComentario.Text) ? null : txtComentario.Text.Trim(),
                Detalles = new List<ENTIDAD_DETALLE_ABASTECIMIENTO>(_items)
            };

            try
            {
                _servicio.Registrar_Abastecimiento(abastecimiento);
                MessageBox.Show("Abastecimiento " + abastecimiento.ID_Abastecimiento + " registrado. El stock fue actualizado.",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _items.Clear();
                Mostrar_Items();
                txtComentario.Clear();
                Cargar_Inventario();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------------------------------------------------------------- Consumo por receta
        private void btnVerConsumo_Click(object sender, EventArgs e)
        {
            ENTIDAD_PRODUCTO_CAJA producto = cboProductoConsumo.SelectedItem as ENTIDAD_PRODUCTO_CAJA;
            if (producto == null)
                return;

            try
            {
                List<ENTIDAD_CONSUMO_INSUMO> consumo = _servicio.Consumo_De_Producto(Sede_Seleccionada(), producto);
                if (consumo.Count == 0)
                    MessageBox.Show("El producto no tiene receta registrada.", "Consumo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgvConsumo.DataSource = consumo.Select(c => new
                {
                    Insumo = c.Nom_Insumo,
                    Necesita = c.Cantidad_Requerida.ToString("0.###") + " " + c.Unidad,
                    Stock = c.Stock_Actual.ToString("0.###"),
                    Alcanza = c.Alcanza ? "Sí" : "No"
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular el consumo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
