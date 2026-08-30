namespace login.Bar
{
    partial class frmRegistrarMovimiento
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
            this.lblCrearProducto = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbProducto = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTipoMovimiento = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCantidad = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbMotivo = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtOtro = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnCrear = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // lblCrearProducto
            // 
            this.lblCrearProducto.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrearProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(37)))), ((int)(((byte)(87)))));
            this.lblCrearProducto.Location = new System.Drawing.Point(101, 32);
            this.lblCrearProducto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCrearProducto.Name = "lblCrearProducto";
            this.lblCrearProducto.Size = new System.Drawing.Size(386, 41);
            this.lblCrearProducto.TabIndex = 65;
            this.lblCrearProducto.Text = "Registrar movimiento";
            this.lblCrearProducto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(37)))), ((int)(((byte)(87)))));
            this.label1.Location = new System.Drawing.Point(87, 94);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 41);
            this.label1.TabIndex = 68;
            this.label1.Text = "Producto";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbProducto
            // 
            this.cmbProducto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbProducto.BackColor = System.Drawing.Color.Transparent;
            this.cmbProducto.BorderRadius = 12;
            this.cmbProducto.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProducto.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cmbProducto.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cmbProducto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbProducto.ItemHeight = 30;
            this.cmbProducto.Location = new System.Drawing.Point(269, 99);
            this.cmbProducto.Margin = new System.Windows.Forms.Padding(2);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(228, 36);
            this.cmbProducto.TabIndex = 0;
            this.cmbProducto.SelectedIndexChanged += new System.EventHandler(this.cmbProducto_SelectedIndexChanged);
            this.cmbProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbProducto_KeyDown);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(37)))), ((int)(((byte)(87)))));
            this.label2.Location = new System.Drawing.Point(87, 159);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 41);
            this.label2.TabIndex = 70;
            this.label2.Text = "Tipo de movimiento";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbTipoMovimiento
            // 
            this.cmbTipoMovimiento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbTipoMovimiento.BackColor = System.Drawing.Color.Transparent;
            this.cmbTipoMovimiento.BorderRadius = 12;
            this.cmbTipoMovimiento.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTipoMovimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoMovimiento.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cmbTipoMovimiento.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cmbTipoMovimiento.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTipoMovimiento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbTipoMovimiento.ItemHeight = 30;
            this.cmbTipoMovimiento.Items.AddRange(new object[] {
            "Entrada",
            "Salida"});
            this.cmbTipoMovimiento.Location = new System.Drawing.Point(269, 164);
            this.cmbTipoMovimiento.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTipoMovimiento.Name = "cmbTipoMovimiento";
            this.cmbTipoMovimiento.Size = new System.Drawing.Size(228, 36);
            this.cmbTipoMovimiento.StartIndex = 0;
            this.cmbTipoMovimiento.TabIndex = 1;
            this.cmbTipoMovimiento.SelectedIndexChanged += new System.EventHandler(this.cmbTipoMovimiento_SelectedIndexChanged);
            this.cmbTipoMovimiento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbTipoMovimiento_KeyDown);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(37)))), ((int)(((byte)(87)))));
            this.label3.Location = new System.Drawing.Point(87, 318);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 41);
            this.label3.TabIndex = 72;
            this.label3.Text = "Cantidad";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCantidad
            // 
            this.txtCantidad.BorderRadius = 12;
            this.txtCantidad.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCantidad.DefaultText = "";
            this.txtCantidad.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCantidad.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCantidad.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCantidad.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCantidad.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCantidad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCantidad.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCantidad.Location = new System.Drawing.Point(382, 322);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.PlaceholderText = "";
            this.txtCantidad.SelectedText = "";
            this.txtCantidad.Size = new System.Drawing.Size(115, 37);
            this.txtCantidad.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(37)))), ((int)(((byte)(87)))));
            this.label4.Location = new System.Drawing.Point(87, 231);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 41);
            this.label4.TabIndex = 73;
            this.label4.Text = "Motivo";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbMotivo
            // 
            this.cmbMotivo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbMotivo.BackColor = System.Drawing.Color.Transparent;
            this.cmbMotivo.BorderRadius = 12;
            this.cmbMotivo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbMotivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMotivo.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cmbMotivo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cmbMotivo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbMotivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbMotivo.ItemHeight = 30;
            this.cmbMotivo.Location = new System.Drawing.Point(269, 236);
            this.cmbMotivo.Margin = new System.Windows.Forms.Padding(2);
            this.cmbMotivo.Name = "cmbMotivo";
            this.cmbMotivo.Size = new System.Drawing.Size(228, 36);
            this.cmbMotivo.TabIndex = 2;
            this.cmbMotivo.SelectedIndexChanged += new System.EventHandler(this.cmbMotivo_SelectedIndexChanged);
            this.cmbMotivo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbMotivo_KeyDown);
            // 
            // txtOtro
            // 
            this.txtOtro.BorderRadius = 12;
            this.txtOtro.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOtro.DefaultText = "";
            this.txtOtro.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtOtro.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtOtro.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtOtro.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtOtro.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtOtro.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtOtro.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtOtro.Location = new System.Drawing.Point(269, 277);
            this.txtOtro.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtOtro.Name = "txtOtro";
            this.txtOtro.PlaceholderText = "";
            this.txtOtro.SelectedText = "";
            this.txtOtro.Size = new System.Drawing.Size(228, 39);
            this.txtOtro.TabIndex = 77;
            this.txtOtro.TextChanged += new System.EventHandler(this.txtOtro_TextChanged);
            this.txtOtro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOtro_KeyDown);
            // 
            // btnCrear
            // 
            this.btnCrear.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnCrear.BorderRadius = 14;
            this.btnCrear.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCrear.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCrear.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCrear.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCrear.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(155)))), ((int)(((byte)(75)))));
            this.btnCrear.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCrear.ForeColor = System.Drawing.Color.White;
            this.btnCrear.Image = global::login.Properties.Resources.icons8_guardar_50;
            this.btnCrear.Location = new System.Drawing.Point(187, 381);
            this.btnCrear.Margin = new System.Windows.Forms.Padding(2);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(188, 39);
            this.btnCrear.TabIndex = 75;
            this.btnCrear.Text = "Guardar";
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // frmRegistrarMovimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(585, 448);
            this.Controls.Add(this.txtOtro);
            this.Controls.Add(this.cmbMotivo);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTipoMovimiento);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbProducto);
            this.Controls.Add(this.lblCrearProducto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmRegistrarMovimiento";
            this.Text = "Registrar movimiento";
            this.Load += new System.EventHandler(this.frmRegistrarMovimiento_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label lblCrearProducto;
        public System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cmbProducto;
        public System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox cmbTipoMovimiento;
        public System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtCantidad;
        public System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Button btnCrear;
        private Guna.UI2.WinForms.Guna2ComboBox cmbMotivo;
        private Guna.UI2.WinForms.Guna2TextBox txtOtro;
    }
}