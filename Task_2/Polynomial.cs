using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    public class Polynomial
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
        public int Degree
        {
            get { return coefficients.Length; }
        }
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
        /// <summary>
        /// Оператор вычитания
        /// </summary>
        /// <param name="P1"></param>
        /// <param name="P2"></param>
        /// <returns>
        /// Вычитание многочленов
        /// </returns>
        public static Polynomial operator -(Polynomial P1, Polynomial P2)
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
                result[i] = z - x;
            }
            return new Polynomial(result);
        }
        /// <summary>
        /// Оператор умножения
        /// </summary>
        /// <param name="P1"></param>
        /// <param name="P2"></param>
        /// <returns>
        /// Умножение многочленов
        /// </returns>
        public static Polynomial operator *(Polynomial P1, Polynomial P2)
        {          
            Polynomial P3 = new Polynomial(P1.coefficients.Length + P2.coefficients.Length - 1);
            for (int i = 0; i < P1.coefficients.Length; ++i)
            {
                for (int j = 0; i < P2.coefficients.Length; ++j)
                {
                    P3[i + j] += P1[i] * P2[j];
                }
            }
            return P3;
        }
        /// <summary>
        /// Оператор равенства
        /// </summary>
        /// <param name="P1"></param>
        /// <param name="P2"></param>
        /// <returns>
        /// Проверка на равенство многочленов
        /// </returns>
        public static bool operator ==(Polynomial P1, Polynomial P2)
        {
            if (P1.coefficients.Length != P2.coefficients.Length)
            {
                return false;
            }
            for (int i = 0; i < P1.coefficients.Length; i++)
            {
                if (P1[i] != P2[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static bool operator !=(Polynomial P1, Polynomial P2)
        {
            return !(P1 == P2);
        }

        public override string ToString()
        {
            return string.Format("Коэффициенты:*" + string.Join(";*", coefficients));
        }
    }
}
