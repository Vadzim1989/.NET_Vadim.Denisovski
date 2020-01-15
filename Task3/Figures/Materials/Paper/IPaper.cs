using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Figures
{
    interface IPaper
    {
        Colors Color { get; set; }
        bool IsPainted { get; set; }
    }
}
