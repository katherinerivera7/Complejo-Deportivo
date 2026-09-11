using System;
using System.Data;
using System.Windows.Forms;

namespace login.GestionDeUsuarios
{
    public partial class frmVerFacturas : Form
    {
        csConectaSQL con = new csConectaSQL();
        string cadena;
        bool configurandoFiltro = false;

        public frmVerFacturas()
        {
            InitializeComponent();
            dgvFacturas.AutoGenerateColumns = true;
            dgvFacturas.RowHeadersVisible = false;

            btnBuscar.Click += btnBuscar_Click;
            txtFacturaID.KeyDown += txtFacturaID_KeyDown;
            cmbTipoFactura.SelectedIndexChanged += cmbTipoFactura_SelectedIndexChanged;
            txtFacturaID.TextChanged += txtFacturaID_TextChanged;

            ConfigurarFiltro();
        }

        private void frmVerFacturas_Load(object sender, EventArgs e)
        {
            CargarFacturas();
        }

        private void ConfigurarFiltro()
        {
            configurandoFiltro = true;

            cmbTipoFactura.Items.Clear();
            cmbTipoFactura.Items.Add("Reservas");
            cmbTipoFactura.Items.Add("Bar");
            cmbTipoFactura.SelectedIndex = 0;

            configurandoFiltro = false;
        }

        private void CargarFacturas()
        {
            string texto = txtFacturaID.Text.Trim().Replace("'", "''");
            string tipo = cmbTipoFactura.Text;

            if (tipo == "Bar")
            {
                cadena = @"
SELECT
    FV.FacturaID,
    FV.NumeroFactura,
    FV.Fecha AS FechaEmision,
    C.Nombre + ' ' + C.Apellido AS Cliente,
    C.TipoDocumento,
    C.Cedula AS Documento,
    'Bar' AS Detalle,
    'Venta de productos' AS Horario,
    FV.Subtotal,
    FV.Descuento,
    FV.Total
FROM FacturasVenta FV
INNER JOIN Clientes C
    ON FV.ClienteID = C.ClienteID";

                if (!string.IsNullOrWhiteSpace(texto))
                {
                    cadena += " WHERE CONVERT(VARCHAR(20), FV.FacturaID) LIKE '%" + texto + "%' " +
                               "OR FV.NumeroFactura LIKE '%" + texto + "%'";
                }

                cadena += " ORDER BY FV.FacturaID DESC";
            }
            else
            {
                cadena = @"
SELECT
    F.FacturaID,
    F.ReservaID,
    F.NumeroFactura,
    F.FechaEmision,
    C.Nombre + ' ' + C.Apellido AS Cliente,
    C.TipoDocumento,
    C.Cedula AS Documento,
    CA.Tipo + ' - ' + CA.Nombre AS Detalle,
    CONVERT(VARCHAR(5), R.HoraInicio, 108) + ' - ' +
    CONVERT(VARCHAR(5), R.HoraFin, 108) AS Horario,
    F.Subtotal,
    F.Descuento,
    F.Total
FROM Facturas F
INNER JOIN Reservas R
    ON F.ReservaID = R.ReservaID
INNER JOIN Clientes C
    ON R.ClienteID = C.ClienteID
INNER JOIN Canchas CA
    ON R.CanchaID = CA.CanchaID";

                if (!string.IsNullOrWhiteSpace(texto))
                {
                    cadena += " WHERE CONVERT(VARCHAR(20), F.FacturaID) LIKE '%" + texto + "%' " +
                               "OR F.NumeroFactura LIKE '%" + texto + "%'";
                }

                cadena += " ORDER BY F.FacturaID DESC";
            }

            DataTable tabla = con.retornaRegistros(cadena);
            dgvFacturas.DataSource = tabla;

            if (dgvFacturas.Columns.Contains("FacturaID"))
                dgvFacturas.Columns["FacturaID"].Visible = false;

            if (dgvFacturas.Columns.Contains("ReservaID"))
                dgvFacturas.Columns["ReservaID"].Visible = false;

            if (dgvFacturas.Columns.Contains("NumeroFactura"))
                dgvFacturas.Columns["NumeroFactura"].HeaderText = "N.º factura";

            if (dgvFacturas.Columns.Contains("FechaEmision"))
                dgvFacturas.Columns["FechaEmision"].HeaderText = "Fecha";

            if (dgvFacturas.Columns.Contains("TipoDocumento"))
                dgvFacturas.Columns["TipoDocumento"].HeaderText = "Tipo";

            if (dgvFacturas.Columns.Contains("Documento"))
                dgvFacturas.Columns["Documento"].HeaderText = "Documento";

            if (dgvFacturas.Columns.Contains("Detalle"))
                dgvFacturas.Columns["Detalle"].HeaderText = "Detalle";

            if (dgvFacturas.Columns.Contains("Descuento"))
                dgvFacturas.Columns["Descuento"].HeaderText = "Desc.";

            if (dgvFacturas.Columns.Contains("Subtotal"))
                dgvFacturas.Columns["Subtotal"].DefaultCellStyle.Format = "$#,##0.00";

            if (dgvFacturas.Columns.Contains("Descuento"))
                dgvFacturas.Columns["Descuento"].DefaultCellStyle.Format = "$#,##0.00";

            if (dgvFacturas.Columns.Contains("Total"))
                dgvFacturas.Columns["Total"].DefaultCellStyle.Format = "$#,##0.00";

            dgvFacturas.ClearSelection();
            dgvFacturas.CurrentCell = null;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarFacturas();
        }

        private void txtFacturaID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarFacturas();
                e.SuppressKeyPress = true;
            }
        }

        private void cmbTipoFactura_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!configurandoFiltro && cmbTipoFactura.SelectedIndex >= 0)
                CargarFacturas();
        }

        private void txtFacturaID_TextChanged(object sender, EventArgs e)
        {
            CargarFacturas();
        }
    }
}