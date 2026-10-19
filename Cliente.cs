using System;
using System.Data;
using System.Windows.Forms;
using ENTIDADES;
using NEGOCIO;

namespace RESTAURANTEFINAL
{
    public partial class Cliente : Form
    {
        private const string PREFIJO = "C";   // formato de la BD: C0001
        private const int DIGITOS = 4;

        // SOLID: DIP – el formulario depende de la interfaz IClienteRepositorio, no de DATOS_CLIENTE.
        // Quien lo crea (FrmPrincipal, con FabricaServicios) decide qué implementación usar.
        private readonly IClienteRepositorio _repositorio;
        private bool esActualizar = false;

        public Cliente(IClienteRepositorio repositorio)
        {
            InitializeComponent();
            _repositorio = repositorio;
            Estilo.Aplicar(this);
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            ActualizarTablaClientes();
            LimpiarCampos();
        }

        private void btn_cliente_guardar_Click(object sender, EventArgs e)
        {
            ENTIDAD_CLIENTE cliente = new ENTIDAD_CLIENTE
            {
                ID_Cliente = txt_cliente_cod.Text.Trim(),
                Nom_Cliente = txt_cliente_nom.Text.Trim(),
                Ape_Cliente = txt_cliente_ape.Text.Trim(),
                Tel_Cliente = txt_cliente_tel.Text.Trim(),
                Email = txt_cliente_email.Text.Trim(),
                Dir_Cliente = txt_cliente_dir.Text.Trim()
            };

            // SOLID: SRP – las reglas de validación están en ValidadorCliente (NEGOCIO)
            string error = ValidadorCliente.Validar(cliente);
            if (error != null)
            {
                MessageBox.Show(error, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (esActualizar)
                {
                    _repositorio.Modificar_Cliente(cliente);
                    MessageBox.Show("Cliente modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _repositorio.Agregar_Cliente(cliente);
                    MessageBox.Show("Cliente " + cliente.ID_Cliente + " guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ActualizarTablaClientes();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_cliente_nuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btn_cliente_eliminar_Click(object sender, EventArgs e)
        {
            if (!esActualizar)
            {
                MessageBox.Show("Por favor, seleccione un cliente de la tabla para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Está seguro de que desea eliminar el cliente " + txt_cliente_cod.Text + "?", "Confirmar eliminación",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                _repositorio.Eliminar_Cliente(txt_cliente_cod.Text);
                MessageBox.Show("Cliente eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActualizarTablaClientes();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                // Si tiene pedidos (FK, error 547): "No se puede eliminar: tiene registros asociados"
                AyudaCRUD.Mostrar_Error_Eliminar(ex);
            }
        }

        private void dataGridView_cliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            // Modo edición: el código no se puede cambiar
            esActualizar = true;
            DataGridViewRow fila = dataGridView_cliente.Rows[e.RowIndex];
            txt_cliente_cod.Text = fila.Cells["ID_Cliente"].Value.ToString();
            txt_cliente_nom.Text = fila.Cells["Nom_Cliente"].Value.ToString();
            txt_cliente_ape.Text = fila.Cells["Ape_Cliente"].Value.ToString();
            txt_cliente_tel.Text = fila.Cells["Tel_Cliente"].Value.ToString();
            txt_cliente_email.Text = fila.Cells["Email"].Value.ToString();
            txt_cliente_dir.Text = fila.Cells["Dir_Cliente"].Value.ToString();
            btn_cliente_guardar.Text = "Actualizar";
        }

        private void txt_cliente_buscar_TextChanged(object sender, EventArgs e)
        {
            AyudaCRUD.Buscar(dataGridView_cliente, txt_cliente_buscar.Text,
                             "ID_Cliente", "Nom_Cliente", "Ape_Cliente", "Tel_Cliente", "Email");
        }

        private void ActualizarTablaClientes()
        {
            try
            {
                dataGridView_cliente.DataSource = _repositorio.Cargar_Cliente();
                AyudaCRUD.Encabezados(dataGridView_cliente, "ID_Cliente", "Código", "Nom_Cliente", "Nombres", "Ape_Cliente", "Apellidos",
                                      "Tel_Cliente", "Teléfono", "Email", "Email", "Dir_Cliente", "Dirección");
                txt_cliente_buscar_TextChanged(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sale del modo edición y propone el siguiente código (C0001, C0002, ...)
        private void LimpiarCampos()
        {
            esActualizar = false;
            btn_cliente_guardar.Text = "Guardar";
            txt_cliente_nom.Clear();
            txt_cliente_ape.Clear();
            txt_cliente_tel.Clear();
            txt_cliente_email.Clear();
            txt_cliente_dir.Clear();
            try
            {
                txt_cliente_cod.Text = GeneradorCodigo.Siguiente(_repositorio.Ultimo_Codigo(), PREFIJO, DIGITOS);
            }
            catch (Exception ex)
            {
                txt_cliente_cod.Clear();
                MessageBox.Show("Error al generar el código: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txt_cliente_nom.Focus();
        }
    }
}
