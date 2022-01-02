using MathExtended.Interfaces;
using MathExtended.Matrices.Structures.CellsCollections;
using System;
using System.Collections.Generic;
using System.Linq;
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
        /// В разработке
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="matrix"></param>
        /// <param name="downRowBound"></param>
        /// <param name="downColumnBound"></param>
        /// <param name="upperRowBound"></param>
        /// <param name="upperColumnBound"></param>
        /// <returns></returns>
        public static IMatrix<T> GetSubMatrix<T>(this Matrix<T> matrix,int downRowBound, int downColumnBound, int upperRowBound, int upperColumnBound) where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            Matrix<T> subMatrix = new Matrix<T>
                (upperRowBound+downColumnBound,upperColumnBound+downRowBound);

            for (int row = downRowBound; row < upperRowBound; row++)
            {
                for (int column = downColumnBound; column < upperColumnBound; column++)
                {
                    subMatrix[row, column] = matrix[row, column];
                }
            }



            return subMatrix;

        }

       
    }
}
