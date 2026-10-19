using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using DATOS;
using ENTIDADES;

namespace RESTAURANTEFINAL
{
    // Recetas: qué insumos (y cuánto, en la unidad del insumo) lleva cada plato
    public partial class Plato_Insumo : Form
    {
        private DATOS_PLATO_INSUMO datosPlatoInsumo = new DATOS_PLATO_INSUMO();
        private bool esActualizar = false;

        public Plato_Insumo()
        {
            InitializeComponent();
            Estilo.Aplicar(this);
        }

        private void Plato_Insumo_Load(object sender, EventArgs e)
        {
            CargarPlatosInsumos();
            ActualizarTablaPlatoInsumo();
            LimpiarCampos();
        }

        private void btn_plato_insumo_guardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                ENTIDAD_PLATO_INSUMO platoInsumo = new ENTIDAD_PLATO_INSUMO
                {
                    ID_Plato = cbx_plato_cod.SelectedValue.ToString(),
                    ID_Insumo = cbx_insumo_cod.SelectedValue.ToString(),
                    Cant_Necesaria = LeerCantidad(),   // en la unidad del insumo (ej. 0.25 kg)
                    Procedimiento = txt_plato_insumo_proc.Text.Trim()
                };

                if (esActualizar)
                {
                    datosPlatoInsumo.Modificar_PlatoInsumo(platoInsumo);
                    MessageBox.Show("Receta modificada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    datosPlatoInsumo.Agregar_PlatoInsumo(platoInsumo);
                    MessageBox.Show("Insumo agregado a la receta.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ActualizarTablaPlatoInsumo();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la receta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_plato_insumo_nuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btn_plato_insumo_eliminar_Click(object sender, EventArgs e)
        {
            if (!esActualizar)
            {
                MessageBox.Show("Por favor, seleccione un insumo de la receta para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Está seguro de que desea quitar este insumo de la receta?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                datosPlatoInsumo.Eliminar_PlatoInsumo(cbx_plato_cod.SelectedValue.ToString(), cbx_insumo_cod.SelectedValue.ToString());
                MessageBox.Show("Insumo quitado de la receta.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActualizarTablaPlatoInsumo();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                AyudaCRUD.Mostrar_Error_Eliminar(ex);
            }
        }

        private void txt_plato_insumo_buscar_TextChanged(object sender, EventArgs e)
        {
            AyudaCRUD.Buscar(dataGridView_Plato_Insumo, txt_plato_insumo_buscar.Text,
                             "ID_Plato", "Nom_Plato", "ID_Insumo", "Nom_Insumo", "Procedimiento");
        }

        private void dataGridView_Plato_Insumo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            // Modo edición: plato e insumo son la clave, no se pueden cambiar
            esActualizar = true;
            DataGridViewRow fila = dataGridView_Plato_Insumo.Rows[e.RowIndex];
            cbx_plato_cod.SelectedValue = fila.Cells["ID_Plato"].Value.ToString();
            cbx_insumo_cod.SelectedValue = fila.Cells["ID_Insumo"].Value.ToString();
            txt_plato_insumo_cant.Text = fila.Cells["Cant_Necesaria"].Value == DBNull.Value ? ""
                : Convert.ToDecimal(fila.Cells["Cant_Necesaria"].Value).ToString("0.###", CultureInfo.InvariantCulture);
            txt_plato_insumo_proc.Text = fila.Cells["Procedimiento"].Value.ToString();
            cbx_plato_cod.Enabled = false;
            cbx_insumo_cod.Enabled = false;
            btn_plato_insumo_guardar.Text = "Actualizar";
        }

        private void ActualizarTablaPlatoInsumo()
        {
            try
            {
                dataGridView_Plato_Insumo.DataSource = datosPlatoInsumo.Cargar_PlatoInsumo();
                AyudaCRUD.Encabezados(dataGridView_Plato_Insumo, "ID_Plato", "Cód. plato", "Nom_Plato", "Plato",
                                      "ID_Insumo", "Cód. insumo", "Nom_Insumo", "Insumo", "Cant_Necesaria", "Cantidad",
                                      "Unidad", "Unidad", "Procedimiento", "Procedimiento");
                txt_plato_insumo_buscar_TextChanged(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las recetas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos()
        {
            if (cbx_plato_cod.SelectedIndex == -1 || cbx_insumo_cod.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txt_plato_insumo_proc.Text))
            {
                MessageBox.Show("Complete todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (LeerCantidad() <= 0)
            {
                MessageBox.Show("Ingrese una cantidad numérica mayor a cero, en la unidad del insumo (ej. 0.25 kg).",
                                "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // Acepta punto o coma decimal; devuelve 0 si el texto no es un número
        private decimal LeerCantidad()
        {
            decimal cantidad;
            string texto = txt_plato_insumo_cant.Text.Trim().Replace(',', '.');
            return decimal.TryParse(texto, NumberStyles.Number, CultureInfo.InvariantCulture, out cantidad) ? cantidad : 0m;
        }

        private void LimpiarCampos()
        {
            esActualizar = false;
            btn_plato_insumo_guardar.Text = "Guardar";
            cbx_plato_cod.Enabled = true;
            cbx_insumo_cod.Enabled = true;
            txt_plato_insumo_cant.Clear();
            txt_plato_insumo_proc.Clear();
            cbx_plato_cod.SelectedIndex = -1;
            cbx_insumo_cod.SelectedIndex = -1;
        }

        private void CargarPlatosInsumos()
        {
            try
            {
                cbx_plato_cod.DisplayMember = "Nom_Plato";
                cbx_plato_cod.ValueMember = "ID_Plato";
                cbx_plato_cod.DataSource = datosPlatoInsumo.CargarPlatos();

                cbx_insumo_cod.DisplayMember = "Nombre";
                cbx_insumo_cod.ValueMember = "ID_Insumo";
                cbx_insumo_cod.DataSource = datosPlatoInsumo.CargarInsumos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar platos e insumos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
