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
    public partial class RichMessageBox : Form
    {
        public RichMessageBox(String title, String[] lines)
        {
            InitializeComponent();

            this.Text = title;
            messageBox.Lines = lines;
           
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MinimizeBox = false;
            MaximizeBox = false;


        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode.Equals(Keys.Escape))
                Close();
        }
    }
}
