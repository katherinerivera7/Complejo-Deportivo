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
    public partial class frmEncontrarCliente : Form
    {
        csConectaSQL Con=new csConectaSQL();
        string cadena, canchas;
        string tipoDocumento, cedula, nombre, apellido, clienteID, telefono, correo, direccion, ciudad;
        public string TipoDocumento
        {
            get { return tipoDocumento; }
            set { tipoDocumento = value; }
        }
        public string Cedula
        {
            get { return cedula; }
            set { cedula = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public string ClienteID
        {
            get { return clienteID; }
            set { clienteID = value; }
        }
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        public string Ciudad
        {
            get { return ciudad; }
            set { ciudad = value; }
        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            TipoDocumento = dgvClientes.Rows[e.RowIndex].Cells["TipoDocumento"].Value.ToString();
            Cedula = dgvClientes.Rows[e.RowIndex].Cells["Cedula"].Value.ToString();
            Nombre = dgvClientes.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
            Apellido = dgvClientes.Rows[e.RowIndex].Cells["Apellido"].Value.ToString();
            ClienteID = dgvClientes.Rows[e.RowIndex].Cells["ClienteID"].Value.ToString();
            Telefono = dgvClientes.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
            Correo = dgvClientes.Rows[e.RowIndex].Cells["Correo"].Value.ToString();
            Direccion = dgvClientes.Rows[e.RowIndex].Cells["Direccion"].Value.ToString();
            Ciudad = Convert.ToString(dgvClientes.Rows[e.RowIndex].Cells["Ciudad"].Value);
            DialogResult = DialogResult.OK;
            this.Close();
        }

        public frmEncontrarCliente()
        {
            InitializeComponent();
            dgvClientes.RowHeadersVisible = false;
            dgvClientes.ReadOnly = true;
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToResizeRows = false;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.MultiSelect = false;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.BackgroundColor = Color.White;
            dgvClientes.GridColor = Color.LightGray;
            dgvClientes.EnableHeadersVisualStyles = false;
            dgvClientes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(104, 161, 73);
            dgvClientes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvClientes.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 239, 210);
            dgvClientes.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {
            CargarClientes();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void frmEncontrarCliente_Load(object sender, EventArgs e)
        {
            CargarClientes();
            canchas = "select Nombre from Canchas";
        }
        private void CargarClientes()
        {
            cadena = "SELECT ClienteID, TipoDocumento, Cedula, Nombre, Apellido, Telefono, Correo, Direccion, Ciudad " +
                     "FROM Clientes WHERE TipoDocumento = '" + cmbTipoDocumento.Text + "'";

            if (!string.IsNullOrWhiteSpace(txtCedula.Text))
                cadena += " AND Cedula LIKE '%" + txtCedula.Text.Trim() + "%'";

            dgvClientes.DataSource = Con.retornaRegistros(cadena);
            dgvClientes.Columns["ClienteID"].Visible = false;
            dgvClientes.Columns["TipoDocumento"].Visible = false;
            dgvClientes.Columns["Telefono"].Visible = false;
            dgvClientes.Columns["Correo"].Visible = false;
            dgvClientes.Columns["Direccion"].Visible = false;
        }
    }
}
