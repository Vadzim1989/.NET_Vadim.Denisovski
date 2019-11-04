using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Euklides
{    
    using gcd = System.Int32;
    public class Euklides
    {
               
        /// <summary> Реализация алгоритма Евклида 
        /// </summary>
        /// Для вычесления НОД используем цикл while
        /// в цикле задаем условие (b не равно 0)
        /// производим математические вычисления              
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>
        /// Возвращаем результат вычисления 
        /// </returns>
        /// 

        public gcd GetGCD(gcd a, gcd b) // НОД 2-ух целых чисел
        {
            while (b != 0)
                b = a % (a = b);
            return a;            
        }

        public gcd GetGCD(gcd a, gcd b, gcd c) // НОД 3-ех целых чисел
        {
           return GetGCD(GetGCD(a, b), c);
        }

        public gcd GetGCD(gcd a, gcd b, gcd c, gcd d) // НОД 4-ех целых чисел
        {         
           return GetGCD(GetGCD(GetGCD(a, b), c), d);
        }

        public gcd GetGCD(gcd a, gcd b, gcd c, gcd d, gcd e) // НОД 5-ти целых чисел
        {
            return GetGCD(GetGCD(GetGCD(GetGCD(a, b), c), d), e);
        }       
    }
}
