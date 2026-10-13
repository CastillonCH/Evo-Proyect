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
    public partial class Plato : Form
    {
        private DATOS_PLATO datosPlato = new DATOS_PLATO();
        private bool esActualizar = false;
        public Plato()
        {
            InitializeComponent();
        }

        private void Plato_Load(object sender, EventArgs e)
        {
            ActualizarTablaPlatos();
            CargarPromociones();

        }

        private void btn_plato_guardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                try
                {
                    ENTIDAD_PLATO plato = new ENTIDAD_PLATO
                    {
                        ID_Plato = txt_plato_cod.Text.Trim(),
                        Nom_Plato = txt_plato_nom.Text.Trim(),
                        Des_Plato = txt_plato_des.Text.Trim(),
                        Prec_Original = decimal.Parse(txt_plato_pre.Text.Trim()),
                        ID_Promocion = cbx_promocion_cod.SelectedValue == DBNull.Value ? null : cbx_promocion_cod.SelectedValue.ToString()
                    };

                    if (esActualizar)
                    {
                        datosPlato.Modificar_Plato(plato);
                        MessageBox.Show("Plato modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        esActualizar = false;
                    }
                    else
                    {
                        datosPlato.Agregar_Plato(plato);
                        MessageBox.Show("Plato guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    LimpiarCampos();
                    ActualizarTablaPlatos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar plato: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_plato_eliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView_Plato.SelectedRows.Count > 0)
            {
                string idPlato = dataGridView_Plato.SelectedRows[0].Cells["ID_Plato"].Value.ToString();

                if (MessageBox.Show("¿Está seguro de que desea eliminar este plato?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        datosPlato.Eliminar_Plato(idPlato);
                        MessageBox.Show("Plato eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ActualizarTablaPlatos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar plato: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un plato para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void txt_plato_buscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string filtro = txt_plato_buscar.Text.Trim();

                if (!string.IsNullOrEmpty(filtro))
                {
                    DataTable dtPlatos = datosPlato.Cargar_Plato(); // Método que carga todos los platos
                    DataView dv = dtPlatos.DefaultView;

                    // Aplica el filtro al campo "Nom_Plato"
                    dv.RowFilter = $"Nom_Plato LIKE '%{filtro}%'";
                    dataGridView_Plato.DataSource = dv;
                }
                else
                {
                    // Si el filtro está vacío, recarga todos los datos
                    ActualizarTablaPlatos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar los platos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_Plato_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                esActualizar = true;
                txt_plato_cod.Text = dataGridView_Plato.Rows[e.RowIndex].Cells["ID_Plato"].Value.ToString();
                txt_plato_nom.Text = dataGridView_Plato.Rows[e.RowIndex].Cells["Nom_Plato"].Value.ToString();
                txt_plato_des.Text = dataGridView_Plato.Rows[e.RowIndex].Cells["Des_Plato"].Value.ToString();
                txt_plato_pre.Text = dataGridView_Plato.Rows[e.RowIndex].Cells["Precio_Original"].Value.ToString();
                cbx_promocion_cod.SelectedValue = dataGridView_Plato.Rows[e.RowIndex].Cells["ID_Promocion"].Value.ToString();
            }
        }

        private void ActualizarTablaPlatos()
        {
            try
            {
                dataGridView_Plato.DataSource = datosPlato.Cargar_Plato();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los platos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarPromociones()
        {
            try
            {
                DataTable dtPromociones = datosPlato.Cargar_Promociones();

                // Crear una nueva fila para "Sin Promoción"
                DataRow row = dtPromociones.NewRow();
                row["ID_Promocion"] = DBNull.Value; // Representa "Sin Promoción"
                row["Nom_Promocion"] = "Sin Promoción";

                // Insertar la fila al inicio del DataTable
                dtPromociones.Rows.InsertAt(row, 0);

                // Asignar el DataTable al ComboBox
                cbx_promocion_cod.DataSource = dtPromociones;
                cbx_promocion_cod.DisplayMember = "Nom_Promocion";
                cbx_promocion_cod.ValueMember = "ID_Promocion";
                cbx_promocion_cod.SelectedIndex = 0; // Seleccionar "Sin Promoción" por defecto
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las promociones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txt_plato_cod.Clear();
            txt_plato_nom.Clear();
            txt_plato_des.Clear();
            txt_plato_pre.Clear();
            cbx_promocion_cod.SelectedIndex = -1;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txt_plato_cod.Text) ||
                string.IsNullOrWhiteSpace(txt_plato_nom.Text) ||
                string.IsNullOrWhiteSpace(txt_plato_des.Text) ||
                string.IsNullOrWhiteSpace(txt_plato_pre.Text) ||
                cbx_promocion_cod.SelectedIndex == -1)
            {
                MessageBox.Show("Complete todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(txt_plato_pre.Text, out _))
            {
                MessageBox.Show("Ingrese un precio válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void dataGridView_Plato_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbx_promocion_cod_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
