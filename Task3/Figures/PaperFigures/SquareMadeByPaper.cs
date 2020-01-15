using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Figures;

namespace Task3.Figures.Materials.Paper
{
    public class SquareMadeByPaper : Square, IPaper
    {
        private Colors color;
        private bool isPainted = false;
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="d">Input height</param>
        public SquareMadeByPaper(float d) : base(d)
        {
            color = Colors.white;
        }
        /// <summary>
        /// Constructor with color
        /// </summary>
        /// <param name="c">color</param>
        /// <param name="d">Input height</param>
        public SquareMadeByPaper(string c, float d) : base(d)
        {
            color = (Colors)int.Parse(c);
        }
        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="figure">Input figure</param>
        /// <param name="d">Height</param>
        public SquareMadeByPaper(IFigure figure, float d) : base(figure, d)
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
            if (obj is SquareMadeByPaper)
            {
                if (((SquareMadeByPaper)obj).Color == Color)
                {
                    if (this.A == ((SquareMadeByPaper)obj).A)
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
            int hash = (int)((Area - A) + (A + Perimeter));
            return hash;
        }
        /// <summary>
        /// Override Object.ToString()
        /// </summary>
        /// <returns>String value</returns>
        public override string ToString()
        {
            string txt = "Type of Figure: Square";
            txt += "\nMaterial of Figure: Paper";
            txt += "\nColor of Figure: " + Color.ToString();
            txt += "\nArea of Figure:" + Area;
            txt += "\nPerimeter of Figure:" + Perimeter;
            return txt;
        }
    }
}
