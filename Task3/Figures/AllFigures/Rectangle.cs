using System;

namespace Task3.Figures
{
    /// <summary>
    /// Abstract class for all Rectangle
    /// </summary>
    public abstract class Rectangle : IFigure
    {
        float width, height;
        /// <summary>
        /// Constructor for Rectangle
        /// </summary>
        /// <param name="h">Height</param>
        /// <param name="w">Width</param>
        public Rectangle(float h, float w)
        {
            Width = w;
            Height = h;
        }
        /// <summary>
        /// Constructor for cutting new rectangle from rectangle
        /// </summary>
        /// <param name="figure">Figure for cut</param>
        /// <param name="h">Height</param>
        /// <param name="w">Width</param>
        public Rectangle(IFigure figure, float h, float w)
        {
            if (h <= 0 && w <= 0)
            {
                throw new Exception("Invalid input parameter");
            }
            if (!(figure is Rectangle))
            {
                throw new Exception("Invalid Figure for cut");
            }
            this.Width = w;
            this.Height = h;
            if (figure.Area <= this.Area)
            {
                throw new Exception("Figure fot cut less than new");
            }
        }
        /// <summary>
        /// Area of Rectangle
        /// </summary>
        public float Area { get => Width * Height; }
        /// <summary>
        /// Perimeter of Rectangle
        /// </summary>
        public float Perimeter { get => 2 * (Width + Height); }
        /// <summary>
        /// Property of width
        /// </summary>
        public float Width { get => width; set => width = value; }
        /// <summary>
        /// Property of height
        /// </summary>
        public float Height { get => height; set => height = value; }
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
