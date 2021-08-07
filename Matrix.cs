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

namespace MathExtended
{
    /// <summary>
    /// Описывает основную логику матриц
    /// </summary>
    /// <typeparam name="T">Числовой тип</typeparam>
    public class Matrix<T>:BaseMatrix<T> where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        #region Поля матрицы

        private int rowsCount;

        private int columnsCount;

        private bool isSquareMatrix;

        #endregion

        private bool disposedValue;

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
                isSquareMatrix = rowsCount == columnsCount;
            }
        }
        #endregion

        /// <summary>
        /// Создает матрицу с указанными размерами
        /// </summary>
        /// <param name="rows">Колличество строк в матрице</param>
        /// <param name="columns">Колличество столбцов матрице</param>
        public Matrix(int rows, int columns):base(rows,columns)
        {
            rowsCount = rows;

            columnsCount = columns;

            matrix = new T[rowsCount, columns];

            IsSquareMatrix = RowsCount == ColumnsCount;

            DiagonalChanged = OnDiagonalChanged;

        }

        /// <summary>
        /// Создает матрицу на основе двумерного массива 
        /// </summary>
        /// <param name="array">Двумерный массив</param>
        public Matrix(T[,] array) : base(array.GetUpperBound(0) + 1,array.GetUpperBound(1) + 1)
        {
            
            matrix = array;

            IsSquareMatrix = RowsCount == ColumnsCount;

            DiagonalChanged = OnDiagonalChanged;

        }


        private event Action DiagonalChanged;

        private void OnDiagonalChanged()
        {
            MainDiagonal = FindDiagonal();
        }

        #region Операторы

        /// <summary>
        /// Суммирует две матрицы и возвращает 3-ю
        /// </summary>
        /// <param name="matrixA"></param>
        /// <param name="matrixB"></param>
        /// <returns><code>double[,]</code>Сумма A и B</returns>
        public static double[,] SumMatrix(double[,] matrixA, double[,] matrixB)
        {

            if (matrixA.Length == matrixB.Length)
            {
                var matrixC = new double[matrixA.GetLength(0), matrixB.GetLength(0)];

                for (var row = 0; row < matrixA.GetLength(0); row++)
                {
                    for (var column = 0; column < matrixB.GetLength(0); column++)
                    {
                        matrixC[row, column] = matrixA[row, column] + matrixB[row, column];
                    }
                }

                return matrixC;
            }
            else
            {
                throw new MatrixDifferentSizeException();
            }
        }

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
                         matrixC[row, colunm] = Operator.Add(matrixA[row, colunm], matrixB[row, colunm]);
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
        /// Вычетает два двумерных массива и возвращает 3-й
        /// </summary>
        /// <param name="matrixA">Матрица A</param>
        /// <param name="matrixB">Матрица B</param>
        /// <returns>Разность матриц представленных в виде двумерных массивов</returns>
        public static double[,] SubstractMatrix(ref double[,] matrixA, ref double[,] matrixB)
        {

            if (matrixA.Length == matrixB.Length)
            {
                var matrixC = new double[matrixA.GetLength(0), matrixB.GetLength(0)];

                for (var i = 0; i < matrixA.GetLength(0); i++)
                {
                    for (var j = 0; j < matrixB.GetLength(0); j++)
                    {
                        matrixC[i, j] = matrixA[i, j] - matrixB[i, j];
                    }
                }

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
        public static Matrix<T> operator -(Matrix<T> matrixA, Matrix<T> matrixB)
        {
            if (matrixA.ColumnsCount == matrixB.ColumnsCount && matrixA.RowsCount == matrixB.RowsCount)
            {
                var matrixC = new Matrix<T>(matrixA.RowsCount, matrixB.ColumnsCount);

                Parallel.For(0, matrixA.RowsCount, i =>
                {
                
                    Parallel.For(0, matrixB.ColumnsCount, j =>
                    {
                            matrixC[i, j] = Operator.Subtract(matrixA[i, j], matrixB[i, j]);
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
        public static Matrix<T> operator *(T multiplier,Matrix<T> matrixA)
        {
            var matrixB = new Matrix<T>(matrixA.RowsCount, matrixA.ColumnsCount);

            Parallel.For(0, matrixA.RowsCount, row =>
            {
            
                Parallel.For(0, matrixA.ColumnsCount, column =>
                {
                     matrixB[row, column] = Operator.Multiply(matrixA[row, column], multiplier);
                });
            
            });
            
            return matrixB;
        }
        /// <summary>
        /// Перемножает матрицы
        /// </summary>
        /// <param name="matrixA"></param>
        /// <param name="matrixB"></param>
        /// <returns></returns>
        public static Matrix<T> operator *(Matrix<T> matrixA,Matrix<T> matrixB)
        {
            if(matrixA.RowsCount == matrixB.ColumnsCount)
            {
                var matrixC = new Matrix<T>(matrixA.RowsCount, matrixB.ColumnsCount);

                Parallel.For(0, matrixA.RowsCount, row =>
                {
                      Parallel.For(0, matrixB.ColumnsCount, column =>
                      {
                            for (int k = 0; k < matrixB.RowsCount; k++)// A B или C ?
                            {
                                matrixC[row, column] = Operator.Add(matrixC[row, column], Operator.Multiply(matrixA[row, k], matrixB[k, column]));
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


        #endregion


        /// <summary>
        /// Возводит матрицу в степень
        /// </summary>
        /// <param name="matrix">Матрица</param>
        /// <param name="power">Степень</param>
        /// <returns></returns>
        public static Matrix<T> Pow(Matrix<T> matrix, int power)
        {
           
            if (matrix != null && matrix.ColumnsCount == matrix.RowsCount)
            {
                var matrixC = matrix;

                for (int i = 1;i < power; i++)
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
        public Matrix<T> TransponateMatrix()
        {
            var transposedMatrix = new Matrix<T>(this.ColumnsCount,this.RowsCount);

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
        /// <returns><see cref="Matrix{T}"/>.Матрица в ступенчатов виде</returns>
        public Matrix<T> ConvertToStepped()
        {
            var steppedMatrix = this;

            if (IsSquareMatrix)
            {
                for (int i = 0; i < RowsCount; i++)
                {
                    for (int j = i + 1; j < ColumnsCount; j++)
                    {
                        dynamic koef = Operator.Divide(steppedMatrix[j, i], steppedMatrix[i, i]);
                        for (int k = i; k < RowsCount; k++)
                            steppedMatrix[j, k] -= steppedMatrix[i, k] * koef;
                    }
                }
            }
            else
            {
                throw new TheNumberOfRowsAndColumnsIsDifferentException();
            }
            return steppedMatrix;
        }
        #region Фичи

        /// <summary>
        /// Заполняет матрицу случайными значениями
        /// </summary>
        /// <returns>Матрмца со случайными значениями</returns>
        public dynamic FillMatrixRandom()
        {
#warning Небезопасность типов 
            dynamic filledMatrix = new Matrix<T>(this.RowsCount,this.ColumnsCount);

            Random random = new Random();

            for(int row = 0;row < this.RowsCount;row++)
            {
                for(int column = 0;column < this.ColumnsCount;column++)
                {
                    filledMatrix[row, column] = random.Next();
                }
            }

            return filledMatrix;
        }

        /// <summary>
        /// Заполняет матрицу случайными значениями в определенном диапазоне
        /// </summary>
        /// <param name="min">Минимальное число</param>
        /// <param name="max">Максимальное число</param>
        /// <returns></returns>
        public dynamic FillMatrixRandom(T min,T max)
        {
            dynamic filledMatrix = new Matrix<T>(this.RowsCount, this.ColumnsCount);

            dynamic random = new Random();

            for (int row = 0; row < this.RowsCount; row++)
            {
                for (int column = 0; column < this.ColumnsCount; column++)
                {
                    filledMatrix[row, column] = random.Next(min,max);
                }
            }

            return filledMatrix;
        }

        /// <summary>
        /// Заполняет матрицу по порядку:от 1 до размера матрицы
        /// </summary>
        /// <returns>Матрица заполненная по порядку</returns>
        public Matrix<int> FillMatrixInOrder()//Проблема с заполнением кв кадратных матриц
        {
            var filledMatrix = new Matrix<int>(this.RowsCount, this.ColumnsCount);

            int counter = 1;
#warning медленное выполениние при больших размерах
            for(int row = 0;row < this.RowsCount;row++)
            {
                for (int column = 0; column < this.ColumnsCount; column++)
                {
                    filledMatrix[row, column] = counter++;
                }
            }
               
          
           return filledMatrix;
        }

        /// <summary>
        /// Применяет функцию ко всем элементам матрицы
        /// </summary>
        /// <param name="action">Делегат с одним параметром</param>
        public void ForEach(Action<T> action)
        {

            if (action != null)
            {
                Parallel.For(0, this.RowsCount, row =>
                {
                      Parallel.For(0, this.ColumnsCount, column =>
                      {
                           action(this[row, column]);
                      });
                });
            }
            else
            {
                throw new ArgumentNullException();
            }

        }

        /// <summary>
        /// Преобразует матрицу в двумерный массив
        /// </summary>
        /// <returns>Двумерный массив</returns>
        public T[,] ToArray()
        {
            return matrix;
        }

        /// <summary>
        /// Вывод всей матрицы 
        /// </summary>
        /// <returns></returns>
        public string OutString()
        {
            string outString = String.Empty;

            for(int row = 0;row < this.rowsCount; row++)
            {
                for(int column = 0;column < this.columnsCount; column++)
                {
                    outString += matrix[row, column].ToString().PadLeft(8) + " ";
                   
                }

                outString += "\n";

            }

            return outString;
        }










        #endregion

        /// <summary>
        /// Высвобождает использованные ресурсы
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {

                    MainDiagonal = null;
                    matrix = null;


                }

                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить метод завершения
                // TODO: установить значение NULL для больших полей
                disposedValue = true;
            }
        }
    }
}
