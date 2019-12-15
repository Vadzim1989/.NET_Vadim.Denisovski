using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3.Shapes;

namespace Task3.Tests
{
    [TestClass]
    public class PerimeterTest
    {
        /// <summary>
        /// Test circle perimeter
        /// </summary>
        [TestMethod]
        public void CirclePerimeter()
        {
            //Arrange
            double perimeter = 12.566368;
            //Action
            Figure circle = new Circle(Material.Paper, 2);
            //Assert
            Assert.IsTrue(perimeter == circle.GetPerimeter());
        }
        /// <summary>
        /// Test triangle perimeter
        /// </summary>
        [TestMethod]
        public void TrianglePerimeter()
        {
            //Arrange
            double perimeter = 15;
            //Action
            Figure triangle = new Triangle(Material.Paper, 5, 5, 5);
            //Assert
            Assert.IsTrue(perimeter == triangle.GetPerimeter());
        }
        /// <summary>
        /// Test quadrate test
        /// </summary>
        [TestMethod]
        public void QudratePerimeter()
        {
            //Arrange
            double perimeter = 8;
            //Action
            Figure quadrate = new Quadrate(Material.Paper, 2);
            //Assert
            Assert.IsTrue(perimeter == quadrate.GetPerimeter());
        }
    }
}
