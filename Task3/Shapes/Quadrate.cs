using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Shapes
{
    [Serializable]
    public class Quadrate : Figure
    {
        /// <summary>
        /// Side
        /// </summary>
        private double size;
        /// <summary>
        /// Costructor
        /// </summary>
        /// <param name="material"></param>
        /// <param name="coords"></param>
        public Quadrate(Material material, params double[] coords):base(material,coords)
        {
            size = coords[0];
        }
        /// <summary>
        /// Get Perimeter of quadrate
        /// </summary>
        /// <returns></returns>
        public override double GetPerimeter() => 4 * size;
        /// <summary>
        /// Get Square of quadrate
        /// </summary>
        /// <returns></returns>
        public override double GetSquare() => Math.Pow(size, 2);        
        /// <summary>
        /// Check our figure
        /// </summary>
        /// <param name="figure"></param>
        public Quadrate(Figure figure)
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
            var quadrate = obj as Quadrate;
            return quadrate != null &&
                   base.Equals(obj) &&
                   size == quadrate.size;
        }
        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="quadrate"></param>
        /// <returns></returns>
        public bool Equals(Quadrate quadrate)
        {
            if (quadrate == null)
                return false;
            return quadrate.size == this.size;
        }
        /// <summary>
        /// HashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            var hashCode = 1221766130;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + size.GetHashCode();
            return hashCode;
        }
        public override string ToString() => "Quadrate side: " + size + "; perimeter: " + GetPerimeter() + "; square: " + GetSquare();
    }
}
