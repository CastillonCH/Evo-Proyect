using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ENTIDADES;
using DATOS;

namespace RESTAURANTEFINAL
{
    public partial class Cliente : Form
    {
        private DATOS_CLIENTE datosCliente = new DATOS_CLIENTE();
        private bool esActualizar = false;

        public Cliente()
        {
            InitializeComponent();
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            ActualizarTablaClientes();
        }

        private void btn_cliente_guardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                try
                {
                    ENTIDAD_CLIENTE cliente = new ENTIDAD_CLIENTE
                    {
                        ID_Cliente = txt_cliente_cod.Text.Trim(),
                        Nom_Cliente = txt_cliente_nom.Text.Trim(),
                        Ape_Cliente = txt_cliente_ape.Text.Trim(),
                        Tel_Cliente = txt_cliente_tel.Text.Trim(),
                        Email = txt_cliente_email.Text.Trim(),
                        Dir_Cliente = txt_cliente_dir.Text.Trim()
                    };

                    if (esActualizar)
                    {
                        // Actualizar cliente existente
                        datosCliente.Modificar_Cliente(cliente);
                        MessageBox.Show("Cliente modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        esActualizar = false; // Salir del modo de edición
                    }
                    else
                    {
                        // Agregar un nuevo cliente
                        datosCliente.Agregar_Cliente(cliente);
                        MessageBox.Show("Cliente guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Limpiar campos y actualizar tabla
                    LimpiarCampos();
                    ActualizarTablaClientes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ActualizarTablaClientes()
        {
            try
            {
                dataGridView_cliente.DataSource = datosCliente.Cargar_Cliente();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txt_cliente_cod.Clear();
            txt_cliente_nom.Clear();
            txt_cliente_ape.Clear();
            txt_cliente_tel.Clear();
            txt_cliente_email.Clear();
            txt_cliente_dir.Clear();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txt_cliente_cod.Text) ||
                string.IsNullOrWhiteSpace(txt_cliente_nom.Text) ||
                string.IsNullOrWhiteSpace(txt_cliente_ape.Text) ||
                string.IsNullOrWhiteSpace(txt_cliente_tel.Text))
            {
                MessageBox.Show("Complete todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!txt_cliente_email.Text.Contains("@"))
            {
                MessageBox.Show("Ingrese un correo válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btn_cliente_eliminar_Click(object sender, EventArgs e)
        {
            // Verifica que se haya seleccionado un cliente
            if (dataGridView_cliente.SelectedRows.Count > 0)
            {
                string idCliente = dataGridView_cliente.SelectedRows[0].Cells["ID_Cliente"].Value.ToString();

                if (MessageBox.Show("¿Está seguro de que desea eliminar este cliente?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        datosCliente.Eliminar_Cliente(idCliente);
                        MessageBox.Show("Cliente eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Actualiza la tabla después de eliminar
                        LimpiarCampos();
                        ActualizarTablaClientes();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView_cliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que se haya seleccionado una fila válida
            if (e.RowIndex >= 0)
            {
                // Activa el modo de edición
                esActualizar = true;

                // Carga los datos seleccionados en los TextBox
                txt_cliente_cod.Text = dataGridView_cliente.Rows[e.RowIndex].Cells["ID_Cliente"].Value.ToString();
                txt_cliente_nom.Text = dataGridView_cliente.Rows[e.RowIndex].Cells["Nom_Cliente"].Value.ToString();
                txt_cliente_ape.Text = dataGridView_cliente.Rows[e.RowIndex].Cells["Ape_Cliente"].Value.ToString();
                txt_cliente_tel.Text = dataGridView_cliente.Rows[e.RowIndex].Cells["Tel_Cliente"].Value.ToString();
                txt_cliente_email.Text = dataGridView_cliente.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                txt_cliente_dir.Text = dataGridView_cliente.Rows[e.RowIndex].Cells["Dir_Cliente"].Value.ToString();

               
            }
        }

        private void dataGridView_cliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_cliente_buscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string filtro = txt_cliente_buscar.Text.Trim();

                if (!string.IsNullOrEmpty(filtro))
                {
                    DataTable dtClientes = datosCliente.Cargar_Cliente();
                    DataView dv = dtClientes.DefaultView;

                    // Filtrar por la columna "Nom_Cliente"
                    dv.RowFilter = $"Nom_Cliente LIKE '%{filtro}%'";
                    dataGridView_cliente.DataSource = dv;
                }
                else
                {
                    // Si el filtro está vacío, carga todos los datos
                    ActualizarTablaClientes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}