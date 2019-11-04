using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euklides
{
    class Programe
    {
        static void Main(string[] args)
        {
            Euklides ea = new Euklides();
            Console.WriteLine(ea.GetGCD(48,36));
        }
    }
}
