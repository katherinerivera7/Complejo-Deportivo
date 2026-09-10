using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login.GestionDeUsuarios
{
    public partial class frmVerFacturas : Form
    {
        csConectaSQL con=new csConectaSQL();
        string cadena;
        public frmVerFacturas()
        {
            InitializeComponent();
        }

        private void frmVerFacturas_Load(object sender, EventArgs e)
        {
            cadena = "SELECT F.FacturaID, F.ReservaID, F.NumeroFactura, F.FechaEmision,\r\nC.Nombre + ' ' + C.Apellido AS Cliente,\r\nC.TipoDocumento,\r\nC.Cedula AS Documento,\r\nCA.Tipo + ' - ' + CA.Nombre AS Cancha,\r\nCONVERT(VARCHAR(5), R.HoraInicio, 108) + ' - ' +\r\nCONVERT(VARCHAR(5), R.HoraFin, 108) AS Horario,\r\nF.Subtotal, F.Descuento, F.Total\r\nFROM Facturas F\r\nINNER JOIN Reservas R ON F.ReservaID = R.ReservaID\r\nINNER JOIN Clientes C ON R.ClienteID = C.ClienteID\r\nINNER JOIN Canchas CA ON R.CanchaID = CA.CanchaID\r\nORDER BY F.FacturaID DESC;";
            dgvFacturas.DataSource = con.retornaRegistros(cadena);
            dgvFacturas.Columns["FacturaID"].Visible = false;
            dgvFacturas.Columns["ReservaID"].Visible = false;

            dgvFacturas.Columns["NumeroFactura"].HeaderText = "N.º factura";
            dgvFacturas.Columns["FechaEmision"].HeaderText = "Fecha";
            dgvFacturas.Columns["TipoDocumento"].HeaderText = "Tipo";
            dgvFacturas.Columns["Documento"].HeaderText = "Documento";
            dgvFacturas.Columns["Descuento"].HeaderText = "Desc.";
        }
    }
}
