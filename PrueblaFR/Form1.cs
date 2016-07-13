using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrueblaFR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtEndTime.Value = DateTime.Now.Date.AddDays(1);
             CustomInitialize();
            PrepareGrid();
             //this.Visible = false;
        }


        void CustomInitialize()
        {
            

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
 
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
    }
}
