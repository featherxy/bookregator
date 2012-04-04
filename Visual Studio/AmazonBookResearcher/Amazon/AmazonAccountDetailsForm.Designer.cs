namespace BookResearcher
{
    partial class AmazonAccountDetails
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
            this.accessKeyId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.secretKey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.save = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.associateTag = new System.Windows.Forms.TextBox();
            this.close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // accessKeyId
            // 
            this.accessKeyId.Location = new System.Drawing.Point(103, 6);
            this.accessKeyId.Name = "accessKeyId";
            this.accessKeyId.Size = new System.Drawing.Size(278, 20);
            this.accessKeyId.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(23, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Access Key ID";
            // 
            // secretKey
            // 
            this.secretKey.Location = new System.Drawing.Point(103, 32);
            this.secretKey.Name = "secretKey";
            this.secretKey.Size = new System.Drawing.Size(278, 20);
            this.secretKey.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Secret Access Key";
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(103, 84);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(139, 23);
            this.save.TabIndex = 3;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Associate ID";
            // 
            // associateTag
            // 
            this.associateTag.Location = new System.Drawing.Point(103, 58);
            this.associateTag.Name = "associateTag";
            this.associateTag.Size = new System.Drawing.Size(278, 20);
            this.associateTag.TabIndex = 5;
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(242, 84);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(139, 23);
            this.close.TabIndex = 4;
            this.close.Text = "Close";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.button2_Click);
            // 
            // AmazonAccountDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 114);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.associateTag);
            this.Controls.Add(this.close);
            this.Controls.Add(this.save);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.secretKey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.accessKeyId);
            this.Name = "AmazonAccountDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Account Details";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox accessKeyId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox secretKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox associateTag;
        private System.Windows.Forms.Button close;
    }
}