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
    public partial class frmRegistrarCliente : Form
    {
        private UCRegistrarUsuario uc;
        public frmRegistrarCliente()
        {
            InitializeComponent();

            uc = new UCRegistrarUsuario();

            uc.Dock = DockStyle.Fill;

            this.Controls.Add(uc);
        }
        public frmRegistrarCliente(int clienteID)
        {
            InitializeComponent();

            uc = new UCRegistrarUsuario(clienteID);

            uc.Dock = DockStyle.Fill;

            this.Controls.Add(uc);
        }
    }
}
