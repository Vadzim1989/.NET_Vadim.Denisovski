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
            int a = 48; // переменная которую будем передавать в метод Евклида
            int b = 36; // переменная которую будем передавать в метод Евклида
            int expeted = 12; // ожидаемый результат 
            // action
            Euklides ea = new Euklides(); // создаем обьъект класса Euklides
            int actual = ea.GetGCD(a, b); // вызываем метод для рассчета алгоритма Евклида. Передаем наши переменный.
            // assert
            Assert.AreEqual(expeted, actual); // производим сравнение ожидаемого результата с реальным результатом.
        }
    }
}
