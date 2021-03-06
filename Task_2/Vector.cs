﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    public class Vector
    {
        /// <summary>
        /// координаты
        /// </summary>
        public double x, y, z;
        /// <summary>
        /// параметризованный конструктор
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Vector(double x = 0, double y = 0, double z = 0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        /// <summary>
        /// Значение координат
        /// </summary>
        /// <returns></returns>
        public double GetX() => x;
        public double GetY() => y;
        public double GetZ() => z;
        /// <summary>
        /// Перегружаем оператор сложения
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <returns>
        /// Новый вектор со сложенными координатами
        /// </returns>
        public static Vector operator +(Vector obj1, Vector obj2)
        {
            Vector Vec = new Vector();
            Vec.x = obj1.x + obj2.x;
            Vec.y = obj1.y + obj2.y;
            Vec.z = obj1.z + obj2.z;
            return Vec;
        }
        /// <summary>
        /// Перегружаем оператор разности
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <returns>
        /// Новый вектор с разностью координат
        /// </returns>
        public static Vector operator -(Vector obj1, Vector obj2)
        {
            Vector Vec = new Vector();
            Vec.x = obj1.x - obj2.x;
            Vec.y = obj1.y - obj2.y;
            Vec.z = obj1.z - obj2.z;
            return Vec;
        }
        /// <summary>
        /// Перегружаем оператор произведения
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <returns>
        /// Новый вектор с произведением координат
        /// </returns>
        public static Vector operator *(Vector obj1, Vector obj2)
        {
            Vector Vec = new Vector();
            Vec.x = obj1.x * obj2.x;
            Vec.y = obj1.y * obj2.y;
            Vec.z = obj1.z * obj2.z;
            return Vec;
        }
        /// <summary>
        /// Вычесляем длину вектора
        /// </summary>
        /// <returns>
        /// Длина вектора
        /// </returns>
        public double Lenght()
        {
            return Math.Sqrt((x * x) + (y * y) + (z * z));
        }
        /// <summary>
        /// Перегружаем оператор равенства
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <returns>
        /// Результат сравнения
        /// </returns>
        public static bool operator == (Vector obj1, Vector obj2)
        {         
            bool obj1Null = ReferenceEquals(obj1, null), obj2Null = ReferenceEquals(obj2, null);            
            if (obj1Null || obj2Null)            
                return obj1Null && obj2Null;
            return ReferenceEquals(obj1, obj2) || obj1.Lenght() == obj2.Lenght();
        }
        /// <summary>
        /// Перегружаем оператор неравенства
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <returns></returns>
        public static bool operator != (Vector obj1, Vector obj2)
        {
            return !(obj1 == obj2);
        }

        /// <summary>
        /// Данный метод проверяет экземпляры на тождество
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>        
        public override bool Equals(object obj)
        {
            if (obj is Vector)            
                return true; 
            return base.Equals(obj);
        }
        /// <summary>
        /// Метод генерации хэш-кодов
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hash = 3, hashCode = x.GetHashCode();
            hashCode = hash * hashCode + y.GetHashCode();
            hashCode = hash * hashCode + z.GetHashCode();
            return hashCode;
        }

    }
}
    