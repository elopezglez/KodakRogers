using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RogersKodak.Dialogs;

namespace RogersKodak
{
    public partial class FrmDashBoard : Form
    {
        public FrmDashBoard()
        {
            InitializeComponent();
            //var dt = new DateTime(2015, 9, 1);
            //if (DateTime.Now > new DateTime(2015, 9, 1))
            //    MessageBox.Show("VERSION DE PRUEBA EXPIRÓ EL DIA." + dt.Date.ToLongDateString(), "RK");
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            Form dlg;
            GroupBox group = (GroupBox)((Button)sender).Parent;
            if (RKUtils.FindControlByKey("level2", group.Controls) == null)
                dlg = new DlgPart1(group);
            else
                dlg = new DlgPart2(group);

            dlg.ShowDialog();
        }


        private void GetResults()
        {
            string strForDB = string.Empty;
            strForDB += RKUtils.GetBodyPartCombination(gbNeck);
            strForDB += "-" + RKUtils.GetBodyPartCombination(gbShoulder);
            strForDB += "-" + RKUtils.GetBodyPartCombination(gbBack);
            strForDB += "-" + RKUtils.GetBodyPartCombination(gbElbow);
            strForDB += "-" + RKUtils.GetBodyPartCombination(gbHand);
            strForDB += "-" + RKUtils.GetBodyPartCombination(gbLeg);
            strForDB += "-" + RKUtils.GetBodyPartCombination(gbFeet);
            var dlg = new FrmSave(strForDB, this);
            dlg.ShowDialog();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            GetResults();
        }

    }
}
