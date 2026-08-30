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

namespace login.Bar
{
    public partial class frmListadoCanchas : Form
    {
        string cadena;
        public frmListadoCanchas()
        {
            InitializeComponent();
        }

        private void frmListadoCanchas_Load(object sender, EventArgs e)
        {

            this.rvwCanchas.RefreshReport();
        }

        private void rvwCanchas_Load(object sender, EventArgs e)
        {
            csConectaSQL oconSQL = new csConectaSQL();
            DataTable dt = new DataTable();
            ReportDataSource dataset = new ReportDataSource();
            rvwCanchas.LocalReport.DataSources.Clear();//limpia rodo lo q este amarrado a ese control
            rvwCanchas.LocalReport.ReportEmbeddedResource = "login.Bar.rptCanchas.rdlc";
            cadena = "select * from Canchas";
            dt = oconSQL.retornaRegistros(cadena);
            dataset = new ReportDataSource("dsCanchas", dt);
            rvwCanchas.LocalReport.DataSources.Add(dataset);
            dataset.Value = dt;
            rvwCanchas.LocalReport.Refresh();//Refresca el reporte
            this.rvwCanchas.RefreshReport();//actualiza el report viewer
        }
    }
}
