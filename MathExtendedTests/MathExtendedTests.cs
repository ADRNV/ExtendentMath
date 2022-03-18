using System;
using Xunit;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using MathExtended;


namespace MathExtendedTests
{
    public class MathExtendentTest
    {
        /// <summary>
        /// ‘актические значени€ y должны совпадать с вычесленными значени€ми y
        /// </summary>
        [Fact]
        public void TabulateFunctionReturnsSameArrays()
        {
            double[] factValues = {64, 49, 36, 25, 16, 9, 4, 1, 0, 1, 4, 9, 16, 25, 36, 49, 64 };

            IReadOnlyCollection<double> calculatedValuesY;
            
            Func<double, double> function = (x) => x * x;

            calculatedValuesY = MathExtendent.TabulateFunction(-8, 8, 1, function).Y;

            Assert.Equal(factValues,calculatedValuesY);
        }

        /// <summary>
        /// ‘актическа€ алгебраическа€ сумма должна совпадать с вычисленной
        /// </summary>
       [Fact]
       public void AlgebraicSumReturnsSameSum()
       {
            double factSum = 333835502;

            double calculatedSum = MathExtendent.AlgebraicSum(0,1000,(x) => Math.Pow(x,2) + 2);

            Assert.Equal(calculatedSum, factSum);
       }


    }
}
