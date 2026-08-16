namespace login.Bar
{
    partial class UCTarjetaProducto
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCTarjetaProducto));
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.pbImagen = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnAnadir = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPrecio
            // 
            this.lblPrecio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.ForeColor = System.Drawing.Color.Green;
            this.lblPrecio.Location = new System.Drawing.Point(16, 237);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(197, 22);
            this.lblPrecio.TabIndex = 13;
            this.lblPrecio.Text = "$ 0.50";
            this.lblPrecio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNombre
            // 
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(110)))), ((int)(((byte)(138)))));
            this.lblNombre.Location = new System.Drawing.Point(24, 200);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(197, 23);
            this.lblNombre.TabIndex = 12;
            this.lblNombre.Text = "Agua 600 ml";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbImagen
            // 
            this.pbImagen.ImageRotate = 0F;
            this.pbImagen.Location = new System.Drawing.Point(36, 17);
            this.pbImagen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbImagen.Name = "pbImagen";
            this.pbImagen.Size = new System.Drawing.Size(163, 181);
            this.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImagen.TabIndex = 10;
            this.pbImagen.TabStop = false;
            // 
            // btnAnadir
            // 
            this.btnAnadir.BorderColor = System.Drawing.Color.Silver;
            this.btnAnadir.BorderRadius = 11;
            this.btnAnadir.BorderThickness = 1;
            this.btnAnadir.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAnadir.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAnadir.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAnadir.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAnadir.FillColor = System.Drawing.Color.LightBlue;
            this.btnAnadir.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnadir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(37)))), ((int)(((byte)(87)))));
            this.btnAnadir.Image = ((System.Drawing.Image)(resources.GetObject("btnAnadir.Image")));
            this.btnAnadir.ImageSize = new System.Drawing.Size(30, 30);
            this.btnAnadir.Location = new System.Drawing.Point(20, 272);
            this.btnAnadir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAnadir.Name = "btnAnadir";
            this.btnAnadir.Size = new System.Drawing.Size(197, 39);
            this.btnAnadir.TabIndex = 11;
            this.btnAnadir.Text = "Añadir";
            this.btnAnadir.Click += new System.EventHandler(this.btnAnadir_Click);
            // 
            // UCTarjetaProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.pbImagen);
            this.Controls.Add(this.btnAnadir);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(240, 340);
            this.Name = "UCTarjetaProducto";
            this.Size = new System.Drawing.Size(240, 357);
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblNombre;
        private Guna.UI2.WinForms.Guna2PictureBox pbImagen;
        private Guna.UI2.WinForms.Guna2Button btnAnadir;
    }
}
