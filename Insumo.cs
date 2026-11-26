using System;
using System.Data;
using System.Windows.Forms;
using DATOS;
using ENTIDADES;

namespace RESTAURANTEFINAL
{
    public partial class Insumo : Form
    {
        private DATOS_INSUMO datosInsumo = new DATOS_INSUMO();
        private bool esActualizar = false;

        public Insumo()
        {
            InitializeComponent();
            Estilo.Aplicar(this);
        }

        private void Insumo_Load(object sender, EventArgs e)
        {
            CargarUnidadMedida();
            CargarClasificacion();
            ActualizarTablaInsumos();
            LimpiarCampos();
        }

        private void btn_insumo_guardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

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
                }
                else
                {
                    datosInsumo.Agregar_Insumo(insumo);
                    MessageBox.Show("Insumo guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ActualizarTablaInsumos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar insumo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_insumo_nuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btn_insumo_eliminar_Click(object sender, EventArgs e)
        {
            if (!esActualizar)
            {
                MessageBox.Show("Por favor, seleccione un insumo para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Está seguro de que desea eliminar este insumo?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                datosInsumo.Eliminar_Insumo(txt_insumo_cod.Text);
                MessageBox.Show("Insumo eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActualizarTablaInsumos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                AyudaCRUD.Mostrar_Error_Eliminar(ex);
            }
        }

        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            esActualizar = true;
            DataGridViewRow fila = dataGridView_Insumo.Rows[e.RowIndex];
            txt_insumo_cod.Text = fila.Cells["ID_Insumo"].Value.ToString();
            txt_insumo_nom.Text = fila.Cells["Nombre"].Value.ToString();
            cbx_insumo_uni_med_cod.SelectedValue = fila.Cells["ID_Unidad_Medida"].Value.ToString();
            txt_insumo_prec_unitario.Text = fila.Cells["Precio_Unitario"].Value.ToString();
            cbx_insumo_clasi_cod.SelectedValue = fila.Cells["ID_Clasificacion"].Value.ToString();
            btn_insumo_guardar.Text = "Actualizar";
        }

        private void txt_insumo_buscar_TextChanged(object sender, EventArgs e)
        {
            AyudaCRUD.Buscar(dataGridView_Insumo, txt_insumo_buscar.Text, "ID_Insumo", "Nombre", "ID_Unidad_Medida", "ID_Clasificacion");
        }

        private void CargarUnidadMedida()
        {
            try
            {
                cbx_insumo_uni_med_cod.DataSource = datosInsumo.Cargar_Unidad_Medida();
                cbx_insumo_uni_med_cod.DisplayMember = "Nom_Unidad_Medida";
                cbx_insumo_uni_med_cod.ValueMember = "ID_Unidad_Medida";
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
                cbx_insumo_clasi_cod.DataSource = datosInsumo.Cargar_Clasificacion();
                cbx_insumo_clasi_cod.DisplayMember = "Nom_Clasificacion";
                cbx_insumo_clasi_cod.ValueMember = "ID_Clasificacion";
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
                AyudaCRUD.Encabezados(dataGridView_Insumo, "ID_Insumo", "Código", "Nombre", "Insumo", "ID_Unidad_Medida", "Unidad",
                                      "Precio_Unitario", "Precio unit. (S/)", "ID_Clasificacion", "Clasificación");
                txt_insumo_buscar_TextChanged(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los insumos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sale del modo edición y genera el siguiente código (I001, I002, ...)
        private void LimpiarCampos()
        {
            esActualizar = false;
            btn_insumo_guardar.Text = "Guardar";
            txt_insumo_nom.Clear();
            txt_insumo_prec_unitario.Clear();
            cbx_insumo_uni_med_cod.SelectedIndex = -1;
            cbx_insumo_clasi_cod.SelectedIndex = -1;
            DataTable tabla = dataGridView_Insumo.DataSource as DataTable;
            txt_insumo_cod.Text = tabla == null ? "" : AyudaCRUD.Siguiente_Codigo(tabla, "ID_Insumo", "I", 3);
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

            decimal precio;
            if (!decimal.TryParse(txt_insumo_prec_unitario.Text, out precio) || precio < 0)
            {
                MessageBox.Show("Ingrese un precio válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
