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
}
