namespace login.Bar
{
    partial class UCVentasBar
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
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.btnMenos = new Guna.UI2.WinForms.Guna2Button();
            this.btnMas = new Guna.UI2.WinForms.Guna2Button();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(29, 25);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(93, 25);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Producto:";
            this.lblNombre.Click += new System.EventHandler(this.lblNombre_Click);
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(265, 25);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(78, 25);
            this.lblPrecio.TabIndex = 1;
            this.lblPrecio.Text = "$Precio:";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(191, 65);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(22, 25);
            this.lblCantidad.TabIndex = 2;
            this.lblCantidad.Text = "0";
            // 
            // btnMenos
            // 
            this.btnMenos.BorderRadius = 3;
            this.btnMenos.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMenos.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMenos.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMenos.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMenos.FillColor = System.Drawing.Color.LightGray;
            this.btnMenos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenos.ForeColor = System.Drawing.Color.White;
            this.btnMenos.Location = new System.Drawing.Point(159, 64);
            this.btnMenos.Name = "btnMenos";
            this.btnMenos.Size = new System.Drawing.Size(26, 26);
            this.btnMenos.TabIndex = 3;
            this.btnMenos.Text = "+";
            this.btnMenos.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnMenos.Click += new System.EventHandler(this.btnMenos_Click);
            // 
            // btnMas
            // 
            this.btnMas.BorderRadius = 3;
            this.btnMas.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMas.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMas.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMas.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMas.FillColor = System.Drawing.Color.LightGray;
            this.btnMas.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMas.ForeColor = System.Drawing.Color.White;
            this.btnMas.Location = new System.Drawing.Point(219, 64);
            this.btnMas.Name = "btnMas";
            this.btnMas.Size = new System.Drawing.Size(26, 26);
            this.btnMas.TabIndex = 4;
            this.btnMas.Text = "-";
            this.btnMas.Click += new System.EventHandler(this.btnMas_Click);
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.Location = new System.Drawing.Point(18, 150);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(87, 25);
            this.lblSubtotal.TabIndex = 5;
            this.lblSubtotal.Text = "Subtotal:";
            // 
            // UCVentasBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblSubtotal);
            this.Controls.Add(this.btnMas);
            this.Controls.Add(this.btnMenos);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblNombre);
            this.Name = "UCVentasBar";
            this.Size = new System.Drawing.Size(391, 190);
            this.Load += new System.EventHandler(this.UCVentasBar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblCantidad;
        private Guna.UI2.WinForms.Guna2Button btnMenos;
        private Guna.UI2.WinForms.Guna2Button btnMas;
        private System.Windows.Forms.Label lblSubtotal;
    }
}
