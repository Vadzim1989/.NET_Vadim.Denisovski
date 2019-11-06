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
            int expected = 12; // ожидаемый результат 
            // action
            Euklides ea = new Euklides(); // создаем обьъект класса Euklides
            int actual = ea.GetGCD(a, b, out long time); // вызываем метод для рассчета алгоритма Евклида. Передаем наши переменный.
            // assert
            Assert.AreEqual(expected, actual); // производим сравнение ожидаемого результата с реальным результатом.
        }

        [TestMethod]
        public void GetGCD_48and36and78_6resulted()
        {
            // arrange
            int a = 48;
            int b = 36;
            int c = 78;
            int expected = 6;

            // action
            Euklides ea = new Euklides(); 
            int actual = ea.GetGCD(a, b, c);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetGCD_48and36and78and92_2resulted()
        {
            // arrange
            int a = 48;
            int b = 36;
            int c = 78;
            int d = 92;
            int expected = 2;

            // action
            Euklides ea = new Euklides();
            int actual = ea.GetGCD(a, b, c, d);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetGCD_34and36and38and40and42_2resulted()
        {
            // arrange
            int a = 34;
            int b = 36;
            int c = 38;
            int d = 40;
            int e = 42;
            int expected = 2;

            // action
            Euklides ea = new Euklides();
            int actual = ea.GetGCD(a, b, c, d, e);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
