using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Shapes
{
    [Serializable]
    public class Circle : Figure    
    {
        /// <summary>
        /// Radius
        /// </summary>
        public double R;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="material"></param>
        /// <param name="coords"></param>
        public Circle(Material material, params double[] coords):base(material,coords)
        {
            R = coords[0];
        }
        /// <summary>
        /// Get Perimetr of circle
        /// </summary>
        /// <returns></returns>
        public override double GetPerimeter() => 2 * Math.PI * R;
        /// <summary>
        /// Get Square of circle
        /// </summary>
        /// <returns></returns>
        public override double GetSquare() => Math.PI * Math.Pow(R, 2);
        /// <summary>
        /// Check our figure
        /// </summary>
        /// <param name="figure"></param>
        public Circle(Figure figure)
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
            var circle = obj as Circle;
            return circle != null &&
                   base.Equals(obj) &&
                   R == circle.R;
        }
        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="figure"></param>
        /// <returns></returns>
        public bool Equals(Circle figure)
        {
            if (figure == null)
                return false;
            return figure.R == this.R;
        }
        /// <summary>
        /// HashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            var hashCode = -63051957;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + R.GetHashCode();
            return hashCode;
        }
        public override string ToString()
        {
            return "Circle radius: " + R + "; perimeter " + GetPerimeter() + "; square: " + GetSquare();
        }
    }
}
