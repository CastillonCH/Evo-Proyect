using System;
using System.Windows.Forms;
using ENTIDADES;
using NEGOCIO;

namespace RESTAURANTEFINAL
{
    public partial class FrmLogin : Form
    {
        private readonly ServicioAutenticacion _autenticacion;

        // Usuario que inició sesión (lo usa Program.cs para abrir FrmPrincipal)
        public ENTIDAD_USUARIO UsuarioAutenticado { get; private set; }

        // SOLID: DIP – el login recibe el servicio ya armado; no sabe de SQL ni de DATOS_USUARIO
        public FrmLogin(ServicioAutenticacion autenticacion)
        {
            InitializeComponent();
            _autenticacion = autenticacion;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            try
            {
                ENTIDAD_USUARIO usuario = _autenticacion.Iniciar_Sesion(txtUsuario.Text, txtClave.Text);
                if (usuario == null)
                {
                    lblError.Text = "Usuario o contraseña incorrectos.";
                    txtClave.Clear();
                    txtClave.Focus();
                    return;
                }

                UsuarioAutenticado = usuario;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (InvalidOperationException ex)
            {
                lblError.Text = ex.Message;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar con la base de datos. Revise el servidor en App.config.\n\n" + ex.Message,
                                "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
