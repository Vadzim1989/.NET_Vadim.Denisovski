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
            int a = 48; // переменная которую будем передавать в метод Стейна
            int b = 36; // переменная которую будем передавать в метод Стейна
            int expeted = 12; // ожидаемый результат 
            // action
            Staine st = new Staine(); // создаем обьъект класса Staine
            int actual = st.GetBiGCD(a, b); // вызываем метод для рассчета алгоритма Стейна. Передаем наши переменный.
            // assert
            Assert.AreEqual(expeted, actual); // производим сравнение ожидаемого результата с реальным результатом.
        }
    }
}
