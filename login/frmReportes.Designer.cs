namespace login
{
    partial class frmReportes
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtpDesde = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpHasta = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnGenerar = new Guna.UI2.WinForms.Guna2Button();
            this.chartReporte = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblTituloReportes = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblSubtituloReportes = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDesde = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblIngresosTotales2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblIngresosTotales = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlFiltros = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblHasta = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cmbTipoReporte = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dgvReporte = new System.Windows.Forms.DataGridView();
            this.pnlIngresosTotales = new Guna.UI2.WinForms.Guna2Panel();
            this.lblIngresosBar = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblIngresosReservas = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlIngresosBar = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlIngresosReservas = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlGrafico = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTituloTabla = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTituloGrafico = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblTituloIngresosTotales = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblTituloIngresosBar = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.lblTituloIngresosReservas = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)(this.chartReporte)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).BeginInit();
            this.pnlIngresosTotales.SuspendLayout();
            this.pnlIngresosBar.SuspendLayout();
            this.pnlIngresosReservas.SuspendLayout();
            this.pnlGrafico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpDesde
            // 
            this.dtpDesde.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.dtpDesde.BorderRadius = 8;
            this.dtpDesde.BorderThickness = 1;
            this.dtpDesde.Checked = true;
            this.dtpDesde.FillColor = System.Drawing.Color.White;
            this.dtpDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dtpDesde.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDesde.Location = new System.Drawing.Point(24, 90);
            this.dtpDesde.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpDesde.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDesde.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(227, 37);
            this.dtpDesde.TabIndex = 3;
            this.dtpDesde.Value = new System.DateTime(2026, 9, 17, 20, 15, 0, 771);
            // 
            // dtpHasta
            // 
            this.dtpHasta.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.dtpHasta.BorderRadius = 8;
            this.dtpHasta.BorderThickness = 1;
            this.dtpHasta.Checked = true;
            this.dtpHasta.FillColor = System.Drawing.Color.White;
            this.dtpHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dtpHasta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHasta.Location = new System.Drawing.Point(24, 161);
            this.dtpHasta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpHasta.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpHasta.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(227, 37);
            this.dtpHasta.TabIndex = 4;
            this.dtpHasta.Value = new System.DateTime(2026, 9, 17, 22, 53, 5, 2);
            // 
            // btnGenerar
            // 
            this.btnGenerar.Animated = true;
            this.btnGenerar.BorderRadius = 8;
            this.btnGenerar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGenerar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGenerar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGenerar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGenerar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(114)))), ((int)(((byte)(196)))));
            this.btnGenerar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.btnGenerar.ForeColor = System.Drawing.Color.White;
            this.btnGenerar.Location = new System.Drawing.Point(20, 303);
            this.btnGenerar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(231, 55);
            this.btnGenerar.TabIndex = 6;
            this.btnGenerar.Text = "Generar reporte";
            // 
            // chartReporte
            // 
            this.chartReporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.chartReporte.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.chartReporte.BorderlineWidth = 0;
            chartArea6.BackColor = System.Drawing.Color.White;
            chartArea6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            chartArea6.Name = "ChartArea1";
            this.chartReporte.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.chartReporte.Legends.Add(legend6);
            this.chartReporte.Location = new System.Drawing.Point(117, 18);
            this.chartReporte.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chartReporte.Name = "chartReporte";
            this.chartReporte.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.chartReporte.Series.Add(series6);
            this.chartReporte.Size = new System.Drawing.Size(680, 326);
            this.chartReporte.TabIndex = 8;
            this.chartReporte.Text = "chart1";
            // 
            // lblTituloReportes
            // 
            this.lblTituloReportes.AutoSize = false;
            this.lblTituloReportes.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloReportes.Font = new System.Drawing.Font("Segoe UI Semibold", 20F);
            this.lblTituloReportes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(37)))), ((int)(((byte)(87)))));
            this.lblTituloReportes.Location = new System.Drawing.Point(130, 13);
            this.lblTituloReportes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblTituloReportes.Name = "lblTituloReportes";
            this.lblTituloReportes.Size = new System.Drawing.Size(505, 47);
            this.lblTituloReportes.TabIndex = 9;
            this.lblTituloReportes.Text = "Reportes y estadísticas";
            // 
            // lblSubtituloReportes
            // 
            this.lblSubtituloReportes.AutoSize = false;
            this.lblSubtituloReportes.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtituloReportes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblSubtituloReportes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(129)))), ((int)(((byte)(141)))));
            this.lblSubtituloReportes.Location = new System.Drawing.Point(130, 58);
            this.lblSubtituloReportes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblSubtituloReportes.Name = "lblSubtituloReportes";
            this.lblSubtituloReportes.Size = new System.Drawing.Size(635, 27);
            this.lblSubtituloReportes.TabIndex = 10;
            this.lblSubtituloReportes.Text = "Consulta la información más importante del complejo";
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = false;
            this.lblDesde.BackColor = System.Drawing.Color.Transparent;
            this.lblDesde.ForeColor = System.Drawing.Color.Black;
            this.lblDesde.Location = new System.Drawing.Point(24, 49);
            this.lblDesde.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(171, 33);
            this.lblDesde.TabIndex = 11;
            this.lblDesde.Text = "Desde";
            this.lblDesde.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblIngresosTotales2
            // 
            this.lblIngresosTotales2.BackColor = System.Drawing.Color.Transparent;
            this.lblIngresosTotales2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngresosTotales2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblIngresosTotales2.Location = new System.Drawing.Point(29, 121);
            this.lblIngresosTotales2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblIngresosTotales2.Name = "lblIngresosTotales2";
            this.lblIngresosTotales2.Size = new System.Drawing.Size(232, 43);
            this.lblIngresosTotales2.TabIndex = 14;
            this.lblIngresosTotales2.Text = "Ingresos Totales";
            this.lblIngresosTotales2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIngresosTotales
            // 
            this.lblIngresosTotales.AutoSize = false;
            this.lblIngresosTotales.BackColor = System.Drawing.Color.Transparent;
            this.lblIngresosTotales.Location = new System.Drawing.Point(747, 365);
            this.lblIngresosTotales.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblIngresosTotales.Name = "lblIngresosTotales";
            this.lblIngresosTotales.Size = new System.Drawing.Size(252, 18);
            this.lblIngresosTotales.TabIndex = 13;
            this.lblIngresosTotales.Text = "Ingresos Totales";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.guna2Panel1.Controls.Add(this.pictureBox1);
            this.guna2Panel1.Controls.Add(this.lblTituloReportes);
            this.guna2Panel1.Controls.Add(this.lblSubtituloReportes);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1339, 89);
            this.guna2Panel1.TabIndex = 16;
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.BackColor = System.Drawing.Color.Transparent;
            this.pnlFiltros.BorderRadius = 8;
            this.pnlFiltros.Controls.Add(this.guna2HtmlLabel1);
            this.pnlFiltros.Controls.Add(this.guna2HtmlLabel2);
            this.pnlFiltros.Controls.Add(this.lblDesde);
            this.pnlFiltros.Controls.Add(this.dtpDesde);
            this.pnlFiltros.Controls.Add(this.lblHasta);
            this.pnlFiltros.Controls.Add(this.dtpHasta);
            this.pnlFiltros.Controls.Add(this.btnGenerar);
            this.pnlFiltros.Controls.Add(this.cmbTipoReporte);
            this.pnlFiltros.FillColor = System.Drawing.Color.White;
            this.pnlFiltros.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.pnlFiltros.Location = new System.Drawing.Point(40, 123);
            this.pnlFiltros.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.ShadowDecoration.BorderRadius = 8;
            this.pnlFiltros.ShadowDecoration.Enabled = true;
            this.pnlFiltros.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.pnlFiltros.Size = new System.Drawing.Size(282, 380);
            this.pnlFiltros.TabIndex = 17;
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.AutoSize = false;
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(20, 206);
            this.guna2HtmlLabel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(223, 28);
            this.guna2HtmlLabel2.TabIndex = 21;
            this.guna2HtmlLabel2.Text = "Tipo de reporte";
            this.guna2HtmlLabel2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = false;
            this.lblHasta.BackColor = System.Drawing.Color.Transparent;
            this.lblHasta.ForeColor = System.Drawing.Color.Black;
            this.lblHasta.Location = new System.Drawing.Point(24, 126);
            this.lblHasta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(166, 35);
            this.lblHasta.TabIndex = 18;
            this.lblHasta.Text = "Hasta";
            this.lblHasta.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbTipoReporte
            // 
            this.cmbTipoReporte.BackColor = System.Drawing.Color.Transparent;
            this.cmbTipoReporte.BorderRadius = 8;
            this.cmbTipoReporte.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTipoReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoReporte.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbTipoReporte.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbTipoReporte.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTipoReporte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbTipoReporte.ItemHeight = 30;
            this.cmbTipoReporte.Location = new System.Drawing.Point(20, 242);
            this.cmbTipoReporte.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbTipoReporte.Name = "cmbTipoReporte";
            this.cmbTipoReporte.Size = new System.Drawing.Size(231, 36);
            this.cmbTipoReporte.TabIndex = 20;
            // 
            // dgvReporte
            // 
            this.dgvReporte.AllowUserToAddRows = false;
            this.dgvReporte.AllowUserToDeleteRows = false;
            this.dgvReporte.AllowUserToResizeColumns = false;
            this.dgvReporte.AllowUserToResizeRows = false;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(65)))));
            this.dgvReporte.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle16;
            this.dgvReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReporte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReporte.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.dgvReporte.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReporte.ColumnHeadersHeight = 40;
            this.dgvReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(235)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(55)))));
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReporte.DefaultCellStyle = dataGridViewCellStyle17;
            this.dgvReporte.EnableHeadersVisualStyles = false;
            this.dgvReporte.GridColor = System.Drawing.Color.Black;
            this.dgvReporte.Location = new System.Drawing.Point(0, 529);
            this.dgvReporte.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvReporte.MultiSelect = false;
            this.dgvReporte.Name = "dgvReporte";
            this.dgvReporte.ReadOnly = true;
            this.dgvReporte.RowHeadersVisible = false;
            this.dgvReporte.RowHeadersWidth = 51;
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(65)))));
            this.dgvReporte.RowsDefaultCellStyle = dataGridViewCellStyle18;
            this.dgvReporte.RowTemplate.Height = 36;
            this.dgvReporte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReporte.Size = new System.Drawing.Size(475, 373);
            this.dgvReporte.TabIndex = 19;
            // 
            // pnlIngresosTotales
            // 
            this.pnlIngresosTotales.BackColor = System.Drawing.Color.Transparent;
            this.pnlIngresosTotales.BorderRadius = 8;
            this.pnlIngresosTotales.Controls.Add(this.lblTituloIngresosTotales);
            this.pnlIngresosTotales.Controls.Add(this.pictureBox2);
            this.pnlIngresosTotales.Controls.Add(this.lblIngresosTotales2);
            this.pnlIngresosTotales.FillColor = System.Drawing.Color.White;
            this.pnlIngresosTotales.Location = new System.Drawing.Point(353, 137);
            this.pnlIngresosTotales.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlIngresosTotales.Name = "pnlIngresosTotales";
            this.pnlIngresosTotales.ShadowDecoration.BorderRadius = 8;
            this.pnlIngresosTotales.ShadowDecoration.Enabled = true;
            this.pnlIngresosTotales.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.pnlIngresosTotales.Size = new System.Drawing.Size(289, 198);
            this.pnlIngresosTotales.TabIndex = 21;
            // 
            // lblIngresosBar
            // 
            this.lblIngresosBar.BackColor = System.Drawing.Color.Transparent;
            this.lblIngresosBar.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngresosBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(114)))), ((int)(((byte)(196)))));
            this.lblIngresosBar.Location = new System.Drawing.Point(65, 121);
            this.lblIngresosBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblIngresosBar.Name = "lblIngresosBar";
            this.lblIngresosBar.Size = new System.Drawing.Size(177, 43);
            this.lblIngresosBar.TabIndex = 22;
            this.lblIngresosBar.Text = "Ingresos bar";
            this.lblIngresosBar.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIngresosReservas
            // 
            this.lblIngresosReservas.BackColor = System.Drawing.Color.Transparent;
            this.lblIngresosReservas.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngresosReservas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(48)))), ((int)(((byte)(209)))));
            this.lblIngresosReservas.Location = new System.Drawing.Point(22, 121);
            this.lblIngresosReservas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblIngresosReservas.Name = "lblIngresosReservas";
            this.lblIngresosReservas.Size = new System.Drawing.Size(252, 43);
            this.lblIngresosReservas.TabIndex = 23;
            this.lblIngresosReservas.Text = "Ingresos Reservas";
            this.lblIngresosReservas.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlIngresosBar
            // 
            this.pnlIngresosBar.BackColor = System.Drawing.Color.Transparent;
            this.pnlIngresosBar.BorderRadius = 8;
            this.pnlIngresosBar.Controls.Add(this.pictureBox3);
            this.pnlIngresosBar.Controls.Add(this.lblTituloIngresosBar);
            this.pnlIngresosBar.Controls.Add(this.lblIngresosBar);
            this.pnlIngresosBar.FillColor = System.Drawing.Color.White;
            this.pnlIngresosBar.Location = new System.Drawing.Point(663, 137);
            this.pnlIngresosBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlIngresosBar.Name = "pnlIngresosBar";
            this.pnlIngresosBar.ShadowDecoration.BorderRadius = 8;
            this.pnlIngresosBar.ShadowDecoration.Enabled = true;
            this.pnlIngresosBar.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.pnlIngresosBar.Size = new System.Drawing.Size(289, 198);
            this.pnlIngresosBar.TabIndex = 22;
            // 
            // pnlIngresosReservas
            // 
            this.pnlIngresosReservas.BackColor = System.Drawing.Color.Transparent;
            this.pnlIngresosReservas.BorderRadius = 8;
            this.pnlIngresosReservas.Controls.Add(this.pictureBox4);
            this.pnlIngresosReservas.Controls.Add(this.lblTituloIngresosReservas);
            this.pnlIngresosReservas.Controls.Add(this.lblIngresosReservas);
            this.pnlIngresosReservas.FillColor = System.Drawing.Color.White;
            this.pnlIngresosReservas.Location = new System.Drawing.Point(977, 137);
            this.pnlIngresosReservas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlIngresosReservas.Name = "pnlIngresosReservas";
            this.pnlIngresosReservas.ShadowDecoration.BorderRadius = 8;
            this.pnlIngresosReservas.ShadowDecoration.Enabled = true;
            this.pnlIngresosReservas.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.pnlIngresosReservas.Size = new System.Drawing.Size(289, 198);
            this.pnlIngresosReservas.TabIndex = 23;
            // 
            // pnlGrafico
            // 
            this.pnlGrafico.Controls.Add(this.chartReporte);
            this.pnlGrafico.Location = new System.Drawing.Point(451, 529);
            this.pnlGrafico.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlGrafico.Name = "pnlGrafico";
            this.pnlGrafico.Size = new System.Drawing.Size(888, 373);
            this.pnlGrafico.TabIndex = 24;
            // 
            // lblTituloTabla
            // 
            this.lblTituloTabla.AutoSize = false;
            this.lblTituloTabla.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloTabla.ForeColor = System.Drawing.Color.Black;
            this.lblTituloTabla.Location = new System.Drawing.Point(568, 503);
            this.lblTituloTabla.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblTituloTabla.Name = "lblTituloTabla";
            this.lblTituloTabla.Size = new System.Drawing.Size(271, 18);
            this.lblTituloTabla.TabIndex = 25;
            this.lblTituloTabla.Text = "Titulo Ingresos Totales";
            // 
            // lblTituloGrafico
            // 
            this.lblTituloGrafico.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloGrafico.ForeColor = System.Drawing.Color.Black;
            this.lblTituloGrafico.Location = new System.Drawing.Point(40, 503);
            this.lblTituloGrafico.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblTituloGrafico.Name = "lblTituloGrafico";
            this.lblTituloGrafico.Size = new System.Drawing.Size(140, 18);
            this.lblTituloGrafico.TabIndex = 26;
            this.lblTituloGrafico.Text = "Titulo Ingresos Totales";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::login.Properties.Resources.icons8_factura_100;
            this.pictureBox1.Location = new System.Drawing.Point(25, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(69, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::login.Properties.Resources.it;
            this.pictureBox2.Location = new System.Drawing.Point(41, 21);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(68, 63);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            // 
            // lblTituloIngresosTotales
            // 
            this.lblTituloIngresosTotales.AutoSize = false;
            this.lblTituloIngresosTotales.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloIngresosTotales.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.lblTituloIngresosTotales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(37)))), ((int)(((byte)(87)))));
            this.lblTituloIngresosTotales.Location = new System.Drawing.Point(110, 21);
            this.lblTituloIngresosTotales.Margin = new System.Windows.Forms.Padding(4);
            this.lblTituloIngresosTotales.Name = "lblTituloIngresosTotales";
            this.lblTituloIngresosTotales.Size = new System.Drawing.Size(172, 92);
            this.lblTituloIngresosTotales.TabIndex = 17;
            this.lblTituloIngresosTotales.Text = "INGRESOS TOTALES";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::login.Properties.Resources.idb;
            this.pictureBox3.Location = new System.Drawing.Point(18, 15);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(68, 63);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 29;
            this.pictureBox3.TabStop = false;
            // 
            // lblTituloIngresosBar
            // 
            this.lblTituloIngresosBar.AutoSize = false;
            this.lblTituloIngresosBar.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloIngresosBar.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.lblTituloIngresosBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(37)))), ((int)(((byte)(87)))));
            this.lblTituloIngresosBar.Location = new System.Drawing.Point(93, 15);
            this.lblTituloIngresosBar.Margin = new System.Windows.Forms.Padding(4);
            this.lblTituloIngresosBar.Name = "lblTituloIngresosBar";
            this.lblTituloIngresosBar.Size = new System.Drawing.Size(174, 98);
            this.lblTituloIngresosBar.TabIndex = 28;
            this.lblTituloIngresosBar.Text = "INGRESOS DEL BAR";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::login.Properties.Resources.ipr;
            this.pictureBox4.Location = new System.Drawing.Point(22, 15);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(68, 63);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 30;
            this.pictureBox4.TabStop = false;
            // 
            // lblTituloIngresosReservas
            // 
            this.lblTituloIngresosReservas.AutoSize = false;
            this.lblTituloIngresosReservas.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloIngresosReservas.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.lblTituloIngresosReservas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(37)))), ((int)(((byte)(87)))));
            this.lblTituloIngresosReservas.Location = new System.Drawing.Point(97, 15);
            this.lblTituloIngresosReservas.Margin = new System.Windows.Forms.Padding(4);
            this.lblTituloIngresosReservas.Name = "lblTituloIngresosReservas";
            this.lblTituloIngresosReservas.Size = new System.Drawing.Size(188, 98);
            this.lblTituloIngresosReservas.TabIndex = 29;
            this.lblTituloIngresosReservas.Text = "INGRESOS POR RESERVAS";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.AutoSize = false;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(37)))), ((int)(((byte)(87)))));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(24, 4);
            this.guna2HtmlLabel1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(232, 43);
            this.guna2HtmlLabel1.TabIndex = 22;
            this.guna2HtmlLabel1.Text = "Filtros de reporte";
            this.guna2HtmlLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1339, 902);
            this.Controls.Add(this.lblTituloGrafico);
            this.Controls.Add(this.lblTituloTabla);
            this.Controls.Add(this.pnlIngresosReservas);
            this.Controls.Add(this.pnlIngresosBar);
            this.Controls.Add(this.pnlIngresosTotales);
            this.Controls.Add(this.dgvReporte);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.lblIngresosTotales);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.pnlGrafico);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmReportes";
            this.Text = " ";
            this.Load += new System.EventHandler(this.frmReportes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartReporte)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.pnlFiltros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).EndInit();
            this.pnlIngresosTotales.ResumeLayout(false);
            this.pnlIngresosTotales.PerformLayout();
            this.pnlIngresosBar.ResumeLayout(false);
            this.pnlIngresosBar.PerformLayout();
            this.pnlIngresosReservas.ResumeLayout(false);
            this.pnlIngresosReservas.PerformLayout();
            this.pnlGrafico.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDesde;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpHasta;
        private Guna.UI2.WinForms.Guna2Button btnGenerar;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartReporte;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTituloReportes;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSubtituloReportes;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDesde;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblIngresosTotales2;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblIngresosTotales;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel pnlFiltros;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblHasta;
        private System.Windows.Forms.DataGridView dgvReporte;
        private Guna.UI2.WinForms.Guna2ComboBox cmbTipoReporte;
        private Guna.UI2.WinForms.Guna2Panel pnlIngresosTotales;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblIngresosBar;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblIngresosReservas;
        private Guna.UI2.WinForms.Guna2Panel pnlIngresosBar;
        private Guna.UI2.WinForms.Guna2Panel pnlIngresosReservas;
        private Guna.UI2.WinForms.Guna2Panel pnlGrafico;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTituloTabla;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTituloGrafico;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTituloIngresosTotales;
        private System.Windows.Forms.PictureBox pictureBox3;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTituloIngresosBar;
        private System.Windows.Forms.PictureBox pictureBox4;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTituloIngresosReservas;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
    }
}