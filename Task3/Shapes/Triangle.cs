using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Shapes
{
    [Serializable]
    public class Triangle : Figure
    {
        /// <summary>
        /// Side of triangle
        /// </summary>
        private double A, B, C;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="material"></param>
        /// <param name="coords"></param>
        public Triangle(Material material, params double[] coords):base(material,coords)
        {
            A = coords[0];
            B = coords[1];
            C = coords[2];
        }
        /// <summary>
        /// get perimeter
        /// </summary>
        /// <returns></returns>
        public override double GetPerimeter() => A + B + C;
        /// <summary>
        /// Heron's formula
        /// </summary>
        /// <returns>
        /// Get Square of triangle
        /// </returns>
        public override double GetSquare()
        {
            if (A == B) return (C * (Math.Sqrt(Math.Pow(A, 2) - ((Math.Pow(C, 2)) / 4)))) / 2;
            if (A == C) return (B * (Math.Sqrt(Math.Pow(A, 2) - ((Math.Pow(B, 2)) / 4)))) / 2;
            if (B == C) return (A * (Math.Sqrt(Math.Pow(B, 2) - ((Math.Pow(A, 2)) / 4)))) / 2;
            if (A == B && A == C && C == B) return (Math.Sqrt(3) / 4) * Math.Pow(A, 2);
            else
            {
                return Math.Sqrt(GetPerimeter() / 2 * ((GetPerimeter() / 2) - A) * ((GetPerimeter() / 2) - B) * ((GetPerimeter() / 2) - C));
            }
        }
        /// <summary>
        /// Check our figure
        /// </summary>
        /// <param name="figure"></param>
        public Triangle(Figure figure)
        {
            if (figure.GetSquare() > GetSquare())
                throw new Exception("You can't cut this shape");
        }
        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var triangle = obj as Triangle;
            return triangle != null &&
                   base.Equals(obj) &&
                   A == triangle.A &&
                   B == triangle.B &&
                   C == triangle.C;
        }
        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="triangle"></param>
        /// <returns></returns>
        public bool Equals(Triangle triangle)
        {
            if (triangle == null)
                return false;
            return triangle.A == this.A && triangle.B == this.B && triangle.C == this.C;
        }
        /// <summary>
        /// HashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            var hashCode = 1180105665;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + A.GetHashCode();
            hashCode = hashCode * -1521134295 + B.GetHashCode();
            hashCode = hashCode * -1521134295 + C.GetHashCode();
            return hashCode;
        }
        public override string ToString()
        {
            return "Triangle perimeter: " + GetPerimeter() + "; square: " + GetSquare();
        }
    }
}
