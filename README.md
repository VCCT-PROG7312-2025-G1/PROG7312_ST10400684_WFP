# Municipal Services Application - Simple Guide

https://github.com/VCCT-PROG7312-2025-G1/PROG7312_ST10400684_WFP 

### YT Video link

https://youtu.be/96UPO6nRfqs 

## Classes Explained:

### Issue.cs

holds information about one reported issue (location, category, description, status).

### IssueManager.cs

Manages all reported issues. Stores them in a LinkedList and provides methods to add, search, and retrieve issues.

### Event.cs

holds information about one event or announcement (title, date, location, category, organizer).

### EventManager.cs

main logic of Part 2. Stores all events using multiple data structures, tracks user behavior, and provides the recommendation algorithm.

### IssueSampleData.cs

Loads 15+ sample issues when the app starts so you have test data to work with.

### ReportForm.cs

The form where users fill out and submit new issue reports. Shows progress bar and handles file uploads.

### EventsForm.cs

The main events page where users can browse, search, filter, and sort events. Shows recommendations based on search patterns.

### Form1.cs

The main menu with buttons to access Report Issues, Local Events, and Service Status.

### Program.cs

Starts the application and loads sample data.


## Data Structures Used

### LinkedList<Issue>

Class: IssueManager.cs

Line: 57

Variable: reportedIssues

Purpose: Stores all reported issues (Part 1 requirement)



### SortedDictionary<DateTime, List<Event>>

Class: EventManager.cs

Line: 17

Variable: eventsOrganizedByDate

Purpose: Automatically sorts events by date



### Dictionary<string, List<Event>>

Class: EventManager.cs

Line: 25

Variable: eventsOrganizedByCategory

Purpose: Fast lookup of events by category



### HashSet<string>

Class: EventManager.cs

Line: 32

Variable: allUniqueCategories

Purpose: Stores unique category names without duplicates



### Stack<Event>

Class: EventManager.cs

Line: 39

Variable: recentlyViewedEvents

Purpose: Tracks last 10 events viewed (LIFO - Last In First Out)



### Queue<Event>

Class: EventManager.cs

Line: 46

Variable: upcomingFeaturedEvents

Purpose: Manages featured events in order (FIFO - First In First Out)



### Dictionary<string, int>

Class: EventManager.cs

Line: 58

Variable: categorySearchFrequency

Purpose: Counts how many times each category is searched (for recommendations)



### Dictionary<DateTime, int>

Class: EventManager.cs

Line: 65

Variable: dateSearchFrequency

Purpose: Counts how many times each date is searched (for recommendations)


### Where is it saving

Once ran it saves to a local file called issues.json


## Recommendation Algorithm

Class: EventManager.cs

Method: GetRecommendedEvents()

Lines: 256-306

How it works: Analyzes which categories users search most, finds upcoming events in those categories, excludes already-viewed events, returns top 6 recommendations.

these links listed below shows what I used AI for aswell as comments in my code showing what I used CO-Pilot for.
## Troubleshooting
https://gemini.google.com/app/2b7f648e6a68ceb5 

https://claude.ai/share/c8242126-5e7c-45f6-985a-9a0f44d994ea 

# REFERENCES
https://docs.github.com/en/get-started/writing-on-github/getting-started-with-writing-and-formatting-on-github/basic-writing-and-formatting-syntax 
