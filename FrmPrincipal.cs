using System;
using System.Drawing;
using System.Windows.Forms;
using ENTIDADES;

namespace RESTAURANTEFINAL
{
    public partial class FrmPrincipal : Form
    {
        private const string ADMINISTRADOR = "Administrador";
        private const string CAJERO = "Cajero";
        private const string COCINA = "Cocina";

        private readonly ENTIDAD_USUARIO _usuario;
        private readonly FabricaServicios _fabrica;
        private Form _formularioActual;
        private Button _botonActivo;
        private Color _colorBotonActivo;

        // true cuando el usuario presiona "Cerrar sesión" (Program.cs vuelve a mostrar el login)
        public bool Cerrar_Sesion_Solicitado { get; private set; }

        public FrmPrincipal(ENTIDAD_USUARIO usuario, FabricaServicios fabrica)
        {
            InitializeComponent();
            _usuario = usuario;
            _fabrica = fabrica;
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = _usuario.Nombre_Empleado + "  ·  " + _usuario.Perfil + "  ·  " + _usuario.Nom_Sede;
            timerReloj_Tick(null, EventArgs.Empty);
            Configurar_Menu();

            // Cada perfil empieza en su pantalla principal
            if (_usuario.Perfil == CAJERO)
                btnCaja.PerformClick();
            else if (_usuario.Perfil == COCINA)
                btnCocina.PerformClick();
            else
            {
                Mostrar_Alerta_Stock();
                btnReportes.PerformClick();
            }
        }

        // Menú según el perfil del usuario
        private void Configurar_Menu()
        {
            bool admin = _usuario.Perfil == ADMINISTRADOR;
            bool cajero = _usuario.Perfil == CAJERO;
            bool cocina = _usuario.Perfil == COCINA;

            btnCaja.Visible = admin || cajero;
            btnClientes.Visible = admin || cajero;
            btnCocina.Visible = admin || cocina;
            btnInventario.Visible = admin;
            btnReportes.Visible = admin;
            btnAdministracion.Visible = admin;
        }

        private void Mostrar_Alerta_Stock()
        {
            try
            {
                int bajos = _fabrica.Inventario.Contar_Stock_Bajo(null);
                lblAlerta.Visible = bajos > 0;
                lblAlerta.Text = "⚠ " + bajos + " insumo(s) bajo el mínimo";
            }
            catch (Exception)
            {
                lblAlerta.Visible = false;   // la alerta es informativa: si falla no se interrumpe el inicio
            }
        }

        // Abre la pantalla DENTRO del panel derecho (no como ventana suelta)
        private void Abrir_Formulario(Form formulario, string titulo, Button boton)
        {
            if (_formularioActual != null)
                _formularioActual.Close();

            pnlContenido.Controls.Clear();
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            pnlContenido.Controls.Add(formulario);
            formulario.Show();

            _formularioActual = formulario;
            lblTituloPantalla.Text = titulo;
            Marcar_Boton(boton);
        }

        private void Marcar_Boton(Button boton)
        {
            if (_botonActivo != null)
            {
                _botonActivo.BackColor = _colorBotonActivo;
                _botonActivo.ForeColor = Color.White;
            }
            _botonActivo = boton;
            _colorBotonActivo = boton.BackColor;
            _botonActivo.BackColor = Estilo.Acento;
            _botonActivo.ForeColor = Estilo.Negro;
        }

        private void btnCaja_Click(object sender, EventArgs e)
        {
            FrmCaja caja = new FrmCaja(_fabrica.Productos, _fabrica.Clientes, _fabrica.Crear_Servicio_Venta(),
                                       _fabrica.Comprobantes(), _usuario);
            Abrir_Formulario(caja, "Caja", btnCaja);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            Abrir_Formulario(new Cliente(_fabrica.Clientes), "Clientes", btnClientes);
        }

        private void btnCocina_Click(object sender, EventArgs e)
        {
            Abrir_Formulario(new FrmCocina(_fabrica.Pedidos, _usuario), "Cocina", btnCocina);
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            FrmInventario inventario = new FrmInventario(_fabrica.Crear_Servicio_Inventario(), _fabrica.Productos, _usuario);
            Abrir_Formulario(inventario, "Inventario", btnInventario);
        }

        private void lblAlerta_Click(object sender, EventArgs e)
        {
            btnInventario.PerformClick();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            FrmReportes reportes = new FrmReportes(_fabrica.Reportes, _fabrica.Crear_Servicio_Inventario());
            Abrir_Formulario(reportes, "Reportes", btnReportes);
        }

        // Muestra u oculta el submenú de Administración
        private void btnAdministracion_Click(object sender, EventArgs e)
        {
            bool mostrar = !btnProductos.Visible;
            btnProductos.Visible = mostrar;
            btnRecetas.Visible = mostrar;
            btnInsumos.Visible = mostrar;
            btnEmpleados.Visible = mostrar;
            btnSedesRoles.Visible = mostrar;
            btnAdministracion.Text = mostrar ? "Administración  ▴" : "Administración  ▾";
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            FrmPestanas pestanas = new FrmPestanas();
            pestanas.Agregar_Pestana("Productos", new Plato());
            pestanas.Agregar_Pestana("Promociones", new Promocion());
            Abrir_Formulario(pestanas, "Productos y Promociones", btnProductos);
        }

        private void btnRecetas_Click(object sender, EventArgs e)
        {
            Abrir_Formulario(new Plato_Insumo(), "Recetas", btnRecetas);
        }

        private void btnInsumos_Click(object sender, EventArgs e)
        {
            Abrir_Formulario(new Insumo(), "Insumos", btnInsumos);
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            Abrir_Formulario(new Empleado(), "Empleados", btnEmpleados);
        }

        private void btnSedesRoles_Click(object sender, EventArgs e)
        {
            FrmPestanas pestanas = new FrmPestanas();
            pestanas.Agregar_Pestana("Sedes", new Sede());
            pestanas.Agregar_Pestana("Roles", new Rol());
            Abrir_Formulario(pestanas, "Sedes y Roles", btnSedesRoles);
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Cerrar_Sesion_Solicitado = true;
            Close();
        }

        private void timerReloj_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }
    }
}
