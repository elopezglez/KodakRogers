using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RogersKodak.Forms
{
    public partial class FrmSplash : Form
    {
        Form _mainForm;
        public FrmSplash(FrmAnalysisList mainForm)
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            _mainForm = mainForm;
            CustomInitialize();
        }


        void CustomInitialize()
        {
            bar1.Style = ProgressBarStyle.Blocks;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
        }

 
        private void FrmSplash_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i <= 100; i++)
            {
                // Wait 100 milliseconds.
                Thread.Sleep(35);
                // Report progress.
                backgroundWorker1.ReportProgress(i);                
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Change the value of the ProgressBar to the BackgroundWorker progress.
            bar1.Value= e.ProgressPercentage;
        }

        private void backgroundWorker1_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();            
        }

    }
}
