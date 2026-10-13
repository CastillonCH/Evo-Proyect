namespace RESTAURANTEFINAL
{
    partial class Venta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Venta));
            this.txt_venta_buscar = new System.Windows.Forms.TextBox();
            this.btn_venta_eliminar = new System.Windows.Forms.Button();
            this.dataGridView_Venta = new System.Windows.Forms.DataGridView();
            this.btn_venta_guardar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbx_pedido_cod = new System.Windows.Forms.ComboBox();
            this.cbx_metodo_cod = new System.Windows.Forms.ComboBox();
            this.dtp_venta_fecha = new System.Windows.Forms.DateTimePicker();
            this.txt_venta_monto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbx_sede_cod = new System.Windows.Forms.ComboBox();
            this.txt_venta_cod = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Venta)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_venta_buscar
            // 
            this.txt_venta_buscar.Location = new System.Drawing.Point(13, 54);
            this.txt_venta_buscar.Margin = new System.Windows.Forms.Padding(4);
            this.txt_venta_buscar.Name = "txt_venta_buscar";
            this.txt_venta_buscar.Size = new System.Drawing.Size(453, 23);
            this.txt_venta_buscar.TabIndex = 41;
            this.txt_venta_buscar.TextChanged += new System.EventHandler(this.txt_venta_buscar_TextChanged);
            // 
            // btn_venta_eliminar
            // 
            this.btn_venta_eliminar.Location = new System.Drawing.Point(205, 397);
            this.btn_venta_eliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_venta_eliminar.Name = "btn_venta_eliminar";
            this.btn_venta_eliminar.Size = new System.Drawing.Size(100, 30);
            this.btn_venta_eliminar.TabIndex = 40;
            this.btn_venta_eliminar.Text = "Eliminar";
            this.btn_venta_eliminar.UseVisualStyleBackColor = true;
            this.btn_venta_eliminar.Click += new System.EventHandler(this.btn_venta_eliminar_Click);
            // 
            // dataGridView_Venta
            // 
            this.dataGridView_Venta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Venta.Location = new System.Drawing.Point(13, 88);
            this.dataGridView_Venta.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView_Venta.Name = "dataGridView_Venta";
            this.dataGridView_Venta.RowHeadersWidth = 51;
            this.dataGridView_Venta.Size = new System.Drawing.Size(577, 392);
            this.dataGridView_Venta.TabIndex = 39;
            this.dataGridView_Venta.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Venta_CellClick);
            // 
            // btn_venta_guardar
            // 
            this.btn_venta_guardar.Location = new System.Drawing.Point(72, 397);
            this.btn_venta_guardar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_venta_guardar.Name = "btn_venta_guardar";
            this.btn_venta_guardar.Size = new System.Drawing.Size(100, 30);
            this.btn_venta_guardar.TabIndex = 38;
            this.btn_venta_guardar.Text = "Guardar";
            this.btn_venta_guardar.UseVisualStyleBackColor = true;
            this.btn_venta_guardar.Click += new System.EventHandler(this.btn_venta_guardar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbx_pedido_cod);
            this.groupBox1.Controls.Add(this.btn_venta_eliminar);
            this.groupBox1.Controls.Add(this.cbx_metodo_cod);
            this.groupBox1.Controls.Add(this.dtp_venta_fecha);
            this.groupBox1.Controls.Add(this.btn_venta_guardar);
            this.groupBox1.Controls.Add(this.txt_venta_monto);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbx_sede_cod);
            this.groupBox1.Controls.Add(this.txt_venta_cod);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(613, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(388, 459);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registro de Venta";
            // 
            // cbx_pedido_cod
            // 
            this.cbx_pedido_cod.FormattingEnabled = true;
            this.cbx_pedido_cod.Location = new System.Drawing.Point(191, 102);
            this.cbx_pedido_cod.Margin = new System.Windows.Forms.Padding(4);
            this.cbx_pedido_cod.Name = "cbx_pedido_cod";
            this.cbx_pedido_cod.Size = new System.Drawing.Size(132, 25);
            this.cbx_pedido_cod.TabIndex = 40;
            // 
            // cbx_metodo_cod
            // 
            this.cbx_metodo_cod.FormattingEnabled = true;
            this.cbx_metodo_cod.Location = new System.Drawing.Point(191, 272);
            this.cbx_metodo_cod.Margin = new System.Windows.Forms.Padding(4);
            this.cbx_metodo_cod.Name = "cbx_metodo_cod";
            this.cbx_metodo_cod.Size = new System.Drawing.Size(132, 25);
            this.cbx_metodo_cod.TabIndex = 39;
            // 
            // dtp_venta_fecha
            // 
            this.dtp_venta_fecha.AllowDrop = true;
            this.dtp_venta_fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_venta_fecha.Location = new System.Drawing.Point(191, 160);
            this.dtp_venta_fecha.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_venta_fecha.Name = "dtp_venta_fecha";
            this.dtp_venta_fecha.Size = new System.Drawing.Size(132, 23);
            this.dtp_venta_fecha.TabIndex = 38;
            // 
            // txt_venta_monto
            // 
            this.txt_venta_monto.Location = new System.Drawing.Point(191, 215);
            this.txt_venta_monto.Margin = new System.Windows.Forms.Padding(4);
            this.txt_venta_monto.Name = "txt_venta_monto";
            this.txt_venta_monto.Size = new System.Drawing.Size(132, 23);
            this.txt_venta_monto.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 341);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 17);
            this.label4.TabIndex = 26;
            this.label4.Text = "Sede:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 170);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "Fecha:";
            // 
            // cbx_sede_cod
            // 
            this.cbx_sede_cod.FormattingEnabled = true;
            this.cbx_sede_cod.Location = new System.Drawing.Point(191, 330);
            this.cbx_sede_cod.Margin = new System.Windows.Forms.Padding(4);
            this.cbx_sede_cod.Name = "cbx_sede_cod";
            this.cbx_sede_cod.Size = new System.Drawing.Size(132, 25);
            this.cbx_sede_cod.TabIndex = 24;
            // 
            // txt_venta_cod
            // 
            this.txt_venta_cod.Location = new System.Drawing.Point(191, 40);
            this.txt_venta_cod.Margin = new System.Windows.Forms.Padding(4);
            this.txt_venta_cod.Name = "txt_venta_cod";
            this.txt_venta_cod.Size = new System.Drawing.Size(132, 23);
            this.txt_venta_cod.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 113);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Código del Pedido:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 50);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Código:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 283);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Metodo de Pago";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 223);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Monto Total:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 17);
            this.label6.TabIndex = 42;
            this.label6.Text = "Codigo de Venta:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(482, -7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(124, 98);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 43;
            this.pictureBox1.TabStop = false;
            // 
            // Venta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 493);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_venta_buscar);
            this.Controls.Add(this.dataGridView_Venta);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Venta";
            this.Text = "\"VENTA\"";
            this.Load += new System.EventHandler(this.Venta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Venta)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_venta_buscar;
        private System.Windows.Forms.Button btn_venta_eliminar;
        private System.Windows.Forms.DataGridView dataGridView_Venta;
        private System.Windows.Forms.Button btn_venta_guardar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtp_venta_fecha;
        private System.Windows.Forms.TextBox txt_venta_monto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbx_sede_cod;
        private System.Windows.Forms.TextBox txt_venta_cod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbx_metodo_cod;
        private System.Windows.Forms.ComboBox cbx_pedido_cod;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}