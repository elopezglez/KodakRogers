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
        UtilsTableAdapter cn = new UtilsTableAdapter();
        public FrmAnalysisList()
        {
            InitializeComponent();
            txtEndTime.Value= DateTime.Now.Date.AddDays(1);
            var tb = cn.GetAnalysisDinceDate(txtStartDate.Value.Date, txtEndTime.Value.Date);
            PrepareGrid();
            ShowResults();
        }




        private void FillGrid(DataTable ds) {
            lstAnalysis.Items.Clear();
            foreach (DataRow row in ds.Rows)
            {
                var item = lstAnalysis.Items.Add(row["ID"].ToString(), row["ID"].ToString(), 0);//.BackColor = Color.LightGray;
                item.SubItems.Add(row["DateCreated"].ToString());
                item.SubItems.Add(row["JobTitle"].ToString());
                item.SubItems.Add("EmployeeName");
            }
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
        }

        private void btnGetAnalysis_Click(object sender, EventArgs e)
        {
            ShowResults();
        }

        private void ShowResults() {
            var tb = cn.GetAnalysisDinceDate(txtStartDate.Value.Date, txtEndTime.Value.Date);
            FillGrid(tb);        
        }

    }
}
