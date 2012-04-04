using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;


namespace BookResearcher
{
    public partial class AmazonAccountDetails : Form
    {
        AmazonSearch search;

        public AmazonAccountDetails(AmazonSearch search)
        {
            InitializeComponent();
            this.search = search;

            accessKeyId.Text = search.AccessKeyId;
            secretKey.Text = search.SecretKey;
            associateTag.Text = search.AssociateTag;

            ControlBox = false;
            MaximizeBox = false;
            MinimizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void save_Click(object sender, EventArgs e)
        {
            close.Enabled = false;
            String error = AmazonSearch.validateAccountDetails(accessKeyId.Text, secretKey.Text, associateTag.Text);
            if (error == null) // valid
            {
                search.AccessKeyId = accessKeyId.Text;
                search.SecretKey = secretKey.Text;
                search.AssociateTag = associateTag.Text;
                search.Save();
            }
            else
            {
                MessageBox.Show(error);
            }
            close.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}