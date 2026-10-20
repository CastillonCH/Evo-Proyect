using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using NEGOCIO;

namespace RESTAURANTEFINAL
{
    // KPIs y gráficos para el gerente, con filtro por sede y rango de fechas
    public partial class FrmReportes : Form
    {
        private readonly IReporteRepositorio _reportes;
        private readonly ServicioInventario _inventario;

        // SOLID: DIP – los reportes llegan por IReporteRepositorio (SPs basados en las vistas)
        public FrmReportes(IReporteRepositorio reportes, ServicioInventario inventario)
        {
            InitializeComponent();
            _reportes = reportes;
            _inventario = inventario;
            Estilo.Grid(dgvTopClientes);
        }

        private void FrmReportes_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable sedes = _reportes.Cargar_Sedes();
                DataRow todas = sedes.NewRow();
                todas["ID_Sede"] = "";
                todas["Nom_Sede"] = "Todas las sedes";
                sedes.Rows.InsertAt(todas, 0);
                cboSede.DataSource = sedes;
                cboSede.DisplayMember = "Nom_Sede";
                cboSede.ValueMember = "ID_Sede";

                dtpDesde.Value = DateTime.Today;
                dtpHasta.Value = DateTime.Today;
                Cargar_Reportes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los reportes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            Cargar_Reportes();
        }

        private void btnHoy_Click(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today;
            Cargar_Reportes();
        }

        private void btnHistorico_Click(object sender, EventArgs e)
        {
            dtpDesde.Value = new DateTime(2024, 1, 1);
            dtpHasta.Value = DateTime.Today;
            Cargar_Reportes();
        }

        private void Cargar_Reportes()
        {
            if (dtpDesde.Value.Date > dtpHasta.Value.Date)
            {
                MessageBox.Show("La fecha 'Desde' no puede ser mayor que 'Hasta'.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sede = cboSede.SelectedValue as string;
            string idSede = string.IsNullOrEmpty(sede) ? null : sede;
            DateTime desde = dtpDesde.Value.Date;
            DateTime hasta = dtpHasta.Value.Date;

            try
            {
                // KPIs
                DataRow kpi = _reportes.KPIs(idSede, desde, hasta).Rows[0];
                lblKpiVentas.Text = "S/ " + Convert.ToDecimal(kpi["Total_Ventas"]).ToString("N2");
                lblKpiPedidos.Text = kpi["Num_Pedidos"].ToString();
                lblKpiTicket.Text = "S/ " + Convert.ToDecimal(kpi["Ticket_Promedio"]).ToString("N2");
                lblKpiStock.Text = _inventario.Contar_Stock_Bajo(idSede).ToString();

                // Gráficos (cada uno viene de un SP basado en una vista existente)
                Llenar_Grafico(chartVentasSede, _reportes.Ventas_Por_Sede(desde, hasta), "Nom_Sede", "total_ventas");
                Llenar_Grafico(chartPlatos, _reportes.Platos_Mas_Pedidos(idSede, desde, hasta), "Nom_Plato", "total_pedidos");
                Llenar_Grafico(chartHoras, _reportes.Horas_Pico(idSede, desde, hasta), "Hora", "CantidadPedidos");
                Llenar_Grafico(chartPromociones, _reportes.Efectividad_Promociones(idSede, desde, hasta), "Promocion", "TotalIngresos");

                dgvTopClientes.DataSource = _reportes.Top_Clientes(idSede, desde, hasta);
                AyudaCRUD.Encabezados(dgvTopClientes, "Cliente", "Cliente", "Frecuencia", "Compras",
                                      "TotalGastado", "Total gastado (S/)", "UltimaVisita", "Última visita");
                if (dgvTopClientes.Columns.Contains("TotalGastado"))
                    dgvTopClientes.Columns["TotalGastado"].DefaultCellStyle.Format = "N2";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los reportes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Llenar_Grafico(Chart grafico, DataTable datos, string columnaX, string columnaY)
        {
            Series serie = grafico.Series[0];
            serie.Points.Clear();
            serie.LabelFormat = "#,0.##";
            foreach (DataRow fila in datos.Rows)
            {
                string etiqueta = columnaX == "Hora" ? fila[columnaX] + ":00" : fila[columnaX].ToString();
                serie.Points.AddXY(etiqueta, Convert.ToDouble(fila[columnaY]));
            }
        }
    }
}
