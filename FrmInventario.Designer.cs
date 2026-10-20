namespace RESTAURANTEFINAL
{
    partial class FrmInventario
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
            this.dgvInventario = new System.Windows.Forms.DataGridView();
            this.pnlDerecha = new System.Windows.Forms.Panel();
            this.grpConsumo = new System.Windows.Forms.GroupBox();
            this.lblProductoConsumo = new System.Windows.Forms.Label();
            this.cboProductoConsumo = new System.Windows.Forms.ComboBox();
            this.btnVerConsumo = new System.Windows.Forms.Button();
            this.dgvConsumo = new System.Windows.Forms.DataGridView();
            this.grpAbastecimiento = new System.Windows.Forms.GroupBox();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.cboProveedor = new System.Windows.Forms.ComboBox();
            this.lblInsumo = new System.Windows.Forms.Label();
            this.cboInsumo = new System.Windows.Forms.ComboBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblUnidad = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.nudPrecio = new System.Windows.Forms.NumericUpDown();
            this.btnAgregarItem = new System.Windows.Forms.Button();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.colItemInsumo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblComentario = new System.Windows.Forms.Label();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.btnQuitarItem = new System.Windows.Forms.Button();
            this.btnRegistrarAbastecimiento = new System.Windows.Forms.Button();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.lblSede = new System.Windows.Forms.Label();
            this.cboSede = new System.Windows.Forms.ComboBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.chkSoloBajos = new System.Windows.Forms.CheckBox();
            this.lblResumen = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).BeginInit();
            this.pnlDerecha.SuspendLayout();
            this.grpConsumo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsumo)).BeginInit();
            this.grpAbastecimiento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.pnlFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvInventario
            // 
            this.dgvInventario.AllowUserToAddRows = false;
            this.dgvInventario.AllowUserToDeleteRows = false;
            this.dgvInventario.BackgroundColor = System.Drawing.Color.White;
            this.dgvInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvInventario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInventario.Location = new System.Drawing.Point(0, 52);
            this.dgvInventario.Name = "dgvInventario";
            this.dgvInventario.ReadOnly = true;
            this.dgvInventario.RowHeadersVisible = false;
            this.dgvInventario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventario.Size = new System.Drawing.Size(670, 638);
            this.dgvInventario.TabIndex = 1;
            this.dgvInventario.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvInventario_DataBindingComplete);
            // 
            // pnlDerecha
            // 
            this.pnlDerecha.Controls.Add(this.grpConsumo);
            this.pnlDerecha.Controls.Add(this.grpAbastecimiento);
            this.pnlDerecha.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDerecha.Location = new System.Drawing.Point(670, 52);
            this.pnlDerecha.Name = "pnlDerecha";
            this.pnlDerecha.Padding = new System.Windows.Forms.Padding(8);
            this.pnlDerecha.Size = new System.Drawing.Size(380, 638);
            this.pnlDerecha.TabIndex = 2;
            // 
            // grpConsumo
            // 
            this.grpConsumo.Controls.Add(this.lblProductoConsumo);
            this.grpConsumo.Controls.Add(this.cboProductoConsumo);
            this.grpConsumo.Controls.Add(this.btnVerConsumo);
            this.grpConsumo.Controls.Add(this.dgvConsumo);
            this.grpConsumo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpConsumo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpConsumo.Location = new System.Drawing.Point(8, 376);
            this.grpConsumo.Name = "grpConsumo";
            this.grpConsumo.Size = new System.Drawing.Size(364, 306);
            this.grpConsumo.TabIndex = 1;
            this.grpConsumo.TabStop = false;
            this.grpConsumo.Text = "Consumo por receta";
            // 
            // lblProductoConsumo
            // 
            this.lblProductoConsumo.AutoSize = true;
            this.lblProductoConsumo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductoConsumo.Location = new System.Drawing.Point(10, 30);
            this.lblProductoConsumo.Name = "lblProductoConsumo";
            this.lblProductoConsumo.Text = "Producto";
            // 
            // cboProductoConsumo
            // 
            this.cboProductoConsumo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProductoConsumo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProductoConsumo.FormattingEnabled = true;
            this.cboProductoConsumo.Location = new System.Drawing.Point(84, 26);
            this.cboProductoConsumo.Name = "cboProductoConsumo";
            this.cboProductoConsumo.Size = new System.Drawing.Size(170, 31);
            this.cboProductoConsumo.TabIndex = 0;
            // 
            // btnVerConsumo
            // 
            this.btnVerConsumo.FlatAppearance.BorderSize = 0;
            this.btnVerConsumo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.btnVerConsumo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerConsumo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerConsumo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerConsumo.ForeColor = System.Drawing.Color.White;
            this.btnVerConsumo.Location = new System.Drawing.Point(260, 25);
            this.btnVerConsumo.Name = "btnVerConsumo";
            this.btnVerConsumo.Size = new System.Drawing.Size(94, 32);
            this.btnVerConsumo.TabIndex = 1;
            this.btnVerConsumo.Text = "Ver consumo";
            this.btnVerConsumo.UseVisualStyleBackColor = false;
            this.btnVerConsumo.Click += new System.EventHandler(this.btnVerConsumo_Click);
            // 
            // dgvConsumo
            // 
            this.dgvConsumo.AllowUserToAddRows = false;
            this.dgvConsumo.AllowUserToDeleteRows = false;
            this.dgvConsumo.BackgroundColor = System.Drawing.Color.White;
            this.dgvConsumo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvConsumo.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            this.dgvConsumo.Location = new System.Drawing.Point(10, 64);
            this.dgvConsumo.Name = "dgvConsumo";
            this.dgvConsumo.ReadOnly = true;
            this.dgvConsumo.RowHeadersVisible = false;
            this.dgvConsumo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConsumo.Size = new System.Drawing.Size(344, 230);
            this.dgvConsumo.TabIndex = 2;
            // 
            // grpAbastecimiento
            // 
            this.grpAbastecimiento.Controls.Add(this.lblProveedor);
            this.grpAbastecimiento.Controls.Add(this.cboProveedor);
            this.grpAbastecimiento.Controls.Add(this.lblInsumo);
            this.grpAbastecimiento.Controls.Add(this.cboInsumo);
            this.grpAbastecimiento.Controls.Add(this.lblCantidad);
            this.grpAbastecimiento.Controls.Add(this.nudCantidad);
            this.grpAbastecimiento.Controls.Add(this.lblUnidad);
            this.grpAbastecimiento.Controls.Add(this.lblPrecio);
            this.grpAbastecimiento.Controls.Add(this.nudPrecio);
            this.grpAbastecimiento.Controls.Add(this.btnAgregarItem);
            this.grpAbastecimiento.Controls.Add(this.dgvItems);
            this.grpAbastecimiento.Controls.Add(this.lblComentario);
            this.grpAbastecimiento.Controls.Add(this.txtComentario);
            this.grpAbastecimiento.Controls.Add(this.btnQuitarItem);
            this.grpAbastecimiento.Controls.Add(this.btnRegistrarAbastecimiento);
            this.grpAbastecimiento.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpAbastecimiento.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpAbastecimiento.Location = new System.Drawing.Point(8, 8);
            this.grpAbastecimiento.Name = "grpAbastecimiento";
            this.grpAbastecimiento.Size = new System.Drawing.Size(364, 368);
            this.grpAbastecimiento.TabIndex = 0;
            this.grpAbastecimiento.TabStop = false;
            this.grpAbastecimiento.Text = "Registrar abastecimiento";
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProveedor.Location = new System.Drawing.Point(10, 30);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Text = "Proveedor";
            // 
            // cboProveedor
            // 
            this.cboProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProveedor.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProveedor.FormattingEnabled = true;
            this.cboProveedor.Location = new System.Drawing.Point(104, 26);
            this.cboProveedor.Name = "cboProveedor";
            this.cboProveedor.Size = new System.Drawing.Size(250, 31);
            this.cboProveedor.TabIndex = 0;
            // 
            // lblInsumo
            // 
            this.lblInsumo.AutoSize = true;
            this.lblInsumo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsumo.Location = new System.Drawing.Point(10, 64);
            this.lblInsumo.Name = "lblInsumo";
            this.lblInsumo.Text = "Insumo";
            // 
            // cboInsumo
            // 
            this.cboInsumo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInsumo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboInsumo.FormattingEnabled = true;
            this.cboInsumo.Location = new System.Drawing.Point(104, 60);
            this.cboInsumo.Name = "cboInsumo";
            this.cboInsumo.Size = new System.Drawing.Size(250, 31);
            this.cboInsumo.TabIndex = 1;
            this.cboInsumo.SelectedIndexChanged += new System.EventHandler(this.cboInsumo_SelectedIndexChanged);
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(10, 98);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Text = "Cantidad";
            // 
            // nudCantidad
            // 
            this.nudCantidad.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudCantidad.Location = new System.Drawing.Point(104, 94);
            this.nudCantidad.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(90, 30);
            this.nudCantidad.TabIndex = 2;
            this.nudCantidad.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblUnidad
            // 
            this.lblUnidad.AutoSize = true;
            this.lblUnidad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.lblUnidad.Location = new System.Drawing.Point(200, 98);
            this.lblUnidad.Name = "lblUnidad";
            this.lblUnidad.Text = "";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(10, 132);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Text = "Precio unit.";
            // 
            // nudPrecio
            // 
            this.nudPrecio.DecimalPlaces = 2;
            this.nudPrecio.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudPrecio.Location = new System.Drawing.Point(104, 128);
            this.nudPrecio.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudPrecio.Name = "nudPrecio";
            this.nudPrecio.Size = new System.Drawing.Size(90, 30);
            this.nudPrecio.TabIndex = 3;
            // 
            // btnAgregarItem
            // 
            this.btnAgregarItem.FlatAppearance.BorderSize = 0;
            this.btnAgregarItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btnAgregarItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarItem.ForeColor = System.Drawing.Color.White;
            this.btnAgregarItem.Location = new System.Drawing.Point(254, 126);
            this.btnAgregarItem.Name = "btnAgregarItem";
            this.btnAgregarItem.Size = new System.Drawing.Size(100, 32);
            this.btnAgregarItem.TabIndex = 4;
            this.btnAgregarItem.Text = "Agregar";
            this.btnAgregarItem.UseVisualStyleBackColor = false;
            this.btnAgregarItem.Click += new System.EventHandler(this.btnAgregarItem_Click);
            // 
            // dgvItems
            // 
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colItemInsumo,
            this.colItemCantidad,
            this.colItemPrecio});
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvItems.Location = new System.Drawing.Point(10, 166);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(344, 118);
            this.dgvItems.TabIndex = 5;
            // 
            // colItemInsumo
            // 
            this.colItemInsumo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colItemInsumo.HeaderText = "Insumo";
            this.colItemInsumo.Name = "colItemInsumo";
            this.colItemInsumo.ReadOnly = true;
            // 
            // colItemCantidad
            // 
            this.colItemCantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colItemCantidad.HeaderText = "Cant.";
            this.colItemCantidad.Name = "colItemCantidad";
            this.colItemCantidad.ReadOnly = true;
            this.colItemCantidad.Width = 60;
            // 
            // colItemPrecio
            // 
            this.colItemPrecio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colItemPrecio.HeaderText = "P. unit.";
            this.colItemPrecio.Name = "colItemPrecio";
            this.colItemPrecio.ReadOnly = true;
            this.colItemPrecio.Width = 72;
            // 
            // lblComentario
            // 
            this.lblComentario.AutoSize = true;
            this.lblComentario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComentario.Location = new System.Drawing.Point(10, 294);
            this.lblComentario.Name = "lblComentario";
            this.lblComentario.Text = "Comentario";
            // 
            // txtComentario
            // 
            this.txtComentario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComentario.Location = new System.Drawing.Point(104, 290);
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(250, 30);
            this.txtComentario.TabIndex = 6;
            this.txtComentario.MaxLength = 100;
            // 
            // btnQuitarItem
            // 
            this.btnQuitarItem.FlatAppearance.BorderSize = 0;
            this.btnQuitarItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btnQuitarItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitarItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitarItem.ForeColor = System.Drawing.Color.White;
            this.btnQuitarItem.Location = new System.Drawing.Point(10, 326);
            this.btnQuitarItem.Name = "btnQuitarItem";
            this.btnQuitarItem.Size = new System.Drawing.Size(100, 34);
            this.btnQuitarItem.TabIndex = 7;
            this.btnQuitarItem.Text = "Quitar";
            this.btnQuitarItem.UseVisualStyleBackColor = false;
            this.btnQuitarItem.Click += new System.EventHandler(this.btnQuitarItem_Click);
            // 
            // btnRegistrarAbastecimiento
            // 
            this.btnRegistrarAbastecimiento.FlatAppearance.BorderSize = 0;
            this.btnRegistrarAbastecimiento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.btnRegistrarAbastecimiento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrarAbastecimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarAbastecimiento.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarAbastecimiento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.btnRegistrarAbastecimiento.Location = new System.Drawing.Point(154, 326);
            this.btnRegistrarAbastecimiento.Name = "btnRegistrarAbastecimiento";
            this.btnRegistrarAbastecimiento.Size = new System.Drawing.Size(200, 34);
            this.btnRegistrarAbastecimiento.TabIndex = 8;
            this.btnRegistrarAbastecimiento.Text = "Registrar ingreso";
            this.btnRegistrarAbastecimiento.UseVisualStyleBackColor = false;
            this.btnRegistrarAbastecimiento.Click += new System.EventHandler(this.btnRegistrarAbastecimiento_Click);
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.Controls.Add(this.lblSede);
            this.pnlFiltros.Controls.Add(this.cboSede);
            this.pnlFiltros.Controls.Add(this.lblBuscar);
            this.pnlFiltros.Controls.Add(this.txtBuscar);
            this.pnlFiltros.Controls.Add(this.chkSoloBajos);
            this.pnlFiltros.Controls.Add(this.lblResumen);
            this.pnlFiltros.BackColor = System.Drawing.Color.White;
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltros.Location = new System.Drawing.Point(0, 0);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(1050, 52);
            this.pnlFiltros.TabIndex = 0;
            // 
            // lblSede
            // 
            this.lblSede.AutoSize = true;
            this.lblSede.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSede.Location = new System.Drawing.Point(12, 15);
            this.lblSede.Name = "lblSede";
            this.lblSede.Text = "Sede";
            // 
            // cboSede
            // 
            this.cboSede.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSede.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSede.FormattingEnabled = true;
            this.cboSede.Location = new System.Drawing.Point(58, 11);
            this.cboSede.Name = "cboSede";
            this.cboSede.Size = new System.Drawing.Size(190, 31);
            this.cboSede.TabIndex = 0;
            this.cboSede.SelectedIndexChanged += new System.EventHandler(this.cboSede_SelectedIndexChanged);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.Location = new System.Drawing.Point(266, 15);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Text = "Buscar";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(324, 11);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(190, 30);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // chkSoloBajos
            // 
            this.chkSoloBajos.AutoSize = true;
            this.chkSoloBajos.Location = new System.Drawing.Point(530, 14);
            this.chkSoloBajos.Name = "chkSoloBajos";
            this.chkSoloBajos.Text = "Solo bajo mínimo";
            this.chkSoloBajos.TabIndex = 2;
            this.chkSoloBajos.UseVisualStyleBackColor = true;
            this.chkSoloBajos.CheckedChanged += new System.EventHandler(this.chkSoloBajos_CheckedChanged);
            // 
            // lblResumen
            // 
            this.lblResumen.AutoSize = true;
            this.lblResumen.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResumen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.lblResumen.Location = new System.Drawing.Point(690, 15);
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Text = "";
            // 
            // FrmInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1050, 690);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmInventario";
            this.Text = "Inventario";
            this.Controls.Add(this.dgvInventario);
            this.Controls.Add(this.pnlDerecha);
            this.Controls.Add(this.pnlFiltros);
            this.Load += new System.EventHandler(this.FrmInventario_Load);
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            this.grpAbastecimiento.ResumeLayout(false);
            this.grpAbastecimiento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsumo)).EndInit();
            this.grpConsumo.ResumeLayout(false);
            this.grpConsumo.PerformLayout();
            this.pnlDerecha.ResumeLayout(false);
            this.pnlDerecha.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInventario;
        private System.Windows.Forms.Panel pnlDerecha;
        private System.Windows.Forms.GroupBox grpConsumo;
        private System.Windows.Forms.Label lblProductoConsumo;
        private System.Windows.Forms.ComboBox cboProductoConsumo;
        private System.Windows.Forms.Button btnVerConsumo;
        private System.Windows.Forms.DataGridView dgvConsumo;
        private System.Windows.Forms.GroupBox grpAbastecimiento;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.ComboBox cboProveedor;
        private System.Windows.Forms.Label lblInsumo;
        private System.Windows.Forms.ComboBox cboInsumo;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Label lblUnidad;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.NumericUpDown nudPrecio;
        private System.Windows.Forms.Button btnAgregarItem;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemInsumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemPrecio;
        private System.Windows.Forms.Label lblComentario;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.Button btnQuitarItem;
        private System.Windows.Forms.Button btnRegistrarAbastecimiento;
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Label lblSede;
        private System.Windows.Forms.ComboBox cboSede;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.CheckBox chkSoloBajos;
        private System.Windows.Forms.Label lblResumen;
    }
}
