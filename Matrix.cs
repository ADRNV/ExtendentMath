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
    public class Matrix<T> : IEnumerator<T> where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T> 
    {
        #region Поля матрицы

        private T[,] matrix;

        private T[] _mainDiagonal;

        private int rowsCount;

        private int columnsCount;

        #endregion

        private bool disposedValue;

        private int _position;

        private int _position1;

        #region Свойства матрицы
        /// <summary>
        /// Массив из объектов составляющих матрицу
        /// </summary>
        /* TODO
         Диагональ не актульна после
         операций над матрицей([0,0,..n])
         нужно сделать обновление при изменении или вынести в
        отдельный метод
         */
        public T[] MainDiagonal
        {
            get
            {
                DiagonalChanged.Invoke();
                return _mainDiagonal;
            }

            private set
            {
                _mainDiagonal = value;
            }
        }

        /// <summary>
        /// Колличество строк в матрице
        /// </summary>
        public int RowsCount
        {

            get => rowsCount;
        }
        /// <summary>
        /// Колличество столбцов в матрице
        /// </summary>
        public int ColumnsCount
        {
            get => columnsCount;
        }

        /// <summary>
        /// Размер матрицы
        /// </summary>
        public int Size
        {
            get => matrix.Length;
        }

        #endregion

        #region IEnumerable
        public T Current
        {
            get
            {
                if (CheckPositionOut(_position, _position1))
                {
                    throw new IndexOutOfRangeException();
                }
                return matrix[_position, _position1];
            }
        }


        object IEnumerator.Current => this.Current;

        public IEnumerator<T> GetEnumerator()
        {
            foreach(var i in matrix)
            {
                yield return i;
            }
        }
        public bool MoveNext()
        {
            if (_position < matrix.GetUpperBound(0) + 1 && _position1 < matrix.Length / matrix.GetUpperBound(1) + 1)
            {
                _position++;
                _position1++;
                return true;
            }
            else
                return false;
        }

        public void Reset()
        {
            _position = -1;
            _position1 = -1;
        }

        #endregion


        /// <summary>
        /// Создает матрицу с указанными размерами
        /// </summary>
        /// <param name="rows">Колличество строк в матрице</param>
        /// <param name="columns">Колличество столбцов матрице</param>
        public Matrix(int rows, int columns)
        {
            rowsCount = rows;

            columnsCount = columns;

            matrix = new T[rowsCount, columns];

            DiagonalChanged = OnDiagonalChanged;

        }

        /// <summary>
        /// Находит диагональ матрицы
        /// </summary>
        /// <returns><code>T[] Array</code>Массив значений составляющих диагональ</returns>
        public T[] FindDiagonal()
        {
            List<T> mainDiagonal = new List<T>();

            Parallel.For(0, rowsCount, i => 
            {

                Parallel.For(0, columnsCount, j =>
                {
                   if (i == j)
                   {
                       mainDiagonal.Add(this[i, j]);
                   }

                });

            });
            
            return mainDiagonal.ToArray();
        }

        private event Action DiagonalChanged;

        private void OnDiagonalChanged()
        {
            MainDiagonal = FindDiagonal();
        }

        private int GetLenght()
        {
            return matrix.Length - 1;
        }


        #region Индексатор
        public T this[int index, int index1]
        {
            get
            {
                return matrix[index, index1];
            }

            set
            {
                matrix[index, index1] = value;
            }
        }

        #endregion

        private bool CheckPositionOut(int position, int position1)
        {
            if (position == -1 || position >= matrix.Length || position1 == -1 || position1 >= matrix.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        #region Matrix Sum

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

                for (var i = 0; i < matrixA.GetLength(0); i++)
                {
                    for (var j = 0; j < matrixB.GetLength(0); j++)
                    {
                        matrixC[i, j] = matrixA[i, j] + matrixB[i, j];
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

        #endregion

        public static double[,] SubstractionMatrix(ref double[,] matrixA, ref double[,] matrixB)
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
        /// <returns><code>Matrix<T></code></returns>
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
        /// <returns></returns>
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
            var matrixC = new Matrix<T>(matrixA.RowsCount, matrixB.ColumnsCount );

            Parallel.For(0,matrixA.RowsCount,row =>
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

                for (int i = 0; i < power; i++)
                {
                    matrixC = matrix * matrix;
                }
                return matrixC;
            }
            else
            {
                throw new TheNumberOfRowsAndColumnsIsDifferentException();
            }

        }
        /// <summary>
        /// Транспонирует текущую матрицу и возвращает новую
        /// </summary>
        /// <returns></returns>
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
        #region Фичи

        //public Matrix<T> FillMatrixRandom()
        //{
        //    Matrix<T> filledMatrix = new Matrix<T>(this.RowsCount,this.ColumnsCount);

        //    Random random = new Random(this.Size);

        //    for(int row = 0;row < this.RowsCount;row++)
        //    {
        //        for(int column = 0;column < this.ColumnsCount;column++)
        //        {
        //            filledMatrix[row, column] = random.Next(0, this.Size);
        //        }
        //    }

        //    return filledMatrix;
        //}

        /// <summary>
        /// Заполняет матрицу по порядку:от 1 до размера матрицы
        /// </summary>
        /// <returns>Матрица заполненная по порядку</returns>
        public Matrix<int> FillMatrixInOrder()
        {
            var filledMatrix = new Matrix<int>(this.RowsCount, this.ColumnsCount);

            int counter = 1;

            if (this.ColumnsCount != this.RowsCount)
            {
                Parallel.For(0, this.ColumnsCount, column =>
                {
                    Parallel.For(0, this.RowsCount, row =>
                    {
                        filledMatrix[column, row] = counter++;
                    });
                });
            }
            else
            {
                Parallel.For(0, this.ColumnsCount, column =>
                {
                    Parallel.For(0, this.RowsCount, row =>
                    {
                        filledMatrix[row, column] = counter++;
                    });
                });
            }
            return filledMatrix;

        }

        /// <summary>
        /// Применяет функцию ко всем элементам матрицы
        /// </summary>
        /// <param name="func">Делегат(Функтор) с одним параметром</param>
        public void ForEach(Func<T, T> func)
        {

            if (func != null)
            {
                Parallel.For(0, this.RowsCount, row =>
                {
                      Parallel.For(0, this.ColumnsCount, column =>
                      {
                           this[row, column] = func(this[row, column]);
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

            Parallel.For(0, this.rowsCount, row =>
            {
                Parallel.For(0, this.columnsCount, column =>
                {
                     outString += $" {this[row, column]} ";
                });

                outString += "\n";

            });

            return outString;

        }










        #endregion

        protected virtual void Dispose(bool disposing)
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

        // // TODO: переопределить метод завершения, только если "Dispose(bool disposing)" содержит код для освобождения неуправляемых ресурсов
        // ~Matrix()
        // {
        //     // Не изменяйте этот код. Разместите код очистки в методе "Dispose(bool disposing)".
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Не изменяйте этот код.  Разместите код очистки в методе "Dispose(bool disposing)".
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }




    }







}
