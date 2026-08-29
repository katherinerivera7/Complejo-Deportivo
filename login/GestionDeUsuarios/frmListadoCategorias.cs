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
    public partial class frmListadoCategorias : Form
    {
        string cadena;
        public frmListadoCategorias()
        {
            InitializeComponent();
        }

        private void frmListadoCategorias_Load(object sender, EventArgs e)
        {

            this.rvwCategorias.RefreshReport();
        }

        private void rvwCategorias_Load(object sender, EventArgs e)
        {
            csConectaSQL oconSQL = new csConectaSQL();
            DataTable dt = new DataTable();
            ReportDataSource dataset = new ReportDataSource();
            rvwCategorias.LocalReport.DataSources.Clear();//limpia rodo lo q este amarrado a ese control
            rvwCategorias.LocalReport.ReportEmbeddedResource = "login.rptCategorias.rdlc";
            cadena = "select * from Categorias";
            dt = oconSQL.retornaRegistros(cadena);
            dataset = new ReportDataSource("dsCategorias", dt);
            rvwCategorias.LocalReport.DataSources.Add(dataset);
            dataset.Value = dt;
            rvwCategorias.LocalReport.Refresh();//Refresca el reporte
            this.rvwCategorias.RefreshReport();//actualiza el report viewer
        }
    }
}
