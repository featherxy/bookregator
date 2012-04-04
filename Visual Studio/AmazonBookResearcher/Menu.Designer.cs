namespace BookResearcher
{
    partial class Menu
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
            this.amazon = new System.Windows.Forms.Button();
            this.worldCat = new System.Windows.Forms.Button();
            this.goodReads = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.help = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // amazon
            // 
            this.amazon.Location = new System.Drawing.Point(15, 31);
            this.amazon.Name = "amazon";
            this.amazon.Size = new System.Drawing.Size(175, 23);
            this.amazon.TabIndex = 0;
            this.amazon.Text = "Amazon";
            this.amazon.UseVisualStyleBackColor = true;
            this.amazon.Click += new System.EventHandler(this.amazon_Click);
            // 
            // worldCat
            // 
            this.worldCat.Location = new System.Drawing.Point(15, 60);
            this.worldCat.Name = "worldCat";
            this.worldCat.Size = new System.Drawing.Size(175, 23);
            this.worldCat.TabIndex = 1;
            this.worldCat.Text = "WorldCat";
            this.worldCat.UseVisualStyleBackColor = true;
            this.worldCat.Click += new System.EventHandler(this.worldCat_Click);
            // 
            // goodReads
            // 
            this.goodReads.Location = new System.Drawing.Point(15, 89);
            this.goodReads.Name = "goodReads";
            this.goodReads.Size = new System.Drawing.Size(175, 23);
            this.goodReads.TabIndex = 2;
            this.goodReads.Text = "GoodReads";
            this.goodReads.UseVisualStyleBackColor = true;
            this.goodReads.Click += new System.EventHandler(this.goodReads_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.help});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(202, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // help
            // 
            this.help.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(44, 20);
            this.help.Text = "Help";
            this.help.Click += new System.EventHandler(this.help_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(202, 121);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.goodReads);
            this.Controls.Add(this.worldCat);
            this.Controls.Add(this.amazon);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bookregator";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button amazon;
        private System.Windows.Forms.Button worldCat;
        private System.Windows.Forms.Button goodReads;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem help;
    }
}