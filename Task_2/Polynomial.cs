using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class Polynomial
    {
        /// <summary>
        /// коэффициенты многочлена
        /// </summary>
        private double[] coefficients;
        /// <summary>
        /// Создаем многочлен по заданным коэффициентам
        /// </summary>
        /// <param name="coefficients"></param>
        public Polynomial(params double[] coefficients)
        {
            this.coefficients = coefficients;
        }
        /// <summary>
        /// Получение/установка значения коэффициента
        /// </summary>
        /// <param name="n"></param>
        /// <returns>
        /// Значение коэффициента
        /// </returns>
        public double this[int n]
        {
            get { return coefficients[n]; }
            set { coefficients[n] = value; }
        }
        /// <summary>
        /// Степень многочлена
        /// </summary>
        public int Degree => coefficients.Length;
        /// <summary>
        /// Расчет значения многочлена по схеме Горнера
        /// </summary>
        /// <param name="x"></param>
        /// <returns>
        /// Значение многочлена
        /// </returns>
        public double Calculate(double x)
        {
            int n = coefficients.Length - 1;
            double result = coefficients[n];
            for (int i = n - 1; i >= 0; i--)
            {
                result = x * result + coefficients[i];
            }
            return result;
        }
        /// <summary>
        /// Оператор сложения
        /// </summary>
        /// <param name="P1"></param>
        /// <param name="P2"></param>
        /// <returns>
        /// Сложение многочленов
        /// </returns>
        public static Polynomial operator +(Polynomial P1, Polynomial P2)
        {
            int count = Math.Max(P1.coefficients.Length, P2.coefficients.Length);
            var result = new double[count];
            for (int i = 0; i < count; i++)
            {
                double z = 0;
                double x = 0;
                if (i < P1.coefficients.Length)
                    z = P1[i];
                if (i < P2.coefficients.Length)
                    x = P2[i];
                result[i] = z + x;
            }
            return new Polynomial(result);
        }
    }
}
