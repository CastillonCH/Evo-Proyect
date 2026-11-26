using System;
using System.Data;
using System.Windows.Forms;
using DATOS;
using ENTIDADES;

namespace RESTAURANTEFINAL
{
    public partial class Plato : Form
    {
        private DATOS_PLATO datosPlato = new DATOS_PLATO();
        private bool esActualizar = false;

        public Plato()
        {
            InitializeComponent();
            Estilo.Aplicar(this);
        }

        private void Plato_Load(object sender, EventArgs e)
        {
            CargarPromociones();
            ActualizarTablaPlatos();
            LimpiarCampos();
        }

        private void btn_plato_guardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

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
                }
                else
                {
                    datosPlato.Agregar_Plato(plato);
                    MessageBox.Show("Plato guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ActualizarTablaPlatos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar plato: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_plato_nuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btn_plato_eliminar_Click(object sender, EventArgs e)
        {
            if (!esActualizar)
            {
                MessageBox.Show("Por favor, seleccione un plato para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Está seguro de que desea eliminar este plato?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                datosPlato.Eliminar_Plato(txt_plato_cod.Text);
                MessageBox.Show("Plato eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActualizarTablaPlatos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                AyudaCRUD.Mostrar_Error_Eliminar(ex);
            }
        }

        private void txt_plato_buscar_TextChanged(object sender, EventArgs e)
        {
            AyudaCRUD.Buscar(dataGridView_Plato, txt_plato_buscar.Text, "ID_Plato", "Nom_Plato", "Des_Plato", "ID_Promocion");
        }

        private void dataGridView_Plato_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            esActualizar = true;
            DataGridViewRow fila = dataGridView_Plato.Rows[e.RowIndex];
            txt_plato_cod.Text = fila.Cells["ID_Plato"].Value.ToString();
            txt_plato_nom.Text = fila.Cells["Nom_Plato"].Value.ToString();
            txt_plato_des.Text = fila.Cells["Des_Plato"].Value.ToString();
            txt_plato_pre.Text = fila.Cells["Prec_Original"].Value.ToString();
            if (fila.Cells["ID_Promocion"].Value == DBNull.Value)
                cbx_promocion_cod.SelectedIndex = 0;   // "Sin Promoción"
            else
                cbx_promocion_cod.SelectedValue = fila.Cells["ID_Promocion"].Value.ToString();
            btn_plato_guardar.Text = "Actualizar";
        }

        private void ActualizarTablaPlatos()
        {
            try
            {
                dataGridView_Plato.DataSource = datosPlato.Cargar_Plato();
                AyudaCRUD.Encabezados(dataGridView_Plato, "ID_Plato", "Código", "Nom_Plato", "Producto", "Des_Plato", "Descripción",
                                      "Prec_Original", "Precio (S/)", "ID_Promocion", "Promoción");
                txt_plato_buscar_TextChanged(null, EventArgs.Empty);
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

                // Primera opción: "Sin Promoción"
                DataRow row = dtPromociones.NewRow();
                row["ID_Promocion"] = DBNull.Value;
                row["Nom_Promocion"] = "Sin Promoción";
                dtPromociones.Rows.InsertAt(row, 0);

                cbx_promocion_cod.DataSource = dtPromociones;
                cbx_promocion_cod.DisplayMember = "Nom_Promocion";
                cbx_promocion_cod.ValueMember = "ID_Promocion";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las promociones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sale del modo edición y genera el siguiente código (D001, D002, ...)
        private void LimpiarCampos()
        {
            esActualizar = false;
            btn_plato_guardar.Text = "Guardar";
            txt_plato_nom.Clear();
            txt_plato_des.Clear();
            txt_plato_pre.Clear();
            if (cbx_promocion_cod.Items.Count > 0)
                cbx_promocion_cod.SelectedIndex = 0;
            DataTable tabla = dataGridView_Plato.DataSource as DataTable;
            txt_plato_cod.Text = tabla == null ? "" : AyudaCRUD.Siguiente_Codigo(tabla, "ID_Plato", "D", 3);
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

            decimal precio;
            if (!decimal.TryParse(txt_plato_pre.Text, out precio) || precio <= 0)
            {
                MessageBox.Show("Ingrese un precio válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
