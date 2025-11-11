using System;
using System.Collections.Generic;
using System.Linq;

namespace PROG7312_WFP
{
    // Graph implementation for managing service request dependencies
    public class Graph<T>
    {
        private Dictionary<int, T> vertices;
        private Dictionary<int, List<int>> adjacencyList;

        public Graph()
        {
            vertices = new Dictionary<int, T>();
            adjacencyList = new Dictionary<int, List<int>>();
        }

        // Add a vertex
        public void AddVertex(int key, T data)
        {
            if (!vertices.ContainsKey(key))
            {
                vertices[key] = data;
                adjacencyList[key] = new List<int>();
            }
        }

        // Add a directed edge (from -> to)
        public void AddEdge(int from, int to)
        {
            if (!adjacencyList.ContainsKey(from))
            {
                AddVertex(from, default(T));
            }

            if (!adjacencyList.ContainsKey(to))
            {
                AddVertex(to, default(T));
            }

            if (!adjacencyList[from].Contains(to))
            {
                adjacencyList[from].Add(to);
            }
        }

        // Get vertex data
        public T GetVertex(int key)
        {
            return vertices.ContainsKey(key) ? vertices[key] : default(T);
        }

        // Get all vertices
        public List<T> GetAllVertices()
        {
            return vertices.Values.ToList();
        }

        // Get dependencies (outgoing edges)
        public List<int> GetDependencies(int key)
        {
            return adjacencyList.ContainsKey(key) ? new List<int>(adjacencyList[key]) : new List<int>();
        }

        // Get dependents (incoming edges)
        public List<int> GetDependents(int key)
        {
            List<int> dependents = new List<int>();

            foreach (var kvp in adjacencyList)
            {
                if (kvp.Value.Contains(key))
                {
                    dependents.Add(kvp.Key);
                }
            }

            return dependents;
        }

        // Breadth-First Search traversal
        public List<T> BFS(int startKey)
        {
            List<T> result = new List<T>();
            HashSet<int> visited = new HashSet<int>();
            Queue<int> queue = new Queue<int>();

            if (!vertices.ContainsKey(startKey))
            {
                return result;
            }

            queue.Enqueue(startKey);
            visited.Add(startKey);

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();
                result.Add(vertices[current]);

                foreach (int neighbor in adjacencyList[current])
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }

            return result;
        }

        // Depth-First Search traversal
        public List<T> DFS(int startKey)
        {
            List<T> result = new List<T>();
            HashSet<int> visited = new HashSet<int>();

            if (vertices.ContainsKey(startKey))
            {
                DFSRecursive(startKey, visited, result);
            }

            return result;
        }

        private void DFSRecursive(int key, HashSet<int> visited, List<T> result)
        {
            visited.Add(key);
            result.Add(vertices[key]);

            foreach (int neighbor in adjacencyList[key])
            {
                if (!visited.Contains(neighbor))
                {
                    DFSRecursive(neighbor, visited, result);
                }
            }
        }

        // Topological Sort (for dependency resolution)
        public List<T> TopologicalSort()
        {
            Dictionary<int, int> inDegree = new Dictionary<int, int>();
            List<T> result = new List<T>();

            // Calculate in-degrees
            foreach (var key in vertices.Keys)
            {
                inDegree[key] = 0;
            }

            foreach (var kvp in adjacencyList)
            {
                foreach (var neighbor in kvp.Value)
                {
                    inDegree[neighbor]++;
                }
            }

            // Queue for vertices with in-degree 0
            Queue<int> queue = new Queue<int>();
            foreach (var kvp in inDegree)
            {
                if (kvp.Value == 0)
                {
                    queue.Enqueue(kvp.Key);
                }
            }

            // Process vertices
            while (queue.Count > 0)
            {
                int current = queue.Dequeue();
                result.Add(vertices[current]);

                foreach (int neighbor in adjacencyList[current])
                {
                    inDegree[neighbor]--;
                    if (inDegree[neighbor] == 0)
                    {
                        queue.Enqueue(neighbor);
                    }
                }
            }

            // Check for cycles
            if (result.Count != vertices.Count)
            {
                throw new InvalidOperationException("Graph contains a cycle");
            }

            return result;
        }

        // Check if there's a path between two vertices
        public bool HasPath(int from, int to)
        {
            if (!vertices.ContainsKey(from) || !vertices.ContainsKey(to))
            {
                return false;
            }

            HashSet<int> visited = new HashSet<int>();
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(from);
            visited.Add(from);

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();

                if (current == to)
                {
                    return true;
                }

                foreach (int neighbor in adjacencyList[current])
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }

            return false;
        }

        // Get vertex count
        public int VertexCount => vertices.Count;

        // Get edge count
        public int EdgeCount
        {
            get
            {
                int count = 0;
                foreach (var list in adjacencyList.Values)
                {
                    count += list.Count;
                }
                return count;
            }
        }

        // Clear the graph
        public void Clear()
        {
            vertices.Clear();
            adjacencyList.Clear();
        }
    }
}