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
        /// Наибольший Общий Делитель (НОД)
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

        /// <summary>
        /// Алгоритм Евклида с выходным параметром 
        /// </summary>
        /// В данном алгоритме принимается выходной параметр
        /// Выходным параметром является время потраченое на решение.
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="euklidTime"></param>
        /// <returns>
        /// Наибольший Общий Делитель (НОД)
        /// Время затраченное на решение данного алгоритма
        /// </returns>
        public gcd GetGCD(gcd a, gcd b, out long euklidTime) // НОД 2-ух целых чисел с выходным параметром времени.
        {
            Stopwatch st = new Stopwatch();
            st.Start();
            while (b != 0)
                b = a % (a = b);
            st.Stop();
            euklidTime = st.ElapsedMilliseconds;
            return a;
        }
    }
}
