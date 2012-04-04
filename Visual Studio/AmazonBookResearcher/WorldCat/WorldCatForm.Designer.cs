namespace BookResearcher.WorldCat
{
    partial class WorldCatForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Search = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.isbnSelect = new System.Windows.Forms.Button();
            this.ISBNDialog = new System.Windows.Forms.OpenFileDialog();
            this.compiledTableDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metaDataBox = new System.Windows.Forms.CheckedListBox();
            this.remainingRequestsDialog = new System.Windows.Forms.SaveFileDialog();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(12, 221);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(257, 23);
            this.Search.TabIndex = 0;
            this.Search.Text = "Compile Table";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ISBN List";
            // 
            // isbnSelect
            // 
            this.isbnSelect.Location = new System.Drawing.Point(136, 31);
            this.isbnSelect.Name = "isbnSelect";
            this.isbnSelect.Size = new System.Drawing.Size(75, 23);
            this.isbnSelect.TabIndex = 3;
            this.isbnSelect.Text = "Select";
            this.isbnSelect.UseVisualStyleBackColor = true;
            this.isbnSelect.Click += new System.EventHandler(this.isbnSelect_Click);
            // 
            // ISBNDialog
            // 
            this.ISBNDialog.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(280, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuItem
            // 
            this.MenuItem.Name = "MenuItem";
            this.MenuItem.Size = new System.Drawing.Size(50, 20);
            this.MenuItem.Text = "Menu";
            this.MenuItem.Click += new System.EventHandler(this.Menu_Click);
            // 
            // metaDataBox
            // 
            this.metaDataBox.FormattingEnabled = true;
            this.metaDataBox.Items.AddRange(new object[] {
            "Author",
            "Title",
            "Year of Publication",
            "Oldest Year of Publication",
            "Publisher",
            "City of Publication",
            "Edition",
            "URL to web resource",
            "Library of Congress Control Number",
            "OCLC Number",
            "ONIX Production Code",
            "Original Language",
            "MARC Language Code"});
            this.metaDataBox.Location = new System.Drawing.Point(12, 60);
            this.metaDataBox.Name = "metaDataBox";
            this.metaDataBox.Size = new System.Drawing.Size(257, 154);
            this.metaDataBox.TabIndex = 18;
            this.metaDataBox.SelectedIndexChanged += new System.EventHandler(this.metaData_SelectedIndexChanged);
            // 
            // remainingRequestsDialog
            // 
            this.remainingRequestsDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // WorldCatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 256);
            this.Controls.Add(this.metaDataBox);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.isbnSelect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Search);
            this.Name = "WorldCatForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "WorldCat Search";
            this.Load += new System.EventHandler(this.WorldCatSearch_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button isbnSelect;
        private System.Windows.Forms.OpenFileDialog ISBNDialog;
        private System.Windows.Forms.SaveFileDialog compiledTableDialog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuItem;
        private System.Windows.Forms.CheckedListBox metaDataBox;
        private System.Windows.Forms.SaveFileDialog remainingRequestsDialog;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    }
}