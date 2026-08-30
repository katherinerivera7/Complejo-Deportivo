namespace login.Bar
{
    partial class frmListadoCanchas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListadoCanchas));
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.btnVolver = new Guna.UI2.WinForms.Guna2Button();
            this.rvwCanchas = new Microsoft.Reporting.WinForms.ReportViewer();
            this.pnlContenido.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContenido
            // 
            this.pnlContenido.Controls.Add(this.btnVolver);
            this.pnlContenido.Controls.Add(this.rvwCanchas);
            this.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenido.Location = new System.Drawing.Point(0, 0);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(1296, 554);
            this.pnlContenido.TabIndex = 0;
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.White;
            this.btnVolver.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnVolver.BorderRadius = 14;
            this.btnVolver.BorderThickness = 1;
            this.btnVolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVolver.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnVolver.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnVolver.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnVolver.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnVolver.FillColor = System.Drawing.Color.White;
            this.btnVolver.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnVolver.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnVolver.Image = ((System.Drawing.Image)(resources.GetObject("btnVolver.Image")));
            this.btnVolver.Location = new System.Drawing.Point(1099, 54);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(171, 48);
            this.btnVolver.TabIndex = 92;
            this.btnVolver.Text = "Volver";
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click_1);
            // 
            // rvwCanchas
            // 
            this.rvwCanchas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvwCanchas.Location = new System.Drawing.Point(0, 0);
            this.rvwCanchas.Margin = new System.Windows.Forms.Padding(4);
            this.rvwCanchas.Name = "rvwCanchas";
            this.rvwCanchas.ServerReport.BearerToken = null;
            this.rvwCanchas.Size = new System.Drawing.Size(1296, 554);
            this.rvwCanchas.TabIndex = 91;
            // 
            // frmListadoCanchas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1296, 554);
            this.Controls.Add(this.pnlContenido);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmListadoCanchas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmListadoCanchas";
            this.Load += new System.EventHandler(this.frmListadoCanchas_Load);
            this.pnlContenido.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContenido;
        private Guna.UI2.WinForms.Guna2Button btnVolver;
        private Microsoft.Reporting.WinForms.ReportViewer rvwCanchas;
    }
}