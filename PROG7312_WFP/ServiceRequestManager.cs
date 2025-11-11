using System;
using System.Collections.Generic;
using System.Linq;

namespace PROG7312_WFP
{
    public static class ServiceRequestManager
    {
        // Data structures for efficient management
        private static BinarySearchTree<ServiceRequest> requestsBST = new BinarySearchTree<ServiceRequest>();
        private static MinHeap<ServiceRequest> priorityQueue = new MinHeap<ServiceRequest>();
        private static Graph<ServiceRequest> dependencyGraph = new Graph<ServiceRequest>();
        private static Dictionary<int, ServiceRequest> requestCache = new Dictionary<int, ServiceRequest>();

        private static int nextRequestId = 2001;
        private static readonly object lockObject = new object();

        // Initialize with sample data
        public static void InitializeSampleData()
        {
            if (requestCache.Count > 0) return;

            var sampleRequests = new[]
            {
                new { Desc = "Repair pothole on Main Street", Location = "Main Street & 5th Ave", Category = "Roads", Priority = ServiceRequestPriority.High, Status = ServiceRequestStatus.InProgress, Progress = 65, Assigned = "Road Maintenance Team A", DependsOn = new int[] { } },
                new { Desc = "Fix broken street light", Location = "Park Avenue", Category = "Street Lighting", Priority = ServiceRequestPriority.Medium, Status = ServiceRequestStatus.Approved, Progress = 30, Assigned = "Electrical Team", DependsOn = new int[] { } },
                new { Desc = "Clear blocked storm drain", Location = "5th Avenue", Category = "Utilities", Priority = ServiceRequestPriority.Critical, Status = ServiceRequestStatus.InProgress, Progress = 80, Assigned = "Drainage Team", DependsOn = new int[] { } },
                new { Desc = "Repair park bench", Location = "Central Park", Category = "Parks & Recreation", Priority = ServiceRequestPriority.Low, Status = ServiceRequestStatus.UnderReview, Progress = 10, Assigned = "Parks Department", DependsOn = new int[] { } },
                new { Desc = "Replace damaged road sign", Location = "Highway 101", Category = "Roads", Priority = ServiceRequestPriority.Medium, Status = ServiceRequestStatus.Submitted, Progress = 0, Assigned = "Unassigned", DependsOn = new int[] { 2001 } }, // Depends on pothole repair
                new { Desc = "Fix water main leak", Location = "Oak Street", Category = "Utilities", Priority = ServiceRequestPriority.Critical, Status = ServiceRequestStatus.InProgress, Progress = 45, Assigned = "Water Department", DependsOn = new int[] { } },
                new { Desc = "Trim overgrown trees", Location = "Maple Drive", Category = "Parks & Recreation", Priority = ServiceRequestPriority.Low, Status = ServiceRequestStatus.Approved, Progress = 20, Assigned = "Forestry Team", DependsOn = new int[] { } },
                new { Desc = "Repair traffic signal", Location = "Main & 1st Street", Category = "Roads", Priority = ServiceRequestPriority.High, Status = ServiceRequestStatus.InProgress, Progress = 55, Assigned = "Traffic Systems", DependsOn = new int[] { 2003 } }, // Depends on storm drain
                new { Desc = "Clean graffiti from building", Location = "Community Center", Category = "Sanitation", Priority = ServiceRequestPriority.Medium, Status = ServiceRequestStatus.Completed, Progress = 100, Assigned = "Sanitation Team", DependsOn = new int[] { } },
                new { Desc = "Install new playground equipment", Location = "Riverside Park", Category = "Parks & Recreation", Priority = ServiceRequestPriority.Medium, Status = ServiceRequestStatus.UnderReview, Progress = 5, Assigned = "Construction Team", DependsOn = new int[] { } },
                new { Desc = "Repair sidewalk crack", Location = "Elm Street", Category = "Infrastructure", Priority = ServiceRequestPriority.Low, Status = ServiceRequestStatus.Submitted, Progress = 0, Assigned = "Unassigned", DependsOn = new int[] { 2001 } }, // Depends on pothole repair
                new { Desc = "Fix leaking fire hydrant", Location = "Pine Street", Category = "Utilities", Priority = ServiceRequestPriority.High, Status = ServiceRequestStatus.Approved, Progress = 25, Assigned = "Water Department", DependsOn = new int[] { 2006 } }, // Depends on water main leak
                new { Desc = "Remove fallen tree", Location = "Forest Road", Category = "Parks & Recreation", Priority = ServiceRequestPriority.Critical, Status = ServiceRequestStatus.Completed, Progress = 100, Assigned = "Emergency Response", DependsOn = new int[] { } },
                new { Desc = "Repair bus shelter", Location = "Transit Stop 45", Category = "Infrastructure", Priority = ServiceRequestPriority.Medium, Status = ServiceRequestStatus.InProgress, Progress = 40, Assigned = "Facilities Team", DependsOn = new int[] { } },
                new { Desc = "Replace parking meter", Location = "Downtown Parking", Category = "Infrastructure", Priority = ServiceRequestPriority.Low, Status = ServiceRequestStatus.UnderReview, Progress = 15, Assigned = "Parking Services", DependsOn = new int[] { } }
            };

            foreach (var req in sampleRequests)
            {
                var request = new ServiceRequest(nextRequestId, req.Desc, req.Location, req.Category, req.Priority)
                {
                    Status = req.Status,
                    ProgressPercentage = req.Progress,
                    AssignedTo = req.Assigned,
                    DateSubmitted = DateTime.Now.AddDays(-new Random().Next(1, 30))
                };

                if (req.Status == ServiceRequestStatus.InProgress || req.Status == ServiceRequestStatus.Completed)
                {
                    request.EstimatedCompletion = DateTime.Now.AddDays(new Random().Next(5, 20));
                }

                request.DependsOn.AddRange(req.DependsOn);

                AddServiceRequest(request);
                nextRequestId++;
            }

            // Add dependencies to graph
            foreach (var request in requestCache.Values)
            {
                foreach (var depId in request.DependsOn)
                {
                    dependencyGraph.AddEdge(request.RequestId, depId);
                }
            }
        }

        // Add new service request
        public static void AddServiceRequest(ServiceRequest request)
        {
            lock (lockObject)
            {
                if (request.RequestId == 0)
                {
                    request.RequestId = nextRequestId++;
                }

                // Add to BST for fast lookup by ID
                requestsBST.Insert(request.RequestId, request);

                // Add to priority queue
                priorityQueue.Insert(request, (int)request.Priority);

                // Add to graph
                dependencyGraph.AddVertex(request.RequestId, request);

                // Add to cache
                requestCache[request.RequestId] = request;
            }
        }

        // Search by ID using BST - O(log n)
        public static ServiceRequest GetRequestById(int requestId)
        {
            lock (lockObject)
            {
                return requestCache.ContainsKey(requestId) ? requestCache[requestId] : null;
            }
        }

        // Get all requests
        public static List<ServiceRequest> GetAllRequests()
        {
            lock (lockObject)
            {
                return requestsBST.ToList();
            }
        }

        // Get requests by priority (using heap)
        public static List<ServiceRequest> GetRequestsByPriority()
        {
            lock (lockObject)
            {
                return priorityQueue.ToSortedList();
            }
        }

        // Get requests by status
        public static List<ServiceRequest> GetRequestsByStatus(ServiceRequestStatus status)
        {
            lock (lockObject)
            {
                return requestCache.Values.Where(r => r.Status == status).OrderBy(r => r.DateSubmitted).ToList();
            }
        }

        // Get dependencies for a request
        public static List<ServiceRequest> GetDependencies(int requestId)
        {
            lock (lockObject)
            {
                var dependencyIds = dependencyGraph.GetDependencies(requestId);
                return dependencyIds.Select(id => requestCache[id]).ToList();
            }
        }

        // Get dependents (requests that depend on this one)
        public static List<ServiceRequest> GetDependents(int requestId)
        {
            lock (lockObject)
            {
                var dependentIds = dependencyGraph.GetDependents(requestId);
                return dependentIds.Select(id => requestCache[id]).ToList();
            }
        }

        // Get all related requests using graph traversal
        public static List<ServiceRequest> GetRelatedRequests(int requestId)
        {
            lock (lockObject)
            {
                return dependencyGraph.BFS(requestId);
            }
        }

        // Update request status
        public static bool UpdateRequestStatus(int requestId, ServiceRequestStatus newStatus, int progress = -1)
        {
            lock (lockObject)
            {
                if (requestCache.ContainsKey(requestId))
                {
                    var request = requestCache[requestId];
                    request.Status = newStatus;

                    if (progress >= 0)
                    {
                        request.ProgressPercentage = Math.Min(progress, 100);
                    }

                    if (newStatus == ServiceRequestStatus.Completed)
                    {
                        request.ProgressPercentage = 100;
                    }

                    return true;
                }
                return false;
            }
        }

        // Search requests
        public static List<ServiceRequest> SearchRequests(string searchText)
        {
            lock (lockObject)
            {
                if (string.IsNullOrWhiteSpace(searchText))
                {
                    return GetAllRequests();
                }

                searchText = searchText.ToLower();
                return requestCache.Values.Where(r =>
                    r.Description.ToLower().Contains(searchText) ||
                    r.Location.ToLower().Contains(searchText) ||
                    r.Category.ToLower().Contains(searchText) ||
                    r.RequestId.ToString().Contains(searchText)).ToList();
            }
        }

        // Get statistics
        public static Dictionary<string, int> GetStatusStatistics()
        {
            lock (lockObject)
            {
                return requestCache.Values
                    .GroupBy(r => r.Status.ToString())
                    .ToDictionary(g => g.Key, g => g.Count());
            }
        }

        public static Dictionary<string, int> GetCategoryStatistics()
        {
            lock (lockObject)
            {
                return requestCache.Values
                    .GroupBy(r => r.Category)
                    .ToDictionary(g => g.Key, g => g.Count());
            }
        }

        public static Dictionary<string, int> GetPriorityStatistics()
        {
            lock (lockObject)
            {
                return requestCache.Values
                    .GroupBy(r => r.Priority.ToString())
                    .ToDictionary(g => g.Key, g => g.Count());
            }
        }

        // Get total count
        public static int GetTotalCount()
        {
            lock (lockObject)
            {
                return requestCache.Count;
            }
        }

        // Clear all data
        public static void ClearAll()
        {
            lock (lockObject)
            {
                requestsBST = new BinarySearchTree<ServiceRequest>();
                priorityQueue = new MinHeap<ServiceRequest>();
                dependencyGraph = new Graph<ServiceRequest>();
                requestCache.Clear();
                nextRequestId = 2001;
            }
        }
    }
}