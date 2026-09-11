using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace login.Reservas
{
    public partial class frmFacturaReserva : Form
    {
        csConectaSQL conSQL = new csConectaSQL();

        private UCNuevaReserva reservaOriginal;
        private Control contenedorOriginal;

        private bool incluyeArbitro;
        private decimal precioArbitro;
        private decimal subtotalCancha;

        private int clienteID;
        private int canchaID;
        private TimeSpan horaInicioReserva;
        private TimeSpan horaFinReserva;
        private string cancha;
        private DateTime fechaReserva;
        private string horario;
        private int cantidadHoras;
        private decimal precioHora;
        private decimal descuento;
        private decimal subtotal;
        private decimal iva;
        private decimal total;
        private int? promocionIDSeleccionada;
        private int facturaIDGuardada = 0;

        public frmFacturaReserva()
        {
            InitializeComponent();

            precioArbitro = 5.00m;

            ConfigurarDetalle();
            InicializarPromociones();
        }

        public frmFacturaReserva(
            int clienteID,
            int canchaID,
            string cliente,
            string tipoDocumento,
            string documento,
            string correo,
            string telefono,
            string direccion,
            string cancha,
            DateTime fechaReserva,
            TimeSpan horaInicioReserva,
            TimeSpan horaFinReserva,
            string horario,
            int cantidadHoras,
            decimal precioHora,
            string ciudad = "",
            UCNuevaReserva reservaOriginal = null,
            Control contenedorOriginal = null,
            bool incluyeArbitro = false,
            decimal precioArbitro = 5.00m)
        {
            InitializeComponent();

            ConfigurarDetalle();

            this.clienteID = clienteID;
            this.canchaID = canchaID;
            this.cancha = cancha;
            this.fechaReserva = fechaReserva;
            this.horaInicioReserva = horaInicioReserva;
            this.horaFinReserva = horaFinReserva;
            this.horario = horario;
            this.cantidadHoras = cantidadHoras;
            this.precioHora = precioHora;
            this.reservaOriginal = reservaOriginal;
            this.contenedorOriginal = contenedorOriginal;
            this.incluyeArbitro = incluyeArbitro;
            this.precioArbitro = precioArbitro;

            subtotalCancha = precioHora * cantidadHoras;

            decimal subtotalServicio =
                incluyeArbitro ? precioArbitro : 0m;

            subtotal = subtotalCancha + subtotalServicio;
            descuento = 0;
            iva = subtotal * 0.15m;
            total = subtotal - descuento + iva;

            txtNumFactura.Text =
                "FAC-" + DateTime.Now.ToString("yyyyMMddHHmmss");

            dtpFechaEmision.Value = DateTime.Today;
            dtpFechaEmision.Enabled = false;

            if (cmbMetodoPago.Items.Count > 0)
                cmbMetodoPago.SelectedIndex = 0;

            PonerTexto(cliente, "txtCliente");
            PonerTexto(
                tipoDocumento + " - " + documento,
                "txtDocumento",
                "txtCedula");

            PonerTexto(correo, "txtCorreo");
            PonerTexto(telefono, "txtTelefono");
            PonerTexto(direccion, "txtDireccion");
            PonerTexto(ciudad, "txtCiudad");

            dgvDetalleFactura.Rows.Clear();

            dgvDetalleFactura.Rows.Add(
                cancha,
                horario,
                cantidadHoras,
                precioHora,
                descuento,
                subtotalCancha);

            if (incluyeArbitro)
            {
                dgvDetalleFactura.Rows.Add(
                    "Servicio de árbitro",
                    horario,
                    1,
                    precioArbitro,
                    0m,
                    precioArbitro);
            }

            MostrarTotales();
            InicializarPromociones();
        }

        private void InicializarPromociones()
        {
            ActualizarPromocionesVencidas();

            cmbPromocion.SelectedIndexChanged -=
                cmbPromocion_SelectedIndexChanged;

            cmbPromocion.SelectedIndexChanged +=
                cmbPromocion_SelectedIndexChanged;

            CargarPromociones();
        }

        private void CargarPromociones()
        {
            DataTable dt = conSQL.retornaRegistros(
                "SELECT PromocionID, Nombre, Descuento, UnidadDescuento " +
                "FROM Promociones " +
                "WHERE Estado = 1 " +
                "AND CAST(GETDATE() AS date) BETWEEN FechaInicio AND FechaFin " +
                "ORDER BY Nombre");

            if (dt == null)
                return;

            DataRow fila = dt.NewRow();

            fila["PromocionID"] = 0;
            fila["Nombre"] = "Sin promoción";
            fila["Descuento"] = 0;
            fila["UnidadDescuento"] = "$";

            dt.Rows.InsertAt(fila, 0);

            cmbPromocion.DataSource = dt;
            cmbPromocion.DisplayMember = "Nombre";
            cmbPromocion.ValueMember = "PromocionID";
            cmbPromocion.SelectedIndex = 0;
        }

        private void cmbPromocion_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            DataRowView fila =
                cmbPromocion.SelectedItem as DataRowView;

            if (fila == null)
                return;

            int id =
                Convert.ToInt32(fila["PromocionID"]);

            if (id == 0)
            {
                promocionIDSeleccionada = null;
                descuento = 0;
            }
            else
            {
                promocionIDSeleccionada = id;

                decimal valorDescuento =
                    fila["Descuento"] == DBNull.Value
                        ? 0
                        : Convert.ToDecimal(fila["Descuento"]);

                string unidad =
                    fila["UnidadDescuento"] == DBNull.Value
                        ? "$"
                        : fila["UnidadDescuento"]
                            .ToString()
                            .Trim();

                if (unidad == "%")
                {
                    descuento =
                        subtotalCancha *
                        valorDescuento /
                        100m;
                }
                else
                {
                    descuento = valorDescuento;
                }

                if (descuento > subtotalCancha)
                    descuento = subtotalCancha;
            }

            iva =
                (subtotal - descuento) *
                0.15m;

            total =
                subtotal -
                descuento +
                iva;

            MostrarTotales();

            if (dgvDetalleFactura.Rows.Count > 0)
            {
                dgvDetalleFactura.Rows[0].Cells[4].Value =
                    descuento;

                dgvDetalleFactura.Rows[0].Cells[5].Value =
                    subtotalCancha;
            }
        }

        private void cmbPromocion_SelectedIndexChanged_1(
            object sender,
            EventArgs e)
        {
            cmbPromocion_SelectedIndexChanged(sender, e);
        }

        private void ActualizarPromocionesVencidas()
        {
            conSQL.retornaRegistros(
                "UPDATE Promociones " +
                "SET Estado = 0 " +
                "WHERE Estado = 1 " +
                "AND FechaFin < CAST(GETDATE() AS date)");
        }

        private void ConfigurarDetalle()
        {
            dgvDetalleFactura.ReadOnly = true;
            dgvDetalleFactura.AllowUserToAddRows = false;
            dgvDetalleFactura.AllowUserToDeleteRows = false;
            dgvDetalleFactura.AllowUserToResizeRows = false;
            dgvDetalleFactura.RowHeadersVisible = false;
            dgvDetalleFactura.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvDetalleFactura.Columns.Count >= 6)
            {
                dgvDetalleFactura.Columns[3]
                    .DefaultCellStyle.Format =
                    "$#,##0.00";

                dgvDetalleFactura.Columns[4]
                    .DefaultCellStyle.Format =
                    "$#,##0.00";

                dgvDetalleFactura.Columns[5]
                    .DefaultCellStyle.Format =
                    "$#,##0.00";
            }
        }

        private void PonerTexto(
            string texto,
            params string[] nombres)
        {
            foreach (string nombre in nombres)
            {
                Control[] controles =
                    Controls.Find(nombre, true);

                if (controles.Length > 0)
                {
                    controles[0].Text =
                        texto ?? "";

                    return;
                }
            }
        }

        private void MostrarTotales()
        {
            PonerTexto(
                subtotal.ToString("$#,##0.00"),
                "lblSubtotal",
                "lblSubTotal");

            PonerTexto(
                descuento.ToString("$#,##0.00"),
                "lblDescuento");

            PonerTexto(
                iva.ToString("$#,##0.00"),
                "lblIVA",
                "lblIva");

            PonerTexto(
                total.ToString("$#,##0.00"),
                "lblTotal");
        }

        private void dgvDetalleFactura_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            ConfigurarDetalle();
        }

        private void btnEditar_Click(
            object sender,
            EventArgs e)
        {
            Control contenedor =
                contenedorOriginal ?? Parent;

            if (contenedor == null)
            {
                MessageBox.Show(
                    "No se encontró el panel contenedor.");

                return;
            }

            UCNuevaReserva reserva =
                reservaOriginal ??
                contenedor.Tag as UCNuevaReserva;

            if (reserva == null)
            {
                MessageBox.Show(
                    "No se pudo recuperar la reserva.");

                return;
            }

            contenedor.Controls.Clear();

            reserva.Dock = DockStyle.Fill;

            contenedor.Controls.Add(reserva);
            contenedor.Tag = reserva;

            reserva.Show();
        }

        private void txtNombre_TextChanged(
            object sender,
            EventArgs e)
        {
        }

        private void txtNombre_KeyDown(
            object sender,
            KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpFechaEmision.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void guna2ComboBox2_KeyDown(
            object sender,
            KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCliente.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void btnFacturar_Click(
            object sender,
            EventArgs e)
        {
            if (facturaIDGuardada > 0)
            {
                MessageBox.Show(
                    "Esta factura ya fue guardada.");

                return;
            }

            string numeroFactura =
                txtNumFactura.Text.Trim();

            string metodoPago =
                cmbMetodoPago.Text.Trim();

            if (string.IsNullOrWhiteSpace(numeroFactura))
            {
                MessageBox.Show(
                    "Ingrese el número de factura.");

                return;
            }

            if (string.IsNullOrWhiteSpace(metodoPago))
            {
                MessageBox.Show(
                    "Seleccione el método de pago.");

                return;
            }

            int facturaID =
                conSQL.guardarReservaFactura(
                    clienteID,
                    canchaID,
                    fechaReserva,
                    horaInicioReserva,
                    horaFinReserva,
                    numeroFactura,
                    dtpFechaEmision.Value,
                    metodoPago,
                    promocionIDSeleccionada,
                    subtotal,
                    descuento,
                    iva,
                    total,
                    cancha,
                    horario,
                    cantidadHoras,
                    precioHora,
                    incluyeArbitro,
                    precioArbitro);

            if (facturaID == -1)
            {
                MessageBox.Show(
                    "La cancha está en mantenimiento o no está disponible.");

                return;
            }

            if (facturaID == -2)
            {
                MessageBox.Show(
                    "El horario seleccionado ya fue reservado.");

                return;
            }

            if (facturaID == -3)
            {
                MessageBox.Show(
                    "El número de factura ya existe.");

                return;
            }

            if (facturaID <= 0)
            {
                MessageBox.Show(
                    "No se pudo guardar la reserva y la factura.");

                return;
            }

            facturaIDGuardada =facturaID;

            MessageBox.Show(
                "Reserva y factura guardadas correctamente.",
                "Éxito",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            AbrirFormulario(new frmReservas());

        }
        private void AbrirFormulario(Form frm)
        {
            pnlContenido.Controls.Clear();

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            pnlContenido.Controls.Add(frm);
            pnlContenido.Tag = frm;

            frm.Show();
        }
    }
}