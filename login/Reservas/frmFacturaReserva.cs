using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login.Reservas
{
    public partial class frmFacturaReserva : Form
    {
        csConectaSQL conSQL = new csConectaSQL();

        int reservaID;
        string cancha;
        DateTime fechaReserva;
        string horario;
        int cantidadHoras;
        decimal precioHora;
        decimal descuento = 0;
        decimal subtotal;
        decimal iva;
        decimal total;
        public frmFacturaReserva()
        {
            InitializeComponent();
        }
        public frmFacturaReserva(int reservaID, string cliente, string tipoDocumento, string documento, string correo,
            string telefono, string direccion, string cancha, DateTime fechaReserva, string horario, int cantidadHoras, 
            decimal precioHora)
        {
            InitializeComponent();

            this.reservaID = reservaID;
            this.cancha = cancha;
            this.fechaReserva = fechaReserva;
            this.horario = horario;
            this.cantidadHoras = cantidadHoras;
            this.precioHora = precioHora;

            subtotal = precioHora * cantidadHoras;
            iva = subtotal * 0.15m;
            total = subtotal - descuento + iva;

            txtNumFactura.Text = "FAC-" + DateTime.Now.ToString("yyyyMMddHHmmss");
            txtCliente.Text = cliente;
            dtpFechaEmision.Value = DateTime.Today;

            if (cmbMetodoPago.Items.Count > 0)
                cmbMetodoPago.SelectedIndex = 0;

            dgvDetalleFactura.Rows.Clear();

            dgvDetalleFactura.Rows.Add(
                cancha,
                horario,
                cantidadHoras,
                precioHora,
                descuento,
                subtotal);
        }

        private void dgvDetalleFactura_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetalleFactura.ReadOnly = true;
            dgvDetalleFactura.AllowUserToAddRows = false;
            dgvDetalleFactura.AllowUserToDeleteRows = false;
            dgvDetalleFactura.AllowUserToResizeRows = false;
            dgvDetalleFactura.RowHeadersVisible = false;
        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            pnlContenido.Controls.Clear();
            UCNuevaReserva frm = new UCNuevaReserva();

            frm.Dock = DockStyle.Fill;

            pnlContenido.Controls.Clear();
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

            int facturaID = conSQL.insertarFactura(
                reservaID,
                numeroFactura,
                dtpFechaEmision.Value,
                metodoPago,
                subtotal,
                descuento,
                iva,
                total);

            if (facturaID <= 0)
            {
                MessageBox.Show("No se pudo guardar la factura. Verifique que el número no esté repetido.");
                return;
            }

            bool detalleGuardado = conSQL.insertarDetalleFactura(
                facturaID,
                "Alquiler de cancha",
                horario,
                cantidadHoras,
                precioHora,
                descuento,
                subtotal);

            if (!detalleGuardado)
            {
                MessageBox.Show("La factura se guardó, pero no se pudo guardar su detalle.");
                return;
            }

            MessageBox.Show("Factura guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
