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
    public partial class frmListadoProductos : Form
    {
        string cadena;
        public frmListadoProductos()
        {
            InitializeComponent();
        }

        private void frmListadoProductos_Load(object sender, EventArgs e)
        {
            csConectaSQL oconSQL = new csConectaSQL();
            DataTable dt = new DataTable();
            ReportDataSource dataset = new ReportDataSource();
            rvwProductos.LocalReport.DataSources.Clear();//limpia rodo lo q este amarrado a ese control
            rvwProductos.LocalReport.ReportEmbeddedResource = "login.Bar.rptProductos.rdlc";
            cadena = "select * from Productos";
            dt = oconSQL.retornaRegistros(cadena);
            dataset = new ReportDataSource("dsProductos", dt);
            rvwProductos.LocalReport.DataSources.Add(dataset);
            dataset.Value = dt;
            rvwProductos.LocalReport.Refresh();//Refresca el reporte
            this.rvwProductos.RefreshReport();//actualiza el report viewer
        }


        private void btnVolver_Click_1(object sender, EventArgs e)
        {
            pnlContenido.Controls.Clear();
            frmInventarioBar frm = new frmInventarioBar();

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            pnlContenido.Controls.Clear();
            pnlContenido.Controls.Add(frm);
            pnlContenido.Tag = frm;

            frm.Show();
        }

        private void rvwProductos_Load(object sender, EventArgs e)
        {

        }
    }
}
