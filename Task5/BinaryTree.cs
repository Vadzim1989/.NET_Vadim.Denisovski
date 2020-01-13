using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Task5
{
    /// <summary>
    /// Class BinaryTree
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class BinaryTree<T> where T : IComparable
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public BinaryTree()
        {

        }
        /// <summary>
        /// Root node of Binary Tree
        /// </summary>
        public Node<T> Root { get; set; }
        /// <summary>
        /// Count of nodes in Binary Tree
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// Add new node in Binary Tree. Uses recursion
        /// </summary>
        /// <param name="data">Input object(type)</param>
        public void Add(T data)
        {
            var node = new Node<T>(data);
            if (Root == null)
            {
                Root = node;
                Count = 1;
                return;
            }
            Add(node, Root);
        }
        /// <summary>
        /// Private method for add new node. Recursion
        /// </summary>
        /// <param name="node">Input new node</param>
        /// <param name="root">Input parent node</param>
        private void Add(Node<T> node, Node<T> root)
        {
            if (node.CompareTo(root) == -1)
            {
                if (root.Left == null)
                {
                    root.Left = node;
                    Count++;
                }
                else Add(node, root.Left);
            }
            else
            {
                if (root.Right == null)
                {
                    root.Right = node;
                    Count++;
                }
                else
                    Add(node, root.Right);
            }
        }
        /// <summary>
        /// Clear Binary Tree for balance
        /// </summary>
        public void Clear()
        {
            Root = null;
            Count = 0;
        }
        /// <summary>
        /// Balance Binary Tree for less O. Rebuild Binary Tree
        /// </summary>
        public void Balance()
        {
            var _temp = new List<T>(Count);
            _temp = InOrder();
            var contains = _temp.Count() - 1;
            Clear();
            Balance(_temp, 0, contains);
        }
        /// <summary>
        /// Part of recursion of balance Binary Tree. 
        /// </summary>
        /// <param name="temp">list with objects of Binary Tree</param>
        /// <param name="start">start number of part temp List</param>
        /// <param name="end">end number of part temp List</param>
        private void Balance(List<T> temp, int start, int end)
        {
            if (start > end)
            {
                return;
            }
            int mid = (start + end) / 2;
            Add(temp[mid]);
            Balance(temp, start, mid - 1);
            Balance(temp, mid + 1, end);
        }
        /// <summary>
        /// Output sorted objects of Binary Tree
        /// </summary>
        /// <returns>Sorted List with objects</returns>
        public List<T> InOrder()
        {
            var output = new List<T>();
            if (Root != null)
            {
                output = InOrder(Root);
                return output;
            }
            else
            {
                throw new Exception("Empty BinaryTree");
            }
        }
        /// <summary>
        /// Part of recursion of Inorder output. Adds List to List
        /// </summary>
        /// <param name="node">Node of Binary Tree</param>
        /// <returns>Sorted List of elements Binary Tree</returns>
        private List<T> InOrder(Node<T> node)
        {
            var output = new List<T>();
            if (node != null)
            {
                if (node.Left != null)
                {
                    output.AddRange(InOrder(node.Left));
                }
                output.Add(node.Data);
                if (node.Right != null)
                {
                    output.AddRange(InOrder(node.Right));
                }
            }
            return output;
        }
    }
}
