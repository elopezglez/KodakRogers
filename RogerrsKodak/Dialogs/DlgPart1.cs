using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RogersKodak.Utils;
using RogersKodak.Properties;

namespace RogersKodak.Dialogs
{
    public partial class DlgPart1 : Form
    {

        private GroupBox _gbResult;

        public DlgPart1(GroupBox groupBox)
        {
            InitializeComponent();
            CustomInitialize();
            this.gb.Text = groupBox.Text;
            RKUtils.LoadEffortOptions(this);
            RKUtils.SetSelectedEffortOption(gb, groupBox);
            this._gbResult = groupBox;
        }

        void CustomInitialize()
        {
            UIUtils.SetIconToButton(btnAccept, Resources.ok);
            UIUtils.SetIconToButton(BtnCancel, Resources.close);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.CancelButton = BtnCancel;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            RKUtils.CalculateBodyPartResult(this._gbResult, this.gb);
            this.Close();
        }

    }
}
