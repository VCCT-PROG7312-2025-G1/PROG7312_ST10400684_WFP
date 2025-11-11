using System;
using System.Collections.Generic;

namespace PROG7312_WFP
{
    // Binary Search Tree Node
    public class BSTNode<T> where T : IComparable<T>
    {
        public int Key { get; set; }
        public T Data { get; set; }
        public BSTNode<T> Left { get; set; }
        public BSTNode<T> Right { get; set; }

        public BSTNode(int key, T data)
        {
            Key = key;
            Data = data;
            Left = null;
            Right = null;
        }
    }

    // Binary Search Tree Implementation
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        private BSTNode<T> root;

        public BinarySearchTree()
        {
            root = null;
        }

        // Insert a new node
        public void Insert(int key, T data)
        {
            root = InsertRecursive(root, key, data);
        }

        private BSTNode<T> InsertRecursive(BSTNode<T> node, int key, T data)
        {
            if (node == null)
            {
                return new BSTNode<T>(key, data);
            }

            if (key < node.Key)
            {
                node.Left = InsertRecursive(node.Left, key, data);
            }
            else if (key > node.Key)
            {
                node.Right = InsertRecursive(node.Right, key, data);
            }
            else
            {
                // Update existing node
                node.Data = data;
            }

            return node;
        }

        // Search for a node by key - O(log n) average case
        public T Search(int key)
        {
            BSTNode<T> result = SearchRecursive(root, key);
            return result != null ? result.Data : default(T);
        }

        private BSTNode<T> SearchRecursive(BSTNode<T> node, int key)
        {
            if (node == null || node.Key == key)
            {
                return node;
            }

            if (key < node.Key)
            {
                return SearchRecursive(node.Left, key);
            }

            return SearchRecursive(node.Right, key);
        }

        // In-order traversal (sorted order)
        public List<T> InOrderTraversal()
        {
            List<T> result = new List<T>();
            InOrderRecursive(root, result);
            return result;
        }

        private void InOrderRecursive(BSTNode<T> node, List<T> result)
        {
            if (node != null)
            {
                InOrderRecursive(node.Left, result);
                result.Add(node.Data);
                InOrderRecursive(node.Right, result);
            }
        }

        // Get all elements as list
        public List<T> ToList()
        {
            return InOrderTraversal();
        }

        // Gets height of tree
        public int GetHeight()
        {
            return GetHeightRecursive(root);
        }

        private int GetHeightRecursive(BSTNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            int leftHeight = GetHeightRecursive(node.Left);
            int rightHeight = GetHeightRecursive(node.Right);

            return Math.Max(leftHeight, rightHeight) + 1;
        }

        // Check if tree is empty
        public bool IsEmpty()
        {
            return root == null;
        }

        // Get node count
        public int Count()
        {
            return CountRecursive(root);
        }

        private int CountRecursive(BSTNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            return 1 + CountRecursive(node.Left) + CountRecursive(node.Right);
        }

        // Finds minimum 
        public int FindMin()
        {
            if (root == null)
            {
                throw new InvalidOperationException("Tree is empty");
            }

            BSTNode<T> current = root;
            while (current.Left != null)
            {
                current = current.Left;
            }

            return current.Key;
        }

        // Finds maximum
        public int FindMax()
        {
            if (root == null)
            {
                throw new InvalidOperationException("Tree is empty");
            }

            BSTNode<T> current = root;
            while (current.Right != null)
            {
                current = current.Right;
            }

            return current.Key;
        }
    }
}