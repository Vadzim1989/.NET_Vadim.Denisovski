using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Euklides
{
    public class Task1_Algorithm
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

        public int GetGCD(int a, int b) // НОД 2-ух целых чисел. Алгоритм Евклида
        {
            while (b != 0)
                b = a % (a = b);
            return a;
        }

        public int GetGCD(int a, int b, int c) // НОД 3-ех целых чисел. Алгоритм Евклида
        {
            return GetGCD(GetGCD(a, b), c);
        }

        public int GetGCD(int a, int b, int c, int d) // НОД 4-ех целых чисел. Алгоритм Евклида
        {
            return GetGCD(GetGCD(GetGCD(a, b), c), d);
        }

        public int GetGCD(int a, int b, int c, int d, int e) // НОД 5-ти целых чисел. Алгоритм Евклида
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
        public int GetGCD(int a, int b, out long euklidTime) // НОД 2-ух целых чисел с выходным параметром времени. Алгоритм Евклида
        {
            Stopwatch st = new Stopwatch();
            st.Start();
            while (b != 0)
                b = a % (a = b);
            st.Stop();
            euklidTime = st.ElapsedMilliseconds;
            return a;
        }

        /// <summary>
        /// Реализация алгоритма Стейна
        /// </summary>
        /// В данном методе описываем реализацию алгоритма Стейна
        /// В методе присутсвует выходной параметр времени потраченое на решение.
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>
        /// Наибольший Общий Делитель (НОД)
        /// Время затраченное на решение данного алгоритма
        /// </returns>
        public int GetBiGCD(int a, int b, out long staineTime) // НОД 2-ух чисел с выходным параметром времени. Алгоритм Стейна
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


        /// <summary>
        /// Метод для построения гистограмм
        /// </summary>
        /// Данный метод сравнивает время нахождения решения каждым методом и
        /// выдает их разность
        /// <param name="euklidTime"></param>
        /// <param name="staineTime"></param>
        /// <returns>
        /// если результат отрицательный значит Евклид отработал быстрее
        /// если результат положительный значит Стейн отработал быстрее
        /// </returns>
        public long GetTimeDecision(long euklidTime,long staineTime)
        {
            long res = euklidTime - staineTime;
            return res;
        }
    }
}
