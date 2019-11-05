using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euklides
{
    public class Staine
    {
        /// <summary>
        /// Алгоритм Стейна
        /// </summary>
        /// В данном методе описываем реализацию алгоритма Стейна
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>
        /// Наибольший Общий Делитель (НОД)
        /// </returns>
        public int GetBiGCD(int a, int b) // НОД 2-ух чисел. БЕЗ ВЫХОДНОГО ПАРАМЕТРА
        {
            if (a == 0) return b;
            if (b == 0) return a;
            if (a == b) return a;
            if (a == 1 || b == 1) return 1;
            if ((a % 2 == 0) && (b % 2 == 0)) return 2 * GetBiGCD(a / 2, b / 2);
            if ((a % 2 == 0) && (b % 2 != 0)) return GetBiGCD(a / 2, b);
            if ((a % 2 != 0) && (b % 2 == 0)) return GetBiGCD(a, b / 2);
            return GetBiGCD(b, Math.Abs(a - b));
        }
    }
}
