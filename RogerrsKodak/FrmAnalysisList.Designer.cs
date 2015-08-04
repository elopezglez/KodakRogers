namespace RogersKodak
{
    partial class FrmAnalysisList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstAnalysis = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lstAnalysis
            // 
            this.lstAnalysis.Location = new System.Drawing.Point(12, 12);
            this.lstAnalysis.Name = "lstAnalysis";
            this.lstAnalysis.Size = new System.Drawing.Size(411, 132);
            this.lstAnalysis.TabIndex = 0;
            this.lstAnalysis.UseCompatibleStateImageBehavior = false;
            // 
            // FrmAnalysisList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 283);
            this.Controls.Add(this.lstAnalysis);
            this.Name = "FrmAnalysisList";
            this.Text = "FrmAnalysisList";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstAnalysis;
    }
}