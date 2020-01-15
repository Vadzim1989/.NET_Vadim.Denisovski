using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Figures
{
    /// <summary>
    /// Abstract class for all Square
    /// </summary>
    public abstract class Square : IFigure
    {
        /// <summary>
        /// Height of Square
        /// </summary>
        private float a;
        /// <summary>
        /// Constructor for Square
        /// </summary>
        /// <param name="a">Height</param>
        public Square(float a)
        {
            A = a;
        }
        /// <summary>
        /// Constructor for cutting new square from square
        /// </summary>
        /// <param name="figure">Figure for cut</param>
        /// <param name="a">Height</param>
        public Square(IFigure figure, float a)
        {
            if (a <= 0)
            {
                throw new Exception("Invalid input parameter");
            }
            if (!(figure is Square))
            {
                throw new Exception("Invalid Figure for cut");
            }
            this.A = a;
            if (figure.Area <= this.Area)
            {
                throw new Exception("Figure fot cut less than new");
            }
        }
        /// <summary>
        /// Calculates Area of square
        /// </summary>
        public float Area { get => A * A; }
        /// <summary>
        /// Calculates Parimeter of square
        /// </summary>
        public float Perimeter { get => 4 * A; }
        /// <summary>
        /// Property for a
        /// </summary>
        public float A { get => a; set => a = value; }
        /// <summary>
        /// Override Object.Equals()
        /// </summary>
        /// <param name="obj">Input Object for compare</param>
        /// <returns>True or False</returns>
        public abstract override bool Equals(Object obj);
        /// <summary>
        /// Override Object.GetHashCode()
        /// </summary>
        /// <returns>Int-hashcode</returns>
        public abstract override int GetHashCode();
        /// <summary>
        /// Override Object.ToString()
        /// </summary>
        /// <returns>String value</returns>
        public abstract override string ToString();
    }
}
