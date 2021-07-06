using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using MathExtended.Exceptions;
using MiscUtil;

namespace MathExtended
{
    public class Matrix<T> : IEnumerator<T> where T: IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        #region Поля матрицы

        private T[,] matrix;

        private T[] _mainDiagonal;

        private int rowsCount;

        private int collumnsCount;

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
                _mainDiagonal = FindDiagonal();
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
        public int CollumnsCount
        {
            get => collumnsCount;
        }

        /// <summary>
        /// Размер матрицы
        /// </summary>
        public int Length
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
            foreach (var i in matrix)
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
        /// <param name="collumns">Колличество столбцов матрице</param>
        public Matrix(int rows, int collumns)
        {
            rowsCount = rows;

            collumnsCount = collumns;

            matrix = new T[rowsCount, collumns];

            MainDiagonal = FindDiagonal();

        }

        /// <summary>
        /// Находит диагональ матрицы
        /// </summary>
        /// <returns><code>T[] Array</code>Массив значений составляющих диагональ</returns>
        public T[] FindDiagonal()
        {
            List<T> mainDiagonal = new List<T>(); 

            for (int i = 0; i < rowsCount; i++) 
            {
                for (int j = 0; j < collumnsCount; j++)
                {
                    if (i == j)
                    {
                        mainDiagonal.Add(this[i, j]);
                    }

                }
            }
          
            return mainDiagonal.ToArray();
        }

        private int GetLenght(T[,] matrix)
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
        public static Matrix<T> operator + (Matrix<T> matrixA, Matrix<T> matrixB)
        {
            if (matrixA.CollumnsCount == matrixB.CollumnsCount && matrixA.RowsCount == matrixB.RowsCount)
            {
                var matrixC = new Matrix<T>(matrixA.RowsCount, matrixB.CollumnsCount);


                for (var i = 0; i < matrixA.RowsCount; i++)
                {
                    for (var j = 0; j < matrixB.CollumnsCount; j++)
                    {
                        matrixC[i, j] = Operator.Add(matrixA[i, j], matrixB[i, j]);
                    }
                }
                return matrixC;
            }
            else
            {
                throw new MatrixDifferentSizeException();
            }


        }



        #endregion



        /// <summary>
        /// Умножает матрицу на число
        /// </summary>
        /// <param name="multiplier"></param>
        /// <param name="matrixA"></param>
        /// <returns></returns>
        public static Matrix<T> operator * (T multiplier, Matrix<T> matrixA)
        {
            var matrixB = new Matrix<T>(matrixA.RowsCount, matrixA.CollumnsCount);

            for (int row = 0; row < matrixA.RowsCount; row++)
            {
                for (int collumn = 0; collumn < matrixA.CollumnsCount; collumn++)
                {
                    matrixB[row, collumn] = Operator.Multiply(matrixA[row,collumn],multiplier);
                }
            }
            return matrixB;
        }
        /// <summary>
        /// Разность матриц
        /// </summary>
        /// <param name="matrixA"></param>
        /// <param name="matrixB"></param>
        /// <returns><code>Matrix<T></code></returns>
        public static Matrix<T> operator - (Matrix<T> matrixA, Matrix<T> matrixB)
        {
            if (matrixA.CollumnsCount == matrixB.CollumnsCount && matrixA.RowsCount == matrixB.RowsCount)
            {
                var matrixC = new Matrix<T>(matrixA.RowsCount, matrixB.CollumnsCount);


                for (var i = 0; i < matrixA.RowsCount; i++)
                {
                    for (var j = 0; j < matrixB.CollumnsCount; j++)
                    {
                        matrixC[i, j] = Operator.Subtract(matrixA[i, j], matrixB[i, j]);
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
        /// Преобразует матрицу в двумерный массив
        /// </summary>
        /// <returns><code>T[,] matrix</code></returns>
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

            for (int row = 0;row < this.rowsCount;row++)
            {
                for(int collumn = 0;collumn < this.collumnsCount;collumn++)
                {
                    outString += $" {this[row,collumn]} ";
                }

                outString += "\n";
                
            }

            return outString;

        }

        

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    matrix = null;
                    MainDiagonal = null;

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
            // Не изменяйте этот код. Разместите код очистки в методе "Dispose(bool disposing)".
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

       


    }


   




}
