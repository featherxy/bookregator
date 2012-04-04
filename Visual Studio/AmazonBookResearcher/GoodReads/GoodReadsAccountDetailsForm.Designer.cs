namespace BookResearcher.GoodReads
{
    partial class GoodReadsAccountDetailsForm
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
            this.key = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.saveAndClose = new System.Windows.Forms.Button();
            this.useDefault = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // key
            // 
            this.key.Location = new System.Drawing.Point(41, 16);
            this.key.Name = "key";
            this.key.Size = new System.Drawing.Size(307, 20);
            this.key.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Key";
            // 
            // saveAndClose
            // 
            this.saveAndClose.Location = new System.Drawing.Point(41, 42);
            this.saveAndClose.Name = "saveAndClose";
            this.saveAndClose.Size = new System.Drawing.Size(151, 23);
            this.saveAndClose.TabIndex = 4;
            this.saveAndClose.Text = "Save and Close";
            this.saveAndClose.UseVisualStyleBackColor = true;
            this.saveAndClose.Click += new System.EventHandler(this.saveAndClose_Click);
            // 
            // useDefault
            // 
            this.useDefault.Location = new System.Drawing.Point(197, 42);
            this.useDefault.Name = "useDefault";
            this.useDefault.Size = new System.Drawing.Size(151, 23);
            this.useDefault.TabIndex = 5;
            this.useDefault.Text = "Use Default and Close";
            this.useDefault.UseVisualStyleBackColor = true;
            this.useDefault.Click += new System.EventHandler(this.useDefault_Click);
            // 
            // GoodReadsAccountDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 77);
            this.Controls.Add(this.useDefault);
            this.Controls.Add(this.saveAndClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.key);
            this.Name = "GoodReadsAccountDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Account Details";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox key;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveAndClose;
        private System.Windows.Forms.Button useDefault;
    }
}