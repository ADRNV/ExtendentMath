using MathExtended.Interfaces;
using MathExtended.Matrices.Structures.CellsCollections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
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
                Parallel.For(0, matrix.RowsCount, row =>
                {
                    for (dynamic column = 0; column < matrix.ColumnsCount; column++)
                    {
                        action(row, column);
                    }
                });
            }

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
        public static IMatrix<T> Transponate<T>(this IMatrix<T> matrix) where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            var transposedMatrix = new Matrix<T>(matrix.ColumnsCount, matrix.RowsCount);

            Parallel.For(0, matrix.RowsCount, row =>
            {
                Parallel.For(0, matrix.ColumnsCount, column =>
                {
                    transposedMatrix[row, column] = matrix[column, row];
                });
            });

            return transposedMatrix;
        }

        /// <summary>
        /// Заполняет матрицу случайными целочисленными значениями
        /// </summary>
        /// <returns>Матрица со случайными значениями</returns>
        public static Matrix<T> FillRandom<T>(this IMatrix<T> matrix) where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            dynamic filledMatrix = new Matrix<T>(matrix.RowsCount, matrix.ColumnsCount);

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
        public static Matrix<T> FillRandom<T>(this IMatrix<T> matrix ,T min, T max) where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
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

        /// <summary>
        /// Находит минор матрицы
        /// </summary>
        /// <param name="matrix">Матрица</param>
        /// <param name="crossedOutRow">Вычеркнутая строка</param>
        /// <param name="crossedOutColumn">Вычеркнутый столбец</param>
        /// <returns><see cref="Matrix{T}"/> Минор матрицы</returns>
        public static Matrix<T> FindMinor<T>(this IMatrix<T> matrix,uint crossedOutRow, uint crossedOutColumn) where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            int i, j, p, q;

            Matrix<T> minor = new Matrix<T>(matrix.RowsCount - 1, matrix.ColumnsCount - 1);

            for (j = 0, q = 0; q < minor.RowsCount; j++, q++)
            {
                for (i = 0, p = 0; p < minor.ColumnsCount; i++, p++)
                {
                    if (i == crossedOutRow) i++;
                    if (j == crossedOutColumn) j++;
                    minor[p, q] = matrix[i, j];
                }

            }

            return minor;
        }
    }
}
