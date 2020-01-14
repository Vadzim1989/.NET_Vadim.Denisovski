using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Task3
{
    [Serializable]
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
}
