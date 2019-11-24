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
            Polynomial P1 = new Polynomial(1, 2);
            var Calc = P1.Calculate(2);
            Console.WriteLine(Calc);
            Polynomial P2 = new Polynomial(10, 20, 30,40);
            Polynomial P3 = P1 + P2;
            Calc = P3.Calculate(2);
            Console.WriteLine("*******************");
            Console.WriteLine(Calc);
            P3 = P1 - P2;
            Calc = P3.Calculate(2);
            Console.WriteLine("*******************");
            Console.WriteLine(Calc);
            P3 = P1 * P2;
            Calc = P3.Calculate(2);
            Console.WriteLine("*******************");
            Console.WriteLine(Calc);
        }
    }
}
