using System;
using Task_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task_2.Tests
{
    [TestClass]
    public class VectorTests
    {
        [TestMethod]
        public void operator_plus()
        {
            // arrange
            Vector v1 = new Vector(5, 8, 2);
            Vector v2 = new Vector(2, 2, 2);
            double x = 7, y = 10, z = 4;
            // action
            Vector v3 = v1 + v2;
            // assert
            Assert.IsTrue(x == v3.GetX() & y == v3.GetY() & z == v3.GetZ());
        }

        [TestMethod]
        public void operator_minus()
        {
            // arrange
            Vector v1 = new Vector(5, 8, 2);
            Vector v2 = new Vector(5, 7, 2);
            double x = 0, y = 1, z = 0;
            // action
            Vector v3 = v1 - v2;
            // assert
            Assert.IsTrue(x == v3.GetX() & y == v3.GetY() & z == v3.GetZ());
        }

        [TestMethod]
        public void operator_multip()
        {
            // arrange
            Vector v1 = new Vector(2, 3, 4);
            Vector v2 = new Vector(2, 2, 2);
            double x = 4, y = 6, z = 8;
            // action
            Vector v3 = v1 * v2;
            // assert
            Assert.IsTrue(x == v3.GetX() & y == v3.GetY() & z == v3.GetZ());
        }

        [TestMethod]
        public void operator_equal()
        {
            // arrange
            Vector v1 = new Vector(2, 3, 4);
            Vector v2 = new Vector(2, 3, 4);
            // action
            //...
            // assert
            Assert.IsTrue(v1 == v2);
        }

        [TestMethod]
        public void operator_inequal()
        {
            // arrange
            Vector v1 = new Vector(2, 3, 4);
            Vector v2 = new Vector(2, 4, 4);
            // action
            //...
            // assert
            Assert.IsTrue(v1 != v2);
        }
    }
}
