using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace login.Bar
{
    public partial class frmFacturaVenta : Form
    {
        private List<DetalleVenta> detallesVenta;
        private csConectaSQL oCon = new csConectaSQL();

        private decimal porcentajeIVA = 15;
        private int clienteID = 0;

        public frmFacturaVenta()
        {
            InitializeComponent();
            detallesVenta = new List<DetalleVenta>();

            txtCedula.TextChanged += txtCedula_TextChanged;
            txtDescuento.TextChanged += txtDescuento_TextChanged;
        }

        public frmFacturaVenta(List<DetalleVenta> detalles)
        {
            InitializeComponent();

            detallesVenta = detalles;

            txtCedula.TextChanged += txtCedula_TextChanged;
            txtDescuento.TextChanged += txtDescuento_TextChanged;

            CargarDetalleFactura();
        }

        private void frmFacturaVenta_Load(object sender, EventArgs e)
        {
            CargarDetalleFactura();
        }

        private void CargarDetalleFactura()
        {
            dgvDetalleFactura.Rows.Clear();

            decimal porcentajeDescuento = 0;

            if (!string.IsNullOrWhiteSpace(txtDescuento.Text))
            {
                decimal.TryParse(txtDescuento.Text, out porcentajeDescuento);
            }

            decimal subtotalFactura = 0;
            decimal descuentoFactura = 0;
            decimal ivaFactura = 0;
            decimal totalFactura = 0;

            if (detallesVenta != null)
            {
                foreach (DetalleVenta detalle in detallesVenta)
                {
                    decimal subtotal = detalle.Cantidad * detalle.PrecioUnitario;

                    decimal descuento =
                        subtotal * porcentajeDescuento / 100;

                    decimal subtotalConDescuento =
                        subtotal - descuento;

                    decimal iva =
                        subtotalConDescuento * porcentajeIVA / 100;

                    decimal total =
                        subtotalConDescuento + iva;

                    dgvDetalleFactura.Rows.Add(
                        detalle.Producto,
                        detalle.Cantidad,
                        "$ " + detalle.PrecioUnitario.ToString("0.00"),
                        "$ " + descuento.ToString("0.00"),
                        "$ " + iva.ToString("0.00"),
                        "$ " + subtotal.ToString("0.00"),
                        "$ " + total.ToString("0.00")
                    );

                    subtotalFactura += subtotal;
                    descuentoFactura += descuento;
                    ivaFactura += iva;
                    totalFactura += total;
                }
            }

            lblSubtotal.Text = "$" + subtotalFactura.ToString("0.00");
            lblDescuento.Text = "$" + descuentoFactura.ToString("0.00");
            lblIva.Text = "$" + ivaFactura.ToString("0.00");
            lblTotal.Text = "$" + totalFactura.ToString("0.00");
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            CargarDetalleFactura();
        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {
            BuscarCliente();
        }

        private void BuscarCliente()
        {
            string cedula = txtCedula.Text.Trim();

            clienteID = 0;

            if (string.IsNullOrWhiteSpace(cedula))
            {
                LimpiarCliente();
                return;
            }

            if (cedula.Length < 10)
            {
                LimpiarCliente();
                return;
            }

            try
            {
                string cedulaSegura = cedula.Replace("'", "''");

                string consulta =
                    "SELECT TOP 1 ClienteID, Cedula, Nombre, Apellido, Correo, Telefono, Ciudad, Direccion " +
                    "FROM Clientes " +
                    "WHERE CAST(Cedula AS VARCHAR(20)) = '" + cedulaSegura + "'";

                DataTable dtCliente = oCon.retornaRegistros(consulta);

                if (dtCliente.Rows.Count > 0)
                {
                    DataRow fila = dtCliente.Rows[0];

                    clienteID = Convert.ToInt32(fila["ClienteID"]);

                    txtCliente.Text =
                        fila["Nombre"].ToString() + " " +
                        fila["Apellido"].ToString();

                    txtCorreo.Text = fila["Correo"].ToString();
                    txtTelefono.Text = fila["Telefono"].ToString();
                    txtCiudad.Text = fila["Ciudad"].ToString();
                    txtDireccion.Text = fila["Direccion"].ToString();
                }
                else
                {
                    LimpiarCliente();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al buscar el cliente:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void LimpiarCliente()
        {
            clienteID = 0;

            txtCliente.Clear();
            txtCorreo.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtCiudad.Clear();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Control pnlContenido = this.Parent;

            if (pnlContenido == null)
                return;

            frmRegistroVenta frm = new frmRegistroVenta();

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            pnlContenido.Controls.Clear();
            pnlContenido.Controls.Add(frm);
            pnlContenido.Tag = frm;

            frm.Show();
        }
    }
}