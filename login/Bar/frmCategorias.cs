using login.GestionDeUsuarios;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Reflection;
using System.Windows.Forms;

namespace login.Bar
{
    public partial class frmCategorias : Form
    {
        csConectaSQL conSQL = new csConectaSQL();

        private bool configurandoFiltro = false;
        private bool busquedaAutomaticaAplicada = false;
        int CategoriasxPag = 40;
        int Bandera = 0;//este es el contador de los clientes

        public frmCategorias()
        {
            InitializeComponent();

            dgvCategorias.AutoGenerateColumns = false;
            dgvCategorias.Columns["colCategoriaID"].DataPropertyName = "CategoriaID";
            dgvCategorias.Columns["colNombre"].DataPropertyName = "Nombre";
        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {
            ConfigurarFiltro();
            CargarCategorias();

        }

        private void ConfigurarFiltro()
        {
            configurandoFiltro = true;

            cmbFiltro.Items.Clear();
            cmbFiltro.Items.Add("Todos");
            cmbFiltro.Items.Add("ID Categoría");
            cmbFiltro.Items.Add("Nombre");
            cmbFiltro.SelectedIndex = 0;

            configurandoFiltro = false;
        }

        private void CargarCategorias()
        {
            try
            {
                string texto = txtFiltro.Text.Trim().Replace("'", "''");
                string filtro = cmbFiltro.SelectedItem?.ToString() ?? "Todos";

                string consulta = "SELECT CategoriaID, Nombre FROM Categorias";

                if (!string.IsNullOrWhiteSpace(texto))
                {
                    switch (filtro)
                    {
                        case "ID Categoría":
                            consulta += " WHERE CONVERT(VARCHAR(20), CategoriaID) LIKE '%" + texto + "%'";
                            break;

                        case "Nombre":
                            consulta += " WHERE Nombre LIKE '%" + texto + "%'";
                            break;

                        default:
                            consulta += @" WHERE CONCAT(
                                          CONVERT(VARCHAR(20), CategoriaID), ' ',
                                          Nombre
                                          ) LIKE '%" + texto + "%'";
                            break;
                    }
                }

                consulta += " ORDER BY CategoriaID DESC";

                DataTable tabla = conSQL.retornaRegistros(consulta);

                if (tabla == null)
                {
                    MessageBox.Show("No se pudieron cargar las categorías.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dgvCategorias.DataSource = tabla;
                dgvCategorias.ClearSelection();
                dgvCategorias.CurrentCell = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las categorías:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!configurandoFiltro && cmbFiltro.SelectedIndex >= 0)
            {
                CargarCategorias();
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmCrearCategoria frm = new frmCrearCategoria();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog(this);
            CargarCategorias();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una categoría para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int categoriaID = Convert.ToInt32(dgvCategorias.SelectedRows[0].Cells["colCategoriaID"].Value);

            frmCrearCategoria frm = new frmCrearCategoria(categoriaID);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog(this);

            CargarCategorias();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una categoría para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int categoriaID = Convert.ToInt32(dgvCategorias.SelectedRows[0].Cells["colCategoriaID"].Value);
            string nombre = dgvCategorias.SelectedRows[0].Cells["colNombre"].Value.ToString();

            DialogResult respuesta = MessageBox.Show(
                "¿Desea eliminar la categoría " + nombre + "?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta != DialogResult.Yes)
                return;

            if (conSQL.borrarDatos("Categorias", "CategoriaID = " + categoriaID))
            {
                MessageBox.Show("Categoría eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarCategorias();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarCategorias();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            int cantidadCaracteres = txtFiltro.Text.Trim().Length;

            if (cantidadCaracteres > 4)
            {
                busquedaAutomaticaAplicada = true;
                CargarCategorias();
            }
            else if (cantidadCaracteres == 0 || busquedaAutomaticaAplicada)
            {
                busquedaAutomaticaAplicada = false;
                CargarCategorias();
            }
        }

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarCategorias();
                e.SuppressKeyPress = true;
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
            e.Graphics.DrawString("Listado de categorías", fuente, verdeProyecto, new Rectangle(95, 65, 300, 30));

            fuente = new Font("Tahoma", 12, FontStyle.Bold);
            e.Graphics.DrawString("Nª.", fuente, Brushes.Black, new Rectangle(20, 135, 50, 20));
            e.Graphics.DrawString("Código", fuente, Brushes.Black, new Rectangle(70, 135, 100, 20));
            e.Graphics.DrawString("Nombre de la categoría", fuente, Brushes.Black, new Rectangle(170, 135, 400, 20));
            e.Graphics.DrawString("Estado", fuente, Brushes.Black, new Rectangle(570, 135, 200, 20));

            Pen lineaVerde = new Pen(Color.FromArgb(139, 195, 74), 2);
            e.Graphics.DrawLine(lineaVerde, 20, 158, 770, 158);

            int y = 168;
            fuente = new Font("Tahoma", 12, FontStyle.Regular);
            csConectaSQL sqlCon = new csConectaSQL();
            string cadena = @"SELECT CategoriaID, Nombre, CASE WHEN Estado = 1 THEN 'Activa' ELSE 'Inactiva' END AS Estado FROM Categorias ORDER BY Nombre";
            DataTable dt = sqlCon.retornaRegistros(cadena);

            for (int i = 0; i < CategoriasxPag && Bandera < dt.Rows.Count && y < e.MarginBounds.Bottom - 25; i++, Bandera++)
            {
                e.Graphics.DrawString((Bandera + 1).ToString(), fuente, Brushes.Black, new Rectangle(20, y, 50, 18));
                e.Graphics.DrawString(dt.Rows[Bandera]["CategoriaID"].ToString(), fuente, Brushes.Black, new Rectangle(70, y, 100, 18));
                e.Graphics.DrawString(dt.Rows[Bandera]["Nombre"].ToString(), fuente, Brushes.Black, new Rectangle(170, y, 400, 18));
                e.Graphics.DrawString(dt.Rows[Bandera]["Estado"].ToString(), fuente, Brushes.Black, new Rectangle(570, y, 200, 18));
                y += 18;
            }

            e.HasMorePages = Bandera < dt.Rows.Count;
            lineaVerde.Dispose();
            verdeProyecto.Dispose();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            pnlContenido2.Controls.Clear();
            frmListadoCategorias frm = new frmListadoCategorias();

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