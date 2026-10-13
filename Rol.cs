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
        }

        private void Rol_Load(object sender, EventArgs e)
        {
            ActualizarTablaRoles();
            CargarDepartamentos();
        }

        private void btn_rol_guardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
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
                        esActualizar = false;
                    }
                    else
                    {
                        datosRol.Agregar_Rol(rol);
                        MessageBox.Show("Rol guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    LimpiarCampos();
                    ActualizarTablaRoles();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar rol: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_rol_eliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView_Rol.SelectedRows.Count > 0)
            {
                string idRol = dataGridView_Rol.SelectedRows[0].Cells["ID_Rol"].Value.ToString();

                if (MessageBox.Show("¿Está seguro de que desea eliminar este rol?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        datosRol.Eliminar_Rol(idRol);
                        MessageBox.Show("Rol eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ActualizarTablaRoles();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar rol: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un rol para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void txt_rol_buscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string filtro = txt_rol_buscar.Text.Trim();

                if (!string.IsNullOrEmpty(filtro))
                {
                    DataTable dtRoles = datosRol.Cargar_Roles(); // Método que carga todos los roles
                    DataView dv = dtRoles.DefaultView;

                    // Aplica el filtro al campo "Nom_Rol"
                    dv.RowFilter = $"Nom_Rol LIKE '%{filtro}%'";
                    dataGridView_Rol.DataSource = dv;
                }
                else
                {
                    // Si el filtro está vacío, recarga todos los datos
                    ActualizarTablaRoles();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar los roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_Rol_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                esActualizar = true;
                txt_rol_cod.Text = dataGridView_Rol.Rows[e.RowIndex].Cells["ID_Rol"].Value.ToString();
                txt_rol_nom.Text = dataGridView_Rol.Rows[e.RowIndex].Cells["Nom_Rol"].Value.ToString();
              
                txt_rol_sal.Text = dataGridView_Rol.Rows[e.RowIndex].Cells["Salario"].Value.ToString();
                cbx_departamento_cod.SelectedValue = dataGridView_Rol.Rows[e.RowIndex].Cells["ID_Departamento"].Value.ToString();
            }
        }
        // Actualizar la tabla de roles
        private void ActualizarTablaRoles()
        {
            try
            {
                dataGridView_Rol.DataSource = datosRol.Cargar_Roles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cargar los departamentos en el combo box
        private void CargarDepartamentos()
        {
            try
            {
                DataTable dtDepartamentos = datosRol.Cargar_Departamentos();

                cbx_departamento_cod.DataSource = dtDepartamentos;
                cbx_departamento_cod.DisplayMember = "Nom_Departamento";
                cbx_departamento_cod.ValueMember = "ID_Departamento";
                cbx_departamento_cod.SelectedIndex = -1; // Ningún valor seleccionado por defecto
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los departamentos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Limpiar los campos del formulario
        private void LimpiarCampos()
        {
            txt_rol_cod.Clear();
            txt_rol_nom.Clear();
          
            txt_rol_sal.Clear();
            cbx_departamento_cod.SelectedIndex = -1;
        }

        // Validar los campos del formulario
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

            if (!decimal.TryParse(txt_rol_sal.Text, out _))
            {
                MessageBox.Show("Ingrese un salario válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
