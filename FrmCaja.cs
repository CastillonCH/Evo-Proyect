using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using ENTIDADES;
using NEGOCIO;

namespace RESTAURANTEFINAL
{
    // Punto de venta: el cajero arma el pedido con botones y cobra en una sola operación
    public partial class FrmCaja : Form
    {
        private readonly IProductoRepositorio _productos;
        private readonly IClienteRepositorio _clientes;
        private readonly ServicioVenta _servicioVenta;
        private readonly List<IComprobante> _comprobantes;
        private readonly ENTIDAD_USUARIO _usuario;

        private List<ENTIDAD_PRODUCTO_CAJA> _listaProductos = new List<ENTIDAD_PRODUCTO_CAJA>();
        private ENTIDAD_PEDIDO_CAJA _pedido;
        private List<string> _lineasComprobante = new List<string>();
        private bool _cargando;

        // SOLID: DIP – la Caja recibe abstracciones y servicios; no crea DATOS_* ni conoce SQL.
        // SOLID: OCP – recibe la lista de comprobantes: uno nuevo aparece aquí sin cambiar este formulario.
        public FrmCaja(IProductoRepositorio productos, IClienteRepositorio clientes, ServicioVenta servicioVenta,
                       List<IComprobante> comprobantes, ENTIDAD_USUARIO usuario)
        {
            InitializeComponent();
            _productos = productos;
            _clientes = clientes;
            _servicioVenta = servicioVenta;
            _comprobantes = comprobantes;
            _usuario = usuario;

            Estilo.Grid(dgvCarrito);
            dgvCarrito.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }

        private void FrmCaja_Load(object sender, EventArgs e)
        {
            try
            {
                _listaProductos = _productos.Cargar_Productos_Venta();
                Cargar_Combos();
                Mostrar_Productos("");
                Nuevo_Pedido();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la caja: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cargar_Combos()
        {
            _cargando = true;

            cboMetodoPago.DataSource = _servicioVenta.Cargar_MetodosPago();
            cboMetodoPago.DisplayMember = "Nom_Metodo_Pago";
            cboMetodoPago.ValueMember = "ID_Metodo_Pago";

            // Se muestran los nombres; el comprobante elegido se toma por posición
            cboComprobante.DataSource = _comprobantes.Select(c => c.Tipo).ToList();

            // Cliente opcional: primera opción "Cliente varios" y luego los clientes registrados
            DataTable lista = new DataTable();
            lista.Columns.Add("ID_Cliente");
            lista.Columns.Add("Texto");
            lista.Rows.Add("", "(Cliente varios)");
            foreach (DataRow fila in _clientes.Cargar_Cliente().Rows)
            {
                string id = fila["ID_Cliente"].ToString();
                if (id != ServicioVenta.CLIENTE_VARIOS)
                    lista.Rows.Add(id, id + " - " + fila["Nom_Cliente"] + " " + fila["Ape_Cliente"]);
            }
            cboCliente.DataSource = lista;
            cboCliente.DisplayMember = "Texto";
            cboCliente.ValueMember = "ID_Cliente";

            _cargando = false;
        }

        // ---------------------------------------------------------------- Productos
        private void Mostrar_Productos(string filtro)
        {
            flpProductos.SuspendLayout();
            flpProductos.Controls.Clear();
            foreach (ENTIDAD_PRODUCTO_CAJA producto in _listaProductos)
            {
                if (filtro == "" || producto.Nom_Plato.IndexOf(filtro, StringComparison.OrdinalIgnoreCase) >= 0)
                    flpProductos.Controls.Add(Crear_Boton_Producto(producto));
            }
            flpProductos.ResumeLayout();
        }

        private Button Crear_Boton_Producto(ENTIDAD_PRODUCTO_CAJA producto)
        {
            Button boton = new Button();
            boton.Size = new Size(180, 100);
            boton.Margin = new Padding(6);
            boton.Text = producto.Nom_Plato + "\nS/ " + producto.Precio.ToString("N2");
            boton.Tag = producto;
            Estilo.Boton(boton, Color.White);
            boton.ForeColor = Estilo.Negro;
            boton.FlatAppearance.BorderSize = 1;
            boton.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);
            boton.FlatAppearance.MouseOverBackColor = Estilo.AcentoClaro;
            boton.Click += BotonProducto_Click;

            // Badge de promoción vigente (ej. "-20%")
            if (DescuentoPromocion.Esta_Vigente(producto, DateTime.Now))
            {
                Label badge = new Label();
                badge.Text = "-" + producto.Porc_Descuento.ToString("0.##") + "%";
                badge.BackColor = Estilo.Acento;
                badge.ForeColor = Estilo.Negro;
                badge.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                badge.TextAlign = ContentAlignment.MiddleCenter;
                badge.Size = new Size(54, 22);
                badge.Location = new Point(boton.Width - badge.Width - 4, 4);
                badge.Click += (s, ev) => boton.PerformClick();
                boton.Controls.Add(badge);
            }
            return boton;
        }

        private void BotonProducto_Click(object sender, EventArgs e)
        {
            ENTIDAD_PRODUCTO_CAJA producto = (ENTIDAD_PRODUCTO_CAJA)((Button)sender).Tag;

            ENTIDAD_LINEA_PEDIDO linea = _pedido.Lineas.FirstOrDefault(l => l.Producto.ID_Plato == producto.ID_Plato);
            if (linea == null)
                _pedido.Lineas.Add(new ENTIDAD_LINEA_PEDIDO { Producto = producto, Cantidad = 1 });
            else
                linea.Cantidad++;

            Refrescar_Carrito();
        }

        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            Mostrar_Productos(txtBuscarProducto.Text.Trim());
        }

        // ---------------------------------------------------------------- Carrito
        // Recalcula descuentos y total en vivo con CalculadoraPedido (a través de ServicioVenta)
        private void Refrescar_Carrito()
        {
            ENTIDAD_RESUMEN_PEDIDO resumen = _servicioVenta.Calcular(_pedido);

            dgvCarrito.Rows.Clear();
            foreach (ENTIDAD_LINEA_PEDIDO linea in _pedido.Lineas)
            {
                string nombre = linea.Producto.Nom_Plato;
                if (linea.Descuento_Aplicado != null)
                    nombre += "  (" + linea.Descuento_Aplicado + ")";
                dgvCarrito.Rows.Add(nombre, linea.Cantidad, null, null, linea.Total.ToString("N2"), null);
            }

            lblSubtotal.Text = "S/ " + resumen.Subtotal.ToString("N2");
            lblDescuento.Text = "- S/ " + resumen.Descuento.ToString("N2");
            lblTotal.Text = "S/ " + resumen.Total.ToString("N2");
        }

        private void dgvCarrito_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _pedido.Lineas.Count)
                return;

            ENTIDAD_LINEA_PEDIDO linea = _pedido.Lineas[e.RowIndex];
            if (e.ColumnIndex == colMas.Index)
                linea.Cantidad++;
            else if (e.ColumnIndex == colMenos.Index)
                linea.Cantidad--;
            else if (e.ColumnIndex == colQuitar.Index)
                linea.Cantidad = 0;
            else
                return;

            if (linea.Cantidad <= 0)
                _pedido.Lineas.Remove(linea);
            Refrescar_Carrito();
        }

        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cargando || _pedido == null)
                return;
            try
            {
                DataRowView fila = cboCliente.SelectedItem as DataRowView;
                string idCliente = fila == null ? "" : fila["ID_Cliente"].ToString();
                if (idCliente == "")
                    _servicioVenta.Asignar_Cliente(_pedido, null, null);
                else   // "C0001 - Juan Perez" -> "Juan Perez"
                    _servicioVenta.Asignar_Cliente(_pedido, idCliente, fila["Texto"].ToString().Substring(idCliente.Length + 3));
                Refrescar_Carrito();   // puede aplicar el descuento de cliente frecuente
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // RUC y razón social solo se piden si el comprobante lo requiere (Factura)
        private void cboComprobante_SelectedIndexChanged(object sender, EventArgs e)
        {
            IComprobante comprobante = Comprobante_Seleccionado();
            bool pedirRUC = comprobante != null && comprobante.Requiere_RUC;
            lblRUC.Visible = pedirRUC;
            txtRUC.Visible = pedirRUC;
            lblRazonSocial.Visible = pedirRUC;
            txtRazonSocial.Visible = pedirRUC;
        }

        private IComprobante Comprobante_Seleccionado()
        {
            return cboComprobante.SelectedIndex < 0 ? null : _comprobantes[cboComprobante.SelectedIndex];
        }

        private void Nuevo_Pedido()
        {
            _pedido = new ENTIDAD_PEDIDO_CAJA { ID_Sede = _usuario.ID_Sede };

            _cargando = true;
            cboTipoPedido.SelectedIndex = 0;
            cboCliente.SelectedIndex = 0;
            cboComprobante.SelectedIndex = 0;
            _cargando = false;

            txtRUC.Clear();
            txtRazonSocial.Clear();
            txtObservaciones.Clear();
            Refrescar_Carrito();
        }

        private void btnNuevoPedido_Click(object sender, EventArgs e)
        {
            if (_pedido.Lineas.Count == 0 ||
                MessageBox.Show("¿Descartar el pedido actual?", "Nuevo pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Nuevo_Pedido();
        }

        // ---------------------------------------------------------------- Cobro
        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (_pedido.Lineas.Count == 0)
            {
                MessageBox.Show("Agregue al menos un producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IComprobante comprobante = Comprobante_Seleccionado();
            _pedido.Tipo_Pedido = cboTipoPedido.Text;
            _pedido.ID_Metodo_Pago = cboMetodoPago.SelectedValue as string;
            _pedido.Observaciones = string.IsNullOrWhiteSpace(txtObservaciones.Text) ? null : txtObservaciones.Text.Trim();
            _pedido.RUC = comprobante.Requiere_RUC ? txtRUC.Text.Trim() : null;
            _pedido.Razon_Social = comprobante.Requiere_RUC ? txtRazonSocial.Text.Trim() : null;

            string error = _servicioVenta.Validar(_pedido, comprobante);
            if (error != null)
            {
                MessageBox.Show(error, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 1. Avisar ANTES de cobrar si algún insumo de la receta no alcanza
                List<ENTIDAD_CONSUMO_INSUMO> faltantes = _servicioVenta.Insumos_Faltantes(_pedido);
                if (faltantes.Count > 0)
                {
                    string detalle = string.Join("\n", faltantes.Select(f =>
                        "• " + f.Nom_Insumo + ": necesita " + f.Cantidad_Requerida.ToString("0.###") + " " + f.Unidad +
                        ", hay " + f.Stock_Actual.ToString("0.###")));
                    MessageBox.Show("No hay stock suficiente para este pedido:\n\n" + detalle, "Stock insuficiente",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Pedido + Detalle + Venta + Detalle_Venta + Inventario en una sola transacción
                ENTIDAD_RESULTADO_VENTA resultado = _servicioVenta.Cobrar(_pedido, comprobante);

                // 3. Comprobante imprimible
                _lineasComprobante = Armar_Comprobante(resultado, comprobante);
                MessageBox.Show("Venta registrada: " + resultado.ID_Venta + "\nPedido " + resultado.ID_Pedido + " enviado a cocina.",
                                "Cobro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Mostrar_Comprobante();

                Nuevo_Pedido();
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

        private List<string> Armar_Comprobante(ENTIDAD_RESULTADO_VENTA resultado, IComprobante comprobante)
        {
            string separador = new string('-', 42);
            List<string> lineas = new List<string>
            {
                "SPYC:I - " + _usuario.Nom_Sede,
                comprobante.Tipo.ToUpper(),
                "Pedido: " + resultado.ID_Pedido + "    Venta: " + resultado.ID_Venta,
                "Fecha: " + resultado.Fecha.ToString("dd/MM/yyyy HH:mm"),
                "Tipo: " + _pedido.Tipo_Pedido
            };
            lineas.AddRange(comprobante.Lineas_Cliente(_pedido));
            lineas.Add(separador);

            foreach (ENTIDAD_LINEA_PEDIDO linea in _pedido.Lineas)
            {
                string descripcion = linea.Cantidad + " x " + linea.Producto.Nom_Plato;
                lineas.Add(descripcion.PadRight(32) + linea.Total.ToString("N2").PadLeft(10));
                if (linea.Descuento_Unitario > 0)
                    lineas.Add("   " + linea.Descuento_Aplicado + ": -" + (linea.Descuento_Unitario * linea.Cantidad).ToString("N2"));
            }

            lineas.Add(separador);
            if (resultado.Resumen.Descuento > 0)
                lineas.Add("Descuento: S/ " + resultado.Resumen.Descuento.ToString("N2"));
            lineas.AddRange(comprobante.Lineas_Totales(resultado.Resumen));
            lineas.Add("Pago: " + cboMetodoPago.Text);
            lineas.Add("");
            lineas.Add("¡Gracias por su compra!");
            return lineas;
        }

        // Vista previa de impresión; si la PC no tiene impresora instalada se muestra el texto en pantalla
        private void Mostrar_Comprobante()
        {
            if (PrinterSettings.InstalledPrinters.Count > 0)
                printPreviewComprobante.ShowDialog(this);
            else
                MessageBox.Show(string.Join("\n", _lineasComprobante), "Comprobante (sin impresora instalada)",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void printDocumento_PrintPage(object sender, PrintPageEventArgs e)
        {
            using (Font fuente = new Font("Consolas", 10F))
            {
                float x = e.MarginBounds.Left;
                float y = e.MarginBounds.Top;
                e.Graphics.DrawImage(Properties.Resources.logo_spyci, x, y, 80, 80);
                y += 90;

                foreach (string linea in _lineasComprobante)
                {
                    e.Graphics.DrawString(linea, fuente, Brushes.Black, x, y);
                    y += fuente.GetHeight(e.Graphics) + 2;
                }
            }
            e.HasMorePages = false;
        }
    }
}
