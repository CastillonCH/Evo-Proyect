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
    public partial class Sede : Form
    {
        private DATOS_SEDE datosSede = new DATOS_SEDE();
        private bool esActualizar = false;
        public Sede()
        {
            InitializeComponent();
        }

        private void Sede_Load(object sender, EventArgs e)
        {
            ActualizarTablaSedes();
        }

        private void btn_sede_guardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                try
                {
                    ENTIDAD_SEDE sede = new ENTIDAD_SEDE
                    {
                        ID_Sede = txt_sede_cod.Text.Trim(),
                        Nom_Sede = txt_sede_nom.Text.Trim(),
                        Dir_Sede = txt_sede_dir.Text.Trim(),
                        Tel_Sede = txt_sede_tel.Text.Trim(),
                        Hora_Apertura = dateTimePicker_apertura.Value,
                        Hora_Cierre = dateTimePicker_cierre.Value
                    };

                    if (esActualizar)
                    {
                        // Actualizar sede existente
                        datosSede.Modificar_Sede(sede);
                        MessageBox.Show("Sede modificada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        esActualizar = false; // Salir del modo de edición
                    }
                    else
                    {
                        // Agregar una nueva sede
                        datosSede.Agregar_Sede(sede);
                        MessageBox.Show("Sede guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Limpiar campos y actualizar tabla
                    LimpiarCampos();
                    ActualizarTablaSedes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar sede: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_sede_eliminar_Click(object sender, EventArgs e)
        {
            // Verifica que se haya seleccionado una sede
            if (dataGridView_sede.SelectedRows.Count > 0)
            {
                string idSede = dataGridView_sede.SelectedRows[0].Cells["ID_Sede"].Value.ToString();

                if (MessageBox.Show("¿Está seguro de que desea eliminar esta sede?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        datosSede.Eliminar_Sede(idSede);
                        MessageBox.Show("Sede eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Actualiza la tabla después de eliminar
                        LimpiarCampos();
                        ActualizarTablaSedes();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar sede: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una sede para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void ActualizarTablaSedes()
        {
            try
            {
                dataGridView_sede.DataSource = datosSede.Cargar_Sede();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimpiarCampos()
        {
            txt_sede_cod.Clear();
            txt_sede_nom.Clear();
            txt_sede_dir.Clear();
            txt_sede_tel.Clear();
            dateTimePicker_apertura.Value = DateTime.Now;
            dateTimePicker_cierre.Value = DateTime.Now;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txt_sede_cod.Text) ||
                string.IsNullOrWhiteSpace(txt_sede_nom.Text) ||
                string.IsNullOrWhiteSpace(txt_sede_dir.Text) ||
                string.IsNullOrWhiteSpace(txt_sede_tel.Text))
            {
                MessageBox.Show("Complete todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void txt_sede_buscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string filtro = txt_sede_buscar.Text.Trim();

                if (!string.IsNullOrEmpty(filtro))
                {
                    DataTable dtSedes = datosSede.Cargar_Sede();
                    DataView dv = dtSedes.DefaultView;

                    // Filtrar por la columna "Nom_Sede"
                    dv.RowFilter = $"Nom_Sede LIKE '%{filtro}%'";
                    dataGridView_sede.DataSource = dv;
                }
                else
                {
                    // Si el filtro está vacío, carga todos los datos
                    ActualizarTablaSedes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_sede_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que se haya seleccionado una fila válida
            if (e.RowIndex >= 0)
            {
                // Activa el modo de edición
                esActualizar = true;

                // Carga los datos seleccionados en los TextBox
                txt_sede_cod.Text = dataGridView_sede.Rows[e.RowIndex].Cells["ID_Sede"].Value.ToString();
                txt_sede_nom.Text = dataGridView_sede.Rows[e.RowIndex].Cells["Nom_Sede"].Value.ToString();
                txt_sede_dir.Text = dataGridView_sede.Rows[e.RowIndex].Cells["Dir_Sede"].Value.ToString();
                txt_sede_tel.Text = dataGridView_sede.Rows[e.RowIndex].Cells["Tel_Sede"].Value.ToString();
                dateTimePicker_apertura.Value = (DateTime)dataGridView_sede.Rows[e.RowIndex].Cells["Hora_Apertura"].Value;
                dateTimePicker_cierre.Value = (DateTime)dataGridView_sede.Rows[e.RowIndex].Cells["Hora_Cierre"].Value;
            }
        }
    }
}
