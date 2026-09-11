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
            ActualizarPromocionesVencidas();
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

        private void ActualizarPromocionesVencidas()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                using (SqlCommand cmd = new SqlCommand(
                    "UPDATE Promociones " +
                    "SET Estado = 0 " +
                    "WHERE Estado = 1 " +
                    "AND FechaFin < CAST(GETDATE() AS date)",
                    conexion))
                {
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron actualizar las promociones vencidas:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CargarPromociones()
        {
            string texto = txtFiltro.Text.Trim();
            string filtro = cmbFiltro.SelectedItem?.ToString() ?? "Todos";

            string consulta = @"SELECT
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
                        consulta += @" WHERE
                            CASE
                                WHEN Estado = 1 THEN 'Activa'
                                ELSE 'Inactiva'
                            END LIKE @Texto";
                        break;

                    default:
                        consulta += @" WHERE CONCAT(
                            Nombre, ' ',
                            TipoPromocion, ' ',
                            CONVERT(VARCHAR(20), Descuento), ' ',
                            AplicarA, ' ',
                            CONVERT(VARCHAR(10), FechaInicio, 103), ' ',
                            CONVERT(VARCHAR(10), FechaFin, 103), ' ',
                            CASE
                                WHEN Estado = 1 THEN 'Activa'
                                ELSE 'Inactiva'
                            END
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
                        comando.Parameters.Add("@Texto", SqlDbType.VarChar, 150).Value =
                            "%" + texto + "%";
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
                MessageBox.Show(
                    "Error al cargar las promociones:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private bool ObtenerPromocionSeleccionada(out int promocionID)
        {
            promocionID = 0;

            if (dgvPromociones.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccione una promoción.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            DataRowView fila = dgvPromociones.CurrentRow.DataBoundItem as DataRowView;

            if (fila == null)
                return false;

            promocionID = Convert.ToInt32(fila["PromocionID"]);
            return promocionID > 0;
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
                CargarPromociones();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!ObtenerPromocionSeleccionada(out int promocionID))
                return;

            pnlContenidoo.Controls.Clear();

            frmCrearPromocion frm = new frmCrearPromocion(promocionID);

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            pnlContenidoo.Controls.Add(frm);
            pnlContenidoo.Tag = frm;

            frm.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!ObtenerPromocionSeleccionada(out int promocionID))
                return;

            DataRowView fila = dgvPromociones.CurrentRow.DataBoundItem as DataRowView;
            string nombre = fila["Nombre"].ToString();

            DialogResult respuesta = MessageBox.Show(
                "¿Desea eliminar la promoción \"" + nombre + "\"?",
                "Eliminar promoción",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                using (SqlCommand comando = new SqlCommand(
                    "UPDATE Promociones " +
                    "SET Estado = 0 " +
                    "WHERE PromocionID = @PromocionID",
                    conexion))
                {
                    comando.Parameters.Add("@PromocionID", SqlDbType.Int).Value =
                        promocionID;

                    conexion.Open();
                    comando.ExecuteNonQuery();
                }

                MessageBox.Show(
                    "Promoción eliminada correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarPromociones();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo eliminar la promoción: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
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