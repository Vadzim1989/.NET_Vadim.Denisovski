using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    /// <summary>
    /// Class for operations with rectangle
    /// </summary>
    public class Rectangle : Figure
    {
        float width, height;
        /// <summary>
        /// Constructor for Rectangle. Uses base class constructor.
        /// </summary>
        /// <param name="m">Material</param>
        /// <param name="c">Color</param>
        /// <param name="h">Height</param>
        /// <param name="w">Width</param>
        public Rectangle(string m, string c, float h, float w) : base(m, c)
        {
            Width = w;
            Height = h;
        }
        /// <summary>
        /// Area of Rectangle
        /// </summary>
        public override float Area { get => Width * Height; }
        /// <summary>
        /// Perimeter of Rectangle
        /// </summary>
        public override float Perimeter { get => 2 * (Width + Height); }
        /// <summary>
        /// Property of width
        /// </summary>
        public float Width { get => width; set => width = value; }
        /// <summary>
        /// Property of height
        /// </summary>
        public float Height { get => height; set => height = value; }

        /// <summary>
        /// Compares this rectangle with another object
        /// </summary>
        /// <param name="obj">Input object</param>
        /// <returns>true or false</returns>
        public override bool Equals(object obj)
        {
            if (obj is Rectangle)
            {
                if ((this.Height == ((Rectangle)obj).Height) && (this.Width == ((Rectangle)obj).Width))
                {
                    if ((this.Color == ((Rectangle)obj).Color))
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }
        /// <summary>
        /// Override GetHashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hash = (int)((Area - Width) + (Height + Perimeter)) + (int)Color;
            return hash;
        }
        /// <summary>
        /// Create xml for figure
        /// </summary>
        /// <returns>String for xml</returns>
        public override string GetXML()
        {
            string xml = "";
            xml += "\t<figure type=\"Rectangle\">\n";
            xml += "\t\t<material>" + Material + "</material>\n";
            xml += "\t\t<color>" + Color + "</color>\n";
            xml += "\t\t<height>" + Height + "</height>\n";
            xml += "\t\t<width>" + Height + "</width>\n";
            xml += "\t</figure>\n";
            return xml;
        }
    }
    /// <summary>
    /// Class for operations with Square
    /// </summary>
    public class Square : Figure
    {
        /// <summary>
        /// Height of Square
        /// </summary>
        private float a;
        /// <summary>
        /// Constructor for Square. Uses base class constructor.
        /// </summary>
        /// <param name="m">Material</param>
        /// <param name="c">Color</param>
        /// <param name="a">Height</param>
        public Square(string m, string c, float a) : base(m, c)
        {
            this.A = a;
        }
        /// <summary>
        /// Calculates Area of square
        /// </summary>
        public override float Area { get => A * A; }
        /// <summary>
        /// Calculates Parimeter of square
        /// </summary>
        public override float Perimeter { get => 4 * A; }
        /// <summary>
        /// Property for a
        /// </summary>
        public float A { get => a; set => a = value; }

        /// <summary>
        /// Compares this square with another object
        /// </summary>
        /// <param name="obj">Input object</param>
        /// <returns>True or False</returns>
        public override bool Equals(object obj)
        {
            if (obj is Square)
            {
                if ((this.A == ((Square)obj).A))
                {
                    if ((this.Color == ((Square)obj).Color))
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }
        /// <summary>
        /// Override GetHashCode()
        /// </summary>
        /// <returns>Int value for hashcode</returns>
        public override int GetHashCode()
        {
            int hash = (int)((Area - A) + (A + Perimeter)) + (int)Color;
            return hash;
        }
        /// <summary>
        /// Create xml for figure
        /// </summary>
        /// <returns>String for xml</returns>
        public override string GetXML()
        {
            string xml = "";
            xml += "\t<figure type=\"Square\">\n";
            xml += "\t\t<material>" + Material + "</material>\n";
            xml += "\t\t<color>" + Color + "</color>\n";
            xml += "\t\t<height>" + A + "</height>\n";
            xml += "\t</figure>\n";
            return xml;
        }
    }
    /// <summary>
    /// Class for operations with triangle
    /// </summary>
    public class Triangle : Figure
    {
        /// <summary>
        /// Sides of triangle
        /// </summary>
        float a, b, d;
        /// <summary>
        /// Constructor for Triangle. Uses base class constructor.
        /// </summary>
        /// <param name="m">Material</param>
        /// <param name="c">Color</param>
        /// <param name="a">First side</param>
        /// <param name="b">Second side</param>
        /// <param name="d">Third side</param>
        public Triangle(string m, string c, float a, float b, float d) : base(m, c)
        {
            this.A = a;
            this.B = b;
            this.D = d;
        }
        /// <summary>
        /// Calculates Area of triangle
        /// </summary>
        public override float Area
        {
            get
            {
                float halfperimeter = Perimeter / 2;
                return (float)Math.Sqrt(halfperimeter * (halfperimeter - A) * (halfperimeter - B) * (halfperimeter - D));
            }
        }
        /// <summary>
        /// Calculates Perimeter of triangle
        /// </summary>
        public override float Perimeter { get => A + B + D; }
        /// <summary>
        /// Property for a
        /// </summary>
        public float A { get => a; set => a = value; }
        /// <summary>
        /// Property for b
        /// </summary>
        public float B { get => b; set => b = value; }
        /// <summary>
        /// Property for d
        /// </summary>
        public float D { get => d; set => d = value; }

        /// <summary>
        /// Compares Triangle with another object
        /// </summary>
        /// <param name="obj">Input object</param>
        /// <returns>True or False</returns>
        public override bool Equals(object obj)
        {
            if (obj is Triangle)
            {
                if ((this.A == ((Triangle)obj).A) && (this.B == ((Triangle)obj).B) && (this.D == ((Triangle)obj).D))
                {
                    if ((this.Color == ((Triangle)obj).Color))
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }
        /// <summary>
        /// Override GetHashCode()
        /// </summary>
        /// <returns>Int value for hash code</returns>
        public override int GetHashCode()
        {
            int hash = (int)((Area - A) + (B + Perimeter)) + (int)Color + (int)D;
            return hash;
        }
        /// <summary>
        /// Create xml for figure
        /// </summary>
        /// <returns>String for xml</returns>
        public override string GetXML()
        {
            string xml = "";
            xml += "\t<figure type=\"Triangle\">\n";
            xml += "\t\t<material>" + Material + "</material>\n";
            xml += "\t\t<color>" + Color + "</color>\n";
            xml += "\t\t<side_a>" + A + "</side_a>\n";
            xml += "\t\t<side_b>" + B + "</side_b>\n";
            xml += "\t\t<side_d>" + D + "</side_d>\n";
            xml += "\t</figure>\n";
            return xml;
        }
    }
    /// <summary>
    /// Class for operations with Circle
    /// </summary>
    public class Circle : Figure
    {
        /// <summary>
        /// Diameter of circle
        /// </summary>
        float diameter;
        /// <summary>
        /// Constructor for Circle. Uses base class constructor.
        /// </summary>
        /// <param name="m">Material</param>
        /// <param name="c">Color</param>
        /// <param name="d">Diameter</param>
        public Circle(string m, string c, float d) : base(m, c)
        {
            Diameter = d;
        }
        /// <summary>
        /// Calculates are of circle
        /// </summary>
        public override float Area
        {
            get
            {
                double i = Diameter * Diameter;
                i = i * Math.PI;
                i /= 4;
                return (float)i;
            }
        }
        /// <summary>
        /// Calculates Perimeter of circle
        /// </summary>
        public override float Perimeter { get => (float)(Math.PI * Diameter); }
        /// <summary>
        /// Property of Diameter
        /// </summary>
        public float Diameter { get => diameter; set => diameter = value; }

        /// <summary>
        /// Compares Triangle with another object
        /// </summary>
        /// <param name="obj">Input object</param>
        /// <returns>true or false</returns>
        public override bool Equals(object obj)
        {
            if (obj is Circle)
            {
                if ((this.Diameter == ((Circle)obj).Diameter))
                {
                    if ((this.Color == ((Circle)obj).Color))
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }
        /// <summary>
        /// Override GetHashCode()
        /// </summary>
        /// <returns>Int value for hashcode</returns>
        public override int GetHashCode()
        {
            int hash = (int)((Area - Diameter) + (Diameter + Perimeter)) + (int)Color;
            return hash;
        }
        /// <summary>
        /// Get XML form of object with params
        /// </summary>
        /// <returns>Formated String</returns>
        public override string GetXML()
        {
            string xml = "";
            xml += "\t<figure type=\"Circle\">\n";
            xml += "\t\t<material>" + Material + "</material>\n";
            xml += "\t\t<color>" + Color + "</color>\n";
            xml += "\t\t<diameter>" + Diameter + "</diameter>\n";
            xml += "\t</figure>\n";
            return xml;
        }
    }
}
