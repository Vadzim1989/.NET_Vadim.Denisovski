using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Euklides.Tests
{
    /// <summary>
    /// Summary description for StaineTests
    /// </summary>
    [TestClass]
    public class StaineTests
    {        
        [TestMethod]
        public void GetBiGCD_48and36_12returned()
        {
            // arrange
            int a = 48;
            int b = 36;
            int expeted = 12;
            // action
            Staine st = new Staine();
            int actual = st.GetBiGCD(a, b);
            // assert
            Assert.AreEqual(expeted, actual);
        }
    }
}
