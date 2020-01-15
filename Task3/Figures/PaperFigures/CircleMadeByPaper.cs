using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Figures;

namespace Task3.Figures.Materials.Paper
{
    public class CircleMadeByPaper : Circle, IPaper
    {
        private Colors color;
        private bool isPainted = false;
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="d">Input diameter</param>
        public CircleMadeByPaper(float d) : base(d)
        {
            color = Colors.white;
        }
        /// <summary>
        /// Constructor with color
        /// </summary>
        /// <param name="c">Input color</param>
        /// <param name="d">Input diameter</param>
        public CircleMadeByPaper(string c, float d) : base(d)
        {
            color = (Colors)int.Parse(c);
        }
        /// <summary>
        /// Copy constructor for cutting
        /// </summary>
        /// <param name="figure">Input figure</param>
        /// <param name="d">Input diameter</param>
        public CircleMadeByPaper(IFigure figure, float d) : base(figure, d)
        {
            if (!(figure is IPaper))
            {
                throw new Exception("Invalid Figure's material for cut");
            }
            else
            {
                IPaper cp1 = (IPaper)figure;
                Color = cp1.Color;
                IsPainted = cp1.IsPainted;
            }
        }
        /// <summary>
        /// Property for change private color
        /// </summary>
        public Colors Color
        {
            get => color;
            set
            {
                if (value != color)
                {
                    if (!IsPainted)
                    {
                        color = value;
                        IsPainted = true;
                    }
                    else
                    {
                        throw new Exception("Figure Is Already Painted");
                    }
                }
                else throw new Exception("Figure already " + color.ToString() + ". Select another color");
            }
        }
        /// <summary>
        /// Checks only once painting a figure
        /// </summary>
        public bool IsPainted { get => isPainted; set => isPainted = value; }
        /// <summary>
        /// Override Object.Equals()
        /// </summary>
        /// <param name="obj">Input object</param>
        /// <returns>True or false</returns>
        public override bool Equals(object obj)
        {
            if (obj is CircleMadeByPaper)
            {
                if (((CircleMadeByPaper)obj).Color == Color)
                {
                    if (Diameter == ((CircleMadeByPaper)obj).Diameter)
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
        /// Override Object.GetHashCode()
        /// </summary>
        /// <returns>Int value</returns>
        public override int GetHashCode()
        {
            int hash = (int)((Area - Diameter) + (Diameter + Perimeter));
            return hash;
        }
        /// <summary>
        /// Override Object.ToString()
        /// </summary>
        /// <returns>String value</returns>
        public override string ToString()
        {
            string txt = "Type of Figure: Circle";
            txt += "\nMaterial of Figure: Paper";
            txt += "\nColor of Figure: " + Color.ToString();
            txt += "\nArea of Figure:" + Area;
            txt += "\nPerimeter of Figure:" + Perimeter;
            return txt;
        }
    }
}
