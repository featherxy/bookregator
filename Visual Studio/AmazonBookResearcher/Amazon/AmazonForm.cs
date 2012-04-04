using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace BookResearcher
{
    public partial class AmazonForm : Form
    {
        public static readonly String DEFAULT_YEAR = "2011-08-01"; 
        public static readonly String DEFAULT_INCLUDE_REVIEWS_SUMMARY = "false";
        public static readonly String DEFAULT_OPERATION = "ItemSearch";
        public static readonly String DEFAULT_SERVICE = "AWSECommerceService";
        public static readonly String DEFAULT_SEARCH_INDEX = "All";
        public static readonly String DEFAULT_AWS_NAMESPACE = "http://webservices.amazon.com/AWSECommerceService/2011-08-01";

        private AmazonSearch search;
        public static String ResponseGroupURL;
        private Stream       inputStream;
        private String[]     helpInfo;

        public AmazonForm()
        {
            InitializeComponent();
            ClearStreams();
            MaximizeBox = false;
            MinimizeBox = false;
            KeyPreview = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            yearTextBox.Text = DEFAULT_YEAR;
            includeTextBox.Text = DEFAULT_INCLUDE_REVIEWS_SUMMARY;
            operationTextBox.Text = DEFAULT_OPERATION;
            serviceTextBox.Text = DEFAULT_SERVICE;
            searchIndexTextBox.Text = DEFAULT_SEARCH_INDEX;
            awsNamespaceTextBox.Text = DEFAULT_AWS_NAMESPACE;

            ISBNDialog.Filter = "Txt File|*.txt";
            ISBNDialog.Title = "Save ISBN list";
            ISBNDialog.FileName = "ISBNList.txt";

            elementsDialog.Filter = "Txt File|*.txt";
            elementsDialog.Title = "Open Element list";
            elementsDialog.FileName = "elementList.txt";

            requestsDialog.Filter = "Txt File|*.txt";
            requestsDialog.Title = "Open Request List";
            requestsDialog.FileName = "requestList.txt";

            compiledTableDialog.Filter = "Csv File|*.csv";
            compiledTableDialog.Title = "Save compiled table";
            compiledTableDialog.FileName = "compiledTable.csv";

            remainingResultsDialog.Filter = "Txt File|*.txt";
            remainingResultsDialog.Title = "Remaining requests";
            remainingResultsDialog.FileName = "remainingRequests.txt";

            amazonElements.Links.Add(0, amazonElements.Text.Length,
                "http://docs.amazonwebservices.com/AWSECommerceService/2010-11-01/DG/CHAP_ResponseGroupsList.html");
            ResponseGroupURL = "http://docs.amazonwebservices.com/AWSECommerceService/2011-08-01/DG/";
            helpInfo = new[]
            {
                "The requests list is a .txt file that has each requested book title or ISBN number each seperated by a new line.",
                "",
                "A response group is a container for the elements. Each response group in the list will request different elements of data for the request list. To see the listing of elements  for each response group click the link at the bottom.",
                "",
                "An element is a piece of data related to the request.",
                "",
                "At the account management screen of the Amazon Product Advertising API under in access identifiers box you can find Access Key ID and the Secret Access Key required to search with a personal Amazon Product advertising Account. Link to the management and signup page for Amazon Product Advertising accounts: https://affiliate-program.amazon.com/gp/flex/advertising/api/sign-in.html",
                "",
                "Response Group documentation: http://docs.amazonwebservices.com/AWSECommerceService/2010-11-01/DG/index.html?CHAP_ResponseGroupsList.html"
            };

            search = new AmazonSearch();
            search.Load();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode.Equals(Keys.Escape))
                Close();
        }

        private void inputBrowse_Click(object sender, EventArgs e)
        {
            if (requestsDialog.ShowDialog() == DialogResult.OK)
            {
                if (requestsDialog.FileName != "")
                    inputStream = requestsDialog.OpenFile();
            }
        }

        private void compileTable_Click(object sender, EventArgs e)
        {
            if (inputStream == null)
                new MMessageBox("Input list not selected.", "Error").ShowDialog();

            else if (responseGroupBox.Text == null || responseGroupBox.Text.Equals(""))
                new MMessageBox("No response group entered.", "Error").ShowDialog();

            else if (String.IsNullOrEmpty(search.SecretKey) || String.IsNullOrEmpty(search.AccessKeyId) || String.IsNullOrEmpty(search.AssociateTag))
                new MMessageBox("No account details loaded.", "Error").ShowDialog();
            else
                Search();
        }

        private void Search()
        {
            var requests = new List<String>();
            //Reads the requests to a temporary list, and the converts them
            //to an array
            using (TextReader txtReader = new StreamReader(inputStream))
            {
                do
                {
                    string line = txtReader.ReadLine();

                    if (line == null || line.Equals(""))
                        break;

                    requests.Add(line);
                } while (true);
                txtReader.Close();
            }

            
            Search lookup = new AmazonSearch(search, ISBNCheck.Checked, requests.ToArray(), 
                amazonElementsTextBox.Lines, responseGroupBox.Text, yearTextBox.Text, 
                includeTextBox.Text, operationTextBox.Text, serviceTextBox.Text, 
                searchIndexTextBox.Text, awsNamespaceTextBox.Text); 
            //FIX THIS
            var progress = new Progress(lookup);
            progress.ShowDialog();
            var amazonSearch = (AmazonSearch)progress.Search;

            Stream outputStream;
            while (true)
            {
                if (compiledTableDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (compiledTableDialog.FileName != "")
                        {
                            outputStream = compiledTableDialog.OpenFile();
                            break;
                        }
                    }
                    catch (Exception)
                    {
                        new MMessageBox("File Currently in Use", "Error").ShowDialog();
                    }
                }
            }

            //Writes the CsvTable to file););
            using (CsvFileWriter csvFileWriter = new CsvFileWriter(outputStream))
            {
                csvFileWriter.Write(progress.Table);
                csvFileWriter.Close();
            }

            String finishMessage = amazonSearch.Requests.Count() + " requests compiled.";

            //Writes remaining results to file if fetching ends prematurely.
            //Occurs only if not an account error
            if (amazonSearch.Error != null && !amazonSearch.Error.Equals("Invalid account details (403)"))
            {
                //progressWindow.SetMessage("Saving Remaining Requests");
                Stream remainingResultsOutput;

                while (true)
                {
                    if (remainingResultsDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            if (remainingResultsDialog.FileName != "")
                            {
                                remainingResultsOutput = remainingResultsDialog.OpenFile();
                                break;
                            }
                        }
                        catch (Exception)
                        {
                            new MMessageBox("File Currently in Use", "Error").Show();
                        }

                    }
                }

                using (TextWriter textWriter = new StreamWriter(remainingResultsOutput))
                {
                    for (int i = amazonSearch.CurrentRequest; i < amazonSearch.TotalRequests; i++)
                        textWriter.WriteLine(amazonSearch.Requests[i]);
                }

                finishMessage = (amazonSearch.CurrentRequest) + "/" + amazonSearch.Requests.Length + " requests compiled.";
            }

            //Save the ISBN List
            if (ISBNCheck.Checked)
            {
                Stream ISBNOutput;
                while (true)
                {
                    if (ISBNDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            if (ISBNDialog.FileName != "")
                            {
                                ISBNOutput = ISBNDialog.OpenFile();
                                break;
                            }
                        }
                        catch (Exception)
                        {
                            new MMessageBox("File Currently in Use", "Error").ShowDialog();
                        }
                    }
                }

                using (TextWriter textWriter = new StreamWriter(ISBNOutput))
                {
                   foreach(String ISBN in amazonSearch.Isbns)
                       textWriter.WriteLine(ISBN);
                }
            }

            new MMessageBox(finishMessage, "Progress Report").ShowDialog();
            ClearStreams();
        }

        private void ClearStreams()
        {
            inputStream = null;
        }

        private void returnToMenu_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void amazonElements_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String link = ResponseGroupURL;
            try
            {
                System.Diagnostics.Process.Start("IExplore", link);
            }
            catch (Exception)
            {
                new MMessageBox(link, "IExplore not found");
                throw;
            }
        }

        private void help_Click(object sender, EventArgs e)
        {
            new RichMessageBox("Amazon Help", helpInfo).ShowDialog();
        }

        private void accountDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AmazonAccountDetails(search).ShowDialog();
        }
    }
}
