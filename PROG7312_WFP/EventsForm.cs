using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PROG7312_WFP
{
    public partial class EventsForm : Form
    {
        private List<Event> currentEvents = new List<Event>();
        private string currentSortMethod = "Date (Ascending)";

        public EventsForm()
        {
            InitializeComponent();
        }

        private void EventsForm_Load(object sender, EventArgs e)
        {
            // Initialize sample data if not already loaded
            if (EventManager.GetTotalEventCount() == 0)
            {
                EventManager.InitializeSampleData();
            }

            // Convert reported issues to events
            LoadIssuesAsEvents();

            // Populate category dropdown
            LoadCategories();

            // Populate sort dropdown
            LoadSortOptions();

            // Load all events initially
            LoadEvents();

            // Load recommendations
            LoadRecommendations();

            UpdateStatusBar();
        }

        private void LoadIssuesAsEvents()
        {
            var issues = IssueManager.GetAllIssues();

            if (issues.Count > 0)
            {
                foreach (var issue in issues)
                {
                    // Convert each issue to an announcement/event
                    var issueEvent = new Event
                    {
                        EventId = 9000 + issue.IssueId, // Offset ID to avoid conflicts
                        Title = $"Issue Report: {issue.Category}",
                        Category = "Community Issues",
                        EventDate = issue.DateReported,
                        Description = $"Location: {issue.Location}\n\n{issue.Description}\n\nStatus: {issue.Status}\n\nReported Issue ID: #{issue.IssueId}",
                        Location = issue.Location,
                        Organizer = "Municipal Services - Citizen Report",
                        IsFeatured = issue.Status == "Under Review" || issue.Status == "In Progress"
                    };

                    EventManager.AddEvent(issueEvent);
                }
            }
        }

        private void LoadCategories()
        {
            comboBoxCategory.Items.Clear();
            comboBoxCategory.Items.Add("All Categories");

            var categories = EventManager.GetAllCategories().OrderBy(c => c);
            foreach (var category in categories)
            {
                comboBoxCategory.Items.Add(category);
            }

            comboBoxCategory.SelectedIndex = 0;
        }

        private void LoadSortOptions()
        {
            comboBoxSortOptions.Items.Clear();
            comboBoxSortOptions.Items.AddRange(new string[]
            {
                "Date (Ascending)",
                "Date (Descending)",
                "Title (A-Z)",
                "Title (Z-A)",
                "Category"
            });
            comboBoxSortOptions.SelectedIndex = 0;
        }

        private void LoadEvents(List<Event> events = null)
        {
            if (events == null)
            {
                events = EventManager.GetAllEvents();
            }

            currentEvents = EventManager.SortEvents(events, currentSortMethod);

            listBoxEvents.Items.Clear();
            foreach (var evt in currentEvents)
            {
                listBoxEvents.Items.Add(evt);
            }

            UpdateStatusBar();
        }

        private void LoadRecommendations()
        {
            listBoxRecommendations.Items.Clear();
            var recommendations = EventManager.GetRecommendedEvents();

            if (recommendations.Count == 0)
            {
                listBoxRecommendations.Items.Add("Search for events to get personalized recommendations!");
            }
            else
            {
                foreach (var evt in recommendations)
                {
                    listBoxRecommendations.Items.Add(evt);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string category = comboBoxCategory.SelectedItem?.ToString();
            if (category == "All Categories") category = null;

            DateTime? date = null;
            if (chkUseDate.Checked)
            {
                date = dateTimePickerEventDate.Value.Date;
            }

            string searchText = txtSearchKeyword.Text.Trim();
            if (string.IsNullOrEmpty(searchText)) searchText = null;

            var results = EventManager.SearchEvents(category, date, searchText);
            LoadEvents(results);

            // Update recommendations based on new search patterns
            LoadRecommendations();

            lblStatus.Text = $"Found {results.Count} event(s) matching your criteria";
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            txtSearchKeyword.Clear();
            comboBoxCategory.SelectedIndex = 0;
            chkUseDate.Checked = false;
            dateTimePickerEventDate.Value = DateTime.Now;

            LoadEvents();
            lblStatus.Text = "Filters cleared. Showing all events.";
        }

        private void comboBoxSortOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentSortMethod = comboBoxSortOptions.SelectedItem?.ToString() ?? "Date (Ascending)";
            LoadEvents(currentEvents);
        }

        private void listBoxEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxEvents.SelectedItem is Event selectedEvent)
            {
                DisplayEventDetails(selectedEvent);
                EventManager.RecordEventView(selectedEvent);
            }
        }

        private void DisplayEventDetails(Event evt)
        {
            richTextBoxEventDetails.Clear();

            // Title
            richTextBoxEventDetails.SelectionFont = new Font("Segoe UI", 14, FontStyle.Bold);
            richTextBoxEventDetails.SelectionColor = Color.FromArgb(41, 128, 185);
            richTextBoxEventDetails.AppendText(evt.Title + "\n\n");

            // Category badge
            richTextBoxEventDetails.SelectionFont = new Font("Segoe UI", 9, FontStyle.Bold);
            richTextBoxEventDetails.SelectionColor = Color.White;
            richTextBoxEventDetails.SelectionBackColor = GetCategoryColor(evt.Category);
            richTextBoxEventDetails.AppendText($" {evt.Category} ");
            richTextBoxEventDetails.SelectionBackColor = Color.White;

            if (evt.IsFeatured)
            {
                richTextBoxEventDetails.SelectionBackColor = Color.Gold;
                richTextBoxEventDetails.SelectionColor = Color.Black;
                richTextBoxEventDetails.AppendText(" ⭐ FEATURED ");
                richTextBoxEventDetails.SelectionBackColor = Color.White;
            }

            richTextBoxEventDetails.AppendText("\n\n");

            // Date and Time
            richTextBoxEventDetails.SelectionFont = new Font("Segoe UI", 10, FontStyle.Bold);
            richTextBoxEventDetails.SelectionColor = Color.Black;
            richTextBoxEventDetails.AppendText("📅 Date & Time:\n");
            richTextBoxEventDetails.SelectionFont = new Font("Segoe UI", 10, FontStyle.Regular);
            richTextBoxEventDetails.SelectionColor = Color.DimGray;
            richTextBoxEventDetails.AppendText($"{evt.EventDate:dddd, MMMM dd, yyyy 'at' hh:mm tt}\n\n");

            // Location
            richTextBoxEventDetails.SelectionFont = new Font("Segoe UI", 10, FontStyle.Bold);
            richTextBoxEventDetails.SelectionColor = Color.Black;
            richTextBoxEventDetails.AppendText("📍 Location:\n");
            richTextBoxEventDetails.SelectionFont = new Font("Segoe UI", 10, FontStyle.Regular);
            richTextBoxEventDetails.SelectionColor = Color.DimGray;
            richTextBoxEventDetails.AppendText($"{evt.Location}\n\n");

            // Organizer
            richTextBoxEventDetails.SelectionFont = new Font("Segoe UI", 10, FontStyle.Bold);
            richTextBoxEventDetails.SelectionColor = Color.Black;
            richTextBoxEventDetails.AppendText("👥 Organizer:\n");
            richTextBoxEventDetails.SelectionFont = new Font("Segoe UI", 10, FontStyle.Regular);
            richTextBoxEventDetails.SelectionColor = Color.DimGray;
            richTextBoxEventDetails.AppendText($"{evt.Organizer}\n\n");

            // Description
            richTextBoxEventDetails.SelectionFont = new Font("Segoe UI", 10, FontStyle.Bold);
            richTextBoxEventDetails.SelectionColor = Color.Black;
            richTextBoxEventDetails.AppendText("📝 Description:\n");
            richTextBoxEventDetails.SelectionFont = new Font("Segoe UI", 10, FontStyle.Regular);
            richTextBoxEventDetails.SelectionColor = Color.DimGray;
            richTextBoxEventDetails.AppendText($"{evt.Description}\n");

            richTextBoxEventDetails.SelectionStart = 0;
            richTextBoxEventDetails.ScrollToCaret();
        }

        private Color GetCategoryColor(string category)
        {
            return category switch
            {
                "Government" => Color.FromArgb(52, 73, 94),
                "Community" => Color.FromArgb(46, 204, 113),
                "Community Issues" => Color.FromArgb(231, 76, 60), // Red for reported issues
                "Education" => Color.FromArgb(52, 152, 219),
                "Culture" => Color.FromArgb(155, 89, 182),
                "Infrastructure" => Color.FromArgb(230, 126, 34),
                "Sports" => Color.FromArgb(231, 76, 60),
                "Business" => Color.FromArgb(26, 188, 156),
                "Safety" => Color.FromArgb(192, 57, 43),
                "Environment" => Color.FromArgb(39, 174, 96),
                "Health" => Color.FromArgb(41, 128, 185),
                _ => Color.Gray
            };
        }

        private void btnViewRecommendation_Click(object sender, EventArgs e)
        {
            // Check if an item is selected
            if (listBoxRecommendations.SelectedItem == null)
            {
                MessageBox.Show("Please select a recommended event to view.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Check if it's the placeholder message
            if (listBoxRecommendations.SelectedItem is string)
            {
                MessageBox.Show("No recommendations available yet. Try searching for events first!",
                    "No Recommendations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Get the selected event
            if (listBoxRecommendations.SelectedItem is Event selectedEvent)
            {
                // Clear any existing filters first
                btnClearFilters_Click(sender, e);

                // Give the UI a moment to refresh
                Application.DoEvents();

                // Find and select this event in the main list
                bool eventFound = false;
                for (int i = 0; i < listBoxEvents.Items.Count; i++)
                {
                    if (listBoxEvents.Items[i] is Event evt && evt.EventId == selectedEvent.EventId)
                    {
                        listBoxEvents.SelectedIndex = i;
                        listBoxEvents.TopIndex = Math.Max(0, i - 3); // Show event near top of visible area
                        eventFound = true;

                        // Ensure the details are displayed
                        DisplayEventDetails(evt);
                        EventManager.RecordEventView(evt);

                        lblStatus.Text = $"Viewing recommended event: {evt.Title}";
                        break;
                    }
                }

                if (!eventFound)
                {
                    MessageBox.Show($"Could not locate the event '{selectedEvent.Title}' in the current list.",
                        "Event Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a valid recommended event to view.", "Invalid Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void chkUseDate_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerEventDate.Enabled = chkUseDate.Checked;
        }

        private void UpdateStatusBar()
        {
            var stats = EventManager.GetCategoryStatistics();
            int totalEvents = currentEvents.Count;
            int allEvents = EventManager.GetTotalEventCount();

            lblStatus.Text = $"Displaying {totalEvents} of {allEvents} total events | " +
                           $"Categories: {stats.Count}";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 mainForm = new Form1();
            mainForm.Show();
            this.Close();
        }
    }
}