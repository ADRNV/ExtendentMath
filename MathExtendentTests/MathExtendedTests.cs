using MathExtended;
using System;
using System.Collections.Generic;
using Xunit;


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
            double[] factValues = { 64, 49, 36, 25, 16, 9, 4, 1, 0, 1, 4, 9, 16, 25, 36, 49, 64 };

            IReadOnlyCollection<double> calculatedValuesY;

            Func<double, double> function = (x) => x * x;

            calculatedValuesY = MathExtendent.TabulateFunction(-8, 8, 1, function).Y;

            Assert.Equal(factValues, calculatedValuesY);
        }

        /// <summary>
        /// ‘актическа€ алгебраическа€ сумма должна совпадать с вычисленной
        /// </summary>
        [Theory]
        [InlineData(0, 100, 338552)]
        [InlineData(1, 100, 338550)]
        [InlineData(0d, 5.0653d, 69.1240283333)]
        public void AlgebraicSumReturnsSameSum(double start, double stop, double expected)
        {
            double calculatedSum = MathExtendent.AlgebraicSum(start, stop, (x) => Math.Pow(x, 2) + 2);

            Assert.Equal(expected, calculatedSum);
        }

    }
}
