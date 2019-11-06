using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Euklides
{
    public class Staine
    {
        /// <summary>
        /// Алгоритм Стейна
        /// </summary>
        /// В данном методе описываем реализацию алгоритма Стейна
        /// В методе присутсвует выходной параметр времени потраченое на решение.
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>
        /// Наибольший Общий Делитель (НОД)
        /// Время затраченное на решение данного алгоритма
        /// </returns>
        public int GetBiGCD(int a, int b, out long staineTime) // НОД 2-ух чисел с выходным параметром времени
        {
            long time;
            int result;
            Stopwatch st = new Stopwatch();
            st.Start();

            if (a == 0) { st.Stop(); staineTime = st.ElapsedMilliseconds; return b; }
            if (b == 0) { st.Stop(); staineTime = st.ElapsedMilliseconds; return a; }
            if (a == b) { st.Stop(); staineTime = st.ElapsedMilliseconds; return a; }
            if (a == 1 || b == 1) { st.Stop(); staineTime = st.ElapsedMilliseconds; return 1; }
            if ((a % 2 == 0) && (b % 2 == 0))
            {
                result = 2 * GetBiGCD(a / 2, b / 2, out time);
                st.Stop();
                staineTime = st.ElapsedMilliseconds + time;
                return result;
            }
            if ((a % 2 == 0) && (b % 2 != 0))
            {
                result = GetBiGCD(a / 2, b, out time);
                st.Stop();
                staineTime = st.ElapsedMilliseconds + time;
                return result;
            }
            if ((a % 2 != 0) && (b % 2 == 0))
            {
                result = GetBiGCD(a, b / 2, out time);
                st.Stop();
                staineTime = st.ElapsedMilliseconds + time;
                return result;
            }
            result = GetBiGCD(b, Math.Abs(a - b), out time);
            st.Stop();
            staineTime = st.ElapsedMilliseconds + time;
            return result;
        }
    }
}
