namespace RESTAURANTEFINAL
{
    partial class Pedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pedido));
            this.btn_pedido_guardar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_pedido_buscar = new System.Windows.Forms.TextBox();
            this.btn_pedido_eliminar = new System.Windows.Forms.Button();
            this.dataGridView_Pedido = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbx_pedido_estado = new System.Windows.Forms.ComboBox();
            this.dtp_pedido_fecha = new System.Windows.Forms.DateTimePicker();
            this.txt_pedido_obs = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbx_cliente_cod = new System.Windows.Forms.ComboBox();
            this.txt_pedido_cod = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Pedido)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_pedido_guardar
            // 
            this.btn_pedido_guardar.Location = new System.Drawing.Point(81, 393);
            this.btn_pedido_guardar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_pedido_guardar.Name = "btn_pedido_guardar";
            this.btn_pedido_guardar.Size = new System.Drawing.Size(100, 28);
            this.btn_pedido_guardar.TabIndex = 42;
            this.btn_pedido_guardar.Text = "Guardar";
            this.btn_pedido_guardar.UseVisualStyleBackColor = true;
            this.btn_pedido_guardar.Click += new System.EventHandler(this.btn_pedido_guardar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 85);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 16);
            this.label6.TabIndex = 41;
            this.label6.Text = "Nombre:";
            // 
            // txt_pedido_buscar
            // 
            this.txt_pedido_buscar.Location = new System.Drawing.Point(12, 105);
            this.txt_pedido_buscar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_pedido_buscar.Name = "txt_pedido_buscar";
            this.txt_pedido_buscar.Size = new System.Drawing.Size(453, 22);
            this.txt_pedido_buscar.TabIndex = 40;
            this.txt_pedido_buscar.TextChanged += new System.EventHandler(this.txt_pedido_buscar_TextChanged);
            // 
            // btn_pedido_eliminar
            // 
            this.btn_pedido_eliminar.Location = new System.Drawing.Point(257, 393);
            this.btn_pedido_eliminar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_pedido_eliminar.Name = "btn_pedido_eliminar";
            this.btn_pedido_eliminar.Size = new System.Drawing.Size(100, 28);
            this.btn_pedido_eliminar.TabIndex = 39;
            this.btn_pedido_eliminar.Text = "Eliminar";
            this.btn_pedido_eliminar.UseVisualStyleBackColor = true;
            this.btn_pedido_eliminar.Click += new System.EventHandler(this.btn_pedido_eliminar_Click);
            // 
            // dataGridView_Pedido
            // 
            this.dataGridView_Pedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Pedido.Location = new System.Drawing.Point(12, 151);
            this.dataGridView_Pedido.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView_Pedido.Name = "dataGridView_Pedido";
            this.dataGridView_Pedido.RowHeadersWidth = 51;
            this.dataGridView_Pedido.Size = new System.Drawing.Size(521, 304);
            this.dataGridView_Pedido.TabIndex = 38;
            this.dataGridView_Pedido.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Pedido_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_pedido_guardar);
            this.groupBox1.Controls.Add(this.cbx_pedido_estado);
            this.groupBox1.Controls.Add(this.btn_pedido_eliminar);
            this.groupBox1.Controls.Add(this.dtp_pedido_fecha);
            this.groupBox1.Controls.Add(this.txt_pedido_obs);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbx_cliente_cod);
            this.groupBox1.Controls.Add(this.txt_pedido_cod);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(555, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(413, 442);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registro de Pedido";
            // 
            // cbx_pedido_estado
            // 
            this.cbx_pedido_estado.FormattingEnabled = true;
            this.cbx_pedido_estado.Location = new System.Drawing.Point(156, 191);
            this.cbx_pedido_estado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbx_pedido_estado.Name = "cbx_pedido_estado";
            this.cbx_pedido_estado.Size = new System.Drawing.Size(132, 24);
            this.cbx_pedido_estado.TabIndex = 29;
            // 
            // dtp_pedido_fecha
            // 
            this.dtp_pedido_fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_pedido_fecha.Location = new System.Drawing.Point(156, 145);
            this.dtp_pedido_fecha.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtp_pedido_fecha.Name = "dtp_pedido_fecha";
            this.dtp_pedido_fecha.Size = new System.Drawing.Size(132, 22);
            this.dtp_pedido_fecha.TabIndex = 28;
            // 
            // txt_pedido_obs
            // 
            this.txt_pedido_obs.Location = new System.Drawing.Point(156, 254);
            this.txt_pedido_obs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_pedido_obs.Name = "txt_pedido_obs";
            this.txt_pedido_obs.Size = new System.Drawing.Size(236, 111);
            this.txt_pedido_obs.TabIndex = 27;
            this.txt_pedido_obs.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 254);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 16);
            this.label3.TabIndex = 26;
            this.label3.Text = "Observación:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 198);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 25;
            this.label1.Text = "Estado Pedido:";
            // 
            // cbx_cliente_cod
            // 
            this.cbx_cliente_cod.FormattingEnabled = true;
            this.cbx_cliente_cod.Location = new System.Drawing.Point(156, 90);
            this.cbx_cliente_cod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbx_cliente_cod.Name = "cbx_cliente_cod";
            this.cbx_cliente_cod.Size = new System.Drawing.Size(132, 24);
            this.cbx_cliente_cod.TabIndex = 24;
            // 
            // txt_pedido_cod
            // 
            this.txt_pedido_cod.Location = new System.Drawing.Point(156, 41);
            this.txt_pedido_cod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_pedido_cod.Name = "txt_pedido_cod";
            this.txt_pedido_cod.Size = new System.Drawing.Size(132, 22);
            this.txt_pedido_cod.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 150);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 47);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Código:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 97);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Código Cliente:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(424, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(109, 85);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 42;
            this.pictureBox1.TabStop = false;
            // 
            // Pedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 475);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_pedido_buscar);
            this.Controls.Add(this.dataGridView_Pedido);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Pedido";
            this.Text = "\"PEDIDO\"";
            this.Load += new System.EventHandler(this.Pedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Pedido)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_pedido_guardar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_pedido_buscar;
        private System.Windows.Forms.Button btn_pedido_eliminar;
        private System.Windows.Forms.DataGridView dataGridView_Pedido;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbx_cliente_cod;
        private System.Windows.Forms.TextBox txt_pedido_cod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox txt_pedido_obs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbx_pedido_estado;
        private System.Windows.Forms.DateTimePicker dtp_pedido_fecha;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}