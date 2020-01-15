using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Figures;

namespace Task3.Figures.Materials.Paper
{
    public class TriangleMadeByPaper : Triangle, IPaper
    {
        private Colors color;
        private bool isPainted = false;
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="a">Side a</param>
        /// <param name="b">Side b</param>
        /// <param name="c">Side c</param>
        public TriangleMadeByPaper(float a, float b, float c) : base(a, b, c)
        {
            color = Colors.white;
        }
        /// <summary>
        /// Constructor with color
        /// </summary>
        /// <param name="col">Color</param>
        /// <param name="a">Side a</param>
        /// <param name="b">Side b</param>
        /// <param name="c">Side c</param>
        public TriangleMadeByPaper(string col, float a, float b, float c) : base(a, b, c)
        {
            color = (Colors)int.Parse(col);
        }
        /// <summary>
        /// Copy constructor for cutting
        /// </summary>
        /// <param name="figure">Input figure</param>
        /// <param name="a">Side a</param>
        /// <param name="b">Side b</param>
        /// <param name="c">Side c</param>
        public TriangleMadeByPaper(IFigure figure, float a, float b, float c) : base(figure, a, b, c)
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
            if (obj is TriangleMadeByPaper)
            {
                if (A == ((TriangleMadeByPaper)obj).A && B == ((TriangleMadeByPaper)obj).B && C == ((TriangleMadeByPaper)obj).C)
                {
                    return true;
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
            int hash = (int)((Area - A) + (B + Perimeter)) + (int)C;
            return hash;
        }
        /// <summary>
        /// Override Object.ToString()
        /// </summary>
        /// <returns>String value</returns>
        public override string ToString()
        {
            string txt = "Type of Figure: Triangle";
            txt += "\nMaterial of Figure: Paper";
            txt += "\nColor of Figure: " + Color.ToString();
            txt += "\nArea of Figure:" + Area;
            txt += "\nPerimeter of Figure:" + Perimeter;
            return txt;
        }
    }
}
