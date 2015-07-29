using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RogersKodak.Dialogs
{
    public partial class DlgPart1 : Form
    {

        private GroupBox _gbResult;

        public DlgPart1(GroupBox groupBox)
        {
            InitializeComponent();
            this.gb.Text = groupBox.Text;
            RKUtils.LoadEffortOptions(this);
            RKUtils.SetSelectedEffortOption(gb, groupBox);
            this._gbResult = groupBox;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            RKUtils.CalculateBodyPartResult(this._gbResult, this.gb);
            this.Close();
        }

    }
}
