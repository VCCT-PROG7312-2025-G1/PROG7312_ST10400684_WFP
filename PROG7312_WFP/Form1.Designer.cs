namespace PROG7312_WFP
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            reportIssuesToolStripMenuItem = new ToolStripMenuItem();
            localEventsToolStripMenuItem = new ToolStripMenuItem();
            serviceStatusToolStripMenuItem = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();

            // menuStrip1
            menuStrip1.Items.AddRange(new ToolStripItem[] { reportIssuesToolStripMenuItem, localEventsToolStripMenuItem, serviceStatusToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";

            // reportIssuesToolStripMenuItem
            reportIssuesToolStripMenuItem.Name = "reportIssuesToolStripMenuItem";
            reportIssuesToolStripMenuItem.Size = new Size(88, 20);
            reportIssuesToolStripMenuItem.Text = "Report Issues";
            reportIssuesToolStripMenuItem.Click += reportIssuesMenuItem_Click;

            // localEventsToolStripMenuItem
            localEventsToolStripMenuItem.Name = "localEventsToolStripMenuItem";
            localEventsToolStripMenuItem.Size = new Size(198, 20);
            localEventsToolStripMenuItem.Text = "Local Events and Announcements";
            localEventsToolStripMenuItem.Click += localEventsMenuItem_Click;

            // serviceStatusToolStripMenuItem
            serviceStatusToolStripMenuItem.Name = "serviceStatusToolStripMenuItem";
            serviceStatusToolStripMenuItem.Size = new Size(136, 20);
            serviceStatusToolStripMenuItem.Text = "Service Request Status";
            serviceStatusToolStripMenuItem.Click += serviceStatusMenuItem_Click;

            // pictureBox1
            pictureBox1.BackgroundImage = Properties.Resources._20210806_0113_1_scaled_1_2048x1366;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 24);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(800, 426);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click_1;

            // Form1
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem reportIssuesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localEventsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviceStatusToolStripMenuItem;
        private PictureBox pictureBox1;
    }
}