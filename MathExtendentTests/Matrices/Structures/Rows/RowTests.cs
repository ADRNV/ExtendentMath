using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathExtended.Matrices.Structures.Rows;
using Xunit;

namespace MathExtendentTests.Matrices.Structures.Rows
{
    public class RowTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(6)]
        public void InitRow(int lenght)
        {
            Row<decimal> row = new Row<decimal>(lenght);

            Assert.Equal(lenght, row.Size);
        }

        [Theory]
        [InlineData(-1)]
        public void InitRowWithInvalidSize(int lenght)
        {
            Assert.Throws<OverflowException>(() =>
            {
                Row<decimal> row = new Row<decimal>(lenght);
            });
        }

        [Theory]
        [InlineData(new double[0] { })]
        [InlineData(new double[3] { 1, 2, 3 })]
        [InlineData(new double[6] { 1, 2, 4, 5, 6, 7 })]
        public void InitRowByArray(double[] array)
        {
            Row<double> row = new Row<double>(array);

            Assert.Equal(array.Length, row.Size);

            Assert.Equal(array, row);
        }

        [Fact]
        public void RowCastToArray()
        {
            Row<int> row = new Row<int>(3);

            int[] array = { 0, 0, 0 };

            Assert.Equal(array.GetType(), ((int[])row).GetType());
        }

        [Fact]
        public void ArrayCastToRow()
        {
            Row<int> row = new Row<int>(3);

            int[] array = { 0, 0, 0 };

            row = array;

            Assert.Equal(row.GetType(), ((Row<int>)array).GetType());
        }

        [Theory]
        [InlineData(0, new double[3] { 2, 3, 1 }, new double[3] { 0, 0, 0 })]
        [InlineData(1, new double[3] { 1, 2, 3 }, new double[3] { 1, 2, 3 })]
        [InlineData(-1, new double[3] { 1, 2, 3 }, new double[3] { -1, -2, -3 })]
        public void MultiplyOperatorMultiplierToRow(double multiplier, double[] row, double[] expected)
        {
            Row<double> multiplyedRow = multiplier * (Row<double>)row;

            Assert.Equal(multiplyedRow, expected);
        }

        [Theory]
        [InlineData(new double[3] { 2, 3, 1 }, 0, new double[3] { 0, 0, 0 })]
        [InlineData(new double[3] { 1, 2, 3 }, 1, new double[3] { 1, 2, 3 })]
        [InlineData(new double[3] { 1, 2, 3 }, -1, new double[3] { -1, -2, -3 })]
        public void MultiplyOperatorRowToMultiplier(double[] row, double multiplier, double[] expected)
        {
            Row<double> multiplyedRow = multiplier * (Row<double>)row;

            Assert.Equal(multiplyedRow, expected);
        }

        [Theory]
        [InlineData(new double[3] {1, 1, 1}, new double[3] {1, 1, 1}, new double[3] {2, 2, 2})]
        [InlineData(new double[3] { 1, 2, 3 }, new double[3] { 1, 2, 3 }, new double[3] { 2, 4, 6 })]
        public void AddOperatorRow(double[] rowA, double[] rowB, double[] expected)
        {
            Assert.Equal(expected, (Row<double>)rowA + rowB);
        }
    }
}
