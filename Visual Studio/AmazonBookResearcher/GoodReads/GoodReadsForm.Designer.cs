namespace BookResearcher.GoodReads
{
    partial class GoodReadsForm
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
            this.requestListSelect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.requestCheckBox = new System.Windows.Forms.CheckedListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compileTable = new System.Windows.Forms.Button();
            this.openRequestDialog = new System.Windows.Forms.OpenFileDialog();
            this.compileTableDialog = new System.Windows.Forms.SaveFileDialog();
            this.remainingRequestsDialog = new System.Windows.Forms.SaveFileDialog();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // requestListSelect
            // 
            this.requestListSelect.Location = new System.Drawing.Point(139, 24);
            this.requestListSelect.Name = "requestListSelect";
            this.requestListSelect.Size = new System.Drawing.Size(75, 23);
            this.requestListSelect.TabIndex = 0;
            this.requestListSelect.Text = "Select";
            this.requestListSelect.UseVisualStyleBackColor = true;
            this.requestListSelect.Click += new System.EventHandler(this.requestList_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Request List";
            // 
            // requestCheckBox
            // 
            this.requestCheckBox.FormattingEnabled = true;
            this.requestCheckBox.Items.AddRange(new object[] {
            "Title",
            "Author",
            "Average Rating",
            "Ratings Count",
            "Text Reviews Count",
            "Publication Day",
            "Publication Month",
            "Publication Year"});
            this.requestCheckBox.Location = new System.Drawing.Point(12, 53);
            this.requestCheckBox.Name = "requestCheckBox";
            this.requestCheckBox.Size = new System.Drawing.Size(244, 154);
            this.requestCheckBox.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.accountDetailsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(269, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            this.menuToolStripMenuItem.Click += new System.EventHandler(this.menuToolStripMenuItem_Click);
            // 
            // accountDetailsToolStripMenuItem
            // 
            this.accountDetailsToolStripMenuItem.Name = "accountDetailsToolStripMenuItem";
            this.accountDetailsToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.accountDetailsToolStripMenuItem.Text = "Account Details";
            this.accountDetailsToolStripMenuItem.Click += new System.EventHandler(this.accountDetailsToolStripMenuItem_Click);
            // 
            // compileTable
            // 
            this.compileTable.Location = new System.Drawing.Point(12, 213);
            this.compileTable.Name = "compileTable";
            this.compileTable.Size = new System.Drawing.Size(244, 23);
            this.compileTable.TabIndex = 4;
            this.compileTable.Text = "Compile Table";
            this.compileTable.UseVisualStyleBackColor = true;
            this.compileTable.Click += new System.EventHandler(this.compileTable_Click);
            // 
            // openRequestDialog
            // 
            this.openRequestDialog.SupportMultiDottedExtensions = true;
            this.openRequestDialog.ValidateNames = false;
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // GoodReadsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 243);
            this.Controls.Add(this.compileTable);
            this.Controls.Add(this.requestCheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.requestListSelect);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GoodReadsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GoodReads Search";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button requestListSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox requestCheckBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountDetailsToolStripMenuItem;
        private System.Windows.Forms.Button compileTable;
        private System.Windows.Forms.OpenFileDialog openRequestDialog;
        private System.Windows.Forms.SaveFileDialog compileTableDialog;
        private System.Windows.Forms.SaveFileDialog remainingRequestsDialog;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    }
}