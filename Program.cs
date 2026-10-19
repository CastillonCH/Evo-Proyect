using System;
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

            // Se arman todas las dependencias una sola vez y se pasan a los formularios
            FabricaServicios fabrica = new FabricaServicios();
            Application.Run(new Form1(fabrica));
        }
    }
}
