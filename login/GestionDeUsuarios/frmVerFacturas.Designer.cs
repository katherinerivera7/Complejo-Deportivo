namespace login.GestionDeUsuarios
{
    partial class frmVerFacturas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVerFacturas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlContenidoo = new Guna.UI2.WinForms.Guna2Panel();
            this.btnReporte = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTipoFactura = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscar = new Guna.UI2.WinForms.Guna2Button();
            this.txtFacturaID = new Guna.UI2.WinForms.Guna2TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnImprimir = new Guna.UI2.WinForms.Guna2Button();
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.dgvFacturas = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlContenidoo.SuspendLayout();
            this.pnlContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContenidoo
            // 
            this.pnlContenidoo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.pnlContenidoo.Controls.Add(this.btnReporte);
            this.pnlContenidoo.Controls.Add(this.label1);
            this.pnlContenidoo.Controls.Add(this.cmbTipoFactura);
            this.pnlContenidoo.Controls.Add(this.label2);
            this.pnlContenidoo.Controls.Add(this.btnBuscar);
            this.pnlContenidoo.Controls.Add(this.txtFacturaID);
            this.pnlContenidoo.Controls.Add(this.label11);
            this.pnlContenidoo.Controls.Add(this.btnImprimir);
            this.pnlContenidoo.Controls.Add(this.pnlContenido);
            this.pnlContenidoo.Controls.Add(this.pictureBox1);
            this.pnlContenidoo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenidoo.Location = new System.Drawing.Point(0, 0);
            this.pnlContenidoo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlContenidoo.Name = "pnlContenidoo";
            this.pnlContenidoo.Size = new System.Drawing.Size(1395, 932);
            this.pnlContenidoo.TabIndex = 2;
            // 
            // btnReporte
            // 
            this.btnReporte.BackColor = System.Drawing.Color.Transparent;
            this.btnReporte.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnReporte.BorderRadius = 14;
            this.btnReporte.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReporte.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReporte.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReporte.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReporte.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(189)))), ((int)(((byte)(252)))));
            this.btnReporte.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporte.ForeColor = System.Drawing.Color.White;
            this.btnReporte.Image = global::login.Properties.Resources.icons8_factura_100;
            this.btnReporte.Location = new System.Drawing.Point(951, 833);
            this.btnReporte.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(163, 48);
            this.btnReporte.TabIndex = 68;
            this.btnReporte.Text = "Reporte";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(37)))), ((int)(((byte)(87)))));
            this.label1.Location = new System.Drawing.Point(281, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 28);
            this.label1.TabIndex = 64;
            this.label1.Text = "Tipo de factura:";
            // 
            // cmbTipoFactura
            // 
            this.cmbTipoFactura.BackColor = System.Drawing.Color.Transparent;
            this.cmbTipoFactura.BorderRadius = 12;
            this.cmbTipoFactura.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTipoFactura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoFactura.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbTipoFactura.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbTipoFactura.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.cmbTipoFactura.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmbTipoFactura.ItemHeight = 30;
            this.cmbTipoFactura.Items.AddRange(new object[] {
            "Reservas",
            "Bar"});
            this.cmbTipoFactura.Location = new System.Drawing.Point(472, 185);
            this.cmbTipoFactura.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbTipoFactura.Name = "cmbTipoFactura";
            this.cmbTipoFactura.ShadowDecoration.BorderRadius = 14;
            this.cmbTipoFactura.ShadowDecoration.Depth = 4;
            this.cmbTipoFactura.ShadowDecoration.Enabled = true;
            this.cmbTipoFactura.Size = new System.Drawing.Size(257, 36);
            this.cmbTipoFactura.TabIndex = 63;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(21, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(559, 30);
            this.label2.TabIndex = 65;
            this.label2.Text = "Visualiza las facturas de las reservas y ventas del bar";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnBuscar.BorderRadius = 14;
            this.btnBuscar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBuscar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBuscar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBuscar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBuscar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(155)))), ((int)(((byte)(75)))));
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(472, 121);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(259, 48);
            this.btnBuscar.TabIndex = 62;
            this.btnBuscar.Text = "Buscar";
            // 
            // txtFacturaID
            // 
            this.txtFacturaID.BackColor = System.Drawing.Color.Transparent;
            this.txtFacturaID.BorderRadius = 12;
            this.txtFacturaID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFacturaID.DefaultText = "";
            this.txtFacturaID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFacturaID.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFacturaID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFacturaID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFacturaID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFacturaID.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txtFacturaID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtFacturaID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFacturaID.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtFacturaID.IconLeft")));
            this.txtFacturaID.Location = new System.Drawing.Point(29, 121);
            this.txtFacturaID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFacturaID.Name = "txtFacturaID";
            this.txtFacturaID.PlaceholderText = "Factura ID";
            this.txtFacturaID.SelectedText = "";
            this.txtFacturaID.ShadowDecoration.BorderRadius = 12;
            this.txtFacturaID.ShadowDecoration.Depth = 4;
            this.txtFacturaID.ShadowDecoration.Enabled = true;
            this.txtFacturaID.Size = new System.Drawing.Size(424, 48);
            this.txtFacturaID.TabIndex = 61;
            this.txtFacturaID.TextChanged += new System.EventHandler(this.txtFacturaID_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(37)))), ((int)(((byte)(87)))));
            this.label11.Location = new System.Drawing.Point(15, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(209, 62);
            this.label11.TabIndex = 60;
            this.label11.Text = "Facturas";
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.Transparent;
            this.btnImprimir.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnImprimir.BorderRadius = 14;
            this.btnImprimir.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnImprimir.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnImprimir.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnImprimir.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnImprimir.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(155)))), ((int)(((byte)(75)))));
            this.btnImprimir.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.Location = new System.Drawing.Point(1141, 833);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(163, 48);
            this.btnImprimir.TabIndex = 59;
            this.btnImprimir.Text = "Imprimir";
            // 
            // pnlContenido
            // 
            this.pnlContenido.BackColor = System.Drawing.Color.White;
            this.pnlContenido.Controls.Add(this.dgvFacturas);
            this.pnlContenido.Location = new System.Drawing.Point(16, 247);
            this.pnlContenido.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(1288, 566);
            this.pnlContenido.TabIndex = 50;
            // 
            // dgvFacturas
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.dgvFacturas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(155)))), ((int)(((byte)(75)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(155)))), ((int)(((byte)(75)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFacturas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvFacturas.ColumnHeadersHeight = 50;
            this.dgvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFacturas.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvFacturas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFacturas.GridColor = System.Drawing.SystemColors.Control;
            this.dgvFacturas.Location = new System.Drawing.Point(0, 0);
            this.dgvFacturas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvFacturas.Name = "dgvFacturas";
            this.dgvFacturas.RowHeadersVisible = false;
            this.dgvFacturas.RowHeadersWidth = 51;
            this.dgvFacturas.RowTemplate.Height = 24;
            this.dgvFacturas.Size = new System.Drawing.Size(1288, 566);
            this.dgvFacturas.TabIndex = 0;
            this.dgvFacturas.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvFacturas.ThemeStyle.GridColor = System.Drawing.SystemColors.Control;
            this.dgvFacturas.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(155)))), ((int)(((byte)(75)))));
            this.dgvFacturas.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.dgvFacturas.ThemeStyle.HeaderStyle.Height = 50;
            this.dgvFacturas.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvFacturas.ThemeStyle.RowsStyle.Height = 24;
            this.dgvFacturas.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(251)))));
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::login.Properties.Resources.facturailustracion;
            this.pictureBox1.Location = new System.Drawing.Point(780, -15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(560, 289);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 66;
            this.pictureBox1.TabStop = false;
            // 
            // frmVerFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1395, 932);
            this.Controls.Add(this.pnlContenidoo);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmVerFacturas";
            this.Text = "frmVerFacturas";
            this.Load += new System.EventHandler(this.frmVerFacturas_Load);
            this.pnlContenidoo.ResumeLayout(false);
            this.pnlContenidoo.PerformLayout();
            this.pnlContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlContenidoo;
        private Guna.UI2.WinForms.Guna2Button btnReporte;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cmbTipoFactura;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btnBuscar;
        private Guna.UI2.WinForms.Guna2TextBox txtFacturaID;
        private System.Windows.Forms.Label label11;
        private Guna.UI2.WinForms.Guna2Button btnImprimir;
        private System.Windows.Forms.Panel pnlContenido;
        private Guna.UI2.WinForms.Guna2DataGridView dgvFacturas;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}