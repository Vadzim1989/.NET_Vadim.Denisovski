using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace Task5.Tests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void CompareToTest()
        {
            var s1 = new Student("Denisovski", 27, "DataStructure", new DateTime(2015, 7, 20));
            var s2 = new Student("Petrov", 10, "DataStructure", new DateTime(2016, 3, 25));
            var s3 = new Student("Vasyachkin", 58, "DataStructure", new DateTime(2018, 1, 12));
            var s4 = new Student("Pushkin", 53, "DataStructure", new DateTime(2017, 2, 10));
            var s5 = new Student("Lermontov", 88, "DataStructure", new DateTime(2019, 2, 11));
            var s6 = new Student("Lenin", 75, "DataStructure", new DateTime(2015, 2, 11));
            var s7 = new Student("Lukashenko", 99, "DataStructure", new DateTime(2015, 2, 11));
            var result = s1.CompareTo(s2);
            var expected = 1;
            var b1 = new BinaryTree<Student>();
            b1.Add(s1);
            b1.Add(s2);
            b1.Add(s3);
            b1.Add(s5);
            b1.Add(s6);
            b1.Add(s7);
            b1.Balance();
            b1.Add(s4);
            Assert.AreEqual(expected, result);
            XmlSerializer Serializer = new XmlSerializer(typeof(BinaryTree<Student>));            

            using (var stringwriter = new System.IO.StringWriter())
            {
                using (System.Xml.XmlWriter xmlwriter = System.Xml.XmlWriter.Create(stringwriter))
                {
                    Serializer.Serialize(xmlwriter, b1);
                    var xml = stringwriter.ToString();
                    XmlDocument xDoc = new XmlDocument();
                    xDoc.LoadXml(xml);
                    xDoc.Save("output.xml");
                }
            }
        }
    }
}
