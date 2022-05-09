using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathExtended.Exceptions;
using MathExtended.Matrices.Structures.Columns;
using MathExtended.Matrices.Structures.Rows;
using Xunit;

namespace MathExtendentTests.Matrices.Structures.Rows
{
    public class RowTests
    {
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
        [InlineData(new double[3] { 2, 3, 1 })]
        [InlineData(new double[5] { 1, 2, 3, 4, 5})]
        [InlineData(new double[6] { 1, 2, 3, 4, 5, 6})]
        public void TransponateRowToColum(double[] array)
        {
            Row<double> row = array;

            Column<double> colum = array;

            Assert.Equal(colum,row.Transponate());
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
        [InlineData(new double[3] { 1, 1, 1 }, new double[3] { 1, 1, 1 }, new double[3] { 2, 2, 2 })]
        [InlineData(new double[3] { 1, 2, 3 }, new double[3] { 1, 2, 3 }, new double[3] { 2, 4, 6 })]
        [InlineData(new double[3] { -1, -2, -3 }, new double[3] { 1, 2, 3 }, new double[3] { 0, 0, 0 })]
        public void AddOperatorRow(double[] rowA, double[] rowB, double[] expected)
        {
            Assert.Equal(expected, (Row<double>)rowA + rowB);
        }

        [Theory]
        [InlineData(new double[3] { 1, 1, 1 }, new double[3] { 1, 1, 1 }, new double[3] { 0, 0, 0 })]
        [InlineData(new double[3] { 1, 3, 3 }, new double[3] { 1, 2, 1 }, new double[3] { 0, 1, 2 })]
        [InlineData(new double[3] { -1, -2, -3 }, new double[3] { 1, 2, 3 }, new double[3] { -2, -4, -6 })]
        public void MinusOperatorRow(double[] rowA, double[] rowB, double[] expected)
        {
            Assert.Equal(expected, ((Row<double>)rowA - rowB));
        }

        [Theory]
        [InlineData(new double[3] { 1, 2, 3 }, new double[3] { 1, 2, 3 }, 14)]
        [InlineData(new double[3] { 0, 0, 0 }, new double[3] { 1, 2, 3 }, 0)]
        public void MultiplyOperatorRowToColumn(double[] row, double[] column, double expected)
        {
            Assert.Equal(expected, (Row<double>)row * (Column<double>)column);
        }

        [Theory]
        [InlineData(new double[3] { 1, 1, 1 }, new double[2] { 1, 1 })]
        [InlineData(new double[2] { 1, 2 }, new double[3] { 1, 2, 3 })]
        [InlineData(new double[0] { }, new double[3] { 1, 2, 3 })]
        [InlineData(new double[2] { 1, 2 }, new double[0]{})]
        public void AddOperatorRowInvalidSizes(double[] rowA, double[] rowB)
        {
            Assert.Throws<RowsOfDifferentSizesException>(() => (Row<double>)rowA + rowB);
        }
    }
}
