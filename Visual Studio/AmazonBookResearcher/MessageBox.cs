using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BookResearcher
{
    public partial class MMessageBox  : Form
    {
        public MMessageBox(String message)
        {
            InitializeComponent();
            this.message.Text = message;

            KeyPreview = true;
            if (Parent == null)
                StartPosition = FormStartPosition.CenterScreen;

            FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        public MMessageBox(String message, String title) : this(message)
        {
            Text = title;
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            ActiveControl = null;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        public void SetMessage(String message)
        {
            this.message.Text = message;
            Update();
        }

        public void Center()
        {
            CenterToScreen();
            Update();
        }

        private void Alert_Load(object sender, EventArgs e)
        {

        }

        private void message_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
