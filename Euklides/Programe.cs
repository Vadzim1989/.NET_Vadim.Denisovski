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
            // проверка Евклида
            Euklides ea = new Euklides();
            ea.GetGCD(32, 8, out long eTime);
            Console.WriteLine(ea.GetGCD(48, 36,12,78,8));
            Console.WriteLine($"Затраченное время на выполнение алгоритма Евклида: {eTime,2:f10}");
            // проверка Стейна
            Staine st = new Staine();
            st.GetBiGCD(32, 8, out long sTime);
            Console.WriteLine($"Затраченное время на выполнение алгоритма Стейна: {sTime,2:f10}");
        }
    }
}
