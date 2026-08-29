namespace login.Bar
{
    partial class frmHistorialMovimientos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHistorialMovimientos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlContenidoo = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFiltro = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscar = new Guna.UI2.WinForms.Guna2Button();
            this.txtNombre = new Guna.UI2.WinForms.Guna2TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnImprimir = new Guna.UI2.WinForms.Guna2Button();
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.dgvMovimientos = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colMovimientoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipoMovimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaMovimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMotivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlContenidoo.SuspendLayout();
            this.pnlContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContenidoo
            // 
            this.pnlContenidoo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.pnlContenidoo.Controls.Add(this.guna2Button1);
            this.pnlContenidoo.Controls.Add(this.label1);
            this.pnlContenidoo.Controls.Add(this.cmbFiltro);
            this.pnlContenidoo.Controls.Add(this.label2);
            this.pnlContenidoo.Controls.Add(this.btnBuscar);
            this.pnlContenidoo.Controls.Add(this.txtNombre);
            this.pnlContenidoo.Controls.Add(this.label11);
            this.pnlContenidoo.Controls.Add(this.btnImprimir);
            this.pnlContenidoo.Controls.Add(this.pnlContenido);
            this.pnlContenidoo.Controls.Add(this.pictureBox1);
            this.pnlContenidoo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenidoo.Location = new System.Drawing.Point(0, 0);
            this.pnlContenidoo.Margin = new System.Windows.Forms.Padding(2);
            this.pnlContenidoo.Name = "pnlContenidoo";
            this.pnlContenidoo.Size = new System.Drawing.Size(1062, 796);
            this.pnlContenidoo.TabIndex = 2;
            this.pnlContenidoo.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlContenidoo_Paint);
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.guna2Button1.BorderRadius = 14;
            this.guna2Button1.BorderThickness = 1;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.White;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.guna2Button1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.guna2Button1.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button1.Image")));
            this.guna2Button1.Location = new System.Drawing.Point(218, 677);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(2);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(166, 39);
            this.guna2Button1.TabIndex = 85;
            this.guna2Button1.Text = "Volver";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(37)))), ((int)(((byte)(87)))));
            this.label1.Location = new System.Drawing.Point(250, 150);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 21);
            this.label1.TabIndex = 64;
            this.label1.Text = "Filtrar por:";
            // 
            // cmbFiltro
            // 
            this.cmbFiltro.BackColor = System.Drawing.Color.Transparent;
            this.cmbFiltro.BorderRadius = 12;
            this.cmbFiltro.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltro.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbFiltro.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbFiltro.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.cmbFiltro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmbFiltro.ItemHeight = 30;
            this.cmbFiltro.Items.AddRange(new object[] {
            "ID Producto",
            "Categoría",
            "Nombre"});
            this.cmbFiltro.Location = new System.Drawing.Point(354, 150);
            this.cmbFiltro.Margin = new System.Windows.Forms.Padding(2);
            this.cmbFiltro.Name = "cmbFiltro";
            this.cmbFiltro.ShadowDecoration.BorderRadius = 14;
            this.cmbFiltro.ShadowDecoration.Depth = 4;
            this.cmbFiltro.ShadowDecoration.Enabled = true;
            this.cmbFiltro.Size = new System.Drawing.Size(194, 36);
            this.cmbFiltro.StartIndex = 0;
            this.cmbFiltro.TabIndex = 63;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(16, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(419, 24);
            this.label2.TabIndex = 65;
            this.label2.Text = "Revisa las entradas/salidas de stocks de productos";
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
            this.btnBuscar.Location = new System.Drawing.Point(354, 98);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(194, 39);
            this.btnBuscar.TabIndex = 62;
            this.btnBuscar.Text = "Buscar";
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.Transparent;
            this.txtNombre.BorderRadius = 12;
            this.txtNombre.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNombre.DefaultText = "";
            this.txtNombre.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNombre.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNombre.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNombre.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNombre.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txtNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNombre.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNombre.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtNombre.IconLeft")));
            this.txtNombre.Location = new System.Drawing.Point(22, 98);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.PlaceholderText = "Buscar por ID Producto, categoría o nombre";
            this.txtNombre.SelectedText = "";
            this.txtNombre.ShadowDecoration.BorderRadius = 12;
            this.txtNombre.ShadowDecoration.Depth = 4;
            this.txtNombre.ShadowDecoration.Enabled = true;
            this.txtNombre.Size = new System.Drawing.Size(318, 39);
            this.txtNombre.TabIndex = 61;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(37)))), ((int)(((byte)(87)))));
            this.label11.Location = new System.Drawing.Point(11, 9);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(474, 51);
            this.label11.TabIndex = 60;
            this.label11.Text = "Historial de movimientos";
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
            this.btnImprimir.Location = new System.Drawing.Point(22, 677);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(2);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(166, 39);
            this.btnImprimir.TabIndex = 59;
            this.btnImprimir.Text = "Imprimir";
            // 
            // pnlContenido
            // 
            this.pnlContenido.BackColor = System.Drawing.Color.White;
            this.pnlContenido.Controls.Add(this.dgvMovimientos);
            this.pnlContenido.Location = new System.Drawing.Point(12, 201);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(966, 460);
            this.pnlContenido.TabIndex = 50;
            // 
            // dgvMovimientos
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvMovimientos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(155)))), ((int)(((byte)(75)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(155)))), ((int)(((byte)(75)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMovimientos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMovimientos.ColumnHeadersHeight = 50;
            this.dgvMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvMovimientos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMovimientoID,
            this.colProducto,
            this.colUsuario,
            this.colTipoMovimiento,
            this.colCantidad,
            this.colFechaMovimiento,
            this.colMotivo});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMovimientos.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMovimientos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMovimientos.GridColor = System.Drawing.SystemColors.Control;
            this.dgvMovimientos.Location = new System.Drawing.Point(0, 0);
            this.dgvMovimientos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvMovimientos.Name = "dgvMovimientos";
            this.dgvMovimientos.RowHeadersVisible = false;
            this.dgvMovimientos.RowHeadersWidth = 51;
            this.dgvMovimientos.RowTemplate.Height = 24;
            this.dgvMovimientos.Size = new System.Drawing.Size(966, 460);
            this.dgvMovimientos.TabIndex = 0;
            this.dgvMovimientos.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvMovimientos.ThemeStyle.GridColor = System.Drawing.SystemColors.Control;
            this.dgvMovimientos.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(155)))), ((int)(((byte)(75)))));
            this.dgvMovimientos.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvMovimientos.ThemeStyle.HeaderStyle.Height = 50;
            this.dgvMovimientos.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvMovimientos.ThemeStyle.RowsStyle.Height = 24;
            this.dgvMovimientos.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(251)))));
            // 
            // colMovimientoID
            // 
            this.colMovimientoID.DataPropertyName = "MovimientoID";
            this.colMovimientoID.HeaderText = "ID";
            this.colMovimientoID.MinimumWidth = 6;
            this.colMovimientoID.Name = "colMovimientoID";
            // 
            // colProducto
            // 
            this.colProducto.DataPropertyName = "Producto";
            this.colProducto.HeaderText = "Producto";
            this.colProducto.MinimumWidth = 6;
            this.colProducto.Name = "colProducto";
            // 
            // colUsuario
            // 
            this.colUsuario.DataPropertyName = "Usuario";
            this.colUsuario.HeaderText = "Usuario";
            this.colUsuario.MinimumWidth = 6;
            this.colUsuario.Name = "colUsuario";
            // 
            // colTipoMovimiento
            // 
            this.colTipoMovimiento.DataPropertyName = "TipoMovimiento";
            this.colTipoMovimiento.HeaderText = "Tipo";
            this.colTipoMovimiento.MinimumWidth = 6;
            this.colTipoMovimiento.Name = "colTipoMovimiento";
            // 
            // colCantidad
            // 
            this.colCantidad.DataPropertyName = "Cantidad";
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.MinimumWidth = 6;
            this.colCantidad.Name = "colCantidad";
            // 
            // colFechaMovimiento
            // 
            this.colFechaMovimiento.DataPropertyName = "FechaMovimiento";
            this.colFechaMovimiento.HeaderText = "Fecha";
            this.colFechaMovimiento.Name = "colFechaMovimiento";
            // 
            // colMotivo
            // 
            this.colMotivo.DataPropertyName = "Motivo";
            this.colMotivo.HeaderText = "Motivo";
            this.colMotivo.Name = "colMotivo";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::login.Properties.Resources.ILUSTRACIÓN_INVENTARIO;
            this.pictureBox1.Location = new System.Drawing.Point(585, -12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(420, 235);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 66;
            this.pictureBox1.TabStop = false;
            // 
            // frmHistorialMovimientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1062, 796);
            this.Controls.Add(this.pnlContenidoo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmHistorialMovimientos";
            this.Text = "frmHistorialMovimientos";
            this.Load += new System.EventHandler(this.frmHistorialMovimientos_Load);
            this.pnlContenidoo.ResumeLayout(false);
            this.pnlContenidoo.PerformLayout();
            this.pnlContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlContenidoo;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cmbFiltro;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btnBuscar;
        private Guna.UI2.WinForms.Guna2TextBox txtNombre;
        private System.Windows.Forms.Label label11;
        private Guna.UI2.WinForms.Guna2Button btnImprimir;
        private System.Windows.Forms.Panel pnlContenido;
        private Guna.UI2.WinForms.Guna2DataGridView dgvMovimientos;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMovimientoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipoMovimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaMovimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMotivo;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}