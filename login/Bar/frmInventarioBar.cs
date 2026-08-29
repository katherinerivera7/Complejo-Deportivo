using login.GestionDeUsuarios;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Reflection;
using System.Windows.Forms;

namespace login.Bar
{
    public partial class frmInventarioBar : Form
    {
        csConectaSQL conSQL = new csConectaSQL();

        private bool configurandoFiltro = false;
        private bool busquedaAutomaticaAplicada = false;
        int ClientexPag = 40;
        int Bandera = 0;//este es el contador de los clientes

        public frmInventarioBar()
        {
            InitializeComponent();

            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.Columns["colProductoID"].DataPropertyName = "ProductoID";
            dgvProductos.Columns["colCategoria"].DataPropertyName = "Categoria";
            dgvProductos.Columns["colNombre"].DataPropertyName = "Nombre";
            dgvProductos.Columns["colPrecio"].DataPropertyName = "Precio";
            dgvProductos.Columns["colStock"].DataPropertyName = "Stock";
        }

        private void frmInventarioBar_Load(object sender, EventArgs e)
        {
            ConfigurarFiltro();
            CargarProductos();
        }

        private void ConfigurarFiltro()
        {
            configurandoFiltro = true;

            cmbFiltro.Items.Clear();
            cmbFiltro.Items.Add("Todos");
            cmbFiltro.Items.Add("ID Producto");
            cmbFiltro.Items.Add("Categoría");
            cmbFiltro.Items.Add("Nombre");
            cmbFiltro.Items.Add("Precio");
            cmbFiltro.Items.Add("Stock");
            cmbFiltro.SelectedIndex = 0;

            configurandoFiltro = false;
        }

        private void CargarProductos()
        {
            try
            {
                string texto = txtBuscar.Text.Trim().Replace("'", "''");
                string filtro = cmbFiltro.SelectedItem?.ToString() ?? "Todos";

                string consulta = @"SELECT p.ProductoID, c.Nombre AS Categoria, p.Nombre, p.Precio, p.Stock
                                    FROM Productos p
                                    INNER JOIN Categorias c ON p.CategoriaID = c.CategoriaID";

                if (!string.IsNullOrWhiteSpace(texto))
                {
                    switch (filtro)
                    {
                        case "ID Producto":
                            consulta += " WHERE CONVERT(VARCHAR(20), p.ProductoID) LIKE '%" + texto + "%'";
                            break;

                        case "Categoría":
                            consulta += " WHERE c.Nombre LIKE '%" + texto + "%'";
                            break;

                        case "Nombre":
                            consulta += " WHERE p.Nombre LIKE '%" + texto + "%'";
                            break;

                        case "Precio":
                            consulta += " WHERE CONVERT(VARCHAR(30), p.Precio) LIKE '%" + texto + "%'";
                            break;

                        case "Stock":
                            consulta += " WHERE CONVERT(VARCHAR(20), p.Stock) LIKE '%" + texto + "%'";
                            break;

                        default:
                            consulta += @" WHERE CONCAT(
                                          CONVERT(VARCHAR(20), p.ProductoID), ' ',
                                          c.Nombre, ' ',
                                          p.Nombre, ' ',
                                          CONVERT(VARCHAR(30), p.Precio), ' ',
                                          CONVERT(VARCHAR(20), p.Stock)
                                          ) LIKE '%" + texto + "%'";
                            break;
                    }
                }

                consulta += " ORDER BY p.ProductoID DESC";

                DataTable tabla = conSQL.retornaRegistros(consulta);

                if (tabla == null)
                {
                    MessageBox.Show("No se pudieron cargar los productos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dgvProductos.DataSource = tabla;
                dgvProductos.ClearSelection();
                dgvProductos.CurrentCell = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los productos:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmProductos frm = new frmProductos();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog(this);
            CargarProductos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int productoID = Convert.ToInt32(dgvProductos.SelectedRows[0].Cells["colProductoID"].Value);

            frmProductos frm = new frmProductos(productoID);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog(this);

            CargarProductos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int productoID = Convert.ToInt32(dgvProductos.SelectedRows[0].Cells["colProductoID"].Value);
            string nombre = dgvProductos.SelectedRows[0].Cells["colNombre"].Value.ToString();

            DialogResult respuesta = MessageBox.Show(
                "¿Desea eliminar el producto " + nombre + "?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta != DialogResult.Yes)
                return;

            if (conSQL.borrarDatos("Productos", "ProductoID = " + productoID))
            {
                MessageBox.Show("Producto eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarProductos();
            }
        }

        private void btnMovimiento_Click(object sender, EventArgs e)
        {
            frmRegistrarMovimiento frm = new frmRegistrarMovimiento();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog(this);
            CargarProductos();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            pnlContenidoo.Controls.Clear();

            frmHistorialMovimientos frm = new frmHistorialMovimientos();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            pnlContenidoo.Controls.Add(frm);
            pnlContenidoo.Tag = frm;
            frm.Show();
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            int cantidadCaracteres = txtBuscar.Text.Trim().Length;

            if (cantidadCaracteres > 4)
            {
                busquedaAutomaticaAplicada = true;
                CargarProductos();
            }
            else if (cantidadCaracteres == 0 || busquedaAutomaticaAplicada)
            {
                busquedaAutomaticaAplicada = false;
                CargarProductos();
            }
        }

        private void cmbFiltro_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!configurandoFiltro && cmbFiltro.SelectedIndex >= 0)
            {
                CargarProductos();
            }
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarProductos();
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
            e.Graphics.DrawString("Listado de productos", fuente, verdeProyecto, new Rectangle(95, 65, 300, 30));

            fuente = new Font("Tahoma", 9, FontStyle.Bold);
            e.Graphics.DrawString("N°.", fuente, Brushes.Black, new Rectangle(20, 135, 40, 20));
            e.Graphics.DrawString("Código", fuente, Brushes.Black, new Rectangle(60, 135, 80, 20));
            e.Graphics.DrawString("Categoría", fuente, Brushes.Black, new Rectangle(140, 135, 170, 20));
            e.Graphics.DrawString("Producto", fuente, Brushes.Black, new Rectangle(310, 135, 230, 20));
            e.Graphics.DrawString("Precio", fuente, Brushes.Black, new Rectangle(540, 135, 120, 20));
            e.Graphics.DrawString("Stock", fuente, Brushes.Black, new Rectangle(660, 135, 110, 20));

            Pen lineaVerde = new Pen(Color.FromArgb(139, 195, 74), 2);
            e.Graphics.DrawLine(lineaVerde, 20, 158, 770, 158);

            int y = 168;
            fuente = new Font("Tahoma", 8.5f, FontStyle.Regular);
            csConectaSQL sqlCon = new csConectaSQL();
            string cadena = @"SELECT p.ProductoID, c.Nombre AS Categoria, p.Nombre, p.Precio, p.Stock
                  FROM Productos p
                  LEFT JOIN Categorias c ON p.CategoriaID = c.CategoriaID
                  ORDER BY p.Nombre";

            DataTable dt = sqlCon.retornaRegistros(cadena);

            for (int i = 0; i < ClientexPag && Bandera < dt.Rows.Count && y < e.MarginBounds.Bottom - 25; i++, Bandera++)
            {
                e.Graphics.DrawString((Bandera + 1).ToString(), fuente, Brushes.Black, new Rectangle(20, y, 40, 18));
                e.Graphics.DrawString(dt.Rows[Bandera]["ProductoID"].ToString(), fuente, Brushes.Black, new Rectangle(60, y, 80, 18));
                e.Graphics.DrawString(dt.Rows[Bandera]["Categoria"].ToString(), fuente, Brushes.Black, new Rectangle(140, y, 170, 18));
                e.Graphics.DrawString(dt.Rows[Bandera]["Nombre"].ToString(), fuente, Brushes.Black, new Rectangle(310, y, 230, 18));
                e.Graphics.DrawString(dt.Rows[Bandera]["Precio"] == DBNull.Value ? "$0.00" : "$" + Convert.ToDecimal(dt.Rows[Bandera]["Precio"]).ToString("N2"), fuente, Brushes.Black, new Rectangle(540, y, 120, 18));
                e.Graphics.DrawString(dt.Rows[Bandera]["Stock"].ToString(), fuente, Brushes.Black, new Rectangle(660, y, 110, 18));
                y += 18;
            }

            e.HasMorePages = Bandera < dt.Rows.Count;
            lineaVerde.Dispose();
            verdeProyecto.Dispose();
        }

        private void pnlContenidoo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            pnlContenidoo.Controls.Clear();
            frmListadoProductos frm = new frmListadoProductos();

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