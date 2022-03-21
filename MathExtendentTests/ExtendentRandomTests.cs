using MathExtended;
using System;
using Xunit;

namespace MathExtendedTests
{
    public class ExtendentRandomTests
    {
        [Theory]
        [InlineData(1, 3)]
        [InlineData(2, 3)]
        [InlineData(-2, 0)]
        [InlineData(-2, 3)]
        public void ExtendentRandomGeneratesIntValueInRangeOfValues(int downBound, int upperBound)
        {
            int generatedValue = new ExtendentRandom().Next(downBound, upperBound);

            Assert.True(generatedValue < upperBound && generatedValue >= downBound);
        }

        [Theory]
        [InlineData(1, 3)]
        [InlineData(2, 3)]
        [InlineData(3.6, 3.7)]
        [InlineData(2.666, 2.777)]
        [InlineData(-3.6, 0)]
        [InlineData(-3.1, -2)]
        public void ExtendentRandomGeneratesDoubleValueInRangeOfValues(double downBound, double upperBound)
        {
            double generatedValue = new ExtendentRandom().Next(downBound, upperBound);

            Assert.True(generatedValue < upperBound && generatedValue >= downBound);
        }

        [Theory]
        [InlineData(4, 2)]
        [InlineData(2, 0)]
        [InlineData(-2, -4)]
        public void ExtendentRandomGeneratesValueInInvalidRange(int downBound, int upperBound)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new ExtendentRandom().Next(downBound, upperBound));
        }



    }
}
