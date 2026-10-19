using System.Drawing;
using System.Windows.Forms;

namespace RESTAURANTEFINAL
{
    // Colores y fuentes de SPYC:I en un solo lugar (barra negra + acento naranja/amarillo)
    public static class Estilo
    {
        public static readonly Color Negro = Color.FromArgb(18, 18, 18);
        public static readonly Color GrisOscuro = Color.FromArgb(66, 66, 66);
        public static readonly Color Acento = Color.FromArgb(255, 152, 0);        // naranja
        public static readonly Color AcentoClaro = Color.FromArgb(255, 193, 7);   // amarillo
        public static readonly Color Fondo = Color.FromArgb(245, 245, 245);
        public static readonly Color Rojo = Color.FromArgb(211, 47, 47);
        public static readonly Color RojoClaro = Color.FromArgb(255, 205, 210);
        public static readonly Color Verde = Color.FromArgb(56, 142, 60);

        public static readonly Font Fuente = new Font("Segoe UI", 10F);
        public static readonly Font FuenteNegrita = new Font("Segoe UI", 10F, FontStyle.Bold);

        // Estilo uniforme para las pantallas de Administración (sin cambiar su diseño)
        public static void Aplicar(Control contenedor)
        {
            contenedor.BackColor = Fondo;
            foreach (Control control in contenedor.Controls)
            {
                Button boton = control as Button;
                DataGridView grid = control as DataGridView;
                if (boton != null)
                    Boton(boton, boton.Text.Contains("Guardar") ? Acento : boton.Text.Contains("Eliminar") ? Rojo : GrisOscuro);
                else if (grid != null)
                    Grid(grid);
                else if (control is GroupBox || control is Panel)
                    Aplicar(control);
            }
        }

        public static void Boton(Button boton, Color color)
        {
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.BackColor = color;
            boton.ForeColor = color == Acento || color == AcentoClaro ? Negro : Color.White;
            boton.FlatAppearance.MouseOverBackColor = ControlPaint.Light(color, 0.3f);
            boton.Font = FuenteNegrita;
            boton.Cursor = Cursors.Hand;
        }

        public static void Grid(DataGridView grid)
        {
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Negro;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = FuenteNegrita;
            grid.ColumnHeadersHeight = 32;
            grid.DefaultCellStyle.Font = Fuente;
            grid.DefaultCellStyle.SelectionBackColor = AcentoClaro;
            grid.DefaultCellStyle.SelectionForeColor = Negro;
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);
            grid.RowHeadersVisible = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.ReadOnly = true;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.DataBindingComplete += (s, e) => grid.ClearSelection();   // sin fila preseleccionada
        }
    }
}
