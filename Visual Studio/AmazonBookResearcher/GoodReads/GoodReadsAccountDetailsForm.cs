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
using System.Xml;

namespace BookResearcher.GoodReads
{
    public partial class GoodReadsAccountDetailsForm : Form
    {
        public GoodReadsAccountDetailsForm()
        {
            InitializeComponent();

            ControlBox = false;
            MaximizeBox = false;
            MinimizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void saveAndClose_Click(object sender, EventArgs e)
        {
            if(key.Text == null || key.Text.Equals(""))
            {
                new MMessageBox("Key required", "Error").ShowDialog();
                return;
            }

            XmlDocument doc = new XmlDocument();
            try
            {
                bool nullReference = true;
                doc.Load("http://www.goodreads.com/search/index.xml?key=" + key.Text);
                if (doc.InnerXml == null || doc.InnerXml.Equals(""))
                    throw new XmlException("XML incorrect format");
            }
            catch (Exception)
            {
                new MMessageBox("Invalid details.", "Error").ShowDialog();
                return;
            }

            //Store key and secretKey
            GoodReadsSearch.Key = key.Text;

            //If the account details are valid, save to file.
            GoodReadsAccountDetails accountDetails = new GoodReadsAccountDetails();
            accountDetails.Key = GoodReadsSearch.Key;
            Stream fileStream = File.OpenWrite("GoodReadsSettings.bin");
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fileStream, accountDetails);
            fileStream.Close();
            Close();
        }

        private void useDefault_Click(object sender, EventArgs e)
        {
            GoodReadsSearch.SetDefaultAccountDetails();
            Close();
        }
    }
}
