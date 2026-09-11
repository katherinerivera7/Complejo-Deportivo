using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace login.Reservas
{
    public partial class frmDisponibilidad : Form
    {
        csConectaSQL conSQL = new csConectaSQL();
        string cadena;

        // Evita que los eventos se ejecuten varias veces
        // mientras se está cargando el formulario.
        private bool cargandoFormulario = false;

        public frmDisponibilidad()
        {
            InitializeComponent();

            dgvHorarios.RowHeadersVisible = false;
            dgvHorarios.ReadOnly = true;
            dgvHorarios.AllowUserToAddRows = false;
            dgvHorarios.AllowUserToDeleteRows = false;
            dgvHorarios.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvHorarios.MultiSelect = false;
            dgvHorarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvHorarios.ScrollBars = ScrollBars.Both;
            dgvHorarios.RowTemplate.Height = 35;
        }

        private void frmDisponibilidad_Load(object sender, EventArgs e)
        {
            cargandoFormulario = true;

            // No permitir fechas anteriores al día actual
            dtpFecha.MinDate = DateTime.Today;
            dtpFecha.Value = DateTime.Today;

            CargarFiltroCanchas();

            cargandoFormulario = false;

            // Carga toda la pantalla por primera vez.
            ActualizarPantalla();
        }

        private void CargarFiltroCanchas()
        {
            cmbFiltroCancha.Items.Clear();
            cmbFiltroCancha.Items.Add("Todas");

            DataTable dtCanchas = conSQL.retornaRegistros(
                "SELECT Nombre FROM Canchas ORDER BY Nombre");

            if (dtCanchas != null)
            {
                foreach (DataRow fila in dtCanchas.Rows)
                {
                    cmbFiltroCancha.Items.Add(
                        fila["Nombre"].ToString());
                }
            }

            cmbFiltroCancha.SelectedIndex = 0;
        }

        // Actualiza TODO lo relacionado con la fecha seleccionada.
        private void ActualizarPantalla()
        {
            ActualizarFecha();
            CargarResumenCanchas();
            CargarDisponibilidad();
        }

        private void ActualizarFecha()
        {
            DateTime fecha = dtpFecha.Value.Date;

            CultureInfo cultura = new CultureInfo("es-ES");

            // Label grande que está entre las dos flechas.
            // Ejemplo: 12 de agosto de 2026
            lblMes.Text = fecha.ToString(
                "d 'de' MMMM 'de' yyyy",
                cultura);

            // Tarjeta superior.
            // Ejemplo: 12 agosto 2026
            lblFechaSeleccionada.Text = fecha.ToString(
                "d MMMM yyyy",
                cultura);

            // Ejemplo: miércoles
            lblDia.Text = fecha.ToString(
                "dddd",
                cultura);

            // No se puede retroceder antes de hoy.
            btnRetroceder.Enabled =
                fecha > DateTime.Today;

            // Evita exceder la fecha máxima del DateTimePicker.
            btnSiguiente.Enabled =
                fecha < dtpFecha.MaxDate.Date;
        }

        private void CargarResumenCanchas()
        {
            string fecha = dtpFecha.Value.ToString("yyyyMMdd");

            /*
             * TotalActivas:
             * Solo cuenta canchas que NO están:
             * - En mantenimiento
             * - Inactivas
             * - Cerradas
             *
             * Disponibles:
             * Cuenta las canchas activas que tienen al menos
             * un horario libre en la fecha seleccionada.
             *
             * Si la fecha seleccionada es hoy, solo se consideran
             * horarios que todavía no hayan terminado.
             */

            string condicionHorario = "";

            if (dtpFecha.Value.Date == DateTime.Today)
            {
                condicionHorario =
                    " AND H.HoraFin > CAST(GETDATE() AS TIME) ";
            }

            string consulta = @"
                SELECT
                    COUNT(*) AS TotalActivas,

                    SUM(
                        CASE
                            WHEN EXISTS
                            (
                                SELECT 1
                                FROM Horarios H
                                WHERE 1 = 1
                                " + condicionHorario + @"

                                AND NOT EXISTS
                                (
                                    SELECT 1
                                    FROM Reservas R
                                    WHERE R.CanchaID = C.CanchaID

                                    AND CONVERT(DATE, R.Fecha) =
                                        CONVERT(DATE, '" + fecha + @"', 112)

                                    AND UPPER(
                                        LTRIM(
                                            RTRIM(
                                                ISNULL(R.Estado, '')
                                            )
                                        )
                                    ) <> 'CANCELADA'

                                    AND R.HoraInicio < H.HoraFin
                                    AND R.HoraFin > H.HoraInicio
                                )
                            )
                            THEN 1
                            ELSE 0
                        END
                    ) AS Disponibles

                FROM Canchas C

                WHERE
                    UPPER(
                        LTRIM(
                            RTRIM(
                                ISNULL(C.Estado, '')
                            )
                        )
                    ) NOT LIKE 'MANTENIMIENTO%'

                AND UPPER(
                    LTRIM(
                        RTRIM(
                            ISNULL(C.Estado, '')
                        )
                    )
                ) NOT IN ('INACTIVA', 'CERRADA')";

            DataTable dt =
                conSQL.retornaRegistros(consulta);

            if (dt != null && dt.Rows.Count > 0)
            {
                int totalActivas = 0;
                int disponibles = 0;

                if (dt.Rows[0]["TotalActivas"] != DBNull.Value)
                {
                    totalActivas =
                        Convert.ToInt32(
                            dt.Rows[0]["TotalActivas"]);
                }

                if (dt.Rows[0]["Disponibles"] != DBNull.Value)
                {
                    disponibles =
                        Convert.ToInt32(
                            dt.Rows[0]["Disponibles"]);
                }

                lblCanchasTotales.Text =
                    totalActivas.ToString();

                lblCanchasDisponibles.Text =
                    disponibles.ToString();
            }
            else
            {
                lblCanchasTotales.Text = "0";
                lblCanchasDisponibles.Text = "0";
            }
        }

        private void CargarDisponibilidad()
        {
            string fecha =
                dtpFecha.Value.ToString("yyyyMMdd");

            string filtro =
                cmbFiltroCancha.Text
                .Trim()
                .Replace("'", "''");

            cadena =
                "SELECT " +

                "CONVERT(VARCHAR(5), H.HoraInicio, 108) AS HoraInicio, " +

                "CONVERT(VARCHAR(5), H.HoraFin, 108) AS HoraFin, " +

                "C.CanchaID, " +
                "C.Nombre, " +

                "CASE " +

                // Cancha fuera de servicio.
                "WHEN UPPER(LTRIM(RTRIM(ISNULL(C.Estado, '')))) " +
                "LIKE 'MANTENIMIENTO%' " +

                "OR UPPER(LTRIM(RTRIM(ISNULL(C.Estado, '')))) " +
                "IN ('INACTIVA', 'CERRADA') " +

                "THEN 'Mantenimiento' " +

                // Existe una reserva que ocupa ese horario.
                "WHEN EXISTS " +
                "( " +

                "SELECT 1 " +
                "FROM Reservas R " +

                "WHERE R.CanchaID = C.CanchaID " +

                "AND CONVERT(DATE, R.Fecha) = " +
                "CONVERT(DATE, '" + fecha + "', 112) " +

                "AND UPPER(LTRIM(RTRIM(ISNULL(R.Estado, '')))) " +
                "<> 'CANCELADA' " +

                "AND R.HoraInicio < H.HoraFin " +
                "AND R.HoraFin > H.HoraInicio " +

                ") " +

                "THEN 'Reservada' " +

                // Si no está en mantenimiento ni reservada.
                "ELSE 'Disponible' " +

                "END AS EstadoHorario " +

                "FROM Horarios H " +

                "CROSS JOIN Canchas C ";

            // Filtro por una cancha específica.
            if (filtro != "Todas" &&
                !string.IsNullOrWhiteSpace(filtro))
            {
                cadena +=
                    "WHERE C.Nombre = '" +
                    filtro +
                    "' ";
            }

            cadena +=
                "ORDER BY H.HoraInicio, C.CanchaID";

            DataTable dt =
                conSQL.retornaRegistros(cadena);

            dgvHorarios.Columns.Clear();
            dgvHorarios.Rows.Clear();

            if (dt == null ||
                dt.Rows.Count == 0)
            {
                return;
            }

            // -----------------------------------------
            // CREAR COLUMNAS DE LAS CANCHAS
            // -----------------------------------------

            DataTable canchas =
                dt.DefaultView.ToTable(
                    true,
                    "CanchaID",
                    "Nombre");

            DataGridViewTextBoxColumn columnaHorario =
                new DataGridViewTextBoxColumn();

            columnaHorario.Name =
                "colHorario";

            columnaHorario.HeaderText =
                "Horario";

            columnaHorario.Width = 120;
            columnaHorario.Frozen = true;

            columnaHorario.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvHorarios.Columns.Add(
                columnaHorario);

            foreach (DataRow cancha in canchas.Rows)
            {
                DataGridViewTextBoxColumn columna =
                    new DataGridViewTextBoxColumn();

                int canchaID =
                    Convert.ToInt32(
                        cancha["CanchaID"]);

                columna.Name =
                    "Cancha_" + canchaID;

                columna.HeaderText =
                    cancha["Nombre"].ToString();

                columna.Width = 130;

                // Guardamos internamente el ID.
                columna.Tag = canchaID;

                columna.DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                dgvHorarios.Columns.Add(
                    columna);
            }

            // -----------------------------------------
            // CREAR FILAS DE HORARIOS
            // -----------------------------------------

            DataTable horarios =
                dt.DefaultView.ToTable(
                    true,
                    "HoraInicio",
                    "HoraFin");

            Dictionary<string, int> filas =
                new Dictionary<string, int>();

            foreach (DataRow horario in horarios.Rows)
            {
                string inicio =
                    horario["HoraInicio"].ToString();

                string fin =
                    horario["HoraFin"].ToString();

                string clave =
                    inicio + "|" + fin;

                string textoHorario =
                    inicio + " - " + fin;

                int fila =
                    dgvHorarios.Rows.Add();

                dgvHorarios.Rows[fila]
                    .Cells[0].Value =
                    textoHorario;

                dgvHorarios.Rows[fila].Tag =
                    clave;

                filas[clave] = fila;
            }

            // -----------------------------------------
            // LLENAR ESTADO DE CADA CANCHA
            // -----------------------------------------

            foreach (DataRow registro in dt.Rows)
            {
                string inicio =
                    registro["HoraInicio"]
                    .ToString();

                string fin =
                    registro["HoraFin"]
                    .ToString();

                string claveHorario =
                    inicio + "|" + fin;

                int canchaID =
                    Convert.ToInt32(
                        registro["CanchaID"]);

                if (!filas.ContainsKey(
                    claveHorario))
                {
                    continue;
                }

                string nombreColumna =
                    "Cancha_" + canchaID;

                if (!dgvHorarios.Columns.Contains(
                    nombreColumna))
                {
                    continue;
                }

                int fila =
                    filas[claveHorario];

                int columna =
                    dgvHorarios.Columns[
                        nombreColumna].Index;

                string estado =
                    registro[
                        "EstadoHorario"]
                    .ToString();

                DataGridViewCell celda =
                    dgvHorarios.Rows[fila]
                    .Cells[columna];

                celda.Value = estado;

                celda.Style.Alignment =
                    DataGridViewContentAlignment
                    .MiddleCenter;

                // Disponible
                if (estado == "Disponible")
                {
                    celda.Style.BackColor =
                        Color.FromArgb(
                            190,
                            239,
                            190);

                    celda.Style.ForeColor =
                        Color.FromArgb(
                            45,
                            110,
                            45);
                }

                // Reservada
                else if (estado == "Reservada")
                {
                    celda.Style.BackColor =
                        Color.FromArgb(
                            245,
                            166,
                            130);

                    celda.Style.ForeColor =
                        Color.FromArgb(
                            130,
                            55,
                            25);
                }

                // Mantenimiento
                else
                {
                    celda.Style.BackColor =
                        Color.LightGray;

                    celda.Style.ForeColor =
                        Color.DimGray;
                }
            }

            dgvHorarios.ClearSelection();
        }

        // =================================================
        // CAMBIAR FECHA DESDE EL DATETIMEPICKER
        // =================================================

        private void dtpFecha_ValueChanged(
            object sender,
            EventArgs e)
        {
            if (cargandoFormulario)
                return;

            ActualizarPantalla();
        }

        // =================================================
        // FILTRAR CANCHA
        // =================================================

        private void cmbFiltroCancha_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            if (cargandoFormulario)
                return;

            if (cmbFiltroCancha.SelectedIndex >= 0)
            {
                CargarDisponibilidad();
            }
        }

        // =================================================
        // SIGUIENTE DÍA
        // =================================================

        private void btnSiguiente_Click(
            object sender,
            EventArgs e)
        {
            DateTime nuevaFecha =
                dtpFecha.Value.Date.AddDays(1);

            if (nuevaFecha <=
                dtpFecha.MaxDate.Date)
            {
                /*
                 * Al cambiar dtpFecha automáticamente
                 * se ejecuta dtpFecha_ValueChanged().
                 *
                 * Ese evento actualiza:
                 *
                 * lblMes
                 * lblFechaSeleccionada
                 * lblDia
                 * lblCanchasTotales
                 * lblCanchasDisponibles
                 * dgvHorarios
                 */
                dtpFecha.Value =
                    nuevaFecha;
            }
        }

        // =================================================
        // DÍA ANTERIOR
        // =================================================

        private void btnRetroceder_Click(
            object sender,
            EventArgs e)
        {
            DateTime nuevaFecha =
                dtpFecha.Value.Date.AddDays(-1);

            // Nunca permitir fechas anteriores a hoy.
            if (nuevaFecha < DateTime.Today)
                return;

            dtpFecha.Value =
                nuevaFecha;
        }

       

        private void guna2Panel1_Paint(
            object sender,
            PaintEventArgs e)
        {

        }

        private void dgvHorarios_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {

        }

        private void guna2Panel2_Paint(
            object sender,
            PaintEventArgs e)
        {

        }

        private void guna2CircleButton6_Click(
            object sender,
            EventArgs e)
        {

        }

        private void dgvHorarios_CellFormatting(
            object sender,
            DataGridViewCellFormattingEventArgs e)
        {

        }
    }
}