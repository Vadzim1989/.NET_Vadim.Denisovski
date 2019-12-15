using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Shapes
{
    class Coords
    {
        /// <summary>
        /// Coordinates
        /// </summary>
        public int x { get; set; }
        public int y { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Coords(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        /// <summary>
        /// Get length of side
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns>
        /// Length of side
        /// </returns>
        public static double Length(Coords c1, Coords c2)
        {
            return Math.Sqrt(Math.Pow(c1.x - c2.x, 2) + Math.Pow(c1.y - c2.y, 2));
        }
    }
}
