using System;
using System.Windows.Forms;
using BookResearcher.GoodReads;
using BookResearcher.WorldCat;

namespace BookResearcher
{
    public partial class Menu : Form
    {
        private static readonly String[] helpInfo = new []
        {
            "Book Search is an application designed to research a multitude of information from numerous databases about a list of book titles. After gathering the data the program will then compile a .csv table that can be manipulated most database programs. It currently has access to Amazon, WorldCat, and GoodReads which are the three most used book databases. Click a database and get researching!",
        };

        public Menu()
        {
            InitializeComponent();
            MaximizeBox = false;
            MinimizeBox = false;
            KeyPreview = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode.Equals(Keys.Escape))
                Close();
        }

        private void amazon_Click(object sender, EventArgs e)
        {
            Visible = false;
            new AmazonForm().ShowDialog();
            Visible = true;
           
        }

        private void worldCat_Click(object sender, EventArgs e)
        {
            Visible = false;
            new WorldCatForm().ShowDialog();
            Visible = true;
        }

        private void goodReads_Click(object sender, EventArgs e)
        {
            Visible = false;
            new GoodReadsForm().ShowDialog();
            Visible = true;
        }

        private void help_Click(object sender, EventArgs e)
        {
            new RichMessageBox("Menu Help", helpInfo).ShowDialog();
        }
    }
}
