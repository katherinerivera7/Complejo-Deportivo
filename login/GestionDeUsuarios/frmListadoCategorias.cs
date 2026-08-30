using login.Bar;
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
            csConectaSQL oconSQL = new csConectaSQL();
            DataTable dt = new DataTable();
            ReportDataSource dataset = new ReportDataSource();
            rvwCategorias.LocalReport.DataSources.Clear();//limpia rodo lo q este amarrado a ese control
            rvwCategorias.LocalReport.ReportEmbeddedResource = "login.rptCategorias.rdlc";
            cadena = "SELECT CategoriaID, Nombre, " +
         "CASE WHEN Estado = 1 THEN 'Activa' ELSE 'Inactiva' END AS Estado " +
         "FROM Categorias";
            dt = oconSQL.retornaRegistros(cadena);
            dataset = new ReportDataSource("dsCategoria", dt);
            rvwCategorias.LocalReport.DataSources.Add(dataset);
            dataset.Value = dt;
            rvwCategorias.LocalReport.Refresh();//Refresca el reporte
            this.rvwCategorias.RefreshReport();//actualiza el report viewer
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            pnlContenido.Controls.Clear();
            frmCategorias frm = new frmCategorias();

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
