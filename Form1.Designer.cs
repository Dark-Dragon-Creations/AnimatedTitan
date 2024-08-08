namespace AnimatedTitan
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnCreateGif = new Button();
            txtMessages = new TextBox();
            lblImageFolder = new Label();
            txtImageFolder = new TextBox();
            btnFindImageFolder = new Button();
            lblOutputPath = new Label();
            txtOutputPath = new TextBox();
            btnFindOutputPath = new Button();
            lblTotalDuration = new Label();
            txtTotalDuration = new TextBox();
            lblFilename = new Label();
            txtFilename = new TextBox();
            SuspendLayout();
            // 
            // btnCreateGif
            // 
            btnCreateGif.Location = new Point(12, 180);
            btnCreateGif.Name = "btnCreateGif";
            btnCreateGif.Size = new Size(474, 23);
            btnCreateGif.TabIndex = 0;
            btnCreateGif.Text = "Create GIF";
            btnCreateGif.UseVisualStyleBackColor = true;
            btnCreateGif.Click += new EventHandler(this.btnCreateGif_Click);
            // 
            // txtMessages
            // 
            txtMessages.Location = new Point(12, 209);
            txtMessages.Multiline = true;
            txtMessages.Name = "txtMessages";
            txtMessages.Size = new Size(474, 160);
            txtMessages.TabIndex = 1;
            // 
            // lblImageFolder
            // 
            lblImageFolder.AutoSize = true;
            lblImageFolder.Location = new Point(12, 9);
            lblImageFolder.Name = "lblImageFolder";
            lblImageFolder.Size = new Size(79, 15);
            lblImageFolder.TabIndex = 2;
            lblImageFolder.Text = "Image Folder:";
            // 
            // txtImageFolder
            // 
            txtImageFolder.Location = new Point(12, 25);
            txtImageFolder.Name = "txtImageFolder";
            txtImageFolder.Size = new Size(405, 23);
            txtImageFolder.TabIndex = 3;
            // 
            // btnFindImageFolder
            // 
            btnFindImageFolder.Location = new Point(423, 25);
            btnFindImageFolder.Name = "btnFindImageFolder";
            btnFindImageFolder.Size = new Size(63, 23);
            btnFindImageFolder.TabIndex = 4;
            btnFindImageFolder.Text = "Find Folder";
            btnFindImageFolder.UseVisualStyleBackColor = true;
            btnFindImageFolder.Click += new EventHandler(this.btnFindImageFolder_Click);
            // 
            // lblOutputPath
            // 
            lblOutputPath.AutoSize = true;
            lblOutputPath.Location = new Point(12, 51);
            lblOutputPath.Name = "lblOutputPath";
            lblOutputPath.Size = new Size(75, 15);
            lblOutputPath.TabIndex = 5;
            lblOutputPath.Text = "Output Path:";
            // 
            // txtOutputPath
            // 
            txtOutputPath.Location = new Point(12, 67);
            txtOutputPath.Name = "txtOutputPath";
            txtOutputPath.Size = new Size(405, 23);
            txtOutputPath.TabIndex = 6;
            // 
            // btnFindOutputPath
            // 
            btnFindOutputPath.Location = new Point(423, 67);
            btnFindOutputPath.Name = "btnFindOutputPath";
            btnFindOutputPath.Size = new Size(63, 23);
            btnFindOutputPath.TabIndex = 7;
            btnFindOutputPath.Text = "Find Folder";
            btnFindOutputPath.UseVisualStyleBackColor = true;
            btnFindOutputPath.Click += new EventHandler(this.btnFindOutputPath_Click);
            // 
            // lblTotalDuration
            // 
            lblTotalDuration.AutoSize = true;
            lblTotalDuration.Location = new Point(12, 126);
            lblTotalDuration.Name = "lblTotalDuration";
            lblTotalDuration.Size = new Size(84, 15);
            lblTotalDuration.TabIndex = 8;
            lblTotalDuration.Text = "Total Duration:";
            // 
            // txtTotalDuration
            // 
            txtTotalDuration.Location = new Point(12, 142);
            txtTotalDuration.Name = "txtTotalDuration";
            txtTotalDuration.Size = new Size(474, 23);
            txtTotalDuration.TabIndex = 9;
            // 
            // lblFilename
            // 
            lblFilename.AutoSize = true;
            lblFilename.Location = new Point(12, 90);
            lblFilename.Name = "lblFilename";
            lblFilename.Size = new Size(58, 15);
            lblFilename.TabIndex = 10;
            lblFilename.Text = "Filename:";
            // 
            // txtFilename
            // 
            txtFilename.Location = new Point(12, 106);
            txtFilename.Name = "txtFilename";
            txtFilename.Size = new Size(474, 23);
            txtFilename.TabIndex = 11;
            // 
            // Form1
            // 
            ClientSize = new Size(498, 381);
            Controls.Add(txtFilename);
            Controls.Add(lblFilename);
            Controls.Add(txtTotalDuration);
            Controls.Add(lblTotalDuration);
            Controls.Add(btnFindOutputPath);
            Controls.Add(txtOutputPath);
            Controls.Add(lblOutputPath);
            Controls.Add(btnFindImageFolder);
            Controls.Add(txtImageFolder);
            Controls.Add(lblImageFolder);
            Controls.Add(txtMessages);
            Controls.Add(btnCreateGif);
            Name = "Form1";
            Text = "Animated Titan";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Button btnCreateGif;
        private System.Windows.Forms.TextBox txtMessages;
        private System.Windows.Forms.Label lblImageFolder;
        private System.Windows.Forms.TextBox txtImageFolder;
        private System.Windows.Forms.Button btnFindImageFolder;
        private System.Windows.Forms.Label lblOutputPath;
        private System.Windows.Forms.TextBox txtOutputPath;
        private System.Windows.Forms.Button btnFindOutputPath;
        private System.Windows.Forms.Label lblTotalDuration;
        private System.Windows.Forms.TextBox txtTotalDuration;
        private System.Windows.Forms.Label lblFilename;
        private System.Windows.Forms.TextBox txtFilename;
    }
}
