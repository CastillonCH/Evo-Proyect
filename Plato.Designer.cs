namespace RESTAURANTEFINAL
{
    partial class Plato
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Plato));
            this.btn_plato_guardar = new System.Windows.Forms.Button();
            this.btn_plato_nuevo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbx_promocion_cod = new System.Windows.Forms.ComboBox();
            this.txt_plato_cod = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_plato_nom = new System.Windows.Forms.TextBox();
            this.txt_plato_pre = new System.Windows.Forms.TextBox();
            this.txt_plato_des = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView_Plato = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_plato_buscar = new System.Windows.Forms.TextBox();
            this.btn_plato_eliminar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Plato)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_plato_nuevo
            // 
            this.btn_plato_nuevo.Location = new System.Drawing.Point(24, 326);
            this.btn_plato_nuevo.Name = "btn_plato_nuevo";
            this.btn_plato_nuevo.Size = new System.Drawing.Size(100, 28);
            this.btn_plato_nuevo.TabIndex = 20;
            this.btn_plato_nuevo.Text = "Nuevo";
            this.btn_plato_nuevo.UseVisualStyleBackColor = true;
            this.btn_plato_nuevo.Click += new System.EventHandler(this.btn_plato_nuevo_Click);
            // 
            // btn_plato_guardar
            // 
            this.btn_plato_guardar.Location = new System.Drawing.Point(134, 326);
            this.btn_plato_guardar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_plato_guardar.Name = "btn_plato_guardar";
            this.btn_plato_guardar.Size = new System.Drawing.Size(100, 28);
            this.btn_plato_guardar.TabIndex = 22;
            this.btn_plato_guardar.Text = "Guardar";
            this.btn_plato_guardar.UseVisualStyleBackColor = true;
            this.btn_plato_guardar.Click += new System.EventHandler(this.btn_plato_guardar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbx_promocion_cod);
            this.groupBox1.Controls.Add(this.btn_plato_eliminar);
            this.groupBox1.Controls.Add(this.txt_plato_cod);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btn_plato_nuevo);
            this.groupBox1.Controls.Add(this.btn_plato_guardar);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_plato_nom);
            this.groupBox1.Controls.Add(this.txt_plato_pre);
            this.groupBox1.Controls.Add(this.txt_plato_des);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(517, 85);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(369, 378);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Plato";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 160);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 25;
            this.label1.Text = "Precio:";
            // 
            // cbx_promocion_cod
            // 
            this.cbx_promocion_cod.FormattingEnabled = true;
            this.cbx_promocion_cod.Location = new System.Drawing.Point(191, 218);
            this.cbx_promocion_cod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbx_promocion_cod.Name = "cbx_promocion_cod";
            this.cbx_promocion_cod.Size = new System.Drawing.Size(127, 24);
            this.cbx_promocion_cod.TabIndex = 24;
            // 
            // txt_plato_cod
            // 
            this.txt_plato_cod.Location = new System.Drawing.Point(191, 38);
            this.txt_plato_cod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_plato_cod.Name = "txt_plato_cod";
            this.txt_plato_cod.ReadOnly = true;
            this.txt_plato_cod.Size = new System.Drawing.Size(132, 22);
            this.txt_plato_cod.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 106);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre:\r\n";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 47);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Código:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 282);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Descripción:";
            // 
            // txt_plato_nom
            // 
            this.txt_plato_nom.Location = new System.Drawing.Point(191, 97);
            this.txt_plato_nom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_plato_nom.Name = "txt_plato_nom";
            this.txt_plato_nom.Size = new System.Drawing.Size(132, 22);
            this.txt_plato_nom.TabIndex = 3;
            // 
            // txt_plato_pre
            // 
            this.txt_plato_pre.Location = new System.Drawing.Point(191, 154);
            this.txt_plato_pre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_plato_pre.Name = "txt_plato_pre";
            this.txt_plato_pre.Size = new System.Drawing.Size(132, 22);
            this.txt_plato_pre.TabIndex = 10;
            // 
            // txt_plato_des
            // 
            this.txt_plato_des.Location = new System.Drawing.Point(191, 273);
            this.txt_plato_des.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_plato_des.Name = "txt_plato_des";
            this.txt_plato_des.Size = new System.Drawing.Size(132, 22);
            this.txt_plato_des.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 222);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Código Promoción";
            // 
            // dataGridView_Plato
            // 
            this.dataGridView_Plato.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Plato.Location = new System.Drawing.Point(13, 85);
            this.dataGridView_Plato.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView_Plato.Name = "dataGridView_Plato";
            this.dataGridView_Plato.RowHeadersWidth = 51;
            this.dataGridView_Plato.Size = new System.Drawing.Size(467, 383);
            this.dataGridView_Plato.TabIndex = 26;
            this.dataGridView_Plato.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Plato_CellClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 35);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 16);
            this.label6.TabIndex = 31;
            this.label6.Text = "Buscar:";
            // 
            // txt_plato_buscar
            // 
            this.txt_plato_buscar.Location = new System.Drawing.Point(13, 55);
            this.txt_plato_buscar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_plato_buscar.Name = "txt_plato_buscar";
            this.txt_plato_buscar.Size = new System.Drawing.Size(453, 22);
            this.txt_plato_buscar.TabIndex = 30;
            this.txt_plato_buscar.TextChanged += new System.EventHandler(this.txt_plato_buscar_TextChanged);
            // 
            // btn_plato_eliminar
            // 
            this.btn_plato_eliminar.Location = new System.Drawing.Point(244, 326);
            this.btn_plato_eliminar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_plato_eliminar.Name = "btn_plato_eliminar";
            this.btn_plato_eliminar.Size = new System.Drawing.Size(100, 28);
            this.btn_plato_eliminar.TabIndex = 29;
            this.btn_plato_eliminar.Text = "Eliminar";
            this.btn_plato_eliminar.UseVisualStyleBackColor = true;
            this.btn_plato_eliminar.Click += new System.EventHandler(this.btn_plato_eliminar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(473, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 77);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // Plato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 487);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_plato_buscar);
            this.Controls.Add(this.dataGridView_Plato);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Plato";
            this.Text = "\"PLATO\"";
            this.Load += new System.EventHandler(this.Plato_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Plato)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_plato_guardar;
        private System.Windows.Forms.Button btn_plato_nuevo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbx_promocion_cod;
        private System.Windows.Forms.TextBox txt_plato_cod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_plato_nom;
        private System.Windows.Forms.TextBox txt_plato_pre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_plato_des;
        private System.Windows.Forms.DataGridView dataGridView_Plato;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_plato_buscar;
        private System.Windows.Forms.Button btn_plato_eliminar;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}