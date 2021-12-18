using MiscUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtended.GenericMath
{
    public static class GenericMath<T> where T: IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        public static T Abs(T num)
        {
            T absNum;

            if (Operator.LessThan(num, Operator.Convert<int, T>(0)))
            {
                absNum = Operator.Negate(num);

                return absNum;
            }
            else
            {
                return num;
            }
        }

       
       
    }    
}
