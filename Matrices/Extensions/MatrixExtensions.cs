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
        /// Выполняет действие с кaждой ячейкой матрицы
        /// </summary>
        /// <param name="matrix">Матрица</param>
        /// <param name="action">Действие</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ForEach<T>(this Matrix<T> matrix, Action<T> action) where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            foreach (var cell in matrix)
            {
                action(cell);
            }
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
        public static Matrix<T> FillRandom<T>(this Matrix<T> matrix ,T min, T max) where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
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
    }
}
