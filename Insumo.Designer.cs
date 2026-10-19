namespace RESTAURANTEFINAL
{
    partial class Insumo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Insumo));
            this.btn_insumo_guardar = new System.Windows.Forms.Button();
            this.btn_insumo_nuevo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbx_insumo_clasi_cod = new System.Windows.Forms.ComboBox();
            this.cbx_insumo_uni_med_cod = new System.Windows.Forms.ComboBox();
            this.txt_insumo_nom = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_insumo_cod = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_insumo_prec_unitario = new System.Windows.Forms.TextBox();
            this.txt_insumo_buscar = new System.Windows.Forms.TextBox();
            this.btn_insumo_eliminar = new System.Windows.Forms.Button();
            this.dataGridView_Insumo = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Insumo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_insumo_nuevo
            // 
            this.btn_insumo_nuevo.Location = new System.Drawing.Point(13, 332);
            this.btn_insumo_nuevo.Name = "btn_insumo_nuevo";
            this.btn_insumo_nuevo.Size = new System.Drawing.Size(100, 30);
            this.btn_insumo_nuevo.TabIndex = 20;
            this.btn_insumo_nuevo.Text = "Nuevo";
            this.btn_insumo_nuevo.UseVisualStyleBackColor = true;
            this.btn_insumo_nuevo.Click += new System.EventHandler(this.btn_insumo_nuevo_Click);
            // 
            // btn_insumo_guardar
            // 
            this.btn_insumo_guardar.Location = new System.Drawing.Point(123, 332);
            this.btn_insumo_guardar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_insumo_guardar.Name = "btn_insumo_guardar";
            this.btn_insumo_guardar.Size = new System.Drawing.Size(100, 30);
            this.btn_insumo_guardar.TabIndex = 18;
            this.btn_insumo_guardar.Text = "Guardar";
            this.btn_insumo_guardar.UseVisualStyleBackColor = true;
            this.btn_insumo_guardar.Click += new System.EventHandler(this.btn_insumo_guardar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbx_insumo_clasi_cod);
            this.groupBox1.Controls.Add(this.cbx_insumo_uni_med_cod);
            this.groupBox1.Controls.Add(this.btn_insumo_eliminar);
            this.groupBox1.Controls.Add(this.txt_insumo_nom);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_insumo_cod);
            this.groupBox1.Controls.Add(this.btn_insumo_nuevo);
            this.groupBox1.Controls.Add(this.btn_insumo_guardar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_insumo_prec_unitario);
            this.groupBox1.Location = new System.Drawing.Point(576, 80);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(347, 384);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Insumo";
            // 
            // cbx_insumo_clasi_cod
            // 
            this.cbx_insumo_clasi_cod.FormattingEnabled = true;
            this.cbx_insumo_clasi_cod.Location = new System.Drawing.Point(191, 288);
            this.cbx_insumo_clasi_cod.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbx_insumo_clasi_cod.Name = "cbx_insumo_clasi_cod";
            this.cbx_insumo_clasi_cod.Size = new System.Drawing.Size(132, 25);
            this.cbx_insumo_clasi_cod.TabIndex = 24;
            // 
            // cbx_insumo_uni_med_cod
            // 
            this.cbx_insumo_uni_med_cod.FormattingEnabled = true;
            this.cbx_insumo_uni_med_cod.Location = new System.Drawing.Point(191, 168);
            this.cbx_insumo_uni_med_cod.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbx_insumo_uni_med_cod.Name = "cbx_insumo_uni_med_cod";
            this.cbx_insumo_uni_med_cod.Size = new System.Drawing.Size(132, 25);
            this.cbx_insumo_uni_med_cod.TabIndex = 23;
            // 
            // txt_insumo_nom
            // 
            this.txt_insumo_nom.Location = new System.Drawing.Point(191, 103);
            this.txt_insumo_nom.Margin = new System.Windows.Forms.Padding(4);
            this.txt_insumo_nom.Name = "txt_insumo_nom";
            this.txt_insumo_nom.Size = new System.Drawing.Size(132, 23);
            this.txt_insumo_nom.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 176);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Codigo unidad medida";
            // 
            // txt_insumo_cod
            // 
            this.txt_insumo_cod.Location = new System.Drawing.Point(191, 40);
            this.txt_insumo_cod.Margin = new System.Windows.Forms.Padding(4);
            this.txt_insumo_cod.Name = "txt_insumo_cod";
            this.txt_insumo_cod.ReadOnly = true;
            this.txt_insumo_cod.Size = new System.Drawing.Size(132, 23);
            this.txt_insumo_cod.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 113);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre";
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
            this.label3.Location = new System.Drawing.Point(36, 237);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Precio unitario";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 296);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Codigo clasificacion";
            // 
            // txt_insumo_prec_unitario
            // 
            this.txt_insumo_prec_unitario.Location = new System.Drawing.Point(191, 227);
            this.txt_insumo_prec_unitario.Margin = new System.Windows.Forms.Padding(4);
            this.txt_insumo_prec_unitario.Name = "txt_insumo_prec_unitario";
            this.txt_insumo_prec_unitario.Size = new System.Drawing.Size(132, 23);
            this.txt_insumo_prec_unitario.TabIndex = 8;
            // 
            // txt_insumo_buscar
            // 
            this.txt_insumo_buscar.Location = new System.Drawing.Point(13, 80);
            this.txt_insumo_buscar.Margin = new System.Windows.Forms.Padding(4);
            this.txt_insumo_buscar.Name = "txt_insumo_buscar";
            this.txt_insumo_buscar.Size = new System.Drawing.Size(453, 23);
            this.txt_insumo_buscar.TabIndex = 36;
            this.txt_insumo_buscar.TextChanged += new System.EventHandler(this.txt_insumo_buscar_TextChanged);
            // 
            // btn_insumo_eliminar
            // 
            this.btn_insumo_eliminar.Location = new System.Drawing.Point(233, 332);
            this.btn_insumo_eliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_insumo_eliminar.Name = "btn_insumo_eliminar";
            this.btn_insumo_eliminar.Size = new System.Drawing.Size(100, 30);
            this.btn_insumo_eliminar.TabIndex = 35;
            this.btn_insumo_eliminar.Text = "Eliminar";
            this.btn_insumo_eliminar.UseVisualStyleBackColor = true;
            this.btn_insumo_eliminar.Click += new System.EventHandler(this.btn_insumo_eliminar_Click);
            // 
            // dataGridView_Insumo
            // 
            this.dataGridView_Insumo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Insumo.Location = new System.Drawing.Point(13, 111);
            this.dataGridView_Insumo.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView_Insumo.Name = "dataGridView_Insumo";
            this.dataGridView_Insumo.RowHeadersWidth = 51;
            this.dataGridView_Insumo.Size = new System.Drawing.Size(552, 368);
            this.dataGridView_Insumo.TabIndex = 34;
            this.dataGridView_Insumo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView6_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 37;
            this.label1.Text = "Buscar:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(460, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(110, 91);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            // 
            // Insumo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 500);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_insumo_buscar);
            this.Controls.Add(this.dataGridView_Insumo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Insumo";
            this.Text = "\"INSUMO\"";
            this.Load += new System.EventHandler(this.Insumo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Insumo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_insumo_guardar;
        private System.Windows.Forms.Button btn_insumo_nuevo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbx_insumo_clasi_cod;
        private System.Windows.Forms.ComboBox cbx_insumo_uni_med_cod;
        private System.Windows.Forms.TextBox txt_insumo_nom;
        private System.Windows.Forms.TextBox txt_insumo_cod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_insumo_prec_unitario;
        private System.Windows.Forms.TextBox txt_insumo_buscar;
        private System.Windows.Forms.Button btn_insumo_eliminar;
        private System.Windows.Forms.DataGridView dataGridView_Insumo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}