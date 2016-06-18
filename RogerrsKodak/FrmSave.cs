using RogersKodak.Data_Sets.LocalBDDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace RogersKodak
{
    public partial class FrmSave : Form
    {
        string _strResults = string.Empty;
        Form _frmDashBoard;

        public FrmSave(string strResults, Form frmDashBoard)
        {
            InitializeComponent();
            this._strResults = strResults;
            _frmDashBoard = frmDashBoard;
        }



        private void btnAccept_Click(object sender, EventArgs e)
        {
            string[] arr = _strResults.Split('-');
            var adapterRs = new AnalysisResultsTableAdapter();
            int analysisResultsId = adapterRs.InsertNewAnalysisResultsRecord(
                                    arr[0],
                                    arr[1],
                                    arr[2],
                                    arr[3],
                                    arr[4],
                                    arr[5],
                                    arr[6],
                                    arr[7],
                                    arr[8],
                                    arr[9],
                                    arr[10],
                                    arr[11],
                                    arr[12],
                                    arr[13],
                                    arr[14],
                                    arr[15],
                                    arr[16],
                                    arr[17],
                                    arr[18]
                                        );
            var adapter = new AnalysisDataTableAdapter();
            int num = adapter.InsertNewAnalysisDataRecord(txtAnalystName.Text,
                                                  txtJobTitle.Text,
                                                  txtJobDescription.Text,
                                                  txtAnalystName.Text,
                                                  txtEmployeeName.Text,
                                                  analysisResultsId
                                                  );

            MessageBox.Show("EL ANALISIS SE HA GUARDADO CON EXITO", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
            _frmDashBoard.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();            
        }




    }
}
