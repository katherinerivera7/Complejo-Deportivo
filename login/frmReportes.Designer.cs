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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.lblHasta = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dgvReporte = new System.Windows.Forms.DataGridView();
            this.cmbTipoReporte = new Guna.UI2.WinForms.Guna2ComboBox();
            this.pnlIngresosTotales = new Guna.UI2.WinForms.Guna2Panel();
            this.lblIngresosBar = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblIngresosReservas = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlIngresosBar = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlIngresosReservas = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlGrafico = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTituloIngresosTotales = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTituloIngresosBar = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTituloIngresosReservas = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTituloTabla = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTituloGrafico = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)(this.chartReporte)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).BeginInit();
            this.pnlIngresosTotales.SuspendLayout();
            this.pnlIngresosBar.SuspendLayout();
            this.pnlIngresosReservas.SuspendLayout();
            this.pnlGrafico.SuspendLayout();
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
            this.dtpDesde.Location = new System.Drawing.Point(15, 31);
            this.dtpDesde.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDesde.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(170, 38);
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
            this.dtpHasta.Location = new System.Drawing.Point(18, 101);
            this.dtpHasta.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpHasta.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(170, 38);
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
            this.btnGenerar.Location = new System.Drawing.Point(15, 246);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(173, 45);
            this.btnGenerar.TabIndex = 6;
            this.btnGenerar.Text = "Generar reporte";
            // 
            // chartReporte
            // 
            this.chartReporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.chartReporte.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.chartReporte.BorderlineWidth = 0;
            chartArea1.BackColor = System.Drawing.Color.White;
            chartArea1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            chartArea1.Name = "ChartArea1";
            this.chartReporte.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartReporte.Legends.Add(legend1);
            this.chartReporte.Location = new System.Drawing.Point(88, 15);
            this.chartReporte.Name = "chartReporte";
            this.chartReporte.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartReporte.Series.Add(series1);
            this.chartReporte.Size = new System.Drawing.Size(510, 265);
            this.chartReporte.TabIndex = 8;
            this.chartReporte.Text = "chart1";
            // 
            // lblTituloReportes
            // 
            this.lblTituloReportes.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloReportes.Font = new System.Drawing.Font("Segoe UI Semibold", 20F);
            this.lblTituloReportes.Location = new System.Drawing.Point(24, 14);
            this.lblTituloReportes.Name = "lblTituloReportes";
            this.lblTituloReportes.Size = new System.Drawing.Size(281, 39);
            this.lblTituloReportes.TabIndex = 9;
            this.lblTituloReportes.Text = "Reportes y estadísticas";
            // 
            // lblSubtituloReportes
            // 
            this.lblSubtituloReportes.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtituloReportes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblSubtituloReportes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(129)))), ((int)(((byte)(141)))));
            this.lblSubtituloReportes.Location = new System.Drawing.Point(26, 48);
            this.lblSubtituloReportes.Name = "lblSubtituloReportes";
            this.lblSubtituloReportes.Size = new System.Drawing.Size(295, 17);
            this.lblSubtituloReportes.TabIndex = 10;
            this.lblSubtituloReportes.Text = "Consulta la información más importante del complejo";
            // 
            // lblDesde
            // 
            this.lblDesde.BackColor = System.Drawing.Color.Transparent;
            this.lblDesde.Location = new System.Drawing.Point(15, 10);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(34, 15);
            this.lblDesde.TabIndex = 11;
            this.lblDesde.Text = "Desde";
            // 
            // lblIngresosTotales2
            // 
            this.lblIngresosTotales2.BackColor = System.Drawing.Color.Transparent;
            this.lblIngresosTotales2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngresosTotales2.ForeColor = System.Drawing.Color.Black;
            this.lblIngresosTotales2.Location = new System.Drawing.Point(-3, 45);
            this.lblIngresosTotales2.Name = "lblIngresosTotales2";
            this.lblIngresosTotales2.Size = new System.Drawing.Size(141, 26);
            this.lblIngresosTotales2.TabIndex = 14;
            this.lblIngresosTotales2.Text = "Ingresos Totales";
            this.lblIngresosTotales2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIngresosTotales
            // 
            this.lblIngresosTotales.BackColor = System.Drawing.Color.Transparent;
            this.lblIngresosTotales.Location = new System.Drawing.Point(560, 319);
            this.lblIngresosTotales.Name = "lblIngresosTotales";
            this.lblIngresosTotales.Size = new System.Drawing.Size(81, 15);
            this.lblIngresosTotales.TabIndex = 13;
            this.lblIngresosTotales.Text = "Ingresos Totales";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.Controls.Add(this.lblTituloReportes);
            this.guna2Panel1.Controls.Add(this.lblSubtituloReportes);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.FillColor = System.Drawing.Color.White;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1004, 72);
            this.guna2Panel1.TabIndex = 16;
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.Controls.Add(this.guna2HtmlLabel2);
            this.pnlFiltros.Controls.Add(this.lblDesde);
            this.pnlFiltros.Controls.Add(this.dtpDesde);
            this.pnlFiltros.Controls.Add(this.lblHasta);
            this.pnlFiltros.Controls.Add(this.dtpHasta);
            this.pnlFiltros.Controls.Add(this.btnGenerar);
            this.pnlFiltros.Controls.Add(this.cmbTipoReporte);
            this.pnlFiltros.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.pnlFiltros.Location = new System.Drawing.Point(30, 100);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(222, 309);
            this.pnlFiltros.TabIndex = 17;
            // 
            // lblHasta
            // 
            this.lblHasta.BackColor = System.Drawing.Color.Transparent;
            this.lblHasta.Location = new System.Drawing.Point(18, 80);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(31, 15);
            this.lblHasta.TabIndex = 18;
            this.lblHasta.Text = "Hasta";
            // 
            // dgvReporte
            // 
            this.dgvReporte.AllowUserToAddRows = false;
            this.dgvReporte.AllowUserToDeleteRows = false;
            this.dgvReporte.AllowUserToResizeColumns = false;
            this.dgvReporte.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(65)))));
            this.dgvReporte.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReporte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReporte.BackgroundColor = System.Drawing.Color.White;
            this.dgvReporte.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReporte.ColumnHeadersHeight = 40;
            this.dgvReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(235)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(55)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReporte.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReporte.EnableHeadersVisualStyles = false;
            this.dgvReporte.GridColor = System.Drawing.Color.Black;
            this.dgvReporte.Location = new System.Drawing.Point(0, 430);
            this.dgvReporte.MultiSelect = false;
            this.dgvReporte.Name = "dgvReporte";
            this.dgvReporte.ReadOnly = true;
            this.dgvReporte.RowHeadersVisible = false;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(65)))));
            this.dgvReporte.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvReporte.RowTemplate.Height = 36;
            this.dgvReporte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReporte.Size = new System.Drawing.Size(356, 303);
            this.dgvReporte.TabIndex = 19;
            // 
            // cmbTipoReporte
            // 
            this.cmbTipoReporte.BackColor = System.Drawing.Color.Transparent;
            this.cmbTipoReporte.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTipoReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoReporte.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbTipoReporte.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbTipoReporte.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTipoReporte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbTipoReporte.ItemHeight = 30;
            this.cmbTipoReporte.Location = new System.Drawing.Point(18, 174);
            this.cmbTipoReporte.Name = "cmbTipoReporte";
            this.cmbTipoReporte.Size = new System.Drawing.Size(167, 36);
            this.cmbTipoReporte.TabIndex = 20;
            // 
            // pnlIngresosTotales
            // 
            this.pnlIngresosTotales.Controls.Add(this.lblIngresosTotales2);
            this.pnlIngresosTotales.Location = new System.Drawing.Point(345, 168);
            this.pnlIngresosTotales.Name = "pnlIngresosTotales";
            this.pnlIngresosTotales.Size = new System.Drawing.Size(138, 100);
            this.pnlIngresosTotales.TabIndex = 21;
            // 
            // lblIngresosBar
            // 
            this.lblIngresosBar.BackColor = System.Drawing.Color.Transparent;
            this.lblIngresosBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngresosBar.ForeColor = System.Drawing.Color.Black;
            this.lblIngresosBar.Location = new System.Drawing.Point(19, 43);
            this.lblIngresosBar.Name = "lblIngresosBar";
            this.lblIngresosBar.Size = new System.Drawing.Size(107, 26);
            this.lblIngresosBar.TabIndex = 22;
            this.lblIngresosBar.Text = "Ingresos bar";
            this.lblIngresosBar.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIngresosReservas
            // 
            this.lblIngresosReservas.BackColor = System.Drawing.Color.Transparent;
            this.lblIngresosReservas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngresosReservas.ForeColor = System.Drawing.Color.Black;
            this.lblIngresosReservas.Location = new System.Drawing.Point(-11, 43);
            this.lblIngresosReservas.Name = "lblIngresosReservas";
            this.lblIngresosReservas.Size = new System.Drawing.Size(158, 26);
            this.lblIngresosReservas.TabIndex = 23;
            this.lblIngresosReservas.Text = "Ingresos Reservas";
            this.lblIngresosReservas.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlIngresosBar
            // 
            this.pnlIngresosBar.Controls.Add(this.lblIngresosBar);
            this.pnlIngresosBar.Location = new System.Drawing.Point(541, 168);
            this.pnlIngresosBar.Name = "pnlIngresosBar";
            this.pnlIngresosBar.Size = new System.Drawing.Size(149, 100);
            this.pnlIngresosBar.TabIndex = 22;
            // 
            // pnlIngresosReservas
            // 
            this.pnlIngresosReservas.Controls.Add(this.lblIngresosReservas);
            this.pnlIngresosReservas.Location = new System.Drawing.Point(772, 168);
            this.pnlIngresosReservas.Name = "pnlIngresosReservas";
            this.pnlIngresosReservas.Size = new System.Drawing.Size(138, 100);
            this.pnlIngresosReservas.TabIndex = 23;
            // 
            // pnlGrafico
            // 
            this.pnlGrafico.Controls.Add(this.chartReporte);
            this.pnlGrafico.Location = new System.Drawing.Point(338, 430);
            this.pnlGrafico.Name = "pnlGrafico";
            this.pnlGrafico.Size = new System.Drawing.Size(666, 303);
            this.pnlGrafico.TabIndex = 24;
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(18, 153);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(96, 19);
            this.guna2HtmlLabel2.TabIndex = 21;
            this.guna2HtmlLabel2.Text = "Tipo de reporte";
            // 
            // lblTituloIngresosTotales
            // 
            this.lblTituloIngresosTotales.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloIngresosTotales.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloIngresosTotales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(81)))), ((int)(((byte)(99)))));
            this.lblTituloIngresosTotales.Location = new System.Drawing.Point(338, 131);
            this.lblTituloIngresosTotales.Name = "lblTituloIngresosTotales";
            this.lblTituloIngresosTotales.Size = new System.Drawing.Size(154, 18);
            this.lblTituloIngresosTotales.TabIndex = 15;
            this.lblTituloIngresosTotales.Text = "INGRESOS TOTALES";
            this.lblTituloIngresosTotales.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTituloIngresosBar
            // 
            this.lblTituloIngresosBar.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloIngresosBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloIngresosBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(81)))), ((int)(((byte)(99)))));
            this.lblTituloIngresosBar.Location = new System.Drawing.Point(541, 131);
            this.lblTituloIngresosBar.Name = "lblTituloIngresosBar";
            this.lblTituloIngresosBar.Size = new System.Drawing.Size(149, 18);
            this.lblTituloIngresosBar.TabIndex = 23;
            this.lblTituloIngresosBar.Text = "INGRESOS DEL BAR";
            this.lblTituloIngresosBar.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTituloIngresosReservas
            // 
            this.lblTituloIngresosReservas.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloIngresosReservas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloIngresosReservas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(81)))), ((int)(((byte)(99)))));
            this.lblTituloIngresosReservas.Location = new System.Drawing.Point(733, 131);
            this.lblTituloIngresosReservas.Name = "lblTituloIngresosReservas";
            this.lblTituloIngresosReservas.Size = new System.Drawing.Size(203, 18);
            this.lblTituloIngresosReservas.TabIndex = 24;
            this.lblTituloIngresosReservas.Text = "INGRESOS POR RESERVAS";
            this.lblTituloIngresosReservas.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTituloTabla
            // 
            this.lblTituloTabla.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloTabla.ForeColor = System.Drawing.Color.Black;
            this.lblTituloTabla.Location = new System.Drawing.Point(426, 409);
            this.lblTituloTabla.Name = "lblTituloTabla";
            this.lblTituloTabla.Size = new System.Drawing.Size(110, 15);
            this.lblTituloTabla.TabIndex = 25;
            this.lblTituloTabla.Text = "Titulo Ingresos Totales";
            // 
            // lblTituloGrafico
            // 
            this.lblTituloGrafico.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloGrafico.ForeColor = System.Drawing.Color.Black;
            this.lblTituloGrafico.Location = new System.Drawing.Point(30, 409);
            this.lblTituloGrafico.Name = "lblTituloGrafico";
            this.lblTituloGrafico.Size = new System.Drawing.Size(110, 15);
            this.lblTituloGrafico.TabIndex = 26;
            this.lblTituloGrafico.Text = "Titulo Ingresos Totales";
            // 
            // frmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1004, 733);
            this.Controls.Add(this.lblTituloGrafico);
            this.Controls.Add(this.lblTituloTabla);
            this.Controls.Add(this.lblTituloIngresosReservas);
            this.Controls.Add(this.lblTituloIngresosBar);
            this.Controls.Add(this.lblTituloIngresosTotales);
            this.Controls.Add(this.pnlIngresosReservas);
            this.Controls.Add(this.pnlIngresosBar);
            this.Controls.Add(this.pnlIngresosTotales);
            this.Controls.Add(this.dgvReporte);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.lblIngresosTotales);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.pnlGrafico);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReportes";
            this.Text = "frmReportes";
            this.Load += new System.EventHandler(this.frmReportes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartReporte)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).EndInit();
            this.pnlIngresosTotales.ResumeLayout(false);
            this.pnlIngresosTotales.PerformLayout();
            this.pnlIngresosBar.ResumeLayout(false);
            this.pnlIngresosBar.PerformLayout();
            this.pnlIngresosReservas.ResumeLayout(false);
            this.pnlIngresosReservas.PerformLayout();
            this.pnlGrafico.ResumeLayout(false);
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
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTituloIngresosTotales;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTituloIngresosBar;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTituloIngresosReservas;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTituloTabla;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTituloGrafico;
    }
}