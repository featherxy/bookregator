using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BookResearcher.WorldCat
{
    public partial class WorldCatForm : Form
    {
        private Stream ISBN;

        private static readonly String[] helpInfo = new[]
        {
            "The ISBN list is a .txt file that has each requested ISBN number of a book to be researched seperated by a new line.",
            "",
            "By checking a box in the checkbox list of data elements the corresponding data will be compiled into a table for each ISBN in the ISBN list."
        };

        private static readonly String[] elementConstants = new[]
        {
            "author",
            "title",
            "year",
            "oldestYear",
            "publisher",
            "city",
            "ed",
            "url",
            "lccn",
            "oclcnum",
            "form",
            "originalLang",
            "lang"
        };

        public WorldCatForm()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.FixedDialog;
            MinimizeBox = false;
            MaximizeBox = false;

            compiledTableDialog.Filter = "Csv File|*.csv";
            compiledTableDialog.Title = "Output Location";
            compiledTableDialog.FileName = "compiledTable.csv";

            ISBNDialog.Filter = "Txt File|*.txt";
            ISBNDialog.Title = "Open ISBN List";
            ISBNDialog.FileName = "ISBNList.txt";

            remainingRequestsDialog.Filter = "Txt File|*.txt";
            remainingRequestsDialog.Title = "Remaining requests";
            remainingRequestsDialog.FileName = "remainingISBNs.txt";
        }

        private void Search_Click(object sender, EventArgs e)
        {
            if(ISBN == null)
                new MMessageBox("ISBN list not selected.", "Error").ShowDialog();
            else
            {
                Stream outputStream;

                List<String> ISBNs = new List<string>();
                //Reads the requests to a temporary list, and the converts them
                //to an array
                using (TextReader txtReader = new StreamReader(ISBN))
                {
                    do
                    {
                        string line = txtReader.ReadLine();

                        if (line == null || line.Equals(""))
                            break;

                        ISBNs.Add(line);
                    } while (true);
                }

                var elements = (from int index in metaDataBox.CheckedIndices select elementConstants[index]).ToList();
                Search lookup = new WorldCatSearch(ISBNs.ToArray(), elements);
                Progress progress = new Progress(lookup);
                progress.ShowDialog();
                WorldCatSearch worldCatSearch = (WorldCatSearch)progress.Search;

                String finishMessage = ISBNs.Count + " requests compiled.";
                //Writes remaining results to file if fetching ends prematurely.
                //Occurs only if not an account error
                if (worldCatSearch.Error != null && !worldCatSearch.Error.Equals("Invalid account details (403)"))
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
                        for (int i = worldCatSearch.CurrentRequest; i < worldCatSearch.TotalRequests; i++)
                            textWriter.WriteLine(ISBNs[i]);
                    }

                    finishMessage = worldCatSearch.CurrentRequest + "/" + worldCatSearch.TotalRequests + " requests compiled.";
                }

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
                            new MMessageBox("File Currently in Use", "Error").Show();
                        }

                    }
                }

                using (CsvFileWriter csvFileWriter = new CsvFileWriter(outputStream))
                {
                    csvFileWriter.Write(progress.Table);
                    csvFileWriter.Close();
                }

                new MMessageBox(finishMessage, "Progress Report").ShowDialog();
                ClearStreams();
            }
           
        }

        private void isbnSelect_Click(object sender, EventArgs e)
        {
            if (ISBNDialog.ShowDialog() == DialogResult.OK)
            {
                if (ISBNDialog.FileName != "")
                    ISBN = ISBNDialog.OpenFile();
            }
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ClearStreams()
        {
            ISBN = null;
        }

        private void metaData_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void WorldCatSearch_Load(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new RichMessageBox("WorldCat Help", helpInfo).ShowDialog();
        }
    }
}
