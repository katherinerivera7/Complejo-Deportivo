using FontAwesome.Sharp;
using login.GestionDeUsuarios;
using System;
using System.Data;
using System.Windows.Forms;

namespace login.Reservas
{
    public partial class UCNuevaReserva : UserControl
    {
        csConectaSQL conSQL = new csConectaSQL();

        private int clienteID = 0;
        private int reservaIDEditar = 0;
        private string ciudadCliente = "";
        private bool incluyeArbitro = false;
        private decimal precioArbitro = 5.00m;

        public UCNuevaReserva()
        {
            InitializeComponent();

            dtpFecha.MinDate = DateTime.Today;
            dtpFecha.Value = DateTime.Today;

            nudCantidadHoras.Minimum = 1;
            nudCantidadHoras.Maximum = 8;
            nudCantidadHoras.Value = 1;

            nudCantidadHoras.ValueChanged -= nudCantidadHoras_ValueChanged;
            nudCantidadHoras.ValueChanged += nudCantidadHoras_ValueChanged;
        }

        public UCNuevaReserva(int reservaID) : this()
        {
            reservaIDEditar = reservaID;
        }

        private void UCNuevaReserva_Load(object sender, EventArgs e)
        {
            DataTable dt = conSQL.retornaRegistros(
                "SELECT DISTINCT Tipo FROM Canchas ORDER BY Tipo");

            cmbDeporte.DataSource = dt;
            cmbDeporte.DisplayMember = "Tipo";
            cmbDeporte.ValueMember = "Tipo";
            cmbDeporte.SelectedIndex = -1;

            lblFecha.Text = dtpFecha.Value.ToString("dd/MM/yyyy");
            lblCancha.Text = "---";
            lblHorario.Text = "---";
            lblServiciosAdicionales.Text = "Ninguno";

            if (reservaIDEditar > 0)
            {
                btnFacturar.Text = "Guardar cambios";
                CargarReservaEditar();
            }
        }

        private void CargarReservaEditar()
        {
            string consulta =
                "SELECT R.ReservaID, R.ClienteID, R.CanchaID, R.Fecha, " +
                "R.HoraInicio, R.HoraFin, CA.Tipo, " +
                "CA.Tipo + ' - ' + CA.Nombre AS Cancha, " +
                "CL.TipoDocumento, CL.Cedula, CL.Nombre, CL.Apellido, " +
                "CL.Correo, CL.Telefono, CL.Direccion, CL.Ciudad " +
                "FROM Reservas R " +
                "INNER JOIN Canchas CA ON R.CanchaID = CA.CanchaID " +
                "INNER JOIN Clientes CL ON R.ClienteID = CL.ClienteID " +
                "WHERE R.ReservaID = " + reservaIDEditar;

            DataTable tabla = conSQL.retornaRegistros(consulta);

            if (tabla == null || tabla.Rows.Count == 0)
                return;

            DataRow fila = tabla.Rows[0];

            clienteID = Convert.ToInt32(fila["ClienteID"]);
            ciudadCliente = fila["Ciudad"].ToString();

            txtCodigo.Text = fila["ClienteID"].ToString();
            txtTipoDocumento.Text = fila["TipoDocumento"].ToString();
            txtCedula.Text = fila["Cedula"].ToString();
            txtNombres.Text = fila["Nombre"].ToString();
            txtApellidos.Text = fila["Apellido"].ToString();
            txtCorreo.Text = fila["Correo"].ToString();
            txtTelefono.Text = fila["Telefono"].ToString();
            txtDireccion.Text = fila["Direccion"].ToString();

            lblCliente.Text =
                fila["Nombre"] + " " +
                fila["Apellido"];

            dtpFecha.Value = Convert.ToDateTime(fila["Fecha"]);

            TimeSpan horaInicio = ConvertirHora(fila["HoraInicio"]);
            TimeSpan horaFin = ConvertirHora(fila["HoraFin"]);

            int cantidadHoras =
                Convert.ToInt32((horaFin - horaInicio).TotalHours);

            if (cantidadHoras < 1)
                cantidadHoras = 1;

            if (cantidadHoras > 8)
                cantidadHoras = 8;

            nudCantidadHoras.Value = cantidadHoras;

            cmbDeporte.SelectedValue = fila["Tipo"].ToString();

            if (cmbCancha.DataSource != null)
            {
                cmbCancha.SelectedValue =
                    Convert.ToInt32(fila["CanchaID"]);
            }

            lblCancha.Text = fila["Cancha"].ToString();

            CargarHorariosDisponibles();

            for (int i = 0; i < cmbHorario.Items.Count; i++)
            {
                DataRowView filaHorario =
                    cmbHorario.Items[i] as DataRowView;

                if (filaHorario == null)
                    continue;

                TimeSpan horaInicioHorario =
                    ConvertirHora(filaHorario["HoraInicio"]);

                if (horaInicioHorario == horaInicio)
                {
                    cmbHorario.SelectedIndex = i;
                    break;
                }
            }
        }

        private TimeSpan ConvertirHora(object valor)
        {
            if (valor is TimeSpan)
                return (TimeSpan)valor;

            return TimeSpan.Parse(valor.ToString());
        }

        private void cmbDeporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCancha.DataSource = null;
            cmbCancha.Items.Clear();
            cmbCancha.Enabled = true;

            cmbHorario.DataSource = null;
            cmbHorario.Items.Clear();
            cmbHorario.Enabled = true;

            lblCancha.Text = "---";
            lblHorario.Text = "---";

            if (cmbDeporte.SelectedIndex == -1)
                return;

            string deporte =
                cmbDeporte.Text.Trim().Replace("'", "''");

            string consulta =
                "SELECT CanchaID, Tipo + ' - ' + Nombre AS Cancha " +
                "FROM Canchas " +
                "WHERE Tipo = '" + deporte + "' " +
                "AND UPPER(LTRIM(RTRIM(Estado))) NOT LIKE 'MANTENIMIENTO%' " +
                "AND UPPER(LTRIM(RTRIM(Estado))) NOT IN " +
                "('INACTIVA', 'CERRADA') " +
                "ORDER BY Nombre";

            DataTable dt = conSQL.retornaRegistros(consulta);

            if (dt == null || dt.Rows.Count == 0)
            {
                cmbCancha.Items.Add("No hay canchas disponibles");
                cmbCancha.Enabled = false;
                cmbCancha.SelectedIndex = 0;

                cmbHorario.Items.Add("No hay horarios disponibles");
                cmbHorario.Enabled = false;
                cmbHorario.SelectedIndex = 0;

                lblCancha.Text = "No disponible";
                lblHorario.Text = "No hay horarios disponibles";
                return;
            }

            cmbCancha.DataSource = dt;
            cmbCancha.DisplayMember = "Cancha";
            cmbCancha.ValueMember = "CanchaID";
            cmbCancha.SelectedIndex = 0;
        }

        private void cmbCancha_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView filaCancha =
                cmbCancha.SelectedItem as DataRowView;

            if (filaCancha == null || !cmbCancha.Enabled)
                return;

            lblCancha.Text =
                filaCancha["Cancha"].ToString();

            CargarHorariosDisponibles();
        }

        private void CargarHorariosDisponibles()
        {
            lblHorario.Text = "---";

            cmbHorario.DataSource = null;
            cmbHorario.Items.Clear();
            cmbHorario.Enabled = true;

            DataRowView filaCancha =
                cmbCancha.SelectedItem as DataRowView;

            if (filaCancha == null || !cmbCancha.Enabled)
                return;

            int canchaID =
                Convert.ToInt32(filaCancha["CanchaID"]);

            int cantidadHoras =
                Convert.ToInt32(nudCantidadHoras.Value);

            string fecha =
                dtpFecha.Value.ToString("yyyyMMdd");

            string excluirReserva = "";

            if (reservaIDEditar > 0)
            {
                excluirReserva =
                    "AND R.ReservaID <> " + reservaIDEditar + " ";
            }

            string finHorario =
                "CONVERT(TIME, DATEADD(HOUR, " +
                cantidadHoras +
                ", CAST(H.HoraInicio AS DATETIME)))";

            string consulta =
                "SELECT H.HorarioID, " +
                "CONVERT(VARCHAR(5), H.HoraInicio, 108) + ' - ' + " +
                "CONVERT(VARCHAR(5), " + finHorario + ", 108) AS Horario, " +
                "H.HoraInicio, " + finHorario + " AS HoraFin " +
                "FROM Horarios H " +
                "WHERE " + finHorario + " > H.HoraInicio " +
                "AND " +
                "(SELECT COUNT(*) FROM Horarios H2 " +
                "WHERE H2.HoraInicio >= H.HoraInicio " +
                "AND H2.HoraInicio < " + finHorario + ") = " +
                cantidadHoras + " " +
                "AND EXISTS " +
                "(SELECT 1 FROM Canchas C " +
                "WHERE C.CanchaID = " + canchaID + " " +
                "AND UPPER(LTRIM(RTRIM(C.Estado))) " +
                "NOT LIKE 'MANTENIMIENTO%' " +
                "AND UPPER(LTRIM(RTRIM(C.Estado))) " +
                "NOT IN ('INACTIVA', 'CERRADA')) " +
                "AND NOT EXISTS " +
                "(SELECT 1 FROM Reservas R " +
                "WHERE R.CanchaID = " + canchaID + " " +
                "AND CONVERT(DATE, R.Fecha) = " +
                "CONVERT(DATE, '" + fecha + "', 112) " +
                excluirReserva +
                "AND UPPER(LTRIM(RTRIM(ISNULL(R.Estado, '')))) " +
                "<> 'CANCELADA' " +
                "AND R.HoraInicio < " + finHorario + " " +
                "AND R.HoraFin > H.HoraInicio) " +
                "ORDER BY H.HoraInicio";

            DataTable tabla =
                conSQL.retornaRegistros(consulta);

            if (tabla == null || tabla.Rows.Count == 0)
            {
                cmbHorario.Items.Add("No hay horarios disponibles");
                cmbHorario.SelectedIndex = 0;
                cmbHorario.Enabled = false;
                lblHorario.Text = "No hay horarios disponibles";
                return;
            }

            cmbHorario.DataSource = tabla;
            cmbHorario.DisplayMember = "Horario";
            cmbHorario.ValueMember = "HorarioID";
            cmbHorario.SelectedIndex = -1;
        }

        private void cmbHorario_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView filaHorario =
                cmbHorario.SelectedItem as DataRowView;

            if (filaHorario == null || !cmbHorario.Enabled)
                return;

            TimeSpan horaInicio =
                ConvertirHora(filaHorario["HoraInicio"]);

            TimeSpan horaFin =
                ConvertirHora(filaHorario["HoraFin"]);

            lblHorario.Text =
                horaInicio.ToString(@"hh\:mm") +
                " - " +
                horaFin.ToString(@"hh\:mm");
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            lblFecha.Text =
                dtpFecha.Value.ToString("dd/MM/yyyy");

            CargarHorariosDisponibles();
        }

        private void nudCantidadHoras_ValueChanged(
            object sender,
            EventArgs e)
        {
            CargarHorariosDisponibles();
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            if (clienteID <= 0)
            {
                MessageBox.Show("Seleccione un cliente.");
                return;
            }

            DataRowView filaCancha =
                cmbCancha.SelectedItem as DataRowView;

            DataRowView filaHorario =
                cmbHorario.SelectedItem as DataRowView;

            if (filaCancha == null || !cmbCancha.Enabled)
            {
                MessageBox.Show("Seleccione una cancha disponible.");
                return;
            }

            if (filaHorario == null || !cmbHorario.Enabled)
            {
                MessageBox.Show("Seleccione un horario disponible.");
                return;
            }

            int canchaID =
                Convert.ToInt32(filaCancha["CanchaID"]);

            int cantidadHoras =
                Convert.ToInt32(nudCantidadHoras.Value);

            TimeSpan horaInicio =
                ConvertirHora(filaHorario["HoraInicio"]);

            TimeSpan horaFin =
                ConvertirHora(filaHorario["HoraFin"]);

            string horario =
                filaHorario["Horario"].ToString();

            string cancha =
                filaCancha["Cancha"].ToString();

            DataTable tablaPrecio =
                conSQL.retornaRegistros(
                    "SELECT PrecioHora FROM Canchas " +
                    "WHERE CanchaID = " + canchaID);

            if (tablaPrecio == null || tablaPrecio.Rows.Count == 0)
            {
                MessageBox.Show(
                    "No se pudo obtener el precio de la cancha.");
                return;
            }

            decimal precioHora =
                Convert.ToDecimal(
                    tablaPrecio.Rows[0]["PrecioHora"]);

            if (reservaIDEditar > 0)
            {
                int resultado =
                    conSQL.actualizarReservaFactura(
                        reservaIDEditar,
                        clienteID,
                        canchaID,
                        dtpFecha.Value.Date,
                        horaInicio,
                        horaFin,
                        cancha,
                        horario,
                        cantidadHoras,
                        precioHora,
                        incluyeArbitro ? precioArbitro : 0m);

                if (resultado == -1)
                {
                    MessageBox.Show(
                        "La cancha está en mantenimiento.");
                    return;
                }

                if (resultado == -2)
                {
                    MessageBox.Show(
                        "El horario ya está ocupado.");
                    return;
                }

                if (resultado == 1)
                {
                    MessageBox.Show(
                        "Reserva actualizada correctamente.",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                        "No se pudo actualizar la reserva.");
                }

                return;
            }

            Control contenedorOriginal = Parent;

            if (contenedorOriginal == null)
            {
                MessageBox.Show(
                    "No se encontró el panel contenedor.");
                return;
            }

            contenedorOriginal.Tag = this;

            frmFacturaReserva frm =
                new frmFacturaReserva(
                    clienteID,
                    canchaID,
                    txtNombres.Text.Trim() + " " +
                    txtApellidos.Text.Trim(),
                    txtTipoDocumento.Text.Trim(),
                    txtCedula.Text.Trim(),
                    txtCorreo.Text.Trim(),
                    txtTelefono.Text.Trim(),
                    txtDireccion.Text.Trim(),
                    cancha,
                    dtpFecha.Value.Date,
                    horaInicio,
                    horaFin,
                    horario,
                    cantidadHoras,
                    precioHora,
                    ciudadCliente,
                    this,
                    contenedorOriginal,
                    chkArbitro.Checked,
                    5.00m);

            contenedorOriginal.Controls.Clear();

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            contenedorOriginal.Controls.Add(frm);
            frm.Show();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro de que desea cancelar la reserva?",
                "Cancelar reserva",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
        }

        private void pnlContenido_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnEncontrarCliente_Click(object sender, EventArgs e)
        {
            frmEncontrarCliente frmC =
                new frmEncontrarCliente();

            frmC.StartPosition =
                FormStartPosition.CenterScreen;

            frmC.ShowDialog();

            if (frmC.DialogResult == DialogResult.OK)
            {
                clienteID =
                    Convert.ToInt32(frmC.ClienteID);

                ciudadCliente =
                    frmC.Ciudad;

                txtTipoDocumento.Text =
                    frmC.TipoDocumento;

                txtTelefono.Text =
                    frmC.Telefono;

                txtNombres.Text =
                    frmC.Nombre;

                txtDireccion.Text =
                    frmC.Direccion;

                txtCorreo.Text =
                    frmC.Correo;

                txtCodigo.Text =
                    frmC.ClienteID;

                txtCedula.Text =
                    frmC.Cedula;

                txtApellidos.Text =
                    frmC.Apellido;

                lblCliente.Text =
                    frmC.Nombre + " " +
                    frmC.Apellido;
            }
        }

        private void chkArbitro_CheckedChanged(
            object sender,
            EventArgs e)
        {
            incluyeArbitro = chkArbitro.Checked;

            lblServiciosAdicionales.Text =
                incluyeArbitro ? "Árbitro" : "Ninguno";
        }
    }
}