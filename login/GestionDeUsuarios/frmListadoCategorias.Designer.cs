namespace login.GestionDeUsuarios
{
    partial class frmListadoCategorias
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
            this.rvwCategorias = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvwCategorias
            // 
            this.rvwCategorias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvwCategorias.Location = new System.Drawing.Point(0, 0);
            this.rvwCategorias.Name = "rvwCategorias";
            this.rvwCategorias.ServerReport.BearerToken = null;
            this.rvwCategorias.Size = new System.Drawing.Size(800, 450);
            this.rvwCategorias.TabIndex = 0;
            this.rvwCategorias.Load += new System.EventHandler(this.rvwCategorias_Load);
            // 
            // frmListadoCategorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rvwCategorias);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmListadoCategorias";
            this.Text = "frmListadoCategorias";
            this.Load += new System.EventHandler(this.frmListadoCategorias_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvwCategorias;
    }
}