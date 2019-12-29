using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task5;

namespace Task5.Tests
{
    /// <summary>
    /// Summary description for StudentTests
    /// </summary>
    [TestClass]
    public class StudentTests
    { 
        /// <summary>
        /// create student
        /// </summary>
        [TestMethod]
        public void CreateStudent()
        {
            // arrange
            Student student = new Student("Vasya", "IT", Convert.ToDateTime("12/30/2019 1:10:00 AM"), 82.5);
            // assert
            Assert.IsTrue(student.name == "Vasya" && student.TestName == "IT" && student.Mark == 82.5);
        }
        /// <summary>
        /// equals
        /// </summary>
        [TestMethod]
        public void EqualsTest()
        {
            // arrange
            Student student1 = new Student("Vasya", "IT", Convert.ToDateTime("12/30/2019 1:10:00 AM"), 82.5);
            Student student2 = new Student("Vasya", "IT", Convert.ToDateTime("12/30/2019 1:10:00 AM"), 82.5);
            // assert
            Assert.IsTrue(student1.Equals(student2));
        }
    }
}
