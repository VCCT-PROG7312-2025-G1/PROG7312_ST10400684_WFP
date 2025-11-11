using System;
using System.Collections.Generic;

namespace PROG7312_WFP
{
    // Min Heap for Priority Queue (lower priority number = higher priority)
    public class MinHeap<T> where T : IComparable<T>
    {
        private class HeapNode
        {
            public int Priority { get; set; }
            public T Data { get; set; }

            public HeapNode(int priority, T data)
            {
                Priority = priority;
                Data = data;
            }
        }

        private List<HeapNode> heap;

        public MinHeap()
        {
            heap = new List<HeapNode>();
        }

        public int Count => heap.Count;

        public bool IsEmpty => heap.Count == 0;

        // Insert element with priority - O(log n)
        public void Insert(T data, int priority)
        {
            HeapNode newNode = new HeapNode(priority, data);
            heap.Add(newNode);
            HeapifyUp(heap.Count - 1);
        }

        // Extract minimum priority element - O(log n)
        public T ExtractMin()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Heap is empty");
            }

            T min = heap[0].Data;

            // Move last element to root
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);

            if (!IsEmpty)
            {
                HeapifyDown(0);
            }

            return min;
        }

        // Peek at minimum without removing - O(1)
        public T PeekMin()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Heap is empty");
            }

            return heap[0].Data;
        }

        // Get all elements as list (not in sorted order)
        public List<T> ToList()
        {
            List<T> result = new List<T>();
            foreach (var node in heap)
            {
                result.Add(node.Data);
            }
            return result;
        }

        // Get elements in priority order (creates a copy to avoid modifying heap)
        public List<T> ToSortedList()
        {
            List<T> result = new List<T>();
            MinHeap<T> tempHeap = new MinHeap<T>();

            // Copy all elements to temp heap
            foreach (var node in heap)
            {
                tempHeap.Insert(node.Data, node.Priority);
            }

            // Extract all in order
            while (!tempHeap.IsEmpty)
            {
                result.Add(tempHeap.ExtractMin());
            }

            return result;
        }

        private void HeapifyUp(int index)
        {
            while (index > 0)
            {
                int parentIndex = (index - 1) / 2;

                if (heap[index].Priority >= heap[parentIndex].Priority)
                {
                    break;
                }

                // Swap with parent
                Swap(index, parentIndex);
                index = parentIndex;
            }
        }

        private void HeapifyDown(int index)
        {
            int lastIndex = heap.Count - 1;

            while (true)
            {
                int leftChild = 2 * index + 1;
                int rightChild = 2 * index + 2;
                int smallest = index;

                if (leftChild <= lastIndex && heap[leftChild].Priority < heap[smallest].Priority)
                {
                    smallest = leftChild;
                }

                if (rightChild <= lastIndex && heap[rightChild].Priority < heap[smallest].Priority)
                {
                    smallest = rightChild;
                }

                if (smallest == index)
                {
                    break;
                }

                Swap(index, smallest);
                index = smallest;
            }
        }

        private void Swap(int i, int j)
        {
            HeapNode temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }

        // Clear all elements
        public void Clear()
        {
            heap.Clear();
        }
    }
}