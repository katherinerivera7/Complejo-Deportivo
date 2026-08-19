using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Reflection;
using System.Windows.Forms;

namespace login.Reservas
{
    public partial class frmCanchas : Form
    {
        csConectaSQL conSQL = new csConectaSQL();

        private bool configurandoFiltro = false;
        private bool busquedaAutomaticaAplicada = false;
        int ClientexPag = 40;
        int Bandera = 0;//este es el contador de los clientes


        public frmCanchas()
        {
            InitializeComponent();

            dgvCanchas.AutoGenerateColumns = false;

            dgvCanchas.Columns[0].Name = "colCanchaID";
            dgvCanchas.Columns[0].DataPropertyName = "CanchaID";

            dgvCanchas.Columns[1].Name = "colNombre";
            dgvCanchas.Columns[1].DataPropertyName = "Nombre";

            dgvCanchas.Columns[2].Name = "colTipo";
            dgvCanchas.Columns[2].DataPropertyName = "Tipo";

            dgvCanchas.Columns[3].Name = "colPrecioHora";
            dgvCanchas.Columns[3].DataPropertyName = "PrecioHora";

            dgvCanchas.Columns[4].Name = "colEstado";
            dgvCanchas.Columns[4].DataPropertyName = "Estado";
        }

        private void frmCanchas_Load(object sender, EventArgs e)
        {
            ConfigurarFiltro();
            CargarCanchas();
        }

        private void ConfigurarFiltro()
        {
            configurandoFiltro = true;

            cmbFiltro.Items.Clear();
            cmbFiltro.Items.Add("Todos");
            cmbFiltro.Items.Add("ID Cancha");
            cmbFiltro.Items.Add("Nombre");
            cmbFiltro.Items.Add("Tipo");
            cmbFiltro.Items.Add("Precio por hora");
            cmbFiltro.Items.Add("Estado");
            cmbFiltro.SelectedIndex = 0;

            configurandoFiltro = false;
        }

        private void CargarCanchas()
        {
            try
            {
                string texto = txtFiltro.Text.Trim().Replace("'", "''");
                string filtro = cmbFiltro.SelectedItem?.ToString() ?? "Todos";

                string consulta = @"SELECT CanchaID, Nombre, Tipo, PrecioHora, Estado
                                    FROM Canchas";

                if (!string.IsNullOrWhiteSpace(texto))
                {
                    switch (filtro)
                    {
                        case "ID Cancha":
                            consulta += " WHERE CONVERT(VARCHAR(20), CanchaID) LIKE '%" + texto + "%'";
                            break;

                        case "Nombre":
                            consulta += " WHERE Nombre LIKE '%" + texto + "%'";
                            break;

                        case "Tipo":
                            consulta += " WHERE Tipo LIKE '%" + texto + "%'";
                            break;

                        case "Precio por hora":
                            consulta += " WHERE CONVERT(VARCHAR(30), PrecioHora) LIKE '%" + texto + "%'";
                            break;

                        case "Estado":
                            consulta += " WHERE CONVERT(VARCHAR(30), Estado) LIKE '%" + texto + "%'";
                            break;

                        default:
                            consulta += @" WHERE CONCAT(
                                          CONVERT(VARCHAR(20), CanchaID), ' ',
                                          Nombre, ' ',
                                          Tipo, ' ',
                                          CONVERT(VARCHAR(30), PrecioHora), ' ',
                                          CONVERT(VARCHAR(30), Estado)
                                          ) LIKE '%" + texto + "%'";
                            break;
                    }
                }

                consulta += " ORDER BY CanchaID DESC";

                DataTable tabla = conSQL.retornaRegistros(consulta);

                if (tabla == null)
                {
                    MessageBox.Show("No se pudieron cargar las canchas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dgvCanchas.DataSource = tabla;
                dgvCanchas.ClearSelection();
                dgvCanchas.CurrentCell = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las canchas:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarCanchas();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            int cantidadCaracteres = txtFiltro.Text.Trim().Length;

            if (cantidadCaracteres > 4)
            {
                busquedaAutomaticaAplicada = true;
                CargarCanchas();
            }
            else if (cantidadCaracteres == 0 || busquedaAutomaticaAplicada)
            {
                busquedaAutomaticaAplicada = false;
                CargarCanchas();
            }
        }

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarCanchas();
                e.SuppressKeyPress = true;
            }
        }

        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!configurandoFiltro && cmbFiltro.SelectedIndex >= 0)
            {
                CargarCanchas();
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmCrearCancha frm = new frmCrearCancha();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog(this);
            CargarCanchas();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCanchas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una cancha para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int canchaID = Convert.ToInt32(dgvCanchas.SelectedRows[0].Cells["colCanchaID"].Value);

            frmCrearCancha frm = new frmCrearCancha(canchaID);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog(this);

            CargarCanchas();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCanchas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una cancha para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int canchaID = Convert.ToInt32(dgvCanchas.SelectedRows[0].Cells["colCanchaID"].Value);
            string nombre = dgvCanchas.SelectedRows[0].Cells["colNombre"].Value.ToString();

            DialogResult respuesta = MessageBox.Show(
                "¿Desea eliminar la cancha " + nombre + "?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta != DialogResult.Yes)
                return;

            if (conSQL.borrarDatos("Canchas", "CanchaID = " + canchaID))
            {
                MessageBox.Show("Cancha eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarCanchas();
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            prdImprimir = new PrintDocument();
            PrinterSettings pd = new PrinterSettings();
            prdImprimir.PrinterSettings = pd;
            prdImprimir.PrintPage += imprimePagina;
            prdImprimir.Print();
        }
        private void imprimePagina(object sender, PrintPageEventArgs e)
        {
            SolidBrush verdeProyecto = new SolidBrush(Color.FromArgb(139, 195, 74));

            e.Graphics.DrawImage(imlImagenes.Images[0], 20, 20, 60, 60);
            Font fuente = new Font("Tahoma", 18, FontStyle.Bold);
            e.Graphics.DrawString("Olimpo Sport Club", fuente, Brushes.DarkBlue, new Rectangle(95, 25, 400, 35));
            fuente = new Font("Tahoma", 14, FontStyle.Bold);
            e.Graphics.DrawString("Listado de canchas", fuente, verdeProyecto, new Rectangle(95, 65, 300, 30));

            fuente = new Font("Tahoma", 9, FontStyle.Bold);
            e.Graphics.DrawString("N°.", fuente, Brushes.Black, new Rectangle(20, 135, 40, 20));
            e.Graphics.DrawString("Código", fuente, Brushes.Black, new Rectangle(60, 135, 80, 20));
            e.Graphics.DrawString("Nombre", fuente, Brushes.Black, new Rectangle(140, 135, 190, 20));
            e.Graphics.DrawString("Tipo", fuente, Brushes.Black, new Rectangle(330, 135, 170, 20));
            e.Graphics.DrawString("Precio por hora", fuente, Brushes.Black, new Rectangle(500, 135, 140, 20));
            e.Graphics.DrawString("Estado", fuente, Brushes.Black, new Rectangle(640, 135, 130, 20));

            Pen lineaVerde = new Pen(Color.FromArgb(139, 195, 74), 2);
            e.Graphics.DrawLine(lineaVerde, 20, 158, 770, 158);

            int y = 168;
            fuente = new Font("Tahoma", 8.5f, FontStyle.Regular);
            csConectaSQL sqlCon = new csConectaSQL();
            string cadena = "SELECT CanchaID, Nombre, Tipo, PrecioHora, Estado FROM Canchas ORDER BY Nombre";
            DataTable dt = sqlCon.retornaRegistros(cadena);

            for (int i = 0; i < ClientexPag && Bandera < dt.Rows.Count && y < e.MarginBounds.Bottom - 25; i++, Bandera++)
            {
                e.Graphics.DrawString((Bandera + 1).ToString(), fuente, Brushes.Black, new Rectangle(20, y, 40, 18));
                e.Graphics.DrawString(dt.Rows[Bandera]["CanchaID"].ToString(), fuente, Brushes.Black, new Rectangle(60, y, 80, 18));
                e.Graphics.DrawString(dt.Rows[Bandera]["Nombre"].ToString(), fuente, Brushes.Black, new Rectangle(140, y, 190, 18));
                e.Graphics.DrawString(dt.Rows[Bandera]["Tipo"].ToString(), fuente, Brushes.Black, new Rectangle(330, y, 170, 18));
                e.Graphics.DrawString(dt.Rows[Bandera]["PrecioHora"] == DBNull.Value ? "$0.00" : "$" + Convert.ToDecimal(dt.Rows[Bandera]["PrecioHora"]).ToString("N2"), fuente, Brushes.Black, new Rectangle(500, y, 140, 18));
                e.Graphics.DrawString(dt.Rows[Bandera]["Estado"].ToString(), fuente, Brushes.Black, new Rectangle(640, y, 130, 18));
                y += 18;
            }

            e.HasMorePages = Bandera < dt.Rows.Count;
            lineaVerde.Dispose();
            verdeProyecto.Dispose();
        }
    }
}