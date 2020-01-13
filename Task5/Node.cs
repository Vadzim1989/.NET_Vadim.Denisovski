using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Task5
{
    /// <summary>
    /// Class Node
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class Node<T> where T : IComparable
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Node()
        {
        }
        /// <summary>
        /// Data of object
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// Left Node of parent node
        /// </summary>
        public Node<T> Left { get; set; }
        /// <summary>
        /// Right Node of parent Node
        /// </summary>
        public Node<T> Right { get; set; }
        /// <summary>
        /// Constructor of node
        /// </summary>
        /// <param name="data">Data of input object</param>
        public Node(T data)
        {
            Data = data;
        }
        /// <summary>
        /// Create parent node with left and right node
        /// </summary>
        /// <param name="data">Data of input object</param>
        /// <param name="left">Left Node</param>
        /// <param name="right">Right Node</param>
        public Node(T data, Node<T> left, Node<T> right)
        {
            Data = data;
            Left = left;
            Right = right;
        }
        /// <summary>
        /// Realization of IComparable
        /// </summary>
        /// <param name="other">Input object for compare</param>
        /// <returns>-1 for less, 0 for equal, 1 for more</returns>
        public int CompareTo(Node<T> other)
        {
            if (other is Node<T> c)
            {
                return this.Data.CompareTo(c.Data);
            }
            else throw new Exception("Wrong node");
        }
    }
}
