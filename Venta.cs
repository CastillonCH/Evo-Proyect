using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//
using DATOS;
using ENTIDADES;

namespace RESTAURANTEFINAL
{
    public partial class Venta : Form
    {
        private DATOS_VENTA datosVenta = new DATOS_VENTA();
        private bool esActualizar = false;
        public Venta()
        {
            InitializeComponent();
        }
        private void Venta_Load(object sender, EventArgs e)
        {
            ActualizarTablaVentas();
            CargarPedidos();
            CargarMetodosPago();
            CargarSedes();
        }

        private void btn_venta_guardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                try
                {
                    ENTIDAD_VENTA venta = new ENTIDAD_VENTA
                    {
                        ID_Venta = txt_venta_cod.Text.Trim(),
                        ID_Pedido = cbx_pedido_cod.SelectedValue.ToString(),
                        Fec_Venta = DateTime.Parse(dtp_venta_fecha.Text.Trim()),
                        Monto_Total = decimal.Parse(txt_venta_monto.Text.Trim()),
                        ID_Metodo_Pago = cbx_metodo_cod.SelectedValue.ToString(),
                        ID_Sede = cbx_sede_cod.SelectedValue.ToString()
                    };

                    if (esActualizar)
                    {
                        datosVenta.Modificar_Venta(venta);
                        MessageBox.Show("Venta modificada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        esActualizar = false;
                    }
                    else
                    {
                        datosVenta.Agregar_Venta(venta);
                        MessageBox.Show("Venta guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    LimpiarCampos();
                    ActualizarTablaVentas();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_venta_eliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView_Venta.SelectedRows.Count > 0)
            {
                string idVenta = dataGridView_Venta.SelectedRows[0].Cells["ID_Venta"].Value.ToString();

                if (MessageBox.Show("¿Está seguro de que desea eliminar esta venta?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        datosVenta.Eliminar_Venta(idVenta);
                        MessageBox.Show("Venta eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ActualizarTablaVentas();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una venta para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt_venta_buscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string filtro = txt_venta_buscar.Text.Trim();

                if (!string.IsNullOrEmpty(filtro))
                {
                    DataTable dtVentas = datosVenta.Cargar_Ventas();
                    DataView dv = dtVentas.DefaultView;

                    // Aplica el filtro al campo "ID_Venta"
                    dv.RowFilter = $"ID_Venta LIKE '%{filtro}%' OR ID_Pedido LIKE '%{filtro}%'";
                    dataGridView_Venta.DataSource = dv;
                }
                else
                {
                    // Si el filtro está vacío, recarga todos los datos
                    ActualizarTablaVentas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar las ventas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_Venta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                esActualizar = true;
                txt_venta_cod.Text = dataGridView_Venta.Rows[e.RowIndex].Cells["ID_Venta"].Value.ToString();
                cbx_pedido_cod.SelectedValue = dataGridView_Venta.Rows[e.RowIndex].Cells["ID_Pedido"].Value.ToString();
                dtp_venta_fecha.Text = dataGridView_Venta.Rows[e.RowIndex].Cells["Fec_Venta"].Value.ToString();
                txt_venta_monto.Text = dataGridView_Venta.Rows[e.RowIndex].Cells["Monto_Total"].Value.ToString();
                cbx_metodo_cod.SelectedValue = dataGridView_Venta.Rows[e.RowIndex].Cells["ID_Metodo_Pago"].Value.ToString();
                cbx_sede_cod.SelectedValue = dataGridView_Venta.Rows[e.RowIndex].Cells["ID_Sede"].Value.ToString();
            }
        }
        private void ActualizarTablaVentas()
        {
            try
            {
                dataGridView_Venta.DataSource = datosVenta.Cargar_Ventas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las ventas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txt_venta_cod.Clear();
            cbx_pedido_cod.SelectedIndex = -1;
            dtp_venta_fecha.Value = DateTime.Now; // Restablecer a la fecha actual o la fecha mínima
            txt_venta_monto.Clear();
            cbx_metodo_cod.SelectedIndex = -1;
            cbx_sede_cod.SelectedIndex = -1;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txt_venta_cod.Text) ||
                string.IsNullOrWhiteSpace(dtp_venta_fecha.Text) ||
                string.IsNullOrWhiteSpace(txt_venta_monto.Text) ||
                cbx_pedido_cod.SelectedIndex == -1 ||
                cbx_metodo_cod.SelectedIndex == -1 ||
                cbx_sede_cod.SelectedIndex == -1)
            {
                MessageBox.Show("Complete todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(txt_venta_monto.Text, out _))
            {
                MessageBox.Show("Ingrese un monto válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private void CargarPedidos()
        {
            try
            {
                DataTable dtPedidos = datosVenta.Cargar_Pedidos();
                cbx_pedido_cod.DataSource = dtPedidos;
                cbx_pedido_cod.DisplayMember = "Nombre_Pedido";
                cbx_pedido_cod.ValueMember = "ID_Pedido";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los pedidos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Cargar los métodos de pago en el ComboBox
        private void CargarMetodosPago()
        {
            try
            {
                DataTable dtMetodosPago = datosVenta.Cargar_MetodosPago();
                cbx_metodo_cod.DataSource = dtMetodosPago;
                cbx_metodo_cod.DisplayMember = "Nombre_Metodo_Pago"; // Asumimos que hay una columna "Nombre_Metodo_Pago"
                cbx_metodo_cod.ValueMember = "ID_Metodo_Pago";       // Columna "ID_Metodo_Pago"
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los métodos de pago: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cargar las sedes en el ComboBox
        private void CargarSedes()
        {
            try
            {
                DataTable dtSedes = datosVenta.Cargar_Sedes();
                cbx_sede_cod.DataSource = dtSedes;
                cbx_sede_cod.DisplayMember = "Nombre_Sede"; // Asumimos que hay una columna "Nombre_Sede"
                cbx_sede_cod.ValueMember = "ID_Sede";       // Columna "ID_Sede"
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las sedes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
