using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BookResearcher.GoodReads
{
    public partial class GoodReadsLoadForm : Form
    {
        private readonly string key;

        public GoodReadsLoadForm(GoodReadsAccountDetails accountDetails)
        {
            InitializeComponent();

            ControlBox = false;
            MinimizeBox = false;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            key = accountDetails.Key;
        }

        private void useLoadedDetails_Click(object sender, EventArgs e)
        {
            GoodReadsSearch.Key = key;
            Close();
        }

        private void useDefaultDetails_Click(object sender, EventArgs e)
        {
            GoodReadsSearch.SetDefaultAccountDetails();
            Close();
        }
    }
}
