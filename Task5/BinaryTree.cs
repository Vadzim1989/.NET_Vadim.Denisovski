using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Task5
{
    [Serializable]
    public class BinaryTree<T> : IComparable where T : IComparable
    {
        /// <summary>
        /// constructor without parameters
        /// </summary>
        public BinaryTree() { }
        /// <summary>
        /// Contains the number of nodes
        /// </summary>
        private int countNode;
        /// <summary>
        /// Node with specified data
        /// </summary>
        private Node<T> treeNode;
        /// <summary>
        /// NEW parent node
        /// </summary>
        private Node<T> parentNode;
        /// <summary>
        /// Adds the specified data
        /// </summary>
        /// <param name="data"></param>
        public void addNode(T data)
        {
            if (treeNode == null)
            {
                treeNode = new Node<T>(data);
            }
            else
            {
                findNode(treeNode, data);
            }
        }
        /// <summary>
        /// Finds the node
        /// </summary>
        /// <param name="treeNode"></param>
        /// <param name="data"></param>
        private void findNode(Node<T> treeNode, T data)
        {

            if (data.CompareTo(treeNode.Data) < 0)
            {
                if (treeNode.leftNode == null)
                {
                    treeNode.leftNode = new Node<T>(data);
                }
                else
                {
                    findNode(treeNode.leftNode, data);
                }
            }
            else
            {
                if (treeNode.rightNode == null)
                {
                    treeNode.rightNode = new Node<T>(data);
                }
                else
                {
                    findNode(treeNode.rightNode, data);
                }
            }
        }
        /// <summary>
        /// Show information about nodes
        /// </summary>
        /// <param name="data"></param>
        /// <param name="parentNode"></param>
        /// <returns></returns>
        private Node<T> ShowInformation(T data, out Node<T> parentNode)
        {
            Node<T> node = treeNode;
            parentNode = null;

            while (node != null)
            {
                int result = node.CompareTo(data);

                if (result > 0)
                {
                    parentNode = node;
                    node = node.leftNode;
                }
                else if (result < 0)
                {
                    parentNode = node;
                    node = node.rightNode;
                }
                else
                {
                    break;
                }
            }

            return node;
        }
        /// <summary>
        /// Removes the specified node
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool RemoveNode(T data)
        {
            Node<T> node;
            Node<T> parentNode;

            node = ShowInformation(data, out parentNode);

            if (node == null)
            {
                return false;
            }

            countNode--;

            if (node.rightNode == null)
            {
                if (parentNode == null)
                {
                    treeNode = node.leftNode;
                }
                else
                {
                    int result = parentNode.CompareTo(node.Data);
                    if (result > 0)
                    {
                        parentNode.leftNode = node.leftNode;
                    }
                    else if (result < 0)
                    {
                        parentNode.rightNode = node.leftNode;
                    }
                }
            }
            else if (node.rightNode.leftNode == null)
            {
                node.rightNode.leftNode = node.leftNode;

                if (parentNode == null)
                {
                    treeNode = node.rightNode;
                }
                else
                {
                    int result = parentNode.CompareTo(node.Data);
                    if (result > 0)
                    {
                        parentNode.leftNode = node.rightNode;
                    }
                    else if (result < 0)
                    {
                        parentNode.rightNode = node.rightNode;
                    }
                }
            }
            else
            {
                Node<T> leftBranch = node.rightNode.leftNode;
                Node<T> leftParent = node.rightNode;
                while (leftBranch.leftNode != null)
                {
                    leftParent = leftBranch; leftBranch = leftBranch.leftNode;
                }

                leftParent.leftNode = leftBranch.rightNode;
                leftBranch.leftNode = node.leftNode;
                leftBranch.rightNode = node.rightNode;
                if (parentNode == null)
                {
                    treeNode = leftBranch;
                }
                else
                {
                    int result = parentNode.CompareTo(node.Data);
                    if (result > 0)
                    {
                        parentNode.rightNode = leftBranch;
                    }
                    else if (result < 0)
                    {
                        parentNode.rightNode = leftBranch;
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// object Comparison
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
