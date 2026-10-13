namespace RESTAURANTEFINAL
{
    partial class Cliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cliente));
            this.btn_cliente_guardar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_cliente_dir = new System.Windows.Forms.TextBox();
            this.txt_cliente_cod = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_cliente_nom = new System.Windows.Forms.TextBox();
            this.txt_cliente_email = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_cliente_tel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_cliente_ape = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView_cliente = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_cliente_buscar = new System.Windows.Forms.TextBox();
            this.btn_cliente_eliminar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_cliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_cliente_guardar
            // 
            this.btn_cliente_guardar.Location = new System.Drawing.Point(72, 397);
            this.btn_cliente_guardar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_cliente_guardar.Name = "btn_cliente_guardar";
            this.btn_cliente_guardar.Size = new System.Drawing.Size(100, 30);
            this.btn_cliente_guardar.TabIndex = 18;
            this.btn_cliente_guardar.Text = "Guardar";
            this.btn_cliente_guardar.UseVisualStyleBackColor = true;
            this.btn_cliente_guardar.Click += new System.EventHandler(this.btn_cliente_guardar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_cliente_dir);
            this.groupBox1.Controls.Add(this.txt_cliente_cod);
            this.groupBox1.Controls.Add(this.btn_cliente_eliminar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btn_cliente_guardar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_cliente_nom);
            this.groupBox1.Controls.Add(this.txt_cliente_email);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_cliente_tel);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_cliente_ape);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(628, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(364, 435);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de Cliente";
            // 
            // txt_cliente_dir
            // 
            this.txt_cliente_dir.Location = new System.Drawing.Point(191, 351);
            this.txt_cliente_dir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_cliente_dir.Name = "txt_cliente_dir";
            this.txt_cliente_dir.Size = new System.Drawing.Size(132, 23);
            this.txt_cliente_dir.TabIndex = 11;
            // 
            // txt_cliente_cod
            // 
            this.txt_cliente_cod.Location = new System.Drawing.Point(191, 40);
            this.txt_cliente_cod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_cliente_cod.Name = "txt_cliente_cod";
            this.txt_cliente_cod.Size = new System.Drawing.Size(132, 23);
            this.txt_cliente_cod.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 113);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre:\r\n";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 50);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Código:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 176);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Apellido:";
            // 
            // txt_cliente_nom
            // 
            this.txt_cliente_nom.Location = new System.Drawing.Point(191, 103);
            this.txt_cliente_nom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_cliente_nom.Name = "txt_cliente_nom";
            this.txt_cliente_nom.Size = new System.Drawing.Size(132, 23);
            this.txt_cliente_nom.TabIndex = 3;
            // 
            // txt_cliente_email
            // 
            this.txt_cliente_email.Location = new System.Drawing.Point(191, 288);
            this.txt_cliente_email.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_cliente_email.Name = "txt_cliente_email";
            this.txt_cliente_email.Size = new System.Drawing.Size(132, 23);
            this.txt_cliente_email.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 236);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Teléfono:";
            // 
            // txt_cliente_tel
            // 
            this.txt_cliente_tel.Location = new System.Drawing.Point(191, 226);
            this.txt_cliente_tel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_cliente_tel.Name = "txt_cliente_tel";
            this.txt_cliente_tel.Size = new System.Drawing.Size(132, 23);
            this.txt_cliente_tel.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 296);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Email:";
            // 
            // txt_cliente_ape
            // 
            this.txt_cliente_ape.Location = new System.Drawing.Point(191, 168);
            this.txt_cliente_ape.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_cliente_ape.Name = "txt_cliente_ape";
            this.txt_cliente_ape.Size = new System.Drawing.Size(132, 23);
            this.txt_cliente_ape.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 359);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "Dirección:";
            // 
            // dataGridView_cliente
            // 
            this.dataGridView_cliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_cliente.Location = new System.Drawing.Point(24, 90);
            this.dataGridView_cliente.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView_cliente.Name = "dataGridView_cliente";
            this.dataGridView_cliente.RowHeadersWidth = 51;
            this.dataGridView_cliente.Size = new System.Drawing.Size(571, 358);
            this.dataGridView_cliente.TabIndex = 20;
            this.dataGridView_cliente.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_cliente_CellClick);
            this.dataGridView_cliente.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_cliente_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 27;
            this.label1.Text = "Nombre:";
            // 
            // txt_cliente_buscar
            // 
            this.txt_cliente_buscar.Location = new System.Drawing.Point(23, 59);
            this.txt_cliente_buscar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_cliente_buscar.Name = "txt_cliente_buscar";
            this.txt_cliente_buscar.Size = new System.Drawing.Size(453, 23);
            this.txt_cliente_buscar.TabIndex = 26;
            this.txt_cliente_buscar.TextChanged += new System.EventHandler(this.txt_cliente_buscar_TextChanged);
            // 
            // btn_cliente_eliminar
            // 
            this.btn_cliente_eliminar.Location = new System.Drawing.Point(200, 397);
            this.btn_cliente_eliminar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_cliente_eliminar.Name = "btn_cliente_eliminar";
            this.btn_cliente_eliminar.Size = new System.Drawing.Size(100, 30);
            this.btn_cliente_eliminar.TabIndex = 25;
            this.btn_cliente_eliminar.Text = "Eliminar";
            this.btn_cliente_eliminar.UseVisualStyleBackColor = true;
            this.btn_cliente_eliminar.Click += new System.EventHandler(this.btn_cliente_eliminar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(503, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(118, 105);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 468);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_cliente_buscar);
            this.Controls.Add(this.dataGridView_cliente);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Cliente";
            this.Text = "\"CLIENTES\"";
            this.Load += new System.EventHandler(this.Cliente_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_cliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_cliente_guardar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_cliente_dir;
        private System.Windows.Forms.TextBox txt_cliente_cod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_cliente_nom;
        private System.Windows.Forms.TextBox txt_cliente_email;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_cliente_tel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_cliente_ape;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridView_cliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_cliente_buscar;
        private System.Windows.Forms.Button btn_cliente_eliminar;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}