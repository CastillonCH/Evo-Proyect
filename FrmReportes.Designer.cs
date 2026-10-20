namespace RESTAURANTEFINAL
{
    partial class FrmReportes
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.tlpGraficos = new System.Windows.Forms.TableLayoutPanel();
            this.chartVentasSede = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartPlatos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartHoras = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartPromociones = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grpTopClientes = new System.Windows.Forms.GroupBox();
            this.dgvTopClientes = new System.Windows.Forms.DataGridView();
            this.tlpKpis = new System.Windows.Forms.TableLayoutPanel();
            this.pnlKpiVentas = new System.Windows.Forms.Panel();
            this.lblKpiVentas = new System.Windows.Forms.Label();
            this.lblKpiVentasTitulo = new System.Windows.Forms.Label();
            this.pnlKpiVentasBorde = new System.Windows.Forms.Panel();
            this.pnlKpiPedidos = new System.Windows.Forms.Panel();
            this.lblKpiPedidos = new System.Windows.Forms.Label();
            this.lblKpiPedidosTitulo = new System.Windows.Forms.Label();
            this.pnlKpiPedidosBorde = new System.Windows.Forms.Panel();
            this.pnlKpiTicket = new System.Windows.Forms.Panel();
            this.lblKpiTicket = new System.Windows.Forms.Label();
            this.lblKpiTicketTitulo = new System.Windows.Forms.Label();
            this.pnlKpiTicketBorde = new System.Windows.Forms.Panel();
            this.pnlKpiStock = new System.Windows.Forms.Panel();
            this.lblKpiStock = new System.Windows.Forms.Label();
            this.lblKpiStockTitulo = new System.Windows.Forms.Label();
            this.pnlKpiStockBorde = new System.Windows.Forms.Panel();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.lblSede = new System.Windows.Forms.Label();
            this.cboSede = new System.Windows.Forms.ComboBox();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.btnHoy = new System.Windows.Forms.Button();
            this.btnHistorico = new System.Windows.Forms.Button();
            this.tlpGraficos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentasSede)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPlatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartHoras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPromociones)).BeginInit();
            this.grpTopClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopClientes)).BeginInit();
            this.tlpKpis.SuspendLayout();
            this.pnlKpiVentas.SuspendLayout();
            this.pnlKpiVentasBorde.SuspendLayout();
            this.pnlKpiPedidos.SuspendLayout();
            this.pnlKpiPedidosBorde.SuspendLayout();
            this.pnlKpiTicket.SuspendLayout();
            this.pnlKpiTicketBorde.SuspendLayout();
            this.pnlKpiStock.SuspendLayout();
            this.pnlKpiStockBorde.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpGraficos
            // 
            this.tlpGraficos.Controls.Add(this.chartVentasSede, 0, 0);
            this.tlpGraficos.Controls.Add(this.chartPlatos, 1, 0);
            this.tlpGraficos.Controls.Add(this.chartHoras, 2, 0);
            this.tlpGraficos.Controls.Add(this.chartPromociones, 0, 1);
            this.tlpGraficos.Controls.Add(this.grpTopClientes, 1, 1);
            this.tlpGraficos.ColumnCount = 3;
            this.tlpGraficos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpGraficos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpGraficos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpGraficos.RowCount = 2;
            this.tlpGraficos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0F));
            this.tlpGraficos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0F));
            this.tlpGraficos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpGraficos.Location = new System.Drawing.Point(0, 0);
            this.tlpGraficos.Name = "tlpGraficos";
            this.tlpGraficos.Padding = new System.Windows.Forms.Padding(6);
            this.tlpGraficos.Size = new System.Drawing.Size(1050, 538);
            this.tlpGraficos.TabIndex = 2;
            // 
            // chartVentasSede
            // 
            chartArea1.Name = "ChartArea1";
            this.chartVentasSede.ChartAreas.Add(chartArea1);
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            series1.IsValueShownAsLabel = true;
            series1.Name = "Serie1";
            this.chartVentasSede.Series.Add(series1);
            title1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Ventas por sede (S/)";
            this.chartVentasSede.Titles.Add(title1);
            this.chartVentasSede.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartVentasSede.Location = new System.Drawing.Point(0, 0);
            this.chartVentasSede.Margin = new System.Windows.Forms.Padding(6);
            this.chartVentasSede.Name = "chartVentasSede";
            this.chartVentasSede.Size = new System.Drawing.Size(330, 250);
            this.chartVentasSede.TabIndex = 0;
            // 
            // chartPlatos
            // 
            chartArea2.Name = "ChartArea1";
            this.chartPlatos.ChartAreas.Add(chartArea2);
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            series2.IsValueShownAsLabel = true;
            series2.Name = "Serie1";
            this.chartPlatos.Series.Add(series2);
            title2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Title1";
            title2.Text = "Platos más pedidos";
            this.chartPlatos.Titles.Add(title2);
            this.chartPlatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartPlatos.Location = new System.Drawing.Point(0, 0);
            this.chartPlatos.Margin = new System.Windows.Forms.Padding(6);
            this.chartPlatos.Name = "chartPlatos";
            this.chartPlatos.Size = new System.Drawing.Size(330, 250);
            this.chartPlatos.TabIndex = 0;
            // 
            // chartHoras
            // 
            chartArea3.Name = "ChartArea1";
            this.chartHoras.ChartAreas.Add(chartArea3);
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            series3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            series3.IsValueShownAsLabel = true;
            series3.Name = "Serie1";
            this.chartHoras.Series.Add(series3);
            title3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title3.Name = "Title1";
            title3.Text = "Pedidos por hora (horas pico)";
            this.chartHoras.Titles.Add(title3);
            this.chartHoras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartHoras.Location = new System.Drawing.Point(0, 0);
            this.chartHoras.Margin = new System.Windows.Forms.Padding(6);
            this.chartHoras.Name = "chartHoras";
            this.chartHoras.Size = new System.Drawing.Size(330, 250);
            this.chartHoras.TabIndex = 0;
            // 
            // chartPromociones
            // 
            chartArea4.Name = "ChartArea1";
            this.chartPromociones.ChartAreas.Add(chartArea4);
            legend4.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend4.Name = "Legend1";
            this.chartPromociones.Legends.Add(legend4);
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series4.IsValueShownAsLabel = true;
            series4.Legend = "Legend1";
            series4.Name = "Serie1";
            this.chartPromociones.Series.Add(series4);
            title4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title4.Name = "Title1";
            title4.Text = "Efectividad de promociones (S/)";
            this.chartPromociones.Titles.Add(title4);
            this.chartPromociones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartPromociones.Location = new System.Drawing.Point(0, 0);
            this.chartPromociones.Margin = new System.Windows.Forms.Padding(6);
            this.chartPromociones.Name = "chartPromociones";
            this.chartPromociones.Size = new System.Drawing.Size(330, 250);
            this.chartPromociones.TabIndex = 0;
            // 
            // grpTopClientes
            // 
            this.grpTopClientes.Controls.Add(this.dgvTopClientes);
            this.tlpGraficos.SetColumnSpan(this.grpTopClientes, 2);
            this.grpTopClientes.BackColor = System.Drawing.Color.White;
            this.grpTopClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTopClientes.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTopClientes.Margin = new System.Windows.Forms.Padding(6);
            this.grpTopClientes.Name = "grpTopClientes";
            this.grpTopClientes.Size = new System.Drawing.Size(670, 250);
            this.grpTopClientes.TabIndex = 4;
            this.grpTopClientes.TabStop = false;
            this.grpTopClientes.Text = "Top clientes VIP";
            // 
            // dgvTopClientes
            // 
            this.dgvTopClientes.AllowUserToAddRows = false;
            this.dgvTopClientes.AllowUserToDeleteRows = false;
            this.dgvTopClientes.BackgroundColor = System.Drawing.Color.White;
            this.dgvTopClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTopClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTopClientes.Location = new System.Drawing.Point(3, 23);
            this.dgvTopClientes.Name = "dgvTopClientes";
            this.dgvTopClientes.ReadOnly = true;
            this.dgvTopClientes.RowHeadersVisible = false;
            this.dgvTopClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTopClientes.Size = new System.Drawing.Size(664, 224);
            this.dgvTopClientes.TabIndex = 0;
            // 
            // tlpKpis
            // 
            this.tlpKpis.Controls.Add(this.pnlKpiVentas, 0, 0);
            this.tlpKpis.Controls.Add(this.pnlKpiPedidos, 1, 0);
            this.tlpKpis.Controls.Add(this.pnlKpiTicket, 2, 0);
            this.tlpKpis.Controls.Add(this.pnlKpiStock, 3, 0);
            this.tlpKpis.ColumnCount = 4;
            this.tlpKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0F));
            this.tlpKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0F));
            this.tlpKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0F));
            this.tlpKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0F));
            this.tlpKpis.RowCount = 1;
            this.tlpKpis.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0F));
            this.tlpKpis.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpKpis.Location = new System.Drawing.Point(0, 0);
            this.tlpKpis.Name = "tlpKpis";
            this.tlpKpis.Padding = new System.Windows.Forms.Padding(6);
            this.tlpKpis.Size = new System.Drawing.Size(1050, 100);
            this.tlpKpis.TabIndex = 1;
            // 
            // pnlKpiVentas
            // 
            this.pnlKpiVentas.Controls.Add(this.lblKpiVentas);
            this.pnlKpiVentas.Controls.Add(this.lblKpiVentasTitulo);
            this.pnlKpiVentas.Controls.Add(this.pnlKpiVentasBorde);
            this.pnlKpiVentas.BackColor = System.Drawing.Color.White;
            this.pnlKpiVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpiVentas.Margin = new System.Windows.Forms.Padding(6);
            this.pnlKpiVentas.Name = "pnlKpiVentas";
            this.pnlKpiVentas.Size = new System.Drawing.Size(250, 80);
            this.pnlKpiVentas.TabIndex = 0;
            // 
            // lblKpiVentas
            // 
            this.lblKpiVentas.AutoSize = false;
            this.lblKpiVentas.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKpiVentas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lblKpiVentas.Location = new System.Drawing.Point(6, 28);
            this.lblKpiVentas.Name = "lblKpiVentas";
            this.lblKpiVentas.Size = new System.Drawing.Size(244, 52);
            this.lblKpiVentas.Text = "0";
            this.lblKpiVentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblKpiVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKpiVentas.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            // 
            // lblKpiVentasTitulo
            // 
            this.lblKpiVentasTitulo.AutoSize = false;
            this.lblKpiVentasTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKpiVentasTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.lblKpiVentasTitulo.Location = new System.Drawing.Point(6, 0);
            this.lblKpiVentasTitulo.Name = "lblKpiVentasTitulo";
            this.lblKpiVentasTitulo.Size = new System.Drawing.Size(244, 28);
            this.lblKpiVentasTitulo.Text = "Ventas (S/)";
            this.lblKpiVentasTitulo.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblKpiVentasTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpiVentasTitulo.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            // 
            // pnlKpiVentasBorde
            // 
            this.pnlKpiVentasBorde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.pnlKpiVentasBorde.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlKpiVentasBorde.Location = new System.Drawing.Point(0, 0);
            this.pnlKpiVentasBorde.Name = "pnlKpiVentasBorde";
            this.pnlKpiVentasBorde.Size = new System.Drawing.Size(6, 80);
            this.pnlKpiVentasBorde.TabIndex = 0;
            // 
            // pnlKpiPedidos
            // 
            this.pnlKpiPedidos.Controls.Add(this.lblKpiPedidos);
            this.pnlKpiPedidos.Controls.Add(this.lblKpiPedidosTitulo);
            this.pnlKpiPedidos.Controls.Add(this.pnlKpiPedidosBorde);
            this.pnlKpiPedidos.BackColor = System.Drawing.Color.White;
            this.pnlKpiPedidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpiPedidos.Margin = new System.Windows.Forms.Padding(6);
            this.pnlKpiPedidos.Name = "pnlKpiPedidos";
            this.pnlKpiPedidos.Size = new System.Drawing.Size(250, 80);
            this.pnlKpiPedidos.TabIndex = 0;
            // 
            // lblKpiPedidos
            // 
            this.lblKpiPedidos.AutoSize = false;
            this.lblKpiPedidos.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKpiPedidos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lblKpiPedidos.Location = new System.Drawing.Point(6, 28);
            this.lblKpiPedidos.Name = "lblKpiPedidos";
            this.lblKpiPedidos.Size = new System.Drawing.Size(244, 52);
            this.lblKpiPedidos.Text = "0";
            this.lblKpiPedidos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblKpiPedidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKpiPedidos.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            // 
            // lblKpiPedidosTitulo
            // 
            this.lblKpiPedidosTitulo.AutoSize = false;
            this.lblKpiPedidosTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKpiPedidosTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.lblKpiPedidosTitulo.Location = new System.Drawing.Point(6, 0);
            this.lblKpiPedidosTitulo.Name = "lblKpiPedidosTitulo";
            this.lblKpiPedidosTitulo.Size = new System.Drawing.Size(244, 28);
            this.lblKpiPedidosTitulo.Text = "N.º de pedidos";
            this.lblKpiPedidosTitulo.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblKpiPedidosTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpiPedidosTitulo.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            // 
            // pnlKpiPedidosBorde
            // 
            this.pnlKpiPedidosBorde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.pnlKpiPedidosBorde.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlKpiPedidosBorde.Location = new System.Drawing.Point(0, 0);
            this.pnlKpiPedidosBorde.Name = "pnlKpiPedidosBorde";
            this.pnlKpiPedidosBorde.Size = new System.Drawing.Size(6, 80);
            this.pnlKpiPedidosBorde.TabIndex = 0;
            // 
            // pnlKpiTicket
            // 
            this.pnlKpiTicket.Controls.Add(this.lblKpiTicket);
            this.pnlKpiTicket.Controls.Add(this.lblKpiTicketTitulo);
            this.pnlKpiTicket.Controls.Add(this.pnlKpiTicketBorde);
            this.pnlKpiTicket.BackColor = System.Drawing.Color.White;
            this.pnlKpiTicket.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpiTicket.Margin = new System.Windows.Forms.Padding(6);
            this.pnlKpiTicket.Name = "pnlKpiTicket";
            this.pnlKpiTicket.Size = new System.Drawing.Size(250, 80);
            this.pnlKpiTicket.TabIndex = 0;
            // 
            // lblKpiTicket
            // 
            this.lblKpiTicket.AutoSize = false;
            this.lblKpiTicket.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKpiTicket.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lblKpiTicket.Location = new System.Drawing.Point(6, 28);
            this.lblKpiTicket.Name = "lblKpiTicket";
            this.lblKpiTicket.Size = new System.Drawing.Size(244, 52);
            this.lblKpiTicket.Text = "0";
            this.lblKpiTicket.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblKpiTicket.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKpiTicket.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            // 
            // lblKpiTicketTitulo
            // 
            this.lblKpiTicketTitulo.AutoSize = false;
            this.lblKpiTicketTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKpiTicketTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.lblKpiTicketTitulo.Location = new System.Drawing.Point(6, 0);
            this.lblKpiTicketTitulo.Name = "lblKpiTicketTitulo";
            this.lblKpiTicketTitulo.Size = new System.Drawing.Size(244, 28);
            this.lblKpiTicketTitulo.Text = "Ticket promedio (S/)";
            this.lblKpiTicketTitulo.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblKpiTicketTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpiTicketTitulo.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            // 
            // pnlKpiTicketBorde
            // 
            this.pnlKpiTicketBorde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.pnlKpiTicketBorde.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlKpiTicketBorde.Location = new System.Drawing.Point(0, 0);
            this.pnlKpiTicketBorde.Name = "pnlKpiTicketBorde";
            this.pnlKpiTicketBorde.Size = new System.Drawing.Size(6, 80);
            this.pnlKpiTicketBorde.TabIndex = 0;
            // 
            // pnlKpiStock
            // 
            this.pnlKpiStock.Controls.Add(this.lblKpiStock);
            this.pnlKpiStock.Controls.Add(this.lblKpiStockTitulo);
            this.pnlKpiStock.Controls.Add(this.pnlKpiStockBorde);
            this.pnlKpiStock.BackColor = System.Drawing.Color.White;
            this.pnlKpiStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpiStock.Margin = new System.Windows.Forms.Padding(6);
            this.pnlKpiStock.Name = "pnlKpiStock";
            this.pnlKpiStock.Size = new System.Drawing.Size(250, 80);
            this.pnlKpiStock.TabIndex = 0;
            // 
            // lblKpiStock
            // 
            this.lblKpiStock.AutoSize = false;
            this.lblKpiStock.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKpiStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lblKpiStock.Location = new System.Drawing.Point(6, 28);
            this.lblKpiStock.Name = "lblKpiStock";
            this.lblKpiStock.Size = new System.Drawing.Size(244, 52);
            this.lblKpiStock.Text = "0";
            this.lblKpiStock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblKpiStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKpiStock.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            // 
            // lblKpiStockTitulo
            // 
            this.lblKpiStockTitulo.AutoSize = false;
            this.lblKpiStockTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKpiStockTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.lblKpiStockTitulo.Location = new System.Drawing.Point(6, 0);
            this.lblKpiStockTitulo.Name = "lblKpiStockTitulo";
            this.lblKpiStockTitulo.Size = new System.Drawing.Size(244, 28);
            this.lblKpiStockTitulo.Text = "Insumos bajo el mínimo";
            this.lblKpiStockTitulo.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblKpiStockTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpiStockTitulo.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            // 
            // pnlKpiStockBorde
            // 
            this.pnlKpiStockBorde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.pnlKpiStockBorde.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlKpiStockBorde.Location = new System.Drawing.Point(0, 0);
            this.pnlKpiStockBorde.Name = "pnlKpiStockBorde";
            this.pnlKpiStockBorde.Size = new System.Drawing.Size(6, 80);
            this.pnlKpiStockBorde.TabIndex = 0;
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.Controls.Add(this.lblSede);
            this.pnlFiltros.Controls.Add(this.cboSede);
            this.pnlFiltros.Controls.Add(this.lblDesde);
            this.pnlFiltros.Controls.Add(this.dtpDesde);
            this.pnlFiltros.Controls.Add(this.lblHasta);
            this.pnlFiltros.Controls.Add(this.dtpHasta);
            this.pnlFiltros.Controls.Add(this.btnAplicar);
            this.pnlFiltros.Controls.Add(this.btnHoy);
            this.pnlFiltros.Controls.Add(this.btnHistorico);
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
            this.cboSede.Size = new System.Drawing.Size(180, 31);
            this.cboSede.TabIndex = 0;
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesde.Location = new System.Drawing.Point(254, 15);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Text = "Desde";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(306, 11);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(120, 30);
            this.dtpDesde.TabIndex = 1;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHasta.Location = new System.Drawing.Point(440, 15);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Text = "Hasta";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(490, 11);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(120, 30);
            this.dtpHasta.TabIndex = 2;
            // 
            // btnAplicar
            // 
            this.btnAplicar.FlatAppearance.BorderSize = 0;
            this.btnAplicar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.btnAplicar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAplicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAplicar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.btnAplicar.Location = new System.Drawing.Point(626, 10);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(100, 32);
            this.btnAplicar.TabIndex = 3;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = false;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // btnHoy
            // 
            this.btnHoy.FlatAppearance.BorderSize = 0;
            this.btnHoy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btnHoy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHoy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHoy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoy.ForeColor = System.Drawing.Color.White;
            this.btnHoy.Location = new System.Drawing.Point(734, 10);
            this.btnHoy.Name = "btnHoy";
            this.btnHoy.Size = new System.Drawing.Size(70, 32);
            this.btnHoy.TabIndex = 4;
            this.btnHoy.Text = "Hoy";
            this.btnHoy.UseVisualStyleBackColor = false;
            this.btnHoy.Click += new System.EventHandler(this.btnHoy_Click);
            // 
            // btnHistorico
            // 
            this.btnHistorico.FlatAppearance.BorderSize = 0;
            this.btnHistorico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btnHistorico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHistorico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistorico.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistorico.ForeColor = System.Drawing.Color.White;
            this.btnHistorico.Location = new System.Drawing.Point(812, 10);
            this.btnHistorico.Name = "btnHistorico";
            this.btnHistorico.Size = new System.Drawing.Size(150, 32);
            this.btnHistorico.TabIndex = 5;
            this.btnHistorico.Text = "Todo el histórico";
            this.btnHistorico.UseVisualStyleBackColor = false;
            this.btnHistorico.Click += new System.EventHandler(this.btnHistorico_Click);
            // 
            // FrmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1050, 690);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmReportes";
            this.Text = "Reportes";
            this.Controls.Add(this.tlpGraficos);
            this.Controls.Add(this.tlpKpis);
            this.Controls.Add(this.pnlFiltros);
            this.Load += new System.EventHandler(this.FrmReportes_Load);
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.pnlKpiStockBorde.ResumeLayout(false);
            this.pnlKpiStockBorde.PerformLayout();
            this.pnlKpiStock.ResumeLayout(false);
            this.pnlKpiStock.PerformLayout();
            this.pnlKpiTicketBorde.ResumeLayout(false);
            this.pnlKpiTicketBorde.PerformLayout();
            this.pnlKpiTicket.ResumeLayout(false);
            this.pnlKpiTicket.PerformLayout();
            this.pnlKpiPedidosBorde.ResumeLayout(false);
            this.pnlKpiPedidosBorde.PerformLayout();
            this.pnlKpiPedidos.ResumeLayout(false);
            this.pnlKpiPedidos.PerformLayout();
            this.pnlKpiVentasBorde.ResumeLayout(false);
            this.pnlKpiVentasBorde.PerformLayout();
            this.pnlKpiVentas.ResumeLayout(false);
            this.pnlKpiVentas.PerformLayout();
            this.tlpKpis.ResumeLayout(false);
            this.tlpKpis.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopClientes)).EndInit();
            this.grpTopClientes.ResumeLayout(false);
            this.grpTopClientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPromociones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartHoras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPlatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentasSede)).EndInit();
            this.tlpGraficos.ResumeLayout(false);
            this.tlpGraficos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpGraficos;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVentasSede;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPlatos;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartHoras;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPromociones;
        private System.Windows.Forms.GroupBox grpTopClientes;
        private System.Windows.Forms.DataGridView dgvTopClientes;
        private System.Windows.Forms.TableLayoutPanel tlpKpis;
        private System.Windows.Forms.Panel pnlKpiVentas;
        private System.Windows.Forms.Label lblKpiVentas;
        private System.Windows.Forms.Label lblKpiVentasTitulo;
        private System.Windows.Forms.Panel pnlKpiVentasBorde;
        private System.Windows.Forms.Panel pnlKpiPedidos;
        private System.Windows.Forms.Label lblKpiPedidos;
        private System.Windows.Forms.Label lblKpiPedidosTitulo;
        private System.Windows.Forms.Panel pnlKpiPedidosBorde;
        private System.Windows.Forms.Panel pnlKpiTicket;
        private System.Windows.Forms.Label lblKpiTicket;
        private System.Windows.Forms.Label lblKpiTicketTitulo;
        private System.Windows.Forms.Panel pnlKpiTicketBorde;
        private System.Windows.Forms.Panel pnlKpiStock;
        private System.Windows.Forms.Label lblKpiStock;
        private System.Windows.Forms.Label lblKpiStockTitulo;
        private System.Windows.Forms.Panel pnlKpiStockBorde;
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Label lblSede;
        private System.Windows.Forms.ComboBox cboSede;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Button btnHoy;
        private System.Windows.Forms.Button btnHistorico;
    }
}
