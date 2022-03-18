using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions;
using MathExtended.Matrices;
using MathExtended.Exceptions;
using MathExtended.Matrices.Structures.Rows;
using MathExtended.Matrices.Extensions;
using MathExtended.Interfaces;

namespace MathExtendedTests
{
    public class MatrixTests
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(3, 3)]
        [InlineData(3, 2)]
        [InlineData(3, 6)]
        public void InitMatrix(int rowsCount, int columnsCount)
        {
            Matrix<int> matrix = new Matrix<int>(rowsCount, columnsCount);

            Assert.Equal(rowsCount, matrix.RowsCount);
            Assert.Equal(columnsCount, matrix.ColumnsCount);
            Assert.Equal(rowsCount * columnsCount, matrix.Size);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(-1, 1)]
        [InlineData(1, -1)]
        [InlineData(-1, -1)]
        public void InitInvalidRowsAndColumnsCountMatrix(int rowsCount, int columnsCount)
        {
            Assert.Throws<MatrixInvalidSizesException>(() => new Matrix<int>(rowsCount, columnsCount));
        }

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(3, 3, 9)]
        [InlineData(3, 2, 6)]
        [InlineData(3, 6, 18)]
        public void ForEachInMatrix(int rowsCount, int columnsCount, int eventInvokeCount)
        {
            int eventInvokeCountActual = 0;

            Matrix<double> matrix = new Matrix<double>(rowsCount, columnsCount);

            matrix.ForEach((cell) => eventInvokeCountActual++);

            Assert.Equal(eventInvokeCount, eventInvokeCountActual);
        }

        [Theory]
        [InlineData(3, 3, new double[] {1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [InlineData(3, 2, new double[] { 1, 2, 3, 4, 5, 6 })]
        [InlineData(2, 3, new double[] { 1, 2, 3, 4, 5, 6 })]
        public void FillInOrderAllMatrixCellls(int rowsCount, int columnsCount, IEnumerable<double> expectedValues)
        {
            Matrix<double> matrix = new Matrix<double>(rowsCount, columnsCount).FillInOrder();

            Assert.Equal(expectedValues, matrix);

        }

        [Theory]
        [InlineData(3, 3, new int[] { 2, 4, 6, 8, 10, 12, 14, 16, 18 })]
        [InlineData(3, 2, new int[] { 2, 4, 6, 8, 10, 12 })]
        [InlineData(2, 3, new int[] {2, 4, 6, 8, 10, 12})]
        public void AddOperatorMatrix(int rowsCount, int columnsCount, ICollection<int> expectedValues)
        {
            List<int> actualValues = new List<int>();

            Matrix<int> matrixA = new Matrix<int>(rowsCount, columnsCount).FillInOrder();

            Matrix<int> matrixB = new Matrix<int>(rowsCount, columnsCount).FillInOrder();

            Matrix<int> matrixС = matrixA + matrixB;

            matrixС.ForEach((cell) => actualValues.Add(cell));

            Assert.Equal(expectedValues, actualValues);

        }

        [Theory]
        [InlineData(3, 2, 2, 3)]
        [InlineData(2, 3, 3, 2)]
        public void AddOperatorMatricesDifferentSizes(int rowsCountFirstMatrix, int columnsCountFirstMatrix, int rowsCountSecondMatrix, int columnsCountSecondMatrix)
        {
            Matrix<decimal> matrixA = new Matrix<decimal>(rowsCountFirstMatrix, columnsCountFirstMatrix).FillInOrder();

            Matrix<decimal> matrixB = new Matrix<decimal>(rowsCountSecondMatrix, columnsCountSecondMatrix).FillInOrder();

            Assert.Throws<MatrixDifferentSizeException>(() => matrixA + matrixB);

        }

        [Theory]
        [InlineData(3,3,3,3)]
        [InlineData(3,2,3,2)]
        [InlineData(3,6,3,6)]
        public void MinusOperatorMatrices       
        (int rowsCountFirstMatrix, int columnsCountFirstMatrix, int rowsCountSecondMatrix, int columnsCountSecondMatrix)
        {
            Matrix<double> firstMatrix = new Matrix<double>(rowsCountFirstMatrix, columnsCountFirstMatrix).FillInOrder();

            Matrix<double> secondMatrix = new Matrix<double>(rowsCountSecondMatrix, columnsCountSecondMatrix).FillInOrder();

            Matrix<double> result = firstMatrix - secondMatrix;

            result.ForEach((c) => Assert.Equal(0, c));
        }

        [Theory]
        [InlineData(3, 2, 2, 3)]
        [InlineData(2, 3, 3, 2)]
        public void MinusOperatorMatricesDifferentSizes(int rowsCountFirstMatrix, int columnsCountFirstMatrix, int rowsCountSecondMatrix, int columnsCountSecondMatrix)
        {
            Matrix<double> matrixA = new Matrix<double>(rowsCountFirstMatrix, columnsCountFirstMatrix).FillInOrder();

            Matrix<double> matrixB = new Matrix<double>(rowsCountSecondMatrix, columnsCountSecondMatrix).FillInOrder();

            Assert.Throws<MatrixDifferentSizeException>(() => matrixA + matrixB);
        }

    }
}
