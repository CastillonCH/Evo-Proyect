namespace RESTAURANTEFINAL
{
    partial class Detalle_Pedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Detalle_Pedido));
            this.btn_detalle_pedido_guardar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_detalle_pedido_buscar = new System.Windows.Forms.TextBox();
            this.btn_detalle_pedido_eliminar = new System.Windows.Forms.Button();
            this.dataGridView_Detalle_Pedido = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_detalle_pedido_pre = new System.Windows.Forms.TextBox();
            this.txt_detalle_pedido_cant = new System.Windows.Forms.TextBox();
            this.cbx_plato_cod = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbx_pedido_cod = new System.Windows.Forms.ComboBox();
            this.txt_detalle_pedido_cod = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Detalle_Pedido)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_detalle_pedido_guardar
            // 
            this.btn_detalle_pedido_guardar.Location = new System.Drawing.Point(80, 304);
            this.btn_detalle_pedido_guardar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_detalle_pedido_guardar.Name = "btn_detalle_pedido_guardar";
            this.btn_detalle_pedido_guardar.Size = new System.Drawing.Size(100, 30);
            this.btn_detalle_pedido_guardar.TabIndex = 48;
            this.btn_detalle_pedido_guardar.Text = "Guardar";
            this.btn_detalle_pedido_guardar.UseVisualStyleBackColor = true;
            this.btn_detalle_pedido_guardar.Click += new System.EventHandler(this.btn_detalle_pedido_guardar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 37);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 17);
            this.label6.TabIndex = 47;
            this.label6.Text = "Nombre:";
            // 
            // txt_detalle_pedido_buscar
            // 
            this.txt_detalle_pedido_buscar.Location = new System.Drawing.Point(13, 58);
            this.txt_detalle_pedido_buscar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_detalle_pedido_buscar.Name = "txt_detalle_pedido_buscar";
            this.txt_detalle_pedido_buscar.Size = new System.Drawing.Size(453, 23);
            this.txt_detalle_pedido_buscar.TabIndex = 46;
            this.txt_detalle_pedido_buscar.TextChanged += new System.EventHandler(this.txt_detalle_pedido_buscar_TextChanged);
            // 
            // btn_detalle_pedido_eliminar
            // 
            this.btn_detalle_pedido_eliminar.Location = new System.Drawing.Point(223, 304);
            this.btn_detalle_pedido_eliminar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_detalle_pedido_eliminar.Name = "btn_detalle_pedido_eliminar";
            this.btn_detalle_pedido_eliminar.Size = new System.Drawing.Size(100, 30);
            this.btn_detalle_pedido_eliminar.TabIndex = 45;
            this.btn_detalle_pedido_eliminar.Text = "Eliminar";
            this.btn_detalle_pedido_eliminar.UseVisualStyleBackColor = true;
            this.btn_detalle_pedido_eliminar.Click += new System.EventHandler(this.btn_detalle_pedido_eliminar_Click);
            // 
            // dataGridView_Detalle_Pedido
            // 
            this.dataGridView_Detalle_Pedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Detalle_Pedido.Location = new System.Drawing.Point(13, 90);
            this.dataGridView_Detalle_Pedido.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView_Detalle_Pedido.Name = "dataGridView_Detalle_Pedido";
            this.dataGridView_Detalle_Pedido.RowHeadersWidth = 51;
            this.dataGridView_Detalle_Pedido.Size = new System.Drawing.Size(509, 278);
            this.dataGridView_Detalle_Pedido.TabIndex = 44;
            this.dataGridView_Detalle_Pedido.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Detalle_Pedido_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_detalle_pedido_guardar);
            this.groupBox1.Controls.Add(this.txt_detalle_pedido_pre);
            this.groupBox1.Controls.Add(this.btn_detalle_pedido_eliminar);
            this.groupBox1.Controls.Add(this.txt_detalle_pedido_cant);
            this.groupBox1.Controls.Add(this.cbx_plato_cod);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbx_pedido_cod);
            this.groupBox1.Controls.Add(this.txt_detalle_pedido_cod);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(558, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(369, 367);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle del Pedido";
            // 
            // txt_detalle_pedido_pre
            // 
            this.txt_detalle_pedido_pre.Location = new System.Drawing.Point(191, 260);
            this.txt_detalle_pedido_pre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_detalle_pedido_pre.Name = "txt_detalle_pedido_pre";
            this.txt_detalle_pedido_pre.Size = new System.Drawing.Size(132, 23);
            this.txt_detalle_pedido_pre.TabIndex = 32;
            // 
            // txt_detalle_pedido_cant
            // 
            this.txt_detalle_pedido_cant.Location = new System.Drawing.Point(191, 202);
            this.txt_detalle_pedido_cant.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_detalle_pedido_cant.Name = "txt_detalle_pedido_cant";
            this.txt_detalle_pedido_cant.Size = new System.Drawing.Size(132, 23);
            this.txt_detalle_pedido_cant.TabIndex = 31;
            // 
            // cbx_plato_cod
            // 
            this.cbx_plato_cod.FormattingEnabled = true;
            this.cbx_plato_cod.Location = new System.Drawing.Point(191, 149);
            this.cbx_plato_cod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbx_plato_cod.Name = "cbx_plato_cod";
            this.cbx_plato_cod.Size = new System.Drawing.Size(132, 25);
            this.cbx_plato_cod.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 270);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 17);
            this.label3.TabIndex = 26;
            this.label3.Text = "Precio final:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 210);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "Cantidad:";
            // 
            // cbx_pedido_cod
            // 
            this.cbx_pedido_cod.FormattingEnabled = true;
            this.cbx_pedido_cod.Location = new System.Drawing.Point(191, 92);
            this.cbx_pedido_cod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbx_pedido_cod.Name = "cbx_pedido_cod";
            this.cbx_pedido_cod.Size = new System.Drawing.Size(132, 25);
            this.cbx_pedido_cod.TabIndex = 24;
            // 
            // txt_detalle_pedido_cod
            // 
            this.txt_detalle_pedido_cod.Location = new System.Drawing.Point(191, 40);
            this.txt_detalle_pedido_cod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_detalle_pedido_cod.Name = "txt_detalle_pedido_cod";
            this.txt_detalle_pedido_cod.Size = new System.Drawing.Size(132, 23);
            this.txt_detalle_pedido_cod.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 159);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Codigo Plato:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 50);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Código:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 103);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Código Pedido:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(466, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(91, 78);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 48;
            this.pictureBox1.TabStop = false;
            // 
            // Detalle_Pedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 391);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_detalle_pedido_buscar);
            this.Controls.Add(this.dataGridView_Detalle_Pedido);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Detalle_Pedido";
            this.Text = "\"DETALLE DE PEDIDOS\"";
            this.Load += new System.EventHandler(this.Detalle_Pedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Detalle_Pedido)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_detalle_pedido_guardar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_detalle_pedido_buscar;
        private System.Windows.Forms.Button btn_detalle_pedido_eliminar;
        private System.Windows.Forms.DataGridView dataGridView_Detalle_Pedido;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbx_pedido_cod;
        private System.Windows.Forms.TextBox txt_detalle_pedido_cod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbx_plato_cod;
        private System.Windows.Forms.TextBox txt_detalle_pedido_pre;
        private System.Windows.Forms.TextBox txt_detalle_pedido_cant;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}