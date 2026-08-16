using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login.Bar
{
    public partial class frmHistorialMovimientos : Form
    {
        csConectaSQL conSQL = new csConectaSQL();
        public frmHistorialMovimientos()
        {
            InitializeComponent();
            dgvMovimientos.AutoGenerateColumns = false;
            dgvMovimientos.Columns["colMovimientoID"].DataPropertyName = "MovimientoID";
            dgvMovimientos.Columns["colProducto"].DataPropertyName = "Producto";
            dgvMovimientos.Columns["colUsuario"].DataPropertyName = "Usuario";
            dgvMovimientos.Columns["colTipoMovimiento"].DataPropertyName = "TipoMovimiento";
            dgvMovimientos.Columns["colCantidad"].DataPropertyName = "Cantidad";
            dgvMovimientos.Columns["colFechaMovimiento"].DataPropertyName = "FechaMovimiento";
            dgvMovimientos.Columns["colMotivo"].DataPropertyName = "Motivo";
        }

        private void pnlContenidoo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmHistorialMovimientos_Load(object sender, EventArgs e)
        {
            CargarMovimientos();
        }
        private void CargarMovimientos()
        {
            string consulta = @"SELECT m.MovimientoID, p.Nombre AS Producto, u.NombreUsuario AS Usuario, m.TipoMovimiento, m.Cantidad, m.FechaMovimiento, m.Motivo FROM MovimientosInventario m INNER JOIN Productos p ON m.ProductoID = p.ProductoID LEFT JOIN Usuarios u ON m.UsuarioID = u.UsuarioID ORDER BY m.MovimientoID DESC";

            dgvMovimientos.DataSource = conSQL.retornaRegistros(consulta);
            dgvMovimientos.ClearSelection();
            dgvMovimientos.CurrentCell = null;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            pnlContenidoo.Controls.Clear();
            frmInventarioBar frm = new frmInventarioBar();

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            pnlContenidoo.Controls.Clear();
            pnlContenidoo.Controls.Add(frm);
            pnlContenidoo.Tag = frm;

            frm.Show();
        }
    }
}

