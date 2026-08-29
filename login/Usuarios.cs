using login.GestionDeUsuarios;
using login.Reservas;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Reflection;
using System.Windows.Forms;

namespace login
{
    public partial class UCClientes : Form
    {
        csConectaSQL oCon = new csConectaSQL();
        private bool busquedaAutomaticaAplicada = false;
        int ClientexPag = 40;
        int Bandera = 0;

        string conexionString = @"Server=LAPTOP-J5U2QS20\SQLEXPRESS01;Database=ComplejoDeportivo;Integrated Security=True;TrustServerCertificate=True;";

        public UCClientes()
        {
            InitializeComponent();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            cmbFiltro.Items.Clear();
            cmbFiltro.Items.Add("Todos");
            cmbFiltro.Items.Add("Cédula");
            cmbFiltro.Items.Add("Nombres");
            cmbFiltro.Items.Add("Apellidos");
            cmbFiltro.Items.Add("Correo");
            cmbFiltro.Items.Add("Teléfono");
            cmbFiltro.Items.Add("Ciudad");
            cmbFiltro.SelectedIndex = 0;

            CargarClientes();
        }

        private void CargarClientes()
        {
            try
            {
                string texto = txtBuscar.Text.Trim().Replace("'", "''");
                string filtro = cmbFiltro.SelectedItem?.ToString() ?? "Todos";

                string consulta = @"SELECT ClienteID, Cedula, Nombre, Apellido, Correo, Telefono, Ciudad, Direccion, FechaNacimiento
                                    FROM Clientes";

                    if (!string.IsNullOrWhiteSpace(texto))
                    {
                        switch (filtro)
                        {
                            case "Cédula":
                                consulta += " WHERE Cedula LIKE '%" + texto + "%'";
                                break;

                            case "Nombres":
                                consulta += " WHERE Nombre LIKE '%" + texto + "%'";
                                break;

                            case "Apellidos":
                                consulta += " WHERE Apellido LIKE '%" + texto + "%'";
                                break;

                            case "Correo":
                                consulta += " WHERE Correo LIKE '%" + texto + "%'";
                                break;

                            case "Teléfono":
                                consulta += " WHERE Telefono LIKE '%" + texto + "%'";
                                break;

                            case "Ciudad":
                                consulta += " WHERE Ciudad LIKE '%" + texto + "%'";
                                break;

                            default:
                                consulta += @" WHERE CONCAT(Cedula, ' ', Nombre, ' ', Apellido, ' ', Correo, ' ', Telefono, ' ', Ciudad, ' ', Direccion)
                                              LIKE '%" + texto + "%'";
                                break;
                        }
                    }

                    consulta += " ORDER BY ClienteID DESC";

                    DataTable tabla = oCon.retornaRegistros(consulta);

                    if (tabla == null)
                    {
                        MessageBox.Show("No se pudieron cargar los clientes.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    dgvClientes.DataSource = tabla;
                    dgvClientes.ClearSelection();
                    dgvClientes.CurrentCell = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los clientes:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        private void imprimePagina(object sender, PrintPageEventArgs e)
        {
            SolidBrush verdeProyecto = new SolidBrush(Color.FromArgb(139, 195, 74));

            e.Graphics.DrawImage(imlImagenes.Images[0], 20, 20, 60, 60);
            Font fuente = new Font("Tahoma", 18, FontStyle.Bold);
            e.Graphics.DrawString("Olimpo Sport Club", fuente, Brushes.DarkBlue, new Rectangle(95, 25, 400, 35));
            fuente = new Font("Tahoma", 14, FontStyle.Bold);
            e.Graphics.DrawString("Listado de clientes", fuente, verdeProyecto, new Rectangle(95, 65, 300, 30));

            fuente = new Font("Tahoma", 8, FontStyle.Bold);
            e.Graphics.DrawString("N°", fuente, Brushes.Black, new Rectangle(20, 135, 30, 20));
            e.Graphics.DrawString("Cédula", fuente, Brushes.Black, new Rectangle(50, 135, 70, 20));
            e.Graphics.DrawString("Nombres", fuente, Brushes.Black, new Rectangle(120, 135, 80, 20));
            e.Graphics.DrawString("Apellido", fuente, Brushes.Black, new Rectangle(200, 135, 75, 20));
            e.Graphics.DrawString("Correo", fuente, Brushes.Black, new Rectangle(275, 135, 145, 20));
            e.Graphics.DrawString("Teléfono", fuente, Brushes.Black, new Rectangle(420, 135, 75, 20));
            e.Graphics.DrawString("Ciudad", fuente, Brushes.Black, new Rectangle(495, 135, 65, 20));
            e.Graphics.DrawString("Dirección", fuente, Brushes.Black, new Rectangle(560, 135, 135, 20));
            e.Graphics.DrawString("F. Nacimiento", fuente, Brushes.Black, new Rectangle(695, 135, 90, 20));

            Pen lineaVerde = new Pen(Color.FromArgb(139, 195, 74), 2);
            e.Graphics.DrawLine(lineaVerde, 20, 158, 785, 158);

            int y = 168;
            fuente = new Font("Tahoma", 7.5f, FontStyle.Regular);
            csConectaSQL sqlCon = new csConectaSQL();
            string cadena = "SELECT Cedula, Nombre, Apellido, Correo, Telefono, Ciudad, Direccion, FechaNacimiento FROM Clientes";
            DataTable dt = sqlCon.retornaRegistros(cadena);

            for (int i = 0; i < ClientexPag && Bandera < dt.Rows.Count && y < e.MarginBounds.Bottom - 25; i++, Bandera++)
            {
                e.Graphics.DrawString((Bandera + 1).ToString(), fuente, Brushes.Black, new Rectangle(20, y, 30, 18));
                e.Graphics.DrawString(dt.Rows[Bandera]["Cedula"].ToString(), fuente, Brushes.Black, new Rectangle(50, y, 70, 18));
                e.Graphics.DrawString(dt.Rows[Bandera]["Nombre"].ToString(), fuente, Brushes.Black, new Rectangle(120, y, 80, 18));
                e.Graphics.DrawString(dt.Rows[Bandera]["Apellido"].ToString(), fuente, Brushes.Black, new Rectangle(200, y, 75, 18));
                e.Graphics.DrawString(dt.Rows[Bandera]["Correo"].ToString(), fuente, Brushes.Black, new Rectangle(275, y, 145, 18));
                e.Graphics.DrawString(dt.Rows[Bandera]["Telefono"].ToString(), fuente, Brushes.Black, new Rectangle(420, y, 75, 18));
                e.Graphics.DrawString(dt.Rows[Bandera]["Ciudad"].ToString(), fuente, Brushes.Black, new Rectangle(495, y, 65, 18));
                e.Graphics.DrawString(dt.Rows[Bandera]["Direccion"].ToString(), fuente, Brushes.Black, new Rectangle(560, y, 135, 18));
                e.Graphics.DrawString(dt.Rows[Bandera]["FechaNacimiento"] == DBNull.Value ? "" : Convert.ToDateTime(dt.Rows[Bandera]["FechaNacimiento"]).ToString("dd/MM/yyyy"), fuente, Brushes.Black, new Rectangle(695, y, 90, 18));
                y += 18;
            }

            e.HasMorePages = Bandera < dt.Rows.Count;
            lineaVerde.Dispose();
            verdeProyecto.Dispose();
        }


        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un cliente para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int clienteID = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["colClienteID"].Value);
            string nombre = dgvClientes.SelectedRows[0].Cells["colNombres"].Value.ToString();
            string apellido = dgvClientes.SelectedRows[0].Cells["colApellidos"].Value.ToString();

            DialogResult resultado = MessageBox.Show(
                $"¿Está seguro de eliminar al cliente {nombre} {apellido}?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    string consulta = "DELETE FROM Clientes WHERE ClienteID = @ClienteID";

                    using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                    {
                        cmd.Parameters.Add("@ClienteID", SqlDbType.Int).Value = clienteID;
                        conexion.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Cliente eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el cliente:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un cliente para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int clienteID = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["colClienteID"].Value);

            frmRegistrarCliente ventana = new frmRegistrarCliente(clienteID);
            ventana.StartPosition = FormStartPosition.CenterParent;

            if (ventana.ShowDialog(this) == DialogResult.OK)
            {
                CargarClientes();
            }
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            frmRegistrarCliente ventana = new frmRegistrarCliente();
            ventana.StartPosition = FormStartPosition.CenterParent;

            if (ventana.ShowDialog(this) == DialogResult.OK)
            {
                CargarClientes();
            }
        }

        private void btnImprimir_Click_1(object sender, EventArgs e)
        {
            prdImprimir = new PrintDocument();
            PrinterSettings pd = new PrinterSettings();
            prdImprimir.PrinterSettings = pd;
            prdImprimir.PrintPage += imprimePagina;
            prdImprimir.Print();
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            pnlContenido.Controls.Clear();
            frmListadoClientes frm = new frmListadoClientes();

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            pnlContenido.Controls.Clear();
            pnlContenido.Controls.Add(frm);
            pnlContenido.Tag = frm;

            frm.Show();
        }

        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFiltro.SelectedIndex >= 0 && !string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                CargarClientes();
            }
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarClientes();
                e.SuppressKeyPress = true;
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            int cantidadCaracteres = txtBuscar.Text.Trim().Length;

            if (cantidadCaracteres > 4)
            {
                busquedaAutomaticaAplicada = true;
                CargarClientes();
            }
            else if (cantidadCaracteres == 0 || busquedaAutomaticaAplicada)
            {
                busquedaAutomaticaAplicada = false;
                CargarClientes();
            }
        }
    }
}