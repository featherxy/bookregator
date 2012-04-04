namespace BookResearcher
{
    partial class Progress
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
            this.message = new System.Windows.Forms.TextBox();
            this.tableCompilation = new System.ComponentModel.BackgroundWorker();
            this.compilationProgress = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // message
            // 
            this.message.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.message.BackColor = System.Drawing.SystemColors.Control;
            this.message.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.message.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.message.Location = new System.Drawing.Point(12, 20);
            this.message.Name = "message";
            this.message.ReadOnly = true;
            this.message.Size = new System.Drawing.Size(187, 13);
            this.message.TabIndex = 3;
            this.message.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.message.WordWrap = false;
            // 
            // tableCompilation
            // 
            this.tableCompilation.DoWork += new System.ComponentModel.DoWorkEventHandler(this.tableCompilation_DoWork);
            this.tableCompilation.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.tableCompilation_ProgressChanged);
            this.tableCompilation.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.tableCompilation_RunWorkerCompleted);
            // 
            // compilationProgress
            // 
            this.compilationProgress.Location = new System.Drawing.Point(12, 52);
            this.compilationProgress.Name = "compilationProgress";
            this.compilationProgress.Size = new System.Drawing.Size(182, 23);
            this.compilationProgress.TabIndex = 4;
            // 
            // ProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(206, 87);
            this.Controls.Add(this.compilationProgress);
            this.Controls.Add(this.message);
            this.Name = "ProgressForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Progress";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox message;
        private System.ComponentModel.BackgroundWorker tableCompilation;
        private System.Windows.Forms.ProgressBar compilationProgress;
    }
}