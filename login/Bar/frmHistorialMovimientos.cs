using System;
using System.Data;
using System.Drawing;
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
            dgvMovimientos.RowHeadersVisible = false;
            dgvMovimientos.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvMovimientos.Columns["colMovimientoID"].DataPropertyName =
                "MovimientoID";

            dgvMovimientos.Columns["colProducto"].DataPropertyName =
                "Producto";

            dgvMovimientos.Columns["colUsuario"].DataPropertyName =
                "Usuario";

            if (!dgvMovimientos.Columns.Contains("colCargo"))
            {
                DataGridViewTextBoxColumn columnaCargo =
                    new DataGridViewTextBoxColumn();

                columnaCargo.Name = "colCargo";
                columnaCargo.HeaderText = "Cargo";
                columnaCargo.DataPropertyName = "Cargo";

                int posicionUsuario =
                    dgvMovimientos.Columns["colUsuario"].Index;

                dgvMovimientos.Columns.Insert(
                    posicionUsuario + 1,
                    columnaCargo);
            }
            else
            {
                dgvMovimientos.Columns["colCargo"].DataPropertyName =
                    "Cargo";
            }

            dgvMovimientos.Columns["colTipoMovimiento"].DataPropertyName =
                "TipoMovimiento";

            dgvMovimientos.Columns["colCantidad"].DataPropertyName =
                "Cantidad";

            dgvMovimientos.Columns["colFechaMovimiento"].DataPropertyName =
                "FechaMovimiento";

            dgvMovimientos.Columns["colMotivo"].DataPropertyName =
                "Motivo";

            dgvMovimientos.Columns["colMovimientoID"].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.None;

            dgvMovimientos.Columns["colMovimientoID"].Width = 60;
        }

        private void pnlContenidoo_Paint(
            object sender,
            PaintEventArgs e)
        {
        }

        private void frmHistorialMovimientos_Load(
            object sender,
            EventArgs e)
        {
            CargarMovimientos();
        }

        private void CargarMovimientos()
        {
            string consulta =
    @"SELECT 
        m.MovimientoID,
        p.Nombre AS Producto,
        u.NombreUsuario AS Usuario,
        u.Cargo AS Cargo,
        m.TipoMovimiento,
        m.Cantidad,
        m.FechaMovimiento,
        m.Motivo
      FROM MovimientosInventario m
      INNER JOIN Productos p
        ON m.ProductoID = p.ProductoID
      INNER JOIN Usuarios u
        ON m.UsuarioID = u.UsuarioID
      ORDER BY m.MovimientoID DESC";

            dgvMovimientos.DataSource =
                conSQL.retornaRegistros(consulta);

            dgvMovimientos.ClearSelection();
            dgvMovimientos.CurrentCell = null;
        }

        private void guna2Button1_Click(
            object sender,
            EventArgs e)
        {
            pnlContenidoo.Controls.Clear();

            frmInventarioBar frm =
                new frmInventarioBar();

            frm.TopLevel = false;
            frm.FormBorderStyle =
                FormBorderStyle.None;

            frm.Dock =
                DockStyle.Fill;

            pnlContenidoo.Controls.Add(frm);
            pnlContenidoo.Tag = frm;

            frm.Show();
        }
    }
}