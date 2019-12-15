using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3.Shapes;

namespace Task3.Tests
{
    [TestClass]
    public class PaintTest
    {
        /// <summary>
        /// Paint circle
        /// </summary>
        [TestMethod]
        public void CirclePaint_MaterialPaper()
        {
            //Arrange
            double radius = 3;          
            //Action
            Figure circle = new Circle(Material.Paper, radius);
            circle.Paint(Colors.Black);
            //Assert
            Colors colors = Colors.Black;
            Assert.IsTrue(colors == circle.Colors);
        }
        /// <summary>
        /// Paint triangle
        /// </summary>
        [TestMethod]
        public void TrianglePaint_MaterialPaper()
        {
            //Arrange
            double a = 2, b = 3, c = 4;
            //Action
            Figure triangle = new Triangle(Material.Paper, a, b, c);
            triangle.Paint(Colors.Blue);
            //Assert
            Colors colors = Colors.Blue;
            Assert.IsTrue(colors == triangle.Colors);
        }
        /// <summary>
        /// Paint quadrate
        /// </summary>
        [TestMethod]
        public void QuadratePaint_MaterialPaper()
        {
            //Arrange
            double size = 5;
            //Action
            Figure quadrate = new Quadrate(Material.Paper, size);
            quadrate.Paint(Colors.Green);
            //Assert
            Colors colors = Colors.Green;
            Assert.IsTrue(colors == quadrate.Colors);
        }
    }
}
