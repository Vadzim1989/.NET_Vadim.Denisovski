using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Shapes
{
    [Serializable]
    public abstract class Figure : IFigureMaterial
    {
        private int[] coords;
        public bool IsPainted = false;
        /// <summary>
        /// get/set Materials
        /// </summary>
        public Material Material { get; set; }
        /// <summary>
        /// get/set Colors
        /// </summary>
        public Colors Colors
        {
            get { return Colors; }
            set { Colors = value; IsPainted = true; }
        }
        /// <summary>
        /// Costructor
        /// </summary>
        /// <param name="Material"></param>
        /// <param name="coords"></param>
        public Figure(Material Material = Material.FIlm, params int[] coords)
        {
            this.Material = Material;
            this.coords = coords;
        }
        /// <summary>
        /// Paint paper 
        /// </summary>
        /// <param name="colors"></param>
        public void Paint(Colors colors)
        {
            if (Material == Material.FIlm)
                throw new Exception("You can't do this. Type of figure FILM");

            if (IsPainted == false)
                Colors = colors;
        }
        /// <summary>
        /// Perimeter
        /// </summary>
        /// <returns></returns>
        public abstract double GetPerimeter();
        /// <summary>
        /// Square
        /// </summary>
        /// <returns></returns>
        public abstract double GetSquare();
        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;
            return obj is Figure figure &&
                EqualityComparer<int[]>.Default.Equals(coords, figure.coords) &&
                IsPainted == figure.IsPainted &&
                Material == figure.Material;
        }
        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="figure"></param>
        /// <returns></returns>
        public bool Equals(Figure figure)
        {
            if (figure == null)
                return false;
            return figure.IsPainted == this.IsPainted && figure.Material == this.Material && figure.coords == this.coords;
        }
        /// <summary>
        /// HashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            var hashCode = 1828495945;
            hashCode = hashCode * -1521134295 + EqualityComparer<int[]>.Default.GetHashCode(coords);
            hashCode = hashCode * -1521134295 + IsPainted.GetHashCode();
            hashCode = hashCode * -1521134295 + Material.GetHashCode();
            return hashCode;
        }
        /// <summary>
        /// Get Type of Figure
        /// </summary>
        /// <param name="figure"></param>
        /// <returns></returns>
        public static string GetFType(Figure figure) => figure.GetType().ToString();
        /// <summary>
        /// Get Material of Figure
        /// </summary>
        /// <param name="figure"></param>
        /// <returns></returns>
        public static string GetFMaterial(Figure figure) => figure.Material.ToString();

        public override string ToString() => "Figure color: " + Colors + "figure material: " + Material;
    }
}
