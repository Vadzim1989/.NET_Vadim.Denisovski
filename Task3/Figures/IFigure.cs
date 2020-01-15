using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Figures
{
    /// <summary>
    /// Interface for all Figures
    /// </summary>
    public interface IFigure
    {
        /// <summary>
        /// Area of Figure
        /// </summary>
        float Area { get; }
        /// <summary>
        /// Perimeter of Figure
        /// </summary>
        float Perimeter { get; }
    }
}
