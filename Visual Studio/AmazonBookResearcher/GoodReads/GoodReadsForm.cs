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


namespace BookResearcher.GoodReads
{
    public partial class GoodReadsForm : Form
    {
        public static readonly String[] RequestConstants =
            {
                "title",
                "name",
                "average_rating",
                "ratings_count",
                "text_reviews_count",
                "original_publication_day",
                "original_publication_month",
                "original_publication_year"
            };
        private static readonly String[] helpInfo = new[]
        {
            "The requests list is a .txt file that has each requested book title or ISBN number each seperated by a new line.",
            "",
            "By checking a box in the checkbox list of data elements the corresponding data will be compiled into a table for each ISBN in the ISBN list.",
            "",
            "At the account management page on the GoodReads website a api key can be obtained and used with this program by clicking on the account details button. Link to GoodReads website: http://www.goodreads.com/"
        };

        private Stream requestInput;

        public GoodReadsForm()
        {
            InitializeComponent();

            MaximizeBox = false;
            MinimizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            openRequestDialog.Filter = "Txt File|*.txt";
            openRequestDialog.Title = "Open Request List";
            openRequestDialog.FileName = "RequestList.txt";

            remainingRequestsDialog.Filter = "Txt File|*.txt";
            remainingRequestsDialog.Title = "Save Remaining Requests";
            remainingRequestsDialog.FileName = "RemainingRequests.txt";

            compileTableDialog.Filter = "Csv File|*.csv";
            compileTableDialog.Title = "Output Location";
            compileTableDialog.FileName = "compiledTable.csv";

            //Loads the account details from previous session, if any, and 
            //informs the user.
            try
            {
                FileStream fileStream = new FileStream("GoodReadsSettings.bin", FileMode.Open);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                GoodReadsAccountDetails accountDetails = binaryFormatter.Deserialize(fileStream) as GoodReadsAccountDetails;

                if (accountDetails == null)
                    throw new FileNotFoundException();

                new GoodReadsLoadForm(accountDetails).ShowDialog();
                fileStream.Close();
            }
            catch (FileNotFoundException) { }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode.Equals(Keys.Escape))
                Close();
        }

        private void requestList_Click(object sender, EventArgs e)
        {
            if (openRequestDialog.ShowDialog() == DialogResult.OK)
            {
                if (openRequestDialog.FileName != "")
                    requestInput = openRequestDialog.OpenFile();
            }  
        }

        private void compileTable_Click(object sender, EventArgs e)
        {
            if(requestInput == null)
            {
                new MMessageBox("Request list not selected.", "Error").ShowDialog();
                return;
            }

            Stream output;
            List<String> temp = new List<String>();

            //Create requests array
            using(TextReader textReader = new StreamReader(requestInput))
            {
                do
                {
                    string line = textReader.ReadLine();

                    if (line == null || line.Equals(""))
                        break;

                    temp.Add(line);
                } while (true);
            }
            string[] requests = temp.ToArray();
            temp.Clear();

            //Create elements array
            temp = (from int element in requestCheckBox.CheckedIndices select RequestConstants[element]).ToList();
            string[] elements = temp.ToArray();
            temp.Clear();

            //Create table header array
            temp.AddRange(requestCheckBox.CheckedItems.Cast<string>());
            String[] tableHeader = temp.ToArray();

            GoodReadsSearch search = new GoodReadsSearch(requests, elements, tableHeader);
            Progress progress = new Progress(search);
            progress.ShowDialog();
            search = (GoodReadsSearch)progress.Search;

            String finishMessage = requests.Length + " requests compiled.";
            //Writes remaining results to file if fetching ends prematurely.
            //Occurs only if not an account error
            if (search.Error != null)
            {
                //progressWindow.SetMessage("Saving Remaining Requests");
                Stream remainingResultsOutput;

                while (true)
                {
                    if (remainingRequestsDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            if (remainingRequestsDialog.FileName != "")
                            {
                                remainingResultsOutput = remainingRequestsDialog.OpenFile();
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
                    for (int i = search.CurrentRequest; i < search.TotalRequests; i++)
                        textWriter.WriteLine(requests[i]);
                }

                finishMessage = search.CurrentRequest + "/" + search.TotalRequests + " requests compiled.";
            }

            while (true)
            {
                if (compileTableDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (compileTableDialog.FileName != "")
                        {
                            output = compileTableDialog.OpenFile();
                            break;
                        }
                    }
                    catch (Exception)
                    {
                        new MMessageBox("File Currently in Use", "Error").Show();
                    }

                }
            }

            using (CsvFileWriter csvFileWriter = new CsvFileWriter(output))
            {
                csvFileWriter.Write(progress.Table);
                csvFileWriter.Close();
            }

            new MMessageBox(finishMessage, "Task Report").ShowDialog();
            ClearStreams();
        }

        private void accountDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new GoodReadsAccountDetailsForm().ShowDialog();
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ClearStreams()
        {
            requestInput = null;
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new RichMessageBox("GoodReads Help", helpInfo).ShowDialog();
        }
    }
}
