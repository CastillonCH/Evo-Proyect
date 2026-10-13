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
    public partial class Empleado : Form
    {
        private DATOS_EMPLEADO datosEmpleado = new DATOS_EMPLEADO();
        private bool esActualizar = false;
        public Empleado()
        {
            InitializeComponent();
        }

        private void Empleado_Load(object sender, EventArgs e)
        {
            ActualizarTablaEmpleados();
            CargarRoles();
        }

        private void btn_empleado_guardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                try
                {
                    ENTIDAD_EMPLEADO empleado = new ENTIDAD_EMPLEADO
                    {
                        ID_Empleado = txt_empleado_cod.Text.Trim(),
                        Nombre = txt_empleado_nom.Text.Trim(),
                        Apellido = txt_empleado_ape.Text.Trim(),
                        Telefono = txt_empleado_tel.Text.Trim(),
                        Email = txt_empleado_email.Text.Trim(),
                        Fec_Contratacion = dtp_fecha_contra.Value,
                        ID_Rol = cbx_empleado_cod.SelectedValue.ToString() // Suponiendo que tienes un ComboBox para los roles
                    };

                    if (esActualizar)
                    {
                        datosEmpleado.Modificar_Empleado(empleado);
                        MessageBox.Show("Empleado modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        esActualizar = false;
                    }
                    else
                    {
                        datosEmpleado.Agregar_Empleado(empleado);
                        MessageBox.Show("Empleado guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    LimpiarCampos();
                    ActualizarTablaEmpleados();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_empleado_eliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView_Empleado.SelectedRows.Count > 0)
            {
                string idEmpleado = dataGridView_Empleado.SelectedRows[0].Cells["ID_Empleado"].Value.ToString();

                if (MessageBox.Show("¿Está seguro de que desea eliminar este empleado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        datosEmpleado.Eliminar_Empleado(idEmpleado);
                        MessageBox.Show("Empleado eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ActualizarTablaEmpleados();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un empleado para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt_empleado_buscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string filtro = txt_empleado_buscar.Text.Trim();

                if (!string.IsNullOrEmpty(filtro))
                {
                    DataTable dtEmpleados = datosEmpleado.Cargar_Empleado(); // Método que carga todos los empleados
                    DataView dv = dtEmpleados.DefaultView;

                    // Aplica el filtro al campo "Nombre" o cualquier otro campo
                    dv.RowFilter = $"Nombre LIKE '%{filtro}%' OR Apellido LIKE '%{filtro}%'";
                    dataGridView_Empleado.DataSource = dv;
                }
                else
                {
                    // Si el filtro está vacío, recarga todos los datos
                    ActualizarTablaEmpleados();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar los empleados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_Empleado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                esActualizar = true;
                txt_empleado_cod.Text = dataGridView_Empleado.Rows[e.RowIndex].Cells["ID_Empleado"].Value.ToString();
                txt_empleado_nom.Text = dataGridView_Empleado.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                txt_empleado_ape.Text = dataGridView_Empleado.Rows[e.RowIndex].Cells["Apellido"].Value.ToString();
                txt_empleado_tel.Text = dataGridView_Empleado.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
                txt_empleado_email.Text = dataGridView_Empleado.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                dtp_fecha_contra.Value = Convert.ToDateTime(dataGridView_Empleado.Rows[e.RowIndex].Cells["Fec_Contratacion"].Value);
                cbx_empleado_cod.SelectedValue = dataGridView_Empleado.Rows[e.RowIndex].Cells["ID_Rol"].Value.ToString();
            }
        }
        private void ActualizarTablaEmpleados()
        {
            try
            {
                dataGridView_Empleado.DataSource = datosEmpleado.Cargar_Empleado();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los empleados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txt_empleado_cod.Clear();
            txt_empleado_nom.Clear();
            txt_empleado_ape.Clear();
            txt_empleado_tel.Clear();
            txt_empleado_email.Clear();
            dtp_fecha_contra.Value = DateTime.Now;
            cbx_empleado_cod.SelectedIndex = -1;
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
                DataTable dtRoles = datosEmpleado.Cargar_Roles(); // Cargar los roles desde la base de datos

                cbx_empleado_cod.DataSource = dtRoles;
                cbx_empleado_cod.DisplayMember = "Nom_Rol"; // Mostrar el nombre del rol
                cbx_empleado_cod.ValueMember = "ID_Rol"; // Almacenar el ID del rol
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
