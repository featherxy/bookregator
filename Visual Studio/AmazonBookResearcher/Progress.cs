using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BookResearcher
{
    public partial class Progress : Form
    {
        public Search Search;
        public CsvTable Table;

        public Progress(Search search)
        {
            InitializeComponent();
            Search = search;
            tableCompilation.WorkerReportsProgress = true;

            FormBorderStyle = FormBorderStyle.FixedDialog;
            ControlBox = false;
            MinimizeBox = false;
            MaximizeBox = false;

            compilationProgress.Minimum = 0;
            compilationProgress.Maximum = Search.TotalRequests;
            compilationProgress.Value = 0;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(this.Search.CurrentRequest);
            stringBuilder.Append("/");
            stringBuilder.Append(this.Search.TotalRequests);
            stringBuilder.Append(" requests processed");
            SetMessage(stringBuilder.ToString());

        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            ActiveControl = null;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            tableCompilation.RunWorkerAsync();
        }

        public void SetMessage(String message)
        {
            this.message.Text = message;
        }

        private void tableCompilation_DoWork(object sender, DoWorkEventArgs e)
        {
            Table = Search.CreateTable(this.tableCompilation);
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)Close);
                return;
            } 
        }

        private void tableCompilation_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(Search.CurrentRequest);
            stringBuilder.Append("/");
            stringBuilder.Append(Search.TotalRequests);
            stringBuilder.Append(" requests processed");
            compilationProgress.Value = e.ProgressPercentage;
            SetMessage(stringBuilder.ToString());
        }

        private void tableCompilation_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }


    }
}
