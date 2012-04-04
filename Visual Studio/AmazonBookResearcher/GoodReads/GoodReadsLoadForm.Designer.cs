namespace BookResearcher.GoodReads
{
    partial class GoodReadsLoadForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.useLoadedDetails = new System.Windows.Forms.Button();
            this.useDefaultDetails = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account details found";
            // 
            // useLoadedDetails
            // 
            this.useLoadedDetails.Location = new System.Drawing.Point(7, 45);
            this.useLoadedDetails.Name = "useLoadedDetails";
            this.useLoadedDetails.Size = new System.Drawing.Size(113, 23);
            this.useLoadedDetails.TabIndex = 1;
            this.useLoadedDetails.Text = "Use Loaded Details";
            this.useLoadedDetails.UseVisualStyleBackColor = true;
            this.useLoadedDetails.Click += new System.EventHandler(this.useLoadedDetails_Click);
            // 
            // useDefaultDetails
            // 
            this.useDefaultDetails.Location = new System.Drawing.Point(130, 45);
            this.useDefaultDetails.Name = "useDefaultDetails";
            this.useDefaultDetails.Size = new System.Drawing.Size(113, 23);
            this.useDefaultDetails.TabIndex = 2;
            this.useDefaultDetails.Text = "Use Default Details";
            this.useDefaultDetails.UseVisualStyleBackColor = true;
            this.useDefaultDetails.Click += new System.EventHandler(this.useDefaultDetails_Click);
            // 
            // GoodReadsLoadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 84);
            this.Controls.Add(this.useDefaultDetails);
            this.Controls.Add(this.useLoadedDetails);
            this.Controls.Add(this.label1);
            this.Name = "GoodReadsLoadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Account Details";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button useLoadedDetails;
        private System.Windows.Forms.Button useDefaultDetails;
    }
}