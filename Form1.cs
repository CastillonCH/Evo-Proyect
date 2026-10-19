    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RESTAURANTEFINAL
{
    public partial class Form1 : Form
    {
        private readonly FabricaServicios _fabrica;

        public Form1(FabricaServicios fabrica)
        {
            InitializeComponent();
            _fabrica = fabrica;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Promocion promocion = new Promocion();
            promocion.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Plato plato = new Plato();
            plato.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Insumo insumo = new Insumo();
            insumo.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Sede sede = new Sede();
            sede.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Empleado empleado = new Empleado();
            empleado.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Rol rol = new Rol();
            rol.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Plato_Insumo plato_insumo = new Plato_Insumo();
            plato_insumo.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Pedido pedido = new Pedido();
            pedido.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Detalle_Pedido detalle = new Detalle_Pedido();
            detalle.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Venta venta = new Venta();
            venta.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_Hora.Text = DateTime.Now.ToLongTimeString();
            lbl_Fecha.Text = DateTime.Now.ToLongDateString();
        }
    }
}
