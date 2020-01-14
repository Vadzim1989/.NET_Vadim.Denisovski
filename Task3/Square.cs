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
}
