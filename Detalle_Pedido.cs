using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DATOS;
using ENTIDADES;

namespace RESTAURANTEFINAL
{
    public partial class Detalle_Pedido : Form
    {
        private DATOS.DATOS_DETALLE_PEDIDO datosDetallePedido = new DATOS.DATOS_DETALLE_PEDIDO();
        private bool esActualizar = false;
        public Detalle_Pedido()
        {
            InitializeComponent();
        }
        private void Detalle_Pedido_Load(object sender, EventArgs e)
        {
            ActualizarTablaDetallePedido();
            // Cargar los detalles del pedido y los platos en los ComboBox
            CargarPedido();
            CargarPlato();
        }

        private void btn_detalle_pedido_guardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                try
                {
                    ENTIDADES.ENTIDAD_DETALLE_PEDIDO detallePedido = new ENTIDADES.ENTIDAD_DETALLE_PEDIDO
                    {
                        ID_Detalle_Pedido = txt_detalle_pedido_cod.Text.Trim(),
                        ID_Pedido = cbx_pedido_cod.SelectedValue.ToString(),
                        ID_Plato = cbx_plato_cod.SelectedValue.ToString(),
                        Cantidad = txt_detalle_pedido_cant.Text.Trim(),
                        Pre_Unitario_Final = txt_detalle_pedido_pre.Text.Trim()
                    };

                    if (esActualizar)
                    {
                        datosDetallePedido.Modificar_Detalle_Pedido(detallePedido);
                        MessageBox.Show("Detalle de pedido modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        esActualizar = false;
                    }
                    else
                    {
                        datosDetallePedido.Agregar_Detalle_Pedido(detallePedido);
                        MessageBox.Show("Detalle de pedido guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    LimpiarCampos();
                    ActualizarTablaDetallePedido();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar detalle de pedido: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_detalle_pedido_eliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView_Detalle_Pedido.SelectedRows.Count > 0)
            {
                string idDetallePedido = dataGridView_Detalle_Pedido.SelectedRows[0].Cells["ID_Detalle_Pedido"].Value.ToString();

                if (MessageBox.Show("¿Está seguro de que desea eliminar este detalle de pedido?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        datosDetallePedido.Eliminar_Detalle_Pedido(idDetallePedido);
                        MessageBox.Show("Detalle de pedido eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ActualizarTablaDetallePedido();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar detalle de pedido: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un detalle de pedido para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            LimpiarCampos();
        }

        private void txt_detalle_pedido_buscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string filtro = txt_detalle_pedido_buscar.Text.Trim();

                if (!string.IsNullOrEmpty(filtro))
                {
                    DataTable dtDetalles = datosDetallePedido.Cargar_Detalle_Pedido(); // Método que carga todos los detalles del pedido
                    DataView dv = dtDetalles.DefaultView;

                    // Aplica el filtro al campo "ID_Detalle_Pedido" o cualquier otro campo
                    dv.RowFilter = $"ID_Detalle_Pedido LIKE '%{filtro}%' OR ID_Plato LIKE '%{filtro}%'";
                    dataGridView_Detalle_Pedido.DataSource = dv;
                }
                else
                {
                    // Si el filtro está vacío, recarga todos los datos
                    ActualizarTablaDetallePedido();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar los detalles del pedido: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
        private void ActualizarTablaDetallePedido()
        {
            try
            {
                dataGridView_Detalle_Pedido.DataSource = datosDetallePedido.Cargar_Detalle_Pedido(); // Cargar los detalles de los pedidos desde la base de datos
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los detalles del pedido: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txt_detalle_pedido_cod.Clear();
            cbx_pedido_cod.SelectedIndex = -1;
            cbx_plato_cod.SelectedIndex = -1;
            txt_detalle_pedido_cant.Clear();
            txt_detalle_pedido_pre.Clear();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txt_detalle_pedido_cod.Text) ||
                cbx_pedido_cod.SelectedIndex == -1 ||
                cbx_plato_cod.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txt_detalle_pedido_cant.Text) ||
                string.IsNullOrWhiteSpace(txt_detalle_pedido_pre.Text))
            {
                MessageBox.Show("Complete todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void CargarPedido()
        {
            try
            {
                DataTable dtPedidos = datosDetallePedido.Cargar_Pedido(); // Cargar los pedidos desde la base de datos

                cbx_pedido_cod.DataSource = dtPedidos;
                cbx_pedido_cod.DisplayMember = "ID_Pedido"; // Mostrar el ID del pedido
                cbx_pedido_cod.ValueMember = "ID_Pedido"; // Almacenar el ID del pedido
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los pedidos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarPlato()
        {
            try
            {
                DataTable dtPlatos = datosDetallePedido.Cargar_Plato(); // Cargar los platos desde la base de datos

                cbx_plato_cod.DataSource = dtPlatos;
                cbx_plato_cod.DisplayMember = "Nom_Plato"; // Mostrar el nombre del plato
                cbx_plato_cod.ValueMember = "ID_Plato"; // Almacenar el ID del plato
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los platos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_Detalle_Pedido_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                esActualizar = true;
                txt_detalle_pedido_cod.Text = dataGridView_Detalle_Pedido.Rows[e.RowIndex].Cells["ID_Detalle_Pedido"].Value.ToString();
                cbx_pedido_cod.SelectedValue = dataGridView_Detalle_Pedido.Rows[e.RowIndex].Cells["ID_Pedido"].Value.ToString();
                cbx_plato_cod.SelectedValue = dataGridView_Detalle_Pedido.Rows[e.RowIndex].Cells["ID_Plato"].Value.ToString();
                txt_detalle_pedido_cant.Text = dataGridView_Detalle_Pedido.Rows[e.RowIndex].Cells["Cantidad"].Value.ToString();
                txt_detalle_pedido_pre.Text = dataGridView_Detalle_Pedido.Rows[e.RowIndex].Cells["Pre_Unitario_Final"].Value.ToString();
            }
        }

       
    }
}
