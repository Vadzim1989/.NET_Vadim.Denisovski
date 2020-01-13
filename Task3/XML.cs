using System.IO;
using System.Collections.Generic;
using System.Xml;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3;
using System.Runtime.Serialization;

namespace Task3
{
    [Serializable]
    /// <summary>
    /// StreamReader and StreamWriter
    /// </summary>
    public class Stream
    {
        /// <summary>
        /// StreamWriter
        /// </summary>
        /// <param name="i">Input string</param>
        public void Write(string i)
        {
            StreamWriter sw = new StreamWriter("output.xml", false, System.Text.Encoding.Default);
            string xml = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\n<Box>\n";
            sw.Write(xml + i + "\n</Box>");
            sw.Close();
        }
        /// <summary>
        /// StreamReader
        /// </summary>
        /// <returns>List of figures from XML</returns>
        public List<Figure> Read()
        {
            List<Figure> boxxml = new List<Figure>();
            StreamReader sr = new StreamReader("input.xml");
            string doc = sr.ReadToEnd();
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(doc);
            XmlElement xRoot = xdoc.DocumentElement;
            foreach (XmlNode xnode in xRoot)
            {
                XmlNode typefigure = xnode.Attributes.GetNamedItem("type");
                switch (typefigure.Value)
                {
                    case "Circle":
                        {
                            string material = "", color = "";
                            int diameter = 1;
                            foreach (XmlNode childnode in xnode.ChildNodes)
                            {
                                if (childnode.Name == "material")
                                {
                                    material = $"{childnode.InnerText}";
                                }
                                if (childnode.Name == "color")
                                {
                                    color = $"{childnode.InnerText}";
                                }
                                if (childnode.Name == "diameter")
                                {
                                    diameter = int.Parse(childnode.InnerText);
                                }
                            }
                            Circle c1 = new Circle(material, color, diameter);
                            boxxml.Add(c1);
                            break;
                        }
                    case "Rectangle":
                        {
                            string material = "", color = "";
                            int height = 1;
                            int width = 1;
                            foreach (XmlNode childnode in xnode.ChildNodes)
                            {
                                if (childnode.Name == "material")
                                {
                                    material = $"{childnode.InnerText}";
                                }
                                if (childnode.Name == "color")
                                {
                                    color = $"{childnode.InnerText}";
                                }
                                if (childnode.Name == "height")
                                {
                                    height = int.Parse(childnode.InnerText);
                                }
                                if (childnode.Name == "width")
                                {
                                    width = int.Parse(childnode.InnerText);
                                }
                            }
                            Rectangle c1 = new Rectangle(material, color, height, width);
                            boxxml.Add(c1);
                            break;
                        }
                    case "Square":
                        {
                            string material = "", color = "";
                            int height = 1;
                            foreach (XmlNode childnode in xnode.ChildNodes)
                            {
                                if (childnode.Name == "material")
                                {
                                    material = $"{childnode.InnerText}";
                                }
                                if (childnode.Name == "color")
                                {
                                    color = $"{childnode.InnerText}";
                                }
                                if (childnode.Name == "height")
                                {
                                    height = int.Parse(childnode.InnerText);
                                }
                            }
                            Square c1 = new Square(material, color, height);
                            boxxml.Add(c1);
                            break;
                        }
                    case "Triangle":
                        {
                            string material = "", color = "";
                            int a = 1;
                            int b = 1;
                            int d = 1;
                            foreach (XmlNode childnode in xnode.ChildNodes)
                            {
                                if (childnode.Name == "material")
                                {
                                    material = $"{childnode.InnerText}";
                                }
                                if (childnode.Name == "color")
                                {
                                    color = $"{childnode.InnerText}";
                                }
                                if (childnode.Name == "side_a")
                                {
                                    a = int.Parse(childnode.InnerText);
                                }
                                if (childnode.Name == "side_b")
                                {
                                    b = int.Parse(childnode.InnerText);
                                }
                                if (childnode.Name == "side_d")
                                {
                                    d = int.Parse(childnode.InnerText);
                                }
                            }
                            Triangle c1 = new Triangle(material, color, a, b, d);
                            boxxml.Add(c1);
                            break;
                        }
                }
            }
            sr.Close();
            return boxxml;
        }
    }
    /// <summary>
    /// XmlWriter and XMLReader
    /// </summary>
    public class XML
    {
        /// <summary>
        /// Method Write
        /// </summary>
        /// <param name="intoBox">Input List</param>
        public void Write(List<Figure> intoBox)
        {
            XmlWriter xmlWriter = XmlWriter.Create("test.xml");
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Boxs");
            foreach (var i in intoBox)
            {
                switch (i.GetType().Name)
                {
                    case "Circle":
                        {
                            Circle c1 = (Circle)i;
                            xmlWriter.WriteStartElement("figure");
                            xmlWriter.WriteAttributeString("type", "Circle");
                            xmlWriter.WriteStartElement("material");
                            xmlWriter.WriteString(c1.Material);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteStartElement("color");
                            xmlWriter.WriteString("" + c1.Color);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteStartElement("diameter");
                            xmlWriter.WriteString("" + c1.Diameter);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteEndElement();
                            break;
                        }
                    case "Rectangle":
                        {
                            Rectangle r1 = (Rectangle)i;
                            xmlWriter.WriteStartElement("figure");
                            xmlWriter.WriteAttributeString("type", "Rectangle");
                            xmlWriter.WriteStartElement("material");
                            xmlWriter.WriteString(r1.Material);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteStartElement("color");
                            xmlWriter.WriteString("" + r1.Color);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteStartElement("height");
                            xmlWriter.WriteString("" + r1.Height);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteStartElement("width");
                            xmlWriter.WriteString("" + r1.Width);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteEndElement();
                            break;
                        }
                    case "Square":
                        {
                            Square s1 = (Square)i;
                            xmlWriter.WriteStartElement("figure");
                            xmlWriter.WriteAttributeString("type", "Square");
                            xmlWriter.WriteStartElement("material");
                            xmlWriter.WriteString(s1.Material);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteStartElement("color");
                            xmlWriter.WriteString("" + s1.Color);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteStartElement("height");
                            xmlWriter.WriteString("" + s1.A);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteEndElement();
                            break;
                        }
                    case "Triangle":
                        {
                            Triangle t1 = (Triangle)i;
                            xmlWriter.WriteStartElement("figure");
                            xmlWriter.WriteAttributeString("type", "Triangle");
                            xmlWriter.WriteStartElement("material");
                            xmlWriter.WriteString(t1.Material);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteStartElement("color");
                            xmlWriter.WriteString("" + t1.Color);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteStartElement("side_a");
                            xmlWriter.WriteString("" + t1.A);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteStartElement("side_b");
                            xmlWriter.WriteString("" + t1.B);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteStartElement("side_d");
                            xmlWriter.WriteString("" + t1.D);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteEndElement();
                            break;
                        }
                }
            }
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
        }
        /// <summary>
        /// Method Read
        /// </summary>
        /// <returns>New List</returns>
        public List<Figure> Read()
        {
            List<Figure> boxxml = new List<Figure>();
            XmlReader xreader = XmlReader.Create("input.xml");
            string m;
            string c;
            while (xreader.Read())
            {

                if (xreader.Name == "figure")
                {
                    switch (xreader.GetAttribute("type"))
                    {
                        case "Circle":
                            {
                                int d;
                                xreader.Read();
                                xreader.Read();
                                if (xreader.Name == "material")
                                {
                                    m = xreader.ReadInnerXml();
                                    xreader.Read();
                                }
                                else throw new Exception("Wrong input xml");
                                if (xreader.Name == "color")
                                {
                                    c = xreader.ReadInnerXml();
                                    xreader.Read();
                                }
                                else throw new Exception("Wrong input xml");
                                if (xreader.Name == "diameter")
                                {
                                    d = Int32.Parse(xreader.ReadInnerXml());
                                }
                                else throw new Exception("Wrong input xml");
                                boxxml.Add(new Circle(m, c, d));
                                break;
                            }
                        case "Square":
                            {
                                int a;
                                xreader.Read();
                                xreader.Read();
                                if (xreader.Name == "material")
                                {
                                    m = xreader.ReadInnerXml();
                                    xreader.Read();
                                }
                                else throw new Exception("Wrong input xml");
                                if (xreader.Name == "color")
                                {
                                    c = xreader.ReadInnerXml();
                                    xreader.Read();
                                }
                                else throw new Exception("Wrong input xml");
                                if (xreader.Name == "height")
                                {
                                    a = Int32.Parse(xreader.ReadInnerXml());
                                }
                                else throw new Exception("Wrong input xml");
                                boxxml.Add(new Square(m, c, a));
                                break;
                            }
                        case "Rectangle":
                            {
                                int h, w;
                                xreader.Read();
                                xreader.Read();
                                if (xreader.Name == "material")
                                {
                                    m = xreader.ReadInnerXml();
                                    xreader.Read();
                                }
                                else throw new Exception("Wrong input xml");
                                if (xreader.Name == "color")
                                {
                                    c = xreader.ReadInnerXml();
                                    xreader.Read();
                                }
                                else throw new Exception("Wrong input xml");
                                if (xreader.Name == "height")
                                {
                                    h = Int32.Parse(xreader.ReadInnerXml());
                                    xreader.Read();
                                }
                                else throw new Exception("Wrong input xml");
                                if (xreader.Name == "width")
                                {
                                    w = Int32.Parse(xreader.ReadInnerXml());
                                }
                                else throw new Exception("Wrong input xml");
                                boxxml.Add(new Rectangle(m, c, h, w));
                                break;
                            }
                        case "Triangle":
                            {
                                int a, b, d;
                                xreader.Read();
                                xreader.Read();
                                if (xreader.Name == "material")
                                {
                                    m = xreader.ReadInnerXml();
                                    xreader.Read();
                                }
                                else throw new Exception("Wrong input xml");
                                if (xreader.Name == "color")
                                {
                                    c = xreader.ReadInnerXml();
                                    xreader.Read();
                                }
                                else throw new Exception("Wrong input xml");
                                if (xreader.Name == "a")
                                {
                                    a = Int32.Parse(xreader.ReadInnerXml());
                                    xreader.Read();
                                }
                                else throw new Exception("Wrong input xml");
                                if (xreader.Name == "b")
                                {
                                    b = Int32.Parse(xreader.ReadInnerXml());
                                    xreader.Read();
                                }
                                else throw new Exception("Wrong input xml");
                                if (xreader.Name == "d")
                                {
                                    d = Int32.Parse(xreader.ReadInnerXml());
                                }
                                else throw new Exception("Wrong input xml");
                                boxxml.Add(new Triangle(m, c, a, b, d));
                                break;
                            }
                    }
                }
            }
            xreader.Close();
            return boxxml;
        }
    }
}
