using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace RESTAURANTEFINAL
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Un error inesperado se muestra en pantalla sin cerrar la aplicación
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += Error_No_Controlado;

            // Fechas y números en español (Perú) sin depender de la configuración de la PC
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-PE");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-PE");

            // SOLID: DIP – se arman todas las dependencias una sola vez y se pasan a los formularios
            FabricaServicios fabrica = new FabricaServicios();

            // Login → menú principal; al cerrar sesión se vuelve al login
            while (true)
            {
                FrmPrincipal principal;
                using (FrmLogin login = new FrmLogin(fabrica.Crear_Servicio_Autenticacion()))
                {
                    if (login.ShowDialog() != DialogResult.OK)
                        return;
                    principal = new FrmPrincipal(login.UsuarioAutenticado, fabrica);
                }

                Application.Run(principal);
                if (!principal.Cerrar_Sesion_Solicitado)
                    return;
            }
        }

        private static void Error_No_Controlado(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show("Ocurrió un error inesperado:\n\n" + e.Exception.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
