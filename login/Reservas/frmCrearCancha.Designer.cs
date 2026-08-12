namespace login.Reservas
{
    partial class frmCrearCancha
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTipo = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblCrearCancha = new System.Windows.Forms.Label();
            this.txtNombre = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbEstado = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnCrear = new Guna.UI2.WinForms.Guna2Button();
            this.txtPrecioHora = new Guna.UI2.WinForms.Guna2TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(37)))), ((int)(((byte)(87)))));
            this.label1.Location = new System.Drawing.Point(63, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 50);
            this.label1.TabIndex = 70;
            this.label1.Text = "Tipo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbTipo
            // 
            this.cmbTipo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbTipo.BackColor = System.Drawing.Color.Transparent;
            this.cmbTipo.BorderRadius = 8;
            this.cmbTipo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cmbTipo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cmbTipo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbTipo.ItemHeight = 30;
            this.cmbTipo.Items.AddRange(new object[] {
            "Fútbol",
            "Básquet",
            "Tenis",
            "Pádel",
            "Voley"});
            this.cmbTipo.Location = new System.Drawing.Point(203, 225);
            this.cmbTipo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(313, 36);
            this.cmbTipo.StartIndex = 0;
            this.cmbTipo.TabIndex = 69;
            // 
            // lblCrearCancha
            // 
            this.lblCrearCancha.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrearCancha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(37)))), ((int)(((byte)(87)))));
            this.lblCrearCancha.Location = new System.Drawing.Point(71, 27);
            this.lblCrearCancha.Name = "lblCrearCancha";
            this.lblCrearCancha.Size = new System.Drawing.Size(424, 50);
            this.lblCrearCancha.TabIndex = 68;
            this.lblCrearCancha.Text = "Crear cancha";
            this.lblCrearCancha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNombre
            // 
            this.txtNombre.BorderRadius = 12;
            this.txtNombre.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNombre.DefaultText = "";
            this.txtNombre.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNombre.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNombre.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNombre.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNombre.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNombre.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNombre.IconLeft = global::login.Properties.Resources.icons8_editar_96;
            this.txtNombre.Location = new System.Drawing.Point(92, 103);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.PlaceholderText = "Nombre";
            this.txtNombre.SelectedText = "";
            this.txtNombre.Size = new System.Drawing.Size(424, 46);
            this.txtNombre.TabIndex = 67;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(37)))), ((int)(((byte)(87)))));
            this.label2.Location = new System.Drawing.Point(75, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 50);
            this.label2.TabIndex = 72;
            this.label2.Text = "Estado";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbEstado
            // 
            this.cmbEstado.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbEstado.BackColor = System.Drawing.Color.Transparent;
            this.cmbEstado.BorderRadius = 8;
            this.cmbEstado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cmbEstado.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cmbEstado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbEstado.ItemHeight = 30;
            this.cmbEstado.Items.AddRange(new object[] {
            "Disponible",
            "Mantenimiento",
            "Cerrada"});
            this.cmbEstado.Location = new System.Drawing.Point(203, 277);
            this.cmbEstado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(313, 36);
            this.cmbEstado.StartIndex = 0;
            this.cmbEstado.TabIndex = 71;
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
            this.btnCrear.Image = global::login.Properties.Resources.icons8_masgris_100;
            this.btnCrear.Location = new System.Drawing.Point(167, 358);
            this.btnCrear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(251, 48);
            this.btnCrear.TabIndex = 73;
            this.btnCrear.Text = "Crear";
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // txtPrecioHora
            // 
            this.txtPrecioHora.BorderRadius = 12;
            this.txtPrecioHora.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPrecioHora.DefaultText = "";
            this.txtPrecioHora.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPrecioHora.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPrecioHora.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPrecioHora.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPrecioHora.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPrecioHora.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPrecioHora.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPrecioHora.IconLeft = global::login.Properties.Resources.icons8_dólar_64;
            this.txtPrecioHora.Location = new System.Drawing.Point(92, 161);
            this.txtPrecioHora.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPrecioHora.Name = "txtPrecioHora";
            this.txtPrecioHora.PlaceholderText = "Precio por hora";
            this.txtPrecioHora.SelectedText = "";
            this.txtPrecioHora.Size = new System.Drawing.Size(424, 46);
            this.txtPrecioHora.TabIndex = 74;
            // 
            // frmCrearCancha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(641, 450);
            this.Controls.Add(this.txtPrecioHora);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.lblCrearCancha);
            this.Controls.Add(this.txtNombre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCrearCancha";
            this.Text = "Cancha";
            this.Load += new System.EventHandler(this.frmCrearCancha_Load_1);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cmbTipo;
        public System.Windows.Forms.Label lblCrearCancha;
        private Guna.UI2.WinForms.Guna2TextBox txtNombre;
        public System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox cmbEstado;
        private Guna.UI2.WinForms.Guna2Button btnCrear;
        private Guna.UI2.WinForms.Guna2TextBox txtPrecioHora;
    }
}