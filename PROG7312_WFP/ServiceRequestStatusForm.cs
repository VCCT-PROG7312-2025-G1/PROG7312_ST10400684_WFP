using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PROG7312_WFP
{
    public partial class ServiceRequestStatusForm : Form
    {
        private List<ServiceRequest> currentRequests = new List<ServiceRequest>();

        public ServiceRequestStatusForm()
        {
            InitializeComponent();

            // Add double-click support as alternative
            listBoxDependencies.MouseDoubleClick += listBoxDependencies_MouseDoubleClick;

            System.Diagnostics.Debug.WriteLine("ServiceRequestStatusForm initialized");
        }

        private void listBoxDependencies_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Double-click detected on dependencies list");
            btnViewDependency_Click(sender, e);
        }

        private void ServiceRequestStatusForm_Load(object sender, EventArgs e)
        {
            // Initialize sample data if not already loaded
            if (ServiceRequestManager.GetTotalCount() == 0)
            {
                ServiceRequestManager.InitializeSampleData();
            }

            // Populate filter dropdowns
            LoadFilterOptions();

            // Load all requests initially
            LoadRequests();

            UpdateStatusBar();
        }

        private void LoadFilterOptions()
        {
            // Status filter
            comboBoxStatus.Items.Clear();
            comboBoxStatus.Items.Add("All Statuses");
            foreach (ServiceRequestStatus status in Enum.GetValues(typeof(ServiceRequestStatus)))
            {
                comboBoxStatus.Items.Add(status.ToString());
            }
            comboBoxStatus.SelectedIndex = 0;

            // Priority filter
            comboBoxPriority.Items.Clear();
            comboBoxPriority.Items.Add("All Priorities");
            foreach (ServiceRequestPriority priority in Enum.GetValues(typeof(ServiceRequestPriority)))
            {
                comboBoxPriority.Items.Add(priority.ToString());
            }
            comboBoxPriority.SelectedIndex = 0;
        }

        private void LoadRequests(List<ServiceRequest> requests = null)
        {
            if (requests == null)
            {
                requests = ServiceRequestManager.GetAllRequests();
            }

            currentRequests = requests;

            listBoxRequests.Items.Clear();
            foreach (var request in currentRequests)
            {
                listBoxRequests.Items.Add(request);
            }

            UpdateStatusBar();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var results = ServiceRequestManager.GetAllRequests();

            // Filter by search ID
            string searchText = txtSearchId.Text.Trim();
            if (!string.IsNullOrEmpty(searchText))
            {
                // Extract numeric ID from text like "SR-2001" or "2001"
                searchText = searchText.Replace("SR-", "").Replace("sr-", "");

                if (int.TryParse(searchText, out int searchId))
                {
                    var request = ServiceRequestManager.GetRequestById(searchId);
                    if (request != null)
                    {
                        results = new List<ServiceRequest> { request };
                    }
                    else
                    {
                        MessageBox.Show($"No request found with ID: SR-{searchId:D4}",
                            "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    // General search
                    results = ServiceRequestManager.SearchRequests(searchText);
                }
            }

            // Filter by status
            string selectedStatus = comboBoxStatus.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedStatus) && selectedStatus != "All Statuses")
            {
                if (Enum.TryParse<ServiceRequestStatus>(selectedStatus, out var status))
                {
                    results = results.Where(r => r.Status == status).ToList();
                }
            }

            // Filter by priority
            string selectedPriority = comboBoxPriority.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedPriority) && selectedPriority != "All Priorities")
            {
                if (Enum.TryParse<ServiceRequestPriority>(selectedPriority, out var priority))
                {
                    results = results.Where(r => r.Priority == priority).ToList();
                }
            }

            LoadRequests(results);
            lblStatus.Text = $"Found {results.Count} matching request(s)";
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            txtSearchId.Clear();
            comboBoxStatus.SelectedIndex = 0;
            comboBoxPriority.SelectedIndex = 0;
            LoadRequests();
            lblStatus.Text = "Filters cleared. Showing all requests.";
        }

        private void btnShowPriorityOrder_Click(object sender, EventArgs e)
        {
            var priorityOrderedRequests = ServiceRequestManager.GetRequestsByPriority();
            LoadRequests(priorityOrderedRequests);
            lblStatus.Text = $"Showing {priorityOrderedRequests.Count} requests in priority order (Critical → Low)";
        }

        private void listBoxRequests_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxRequests.SelectedItem is ServiceRequest selectedRequest)
            {
                DisplayRequestDetails(selectedRequest);
                LoadDependencies(selectedRequest);
            }
        }

        private void DisplayRequestDetails(ServiceRequest request)
        {
            richTextBoxDetails.Clear();

            // Request ID Header
            richTextBoxDetails.SelectionFont = new Font("Segoe UI", 16, FontStyle.Bold);
            richTextBoxDetails.SelectionColor = Color.FromArgb(52, 73, 94);
            richTextBoxDetails.AppendText($"Request SR-{request.RequestId:D4}\n\n");

            // Status Badge
            richTextBoxDetails.SelectionFont = new Font("Segoe UI", 9, FontStyle.Bold);
            richTextBoxDetails.SelectionColor = Color.White;
            richTextBoxDetails.SelectionBackColor = GetStatusColor(request.Status);
            richTextBoxDetails.AppendText($" {request.Status} ");
            richTextBoxDetails.SelectionBackColor = Color.White;

            // Priority Badge
            richTextBoxDetails.AppendText("  ");
            richTextBoxDetails.SelectionBackColor = GetPriorityColor(request.Priority);
            richTextBoxDetails.SelectionColor = Color.White;
            richTextBoxDetails.AppendText($" {request.Priority} Priority ");
            richTextBoxDetails.SelectionBackColor = Color.White;
            richTextBoxDetails.AppendText("\n\n");

            // Progress Bar
            richTextBoxDetails.SelectionFont = new Font("Segoe UI", 10, FontStyle.Bold);
            richTextBoxDetails.SelectionColor = Color.Black;
            richTextBoxDetails.AppendText("Progress:\n");
            richTextBoxDetails.SelectionFont = new Font("Segoe UI", 10, FontStyle.Regular);
            richTextBoxDetails.SelectionColor = Color.DimGray;
            richTextBoxDetails.AppendText($"{GetProgressBar(request.ProgressPercentage)} {request.ProgressPercentage}%\n\n");

            // Description
            richTextBoxDetails.SelectionFont = new Font("Segoe UI", 10, FontStyle.Bold);
            richTextBoxDetails.SelectionColor = Color.Black;
            richTextBoxDetails.AppendText("📋 Description:\n");
            richTextBoxDetails.SelectionFont = new Font("Segoe UI", 10, FontStyle.Regular);
            richTextBoxDetails.SelectionColor = Color.DimGray;
            richTextBoxDetails.AppendText($"{request.Description}\n\n");

            // Location
            richTextBoxDetails.SelectionFont = new Font("Segoe UI", 10, FontStyle.Bold);
            richTextBoxDetails.SelectionColor = Color.Black;
            richTextBoxDetails.AppendText("📍 Location:\n");
            richTextBoxDetails.SelectionFont = new Font("Segoe UI", 10, FontStyle.Regular);
            richTextBoxDetails.SelectionColor = Color.DimGray;
            richTextBoxDetails.AppendText($"{request.Location}\n\n");

            // Category
            richTextBoxDetails.SelectionFont = new Font("Segoe UI", 10, FontStyle.Bold);
            richTextBoxDetails.SelectionColor = Color.Black;
            richTextBoxDetails.AppendText("🏷️ Category:\n");
            richTextBoxDetails.SelectionFont = new Font("Segoe UI", 10, FontStyle.Regular);
            richTextBoxDetails.SelectionColor = Color.DimGray;
            richTextBoxDetails.AppendText($"{request.Category}\n\n");

            // Assigned To
            richTextBoxDetails.SelectionFont = new Font("Segoe UI", 10, FontStyle.Bold);
            richTextBoxDetails.SelectionColor = Color.Black;
            richTextBoxDetails.AppendText("👤 Assigned To:\n");
            richTextBoxDetails.SelectionFont = new Font("Segoe UI", 10, FontStyle.Regular);
            richTextBoxDetails.SelectionColor = Color.DimGray;
            richTextBoxDetails.AppendText($"{request.AssignedTo}\n\n");

            // Date Submitted
            richTextBoxDetails.SelectionFont = new Font("Segoe UI", 10, FontStyle.Bold);
            richTextBoxDetails.SelectionColor = Color.Black;
            richTextBoxDetails.AppendText("📅 Date Submitted:\n");
            richTextBoxDetails.SelectionFont = new Font("Segoe UI", 10, FontStyle.Regular);
            richTextBoxDetails.SelectionColor = Color.DimGray;
            richTextBoxDetails.AppendText($"{request.DateSubmitted:dddd, MMMM dd, yyyy 'at' hh:mm tt}\n\n");

            // Estimated Completion
            if (request.EstimatedCompletion.HasValue)
            {
                richTextBoxDetails.SelectionFont = new Font("Segoe UI", 10, FontStyle.Bold);
                richTextBoxDetails.SelectionColor = Color.Black;
                richTextBoxDetails.AppendText("⏰ Estimated Completion:\n");
                richTextBoxDetails.SelectionFont = new Font("Segoe UI", 10, FontStyle.Regular);
                richTextBoxDetails.SelectionColor = Color.DimGray;
                richTextBoxDetails.AppendText($"{request.EstimatedCompletion.Value:dddd, MMMM dd, yyyy}\n");
            }

            richTextBoxDetails.SelectionStart = 0;
            richTextBoxDetails.ScrollToCaret();
        }

        private void LoadDependencies(ServiceRequest request)
        {
            // Don't clear selection - just update items
            int previousSelectedIndex = listBoxDependencies.SelectedIndex;

            listBoxDependencies.Items.Clear();

            // Get all dependencies
            var dependencies = ServiceRequestManager.GetDependencies(request.RequestId);
            var dependents = ServiceRequestManager.GetDependents(request.RequestId);

            if (dependencies.Count == 0 && dependents.Count == 0)
            {
                listBoxDependencies.Items.Add("✓ No dependencies - This request can proceed independently");
                System.Diagnostics.Debug.WriteLine("No dependencies to display");

                // Disable the button when there are no dependencies
                btnViewDependency.Enabled = false;
                return;
            }

            // Enable the button when there are dependencies
            btnViewDependency.Enabled = true;

            if (dependencies.Count > 0)
            {
                listBoxDependencies.Items.Add("═══ DEPENDS ON (must complete first) ═══");
                foreach (var dep in dependencies)
                {
                    listBoxDependencies.Items.Add($"  ⬇ {dep}");
                    System.Diagnostics.Debug.WriteLine($"Added dependency: {dep}");
                }
            }

            if (dependents.Count > 0)
            {
                if (dependencies.Count > 0)
                {
                    listBoxDependencies.Items.Add("");
                }
                listBoxDependencies.Items.Add("═══ BLOCKS (waiting on this request) ═══");
                foreach (var dependent in dependents)
                {
                    listBoxDependencies.Items.Add($"  ⬆ {dependent}");
                    System.Diagnostics.Debug.WriteLine($"Added dependent: {dependent}");
                }
            }

            System.Diagnostics.Debug.WriteLine($"LoadDependencies complete. Total items: {listBoxDependencies.Items.Count}");
        }

        private void listBoxDependencies_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"=== Dependency Selection Changed ===");
            System.Diagnostics.Debug.WriteLine($"SelectedIndex: {listBoxDependencies.SelectedIndex}");
            System.Diagnostics.Debug.WriteLine($"SelectedItem: {listBoxDependencies.SelectedItem}");
        }

        private void btnViewDependency_Click(object sender, EventArgs e)
        {
            try
            {
                // FIRST TEST: Is this even being called?
                MessageBox.Show("Button clicked! Check Output window for details.", "Debug",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // DEBUG: Show what's selected
                System.Diagnostics.Debug.WriteLine("=== btnViewDependency_Click Started ===");
                System.Diagnostics.Debug.WriteLine($"SelectedIndex: {listBoxDependencies.SelectedIndex}");
                System.Diagnostics.Debug.WriteLine($"SelectedItem: {listBoxDependencies.SelectedItem}");
                System.Diagnostics.Debug.WriteLine($"Items Count: {listBoxDependencies.Items.Count}");

                // Check if anything is selected
                if (listBoxDependencies.SelectedItem == null || listBoxDependencies.SelectedIndex < 0)
                {
                    MessageBox.Show("Please select a related request to view.", "No Selection",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string selectedText = listBoxDependencies.SelectedItem.ToString();
                System.Diagnostics.Debug.WriteLine($"Selected Text: '{selectedText}'");

                // Skip header lines and messages
                if (selectedText.Contains("═══") ||
                    selectedText == "No dependencies or dependent requests" ||
                    selectedText.Trim().Length == 0)
                {
                    MessageBox.Show("Please select an actual request, not a header or message.", "Invalid Selection",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Extract ID from the string (format: "  ⬇ SR-2001: ...")
                if (selectedText.Contains("SR-"))
                {
                    System.Diagnostics.Debug.WriteLine("Found 'SR-' in selected text");

                    int startIndex = selectedText.IndexOf("SR-") + 3;
                    int endIndex = selectedText.IndexOf(":", startIndex);

                    System.Diagnostics.Debug.WriteLine($"startIndex: {startIndex}, endIndex: {endIndex}");

                    if (endIndex > startIndex)
                    {
                        string idStr = selectedText.Substring(startIndex, endIndex - startIndex);
                        System.Diagnostics.Debug.WriteLine($"Extracted ID string: '{idStr}'");

                        if (int.TryParse(idStr, out int requestId))
                        {
                            System.Diagnostics.Debug.WriteLine($"Parsed Request ID: {requestId}");
                            System.Diagnostics.Debug.WriteLine($"Searching in {listBoxRequests.Items.Count} items");

                            // Find and select this request in the main list
                            for (int i = 0; i < listBoxRequests.Items.Count; i++)
                            {
                                if (listBoxRequests.Items[i] is ServiceRequest req)
                                {
                                    System.Diagnostics.Debug.WriteLine($"  Checking item {i}: SR-{req.RequestId}");

                                    if (req.RequestId == requestId)
                                    {
                                        System.Diagnostics.Debug.WriteLine($"*** FOUND at index {i}! Selecting...");
                                        listBoxRequests.SelectedIndex = i;
                                        listBoxRequests.TopIndex = Math.Max(0, i - 2);
                                        lblStatus.Text = $"Viewing related request: SR-{requestId:D4}";
                                        MessageBox.Show($"Successfully navigated to Request SR-{requestId:D4}",
                                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                            }

                            System.Diagnostics.Debug.WriteLine("Not found in current view, loading all requests...");

                            // If not in current view, load all and try again
                            LoadRequests();

                            for (int i = 0; i < listBoxRequests.Items.Count; i++)
                            {
                                if (listBoxRequests.Items[i] is ServiceRequest req && req.RequestId == requestId)
                                {
                                    System.Diagnostics.Debug.WriteLine($"*** FOUND in full list at index {i}!");
                                    listBoxRequests.SelectedIndex = i;
                                    listBoxRequests.TopIndex = Math.Max(0, i - 2);
                                    lblStatus.Text = $"Viewing related request: SR-{requestId:D4}";
                                    MessageBox.Show($"Successfully navigated to Request SR-{requestId:D4}",
                                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }

                            System.Diagnostics.Debug.WriteLine("*** NOT FOUND in either list!");
                            MessageBox.Show($"Could not find request SR-{requestId:D4} in the system.\n\nThis request may have been deleted or doesn't exist.",
                                "Request Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine($"Failed to parse ID: '{idStr}'");
                            MessageBox.Show($"Could not parse request ID from: '{idStr}'",
                                "Parse Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid indices for substring extraction");
                        MessageBox.Show("The selected text doesn't contain a valid request ID format.",
                            "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("No 'SR-' found in selected text");
                    MessageBox.Show("The selected item doesn't appear to be a valid service request.",
                        "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ERROR: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Stack Trace: {ex.StackTrace}");
                MessageBox.Show($"An error occurred:\n\n{ex.Message}\n\nCheck the Output window for details.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                System.Diagnostics.Debug.WriteLine("=== btnViewDependency_Click Ended ===\n");
            }
        }

        private Color GetStatusColor(ServiceRequestStatus status)
        {
            return status switch
            {
                ServiceRequestStatus.Submitted => Color.FromArgb(149, 165, 166),
                ServiceRequestStatus.UnderReview => Color.FromArgb(52, 152, 219),
                ServiceRequestStatus.Approved => Color.FromArgb(46, 204, 113),
                ServiceRequestStatus.InProgress => Color.FromArgb(241, 196, 15),
                ServiceRequestStatus.OnHold => Color.FromArgb(230, 126, 34),
                ServiceRequestStatus.Completed => Color.FromArgb(39, 174, 96),
                ServiceRequestStatus.Rejected => Color.FromArgb(231, 76, 60),
                _ => Color.Gray
            };
        }

        private Color GetPriorityColor(ServiceRequestPriority priority)
        {
            return priority switch
            {
                ServiceRequestPriority.Low => Color.FromArgb(52, 152, 219),
                ServiceRequestPriority.Medium => Color.FromArgb(241, 196, 15),
                ServiceRequestPriority.High => Color.FromArgb(230, 126, 34),
                ServiceRequestPriority.Critical => Color.FromArgb(192, 57, 43),
                _ => Color.Gray
            };
        }

        private string GetProgressBar(int percentage)
        {
            int filled = percentage / 10;
            int empty = 10 - filled;
            return $"[{'█'.ToString().PadRight(filled, '█')}{'░'.ToString().PadRight(empty, '░')}]";
        }

        private void UpdateStatusBar()
        {
            var stats = ServiceRequestManager.GetStatusStatistics();
            int totalRequests = ServiceRequestManager.GetTotalCount();

            lblStatus.Text = $"Displaying {currentRequests.Count} of {totalRequests} total requests | " +
                           $"In Progress: {stats.GetValueOrDefault("InProgress", 0)} | " +
                           $"Completed: {stats.GetValueOrDefault("Completed", 0)}";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 mainForm = new Form1();
            mainForm.Show();
            this.Close();
        }
    }
}