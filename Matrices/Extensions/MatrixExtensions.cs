using MathExtended.Exceptions;
using MathExtended.Interfaces;
using MathExtended.Matrices.Structures.CellsCollections;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;


namespace MathExtended.Matrices.Extensions
{
    /// <summary>
    /// Класс расширений для объектов <see cref="IMatrix{T}"/>
    /// </summary>
    public static class MatrixExtensions
    {
        /// <summary>
        /// Выполняет действие с кaждой ячейкой матрицы
        /// </summary>
        /// <param name="matrix">Матрица</param>
        /// <param name="action">Действие</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ForEach<T>(this IMatrix<T> matrix, Action<T> action) where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            foreach (var cell in matrix)
            {
                action(cell);
            }
        }
        private static void ForEach<T>(this IMatrix<T> matrix, Action<int, int> action) where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            if (action == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                for (dynamic row = 0; row < matrix.RowsCount; row++)
                {
                    for (dynamic column = 0; column < matrix.ColumnsCount; column++)
                    {
                        action(row, column);
                    }
                }
            }

        }

        private static void ForEachAsParrallel<T>(this IMatrix<T> matrix, Action<int, int> action) where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            Parallel.For(0, matrix.RowsCount, row =>
            {
                Parallel.For(0, matrix.ColumnsCount, column =>
                {
                    action.Invoke(row, column);
                });
            });
        }

        /// <summary>
        /// Invokes action for each cell in matrix
        /// </summary>
        /// <typeparam name="T">Numerical type</typeparam>
        /// <param name="matrix">Matrix</param>
        /// <param name="action">Action(takes matrix cell value)</param>
        public static void ForEachAsParrallel<T>(this IMatrix<T> matrix, Action<T> action) where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            Parallel.For(0, matrix.RowsCount, row =>
            {
                Parallel.For(0, matrix.ColumnsCount, column =>
                {
                    action.Invoke(matrix[row, column]);
                });
            });
        }

        /// <summary>
        /// Находит главную диагональ матрицы
        /// </summary>
        /// <typeparam name="T">Тип ячеек матрицы</typeparam>
        /// <param name="matrix">Матрица</param>
        /// <returns>Главна диагональ</returns>
        public static MainDiagonal<T> FindDiagonal<T>(this IMatrix<T> matrix) where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            List<T> mainDiagonal = new List<T>();

            ForEach(matrix, (row, column) =>
            {
                if (row == column)
                {
                    mainDiagonal.Add(matrix[row, column]);
                }

            });

            return new MainDiagonal<T>(mainDiagonal.ToArray());
        }

        /// <summary>
        /// Транспонирует(меняет строки со столбцами) текущую матрицу и возвращает новую
        /// </summary>
        /// <returns>Транспонированная матрица</returns>
        public static Matrix<T> Transponate<T>(this IMatrix<T> matrix) where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            Matrix<T> transposedMatrix = new Matrix<T>(matrix.ColumnsCount, matrix.RowsCount);

            transposedMatrix.ForEachAsParrallel((r, c) => transposedMatrix[r, c] = matrix[c, r]);

            return transposedMatrix;
        }

        /// <summary>
        /// Initialize matrix by function
        /// matrix cell value will be equal to function(Method) result.
        /// Arguments for function - cells indexes
        /// </summary>
        /// <typeparam name="T">Numerical type</typeparam>
        /// <param name="matrix">Matrix</param>
        /// <param name="func">Function</param>
        /// <returns>Initialized matrix</returns>
        public static Matrix<T> InitBy<T>(this IMatrix<T> matrix, Func<T, T, T> func) where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            Matrix<T> initedMatrix = new Matrix<T>(matrix.RowsCount, matrix.ColumnsCount);

            matrix.ForEach((r, c) => initedMatrix[r, c] = func.Invoke((dynamic)r, (dynamic)c));

            return initedMatrix;
        }

        /// <summary>
        /// Заполняет матрицу по порядку:от 1-го до размера последнего элемента матрицы
        /// </summary>
        /// <returns>Матрица заполненная по порядку</returns>
        public static Matrix<T> FillInOrder<T>(this IMatrix<T> matrix) where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            Matrix<T> filledMatrix = new Matrix<T>(matrix.RowsCount, matrix.ColumnsCount);

            dynamic counter = 1;

            matrix.ForEach((row, column) => filledMatrix[row, column] = counter++);

            return filledMatrix;
        }


        /// <summary>
        /// Заполняет матрицу случайными целочисленными значениями
        /// </summary>
        /// <returns>Матрица со случайными значениями</returns>
        public static Matrix<T> FillRandom<T>(this IMatrix<T> matrix) where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            Matrix<T> filledMatrix = new Matrix<T>(matrix.RowsCount, matrix.ColumnsCount);

            ExtendentRandom random = new ExtendentRandom();

            Parallel.For(0, matrix.RowsCount, row =>
            {
                Parallel.For(0, matrix.ColumnsCount, column =>
                {
                    filledMatrix[row, column] = random.Next<T>();
                });
            });

            return filledMatrix;
        }

        /// <summary>
        /// Заполняет матрицу случайными значениями в определенном диапазоне
        /// </summary>
        /// <param name="matrix">Матрица</param>
        /// <param name="min">Минимальное число</param>
        /// <param name="max">Максимальное число</param>
        /// <returns>Матрица со случайными значениями</returns>
        public static Matrix<T> FillRandom<T>(this IMatrix<T> matrix, T min, T max) where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            Matrix<T> filledMatrix = new Matrix<T>(matrix.RowsCount, matrix.ColumnsCount);

            ExtendentRandom random = new ExtendentRandom();

            Parallel.For(0, matrix.RowsCount, row =>
            {
                Parallel.For(0, matrix.ColumnsCount, column =>
                {

                    filledMatrix[row, column] = random.Next<T>(min, max);

                });
            });

            return filledMatrix;
        }

        ///<summary>
        /// Создает матрицу с вычеркнутыми столбцами на основе текущей
        /// </summary>
        /// <param name="column">Количество вычеркнутых столбцов</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix<T> CreateMatrixWithoutColumn<T>(this IMatrix<T> matrix, int column) where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            if (column < 0 || column >= matrix.ColumnsCount)
            {
                throw new ArgumentException("invalid column index");
            }
            var result = new Matrix<T>(matrix.RowsCount, matrix.ColumnsCount - 1);
            result.ForEach((i, j) =>
                result[i, j] =
                j < column ? matrix[i, j] : matrix[i, j + 1]);
            return result;
        }

        /// <summary>
        /// Создает матрицу с вычеркнутыми строками на основе текущей
        /// </summary>
        /// <param name="row">Количество вычеркнутых строк</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix<T> CreateMatrixWithoutRow<T>(this IMatrix<T> matrix,int row) where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            if (row < 0 || row >= matrix.RowsCount)
            {
                throw new ArgumentException("invalid row index");
            }
            var result = new Matrix<T>(matrix.RowsCount - 1, matrix.ColumnsCount);
            result.ForEach((i, j) =>
                result[i, j] =
                i < row ?
                matrix[i, j] : matrix[i + 1, j]);
            return result;
        }

        /// <summary>
        /// Calculates minor for
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="matrix"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public static T CalculateMinor<T>(this IMatrix<T> matrix, int row, int column) where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            return matrix.CreateMatrixWithoutColumn(column).CreateMatrixWithoutRow(row).CalculateDeterminant();
        }

        /// <summary>
        /// Возводит матрицу в степень
        /// </summary>
        /// <param name="matrix">Матрица</param>
        /// <param name="power">Степень</param>
        /// <returns>Матрица в заданной степени</returns>
        public static Matrix<T> Pow<T>(this Matrix<T> matrix, int power) where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {

            if (matrix != null && matrix.ColumnsCount == matrix.RowsCount)
            {
                var matrixC = matrix;

                for (int i = 1; i <= power; i++)
                {
                    matrixC *= matrix;
                }
                return matrixC;
            }
            else
            {
                throw new TheNumberOfRowsAndColumnsIsDifferentException();
            }

        }

        /// <summary>
        /// Calculate inverted matrix.If matrix degenerate
        /// returns <see langword="null"/>
        /// </summary>
        /// <typeparam name="T">Numerical type</typeparam>
        /// <param name="matrix">Matrix</param>
        /// <returns>Inverted matrix (matrix^-1)</returns>
        /// <exception cref="TheNumberOfRowsAndColumnsIsDifferentException"></exception>
        public static Matrix<T> CalculateInvertibleMatrix<T>(this Matrix<T> matrix) where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            if (matrix.IsSquareMatrix)
            {
                Matrix<T> inverted = new Matrix<T>(matrix.RowsCount, matrix.ColumnsCount);

                T determinant = matrix.CalculateDeterminant();

                if (!(Math.Abs((dynamic)determinant) < (T)(dynamic)0.0000001))
                {

                    matrix.ForEach((row, column) =>
                    {
                        inverted[row, column] = (dynamic)((row + column) % 2 == 1 ? -1 : 1) * matrix.CalculateMinor(row, column) / determinant;
                    });
                }
                else
                {
                    return null;
                }

                return inverted.Transponate();
            }
            else
            {
                throw new TheNumberOfRowsAndColumnsIsDifferentException();
            }
           
        }

    }
}
