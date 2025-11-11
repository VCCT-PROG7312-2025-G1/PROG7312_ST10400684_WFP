namespace PROG7312_WFP
{
    partial class ServiceRequestStatusForm
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.lblSearchId = new System.Windows.Forms.Label();
            this.txtSearchId = new System.Windows.Forms.TextBox();
            this.lblFilterStatus = new System.Windows.Forms.Label();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.lblFilterPriority = new System.Windows.Forms.Label();
            this.comboBoxPriority = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClearFilters = new System.Windows.Forms.Button();
            this.btnShowPriorityOrder = new System.Windows.Forms.Button();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.listBoxRequests = new System.Windows.Forms.ListBox();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.richTextBoxDetails = new System.Windows.Forms.RichTextBox();
            this.panelDependencies = new System.Windows.Forms.Panel();
            this.lblDependencies = new System.Windows.Forms.Label();
            this.listBoxDependencies = new System.Windows.Forms.ListBox();
            this.btnViewDependency = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelTop.SuspendLayout();
            this.panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panelDetails.SuspendLayout();
            this.panelDependencies.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Controls.Add(this.btnBack);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1200, 70);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(12, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(295, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Service Request Status";
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(1070, 18);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(110, 35);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "← Back to Main";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // panelSearch
            // 
            this.panelSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.panelSearch.Controls.Add(this.lblSearchId);
            this.panelSearch.Controls.Add(this.txtSearchId);
            this.panelSearch.Controls.Add(this.lblFilterStatus);
            this.panelSearch.Controls.Add(this.comboBoxStatus);
            this.panelSearch.Controls.Add(this.lblFilterPriority);
            this.panelSearch.Controls.Add(this.comboBoxPriority);
            this.panelSearch.Controls.Add(this.btnSearch);
            this.panelSearch.Controls.Add(this.btnClearFilters);
            this.panelSearch.Controls.Add(this.btnShowPriorityOrder);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(0, 70);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Padding = new System.Windows.Forms.Padding(10);
            this.panelSearch.Size = new System.Drawing.Size(1200, 100);
            this.panelSearch.TabIndex = 1;
            // 
            // lblSearchId
            // 
            this.lblSearchId.AutoSize = true;
            this.lblSearchId.Location = new System.Drawing.Point(15, 15);
            this.lblSearchId.Name = "lblSearchId";
            this.lblSearchId.Size = new System.Drawing.Size(99, 15);
            this.lblSearchId.TabIndex = 0;
            this.lblSearchId.Text = "Search Request ID:";
            // 
            // txtSearchId
            // 
            this.txtSearchId.Location = new System.Drawing.Point(15, 35);
            this.txtSearchId.Name = "txtSearchId";
            this.txtSearchId.PlaceholderText = "Enter Request ID (e.g., 2001 or SR-2001)";
            this.txtSearchId.Size = new System.Drawing.Size(220, 23);
            this.txtSearchId.TabIndex = 1;
            // 
            // lblFilterStatus
            // 
            this.lblFilterStatus.AutoSize = true;
            this.lblFilterStatus.Location = new System.Drawing.Point(255, 15);
            this.lblFilterStatus.Name = "lblFilterStatus";
            this.lblFilterStatus.Size = new System.Drawing.Size(42, 15);
            this.lblFilterStatus.TabIndex = 2;
            this.lblFilterStatus.Text = "Status:";
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Location = new System.Drawing.Point(255, 35);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(160, 23);
            this.comboBoxStatus.TabIndex = 3;
            // 
            // lblFilterPriority
            // 
            this.lblFilterPriority.AutoSize = true;
            this.lblFilterPriority.Location = new System.Drawing.Point(435, 15);
            this.lblFilterPriority.Name = "lblFilterPriority";
            this.lblFilterPriority.Size = new System.Drawing.Size(48, 15);
            this.lblFilterPriority.TabIndex = 4;
            this.lblFilterPriority.Text = "Priority:";
            // 
            // comboBoxPriority
            // 
            this.comboBoxPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPriority.FormattingEnabled = true;
            this.comboBoxPriority.Location = new System.Drawing.Point(435, 35);
            this.comboBoxPriority.Name = "comboBoxPriority";
            this.comboBoxPriority.Size = new System.Drawing.Size(140, 23);
            this.comboBoxPriority.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(600, 30);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(110, 30);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "🔍 Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClearFilters
            // 
            this.btnClearFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnClearFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFilters.ForeColor = System.Drawing.Color.White;
            this.btnClearFilters.Location = new System.Drawing.Point(720, 30);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(110, 30);
            this.btnClearFilters.TabIndex = 7;
            this.btnClearFilters.Text = "Clear Filters";
            this.btnClearFilters.UseVisualStyleBackColor = false;
            this.btnClearFilters.Click += new System.EventHandler(this.btnClearFilters_Click);
            // 
            // btnShowPriorityOrder
            // 
            this.btnShowPriorityOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnShowPriorityOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowPriorityOrder.ForeColor = System.Drawing.Color.White;
            this.btnShowPriorityOrder.Location = new System.Drawing.Point(15, 65);
            this.btnShowPriorityOrder.Name = "btnShowPriorityOrder";
            this.btnShowPriorityOrder.Size = new System.Drawing.Size(180, 25);
            this.btnShowPriorityOrder.TabIndex = 8;
            this.btnShowPriorityOrder.Text = "⚡ Show Priority Order";
            this.btnShowPriorityOrder.UseVisualStyleBackColor = false;
            this.btnShowPriorityOrder.Click += new System.EventHandler(this.btnShowPriorityOrder_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 170);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.listBoxRequests);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.panelDetails);
            this.splitContainer.Panel2.Controls.Add(this.panelDependencies);
            this.splitContainer.Size = new System.Drawing.Size(1200, 556);
            this.splitContainer.SplitterDistance = 450;
            this.splitContainer.TabIndex = 2;
            // 
            // listBoxRequests
            // 
            this.listBoxRequests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxRequests.FormattingEnabled = true;
            this.listBoxRequests.ItemHeight = 15;
            this.listBoxRequests.Location = new System.Drawing.Point(0, 0);
            this.listBoxRequests.Name = "listBoxRequests";
            this.listBoxRequests.Size = new System.Drawing.Size(450, 556);
            this.listBoxRequests.TabIndex = 0;
            this.listBoxRequests.SelectedIndexChanged += new System.EventHandler(this.listBoxRequests_SelectedIndexChanged);
            // 
            // panelDetails
            // 
            this.panelDetails.Controls.Add(this.richTextBoxDetails);
            this.panelDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetails.Location = new System.Drawing.Point(0, 0);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Padding = new System.Windows.Forms.Padding(10);
            this.panelDetails.Size = new System.Drawing.Size(746, 336);
            this.panelDetails.TabIndex = 0;
            // 
            // richTextBoxDetails
            // 
            this.richTextBoxDetails.BackColor = System.Drawing.Color.White;
            this.richTextBoxDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxDetails.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.richTextBoxDetails.Location = new System.Drawing.Point(10, 10);
            this.richTextBoxDetails.Name = "richTextBoxDetails";
            this.richTextBoxDetails.ReadOnly = true;
            this.richTextBoxDetails.Size = new System.Drawing.Size(726, 316);
            this.richTextBoxDetails.TabIndex = 0;
            this.richTextBoxDetails.Text = "Select a service request to view details...";
            // 
            // panelDependencies
            // 
            this.panelDependencies.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panelDependencies.Controls.Add(this.lblDependencies);
            this.panelDependencies.Controls.Add(this.listBoxDependencies);
            this.panelDependencies.Controls.Add(this.btnViewDependency);
            this.panelDependencies.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDependencies.Location = new System.Drawing.Point(0, 336);
            this.panelDependencies.Name = "panelDependencies";
            this.panelDependencies.Padding = new System.Windows.Forms.Padding(10);
            this.panelDependencies.Size = new System.Drawing.Size(746, 220);
            this.panelDependencies.TabIndex = 1;
            // 
            // lblDependencies
            // 
            this.lblDependencies.AutoSize = true;
            this.lblDependencies.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDependencies.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblDependencies.Location = new System.Drawing.Point(13, 10);
            this.lblDependencies.Name = "lblDependencies";
            this.lblDependencies.Size = new System.Drawing.Size(206, 19);
            this.lblDependencies.TabIndex = 0;
            this.lblDependencies.Text = "🔗 Related/Dependent Requests";
            // 
            // listBoxDependencies
            // 
            this.listBoxDependencies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxDependencies.FormattingEnabled = true;
            this.listBoxDependencies.ItemHeight = 15;
            this.listBoxDependencies.Location = new System.Drawing.Point(13, 35);
            this.listBoxDependencies.Name = "listBoxDependencies";
            this.listBoxDependencies.Size = new System.Drawing.Size(720, 139);
            this.listBoxDependencies.TabIndex = 1;
            // 
            // btnViewDependency
            // 
            this.btnViewDependency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnViewDependency.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnViewDependency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewDependency.ForeColor = System.Drawing.Color.White;
            this.btnViewDependency.Location = new System.Drawing.Point(13, 180);
            this.btnViewDependency.Name = "btnViewDependency";
            this.btnViewDependency.Size = new System.Drawing.Size(150, 30);
            this.btnViewDependency.TabIndex = 2;
            this.btnViewDependency.Text = "View Selected";
            this.btnViewDependency.UseVisualStyleBackColor = false;
            this.btnViewDependency.Click += new System.EventHandler(this.btnViewDependency_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 726);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1200, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(39, 17);
            this.lblStatus.Text = "Ready";
            // 
            // ServiceRequestStatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 748);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.panelSearch);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.statusStrip);
            this.Name = "ServiceRequestStatusForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Service Request Status Tracking";
            this.Load += new System.EventHandler(this.ServiceRequestStatusForm_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panelDetails.ResumeLayout(false);
            this.panelDependencies.ResumeLayout(false);
            this.panelDependencies.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Label lblSearchId;
        private System.Windows.Forms.TextBox txtSearchId;
        private System.Windows.Forms.Label lblFilterStatus;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.Label lblFilterPriority;
        private System.Windows.Forms.ComboBox comboBoxPriority;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClearFilters;
        private System.Windows.Forms.Button btnShowPriorityOrder;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ListBox listBoxRequests;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.RichTextBox richTextBoxDetails;
        private System.Windows.Forms.Panel panelDependencies;
        private System.Windows.Forms.Label lblDependencies;
        private System.Windows.Forms.ListBox listBoxDependencies;
        private System.Windows.Forms.Button btnViewDependency;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}