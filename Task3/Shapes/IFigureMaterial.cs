using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Shapes
{
    /// <summary>
    /// Materials from which you can work
    /// </summary>
    public enum Material
    {
        Paper,
        FIlm
    }
    /// <summary>
    /// Colors which you can use
    /// </summary>
    public enum Colors
    {
        White,
        Black,
        Green,
        Red,
        Blue,
        Yellow
    }
    /// <summary>
    /// Interface
    /// </summary>
    interface IFigureMaterial
    {
        void Paint(Colors colors);
    }
}
