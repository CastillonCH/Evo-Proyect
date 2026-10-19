using System;
using System.Data;
using System.Windows.Forms;
using DATOS;
using ENTIDADES;

namespace RESTAURANTEFINAL
{
    public partial class Promocion : Form
    {
        private DATOS_PROMOCION datosPromocion = new DATOS_PROMOCION();
        private bool esActualizar = false;

        public Promocion()
        {
            InitializeComponent();
            Estilo.Aplicar(this);
        }

        private void Promocion_Load(object sender, EventArgs e)
        {
            ActualizarTablaPromociones();
            LimpiarCampos();
        }

        private void btn_promocion_guardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                ENTIDAD_PROMOCION promocion = new ENTIDAD_PROMOCION
                {
                    ID_Promocion = txt_promocion_cod.Text.Trim(),
                    Nom_Promocion = txt_promocion_nom.Text.Trim(),
                    Fec_Inicio = date_promocion_inicio.Value.Date,
                    Fec_Fin = date_promocion_fin.Value.Date,
                    Descuento = decimal.Parse(txt_promocion_desc.Text.Trim())
                };

                if (esActualizar)
                {
                    datosPromocion.Modificar_Promocion(promocion);
                    MessageBox.Show("Promoción modificada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    datosPromocion.Agregar_Promocion(promocion);
                    MessageBox.Show("Promoción guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ActualizarTablaPromociones();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar promoción: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_promocion_nuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btn_promocion_eliminar_Click(object sender, EventArgs e)
        {
            if (!esActualizar)
            {
                MessageBox.Show("Por favor, seleccione una promoción para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Está seguro de que desea eliminar esta promoción?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                datosPromocion.Eliminar_Promocion(txt_promocion_cod.Text);
                MessageBox.Show("Promoción eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActualizarTablaPromociones();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                AyudaCRUD.Mostrar_Error_Eliminar(ex);
            }
        }

        private void txt_promocion_buscar_TextChanged(object sender, EventArgs e)
        {
            AyudaCRUD.Buscar(dataGridView_Promocion, txt_promocion_buscar.Text, "ID_Promocion", "Nom_Promocion", "Descuento");
        }

        private void dataGridView_Promocion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            esActualizar = true;
            DataGridViewRow fila = dataGridView_Promocion.Rows[e.RowIndex];
            txt_promocion_cod.Text = fila.Cells["ID_Promocion"].Value.ToString();
            txt_promocion_nom.Text = fila.Cells["Nom_Promocion"].Value.ToString();
            date_promocion_inicio.Value = Convert.ToDateTime(fila.Cells["Fec_Inicio"].Value);
            date_promocion_fin.Value = Convert.ToDateTime(fila.Cells["Fec_Fin"].Value);
            txt_promocion_desc.Text = fila.Cells["Descuento"].Value.ToString();
            btn_promocion_guardar.Text = "Actualizar";
        }

        private void ActualizarTablaPromociones()
        {
            try
            {
                dataGridView_Promocion.DataSource = datosPromocion.Cargar_Promocion();
                AyudaCRUD.Encabezados(dataGridView_Promocion, "ID_Promocion", "Código", "Nom_Promocion", "Promoción",
                                      "Fec_Inicio", "Inicio", "Fec_Fin", "Fin", "Descuento", "Descuento (%)");
                txt_promocion_buscar_TextChanged(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las promociones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sale del modo edición y genera el siguiente código (P001, P002, ...)
        private void LimpiarCampos()
        {
            esActualizar = false;
            btn_promocion_guardar.Text = "Guardar";
            txt_promocion_nom.Clear();
            txt_promocion_desc.Clear();
            date_promocion_inicio.Value = DateTime.Today;
            date_promocion_fin.Value = DateTime.Today;
            DataTable tabla = dataGridView_Promocion.DataSource as DataTable;
            txt_promocion_cod.Text = tabla == null ? "" : AyudaCRUD.Siguiente_Codigo(tabla, "ID_Promocion", "P", 3);
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txt_promocion_cod.Text) ||
                string.IsNullOrWhiteSpace(txt_promocion_nom.Text) ||
                string.IsNullOrWhiteSpace(txt_promocion_desc.Text))
            {
                MessageBox.Show("Complete todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            decimal descuento;
            if (!decimal.TryParse(txt_promocion_desc.Text, out descuento) || descuento <= 0 || descuento > 100)
            {
                MessageBox.Show("Ingrese un descuento entre 0 y 100 (%).", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (date_promocion_fin.Value.Date < date_promocion_inicio.Value.Date)
            {
                MessageBox.Show("La fecha de fin no puede ser anterior a la de inicio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
