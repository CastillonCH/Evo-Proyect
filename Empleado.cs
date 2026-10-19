using System;
using System.Data;
using System.Windows.Forms;
using DATOS;
using ENTIDADES;

namespace RESTAURANTEFINAL
{
    public partial class Empleado : Form
    {
        private DATOS_EMPLEADO datosEmpleado = new DATOS_EMPLEADO();
        private bool esActualizar = false;

        public Empleado()
        {
            InitializeComponent();
            Estilo.Aplicar(this);
        }

        private void Empleado_Load(object sender, EventArgs e)
        {
            CargarRoles();
            ActualizarTablaEmpleados();
            LimpiarCampos();
        }

        private void btn_empleado_guardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                ENTIDAD_EMPLEADO empleado = new ENTIDAD_EMPLEADO
                {
                    ID_Empleado = txt_empleado_cod.Text.Trim(),
                    Nombre = txt_empleado_nom.Text.Trim(),
                    Apellido = txt_empleado_ape.Text.Trim(),
                    Telefono = txt_empleado_tel.Text.Trim(),
                    Email = txt_empleado_email.Text.Trim(),
                    Fec_Contratacion = dtp_fecha_contra.Value.Date,
                    ID_Rol = cbx_empleado_cod.SelectedValue.ToString()
                };

                if (esActualizar)
                {
                    datosEmpleado.Modificar_Empleado(empleado);
                    MessageBox.Show("Empleado modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    datosEmpleado.Agregar_Empleado(empleado);
                    MessageBox.Show("Empleado guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ActualizarTablaEmpleados();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_empleado_nuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btn_empleado_eliminar_Click(object sender, EventArgs e)
        {
            if (!esActualizar)
            {
                MessageBox.Show("Por favor, seleccione un empleado para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Está seguro de que desea eliminar este empleado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                datosEmpleado.Eliminar_Empleado(txt_empleado_cod.Text);
                MessageBox.Show("Empleado eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActualizarTablaEmpleados();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                AyudaCRUD.Mostrar_Error_Eliminar(ex);
            }
        }

        private void txt_empleado_buscar_TextChanged(object sender, EventArgs e)
        {
            AyudaCRUD.Buscar(dataGridView_Empleado, txt_empleado_buscar.Text,
                             "ID_Empleado", "Nombre", "Apellido", "Telefono", "Email", "ID_Rol");
        }

        private void dataGridView_Empleado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            esActualizar = true;
            DataGridViewRow fila = dataGridView_Empleado.Rows[e.RowIndex];
            txt_empleado_cod.Text = fila.Cells["ID_Empleado"].Value.ToString();
            txt_empleado_nom.Text = fila.Cells["Nombre"].Value.ToString();
            txt_empleado_ape.Text = fila.Cells["Apellido"].Value.ToString();
            txt_empleado_tel.Text = fila.Cells["Telefono"].Value.ToString();
            txt_empleado_email.Text = fila.Cells["Email"].Value.ToString();
            dtp_fecha_contra.Value = Convert.ToDateTime(fila.Cells["Fec_Contratacion"].Value);
            cbx_empleado_cod.SelectedValue = fila.Cells["ID_Rol"].Value.ToString();
            btn_empleado_guardar.Text = "Actualizar";
        }

        private void ActualizarTablaEmpleados()
        {
            try
            {
                dataGridView_Empleado.DataSource = datosEmpleado.Cargar_Empleado();
                AyudaCRUD.Encabezados(dataGridView_Empleado, "ID_Empleado", "Código", "Nombre", "Nombres", "Apellido", "Apellidos",
                                      "Telefono", "Teléfono", "Email", "Email", "Fec_Contratacion", "Contratación", "ID_Rol", "Rol");
                txt_empleado_buscar_TextChanged(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los empleados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sale del modo edición y genera el siguiente código (E0001, E0002, ...)
        private void LimpiarCampos()
        {
            esActualizar = false;
            btn_empleado_guardar.Text = "Guardar";
            txt_empleado_nom.Clear();
            txt_empleado_ape.Clear();
            txt_empleado_tel.Clear();
            txt_empleado_email.Clear();
            dtp_fecha_contra.Value = DateTime.Today;
            cbx_empleado_cod.SelectedIndex = -1;
            DataTable tabla = dataGridView_Empleado.DataSource as DataTable;
            txt_empleado_cod.Text = tabla == null ? "" : AyudaCRUD.Siguiente_Codigo(tabla, "ID_Empleado", "E", 4);
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txt_empleado_cod.Text) ||
                string.IsNullOrWhiteSpace(txt_empleado_nom.Text) ||
                string.IsNullOrWhiteSpace(txt_empleado_ape.Text) ||
                string.IsNullOrWhiteSpace(txt_empleado_tel.Text) ||
                string.IsNullOrWhiteSpace(txt_empleado_email.Text) ||
                cbx_empleado_cod.SelectedIndex == -1)
            {
                MessageBox.Show("Complete todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!txt_empleado_email.Text.Contains("@"))
            {
                MessageBox.Show("Ingrese un correo válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void CargarRoles()
        {
            try
            {
                cbx_empleado_cod.DataSource = datosEmpleado.Cargar_Roles();
                cbx_empleado_cod.DisplayMember = "Nom_Rol";
                cbx_empleado_cod.ValueMember = "ID_Rol";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
