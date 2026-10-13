using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RESTAURANTEFINAL
{
    public partial class Plato_Insumo : Form
    {
        private DATOS.DATOS_PLATO_INSUMO datosPlatoInsumo = new DATOS.DATOS_PLATO_INSUMO();
        public Plato_Insumo()
        {
            InitializeComponent();
        }

        private void btn_plato_insumo_guardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                try
                {
                    var platoInsumo = new ENTIDADES.ENTIDAD_PLATO_INSUMO
                    {
                        ID_Plato = cbx_plato_cod.SelectedValue.ToString(),  // Obtener el valor seleccionado
                        ID_Insumo = cbx_insumo_cod.SelectedValue.ToString(), // Obtener el valor seleccionado
                        Cant_Necesaria = txt_plato_insumo_cant.Text.Trim(),
                        Procedimiento = txt_plato_insumo_proc.Text.Trim()
                    };

                    datosPlatoInsumo.Agregar_PlatoInsumo(platoInsumo);
                    MessageBox.Show("Plato-Insumo agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    ActualizarTablaPlatoInsumo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar el Plato-Insumo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Plato_Insumo_Load(object sender, EventArgs e)
        {
            ActualizarTablaPlatoInsumo();
            CargarPlatosInsumos(); // Llamada para cargar los ComboBox
        }

        private void btn_plato_insumo_eliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView_Plato_Insumo.SelectedRows.Count > 0)
            {
                string idPlato = dataGridView_Plato_Insumo.SelectedRows[0].Cells["ID_Plato"].Value.ToString();
                string idInsumo = dataGridView_Plato_Insumo.SelectedRows[0].Cells["ID_Insumo"].Value.ToString();

                if (MessageBox.Show("¿Está seguro de que desea eliminar este Plato-Insumo?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        datosPlatoInsumo.Eliminar_PlatoInsumo(idPlato, idInsumo);
                        MessageBox.Show("Plato-Insumo eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ActualizarTablaPlatoInsumo();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar el Plato-Insumo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un Plato-Insumo para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt_plato_insumo_buscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txt_plato_insumo_buscar.Text.ToLower();

            (dataGridView_Plato_Insumo.DataSource as DataTable).DefaultView.RowFilter = string.Format(
                "ID_Plato LIKE '%{0}%' OR ID_Insumo LIKE '%{0}%' OR Cant_Necesaria LIKE '%{0}%' OR Procedimiento LIKE '%{0}%'",
                filtro);
        }

        private void dataGridView_Plato_Insumo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtener los valores de la fila seleccionada
                DataGridViewRow row = dataGridView_Plato_Insumo.Rows[e.RowIndex];
                cbx_plato_cod.Text = row.Cells["ID_Plato"].Value.ToString();
                cbx_insumo_cod.Text = row.Cells["ID_Insumo"].Value.ToString();
                txt_plato_insumo_cant.Text = row.Cells["Cant_Necesaria"].Value.ToString();
                txt_plato_insumo_proc.Text = row.Cells["Procedimiento"].Value.ToString();
            }
        }
        // Función para actualizar el DataGridView con los datos de Plato-Insumo
        private void ActualizarTablaPlatoInsumo()
        {
            try
            {
                dataGridView_Plato_Insumo.DataSource = datosPlatoInsumo.Cargar_PlatoInsumo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los Plato-Insumo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Función para validar que todos los campos están llenos
        private bool ValidarCampos()
        {
            return !string.IsNullOrEmpty(txt_plato_insumo_cant.Text) && !string.IsNullOrEmpty(txt_plato_insumo_proc.Text) &&
                   cbx_plato_cod.SelectedIndex != -1 && cbx_insumo_cod.SelectedIndex != -1;
        }

        // Función para limpiar los campos del formulario
        private void LimpiarCampos()
        {
           
            txt_plato_insumo_cant.Clear();
            txt_plato_insumo_proc.Clear();
            cbx_plato_cod.SelectedIndex = -1;
            cbx_insumo_cod.SelectedIndex = -1;
        }
        // Función para cargar los ComboBox de Platos e Insumos
        private void CargarPlatosInsumos()
        {
            try
            {
                // Cargar los platos
                DataTable dtPlatos = datosPlatoInsumo.CargarPlatos();
                cbx_plato_cod.DisplayMember = "Nom_Plato";  // Columna a mostrar
                cbx_plato_cod.ValueMember = "ID_Plato";        // Columna que contiene el valor
                cbx_plato_cod.DataSource = dtPlatos;

                // Cargar los insumos
                DataTable dtInsumos = datosPlatoInsumo.CargarInsumos();
                cbx_insumo_cod.DisplayMember = "Nombre";  // Columna a mostrar
                cbx_insumo_cod.ValueMember = "ID_Insumo";        // Columna que contiene el valor
                cbx_insumo_cod.DataSource = dtInsumos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los ComboBox de Platos e Insumos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
