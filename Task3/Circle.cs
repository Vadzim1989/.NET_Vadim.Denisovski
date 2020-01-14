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
