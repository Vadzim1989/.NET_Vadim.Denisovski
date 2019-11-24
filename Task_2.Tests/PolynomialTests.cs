using System;
using Task_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task_2.Tests
{   
    [TestClass]
    public class PolynomialTests
    {       
        [TestMethod]
        public void CalculateTest()
        {
            // Arrange
            Polynomial P1 = new Polynomial(2, 3, 4);
            int x = 2;
            double result = 24;
            // Action
            var CalcResult = P1.Calculate(x);
            // Assert
            Assert.AreEqual(result, CalcResult);
        }

        [TestMethod]
        public void operator_plus()
        {
            // Arrange
            Polynomial P1 = new Polynomial(2, 3, 4);
            Polynomial P2 = new Polynomial(1, 2, 3);
            int x = 2;
            double result = 41;
            // Action
            Polynomial P3 = P1 + P2;
            var CalcResult = P3.Calculate(x);
            // Assert
            Assert.AreEqual(result, CalcResult);
        }

        [TestMethod]
        public void operator_minus()
        {
            // Arrange
            Polynomial P1 = new Polynomial(2, 3, 4);
            Polynomial P2 = new Polynomial(1, 2, 3);
            int x = 2;
            double result = 7;
            // Action
            Polynomial P3 = P1 - P2;
            var CalcResult = P3.Calculate(x);
            // Assert
            Assert.AreEqual(result, CalcResult);
        }

        [TestMethod]
        public void operator_equal()
        {
            // Arrange
            Polynomial P1 = new Polynomial(2, 3, 4);
            Polynomial P2 = new Polynomial(2, 3, 4);            
            // Action
            // ...
            // Assert
            Assert.IsTrue(P1==P2);
        }

        [TestMethod]
        public void operator_inequal()
        {
            // arrange
            Polynomial P1 = new Polynomial(2, 3, 4);
            Polynomial P2 = new Polynomial(2, 3, 5);
            // action
            //...
            // assert
            Assert.IsTrue(P1 != P2);
        }
    }
}
