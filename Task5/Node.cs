using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Task5
{
    [Serializable]
    public class Node<T> where T : IComparable
    {
        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public Node() { }
        /// <summary>
        /// Get/set node data
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// get/set left Node
        /// </summary>
        public Node<T> leftNode { get; set; }
        /// <summary>
        /// get/set right Node
        /// </summary>
        public Node<T> rightNode { get; set; }
        /// <summary>
        /// get/set parent Node
        /// </summary>
        public Node<T> parentNode { get; set; }
        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="data"></param>
        public Node(T data)
        {
            Data = data;
        }
        /// <summary>
        /// Data Comparison
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int CompareTo(T data)
        {
            return Data.CompareTo(data);
        }
        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var node = obj as Node<T>;
            return node != null &&
                   EqualityComparer<T>.Default.Equals(Data, node.Data) &&
                   EqualityComparer<Node<T>>.Default.Equals(leftNode, node.leftNode) &&
                   EqualityComparer<Node<T>>.Default.Equals(rightNode, node.rightNode) &&
                   EqualityComparer<Node<T>>.Default.Equals(parentNode, node.parentNode);
        }
        /// <summary>
        /// HashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            var hashCode = -1035467789;
            hashCode = hashCode * -1521134295 + EqualityComparer<T>.Default.GetHashCode(Data);
            hashCode = hashCode * -1521134295 + EqualityComparer<Node<T>>.Default.GetHashCode(leftNode);
            hashCode = hashCode * -1521134295 + EqualityComparer<Node<T>>.Default.GetHashCode(rightNode);
            hashCode = hashCode * -1521134295 + EqualityComparer<Node<T>>.Default.GetHashCode(parentNode);
            return hashCode;
        }       
    }
}
