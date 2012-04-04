using System.Windows.Forms;

namespace BookResearcher
{
    partial class AmazonForm : Form
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
            this.compileTable = new System.Windows.Forms.Button();
            this.requestListLabel = new System.Windows.Forms.Label();
            this.requestsDialog = new System.Windows.Forms.OpenFileDialog();
            this.inputBrowse = new System.Windows.Forms.Button();
            this.compiledTableDialog = new System.Windows.Forms.SaveFileDialog();
            this.elementLabel = new System.Windows.Forms.Label();
            this.elementsDialog = new System.Windows.Forms.OpenFileDialog();
            this.remainingResultsDialog = new System.Windows.Forms.SaveFileDialog();
            this.responseGroupLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.returnToMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.accountDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.help = new System.Windows.Forms.ToolStripMenuItem();
            this.ISBNCheck = new System.Windows.Forms.CheckBox();
            this.ISBNDialog = new System.Windows.Forms.SaveFileDialog();
            this.responseGroupBox = new System.Windows.Forms.ComboBox();
            this.amazonElementsTextBox = new System.Windows.Forms.RichTextBox();
            this.amazonElements = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.yearTextBox = new System.Windows.Forms.TextBox();
            this.includeTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.operationTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.serviceTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.awsNamespaceTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.searchIndexTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // compileTable
            // 
            this.compileTable.Location = new System.Drawing.Point(13, 232);
            this.compileTable.Name = "compileTable";
            this.compileTable.Size = new System.Drawing.Size(558, 23);
            this.compileTable.TabIndex = 6;
            this.compileTable.Text = "Compile Table";
            this.compileTable.UseVisualStyleBackColor = true;
            this.compileTable.Click += new System.EventHandler(this.compileTable_Click);
            // 
            // requestListLabel
            // 
            this.requestListLabel.AutoSize = true;
            this.requestListLabel.Location = new System.Drawing.Point(21, 57);
            this.requestListLabel.Name = "requestListLabel";
            this.requestListLabel.Size = new System.Drawing.Size(66, 13);
            this.requestListLabel.TabIndex = 7;
            this.requestListLabel.Text = "Request List";
            // 
            // requestsDialog
            // 
            this.requestsDialog.FileName = "openFileDialog1";
            // 
            // inputBrowse
            // 
            this.inputBrowse.Location = new System.Drawing.Point(105, 52);
            this.inputBrowse.Name = "inputBrowse";
            this.inputBrowse.Size = new System.Drawing.Size(121, 23);
            this.inputBrowse.TabIndex = 9;
            this.inputBrowse.Text = "Browse";
            this.inputBrowse.UseVisualStyleBackColor = true;
            this.inputBrowse.Click += new System.EventHandler(this.inputBrowse_Click);
            // 
            // elementLabel
            // 
            this.elementLabel.AutoSize = true;
            this.elementLabel.Location = new System.Drawing.Point(21, 152);
            this.elementLabel.Name = "elementLabel";
            this.elementLabel.Size = new System.Drawing.Size(64, 13);
            this.elementLabel.TabIndex = 12;
            this.elementLabel.Text = "Element List";
            // 
            // elementsDialog
            // 
            this.elementsDialog.FileName = "openFileDialog1";
            // 
            // responseGroupLabel
            // 
            this.responseGroupLabel.AutoSize = true;
            this.responseGroupLabel.Location = new System.Drawing.Point(12, 85);
            this.responseGroupLabel.Name = "responseGroupLabel";
            this.responseGroupLabel.Size = new System.Drawing.Size(87, 13);
            this.responseGroupLabel.TabIndex = 15;
            this.responseGroupLabel.Text = "Response Group";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.returnToMenu,
            this.accountDetailsToolStripMenuItem,
            this.help});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(585, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // returnToMenu
            // 
            this.returnToMenu.Name = "returnToMenu";
            this.returnToMenu.Size = new System.Drawing.Size(50, 20);
            this.returnToMenu.Text = "Menu";
            this.returnToMenu.Click += new System.EventHandler(this.returnToMenu_Click);
            // 
            // accountDetailsToolStripMenuItem
            // 
            this.accountDetailsToolStripMenuItem.Name = "accountDetailsToolStripMenuItem";
            this.accountDetailsToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.accountDetailsToolStripMenuItem.Text = "Account Details";
            this.accountDetailsToolStripMenuItem.Click += new System.EventHandler(this.accountDetailsToolStripMenuItem_Click);
            // 
            // help
            // 
            this.help.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(44, 20);
            this.help.Text = "Help";
            this.help.Click += new System.EventHandler(this.help_Click);
            // 
            // ISBNCheck
            // 
            this.ISBNCheck.AutoSize = true;
            this.ISBNCheck.Location = new System.Drawing.Point(38, 211);
            this.ISBNCheck.Name = "ISBNCheck";
            this.ISBNCheck.Size = new System.Drawing.Size(172, 17);
            this.ISBNCheck.TabIndex = 17;
            this.ISBNCheck.Text = "Compile ISBN list from requests";
            this.ISBNCheck.UseVisualStyleBackColor = true;
            // 
            // responseGroupBox
            // 
            this.responseGroupBox.FormattingEnabled = true;
            this.responseGroupBox.Items.AddRange(new object[] {
            "Small",
            "Medium",
            "Large",
            "SalesRank",
            "Accessories",
            "AlternateVersions",
            "BrowseNodeInfo",
            "BrowseNodes",
            "Cart",
            "CartNewReleases",
            "CartTopSellers",
            "CartSimilarities",
            "Collections",
            "EditorialReview",
            "Images",
            "ItemAttributes",
            "ItemIds",
            "MostGifted",
            "MostWishedFor",
            "NewReleases",
            "OfferFull",
            "OfferListings",
            "Offers",
            "OfferSummary",
            "PromotionSummary",
            "RelatedItems",
            "Request",
            "Reviews",
            "SearchBins",
            "Seller",
            "SellerListing",
            "TopSellers",
            "Tracks",
            "Variations",
            "VariationImages",
            "VariationMatrix",
            "VariationOffers",
            "VariationSummary"});
            this.responseGroupBox.Location = new System.Drawing.Point(105, 82);
            this.responseGroupBox.Name = "responseGroupBox";
            this.responseGroupBox.Size = new System.Drawing.Size(121, 21);
            this.responseGroupBox.TabIndex = 18;
            // 
            // amazonElementsTextBox
            // 
            this.amazonElementsTextBox.Location = new System.Drawing.Point(105, 109);
            this.amazonElementsTextBox.Name = "amazonElementsTextBox";
            this.amazonElementsTextBox.Size = new System.Drawing.Size(121, 96);
            this.amazonElementsTextBox.TabIndex = 21;
            this.amazonElementsTextBox.Text = "";
            // 
            // amazonElements
            // 
            this.amazonElements.ActiveLinkColor = System.Drawing.Color.Blue;
            this.amazonElements.AutoSize = true;
            this.amazonElements.DisabledLinkColor = System.Drawing.Color.Blue;
            this.amazonElements.ForeColor = System.Drawing.Color.Blue;
            this.amazonElements.LinkColor = System.Drawing.Color.Blue;
            this.amazonElements.Location = new System.Drawing.Point(7, 165);
            this.amazonElements.Name = "amazonElements";
            this.amazonElements.Size = new System.Drawing.Size(91, 13);
            this.amazonElements.TabIndex = 22;
            this.amazonElements.TabStop = true;
            this.amazonElements.Text = "Amazon Elements";
            this.amazonElements.VisitedLinkColor = System.Drawing.Color.Blue;
            this.amazonElements.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.amazonElements_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Basic Settings";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(313, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(243, 26);
            this.label2.TabIndex = 24;
            this.label2.Text = "Advanced Settings \r\n(Do not modify without knowledge of Amazon API)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(356, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Year";
            // 
            // yearTextBox
            // 
            this.yearTextBox.Location = new System.Drawing.Point(391, 60);
            this.yearTextBox.Name = "yearTextBox";
            this.yearTextBox.Size = new System.Drawing.Size(180, 20);
            this.yearTextBox.TabIndex = 26;
            // 
            // includeTextBox
            // 
            this.includeTextBox.Location = new System.Drawing.Point(391, 86);
            this.includeTextBox.Name = "includeTextBox";
            this.includeTextBox.Size = new System.Drawing.Size(180, 20);
            this.includeTextBox.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(253, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Include Reviews Summary";
            // 
            // operationTextBox
            // 
            this.operationTextBox.Location = new System.Drawing.Point(391, 112);
            this.operationTextBox.Name = "operationTextBox";
            this.operationTextBox.Size = new System.Drawing.Size(180, 20);
            this.operationTextBox.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(332, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Operation";
            // 
            // serviceTextBox
            // 
            this.serviceTextBox.Location = new System.Drawing.Point(391, 138);
            this.serviceTextBox.Name = "serviceTextBox";
            this.serviceTextBox.Size = new System.Drawing.Size(180, 20);
            this.serviceTextBox.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(342, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Service";
            // 
            // awsNamespaceTextBox
            // 
            this.awsNamespaceTextBox.Location = new System.Drawing.Point(391, 190);
            this.awsNamespaceTextBox.Name = "awsNamespaceTextBox";
            this.awsNamespaceTextBox.Size = new System.Drawing.Size(180, 20);
            this.awsNamespaceTextBox.TabIndex = 36;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(298, 193);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "Aws Namespace";
            // 
            // searchIndexTextBox
            // 
            this.searchIndexTextBox.Location = new System.Drawing.Point(391, 164);
            this.searchIndexTextBox.Name = "searchIndexTextBox";
            this.searchIndexTextBox.Size = new System.Drawing.Size(180, 20);
            this.searchIndexTextBox.TabIndex = 34;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(315, 167);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "Search Index";
            // 
            // AmazonForm
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 262);
            this.Controls.Add(this.awsNamespaceTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.searchIndexTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.serviceTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.operationTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.includeTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.yearTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.amazonElements);
            this.Controls.Add(this.amazonElementsTextBox);
            this.Controls.Add(this.responseGroupBox);
            this.Controls.Add(this.ISBNCheck);
            this.Controls.Add(this.responseGroupLabel);
            this.Controls.Add(this.elementLabel);
            this.Controls.Add(this.inputBrowse);
            this.Controls.Add(this.requestListLabel);
            this.Controls.Add(this.compileTable);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AmazonForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Amazon Search";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button compileTable;
        private System.Windows.Forms.Label requestListLabel;
        private System.Windows.Forms.OpenFileDialog requestsDialog;
        private System.Windows.Forms.Button inputBrowse;
        private System.Windows.Forms.SaveFileDialog compiledTableDialog;
        private System.Windows.Forms.Label elementLabel;
        private System.Windows.Forms.OpenFileDialog elementsDialog;
        private System.Windows.Forms.SaveFileDialog remainingResultsDialog;
        private System.Windows.Forms.Label responseGroupLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem accountDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem returnToMenu;
        private System.Windows.Forms.SaveFileDialog ISBNDialog;
        public System.Windows.Forms.CheckBox ISBNCheck;
        private System.Windows.Forms.ComboBox responseGroupBox;
        private System.Windows.Forms.RichTextBox amazonElementsTextBox;
        private System.Windows.Forms.LinkLabel amazonElements;
        private System.Windows.Forms.ToolStripMenuItem help;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox yearTextBox;
        private TextBox includeTextBox;
        private Label label4;
        private TextBox operationTextBox;
        private Label label5;
        private TextBox serviceTextBox;
        private Label label6;
        private TextBox awsNamespaceTextBox;
        private Label label7;
        private TextBox searchIndexTextBox;
        private Label label8;
    }
}

