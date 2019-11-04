using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Euklides.Tests
{
    [TestClass]
    public class EuklidesTests
    {
        [TestMethod]
        public void GetGCD_48and36_12returned()
        {            
            // arrange
            int a = 48;
            int b = 36;
            int expeted = 12;
            // action
            Euklides ea = new Euklides();
            int actual = ea.GetGCD(a, b);
            // assert
            Assert.AreEqual(expeted, actual);
        }
    }
}
