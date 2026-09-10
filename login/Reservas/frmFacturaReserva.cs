using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace login.Reservas
{
    public partial class frmFacturaReserva : Form
    {
        csConectaSQL conSQL = new csConectaSQL();

        int clienteID;
        int canchaID;
        TimeSpan horaInicioReserva;
        TimeSpan horaFinReserva;
        string cancha;
        DateTime fechaReserva;
        string horario;
        int cantidadHoras;
        decimal precioHora;
        decimal descuento;
        decimal subtotal;
        decimal iva;
        decimal total;
        int? promocionIDSeleccionada;
        int facturaIDGuardada = 0;

        public frmFacturaReserva()
        {
            InitializeComponent();
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
            string ciudad = "")
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

            subtotal = precioHora * cantidadHoras;
            descuento = 0;
            iva = subtotal * 0.15m;
            total = subtotal - descuento + iva;

            txtNumFactura.Text = "FAC-" + DateTime.Now.ToString("yyyyMMddHHmmss");
            dtpFechaEmision.Value = DateTime.Today;
            dtpFechaEmision.Enabled = false;

            if (cmbMetodoPago.Items.Count > 0)
                cmbMetodoPago.SelectedIndex = 0;

            PonerTexto(cliente, "txtCliente");
            PonerTexto(tipoDocumento + " - " + documento, "txtDocumento", "txtCedula");
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
                subtotal);

            MostrarTotales();
            InicializarPromociones();
        }

        private void InicializarPromociones()
        {
            ActualizarPromocionesVencidas();

            cmbPromocion.SelectedIndexChanged -= cmbPromocion_SelectedIndexChanged;
            cmbPromocion.SelectedIndexChanged += cmbPromocion_SelectedIndexChanged;

            CargarPromociones();
        }

        private void CargarPromociones()
        {
            DataTable dt = conSQL.retornaRegistros(
                "SELECT PromocionID, Nombre, Descuento, TipoPromocion " +
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
            fila["TipoPromocion"] = "";

            dt.Rows.InsertAt(fila, 0);

            cmbPromocion.DataSource = dt;
            cmbPromocion.DisplayMember = "Nombre";
            cmbPromocion.ValueMember = "PromocionID";
            cmbPromocion.SelectedIndex = 0;
        }

        private void cmbPromocion_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView fila = cmbPromocion.SelectedItem as DataRowView;

            if (fila == null)
                return;

            int id = Convert.ToInt32(fila["PromocionID"]);

            if (id == 0)
            {
                promocionIDSeleccionada = null;
                descuento = 0;
            }
            else
            {
                promocionIDSeleccionada = id;

                decimal valor = fila["Descuento"] == DBNull.Value
                    ? 0
                    : Convert.ToDecimal(fila["Descuento"]);

                string tipo = fila["TipoPromocion"] == DBNull.Value
                    ? ""
                    : fila["TipoPromocion"].ToString().ToLower();

                if (tipo.Contains("porcentaje") || tipo.Contains("%"))
                    descuento = subtotal * valor / 100m;
                else
                    descuento = valor;

                if (descuento > subtotal)
                    descuento = subtotal;
            }

            iva = (subtotal - descuento) * 0.15m;
            total = subtotal - descuento + iva;

            MostrarTotales();

            if (dgvDetalleFactura.Rows.Count > 0)
            {
                dgvDetalleFactura.Rows[0].Cells[4].Value = descuento;
                dgvDetalleFactura.Rows[0].Cells[5].Value = subtotal;
            }
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
            dgvDetalleFactura.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvDetalleFactura.Columns.Count >= 6)
            {
                dgvDetalleFactura.Columns[3].DefaultCellStyle.Format = "$#,##0.00";
                dgvDetalleFactura.Columns[4].DefaultCellStyle.Format = "$#,##0.00";
                dgvDetalleFactura.Columns[5].DefaultCellStyle.Format = "$#,##0.00";
            }
        }

        private void PonerTexto(string texto, params string[] nombres)
        {
            foreach (string nombre in nombres)
            {
                Control[] controles = Controls.Find(nombre, true);

                if (controles.Length > 0)
                {
                    controles[0].Text = texto ?? "";
                    return;
                }
            }
        }

        private void MostrarTotales()
        {
            PonerTexto(subtotal.ToString("$#,##0.00"), "lblSubtotal", "lblSubTotal");
            PonerTexto(descuento.ToString("$#,##0.00"), "lblDescuento");
            PonerTexto(iva.ToString("$#,##0.00"), "lblIVA", "lblIva");
            PonerTexto(total.ToString("$#,##0.00"), "lblTotal");
        }

        private void dgvDetalleFactura_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ConfigurarDetalle();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            pnlContenido.Controls.Clear();

            UCNuevaReserva frm = new UCNuevaReserva();
            frm.Dock = DockStyle.Fill;

            pnlContenido.Controls.Add(frm);
            pnlContenido.Tag = frm;

            frm.Show();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpFechaEmision.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void guna2ComboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCliente.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            if (facturaIDGuardada > 0)
            {
                MessageBox.Show("Esta factura ya fue guardada.");
                return;
            }

            string numeroFactura = txtNumFactura.Text.Trim();
            string metodoPago = cmbMetodoPago.Text.Trim();

            if (string.IsNullOrWhiteSpace(numeroFactura))
            {
                MessageBox.Show("Ingrese el número de factura.");
                return;
            }

            if (string.IsNullOrWhiteSpace(metodoPago))
            {
                MessageBox.Show("Seleccione el método de pago.");
                return;
            }

            int facturaID = conSQL.guardarReservaFactura(
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
                precioHora);

            if (facturaID == -1)
            {
                MessageBox.Show("La cancha está en mantenimiento o no está disponible.");
                return;
            }

            if (facturaID == -2)
            {
                MessageBox.Show("El horario seleccionado ya fue reservado.");
                return;
            }

            if (facturaID == -3)
            {
                MessageBox.Show("El número de factura ya existe.");
                return;
            }

            if (facturaID <= 0)
            {
                MessageBox.Show("No se pudo guardar la reserva y la factura.");
                return;
            }

            facturaIDGuardada = facturaID;

            MessageBox.Show(
                "Reserva y factura guardadas correctamente.",
                "Éxito",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}