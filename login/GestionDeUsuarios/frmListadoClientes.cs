using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace login.GestionDeUsuarios
{
    public partial class frmListadoClientes : Form
    {
        string cadena;
        public frmListadoClientes()
        {
            InitializeComponent();
        }

        private void frmListadoClientes_Load(object sender, EventArgs e)
        {
            csConectaSQL oconSQL = new csConectaSQL();
            DataTable dt = new DataTable();
            ReportDataSource dataset = new ReportDataSource();
            rvwClientes.LocalReport.DataSources.Clear();//limpia rodo lo q este amarrado a ese control
            rvwClientes.LocalReport.ReportEmbeddedResource = "login.rptClientes.rdlc";
            cadena = "select * from Clientes";
            dt = oconSQL.retornaRegistros(cadena);
            dataset = new ReportDataSource("dsClientes", dt);
            rvwClientes.LocalReport.DataSources.Add(dataset);
            dataset.Value = dt;
            rvwClientes.LocalReport.Refresh();//Refresca el reporte
            this.rvwClientes.RefreshReport();//actualiza el report viewer
        }

        private void rvwClientes_Load(object sender, EventArgs e)
        {

        }
    }
}
