using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Polynomial P1 = new Polynomial(2, 3, 4);
            Polynomial P2 = new Polynomial(1, 2, 3);
            Polynomial P3 = P1 * P2;
            double Calc = P3.Calculate(2);
            Console.WriteLine(Calc);
        }
    }
}
