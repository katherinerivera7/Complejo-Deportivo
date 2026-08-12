using login.Bar;
using login.Promciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login
{
    public partial class frmVerPromociones : Form
    {
        string conexionString = @"Server=LAPTOP-J5U2QS20\SQLEXPRESS01;Database=ComplejoDeportivo;Integrated Security=True;TrustServerCertificate=True;";
        public frmVerPromociones()
        {
            InitializeComponent();
            CargarPromociones();
            dgvPromociones.AutoGenerateColumns = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            pnlContenidoo.Controls.Clear();
            frmCrearPromocion frm = new frmCrearPromocion();
            frm.lblTitulo.Text = "Editar Promoción";
            frm.lblSubtitulo.Text = "Modifica la información de la promoción para tus clientes";
            frm.btnGuardar.Text = "Guardar cambios";
            frm.btnCancelar.FocusedColor = Color.FromArgb(9, 128, 0);
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            pnlContenidoo.Controls.Clear();
            pnlContenidoo.Controls.Add(frm);
            pnlContenidoo.Tag = frm;

            frm.Show();
        }
        private void CargarPromociones()
        {
            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                string consulta = @"
    SELECT
        PromocionID,
        Nombre,
        TipoPromocion,
        Descuento,
        AplicarA,
        FechaInicio,
        FechaFin,
        CASE
            WHEN Estado = 1 THEN 'Activa'
            ELSE 'Inactiva'
        END AS Estado
    FROM Promociones
    ORDER BY PromocionID DESC";

                SqlDataAdapter da = new SqlDataAdapter(consulta, conexion);

                DataTable dt = new DataTable();

                da.Fill(dt);

                dgvPromociones.DataSource = dt;
                dgvPromociones.ClearSelection();
            }
        }
    }
}
