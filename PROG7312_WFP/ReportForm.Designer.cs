namespace PROG7312_WFP
{
    partial class ReportForm
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
            label1 = new Label();
            txtLocation = new TextBox();
            label2 = new Label();
            comboBoxCategory = new ComboBox();
            label3 = new Label();
            rtbDescription = new RichTextBox();
            btnUpload = new Button();
            fileAttachmentDialog = new OpenFileDialog();
            btnBack = new Button();
            btnSubmit = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(224, 224, 224);
            label1.Location = new Point(147, 83);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "label1";
            label1.Click += label1_Click;
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(272, 80);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(100, 23);
            txtLocation.TabIndex = 1;
            txtLocation.TextChanged += txtLocation_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(224, 224, 224);
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Location = new Point(147, 133);
            label2.Name = "label2";
            label2.Size = new Size(40, 17);
            label2.TabIndex = 2;
            label2.Text = "label2";
            label2.Click += label2_Click;
            // 
            // comboBoxCategory
            // 
            comboBoxCategory.FormattingEnabled = true;
            comboBoxCategory.Location = new Point(261, 130);
            comboBoxCategory.Name = "comboBoxCategory";
            comboBoxCategory.Size = new Size(121, 23);
            comboBoxCategory.TabIndex = 3;
            comboBoxCategory.SelectedIndexChanged += comboBoxCategory_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(224, 224, 224);
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Location = new Point(147, 221);
            label3.Name = "label3";
            label3.Size = new Size(40, 17);
            label3.TabIndex = 4;
            label3.Text = "label3";
            label3.Click += label3_Click;
            // 
            // rtbDescription
            // 
            rtbDescription.Location = new Point(240, 204);
            rtbDescription.Name = "rtbDescription";
            rtbDescription.Size = new Size(166, 54);
            rtbDescription.TabIndex = 5;
            rtbDescription.Text = "";
            rtbDescription.TextChanged += rtbDescription_TextChanged;
            // 
            // btnUpload
            // 
            btnUpload.Location = new Point(282, 296);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(75, 23);
            btnUpload.TabIndex = 6;
            btnUpload.Text = "Upload";
            btnUpload.UseVisualStyleBackColor = true;
            btnUpload.Click += btnUpload_Click;
            // 
            // fileAttachmentDialog
            // 
            fileAttachmentDialog.FileName = "openFileDialog1";
            fileAttachmentDialog.FileOk += openFileDialog1_FileOk;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(157, 371);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(160, 52);
            btnBack.TabIndex = 7;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(371, 371);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(155, 52);
            btnSubmit.TabIndex = 8;
            btnSubmit.Text = "SUBMIT";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // ReportForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.report;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSubmit);
            Controls.Add(btnBack);
            Controls.Add(btnUpload);
            Controls.Add(rtbDescription);
            Controls.Add(label3);
            Controls.Add(comboBoxCategory);
            Controls.Add(label2);
            Controls.Add(txtLocation);
            Controls.Add(label1);
            Name = "ReportForm";
            Text = "ReportForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.OpenFileDialog fileAttachmentDialog;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnSubmit;
    }
}