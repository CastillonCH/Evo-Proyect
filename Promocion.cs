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
    public partial class Promocion : Form
    {
        private DATOS_PROMOCION datosPromocion = new DATOS_PROMOCION();
        private bool esActualizar = false;

        public Promocion()
        {
            InitializeComponent();
        }

        private void Promocion_Load(object sender, EventArgs e)
        {
            ActualizarTablaPromociones();
        }

        private void btn_promocion_guardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                try
                {
                    ENTIDAD_PROMOCION promocion = new ENTIDAD_PROMOCION
                    {
                        ID_Promocion = txt_promocion_cod.Text.Trim(),
                        Nom_Promocion = txt_promocion_nom.Text.Trim(),
                        Fec_Inicio = date_promocion_inicio.Value,
                        Fec_Fin = date_promocion_fin.Value,
                        Descuento = decimal.Parse(txt_promocion_desc.Text.Trim())
                    };

                    if (esActualizar)
                    {
                        datosPromocion.Modificar_Promocion(promocion);
                        MessageBox.Show("Promoción modificada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        esActualizar = false;
                    }
                    else
                    {
                        datosPromocion.Agregar_Promocion(promocion);
                        MessageBox.Show("Promoción guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    LimpiarCampos();
                    ActualizarTablaPromociones();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar promoción: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_promocion_eliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView_Promocion.SelectedRows.Count > 0)
            {
                string idPromocion = dataGridView_Promocion.SelectedRows[0].Cells["ID_Promocion"].Value.ToString();

                if (MessageBox.Show("¿Está seguro de que desea eliminar esta promoción?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        datosPromocion.Eliminar_Promocion(idPromocion);
                        MessageBox.Show("Promoción eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ActualizarTablaPromociones();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar promoción: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una promoción para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt_promocion_buscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string filtro = txt_promocion_buscar.Text.Trim();

                if (!string.IsNullOrEmpty(filtro))
                {
                    DataTable dtPromociones = datosPromocion.Cargar_Promocion();
                    DataView dv = dtPromociones.DefaultView;
                    dv.RowFilter = $"Nom_Promocion LIKE '%{filtro}%'";
                    dataGridView_Promocion.DataSource = dv;
                }
                else
                {
                    ActualizarTablaPromociones();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar promociones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_Promocion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                esActualizar = true;
                txt_promocion_cod.Text = dataGridView_Promocion.Rows[e.RowIndex].Cells["ID_Promocion"].Value.ToString();
                txt_promocion_nom.Text = dataGridView_Promocion.Rows[e.RowIndex].Cells["Nom_Promocion"].Value.ToString();
                date_promocion_inicio.Value = DateTime.Parse(dataGridView_Promocion.Rows[e.RowIndex].Cells["Fec_Inicio"].Value.ToString());
                date_promocion_fin.Value = DateTime.Parse(dataGridView_Promocion.Rows[e.RowIndex].Cells["Fec_Fin"].Value.ToString());
                txt_promocion_desc.Text = dataGridView_Promocion.Rows[e.RowIndex].Cells["Descuento"].Value.ToString();

                MessageBox.Show("Modo de edición activado. Modifique los datos y presione 'Guardar' para actualizar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ActualizarTablaPromociones()
        {
            try
            {
                dataGridView_Promocion.DataSource = datosPromocion.Cargar_Promocion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las promociones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txt_promocion_cod.Clear();
            txt_promocion_nom.Clear();
            txt_promocion_desc.Clear();
            date_promocion_inicio.Value = DateTime.Now;
            date_promocion_fin.Value = DateTime.Now;
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

            if (!decimal.TryParse(txt_promocion_desc.Text, out _))
            {
                MessageBox.Show("Ingrese un descuento válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

      
    }
}
