using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace login
{
    public partial class frmReportes : Form
    {
        csConectaSQL oCon = new csConectaSQL();

        public frmReportes()
        {
            InitializeComponent();

            this.Load -= frmReportes_Load;
            this.Load += frmReportes_Load;

            btnGenerar.Click -= btnGenerar_Click;
            btnGenerar.Click += btnGenerar_Click;
        }

        private void frmReportes_Load(object sender, EventArgs e)
        {
            ConfigurarControles();
            CargarTiposReporte();

            // Desde enero del año actual hasta hoy
            dtpDesde.Value = new DateTime(DateTime.Now.Year, 1, 1);
            dtpHasta.Value = DateTime.Today;

            cmbTipoReporte.SelectedIndex = 0;

            CargarResumenIngresos();
            GenerarReporteSeleccionado();
        }

        private void ConfigurarControles()
        {
            dgvReporte.AutoGenerateColumns = true;
            dgvReporte.ReadOnly = true;
            dgvReporte.RowHeadersVisible = false;
            dgvReporte.AllowUserToAddRows = false;
            dgvReporte.AllowUserToDeleteRows = false;
            dgvReporte.AllowUserToResizeRows = false;
            dgvReporte.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReporte.MultiSelect = false;
            dgvReporte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarTiposReporte()
        {
            cmbTipoReporte.Items.Clear();

            cmbTipoReporte.Items.Add("Ingresos por mes");
            cmbTipoReporte.Items.Add("Productos más vendidos");
            cmbTipoReporte.Items.Add("Canchas más reservadas");
            cmbTipoReporte.Items.Add("Ingresos totales");
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (cmbTipoReporte.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Seleccione un tipo de reporte.",
                    "Reportes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (dtpDesde.Value.Date > dtpHasta.Value.Date)
            {
                MessageBox.Show(
                    "La fecha inicial no puede ser mayor que la fecha final.",
                    "Fechas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            CargarResumenIngresos();
            GenerarReporteSeleccionado();
        }

        private void GenerarReporteSeleccionado()
        {
            switch (cmbTipoReporte.Text)
            {
                case "Ingresos por mes":
                    ReporteIngresosPorMes();
                    break;

                case "Productos más vendidos":
                    ReporteProductosMasVendidos();
                    break;

                case "Canchas más reservadas":
                    ReporteCanchasMasReservadas();
                    break;

                case "Ingresos totales":
                    ReporteIngresosTotales();
                    break;
            }
        }

        // =========================================================
        // TARJETAS DE INGRESOS
        // =========================================================

        private void CargarResumenIngresos()
        {
            string consultaBar = @"
                SELECT ISNULL(SUM(Total), 0)
                FROM FacturasVenta
                WHERE Fecha >= @Desde
                AND Fecha < @Hasta
                AND (
                    Estado IS NULL
                    OR UPPER(LTRIM(RTRIM(Estado))) = 'FINALIZADA'
                )";

            string consultaReservas = @"
                SELECT ISNULL(SUM(Total), 0)
                FROM Facturas
                WHERE FechaEmision >= @Desde
                AND FechaEmision < @Hasta";

            decimal ingresosBar = ObtenerTotal(consultaBar);
            decimal ingresosReservas = ObtenerTotal(consultaReservas);

            decimal ingresosTotales =
                ingresosBar + ingresosReservas;

            lblIngresosBar.Text =
                "$ " + ingresosBar.ToString("N2");

            lblIngresosReservas.Text =
                "$ " + ingresosReservas.ToString("N2");

            lblIngresosTotales2.Text =
                "$ " + ingresosTotales.ToString("N2");
        }

        // =========================================================
        // 1. INGRESOS POR MES
        // =========================================================

        private void ReporteIngresosPorMes()
        {
            string consulta = @"
                WITH Movimientos AS
                (
                    SELECT
                        YEAR(Fecha) AS Anio,
                        MONTH(Fecha) AS NumeroMes,
                        SUM(Total) AS IngresosBar,
                        CAST(0 AS DECIMAL(18,2)) AS IngresosReservas
                    FROM FacturasVenta
                    WHERE Fecha >= @Desde
                    AND Fecha < @Hasta
                    AND (
                        Estado IS NULL
                        OR UPPER(LTRIM(RTRIM(Estado))) = 'FINALIZADA'
                    )
                    GROUP BY
                        YEAR(Fecha),
                        MONTH(Fecha)

                    UNION ALL

                    SELECT
                        YEAR(FechaEmision) AS Anio,
                        MONTH(FechaEmision) AS NumeroMes,
                        CAST(0 AS DECIMAL(18,2)) AS IngresosBar,
                        SUM(Total) AS IngresosReservas
                    FROM Facturas
                    WHERE FechaEmision >= @Desde
                    AND FechaEmision < @Hasta
                    GROUP BY
                        YEAR(FechaEmision),
                        MONTH(FechaEmision)
                )

                SELECT
                    Anio,
                    NumeroMes,
                    SUM(IngresosBar) AS IngresosBar,
                    SUM(IngresosReservas) AS IngresosReservas,
                    SUM(IngresosBar + IngresosReservas) AS TotalIngresos
                FROM Movimientos
                GROUP BY
                    Anio,
                    NumeroMes
                ORDER BY
                    Anio,
                    NumeroMes";

            DataTable datos = EjecutarConsulta(consulta);

            DataTable tabla = new DataTable();

            tabla.Columns.Add("Periodo", typeof(string));
            tabla.Columns.Add("IngresosBar", typeof(decimal));
            tabla.Columns.Add("IngresosReservas", typeof(decimal));
            tabla.Columns.Add("TotalIngresos", typeof(decimal));

            foreach (DataRow fila in datos.Rows)
            {
                int anio =
                    Convert.ToInt32(fila["Anio"]);

                int numeroMes =
                    Convert.ToInt32(fila["NumeroMes"]);

                decimal ingresosBar =
                    Convert.ToDecimal(fila["IngresosBar"]);

                decimal ingresosReservas =
                    Convert.ToDecimal(fila["IngresosReservas"]);

                decimal total =
                    Convert.ToDecimal(fila["TotalIngresos"]);

                tabla.Rows.Add(
                    ObtenerNombreMes(numeroMes) + " " + anio,
                    ingresosBar,
                    ingresosReservas,
                    total);
            }

            MostrarTabla(tabla);

            lblTituloTabla.Text =
                "Ingresos por mes";

            lblTituloGrafico.Text =
                "Ingresos mensuales";

            PrepararGrafico(
                SeriesChartType.Column,
                true);

            Series serie =
                CrearSerie(
                    "Ingresos",
                    SeriesChartType.Column,
                    true);

            foreach (DataRow fila in tabla.Rows)
            {
                serie.Points.AddXY(
                    fila["Periodo"].ToString(),
                    Convert.ToDecimal(
                        fila["TotalIngresos"]));
            }

            chartReporte.Series.Add(serie);
        }

        // =========================================================
        // 2. PRODUCTOS MÁS VENDIDOS
        // =========================================================

        private void ReporteProductosMasVendidos()
        {
            string consulta = @"
                SELECT TOP 10
                    P.Nombre AS Producto,
                    SUM(D.Cantidad) AS CantidadVendida,
                    SUM(D.Total) AS TotalGenerado
                FROM DetalleFacturaVenta D
                INNER JOIN Productos P
                    ON D.ProductoID = P.ProductoID
                INNER JOIN FacturasVenta F
                    ON D.FacturaID = F.FacturaID
                WHERE F.Fecha >= @Desde
                AND F.Fecha < @Hasta
                AND (
                    F.Estado IS NULL
                    OR UPPER(LTRIM(RTRIM(F.Estado))) = 'FINALIZADA'
                )
                GROUP BY
                    P.ProductoID,
                    P.Nombre
                ORDER BY
                    CantidadVendida DESC,
                    TotalGenerado DESC";

            DataTable tabla =
                EjecutarConsulta(consulta);

            MostrarTabla(tabla);

            lblTituloTabla.Text =
                "Productos más vendidos";

            lblTituloGrafico.Text =
                "Top de productos vendidos";

            PrepararGrafico(
                SeriesChartType.Bar,
                false);

            Series serie =
                CrearSerie(
                    "Cantidad vendida",
                    SeriesChartType.Bar,
                    false);

            foreach (DataRow fila in tabla.Rows)
            {
                serie.Points.AddXY(
                    fila["Producto"].ToString(),
                    Convert.ToInt32(
                        fila["CantidadVendida"]));
            }

            chartReporte.Series.Add(serie);
        }

        // =========================================================
        // 3. CANCHAS MÁS RESERVADAS
        // =========================================================

        private void ReporteCanchasMasReservadas()
        {
            string consulta = @"
                SELECT TOP 10
                    C.Nombre AS Cancha,
                    C.Tipo AS Deporte,
                    COUNT(R.ReservaID) AS CantidadReservas
                FROM Reservas R
                INNER JOIN Canchas C
                    ON R.CanchaID = C.CanchaID
                WHERE R.Fecha >= @Desde
                AND R.Fecha < @Hasta
                AND UPPER(
                    LTRIM(
                        RTRIM(
                            ISNULL(R.Estado, '')
                        )
                    )
                ) <> 'CANCELADA'
                GROUP BY
                    C.CanchaID,
                    C.Nombre,
                    C.Tipo
                ORDER BY
                    CantidadReservas DESC";

            DataTable tabla =
                EjecutarConsulta(consulta);

            MostrarTabla(tabla);

            lblTituloTabla.Text =
                "Canchas más reservadas";

            lblTituloGrafico.Text =
                "Reservas por cancha";

            PrepararGrafico(
                SeriesChartType.Bar,
                false);

            Series serie =
                CrearSerie(
                    "Reservas",
                    SeriesChartType.Bar,
                    false);

            foreach (DataRow fila in tabla.Rows)
            {
                string nombreCancha =
                    fila["Cancha"].ToString();

                serie.Points.AddXY(
                    nombreCancha,
                    Convert.ToInt32(
                        fila["CantidadReservas"]));
            }

            chartReporte.Series.Add(serie);
        }

        // =========================================================
        // 4. INGRESOS TOTALES
        // =========================================================

        private void ReporteIngresosTotales()
        {
            string consultaBar = @"
                SELECT ISNULL(SUM(Total), 0)
                FROM FacturasVenta
                WHERE Fecha >= @Desde
                AND Fecha < @Hasta
                AND (
                    Estado IS NULL
                    OR UPPER(LTRIM(RTRIM(Estado))) = 'FINALIZADA'
                )";

            string consultaReservas = @"
                SELECT ISNULL(SUM(Total), 0)
                FROM Facturas
                WHERE FechaEmision >= @Desde
                AND FechaEmision < @Hasta";

            decimal ingresosBar =
                ObtenerTotal(consultaBar);

            decimal ingresosReservas =
                ObtenerTotal(consultaReservas);

            decimal ingresosTotales =
                ingresosBar + ingresosReservas;

            DataTable tabla = new DataTable();

            tabla.Columns.Add(
                "Concepto",
                typeof(string));

            tabla.Columns.Add(
                "Total",
                typeof(decimal));

            tabla.Rows.Add(
                "Bar",
                ingresosBar);

            tabla.Rows.Add(
                "Reservas",
                ingresosReservas);

            tabla.Rows.Add(
                "Total general",
                ingresosTotales);

            MostrarTabla(tabla);

            lblTituloTabla.Text =
                "Resumen de ingresos";

            lblTituloGrafico.Text =
                "Distribución de ingresos";

            PrepararGrafico(
                SeriesChartType.Column,
                true);

            Series serie =
                CrearSerie(
                    "Ingresos",
                    SeriesChartType.Column,
                    true);

            serie.Points.AddXY(
                "Bar",
                ingresosBar);

            serie.Points.AddXY(
                "Reservas",
                ingresosReservas);

            chartReporte.Series.Add(serie);
        }

        // =========================================================
        // CONSULTAS
        // =========================================================

        private DataTable EjecutarConsulta(string consulta)
        {
            DataTable tabla =
                new DataTable();

            try
            {
                if (!oCon.abrirConexion())
                    return tabla;

                using (SqlCommand cmd =
                    new SqlCommand(
                        consulta,
                        oCon.oCon))
                {
                    AgregarParametrosFechas(cmd);

                    using (SqlDataAdapter da =
                        new SqlDataAdapter(cmd))
                    {
                        da.Fill(tabla);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al generar el reporte:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                oCon.cerrarConexion();
            }

            return tabla;
        }

        private decimal ObtenerTotal(string consulta)
        {
            decimal total = 0;

            try
            {
                if (!oCon.abrirConexion())
                    return 0;

                using (SqlCommand cmd =
                    new SqlCommand(
                        consulta,
                        oCon.oCon))
                {
                    AgregarParametrosFechas(cmd);

                    object resultado =
                        cmd.ExecuteScalar();

                    if (resultado != null &&
                        resultado != DBNull.Value)
                    {
                        total =
                            Convert.ToDecimal(
                                resultado);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al obtener los ingresos:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                oCon.cerrarConexion();
            }

            return total;
        }

        private void AgregarParametrosFechas(
            SqlCommand cmd)
        {
            DateTime desde =
                dtpDesde.Value.Date;

            DateTime hasta =
                dtpHasta.Value.Date.AddDays(1);

            cmd.Parameters.Add(
                "@Desde",
                SqlDbType.DateTime).Value =
                desde;

            cmd.Parameters.Add(
                "@Hasta",
                SqlDbType.DateTime).Value =
                hasta;
        }

        // =========================================================
        // DATAGRIDVIEW
        // =========================================================

        private void MostrarTabla(
            DataTable tabla)
        {
            dgvReporte.DataSource = null;
            dgvReporte.Columns.Clear();

            dgvReporte.AutoGenerateColumns = true;

            dgvReporte.DataSource =
                tabla;

            FormatearColumnas();
        }

        private void FormatearColumnas()
        {
            foreach (DataGridViewColumn columna
                in dgvReporte.Columns)
            {
                switch (columna.Name)
                {
                    case "Periodo":
                        columna.HeaderText =
                            "Mes";
                        break;

                    case "IngresosBar":
                        columna.HeaderText =
                            "Ingresos bar";

                        FormatearDinero(
                            columna);
                        break;

                    case "IngresosReservas":
                        columna.HeaderText =
                            "Ingresos reservas";

                        FormatearDinero(
                            columna);
                        break;

                    case "TotalIngresos":
                        columna.HeaderText =
                            "Total";

                        FormatearDinero(
                            columna);
                        break;

                    case "CantidadVendida":
                        columna.HeaderText =
                            "Cantidad vendida";

                        columna.DefaultCellStyle.Format =
                            "N0";
                        break;

                    case "TotalGenerado":
                        columna.HeaderText =
                            "Total generado";

                        FormatearDinero(
                            columna);
                        break;

                    case "CantidadReservas":
                        columna.HeaderText =
                            "Reservas";

                        columna.DefaultCellStyle.Format =
                            "N0";
                        break;

                    case "Total":
                        columna.HeaderText =
                            "Total";

                        FormatearDinero(
                            columna);
                        break;
                }
            }
        }

        private void FormatearDinero(
            DataGridViewColumn columna)
        {
            columna.DefaultCellStyle.Format =
                "$ #,##0.00";

            columna.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
        }

        // =========================================================
        // GRÁFICOS
        // =========================================================

        private void PrepararGrafico(
            SeriesChartType tipo,
            bool esDinero)
        {
            chartReporte.Series.Clear();
            chartReporte.ChartAreas.Clear();
            chartReporte.Legends.Clear();

            ChartArea area =
                new ChartArea(
                    "AreaPrincipal");

            area.BackColor =
                Color.White;

            area.AxisX.MajorGrid.Enabled =
                false;

            area.AxisX.LineColor =
                Color.Gainsboro;

            area.AxisX.LabelStyle.ForeColor =
                Color.DimGray;

            area.AxisX.Interval = 1;

            area.AxisY.LineColor =
                Color.Gainsboro;

            area.AxisY.MajorGrid.LineColor =
                Color.FromArgb(
                    235,
                    238,
                    242);

            area.AxisY.LabelStyle.ForeColor =
                Color.DimGray;

            if (esDinero)
            {
                area.AxisY.LabelStyle.Format =
                    "$ #,##0.00";
            }
            else
            {
                area.AxisY.LabelStyle.Format =
                    "N0";
            }

            chartReporte.ChartAreas.Add(
                area);

            chartReporte.BackColor =
                Color.White;
        }

        private Series CrearSerie(
            string nombre,
            SeriesChartType tipo,
            bool esDinero)
        {
            Series serie =
                new Series(nombre);

            serie.ChartType =
                tipo;

            serie.ChartArea =
                "AreaPrincipal";

            serie.IsValueShownAsLabel =
                true;

            if (esDinero)
            {
                serie.LabelFormat =
                    "$ #,##0.00";
            }
            else
            {
                serie.LabelFormat =
                    "N0";
            }

            return serie;
        }

      

        private string ObtenerNombreMes(
            int numeroMes)
        {
            CultureInfo cultura =
                new CultureInfo(
                    "es-EC");

            string mes =
                cultura.DateTimeFormat
                .GetMonthName(numeroMes);

            if (string.IsNullOrWhiteSpace(mes))
                return "";

            return char.ToUpper(mes[0]) +
                   mes.Substring(1);
        }
    }
}