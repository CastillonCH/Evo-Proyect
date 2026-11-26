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
using ENTIDADES;
using DATOS;


namespace RESTAURANTEFINAL
{
    public partial class Pedido : Form
    {
        private DATOS_PEDIDO datosPedido = new DATOS_PEDIDO();
        private bool esActualizar = false;
        public Pedido()
        {
            InitializeComponent();
        }
        private void Pedido_Load(object sender, EventArgs e)
        {
            // Cargar los estados del pedido en el ComboBox
            cbx_pedido_estado.Items.Add("Pendiente");
            cbx_pedido_estado.Items.Add("En preparación");
            cbx_pedido_estado.Items.Add("Completado");

            // Opcional: Seleccionar un valor por defecto
            cbx_pedido_estado.SelectedIndex = 0;
            // Cargar los clientes en el ComboBox cbx_cliente_cod
            ActualizarTablaPedido();
            CargarCliente();
        }

        private void btn_pedido_guardar_Click(object sender, EventArgs e)
        {

            if (ValidarCampos())
            {
                try
                {
                    ENTIDADES_PEDIDO pedido = new ENTIDADES_PEDIDO
                    {
                        ID_Pedido = txt_pedido_cod.Text.Trim(),
                        ID_Cliente = cbx_cliente_cod.SelectedValue.ToString(),
                        Fec_Pedido = dtp_pedido_fecha.Value,
                        Estado_Pedido = cbx_pedido_estado.Text.Trim(),  // Corregido: Usamos el valor del ComboBox cbx_pedido_estado
                        Observaciones = txt_pedido_obs.Text.Trim(),
                    };

                    if (esActualizar)
                    {
                        datosPedido.Modificar_Pedido(pedido);
                        MessageBox.Show("Pedido modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        esActualizar = false;
                    }
                    else
                    {
                        datosPedido.Agregar_Pedido(pedido);
                        MessageBox.Show("Pedido guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    LimpiarCampos();
                    ActualizarTablaPedido();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar pedido: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_pedido_eliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView_Pedido.SelectedRows.Count > 0)
            {
                string idPedido = dataGridView_Pedido.SelectedRows[0].Cells["ID_Pedido"].Value.ToString();

                if (MessageBox.Show("¿Está seguro de que desea eliminar este pedido?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        datosPedido.Eliminar_Pedido(idPedido);
                        MessageBox.Show("Pedido eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ActualizarTablaPedido();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar pedido: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un pedido para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt_pedido_buscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string filtro = txt_pedido_buscar.Text.Trim();

                if (!string.IsNullOrEmpty(filtro))
                {
                    DataTable dtPedidos = datosPedido.Cargar_Pedido(); // Método que carga todos los pedidos
                    DataView dv = dtPedidos.DefaultView;

                    // Aplica el filtro al campo "ID_Pedido" o cualquier otro campo
                    dv.RowFilter = $"ID_Pedido LIKE '%{filtro}%' OR Observaciones LIKE '%{filtro}%'";
                    dataGridView_Pedido.DataSource = dv;
                }
                else
                {
                    // Si el filtro está vacío, recarga todos los datos
                    ActualizarTablaPedido();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar los pedidos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_Pedido_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                esActualizar = true;
                txt_pedido_cod.Text = dataGridView_Pedido.Rows[e.RowIndex].Cells["ID_Pedido"].Value.ToString();
                cbx_cliente_cod.SelectedValue = dataGridView_Pedido.Rows[e.RowIndex].Cells["ID_Cliente"].Value.ToString();
                dtp_pedido_fecha.Value = Convert.ToDateTime(dataGridView_Pedido.Rows[e.RowIndex].Cells["Fec_Pedido"].Value);
                cbx_pedido_estado.Text = dataGridView_Pedido.Rows[e.RowIndex].Cells["Estado_Pedido"].Value.ToString();
                txt_pedido_obs.Text = dataGridView_Pedido.Rows[e.RowIndex].Cells["Observaciones"].Value.ToString();
            }
        }
        private void ActualizarTablaPedido()
        {
            try
            {
                dataGridView_Pedido.DataSource = datosPedido.Cargar_Pedido(); // Cargar los pedidos desde la base de datos
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los pedidos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txt_pedido_cod.Clear();
            cbx_cliente_cod.SelectedIndex = -1;
            dtp_pedido_fecha.Value = DateTime.Now;
            cbx_pedido_estado.SelectedIndex = 0;
            txt_pedido_obs.Clear();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txt_pedido_cod.Text) ||
                cbx_cliente_cod.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txt_pedido_obs.Text))
            {
                MessageBox.Show("Complete todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void CargarCliente()
        {
            try
            {
                DataTable dtClientes = datosPedido.Cargar_Cliente(); // Cargar los clientes desde la base de datos

                cbx_cliente_cod.DataSource = dtClientes;
                cbx_cliente_cod.DisplayMember = "ID_Cliente"; // Mostrar el nombre del cliente
                cbx_cliente_cod.ValueMember = "ID_Cliente"; // Almacenar el ID del cliente
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
