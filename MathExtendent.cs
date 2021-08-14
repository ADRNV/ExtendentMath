using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathExtended.Exceptions;

namespace MathExtended
{
    /// <summary>
    /// Класс с функциями дополняющими Math
    /// </summary>
    public static class MathExtendent
    {
        /// <summary>
        ///Секанс
        /// </summary>
        /// <param name="x"></param>
        /// <returns>Возвращает cэканс x</returns>
        public static double Sec(double x)
        {

            return 1 / Math.Cos(x);

        }
        /// <summary>
        /// Гиперболический секанс
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double Sch(double x)
        {
            return 1 / Math.Cosh(x);
        }

        /// <summary>
        ///Косеканс 
        /// </summary>
        /// <param name="x"></param>
        /// <returns>Возвращает коcеканс x</returns>
        public static double Cosec(double x)
        {
            return 1 / Math.Sin(x);
        }
        /// <summary>
        /// Гиперболический котангенс
        /// </summary>
        /// <param name="x"></param>
        /// <returns>Котангенс x</returns>
        public static double Ctgh(double x)
        {
            return 1 / Math.Tanh(x);
        }

        /// <summary>
        /// Гиперболический косеканс
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double Csch(double x)
        {

            return 1 / Sch(x);
        }
        
        /// <summary>
        /// Вычисляет алгебраическую сумму функции
        /// </summary>
        /// <param name="i">Индекс суммирования</param>
        /// <param name="n">Верхняя граница</param>
        /// <param name="func">Функция</param>
        /// <returns><see cref="double"/> Алгебраическая сумма</returns>
        public static double AlgebraicSum(double i, double n, Func<double, double> func)
        {
            double sum = 0;

            for (; i <= n; i++)
            {
                sum += func(i);
            }

            return sum;
        }

        /// <summary>
        /// Вычисляет алгебраическую сумму функции
        /// </summary>
        /// <param name="i">Индекс суммирования</param>
        /// <param name="min">Нижняя граница</param>
        /// <param name="max">Верхняя граница</param>
        /// <param name="func">Функция</param>
        /// <returns><see cref="double"/> Алгебраическая сумма</returns>
        public static double AlgebraicSum(double i, double min, double max, Func<double, double> func)
        {
            double sum = 0;

            for (; i <= max && i >= max; i++)
            {
                sum += func.Invoke(i);
            }

            return sum;
        }
    }
}


