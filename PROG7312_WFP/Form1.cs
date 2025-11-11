using System;
using System.Windows.Forms;

namespace PROG7312_WFP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize service request sample data
            if (ServiceRequestManager.GetTotalCount() == 0)
            {
                ServiceRequestManager.InitializeSampleData();
            }
        }

        private void reportIssuesMenuItem_Click(object sender, EventArgs e)
        {
            // Report Issues menu item
            ShowReportIssuesForm();
        }

        private void localEventsMenuItem_Click(object sender, EventArgs e)
        {
            // Local Events and Announcements menu item
            ShowLocalEventsForm();
        }

        private void serviceStatusMenuItem_Click(object sender, EventArgs e)
        {
            // Service Request Status menu item - NOW IMPLEMENTED!
            ShowServiceRequestStatusForm();
        }

        private void ShowReportIssuesForm()
        {
            ReportForm reportIssuesForm = new ReportForm();
            reportIssuesForm.Show();
            this.Hide();
        }

        private void ShowLocalEventsForm()
        {
            EventsForm localEventsForm = new EventsForm();
            localEventsForm.Show();
            this.Hide();
        }

        private void ShowServiceRequestStatusForm()
        {
            ServiceRequestStatusForm serviceStatusForm = new ServiceRequestStatusForm();
            serviceStatusForm.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Unused
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            // Unused
        }
    }
}