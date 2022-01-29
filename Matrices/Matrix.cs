using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using MathExtended.Exceptions;
using MiscUtil;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using MathExtended.Matrices.Structures.CellsCollections;

namespace MathExtended.Matrices
{
    /// <summary>
    /// Описывает основную логику матриц
    /// </summary>
    /// <typeparam name="T">Числовой тип</typeparam>
    public class Matrix<T> : BaseMatrix<T> where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        #region Поля матрицы

        private bool isSquareMatrix;

        #endregion

        private readonly double precalculatedDeterminant = double.NaN;

        #region Свойства матрицы   
        /// <summary>
        /// Размер матрицы
        /// </summary>
        public int Size
        {
            get => matrix.Length;
        }

        /// <summary>
        /// Квадратность матрицы
        /// </summary>
        public bool IsSquareMatrix
        {
            get => isSquareMatrix;

            private set
            {
                isSquareMatrix = base.RowsCount == base.ColumnsCount;
            }
        }

        
        #endregion

        /// <summary>
        /// Создает матрицу с указанными размерами
        /// </summary>
        /// <param name="rows">Колличество строк в матрице</param>
        /// <param name="columns">Колличество столбцов матрице</param>
        public Matrix(int rows, int columns) : base(rows, columns)
        {
           

            IsSquareMatrix = RowsCount == ColumnsCount;

        }

        /// <summary>
        /// Создает матрицу на основе двумерного массива 
        /// </summary>
        /// <param name="array">Двумерный массив</param>
        public Matrix(T[,] array) : base(array.GetUpperBound(0) + 1, array.GetUpperBound(1) + 1)
        {
            matrix = array;

            IsSquareMatrix = RowsCount == ColumnsCount;

        }

        #region Операторы

        /// <summary>
        /// Суммирует две матрицы
        /// </summary>
        /// <param name="matrixA"></param>
        /// <param name="matrixB"></param>
        /// <returns>Сумма A и B</returns>
        public static Matrix<T> operator +(Matrix<T> matrixA, Matrix<T> matrixB)
        {
            if (matrixA.ColumnsCount == matrixB.ColumnsCount && matrixA.RowsCount == matrixB.RowsCount)
            {
                var matrixC = new Matrix<T>(matrixA.RowsCount, matrixB.ColumnsCount);


                Parallel.For(0, matrixA.RowsCount, row =>
                {
                    Parallel.For(0, matrixB.ColumnsCount, colunm =>
                    {
                        matrixC[row, colunm] = (T)(dynamic)matrixA[row, colunm] + (dynamic)matrixB[row, colunm];
                    });
                });
                return matrixC;
            }
            else
            {
                throw new MatrixDifferentSizeException();
            }
        }

        /// <summary>
        /// Разность матриц
        /// </summary>
        /// <param name="matrixA"></param>
        /// <param name="matrixB"></param>
        /// <returns>Разность матриц</returns>
        public static Matrix<T> operator - (Matrix<T> matrixA, Matrix<T> matrixB)
        {
            if (matrixA.ColumnsCount == matrixB.ColumnsCount && matrixA.RowsCount == matrixB.RowsCount)
            {
                var matrixC = new Matrix<T>(matrixA.RowsCount, matrixB.ColumnsCount);

                Parallel.For(0, matrixA.RowsCount, i =>
                {

                    Parallel.For(0, matrixB.ColumnsCount, j =>
                    {
                        matrixC[i, j] = (T)Operator.Subtract(matrixA[i, j], matrixB[i, j]);
                    });

                });

                return matrixC;
            }
            else
            {
                throw new MatrixDifferentSizeException();
            }

        }

        /// <summary>
        /// Умножает матрицу на число
        /// </summary>
        /// <param name="multiplier"></param>
        /// <param name="matrixA"></param>
        /// <returns>Умноженная на число матрица</returns>
        public static Matrix<T> operator *(T multiplier, Matrix<T> matrixA)
        {
            var matrixB = new Matrix<T>(matrixA.RowsCount, matrixA.ColumnsCount);

            Parallel.For(0, matrixA.RowsCount, row =>
            {
                Parallel.For(0, matrixA.ColumnsCount, column =>
                {
                    matrixB[row, column] = (T)Operator.Multiply(matrixA[row, column], multiplier);
                });

            });

            return matrixB;
        }

        /// <summary>
        /// Умножает матрицу на число
        /// </summary>
        /// <param name="matrixA"></param>
        /// <param name="multiplier"></param>
        /// <returns>Умноженная на число матрица</returns>
        public static Matrix<T> operator *(Matrix<T> matrixA, T multiplier)
        {
            return multiplier * matrixA;
        }

        /// <summary>
        /// Перемножает матрицы
        /// </summary>
        /// <param name="matrixA"></param>
        /// <param name="matrixB"></param>
        /// <returns></returns>
        public static Matrix<T> operator *(Matrix<T> matrixA, Matrix<T> matrixB)
        {
            if (matrixA.RowsCount == matrixB.ColumnsCount)
            {
                var matrixC = new Matrix<T>(matrixA.RowsCount, matrixB.ColumnsCount);

                Parallel.For(0, matrixA.RowsCount, row =>
                {
                    Parallel.For(0, matrixB.ColumnsCount, column =>
                    {
                        for (int k = 0; k < matrixB.RowsCount; k++)// A B или C ?
                        {
                            matrixC[row, column] = (T)Operator.Add(matrixC[row, column], Operator.Multiply(matrixA[row, k], matrixB[k, column]));
                        }
                    });
                });

                return matrixC;
            }
            else
            {
                throw new TheNumberOfRowsAndColumnsIsDifferentException();
            }


        }

        /// <summary>
        /// Явно приводит двумерный массив к <see cref="Matrix{T}"/>
        /// </summary>
        /// <param name="array">Приводимый массив</param>
        public static explicit operator Matrix<T>(T[,] array)
        {
            return new Matrix<T>(array);
        }

        /// <summary>
        /// Явно приводит <see cref="Matrix{T}"/> к двумерному массиву
        /// </summary>
        /// <param name="matrix">Приводимая матрица</param>
        public static explicit operator T[,](Matrix<T> matrix)
        {
            return matrix.matrix;
        }

        #endregion
        private async Task<int> FindRankAsync()
        {
            return await Task<int>.Run(FindRank);
        }

        /// <summary>
        /// Находит ранг мартицы
        /// </summary>
        /// <returns>Ранг матрицы</returns>
        public int FindRank()
        {
            int rank = 0;

            Parallel.ForEach(this.ToSteppedView()[VectorSelector.Rows], row =>
            {
                if (!row.IsZero())
                {
                    rank++;
                }
            });

            return rank;
        }

        /// <summary>
        /// Возводит матрицу в степень
        /// </summary>
        /// <param name="matrix">Матрица</param>
        /// <param name="power">Степень</param>
        /// <returns>Матрица в заданной степени</returns>
        public static Matrix<T> Pow(Matrix<T> matrix,int power)
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
        /// Транспонирует(меняет строки со столбцами) текущую матрицу и возвращает новую
        /// </summary>
        /// <returns>Транспонированная матрица</returns>
        public Matrix<T> Transponate()
        {
            var transposedMatrix = new Matrix<T>(this.ColumnsCount, this.RowsCount);

            Parallel.For(0, this.ColumnsCount, row =>
            {
                Parallel.For(0, this.RowsCount, column =>
                {
                    transposedMatrix[row, column] = this[column, row];
                });
            });

            return transposedMatrix;
        }

        /// <summary>
        /// Приводит матрицу к ступенчатому виду
        /// </summary>
        /// <returns><see cref="Matrix{T}"/> Матрица в ступенчатов виде</returns>
        public Matrix<T> ToSteppedView()
        {
            var steppedMatrix = this;

            steppedMatrix.ForEach((row, column) =>
            {

                for (int j = row + 1; j < steppedMatrix.RowsCount; j++)
                {

                    if (this[row, row] != (dynamic)0)
                    {

                        if (this[row, row] != (dynamic)0)
                        {
                            dynamic koeficient = (dynamic)(steppedMatrix[j, row] / (dynamic)this[row, row]);

                            for (int k = 0; k < steppedMatrix.ColumnsCount; k++)
                            {

                                steppedMatrix[j, k] -= steppedMatrix[row, k] * koeficient;

                            }
                        }
                    }
                }
            });


            return steppedMatrix;
        }

        ///<summary>
        /// Создает матрицу с вычеркнутыми столбцами на основе текущей
        /// </summary>
        /// <param name="column">Количество вычеркнутых столбцов</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Matrix<T> CreateMatrixWithoutColumn(int column)
        {
            if (column < 0 || column >= this.ColumnsCount)
            {
                throw new ArgumentException("invalid column index");
            }
            var result = new Matrix<T>(this.RowsCount, this.ColumnsCount - 1);
            result.ForEach((i, j) =>
                result[i, j] =
                j < column ? this[i,j] : this[i, j + 1]);
            return result;
        }

        /// <summary>
        /// Создает матрицу с вычеркнутыми строками на основе текущей
        /// </summary>
        /// <param name="row">Количество вычеркнутых строк</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Matrix<T> CreateMatrixWithoutRow(int row)
        {
            if (row < 0 || row >= this.RowsCount)
            {
                throw new ArgumentException("invalid row index");
            }
            var result = new Matrix<T>(this.RowsCount - 1, this.ColumnsCount);
            result.ForEach((i, j) =>
                result[i, j] =
                i < row ?
                this[i, j] : this[i + 1, j]);
            return result;
        }

        /// <summary>
        /// Расчитывает детерминант матрицы
        /// </summary>
        /// <returns>Детерминант матрицы</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T CalculateDeterminant()
        {
            dynamic result = 0;

            if (!double.IsNaN(this.precalculatedDeterminant))
            {
                return Operator.Convert<double, T>(this.precalculatedDeterminant);
            }

            if (!this.IsSquareMatrix)
            {
                throw new InvalidOperationException("determinant can be calculated only for square matrix");
            }

            if (this.RowsCount == 2)
            {
                return Operator.Subtract(Operator.Multiply(this[0, 0], this[1, 1]), Operator.Multiply(this[0, 1], this[1, 0]));
            }


            for (var j = 0; j < this.RowsCount; j++)
            {
                result += Operator.Multiply(Operator.Multiply((j % 2 == 1 ? (dynamic)1 : -(dynamic)1), this[1, j]),
                    this.CreateMatrixWithoutColumn(j).CreateMatrixWithoutRow(1).CalculateDeterminant());

            }

            return result;

        }

        /// <summary>
        /// Расчитывает детерминант матрицы асинхронно
        /// </summary>
        /// <returns>Детерминант матрицы</returns>
        public async Task<T> CalculateDeterminantAsync()
        {
           return await Task.Run(CalculateDeterminant);
        }

        #region Фичи

        
        /// <summary>
        /// Заполняет матрицу по порядку:от 1-го до размера последнего элемента матрицы
        /// </summary>
        /// <returns>Матрица заполненная по порядку</returns>
        public Matrix<T> FillInOrder()
        {
            Matrix<T> filledMatrix = new Matrix<T>(this.RowsCount, this.ColumnsCount);

            dynamic counter = 1;

            this.ForEach((row, column) => filledMatrix[row, column] = counter++);

            return filledMatrix;
        }

        /// <summary>
        /// Вывод матрицы в строковом представлении
        /// </summary>
        /// <returns>Строковое представление матрицы</returns>
        public override string ToString()
        {
            string outString = String.Empty;

            for(int row = 0;row < this.RowsCount; row++)
            {
                for(int column = 0;column < this.ColumnsCount; column++)
                {
                    outString += matrix[row, column].ToString().PadLeft(8) + " ";
                   
                }

                outString += "\n";
            };

            

            return outString;
        }


       
        #endregion

        
    }
}
