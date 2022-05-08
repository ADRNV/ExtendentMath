using MathExtended.Exceptions;
using MathExtended.Matrices;
using MathExtended.Matrices.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

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
            Matrix<int> matrix = new(rowsCount, columnsCount);

            Assert.Equal(rowsCount, matrix.RowsCount);
            Assert.Equal(columnsCount, matrix.ColumnsCount);
            Assert.Equal(rowsCount * columnsCount, matrix.Size);
        }

        [Fact]
        public void InitMatrixByFunc()
        {
            Func<double, double, double> func = (r, c) => (r + 1) * (c + 1);

            double[][] expected = new double[3][];

            expected[0] = new double[] { 1, 2, 3 };

            expected[1] = new double[] { 2, 4, 6 };

            expected[2] = new double[] { 3, 6, 9 };


            Matrix<double> matrix = new Matrix<double>(3, 3).InitBy(func);

            Assert.Equal(expected, (double[][])matrix);
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
        [InlineData(1, 1, 1)]
        [InlineData(3, 3, 9)]
        [InlineData(3, 2, 6)]
        [InlineData(3, 6, 18)]
        public void ForEachAsOperatorInMatrix(int rowsCount, int columnsCount, int eventInvokeCount)
        {
            int eventInvokeCountActual = 0;

            Matrix<double> matrix = new Matrix<double>(rowsCount, columnsCount);

            foreach (double cell in matrix)
            {
                eventInvokeCountActual++;
            }

            Assert.Equal(eventInvokeCount, eventInvokeCountActual);
        }


        [Theory]
        [InlineData(3, 3, new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
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
        [InlineData(2, 3, new int[] { 2, 4, 6, 8, 10, 12 })]
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
        [InlineData(3, 3, 3, 3)]
        [InlineData(3, 2, 3, 2)]
        [InlineData(3, 6, 3, 6)]
        public void MinusOperatorMatrices
        (int rowsCountFirstMatrix, int columnsCountFirstMatrix, int rowsCountSecondMatrix, int columnsCountSecondMatrix)
        {
            Matrix<double> matrixA = new Matrix<double>(rowsCountFirstMatrix, columnsCountFirstMatrix).FillInOrder();

            Matrix<double> matrixB = new Matrix<double>(rowsCountSecondMatrix, columnsCountSecondMatrix).FillInOrder();

            Matrix<double> result = matrixA - matrixB;

            result.ToList().ForEach(c => Assert.Equal(0, c));
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

        [Theory]
        [InlineData(3, 3, 3, 3, new double[] { 30, 36, 42, 66, 81, 96, 102, 126, 150 })]
        [InlineData(4, 4, 4, 4, new double[] { 90, 100, 110, 120, 202, 228, 254, 280, 314, 356, 398, 440, 426, 484, 542, 600 })]
        [InlineData(4, 3, 3, 4, new double[] { 38, 44, 50, 56, 83, 98, 113, 128, 128, 152, 176, 200, 173, 206, 239, 272 })]
        [InlineData(2, 3, 3, 2, new double[] { 22, 28, 49, 64 })]
        public void MultiplyOperatorMatricesDifferentSizes(int rowsCountFirstMatrix, int columnsCountFirstMatrix, int rowCountSecondMatrix, int columnsCountSecondMatrix, ICollection<double> expected)
        {
            Matrix<double> matrixA = new Matrix<double>(rowsCountFirstMatrix, columnsCountFirstMatrix).FillInOrder();

            Matrix<double> matrixB = new Matrix<double>(rowCountSecondMatrix, columnsCountSecondMatrix).FillInOrder();

            Matrix<double> result = matrixA * matrixB;

            Assert.Equal(expected, result);

        }

        [Theory]
        [InlineData(3, 2, 4, 2)]
        [InlineData(4, 2, 3, 2)]
        public void MultiplyOperatorInvalidSizes(int rowsCountFirstMatrix, int columnsCountFirstMatrix, int rowCountSecondMatrix, int columnsCountSecondMatrix)
        {
            Matrix<double> matrixA = new Matrix<double>(rowsCountFirstMatrix, columnsCountFirstMatrix);

            Matrix<double> matrixB = new Matrix<double>(rowCountSecondMatrix, columnsCountSecondMatrix);

            Assert.Throws<TheNumberOfRowsAndColumnsIsDifferentException>(() => matrixA * matrixB);
        }

        [Theory]
        [InlineData(3, 3, new double[] { 1, 4, 7, 2, 5, 8, 3, 6, 9 })]
        [InlineData(3, 2, new double[] { 1, 3, 5, 2, 4, 6 })]
        [InlineData(2, 3, new double[] { 1, 4, 2, 5, 3, 6 })]
        public void TransponateMatrixDifferentSizes(int rowsCount, int columsCount, ICollection<double> expected)
        {
            Matrix<double> matrix = new Matrix<double>(rowsCount, columsCount)
                .FillInOrder()
                .Transponate();

            Assert.Equal(expected, matrix);
        }

        [Theory]
        [InlineData(3, 3, new double[] { 1, 0, -1, 0, 1, 2, 0, 0, 0 })]
        public void ToSteppedViewMatrixDifferentSizes(int rowsCount, int columsCount, ICollection<double> expected)
        {
            Matrix<double> steppedMatrix = new Matrix<double>(rowsCount, columsCount)
                .FillInOrder()
                .ToSteppedView();

            Assert.Equal(expected, steppedMatrix);

        }

        [Fact]
        public void MatrixCalculateDeterminant()
        {
            Matrix<double> matrix1 = new Matrix<double>(3, 3).FillInOrder();

            Assert.Equal(0, matrix1.CalculateDeterminant());
        }

    }
}
