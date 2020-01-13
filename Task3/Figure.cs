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
    /// Abstract class for all figures
    /// </summary>
    public abstract class Figure : IFigure
    {
        /// <summary>
        /// Index of color in enumeration Colors
        /// </summary>
        private int color;
        private bool isPainted = false;
        /// <summary>
        /// Enumeration of colors
        /// </summary>
        public enum Colors
        {
            /// <summary>
            /// Transparent = 0
            /// </summary>
            transparent,
            /// <summary>
            /// Red = 1
            /// </summary>
            red,
            /// <summary>
            /// Blue = 2
            /// </summary>
            blue,
            /// <summary>
            /// White = 3
            /// </summary>
            white,
            /// <summary>
            /// Green = 4
            /// </summary>
            green,
            /// <summary>
            /// Black = 5
            /// </summary>
            black,
            /// <summary>
            /// Yellow = 6
            /// </summary>
            yellow,
            /// <summary>
            /// Purple = 7
            /// </summary>
            purple,
            /// <summary>
            /// Pink = 8
            /// </summary>
            pink
        }
        /// <summary>
        /// Default constructor for all classes
        /// </summary>
        public Figure(string m, string c)
        {
            if (m == "film")
            {
                color = (int)Colors.transparent;
            }
            else if ((m == "paper") && (c != "transparent"))
            {
                Color = (Colors)Enum.Parse(typeof(Colors), c);
            }
            else
            {
                throw new Exception("Wrong color or material input");
            }
        }
        /// <summary>
        /// Constructor for create figure from another
        /// </summary>
        /// <param name="m">material</param>
        /// <param name="c">color</param>
        /// <param name="f1">Figure another</param>
        public Figure(string m, string c, Figure f1) : this(m, c)
        {
            if (f1.Area < this.Area)
            {
                throw new Exception("You cannot create bigger figure from less");
            }
        }
        /// <summary>
        /// Area of Figure
        /// </summary>
        public abstract float Area { get; }
        /// <summary>
        /// Perimeter of Figure
        /// </summary>
        public abstract float Perimeter { get; }
        /// <summary>
        /// 
        /// </summary>
        public Colors Color
        {
            get => (Colors)color;
            set
            {
                if ((int)value != 0)
                {
                    if (!isPainted)
                    {
                        color = (int)value;
                    }
                    else
                    {
                        throw new Exception("Figure Is Already Painted");
                    }
                }
                else throw new Exception("Transparent is not color");
            }
        }
        /// <summary>
        /// Type of material. Returns paper or film. 
        /// </summary>
        public string Material
        {
            get
            {
                if (Color != 0)
                {
                    return "paper";
                }
                else return "film";
            }
        }
        /// <summary>
        /// Override default method ToString()
        /// </summary>
        /// <returns>String of params Figure</returns>
        public override string ToString()
        {
            string txt = "Type of Figure:" + GetType().Name;
            txt += "\nColor of Figure:" + Color;
            txt += "\nMaterial of Figure:" + Material;
            txt += "\nArea of Figure:" + Area;
            txt += "\nPerimeter of Figure:" + Perimeter;
            return txt;
        }
        /// <summary>
        /// Method for comparison figures
        /// </summary>
        /// <returns>Returns true if Equal</returns>
        public abstract override bool Equals(object obj);
        /// <summary>
        /// Override GetHashCode()
        /// </summary>
        /// <returns>Int value for hashcode</returns>
        public abstract override int GetHashCode();
        /// <summary>
        /// Get XML form of object with params
        /// </summary>
        /// <returns>Formated String</returns>
        public abstract string GetXML();
    }
}
