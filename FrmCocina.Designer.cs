namespace RESTAURANTEFINAL
{
    partial class FrmCocina
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tlpColumnas = new System.Windows.Forms.TableLayoutPanel();
            this.pnlPendiente = new System.Windows.Forms.Panel();
            this.flpPendiente = new System.Windows.Forms.FlowLayoutPanel();
            this.lblPendiente = new System.Windows.Forms.Label();
            this.pnlPreparacion = new System.Windows.Forms.Panel();
            this.flpPreparacion = new System.Windows.Forms.FlowLayoutPanel();
            this.lblPreparacion = new System.Windows.Forms.Label();
            this.pnlListo = new System.Windows.Forms.Panel();
            this.flpListo = new System.Windows.Forms.FlowLayoutPanel();
            this.lblListo = new System.Windows.Forms.Label();
            this.pnlEntregado = new System.Windows.Forms.Panel();
            this.flpEntregado = new System.Windows.Forms.FlowLayoutPanel();
            this.lblEntregado = new System.Windows.Forms.Label();
            this.pnlBarra = new System.Windows.Forms.Panel();
            this.lblLeyenda = new System.Windows.Forms.Label();
            this.lblVerde = new System.Windows.Forms.Label();
            this.lblAmbar = new System.Windows.Forms.Label();
            this.lblRojo = new System.Windows.Forms.Label();
            this.lblActualizado = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.timerRefresco = new System.Windows.Forms.Timer(this.components);
            this.tlpColumnas.SuspendLayout();
            this.pnlPendiente.SuspendLayout();
            this.flpPendiente.SuspendLayout();
            this.pnlPreparacion.SuspendLayout();
            this.flpPreparacion.SuspendLayout();
            this.pnlListo.SuspendLayout();
            this.flpListo.SuspendLayout();
            this.pnlEntregado.SuspendLayout();
            this.flpEntregado.SuspendLayout();
            this.pnlBarra.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpColumnas
            // 
            this.tlpColumnas.Controls.Add(this.pnlPendiente, 0, 0);
            this.tlpColumnas.Controls.Add(this.pnlPreparacion, 1, 0);
            this.tlpColumnas.Controls.Add(this.pnlListo, 2, 0);
            this.tlpColumnas.Controls.Add(this.pnlEntregado, 3, 0);
            this.tlpColumnas.ColumnCount = 4;
            this.tlpColumnas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0F));
            this.tlpColumnas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0F));
            this.tlpColumnas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0F));
            this.tlpColumnas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0F));
            this.tlpColumnas.RowCount = 1;
            this.tlpColumnas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0F));
            this.tlpColumnas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpColumnas.Location = new System.Drawing.Point(0, 0);
            this.tlpColumnas.Name = "tlpColumnas";
            this.tlpColumnas.Padding = new System.Windows.Forms.Padding(6);
            this.tlpColumnas.Size = new System.Drawing.Size(1050, 640);
            this.tlpColumnas.TabIndex = 1;
            // 
            // pnlPendiente
            // 
            this.pnlPendiente.Controls.Add(this.flpPendiente);
            this.pnlPendiente.Controls.Add(this.lblPendiente);
            this.pnlPendiente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.pnlPendiente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPendiente.Location = new System.Drawing.Point(9, 9);
            this.pnlPendiente.Margin = new System.Windows.Forms.Padding(4);
            this.pnlPendiente.Name = "pnlPendiente";
            this.pnlPendiente.Size = new System.Drawing.Size(250, 600);
            this.pnlPendiente.TabIndex = 0;
            // 
            // flpPendiente
            // 
            this.flpPendiente.AutoScroll = true;
            this.flpPendiente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpPendiente.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpPendiente.Location = new System.Drawing.Point(0, 40);
            this.flpPendiente.Name = "flpPendiente";
            this.flpPendiente.Padding = new System.Windows.Forms.Padding(6);
            this.flpPendiente.Size = new System.Drawing.Size(250, 560);
            this.flpPendiente.TabIndex = 1;
            this.flpPendiente.WrapContents = false;
            // 
            // lblPendiente
            // 
            this.lblPendiente.AutoSize = false;
            this.lblPendiente.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendiente.ForeColor = System.Drawing.Color.White;
            this.lblPendiente.Location = new System.Drawing.Point(0, 0);
            this.lblPendiente.Name = "lblPendiente";
            this.lblPendiente.Size = new System.Drawing.Size(250, 40);
            this.lblPendiente.Text = "Pendiente";
            this.lblPendiente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPendiente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lblPendiente.Dock = System.Windows.Forms.DockStyle.Top;
            // 
            // pnlPreparacion
            // 
            this.pnlPreparacion.Controls.Add(this.flpPreparacion);
            this.pnlPreparacion.Controls.Add(this.lblPreparacion);
            this.pnlPreparacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.pnlPreparacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPreparacion.Location = new System.Drawing.Point(9, 9);
            this.pnlPreparacion.Margin = new System.Windows.Forms.Padding(4);
            this.pnlPreparacion.Name = "pnlPreparacion";
            this.pnlPreparacion.Size = new System.Drawing.Size(250, 600);
            this.pnlPreparacion.TabIndex = 0;
            // 
            // flpPreparacion
            // 
            this.flpPreparacion.AutoScroll = true;
            this.flpPreparacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpPreparacion.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpPreparacion.Location = new System.Drawing.Point(0, 40);
            this.flpPreparacion.Name = "flpPreparacion";
            this.flpPreparacion.Padding = new System.Windows.Forms.Padding(6);
            this.flpPreparacion.Size = new System.Drawing.Size(250, 560);
            this.flpPreparacion.TabIndex = 1;
            this.flpPreparacion.WrapContents = false;
            // 
            // lblPreparacion
            // 
            this.lblPreparacion.AutoSize = false;
            this.lblPreparacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreparacion.ForeColor = System.Drawing.Color.White;
            this.lblPreparacion.Location = new System.Drawing.Point(0, 0);
            this.lblPreparacion.Name = "lblPreparacion";
            this.lblPreparacion.Size = new System.Drawing.Size(250, 40);
            this.lblPreparacion.Text = "En preparación";
            this.lblPreparacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPreparacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lblPreparacion.Dock = System.Windows.Forms.DockStyle.Top;
            // 
            // pnlListo
            // 
            this.pnlListo.Controls.Add(this.flpListo);
            this.pnlListo.Controls.Add(this.lblListo);
            this.pnlListo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.pnlListo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlListo.Location = new System.Drawing.Point(9, 9);
            this.pnlListo.Margin = new System.Windows.Forms.Padding(4);
            this.pnlListo.Name = "pnlListo";
            this.pnlListo.Size = new System.Drawing.Size(250, 600);
            this.pnlListo.TabIndex = 0;
            // 
            // flpListo
            // 
            this.flpListo.AutoScroll = true;
            this.flpListo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpListo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpListo.Location = new System.Drawing.Point(0, 40);
            this.flpListo.Name = "flpListo";
            this.flpListo.Padding = new System.Windows.Forms.Padding(6);
            this.flpListo.Size = new System.Drawing.Size(250, 560);
            this.flpListo.TabIndex = 1;
            this.flpListo.WrapContents = false;
            // 
            // lblListo
            // 
            this.lblListo.AutoSize = false;
            this.lblListo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListo.ForeColor = System.Drawing.Color.White;
            this.lblListo.Location = new System.Drawing.Point(0, 0);
            this.lblListo.Name = "lblListo";
            this.lblListo.Size = new System.Drawing.Size(250, 40);
            this.lblListo.Text = "Listo";
            this.lblListo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblListo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lblListo.Dock = System.Windows.Forms.DockStyle.Top;
            // 
            // pnlEntregado
            // 
            this.pnlEntregado.Controls.Add(this.flpEntregado);
            this.pnlEntregado.Controls.Add(this.lblEntregado);
            this.pnlEntregado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.pnlEntregado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEntregado.Location = new System.Drawing.Point(9, 9);
            this.pnlEntregado.Margin = new System.Windows.Forms.Padding(4);
            this.pnlEntregado.Name = "pnlEntregado";
            this.pnlEntregado.Size = new System.Drawing.Size(250, 600);
            this.pnlEntregado.TabIndex = 0;
            // 
            // flpEntregado
            // 
            this.flpEntregado.AutoScroll = true;
            this.flpEntregado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpEntregado.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpEntregado.Location = new System.Drawing.Point(0, 40);
            this.flpEntregado.Name = "flpEntregado";
            this.flpEntregado.Padding = new System.Windows.Forms.Padding(6);
            this.flpEntregado.Size = new System.Drawing.Size(250, 560);
            this.flpEntregado.TabIndex = 1;
            this.flpEntregado.WrapContents = false;
            // 
            // lblEntregado
            // 
            this.lblEntregado.AutoSize = false;
            this.lblEntregado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntregado.ForeColor = System.Drawing.Color.White;
            this.lblEntregado.Location = new System.Drawing.Point(0, 0);
            this.lblEntregado.Name = "lblEntregado";
            this.lblEntregado.Size = new System.Drawing.Size(250, 40);
            this.lblEntregado.Text = "Entregado";
            this.lblEntregado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEntregado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lblEntregado.Dock = System.Windows.Forms.DockStyle.Top;
            // 
            // pnlBarra
            // 
            this.pnlBarra.Controls.Add(this.lblLeyenda);
            this.pnlBarra.Controls.Add(this.lblVerde);
            this.pnlBarra.Controls.Add(this.lblAmbar);
            this.pnlBarra.Controls.Add(this.lblRojo);
            this.pnlBarra.Controls.Add(this.lblActualizado);
            this.pnlBarra.Controls.Add(this.btnActualizar);
            this.pnlBarra.BackColor = System.Drawing.Color.White;
            this.pnlBarra.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarra.Location = new System.Drawing.Point(0, 0);
            this.pnlBarra.Name = "pnlBarra";
            this.pnlBarra.Size = new System.Drawing.Size(1050, 50);
            this.pnlBarra.TabIndex = 0;
            // 
            // lblLeyenda
            // 
            this.lblLeyenda.AutoSize = true;
            this.lblLeyenda.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeyenda.Location = new System.Drawing.Point(12, 15);
            this.lblLeyenda.Name = "lblLeyenda";
            this.lblLeyenda.Text = "Tiempo de espera:";
            // 
            // lblVerde
            // 
            this.lblVerde.AutoSize = false;
            this.lblVerde.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVerde.ForeColor = System.Drawing.Color.White;
            this.lblVerde.Location = new System.Drawing.Point(150, 12);
            this.lblVerde.Name = "lblVerde";
            this.lblVerde.Size = new System.Drawing.Size(80, 26);
            this.lblVerde.Text = "< 10 min";
            this.lblVerde.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblVerde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(142)))), ((int)(((byte)(60)))));
            // 
            // lblAmbar
            // 
            this.lblAmbar.AutoSize = false;
            this.lblAmbar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmbar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lblAmbar.Location = new System.Drawing.Point(236, 12);
            this.lblAmbar.Name = "lblAmbar";
            this.lblAmbar.Size = new System.Drawing.Size(90, 26);
            this.lblAmbar.Text = "10 - 20 min";
            this.lblAmbar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAmbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            // 
            // lblRojo
            // 
            this.lblRojo.AutoSize = false;
            this.lblRojo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRojo.ForeColor = System.Drawing.Color.White;
            this.lblRojo.Location = new System.Drawing.Point(332, 12);
            this.lblRojo.Name = "lblRojo";
            this.lblRojo.Size = new System.Drawing.Size(80, 26);
            this.lblRojo.Text = "> 20 min";
            this.lblRojo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRojo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            // 
            // lblActualizado
            // 
            this.lblActualizado.AutoSize = false;
            this.lblActualizado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualizado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.lblActualizado.Location = new System.Drawing.Point(640, 15);
            this.lblActualizado.Name = "lblActualizado";
            this.lblActualizado.Size = new System.Drawing.Size(250, 22);
            this.lblActualizado.Text = "Actualizado: --:--:--";
            this.lblActualizado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblActualizado.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            // 
            // btnActualizar
            // 
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(900, 9);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(136, 32);
            this.btnActualizar.TabIndex = 0;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // timerRefresco
            // 
            this.timerRefresco.Interval = 10000;
            this.timerRefresco.Tick += new System.EventHandler(this.timerRefresco_Tick);
            // 
            // FrmCocina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1050, 690);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmCocina";
            this.Text = "Cocina";
            this.Controls.Add(this.tlpColumnas);
            this.Controls.Add(this.pnlBarra);
            this.Load += new System.EventHandler(this.FrmCocina_Load);
            this.pnlBarra.ResumeLayout(false);
            this.pnlBarra.PerformLayout();
            this.flpEntregado.ResumeLayout(false);
            this.flpEntregado.PerformLayout();
            this.pnlEntregado.ResumeLayout(false);
            this.pnlEntregado.PerformLayout();
            this.flpListo.ResumeLayout(false);
            this.flpListo.PerformLayout();
            this.pnlListo.ResumeLayout(false);
            this.pnlListo.PerformLayout();
            this.flpPreparacion.ResumeLayout(false);
            this.flpPreparacion.PerformLayout();
            this.pnlPreparacion.ResumeLayout(false);
            this.pnlPreparacion.PerformLayout();
            this.flpPendiente.ResumeLayout(false);
            this.flpPendiente.PerformLayout();
            this.pnlPendiente.ResumeLayout(false);
            this.pnlPendiente.PerformLayout();
            this.tlpColumnas.ResumeLayout(false);
            this.tlpColumnas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpColumnas;
        private System.Windows.Forms.Panel pnlPendiente;
        private System.Windows.Forms.FlowLayoutPanel flpPendiente;
        private System.Windows.Forms.Label lblPendiente;
        private System.Windows.Forms.Panel pnlPreparacion;
        private System.Windows.Forms.FlowLayoutPanel flpPreparacion;
        private System.Windows.Forms.Label lblPreparacion;
        private System.Windows.Forms.Panel pnlListo;
        private System.Windows.Forms.FlowLayoutPanel flpListo;
        private System.Windows.Forms.Label lblListo;
        private System.Windows.Forms.Panel pnlEntregado;
        private System.Windows.Forms.FlowLayoutPanel flpEntregado;
        private System.Windows.Forms.Label lblEntregado;
        private System.Windows.Forms.Panel pnlBarra;
        private System.Windows.Forms.Label lblLeyenda;
        private System.Windows.Forms.Label lblVerde;
        private System.Windows.Forms.Label lblAmbar;
        private System.Windows.Forms.Label lblRojo;
        private System.Windows.Forms.Label lblActualizado;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Timer timerRefresco;
    }
}
