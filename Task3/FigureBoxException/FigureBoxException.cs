using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.FigureBoxException
{
    /// <summary>
    /// Exception full box
    /// </summary>
    public class FullBoxEx : Exception
    {
        public override string Message => "You can't add this figure, becouse box is full! Remove some of figures and try again";
        public FullBoxEx() : base()
        {
        }
    }
    /// <summary>
    /// Exception empty box
    /// </summary>
    public class EmptyBoxEx : Exception
    {
        public override string Message => "Box is empty, put something and try again";
        public EmptyBoxEx() : base()
        {
        }
    }
    /// <summary>
    /// Exception exist figure
    /// </summary>
    public class ExistFigureEx : Exception
    {
        public override string Message => "You can't make this figure, becouse she already exists";
        public ExistFigureEx() : base()
        {
        }
    }
    /// <summary>
    /// Exception Invalid number
    /// </summary>
    public class InvalidNumEx : Exception
    {
        int number;
        public InvalidNumEx(int number) : base()
        {
            this.number = number;
        }

        public override string Message => "There is no figure by this number. The amount of figures is " + number;
    }
    /// <summary>
    /// Exception Negative number
    /// </summary>
    public class NegativeNumEx : Exception
    {
        public override string Message => "You need to input positive number";
        public NegativeNumEx() : base()
        {
        }
    }
}
