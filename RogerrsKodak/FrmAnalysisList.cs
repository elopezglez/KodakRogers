using RogersKodak.Data_Sets.LocalBDDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RogersKodak
{
    public partial class FrmAnalysisList : Form
    {
        public FrmAnalysisList()
        {
            InitializeComponent();
            this.PrepareGrid();
            var cn = new UtilsTableAdapter();
            var tb = cn.GetAnalysisDinceDate(DateTime.Now);
        }

        private void PrepareGrid()
        {
            lstAnalysis.FullRowSelect = true;
            lstAnalysis.GridLines = true;
            lstAnalysis.HideSelection = false;
            lstAnalysis.HotTracking = false;
            lstAnalysis.LabelEdit = false;
            lstAnalysis.MultiSelect = false;
            lstAnalysis.ShowItemToolTips = true;
            lstAnalysis.View = View.Details;

            lstAnalysis.Columns.Add("ID", 50, HorizontalAlignment.Center);
            lstAnalysis.Columns.Add("Fecha", 150, HorizontalAlignment.Center);
            lstAnalysis.Columns.Add("Proceso", 150, HorizontalAlignment.Center);
            lstAnalysis.Columns.Add("Empleado", 150, HorizontalAlignment.Center);
            lstAnalysis.Columns.Add("Resultado", 150, HorizontalAlignment.Center);

            lstAnalysis.Items.Add("1", "primer col", 0).BackColor = Color.LightGray;
            lstAnalysis.Items[0].SubItems.Add("Segunda");
            lstAnalysis.Items[0].SubItems.Add("Tercer");
            lstAnalysis.Items[0].SubItems.Add("cuarta");

            lstAnalysis.Items.Add("1", "primer col", 0);
            lstAnalysis.Items[1].SubItems.Add("Segunda");
            lstAnalysis.Items[1].SubItems.Add("Tercer");
            lstAnalysis.Items[1].SubItems.Add("cuarta");

            lstAnalysis.Items.Add("1", "primer col", 0).BackColor = Color.LightGray;
            lstAnalysis.Items[2].SubItems.Add("Segunda");
            lstAnalysis.Items[2].SubItems.Add("Tercer");
            lstAnalysis.Items[2].SubItems.Add("cuarta");

        }

    }
}
