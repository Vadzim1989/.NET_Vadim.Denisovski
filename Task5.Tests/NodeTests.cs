using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task5;

namespace Task5.Tests
{
    /// <summary>
    /// Summary description for NodeTests
    /// </summary>
    [TestClass]
    public class NodeTests
    {
        /// <summary>
        /// create node
        /// </summary>
        [TestMethod]
        public void CreateNode()
        {
            // arrange 
            Node<int> node = new Node<int>();
            // action
            node.Data = 10;
            // assert
            Assert.IsTrue(node.Data == 10);
        }
        /// <summary>
        /// Equals
        /// </summary>
        [TestMethod]
        public void EqualsTest()
        {
            // arrange
            Node<int> node1 = new Node<int>();
            Node<int> node2 = new Node<int>();
            // action
            node1.Data = 10;
            node2.Data = 10;
            // assert
            Assert.IsTrue(node1.Equals(node2));
        }
    }
}
