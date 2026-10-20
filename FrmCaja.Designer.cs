namespace RESTAURANTEFINAL
{
    partial class FrmCaja
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlProductos = new System.Windows.Forms.Panel();
            this.flpProductos = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlBuscar = new System.Windows.Forms.Panel();
            this.lblProductos = new System.Windows.Forms.Label();
            this.lblBuscarProducto = new System.Windows.Forms.Label();
            this.txtBuscarProducto = new System.Windows.Forms.TextBox();
            this.pnlCarrito = new System.Windows.Forms.Panel();
            this.dgvCarrito = new System.Windows.Forms.DataGridView();
            this.colProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMenos = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colMas = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colImporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuitar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnlCobro = new System.Windows.Forms.Panel();
            this.lblTipoPedido = new System.Windows.Forms.Label();
            this.cboTipoPedido = new System.Windows.Forms.ComboBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.lblComprobante = new System.Windows.Forms.Label();
            this.cboComprobante = new System.Windows.Forms.ComboBox();
            this.lblMetodoPago = new System.Windows.Forms.Label();
            this.cboMetodoPago = new System.Windows.Forms.ComboBox();
            this.lblRUC = new System.Windows.Forms.Label();
            this.txtRUC = new System.Windows.Forms.TextBox();
            this.lblRazonSocial = new System.Windows.Forms.Label();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.pnlLinea = new System.Windows.Forms.Panel();
            this.lblSubtotalTitulo = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblDescuentoTitulo = new System.Windows.Forms.Label();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.lblTotalTitulo = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnNuevoPedido = new System.Windows.Forms.Button();
            this.btnCobrar = new System.Windows.Forms.Button();
            this.lblPedido = new System.Windows.Forms.Label();
            this.printDocumento = new System.Drawing.Printing.PrintDocument();
            this.printPreviewComprobante = new System.Windows.Forms.PrintPreviewDialog();
            this.pnlProductos.SuspendLayout();
            this.flpProductos.SuspendLayout();
            this.pnlBuscar.SuspendLayout();
            this.pnlCarrito.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).BeginInit();
            this.pnlCobro.SuspendLayout();
            this.pnlLinea.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlProductos
            // 
            this.pnlProductos.Controls.Add(this.flpProductos);
            this.pnlProductos.Controls.Add(this.pnlBuscar);
            this.pnlProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProductos.Location = new System.Drawing.Point(0, 0);
            this.pnlProductos.Name = "pnlProductos";
            this.pnlProductos.Padding = new System.Windows.Forms.Padding(12, 12, 6, 12);
            this.pnlProductos.Size = new System.Drawing.Size(630, 690);
            this.pnlProductos.TabIndex = 0;
            // 
            // flpProductos
            // 
            this.flpProductos.AutoScroll = true;
            this.flpProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpProductos.Location = new System.Drawing.Point(12, 56);
            this.flpProductos.Name = "flpProductos";
            this.flpProductos.Size = new System.Drawing.Size(612, 622);
            this.flpProductos.TabIndex = 1;
            // 
            // pnlBuscar
            // 
            this.pnlBuscar.Controls.Add(this.lblProductos);
            this.pnlBuscar.Controls.Add(this.lblBuscarProducto);
            this.pnlBuscar.Controls.Add(this.txtBuscarProducto);
            this.pnlBuscar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBuscar.Location = new System.Drawing.Point(12, 12);
            this.pnlBuscar.Name = "pnlBuscar";
            this.pnlBuscar.Size = new System.Drawing.Size(612, 44);
            this.pnlBuscar.TabIndex = 0;
            // 
            // lblProductos
            // 
            this.lblProductos.AutoSize = true;
            this.lblProductos.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lblProductos.Location = new System.Drawing.Point(0, 4);
            this.lblProductos.Name = "lblProductos";
            this.lblProductos.Text = "Productos";
            // 
            // lblBuscarProducto
            // 
            this.lblBuscarProducto.AutoSize = true;
            this.lblBuscarProducto.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscarProducto.Location = new System.Drawing.Point(300, 10);
            this.lblBuscarProducto.Name = "lblBuscarProducto";
            this.lblBuscarProducto.Text = "Buscar:";
            this.lblBuscarProducto.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            // 
            // txtBuscarProducto
            // 
            this.txtBuscarProducto.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarProducto.Location = new System.Drawing.Point(362, 6);
            this.txtBuscarProducto.Name = "txtBuscarProducto";
            this.txtBuscarProducto.Size = new System.Drawing.Size(240, 30);
            this.txtBuscarProducto.TabIndex = 0;
            this.txtBuscarProducto.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.txtBuscarProducto.TextChanged += new System.EventHandler(this.txtBuscarProducto_TextChanged);
            // 
            // pnlCarrito
            // 
            this.pnlCarrito.Controls.Add(this.dgvCarrito);
            this.pnlCarrito.Controls.Add(this.pnlCobro);
            this.pnlCarrito.Controls.Add(this.lblPedido);
            this.pnlCarrito.BackColor = System.Drawing.Color.White;
            this.pnlCarrito.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlCarrito.Location = new System.Drawing.Point(630, 0);
            this.pnlCarrito.Name = "pnlCarrito";
            this.pnlCarrito.Padding = new System.Windows.Forms.Padding(12);
            this.pnlCarrito.Size = new System.Drawing.Size(420, 690);
            this.pnlCarrito.TabIndex = 1;
            // 
            // dgvCarrito
            // 
            this.dgvCarrito.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProducto,
            this.colCantidad,
            this.colMenos,
            this.colMas,
            this.colImporte,
            this.colQuitar});
            this.dgvCarrito.AllowUserToAddRows = false;
            this.dgvCarrito.AllowUserToDeleteRows = false;
            this.dgvCarrito.BackgroundColor = System.Drawing.Color.White;
            this.dgvCarrito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCarrito.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCarrito.Location = new System.Drawing.Point(12, 46);
            this.dgvCarrito.Name = "dgvCarrito";
            this.dgvCarrito.ReadOnly = true;
            this.dgvCarrito.RowHeadersVisible = false;
            this.dgvCarrito.RowTemplate.Height = 30;
            this.dgvCarrito.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCarrito.Size = new System.Drawing.Size(396, 240);
            this.dgvCarrito.TabIndex = 1;
            this.dgvCarrito.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCarrito_CellContentClick);
            // 
            // colProducto
            // 
            this.colProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProducto.HeaderText = "Producto";
            this.colProducto.Name = "colProducto";
            this.colProducto.ReadOnly = true;
            // 
            // colCantidad
            // 
            this.colCantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colCantidad.HeaderText = "Cant.";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.ReadOnly = true;
            this.colCantidad.Width = 48;
            // 
            // colMenos
            // 
            this.colMenos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colMenos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colMenos.HeaderText = "";
            this.colMenos.Name = "colMenos";
            this.colMenos.ReadOnly = true;
            this.colMenos.Text = "−";
            this.colMenos.UseColumnTextForButtonValue = true;
            this.colMenos.Width = 34;
            // 
            // colMas
            // 
            this.colMas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colMas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colMas.HeaderText = "";
            this.colMas.Name = "colMas";
            this.colMas.ReadOnly = true;
            this.colMas.Text = "+";
            this.colMas.UseColumnTextForButtonValue = true;
            this.colMas.Width = 34;
            // 
            // colImporte
            // 
            this.colImporte.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colImporte.HeaderText = "Importe";
            this.colImporte.Name = "colImporte";
            this.colImporte.ReadOnly = true;
            this.colImporte.Width = 80;
            // 
            // colQuitar
            // 
            this.colQuitar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colQuitar.HeaderText = "";
            this.colQuitar.Name = "colQuitar";
            this.colQuitar.ReadOnly = true;
            this.colQuitar.Text = "✕";
            this.colQuitar.UseColumnTextForButtonValue = true;
            this.colQuitar.Width = 34;
            // 
            // pnlCobro
            // 
            this.pnlCobro.Controls.Add(this.lblTipoPedido);
            this.pnlCobro.Controls.Add(this.cboTipoPedido);
            this.pnlCobro.Controls.Add(this.lblCliente);
            this.pnlCobro.Controls.Add(this.cboCliente);
            this.pnlCobro.Controls.Add(this.lblComprobante);
            this.pnlCobro.Controls.Add(this.cboComprobante);
            this.pnlCobro.Controls.Add(this.lblMetodoPago);
            this.pnlCobro.Controls.Add(this.cboMetodoPago);
            this.pnlCobro.Controls.Add(this.lblRUC);
            this.pnlCobro.Controls.Add(this.txtRUC);
            this.pnlCobro.Controls.Add(this.lblRazonSocial);
            this.pnlCobro.Controls.Add(this.txtRazonSocial);
            this.pnlCobro.Controls.Add(this.lblObservaciones);
            this.pnlCobro.Controls.Add(this.txtObservaciones);
            this.pnlCobro.Controls.Add(this.pnlLinea);
            this.pnlCobro.Controls.Add(this.lblSubtotalTitulo);
            this.pnlCobro.Controls.Add(this.lblSubtotal);
            this.pnlCobro.Controls.Add(this.lblDescuentoTitulo);
            this.pnlCobro.Controls.Add(this.lblDescuento);
            this.pnlCobro.Controls.Add(this.lblTotalTitulo);
            this.pnlCobro.Controls.Add(this.lblTotal);
            this.pnlCobro.Controls.Add(this.btnNuevoPedido);
            this.pnlCobro.Controls.Add(this.btnCobrar);
            this.pnlCobro.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCobro.Location = new System.Drawing.Point(12, 286);
            this.pnlCobro.Name = "pnlCobro";
            this.pnlCobro.Size = new System.Drawing.Size(396, 392);
            this.pnlCobro.TabIndex = 2;
            // 
            // lblTipoPedido
            // 
            this.lblTipoPedido.AutoSize = true;
            this.lblTipoPedido.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoPedido.Location = new System.Drawing.Point(0, 8);
            this.lblTipoPedido.Name = "lblTipoPedido";
            this.lblTipoPedido.Text = "Tipo de pedido";
            // 
            // cboTipoPedido
            // 
            this.cboTipoPedido.Items.AddRange(new object[] {
            "Comer aquí",
            "Para llevar",
            "Delivery"});
            this.cboTipoPedido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPedido.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoPedido.FormattingEnabled = true;
            this.cboTipoPedido.Location = new System.Drawing.Point(130, 4);
            this.cboTipoPedido.Name = "cboTipoPedido";
            this.cboTipoPedido.Size = new System.Drawing.Size(266, 31);
            this.cboTipoPedido.TabIndex = 0;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(0, 42);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Text = "Cliente";
            // 
            // cboCliente
            // 
            this.cboCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cboCliente.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(130, 38);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(266, 31);
            this.cboCliente.TabIndex = 1;
            this.cboCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCliente.SelectedIndexChanged += new System.EventHandler(this.cboCliente_SelectedIndexChanged);
            // 
            // lblComprobante
            // 
            this.lblComprobante.AutoSize = true;
            this.lblComprobante.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComprobante.Location = new System.Drawing.Point(0, 76);
            this.lblComprobante.Name = "lblComprobante";
            this.lblComprobante.Text = "Comprobante";
            // 
            // cboComprobante
            // 
            this.cboComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboComprobante.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboComprobante.FormattingEnabled = true;
            this.cboComprobante.Location = new System.Drawing.Point(130, 72);
            this.cboComprobante.Name = "cboComprobante";
            this.cboComprobante.Size = new System.Drawing.Size(266, 31);
            this.cboComprobante.TabIndex = 2;
            this.cboComprobante.SelectedIndexChanged += new System.EventHandler(this.cboComprobante_SelectedIndexChanged);
            // 
            // lblMetodoPago
            // 
            this.lblMetodoPago.AutoSize = true;
            this.lblMetodoPago.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMetodoPago.Location = new System.Drawing.Point(0, 110);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.Text = "Método de pago";
            // 
            // cboMetodoPago
            // 
            this.cboMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMetodoPago.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMetodoPago.FormattingEnabled = true;
            this.cboMetodoPago.Location = new System.Drawing.Point(130, 106);
            this.cboMetodoPago.Name = "cboMetodoPago";
            this.cboMetodoPago.Size = new System.Drawing.Size(266, 31);
            this.cboMetodoPago.TabIndex = 3;
            // 
            // lblRUC
            // 
            this.lblRUC.AutoSize = true;
            this.lblRUC.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRUC.Location = new System.Drawing.Point(0, 144);
            this.lblRUC.Name = "lblRUC";
            this.lblRUC.Text = "RUC";
            this.lblRUC.Visible = false;
            // 
            // txtRUC
            // 
            this.txtRUC.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRUC.Location = new System.Drawing.Point(130, 140);
            this.txtRUC.Name = "txtRUC";
            this.txtRUC.Size = new System.Drawing.Size(160, 30);
            this.txtRUC.TabIndex = 4;
            this.txtRUC.MaxLength = 11;
            this.txtRUC.Visible = false;
            // 
            // lblRazonSocial
            // 
            this.lblRazonSocial.AutoSize = true;
            this.lblRazonSocial.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRazonSocial.Location = new System.Drawing.Point(0, 178);
            this.lblRazonSocial.Name = "lblRazonSocial";
            this.lblRazonSocial.Text = "Razón social";
            this.lblRazonSocial.Visible = false;
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(130, 174);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(266, 30);
            this.txtRazonSocial.TabIndex = 5;
            this.txtRazonSocial.MaxLength = 100;
            this.txtRazonSocial.Visible = false;
            // 
            // lblObservaciones
            // 
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObservaciones.Location = new System.Drawing.Point(0, 212);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Text = "Observaciones";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservaciones.Location = new System.Drawing.Point(130, 208);
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(266, 30);
            this.txtObservaciones.TabIndex = 6;
            this.txtObservaciones.MaxLength = 200;
            // 
            // pnlLinea
            // 
            this.pnlLinea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlLinea.Location = new System.Drawing.Point(0, 248);
            this.pnlLinea.Name = "pnlLinea";
            this.pnlLinea.Size = new System.Drawing.Size(396, 1);
            this.pnlLinea.TabIndex = 9;
            // 
            // lblSubtotalTitulo
            // 
            this.lblSubtotalTitulo.AutoSize = true;
            this.lblSubtotalTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotalTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.lblSubtotalTitulo.Location = new System.Drawing.Point(0, 256);
            this.lblSubtotalTitulo.Name = "lblSubtotalTitulo";
            this.lblSubtotalTitulo.Text = "Subtotal";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = false;
            this.lblSubtotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.lblSubtotal.Location = new System.Drawing.Point(246, 256);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(150, 22);
            this.lblSubtotal.Text = "S/ 0.00";
            this.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDescuentoTitulo
            // 
            this.lblDescuentoTitulo.AutoSize = true;
            this.lblDescuentoTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuentoTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(142)))), ((int)(((byte)(60)))));
            this.lblDescuentoTitulo.Location = new System.Drawing.Point(0, 280);
            this.lblDescuentoTitulo.Name = "lblDescuentoTitulo";
            this.lblDescuentoTitulo.Text = "Descuento";
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = false;
            this.lblDescuento.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(142)))), ((int)(((byte)(60)))));
            this.lblDescuento.Location = new System.Drawing.Point(246, 280);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(150, 22);
            this.lblDescuento.Text = "- S/ 0.00";
            this.lblDescuento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalTitulo
            // 
            this.lblTotalTitulo.AutoSize = true;
            this.lblTotalTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lblTotalTitulo.Location = new System.Drawing.Point(0, 308);
            this.lblTotalTitulo.Name = "lblTotalTitulo";
            this.lblTotalTitulo.Text = "TOTAL";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = false;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.lblTotal.Location = new System.Drawing.Point(176, 302);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(220, 40);
            this.lblTotal.Text = "S/ 0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnNuevoPedido
            // 
            this.btnNuevoPedido.FlatAppearance.BorderSize = 0;
            this.btnNuevoPedido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btnNuevoPedido.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevoPedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoPedido.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoPedido.ForeColor = System.Drawing.Color.White;
            this.btnNuevoPedido.Location = new System.Drawing.Point(0, 346);
            this.btnNuevoPedido.Name = "btnNuevoPedido";
            this.btnNuevoPedido.Size = new System.Drawing.Size(124, 46);
            this.btnNuevoPedido.TabIndex = 7;
            this.btnNuevoPedido.Text = "Nuevo pedido";
            this.btnNuevoPedido.UseVisualStyleBackColor = false;
            this.btnNuevoPedido.Click += new System.EventHandler(this.btnNuevoPedido_Click);
            // 
            // btnCobrar
            // 
            this.btnCobrar.FlatAppearance.BorderSize = 0;
            this.btnCobrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.btnCobrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCobrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCobrar.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCobrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.btnCobrar.Location = new System.Drawing.Point(134, 346);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(262, 46);
            this.btnCobrar.TabIndex = 8;
            this.btnCobrar.Text = "COBRAR";
            this.btnCobrar.UseVisualStyleBackColor = false;
            this.btnCobrar.Click += new System.EventHandler(this.btnCobrar_Click);
            // 
            // lblPedido
            // 
            this.lblPedido.AutoSize = false;
            this.lblPedido.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPedido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lblPedido.Location = new System.Drawing.Point(12, 12);
            this.lblPedido.Name = "lblPedido";
            this.lblPedido.Size = new System.Drawing.Size(396, 34);
            this.lblPedido.Text = "Pedido actual";
            this.lblPedido.Dock = System.Windows.Forms.DockStyle.Top;
            // 
            // printDocumento
            // 
            this.printDocumento.DocumentName = "Comprobante SPYC:I";
            this.printDocumento.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocumento_PrintPage);
            // 
            // printPreviewComprobante
            // 
            this.printPreviewComprobante.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewComprobante.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewComprobante.ClientSize = new System.Drawing.Size(500, 700);
            this.printPreviewComprobante.Document = this.printDocumento;
            this.printPreviewComprobante.Enabled = true;
            this.printPreviewComprobante.Name = "printPreviewComprobante";
            this.printPreviewComprobante.Text = "Comprobante";
            this.printPreviewComprobante.Visible = false;
            // 
            // FrmCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1050, 690);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmCaja";
            this.Text = "Caja";
            this.Controls.Add(this.pnlProductos);
            this.Controls.Add(this.pnlCarrito);
            this.Load += new System.EventHandler(this.FrmCaja_Load);
            this.pnlLinea.ResumeLayout(false);
            this.pnlLinea.PerformLayout();
            this.pnlCobro.ResumeLayout(false);
            this.pnlCobro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).EndInit();
            this.pnlCarrito.ResumeLayout(false);
            this.pnlCarrito.PerformLayout();
            this.pnlBuscar.ResumeLayout(false);
            this.pnlBuscar.PerformLayout();
            this.flpProductos.ResumeLayout(false);
            this.flpProductos.PerformLayout();
            this.pnlProductos.ResumeLayout(false);
            this.pnlProductos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlProductos;
        private System.Windows.Forms.FlowLayoutPanel flpProductos;
        private System.Windows.Forms.Panel pnlBuscar;
        private System.Windows.Forms.Label lblProductos;
        private System.Windows.Forms.Label lblBuscarProducto;
        private System.Windows.Forms.TextBox txtBuscarProducto;
        private System.Windows.Forms.Panel pnlCarrito;
        private System.Windows.Forms.DataGridView dgvCarrito;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewButtonColumn colMenos;
        private System.Windows.Forms.DataGridViewButtonColumn colMas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImporte;
        private System.Windows.Forms.DataGridViewButtonColumn colQuitar;
        private System.Windows.Forms.Panel pnlCobro;
        private System.Windows.Forms.Label lblTipoPedido;
        private System.Windows.Forms.ComboBox cboTipoPedido;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.Label lblComprobante;
        private System.Windows.Forms.ComboBox cboComprobante;
        private System.Windows.Forms.Label lblMetodoPago;
        private System.Windows.Forms.ComboBox cboMetodoPago;
        private System.Windows.Forms.Label lblRUC;
        private System.Windows.Forms.TextBox txtRUC;
        private System.Windows.Forms.Label lblRazonSocial;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Panel pnlLinea;
        private System.Windows.Forms.Label lblSubtotalTitulo;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblDescuentoTitulo;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.Label lblTotalTitulo;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnNuevoPedido;
        private System.Windows.Forms.Button btnCobrar;
        private System.Windows.Forms.Label lblPedido;
        private System.Drawing.Printing.PrintDocument printDocumento;
        private System.Windows.Forms.PrintPreviewDialog printPreviewComprobante;
    }
}
