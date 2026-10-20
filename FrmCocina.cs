using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ENTIDADES;
using NEGOCIO;

namespace RESTAURANTEFINAL
{
    // Pedidos del día de la sede en columnas por estado; se actualiza sola cada 10 segundos
    public partial class FrmCocina : Form
    {
        private readonly IPedidoRepositorio _pedidos;
        private readonly ENTIDAD_USUARIO _usuario;

        // SOLID: DIP – Cocina solo conoce IPedidoRepositorio
        public FrmCocina(IPedidoRepositorio pedidos, ENTIDAD_USUARIO usuario)
        {
            InitializeComponent();
            _pedidos = pedidos;
            _usuario = usuario;
            Estilo.Boton(btnActualizar, Estilo.Negro);
        }

        private void FrmCocina_Load(object sender, EventArgs e)
        {
            Refrescar();
            timerRefresco.Start();
        }

        private void timerRefresco_Tick(object sender, EventArgs e)
        {
            Refrescar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Refrescar();
        }

        private void Refrescar()
        {
            List<ENTIDAD_PEDIDO_COCINA> pedidos;
            try
            {
                pedidos = _pedidos.Cargar_Pedidos_Cocina(_usuario.ID_Sede, DateTime.Today);
            }
            catch (Exception ex)
            {
                timerRefresco.Stop();   // evita repetir el mensaje cada 10 segundos
                MessageBox.Show("Error al cargar los pedidos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Llenar_Columna(flpPendiente, lblPendiente, "Pendiente", pedidos.Where(p => p.Estado_Pedido == EstadosPedido.PENDIENTE));
            Llenar_Columna(flpPreparacion, lblPreparacion, "En preparación", pedidos.Where(p => p.Estado_Pedido == EstadosPedido.EN_PREPARACION));
            Llenar_Columna(flpListo, lblListo, "Listo", pedidos.Where(p => p.Estado_Pedido == EstadosPedido.LISTO));
            // De los entregados solo se muestran los 10 últimos
            Llenar_Columna(flpEntregado, lblEntregado, "Entregado",
                           pedidos.Where(p => p.Estado_Pedido == EstadosPedido.ENTREGADO).OrderByDescending(p => p.Fec_Pedido).Take(10));

            lblActualizado.Text = "Actualizado: " + DateTime.Now.ToString("HH:mm:ss");
        }

        private void Llenar_Columna(FlowLayoutPanel columna, Label titulo, string estado, IEnumerable<ENTIDAD_PEDIDO_COCINA> pedidos)
        {
            List<ENTIDAD_PEDIDO_COCINA> lista = pedidos.ToList();
            titulo.Text = estado + " (" + lista.Count + ")";

            columna.SuspendLayout();
            foreach (Control tarjeta in columna.Controls.Cast<Control>().ToList())
                tarjeta.Dispose();
            foreach (ENTIDAD_PEDIDO_COCINA pedido in lista)
                columna.Controls.Add(Crear_Tarjeta(pedido, columna.ClientSize.Width - 30));
            columna.ResumeLayout();
        }

        // Tarjeta de un pedido: cabecera con color según el tiempo de espera, detalle y botón para avanzar
        private Panel Crear_Tarjeta(ENTIDAD_PEDIDO_COCINA pedido, int ancho)
        {
            int minutos = Math.Max(0, (int)(DateTime.Now - pedido.Fec_Pedido).TotalMinutes);
            Color color = Color_Por_Espera(pedido.Estado_Pedido, minutos);

            Panel tarjeta = new Panel { Width = ancho, BackColor = Color.White, Margin = new Padding(4) };

            Label cabecera = new Label
            {
                Dock = DockStyle.Top,
                Height = 30,
                BackColor = color,
                ForeColor = color == Estilo.AcentoClaro ? Estilo.Negro : Color.White,
                Font = Estilo.FuenteNegrita,
                Padding = new Padding(6, 0, 0, 0),
                TextAlign = ContentAlignment.MiddleLeft,
                Text = pedido.ID_Pedido + "  ·  " + pedido.Fec_Pedido.ToString("HH:mm") + "  ·  " + minutos + " min"
            };

            int lineasDetalle = pedido.Detalle.Split('\n').Length;
            Label detalle = new Label
            {
                Dock = DockStyle.Top,
                Height = lineasDetalle * 22 + 8,
                Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
                Padding = new Padding(6, 4, 6, 0),
                Text = pedido.Detalle
            };

            string textoInfo = pedido.Tipo_Pedido + "  ·  " + pedido.Cliente;
            if (pedido.Observaciones != "")
                textoInfo += "\nObs: " + pedido.Observaciones;
            Label info = new Label
            {
                Dock = DockStyle.Top,
                Height = pedido.Observaciones != "" ? 44 : 26,
                ForeColor = Color.FromArgb(97, 97, 97),
                Font = new Font("Segoe UI", 9F),
                Padding = new Padding(6, 2, 6, 0),
                Text = textoInfo
            };

            // Con Dock = Top el último control agregado queda arriba: se agregan de abajo hacia arriba
            string siguiente = EstadosPedido.Siguiente(pedido.Estado_Pedido);
            if (siguiente != null)
            {
                Button avanzar = new Button { Dock = DockStyle.Top, Height = 36, Tag = pedido, Text = Texto_Boton(siguiente) };
                Estilo.Boton(avanzar, siguiente == EstadosPedido.ENTREGADO ? Estilo.Verde : Estilo.Negro);
                avanzar.Click += Avanzar_Click;
                tarjeta.Controls.Add(avanzar);
            }
            tarjeta.Controls.Add(info);
            tarjeta.Controls.Add(detalle);
            tarjeta.Controls.Add(cabecera);

            tarjeta.Height = tarjeta.Controls.Cast<Control>().Sum(c => c.Height);
            return tarjeta;
        }

        private Color Color_Por_Espera(string estado, int minutos)
        {
            if (estado == EstadosPedido.ENTREGADO)
                return Color.Gray;
            if (minutos < 10)
                return Estilo.Verde;
            if (minutos <= 20)
                return Estilo.AcentoClaro;
            return Estilo.Rojo;
        }

        private string Texto_Boton(string siguienteEstado)
        {
            switch (siguienteEstado)
            {
                case EstadosPedido.EN_PREPARACION: return "Iniciar preparación  ▶";
                case EstadosPedido.LISTO: return "Marcar como listo  ▶";
                default: return "Entregar  ✔";
            }
        }

        private void Avanzar_Click(object sender, EventArgs e)
        {
            ENTIDAD_PEDIDO_COCINA pedido = (ENTIDAD_PEDIDO_COCINA)((Button)sender).Tag;
            try
            {
                _pedidos.Cambiar_Estado(pedido.ID_Pedido, EstadosPedido.Siguiente(pedido.Estado_Pedido));
                Refrescar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cambiar el estado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
