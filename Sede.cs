using System;
using System.Data;
using System.Windows.Forms;
using DATOS;
using ENTIDADES;

namespace RESTAURANTEFINAL
{
    public partial class Sede : Form
    {
        private DATOS_SEDE datosSede = new DATOS_SEDE();
        private bool esActualizar = false;

        public Sede()
        {
            InitializeComponent();
            Estilo.Aplicar(this);
        }

        private void Sede_Load(object sender, EventArgs e)
        {
            ActualizarTablaSedes();
            LimpiarCampos();
        }

        private void btn_sede_guardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

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
                    datosSede.Modificar_Sede(sede);
                    MessageBox.Show("Sede modificada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    datosSede.Agregar_Sede(sede);
                    MessageBox.Show("Sede guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ActualizarTablaSedes();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar sede: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_sede_nuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btn_sede_eliminar_Click(object sender, EventArgs e)
        {
            if (!esActualizar)
            {
                MessageBox.Show("Por favor, seleccione una sede para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Está seguro de que desea eliminar esta sede?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                datosSede.Eliminar_Sede(txt_sede_cod.Text);
                MessageBox.Show("Sede eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActualizarTablaSedes();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                AyudaCRUD.Mostrar_Error_Eliminar(ex);
            }
        }

        private void txt_sede_buscar_TextChanged(object sender, EventArgs e)
        {
            AyudaCRUD.Buscar(dataGridView_sede, txt_sede_buscar.Text, "ID_Sede", "Nom_Sede", "Dir_Sede", "Tel_Sede");
        }

        private void dataGridView_sede_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            esActualizar = true;
            DataGridViewRow fila = dataGridView_sede.Rows[e.RowIndex];
            txt_sede_cod.Text = fila.Cells["ID_Sede"].Value.ToString();
            txt_sede_nom.Text = fila.Cells["Nom_Sede"].Value.ToString();
            txt_sede_dir.Text = fila.Cells["Dir_Sede"].Value.ToString();
            txt_sede_tel.Text = fila.Cells["Tel_Sede"].Value.ToString();
            // Las horas llegan de SQL como TimeSpan (columna time)
            dateTimePicker_apertura.Value = DateTime.Today + (TimeSpan)fila.Cells["Hora_Apertura"].Value;
            dateTimePicker_cierre.Value = DateTime.Today + (TimeSpan)fila.Cells["Hora_Cierre"].Value;
            btn_sede_guardar.Text = "Actualizar";
        }

        private void ActualizarTablaSedes()
        {
            try
            {
                dataGridView_sede.DataSource = datosSede.Cargar_Sede();
                AyudaCRUD.Encabezados(dataGridView_sede, "ID_Sede", "Código", "Nom_Sede", "Sede", "Dir_Sede", "Dirección",
                                      "Tel_Sede", "Teléfono", "Hora_Apertura", "Apertura", "Hora_Cierre", "Cierre");
                txt_sede_buscar_TextChanged(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sale del modo edición y genera el siguiente código (S001, S002, ...)
        private void LimpiarCampos()
        {
            esActualizar = false;
            btn_sede_guardar.Text = "Guardar";
            txt_sede_nom.Clear();
            txt_sede_dir.Clear();
            txt_sede_tel.Clear();
            dateTimePicker_apertura.Value = DateTime.Today.AddHours(8);
            dateTimePicker_cierre.Value = DateTime.Today.AddHours(22);
            DataTable tabla = dataGridView_sede.DataSource as DataTable;
            txt_sede_cod.Text = tabla == null ? "" : AyudaCRUD.Siguiente_Codigo(tabla, "ID_Sede", "S", 3);
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
    }
}
