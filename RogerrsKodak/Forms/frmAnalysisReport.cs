using RogersKodak.Properties;
using RogersKodak.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RogersKodak.Forms
{
    public partial class frmAnalysisReport : Form
    {
        public frmAnalysisReport()
        {
            InitializeComponent();
            CustomInitialize();
        }

        void CustomInitialize()
        {
            UIUtils.SetIconToButton(btnOk, Resources.ok);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.CancelButton = btnOk;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
