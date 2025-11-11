using System;
using System.Collections.Generic;
using System.Text;

namespace PROG7312_WFP
{
    public class ServiceRequest : IComparable<ServiceRequest>
    {
        public int RequestId { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public DateTime DateSubmitted { get; set; }
        public ServiceRequestStatus Status { get; set; }
        public ServiceRequestPriority Priority { get; set; }
        public List<int> DependsOn { get; set; }
        // Dependencies for graph structure
        public string AssignedTo { get; set; }
        public DateTime? EstimatedCompletion { get; set; }
        public int ProgressPercentage { get; set; }

        public ServiceRequest()
        {
            DependsOn = new List<int>();
            DateSubmitted = DateTime.Now;
            Description = string.Empty;
            Location = string.Empty;
            Category = string.Empty;
            AssignedTo = "Unassigned";
            ProgressPercentage = 0;
            Status = ServiceRequestStatus.Submitted;
            Priority = ServiceRequestPriority.Low;
        }

        public ServiceRequest(int id, string description, string location, string category, ServiceRequestPriority priority)
        {
            RequestId = id;
            Description = description;
            Location = location;
            Category = category;
            Priority = priority;
            DependsOn = new List<int>();
            DateSubmitted = DateTime.Now;
            AssignedTo = "Unassigned";
            ProgressPercentage = 0;
            Status = ServiceRequestStatus.Submitted;
        }

        public override string ToString()
        {
            return $"[{RequestId}] {Description} ({Category}) - {Status} - Priority: {Priority}";
        }

        public string GetDetailedInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Request ID: {RequestId}");
            sb.AppendLine($"Description: {Description}");
            sb.AppendLine($"Location: {Location}");
            sb.AppendLine($"Category: {Category}");
            sb.AppendLine($"Submitted: {DateSubmitted}");
            sb.AppendLine($"Status: {Status}");
            sb.AppendLine($"Priority: {Priority}");
            sb.AppendLine($"Assigned To: {AssignedTo}");
            sb.AppendLine($"Progress: {ProgressPercentage}%");
            if (EstimatedCompletion.HasValue)
                sb.AppendLine($"Estimated Completion: {EstimatedCompletion.Value}");
            if (DependsOn != null && DependsOn.Count > 0)
                sb.AppendLine($"Depends On: {string.Join(", ", DependsOn)}");
            return sb.ToString();
        }

        // Implement IComparable<ServiceRequest> so ServiceRequest can be used with generic data structures that require comparison.
        // Comparison is primarily by RequestId to provide a stable ordering; modify if a different ordering is desired.
        public int CompareTo(ServiceRequest? other)
        {
            if (other is null) return 1;
            return RequestId.CompareTo(other.RequestId);
        }
    }

    public enum ServiceRequestStatus
    {
        Submitted,
        UnderReview,
        Approved,
        InProgress,
        OnHold,
        Completed,
        Rejected
    }

    public enum ServiceRequestPriority
    {
        Low = 1,
        Medium = 2,
        High = 3,
        Critical = 4
    }
}   