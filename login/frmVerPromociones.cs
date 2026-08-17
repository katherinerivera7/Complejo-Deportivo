using login.Promciones;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace login
{
    public partial class frmVerPromociones : Form
    {
        string conexionString = @"Server=LAPTOP-J5U2QS20\SQLEXPRESS01;Database=ComplejoDeportivo;Integrated Security=True;TrustServerCertificate=True;";

        private bool configurandoFiltro = false;
        private bool busquedaAutomaticaAplicada = false;

        public frmVerPromociones()
        {
            InitializeComponent();

            dgvPromociones.AutoGenerateColumns = false;

            ConfigurarFiltro();
            CargarPromociones();
        }

        private void ConfigurarFiltro()
        {
            configurandoFiltro = true;

            cmbFiltro.Items.Clear();
            cmbFiltro.Items.Add("Todos");
            cmbFiltro.Items.Add("Nombres");
            cmbFiltro.Items.Add("Tipo");
            cmbFiltro.Items.Add("Descuento");
            cmbFiltro.Items.Add("Aplicar a");
            cmbFiltro.Items.Add("Fecha inicio");
            cmbFiltro.Items.Add("Fecha fin");
            cmbFiltro.Items.Add("Estado");
            cmbFiltro.SelectedIndex = 0;

            configurandoFiltro = false;
        }

        private void CargarPromociones()
        {
            string texto = txtFiltro.Text.Trim();
            string filtro = cmbFiltro.SelectedItem?.ToString() ?? "Todos";

            string consulta = @"SELECT PromocionID, Nombre, TipoPromocion, Descuento, AplicarA, FechaInicio, FechaFin,
                                CASE WHEN Estado = 1 THEN 'Activa' ELSE 'Inactiva' END AS Estado
                                FROM Promociones";

            if (!string.IsNullOrWhiteSpace(texto))
            {
                switch (filtro)
                {
                    case "Nombres":
                        consulta += " WHERE Nombre LIKE @Texto";
                        break;

                    case "Tipo":
                        consulta += " WHERE TipoPromocion LIKE @Texto";
                        break;

                    case "Descuento":
                        consulta += " WHERE CONVERT(VARCHAR(20), Descuento) LIKE @Texto";
                        break;

                    case "Aplicar a":
                        consulta += " WHERE AplicarA LIKE @Texto";
                        break;

                    case "Fecha inicio":
                        consulta += " WHERE CONVERT(VARCHAR(10), FechaInicio, 103) LIKE @Texto";
                        break;

                    case "Fecha fin":
                        consulta += " WHERE CONVERT(VARCHAR(10), FechaFin, 103) LIKE @Texto";
                        break;

                    case "Estado":
                        consulta += " WHERE CASE WHEN Estado = 1 THEN 'Activa' ELSE 'Inactiva' END LIKE @Texto";
                        break;

                    default:
                        consulta += @" WHERE CONCAT(
                                      Nombre, ' ',
                                      TipoPromocion, ' ',
                                      CONVERT(VARCHAR(20), Descuento), ' ',
                                      AplicarA, ' ',
                                      CONVERT(VARCHAR(10), FechaInicio, 103), ' ',
                                      CONVERT(VARCHAR(10), FechaFin, 103), ' ',
                                      CASE WHEN Estado = 1 THEN 'Activa' ELSE 'Inactiva' END
                                      ) LIKE @Texto";
                        break;
                }
            }

            consulta += " ORDER BY PromocionID DESC";

            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    if (!string.IsNullOrWhiteSpace(texto))
                    {
                        comando.Parameters.Add("@Texto", SqlDbType.VarChar, 150).Value = "%" + texto + "%";
                    }

                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);

                    dgvPromociones.DataSource = tabla;
                    dgvPromociones.ClearSelection();
                    dgvPromociones.CurrentCell = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las promociones:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarPromociones();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            int cantidadCaracteres = txtFiltro.Text.Trim().Length;

            if (cantidadCaracteres > 4)
            {
                busquedaAutomaticaAplicada = true;
                CargarPromociones();
            }
            else if (cantidadCaracteres == 0 || busquedaAutomaticaAplicada)
            {
                busquedaAutomaticaAplicada = false;
                CargarPromociones();
            }
        }

        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!configurandoFiltro && cmbFiltro.SelectedIndex >= 0)
            {
                CargarPromociones();
            }
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

            pnlContenidoo.Controls.Add(frm);
            pnlContenidoo.Tag = frm;
            frm.Show();
        }

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarPromociones();
                e.SuppressKeyPress = true;
            }
        }
    }
}