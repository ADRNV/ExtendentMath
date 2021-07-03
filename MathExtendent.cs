using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathExtended.Exceptions;

namespace MathExtended
{
    public static class MathExtendent
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="x"></param>
        /// <returns>Возвращает cэканс x</returns>
        public static double Sec(double x)
        {
            
            return 1 / Math.Cos(x);

        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="x"></param>
        /// <returns>Возвращает коcэканс x</returns>
        public static double Cosec(double x)
        {
            return 1 / Math.Sin(x);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns>Котангенс x</returns>
        public static double Cottan(double x)
        {

            return Math.Cos(x) / Math.Sin(x);
        }

    }

   
    }

}
