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






    }

   
}


