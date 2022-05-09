using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathExtended.Matrices.Structures.Columns;
using MathExtended.Matrices.Structures.Rows;
using Xunit;

namespace MathExtendentTests.Matrices.Structures.Columns
{
    public class ColumnTests
    {
        [Fact]
        public void ColumnCastToArray()
        {
            Column<int> row = new Column<int>(3);

            int[] array = { 0, 0, 0 };

            Assert.Equal(array.GetType(), ((int[])row).GetType());
        }

        [Fact]
        public void ArrayCastToRow()
        {
            Column<int> row = new Column<int>(3);

            int[] array = { 0, 0, 0 };

            row = array;

            Assert.Equal(row.GetType(), ((Column<int>)array).GetType());
        }

        [Theory]
        [InlineData(new double[3] { 2, 3, 1 })]
        [InlineData(new double[5] { 1, 2, 3, 4, 5 })]
        [InlineData(new double[6] { 1, 2, 3, 4, 5, 6 })]
        public void TransponateRowToColum(double[] array)
        {
            Row<double> colum = array;

            Column<double> row = array;

            Assert.Equal(row, colum.Transponate());
        }

        [Theory]
        [InlineData(0, new double[3] { 2, 3, 1 }, new double[3] { 0, 0, 0 })]
        [InlineData(1, new double[3] { 1, 2, 3 }, new double[3] { 1, 2, 3 })]
        [InlineData(-1, new double[3] { 1, 2, 3 }, new double[3] { -1, -2, -3 })]
        public void MultiplyOperatorMultiplierToColumn(double multiplier, double[] row, double[] expected)
        {
            Column<double> multiplyedRow = multiplier * (Column<double>)row;

            Assert.Equal(multiplyedRow, expected);
        }

        [Theory]
        [InlineData(new double[3] { 2, 3, 1 }, 0, new double[3] { 0, 0, 0 })]
        [InlineData(new double[3] { 1, 2, 3 }, 1, new double[3] { 1, 2, 3 })]
        [InlineData(new double[3] { 1, 2, 3 }, -1, new double[3] { -1, -2, -3 })]
        public void MultiplyOperatorColumnToMultiplier(double[] column, double multiplier, double[] expected)
        {
            Column<double> multiplyedColumn = multiplier * (Column<double>)column;

            Assert.Equal(multiplyedColumn, expected);
        }

        [Theory]
        [InlineData(new double[3] { 1, 1, 1 }, new double[3] { 1, 1, 1 }, new double[3] { 2, 2, 2 })]
        [InlineData(new double[3] { 1, 2, 3 }, new double[3] { 1, 2, 3 }, new double[3] { 2, 4, 6 })]
        [InlineData(new double[3] { -1, -2, -3 }, new double[3] { 1, 2, 3 }, new double[3] { 0, 0, 0 })]
        public void AddOperatorColumn(double[] columnA, double[] columnB, double[] expected)
        {
            Assert.Equal(expected, (Column<double>)columnA + columnB);
        }

        [Theory]
        [InlineData(new double[3] { 1, 1, 1 }, new double[3] { 1, 1, 1 }, new double[3] { 0, 0, 0 })]
        [InlineData(new double[3] { 1, 3, 3 }, new double[3] { 1, 2, 1 }, new double[3] { 0, 1, 2 })]
        [InlineData(new double[3] { -1, -2, -3 }, new double[3] { 1, 2, 3 }, new double[3] { -2, -4, -6 })]
        public void MinusOperatoColumn(double[] columnsA, double[] columnsB, double[] expected)
        {
            Assert.Equal(expected, ((Column<double>)columnsA - columnsB));
        }

    }
}
