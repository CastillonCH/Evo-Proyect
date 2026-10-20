namespace RESTAURANTEFINAL
{
    partial class FrmPestanas
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
            this.tabPestanas = new System.Windows.Forms.TabControl();
            this.tabPestanas.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPestanas
            // 
            this.tabPestanas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPestanas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPestanas.Location = new System.Drawing.Point(0, 0);
            this.tabPestanas.Name = "tabPestanas";
            this.tabPestanas.Padding = new System.Drawing.Point(16, 6);
            this.tabPestanas.SelectedIndex = 0;
            this.tabPestanas.Size = new System.Drawing.Size(1050, 690);
            this.tabPestanas.TabIndex = 0;
            // 
            // FrmPestanas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 690);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmPestanas";
            this.Text = "Administración";
            this.Controls.Add(this.tabPestanas);
            this.tabPestanas.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabPestanas;
    }
}
