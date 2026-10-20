using System.Windows.Forms;

namespace RESTAURANTEFINAL
{
    // Agrupa dos o más pantallas en pestañas (ej. "Productos y Promociones")
    public partial class FrmPestanas : Form
    {
        public FrmPestanas()
        {
            InitializeComponent();
        }

        public void Agregar_Pestana(string titulo, Form formulario)
        {
            TabPage pestana = new TabPage(titulo);
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            pestana.Controls.Add(formulario);
            tabPestanas.TabPages.Add(pestana);
            formulario.Show();
        }
    }
}
