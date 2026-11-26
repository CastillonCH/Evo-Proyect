namespace RESTAURANTEFINAL
{
    partial class Sede
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sede));
            this.label1 = new System.Windows.Forms.Label();
            this.txt_sede_buscar = new System.Windows.Forms.TextBox();
            this.btn_sede_eliminar = new System.Windows.Forms.Button();
            this.dataGridView_sede = new System.Windows.Forms.DataGridView();
            this.btn_sede_guardar = new System.Windows.Forms.Button();
            this.btn_sede_nuevo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker_cierre = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_apertura = new System.Windows.Forms.DateTimePicker();
            this.txt_sede_cod = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_sede_nom = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_sede_tel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_sede_dir = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_sede)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 33;
            this.label1.Text = "Buscar:";
            // 
            // txt_sede_buscar
            // 
            this.txt_sede_buscar.Location = new System.Drawing.Point(13, 63);
            this.txt_sede_buscar.Margin = new System.Windows.Forms.Padding(4);
            this.txt_sede_buscar.Name = "txt_sede_buscar";
            this.txt_sede_buscar.Size = new System.Drawing.Size(453, 23);
            this.txt_sede_buscar.TabIndex = 32;
            this.txt_sede_buscar.TextChanged += new System.EventHandler(this.txt_sede_buscar_TextChanged);
            // 
            // btn_sede_eliminar
            // 
            this.btn_sede_eliminar.Location = new System.Drawing.Point(244, 350);
            this.btn_sede_eliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_sede_eliminar.Name = "btn_sede_eliminar";
            this.btn_sede_eliminar.Size = new System.Drawing.Size(100, 30);
            this.btn_sede_eliminar.TabIndex = 31;
            this.btn_sede_eliminar.Text = "Eliminar";
            this.btn_sede_eliminar.UseVisualStyleBackColor = true;
            this.btn_sede_eliminar.Click += new System.EventHandler(this.btn_sede_eliminar_Click);
            // 
            // dataGridView_sede
            // 
            this.dataGridView_sede.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_sede.Location = new System.Drawing.Point(12, 99);
            this.dataGridView_sede.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView_sede.Name = "dataGridView_sede";
            this.dataGridView_sede.RowHeadersWidth = 51;
            this.dataGridView_sede.Size = new System.Drawing.Size(571, 333);
            this.dataGridView_sede.TabIndex = 30;
            this.dataGridView_sede.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_sede_CellClick);
            // 
            // btn_sede_nuevo
            // 
            this.btn_sede_nuevo.Location = new System.Drawing.Point(24, 350);
            this.btn_sede_nuevo.Name = "btn_sede_nuevo";
            this.btn_sede_nuevo.Size = new System.Drawing.Size(100, 30);
            this.btn_sede_nuevo.TabIndex = 20;
            this.btn_sede_nuevo.Text = "Nuevo";
            this.btn_sede_nuevo.UseVisualStyleBackColor = true;
            this.btn_sede_nuevo.Click += new System.EventHandler(this.btn_sede_nuevo_Click);
            // 
            // btn_sede_guardar
            // 
            this.btn_sede_guardar.Location = new System.Drawing.Point(134, 350);
            this.btn_sede_guardar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_sede_guardar.Name = "btn_sede_guardar";
            this.btn_sede_guardar.Size = new System.Drawing.Size(100, 30);
            this.btn_sede_guardar.TabIndex = 29;
            this.btn_sede_guardar.Text = "Guardar";
            this.btn_sede_guardar.UseVisualStyleBackColor = true;
            this.btn_sede_guardar.Click += new System.EventHandler(this.btn_sede_guardar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePicker_cierre);
            this.groupBox1.Controls.Add(this.dateTimePicker_apertura);
            this.groupBox1.Controls.Add(this.btn_sede_eliminar);
            this.groupBox1.Controls.Add(this.txt_sede_cod);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btn_sede_nuevo);
            this.groupBox1.Controls.Add(this.btn_sede_guardar);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_sede_nom);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_sede_tel);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_sede_dir);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(611, 29);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(369, 403);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de Sede";
            // 
            // dateTimePicker_cierre
            // 
            this.dateTimePicker_cierre.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker_cierre.Location = new System.Drawing.Point(175, 290);
            this.dateTimePicker_cierre.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker_cierre.Name = "dateTimePicker_cierre";
            this.dateTimePicker_cierre.Size = new System.Drawing.Size(132, 23);
            this.dateTimePicker_cierre.TabIndex = 41;
            // 
            // dateTimePicker_apertura
            // 
            this.dateTimePicker_apertura.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker_apertura.Location = new System.Drawing.Point(175, 237);
            this.dateTimePicker_apertura.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker_apertura.Name = "dateTimePicker_apertura";
            this.dateTimePicker_apertura.Size = new System.Drawing.Size(132, 23);
            this.dateTimePicker_apertura.TabIndex = 40;
            // 
            // txt_sede_cod
            // 
            this.txt_sede_cod.Location = new System.Drawing.Point(175, 37);
            this.txt_sede_cod.Margin = new System.Windows.Forms.Padding(4);
            this.txt_sede_cod.Name = "txt_sede_cod";
            this.txt_sede_cod.ReadOnly = true;
            this.txt_sede_cod.Size = new System.Drawing.Size(132, 23);
            this.txt_sede_cod.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 89);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre:\r\n";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 40);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Código:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 139);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Dirección:";
            // 
            // txt_sede_nom
            // 
            this.txt_sede_nom.Location = new System.Drawing.Point(175, 86);
            this.txt_sede_nom.Margin = new System.Windows.Forms.Padding(4);
            this.txt_sede_nom.Name = "txt_sede_nom";
            this.txt_sede_nom.Size = new System.Drawing.Size(132, 23);
            this.txt_sede_nom.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 195);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Teléfono:";
            // 
            // txt_sede_tel
            // 
            this.txt_sede_tel.Location = new System.Drawing.Point(175, 189);
            this.txt_sede_tel.Margin = new System.Windows.Forms.Padding(4);
            this.txt_sede_tel.Name = "txt_sede_tel";
            this.txt_sede_tel.Size = new System.Drawing.Size(132, 23);
            this.txt_sede_tel.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 242);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Hora Apertura:";
            // 
            // txt_sede_dir
            // 
            this.txt_sede_dir.Location = new System.Drawing.Point(175, 139);
            this.txt_sede_dir.Margin = new System.Windows.Forms.Padding(4);
            this.txt_sede_dir.Name = "txt_sede_dir";
            this.txt_sede_dir.Size = new System.Drawing.Size(132, 23);
            this.txt_sede_dir.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 296);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "Hora Cierre:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(483, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(121, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // Sede
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 447);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_sede_buscar);
            this.Controls.Add(this.dataGridView_sede);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Sede";
            this.Text = "\"SEDE\"";
            this.Load += new System.EventHandler(this.Sede_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_sede)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_sede_buscar;
        private System.Windows.Forms.Button btn_sede_eliminar;
        private System.Windows.Forms.DataGridView dataGridView_sede;
        private System.Windows.Forms.Button btn_sede_guardar;
        private System.Windows.Forms.Button btn_sede_nuevo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_sede_cod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_sede_nom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_sede_tel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_sede_dir;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker_apertura;
        private System.Windows.Forms.DateTimePicker dateTimePicker_cierre;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}