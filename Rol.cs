using System;
using System.Data;
using System.Windows.Forms;
using DATOS;
using ENTIDADES;

namespace RESTAURANTEFINAL
{
    public partial class Rol : Form
    {
        private DATOS_ROL datosRol = new DATOS_ROL();
        private bool esActualizar = false;

        public Rol()
        {
            InitializeComponent();
            Estilo.Aplicar(this);
        }

        private void Rol_Load(object sender, EventArgs e)
        {
            CargarDepartamentos();
            ActualizarTablaRoles();
            LimpiarCampos();
        }

        private void btn_rol_guardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                ENTIDAD_ROL rol = new ENTIDAD_ROL
                {
                    ID_Rol = txt_rol_cod.Text.Trim(),
                    Nom_Rol = txt_rol_nom.Text.Trim(),
                    Salario = decimal.Parse(txt_rol_sal.Text.Trim()),
                    ID_Departamento = cbx_departamento_cod.SelectedValue.ToString()
                };

                if (esActualizar)
                {
                    datosRol.Modificar_Rol(rol);
                    MessageBox.Show("Rol modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    datosRol.Agregar_Rol(rol);
                    MessageBox.Show("Rol guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ActualizarTablaRoles();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar rol: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_rol_nuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btn_rol_eliminar_Click(object sender, EventArgs e)
        {
            if (!esActualizar)
            {
                MessageBox.Show("Por favor, seleccione un rol para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Está seguro de que desea eliminar este rol?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                datosRol.Eliminar_Rol(txt_rol_cod.Text);
                MessageBox.Show("Rol eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActualizarTablaRoles();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                AyudaCRUD.Mostrar_Error_Eliminar(ex);
            }
        }

        private void txt_rol_buscar_TextChanged(object sender, EventArgs e)
        {
            AyudaCRUD.Buscar(dataGridView_Rol, txt_rol_buscar.Text, "ID_Rol", "Nom_Rol", "ID_Departamento");
        }

        private void dataGridView_Rol_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            esActualizar = true;
            DataGridViewRow fila = dataGridView_Rol.Rows[e.RowIndex];
            txt_rol_cod.Text = fila.Cells["ID_Rol"].Value.ToString();
            txt_rol_nom.Text = fila.Cells["Nom_Rol"].Value.ToString();
            txt_rol_sal.Text = fila.Cells["Salario"].Value.ToString();
            cbx_departamento_cod.SelectedValue = fila.Cells["ID_Departamento"].Value.ToString();
            btn_rol_guardar.Text = "Actualizar";
        }

        private void ActualizarTablaRoles()
        {
            try
            {
                dataGridView_Rol.DataSource = datosRol.Cargar_Roles();
                AyudaCRUD.Encabezados(dataGridView_Rol, "ID_Rol", "Código", "ID_Departamento", "Departamento",
                                      "Nom_Rol", "Rol", "Salario", "Salario (S/)");
                txt_rol_buscar_TextChanged(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDepartamentos()
        {
            try
            {
                cbx_departamento_cod.DataSource = datosRol.Cargar_Departamentos();
                cbx_departamento_cod.DisplayMember = "Nom_Departamento";
                cbx_departamento_cod.ValueMember = "ID_Departamento";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los departamentos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sale del modo edición y genera el siguiente código (R001, R002, ...)
        private void LimpiarCampos()
        {
            esActualizar = false;
            btn_rol_guardar.Text = "Guardar";
            txt_rol_nom.Clear();
            txt_rol_sal.Clear();
            cbx_departamento_cod.SelectedIndex = -1;
            DataTable tabla = dataGridView_Rol.DataSource as DataTable;
            txt_rol_cod.Text = tabla == null ? "" : AyudaCRUD.Siguiente_Codigo(tabla, "ID_Rol", "R", 3);
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txt_rol_cod.Text) ||
                string.IsNullOrWhiteSpace(txt_rol_nom.Text) ||
                string.IsNullOrWhiteSpace(txt_rol_sal.Text) ||
                cbx_departamento_cod.SelectedIndex == -1)
            {
                MessageBox.Show("Complete todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            decimal salario;
            if (!decimal.TryParse(txt_rol_sal.Text, out salario) || salario < 0)
            {
                MessageBox.Show("Ingrese un salario válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
