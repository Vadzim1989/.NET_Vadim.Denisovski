using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Figures
{
    /// <summary>
    /// Abstract class for all Triangle
    /// </summary>
    public abstract class Triangle : IFigure
    {
        /// <summary>
        /// Sides of triangle
        /// </summary>
        float a, b, c;
        /// <summary>
        /// Constructor for Triangle
        /// </summary>
        /// <param name="a">First side</param>
        /// <param name="b">Second side</param>
        /// <param name="c">Third side</param>
        public Triangle(float a, float b, float c)
        {
            A = a;
            B = b;
            C = c;
        }
        /// <summary>
        /// Constructor for cutting new triangle from triangle
        /// </summary>
        /// <param name="figure">Triangle for cut</param>
        /// <param name="a">First side</param>
        /// <param name="b">Second side</param>
        /// <param name="c">Third side</param>
        public Triangle(IFigure figure, float a, float b, float c)
        {
            if (!((a > 0) && (b > 0) && (c > 0) && (a + b > c) && (a + c > b) && (b + c > a)))
            {
                throw new Exception("Invalid input parameter");
            }
            if (!(figure is Triangle))
            {
                throw new Exception("Invalid Figure for cut");
            }
            this.A = a;
            this.B = b;
            this.C = c;
            if (figure.Area <= this.Area)
            {
                throw new Exception("Figure fot cut less than new");
            }
        }
        /// <summary>
        /// Calculates Area of triangle
        /// </summary>
        public float Area
        {
            get
            {
                float halfperimeter = Perimeter / 2;
                return (float)Math.Sqrt(halfperimeter * (halfperimeter - A) * (halfperimeter - B) * (halfperimeter - C));
            }
        }
        /// <summary>
        /// Calculates Perimeter of triangle
        /// </summary>
        public float Perimeter { get => A + B + C; }
        /// <summary>
        /// Property for a
        /// </summary>
        public float A { get => a; set => a = value; }
        /// <summary>
        /// Property for b
        /// </summary>
        public float B { get => b; set => b = value; }
        /// <summary>
        /// Property for c
        /// </summary>
        public float C { get => c; set => c = value; }
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
