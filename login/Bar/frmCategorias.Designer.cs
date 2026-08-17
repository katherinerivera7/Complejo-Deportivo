namespace login.Bar
{
    partial class frmCategorias
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCategorias));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFiltro = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.dgvCategorias = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colCategoriaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2ComboBox2 = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dtpFechaFin = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnBuscar = new Guna.UI2.WinForms.Guna2Button();
            this.txtFiltro = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnImprimir = new Guna.UI2.WinForms.Guna2Button();
            this.btnCrear = new Guna.UI2.WinForms.Guna2Button();
            this.btnEditar = new Guna.UI2.WinForms.Guna2Button();
            this.btnEliminar = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pnlContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(37)))), ((int)(((byte)(87)))));
            this.label1.Location = new System.Drawing.Point(261, 164);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 21);
            this.label1.TabIndex = 76;
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
            this.cmbFiltro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbFiltro.ItemHeight = 30;
            this.cmbFiltro.Items.AddRange(new object[] {
            "ID",
            "Nombre"});
            this.cmbFiltro.Location = new System.Drawing.Point(365, 164);
            this.cmbFiltro.Margin = new System.Windows.Forms.Padding(2);
            this.cmbFiltro.Name = "cmbFiltro";
            this.cmbFiltro.ShadowDecoration.BorderRadius = 14;
            this.cmbFiltro.ShadowDecoration.Depth = 4;
            this.cmbFiltro.ShadowDecoration.Enabled = true;
            this.cmbFiltro.Size = new System.Drawing.Size(194, 36);
            this.cmbFiltro.StartIndex = 0;
            this.cmbFiltro.TabIndex = 75;
            this.cmbFiltro.SelectedIndexChanged += new System.EventHandler(this.cmbFiltro_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(27, 74);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(419, 24);
            this.label2.TabIndex = 77;
            this.label2.Text = "Crea, elimina o modifica productos del bar";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(37)))), ((int)(((byte)(87)))));
            this.label11.Location = new System.Drawing.Point(22, 23);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(459, 51);
            this.label11.TabIndex = 72;
            this.label11.Text = "Categorías de productos";
            // 
            // pnlContenido
            // 
            this.pnlContenido.BackColor = System.Drawing.Color.White;
            this.pnlContenido.Controls.Add(this.dgvCategorias);
            this.pnlContenido.Location = new System.Drawing.Point(23, 215);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(443, 429);
            this.pnlContenido.TabIndex = 67;
            // 
            // dgvCategorias
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.dgvCategorias.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(155)))), ((int)(((byte)(75)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(155)))), ((int)(((byte)(75)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCategorias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvCategorias.ColumnHeadersHeight = 50;
            this.dgvCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvCategorias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCategoriaID,
            this.colNombre});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCategorias.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvCategorias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCategorias.GridColor = System.Drawing.SystemColors.Control;
            this.dgvCategorias.Location = new System.Drawing.Point(0, 0);
            this.dgvCategorias.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCategorias.Name = "dgvCategorias";
            this.dgvCategorias.RowHeadersVisible = false;
            this.dgvCategorias.RowHeadersWidth = 51;
            this.dgvCategorias.RowTemplate.Height = 24;
            this.dgvCategorias.Size = new System.Drawing.Size(443, 429);
            this.dgvCategorias.TabIndex = 0;
            this.dgvCategorias.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCategorias.ThemeStyle.GridColor = System.Drawing.SystemColors.Control;
            this.dgvCategorias.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(155)))), ((int)(((byte)(75)))));
            this.dgvCategorias.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCategorias.ThemeStyle.HeaderStyle.Height = 50;
            this.dgvCategorias.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvCategorias.ThemeStyle.RowsStyle.Height = 24;
            this.dgvCategorias.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(251)))));
            // 
            // colCategoriaID
            // 
            this.colCategoriaID.DataPropertyName = "CategoriaID";
            this.colCategoriaID.HeaderText = "ID";
            this.colCategoriaID.MinimumWidth = 6;
            this.colCategoriaID.Name = "colCategoriaID";
            // 
            // colNombre
            // 
            this.colNombre.DataPropertyName = "Nombre";
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.MinimumWidth = 6;
            this.colNombre.Name = "colNombre";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(234)))), ((int)(((byte)(242)))));
            this.guna2Panel2.BorderRadius = 15;
            this.guna2Panel2.Controls.Add(this.guna2ComboBox2);
            this.guna2Panel2.Controls.Add(this.dtpFechaFin);
            this.guna2Panel2.Controls.Add(this.pictureBox2);
            this.guna2Panel2.Controls.Add(this.label3);
            this.guna2Panel2.Controls.Add(this.label10);
            this.guna2Panel2.Controls.Add(this.guna2TextBox1);
            this.guna2Panel2.Controls.Add(this.label4);
            this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(200, 100);
            this.guna2Panel2.TabIndex = 0;
            // 
            // guna2ComboBox2
            // 
            this.guna2ComboBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2ComboBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2ComboBox2.BorderRadius = 8;
            this.guna2ComboBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.guna2ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.guna2ComboBox2.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.guna2ComboBox2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.guna2ComboBox2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.guna2ComboBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.guna2ComboBox2.ItemHeight = 30;
            this.guna2ComboBox2.Items.AddRange(new object[] {
            "Efectivo",
            "Tarjeta",
            "Transferencia"});
            this.guna2ComboBox2.Location = new System.Drawing.Point(536, 81);
            this.guna2ComboBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2ComboBox2.Name = "guna2ComboBox2";
            this.guna2ComboBox2.Size = new System.Drawing.Size(232, 36);
            this.guna2ComboBox2.StartIndex = 0;
            this.guna2ComboBox2.TabIndex = 63;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.dtpFechaFin.BorderRadius = 12;
            this.dtpFechaFin.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.dtpFechaFin.Checked = true;
            this.dtpFechaFin.FillColor = System.Drawing.Color.White;
            this.dtpFechaFin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFechaFin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(303, 79);
            this.dtpFechaFin.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFechaFin.MaxDate = new System.DateTime(2026, 12, 31, 0, 0, 0, 0);
            this.dtpFechaFin.MinDate = new System.DateTime(2026, 8, 9, 0, 0, 0, 0);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(217, 44);
            this.dtpFechaFin.TabIndex = 68;
            this.dtpFechaFin.Value = new System.DateTime(2026, 8, 9, 0, 0, 0, 0);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::login.Properties.Resources.icons8_documento_100;
            this.pictureBox2.Location = new System.Drawing.Point(20, 20);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(44, 28);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 39;
            this.pictureBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(37)))), ((int)(((byte)(87)))));
            this.label3.Location = new System.Drawing.Point(543, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 19);
            this.label3.TabIndex = 62;
            this.label3.Text = "Método de pago";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(37)))), ((int)(((byte)(87)))));
            this.label10.Location = new System.Drawing.Point(297, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 19);
            this.label10.TabIndex = 62;
            this.label10.Text = "Fecha de emisión";
            // 
            // guna2TextBox1
            // 
            this.guna2TextBox1.BorderRadius = 8;
            this.guna2TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox1.DefaultText = "";
            this.guna2TextBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.guna2TextBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.guna2TextBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.Location = new System.Drawing.Point(33, 81);
            this.guna2TextBox1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.guna2TextBox1.Name = "guna2TextBox1";
            this.guna2TextBox1.PlaceholderText = "FAC-00015";
            this.guna2TextBox1.SelectedText = "";
            this.guna2TextBox1.Size = new System.Drawing.Size(244, 42);
            this.guna2TextBox1.TabIndex = 44;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(37)))), ((int)(((byte)(87)))));
            this.label4.Location = new System.Drawing.Point(28, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 19);
            this.label4.TabIndex = 37;
            this.label4.Text = "Número de factura";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(71, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(312, 32);
            this.label5.TabIndex = 37;
            this.label5.Text = "1. Información de la factura";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderRadius = 30;
            this.guna2Panel1.Controls.Add(this.guna2Panel4);
            this.guna2Panel1.Controls.Add(this.pictureBox1);
            this.guna2Panel1.FillColor = System.Drawing.Color.White;
            this.guna2Panel1.Location = new System.Drawing.Point(606, 98);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(2);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.BorderRadius = 30;
            this.guna2Panel1.ShadowDecoration.Depth = 4;
            this.guna2Panel1.ShadowDecoration.Enabled = true;
            this.guna2Panel1.Size = new System.Drawing.Size(352, 509);
            this.guna2Panel1.TabIndex = 79;
            // 
            // guna2Panel4
            // 
            this.guna2Panel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel4.BorderRadius = 30;
            this.guna2Panel4.Controls.Add(this.label7);
            this.guna2Panel4.Controls.Add(this.label6);
            this.guna2Panel4.Controls.Add(this.pictureBox5);
            this.guna2Panel4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.guna2Panel4.Location = new System.Drawing.Point(22, 288);
            this.guna2Panel4.Margin = new System.Windows.Forms.Padding(2);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.ShadowDecoration.BorderRadius = 30;
            this.guna2Panel4.ShadowDecoration.Depth = 4;
            this.guna2Panel4.ShadowDecoration.Enabled = true;
            this.guna2Panel4.Size = new System.Drawing.Size(308, 191);
            this.guna2Panel4.TabIndex = 79;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label7.Location = new System.Drawing.Point(20, 52);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(266, 76);
            this.label7.TabIndex = 80;
            this.label7.Text = "Administra las categorías que organizan los productos del bar para una mejor orga" +
    "nización y gestión.";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(165)))), ((int)(((byte)(252)))));
            this.label6.Location = new System.Drawing.Point(52, 14);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 24);
            this.label6.TabIndex = 80;
            this.label6.Text = "Información";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::login.Properties.Resources.icons8_informaciónazul_64;
            this.pictureBox5.Location = new System.Drawing.Point(24, 14);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(23, 28);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 0;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::login.Properties.Resources.categoriaaim;
            this.pictureBox1.Location = new System.Drawing.Point(22, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(308, 228);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 78;
            this.pictureBox1.TabStop = false;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel3.BorderRadius = 30;
            this.guna2Panel3.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(200, 100);
            this.guna2Panel3.TabIndex = 0;
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
            this.btnBuscar.Location = new System.Drawing.Point(365, 112);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(194, 39);
            this.btnBuscar.TabIndex = 74;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtFiltro
            // 
            this.txtFiltro.BackColor = System.Drawing.Color.Transparent;
            this.txtFiltro.BorderRadius = 12;
            this.txtFiltro.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFiltro.DefaultText = "";
            this.txtFiltro.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFiltro.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFiltro.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFiltro.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFiltro.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFiltro.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltro.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFiltro.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtFiltro.IconLeft")));
            this.txtFiltro.Location = new System.Drawing.Point(33, 112);
            this.txtFiltro.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.PlaceholderText = "Buscar por ID o nombre";
            this.txtFiltro.SelectedText = "";
            this.txtFiltro.ShadowDecoration.BorderRadius = 12;
            this.txtFiltro.ShadowDecoration.Depth = 4;
            this.txtFiltro.ShadowDecoration.Enabled = true;
            this.txtFiltro.Size = new System.Drawing.Size(318, 39);
            this.txtFiltro.TabIndex = 73;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            this.txtFiltro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFiltro_KeyDown);
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
            this.btnImprimir.Location = new System.Drawing.Point(567, 670);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(2);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(166, 39);
            this.btnImprimir.TabIndex = 71;
            this.btnImprimir.Text = "Imprimir";
            // 
            // btnCrear
            // 
            this.btnCrear.BackColor = System.Drawing.Color.Transparent;
            this.btnCrear.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnCrear.BorderRadius = 14;
            this.btnCrear.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCrear.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCrear.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCrear.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCrear.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(189)))), ((int)(((byte)(252)))));
            this.btnCrear.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrear.ForeColor = System.Drawing.Color.White;
            this.btnCrear.Image = ((System.Drawing.Image)(resources.GetObject("btnCrear.Image")));
            this.btnCrear.Location = new System.Drawing.Point(388, 670);
            this.btnCrear.Margin = new System.Windows.Forms.Padding(2);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(166, 39);
            this.btnCrear.TabIndex = 70;
            this.btnCrear.Text = "Crear";
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.Transparent;
            this.btnEditar.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnEditar.BorderRadius = 14;
            this.btnEditar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEditar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEditar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEditar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEditar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(155)))), ((int)(((byte)(75)))));
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.Location = new System.Drawing.Point(208, 670);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(166, 39);
            this.btnEditar.TabIndex = 69;
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Transparent;
            this.btnEliminar.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnEliminar.BorderRadius = 14;
            this.btnEliminar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEliminar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEliminar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEliminar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEliminar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(189)))), ((int)(((byte)(252)))));
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.Location = new System.Drawing.Point(24, 670);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(166, 39);
            this.btnEliminar.TabIndex = 68;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::login.Properties.Resources.categoriaaim;
            this.pictureBox3.Location = new System.Drawing.Point(30, 53);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(427, 280);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 78;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::login.Properties.Resources.categoriaaim;
            this.pictureBox4.Location = new System.Drawing.Point(27, 50);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(427, 280);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 78;
            this.pictureBox4.TabStop = false;
            // 
            // frmCategorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1062, 796);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbFiltro);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.pnlContenido);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCategorias";
            this.Text = "frmCategorias";
            this.Load += new System.EventHandler(this.frmCategorias_Load);
            this.pnlContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cmbFiltro;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btnBuscar;
        private Guna.UI2.WinForms.Guna2TextBox txtFiltro;
        private System.Windows.Forms.Label label11;
        private Guna.UI2.WinForms.Guna2Button btnImprimir;
        private Guna.UI2.WinForms.Guna2Button btnCrear;
        private Guna.UI2.WinForms.Guna2Button btnEditar;
        private Guna.UI2.WinForms.Guna2Button btnEliminar;
        private System.Windows.Forms.Panel pnlContenido;
        private Guna.UI2.WinForms.Guna2DataGridView dgvCategorias;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2ComboBox guna2ComboBox2;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFechaFin;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoriaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
    }
}