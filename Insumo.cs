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
using System.Data.SqlClient;

namespace RESTAURANTEFINAL
{
    public partial class Insumo : Form
    {
        private DATOS_INSUMO datosInsumo = new DATOS_INSUMO();
        private bool esActualizar = false;
        public Insumo()
        {
            InitializeComponent();
        }

        private void Insumo_Load(object sender, EventArgs e)
        {
            ActualizarTablaInsumos();
            CargarUnidadMedida();
            CargarClasificacion();
        }
        private void btn_insumo_guardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                try
                {
                    ENTIDAD_INSUMO insumo = new ENTIDAD_INSUMO
                    {
                        ID_Insumo = txt_insumo_cod.Text.Trim(),
                        Nombre = txt_insumo_nom.Text.Trim(),
                        ID_Unidad_Medida = cbx_insumo_uni_med_cod.SelectedValue.ToString(),
                        Precio_Unitario = decimal.Parse(txt_insumo_prec_unitario.Text.Trim()),
                        ID_Clasificacion = cbx_insumo_clasi_cod.SelectedValue.ToString()
                    };

                    if (esActualizar)
                    {
                        datosInsumo.Modificar_Insumo(insumo);
                        MessageBox.Show("Insumo modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        esActualizar = false;
                    }
                    else
                    {
                        datosInsumo.Agregar_Insumo(insumo);
                        MessageBox.Show("Insumo guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    LimpiarCampos();
                    ActualizarTablaInsumos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar insumo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btn_insumo_eliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView_Insumo.SelectedRows.Count > 0)
            {
                string idInsumo = dataGridView_Insumo.SelectedRows[0].Cells["ID_Insumo"].Value.ToString();

                if (MessageBox.Show("¿Está seguro de que desea eliminar este insumo?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        datosInsumo.Eliminar_Insumo(idInsumo);
                        MessageBox.Show("Insumo eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ActualizarTablaInsumos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar insumo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un insumo para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                esActualizar = true;
                txt_insumo_cod.Text = dataGridView_Insumo.Rows[e.RowIndex].Cells["ID_Insumo"].Value.ToString();
                txt_insumo_nom.Text = dataGridView_Insumo.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                cbx_insumo_uni_med_cod.SelectedValue = dataGridView_Insumo.Rows[e.RowIndex].Cells["ID_Unidad_Medida"].Value.ToString();
                txt_insumo_prec_unitario.Text = dataGridView_Insumo.Rows[e.RowIndex].Cells["Precio_Unitario"].Value.ToString();
                cbx_insumo_clasi_cod.SelectedValue = dataGridView_Insumo.Rows[e.RowIndex].Cells["ID_Clasificacion"].Value.ToString();
            }
        }

        private void CargarUnidadMedida()
        {
            try
            {
                DataTable dtUnidadMedida = datosInsumo.Cargar_Unidad_Medida();
                cbx_insumo_uni_med_cod.DataSource = dtUnidadMedida;
                cbx_insumo_uni_med_cod.DisplayMember = "Nom_Unidad_Medida"; // Nombre visible en el ComboBox
                cbx_insumo_uni_med_cod.ValueMember = "ID_Unidad_Medida"; // Valor seleccionado
                cbx_insumo_uni_med_cod.SelectedIndex = -1; // Sin selección inicial
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las unidades de medida: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarClasificacion()
        {
            try
            {
                DataTable dtClasificacion = datosInsumo.Cargar_Clasificacion();
                cbx_insumo_clasi_cod.DataSource = dtClasificacion;
                cbx_insumo_clasi_cod.DisplayMember = "Nom_Clasificacion"; // Nombre visible en el ComboBox
                cbx_insumo_clasi_cod.ValueMember = "ID_Clasificacion"; // Valor seleccionado
                cbx_insumo_clasi_cod.SelectedIndex = -1; // Sin selección inicial
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las clasificaciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ActualizarTablaInsumos()
        {
            try
            {
                dataGridView_Insumo.DataSource = datosInsumo.Cargar_Insumo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los insumos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void LimpiarCampos()
        {
            txt_insumo_cod.Clear();
            txt_insumo_nom.Clear();
            txt_insumo_prec_unitario.Clear();
            cbx_insumo_uni_med_cod.SelectedIndex = -1;
            cbx_insumo_clasi_cod.SelectedIndex = -1;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txt_insumo_cod.Text) ||
                string.IsNullOrWhiteSpace(txt_insumo_nom.Text) ||
                string.IsNullOrWhiteSpace(txt_insumo_prec_unitario.Text) ||
                cbx_insumo_uni_med_cod.SelectedIndex == -1 ||
                cbx_insumo_clasi_cod.SelectedIndex == -1)
            {
                MessageBox.Show("Complete todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(txt_insumo_prec_unitario.Text, out _))
            {
                MessageBox.Show("Ingrese un precio válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txt_insumo_buscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string filtro = txt_insumo_buscar.Text.Trim();

                if (!string.IsNullOrEmpty(filtro))
                {
                    DataTable dtInsumos = datosInsumo.Cargar_Insumo(); // Carga todos los datos
                    DataView dv = dtInsumos.DefaultView;

                    // Aplica el filtro al campo "Nombre"
                    dv.RowFilter = $"Nombre LIKE '%{filtro}%'";
                    dataGridView_Insumo.DataSource = dv;
                }
                else
                {
                    // Si el filtro está vacío, recarga todos los datos
                    ActualizarTablaInsumos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar los insumos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
