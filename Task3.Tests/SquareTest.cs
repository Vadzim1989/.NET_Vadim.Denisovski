using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3.Shapes;

namespace Task3.Tests
{
    [TestClass]
    public class SquareTest
    {
        /// <summary>
        /// Test circle square
        /// </summary>
        [TestMethod]
        public void CircleSquare()
        {
            //Arrange
            double square = 78.5398;
            //Action
            Figure circle = new Circle(Material.Paper, 5);
            //Assert
            Assert.IsTrue(square == circle.GetSquare());
        }
        /// <summary>
        /// Test triangle square
        /// </summary>
        [TestMethod]
        public void TriangleSquare()
        {
            //Arrange
            double square = 4.145781;
            //Action
            Figure triangle = new Triangle(Material.Paper, 3, 3, 5);
            //Assert
            Assert.IsTrue(square == triangle.GetSquare());
        }
        /// <summary>
        /// Test quadrate square
        /// </summary>
        [TestMethod]
        public void QuadrateTest()
        {
            //Arrange
            double square = 25;
            //Action
            Figure quadrate = new Quadrate(Material.Paper, 5);
            //Assert
            Assert.IsTrue(square == quadrate.GetSquare());
        }
    }
}
