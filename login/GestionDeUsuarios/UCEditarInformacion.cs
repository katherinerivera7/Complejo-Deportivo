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
    public partial class UCEditarInformacion : UserControl
    {
        public UCEditarInformacion()
        {
            InitializeComponent();
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            guna2DateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }

        private void UCEditarInformacion_Load(object sender, EventArgs e)
        {
            guna2DateTimePicker1.Format = DateTimePickerFormat.Custom;
            guna2DateTimePicker1.CustomFormat = "'Fecha de nacimiento'";
        }
    }
}
