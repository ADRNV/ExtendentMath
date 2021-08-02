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
    public class Matrix<T> : IEnumerator<T> where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        #region Поля матрицы

        private T[,] matrix;

        private T[] _mainDiagonal;

        private int rowsCount;

        private int columnsCount;

        private bool isSquareMatrix;

        #endregion

        private bool disposedValue;

        private int _rowPosition = 0;

        private int _columnPosition = -1;



        #region Свойства матрицы
        /// <summary>
        /// Массив из объектов составляющих главную диагональ матрицы
        /// </summary>
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

        public T[][] Rows
        {
            get => GetRows();
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

        #region IEnumerable
        /// <summary>
        /// Текуший элемент
        /// </summary>
        public T Current
        {
            get
            {
                return matrix[_rowPosition, _columnPosition];
            }
        }

        object IEnumerator.Current => Current;



        /// <summary>
        /// Перечислитель
        /// </summary>
        /// <returns>Перечислитель матрицы</returns>
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var i in matrix)
            {

                yield return i;
            }
        }

        /// <summary>
        /// Перемещает индексатор на одну позицию вперед
        /// </summary>
        /// <returns>true или false в зависимости ли можно переместить индексатор</returns>
        public bool MoveNext()
        {

            if (_rowPosition < this.RowsCount)
            {
                if (_columnPosition < this.ColumnsCount - 1)
                {
                    _columnPosition++;
                }
                else
                {
                    if (_rowPosition < this.RowsCount - 1)
                    {
                        _rowPosition++;
                    }
                    else
                    {
                        return false;
                    }
                    _columnPosition = 0;
                }
                return true;
            }
            else
            {
                return false;
            }



        }

        /// <summary>
        /// Перемещает индексатор в начало матрицы
        /// </summary>
        public void Reset()
        {
            _rowPosition = 0;
            _columnPosition = -1;
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

            this.IsSquareMatrix = rows == columns;

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

        public T[][] GetRows()
        {
            T[][] rows = new T[rowsCount][];

            for(int ri = 0;ri < rowsCount;ri++)
            {
                rows[ri] = new T[columnsCount];
            }

            int rowsIterator = 0;
            for(int row = 0;row < rowsCount;row++)
            {
                for(int column = 0;column < columnsCount;column++)
                {
                    if(column++ == columnsCount)
                    {
                        rowsIterator++;
                    }
                    rows[rowsIterator][columnsCount - 1] = this[row, column];
                }
            }

            return rows;
        }

        #region Индексатор
        /// <summary>
        /// Число матрицы
        /// </summary>
        /// <param name="index">Строка</param>
        /// <param name="index1">Столбец</param>
        /// <returns></returns>
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

        #endregion

        #region Операторы

        /// <summary>
        /// Вычетает две матрицы и возвращает новую
        /// </summary>
        /// <param name="matrixA">Первая матрица</param>
        /// <param name="matrixB">Вторая матрица</param>
        /// <returns>Двумерный массив</returns>
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
        #region Требует оптимизации

        /// <summary>
        /// Создает матрицу с вычеркнутыми столбцами на основе текущей
        /// </summary>
        /// <param name="column">Количество вычеркнутых столбцов</param>
        /// <returns></returns>
        private Matrix<T> CreateMatrixWithoutColumn(int column)
        {
            if (column < 0 || column >= this.ColumnsCount)
            {
                throw new ArgumentException("invalid column index");
            }
            var result = new Matrix<T>(this.RowsCount, this.ColumnsCount - 1);
            result.ForEach((i, j) =>
                result[Operator.Convert<T,int>(i), Operator.Convert<T, int>(j)] = 
                Operator.Convert<T,int>(j) < column ? this[Operator.Convert<T, int>(i), 
                Operator.Convert<T, int>(j)] : this[Operator.Convert<T, int>(i), Operator.Convert<T,int>(j) + 1]);
            return result;
        }

        /// <summary>
        /// Создает матрицу с вычеркнутыми строками на основе текущей
        /// </summary>
        /// <param name="row">Количество вычеркнутых строк</param>
        /// <returns></returns>
        private Matrix<T> CreateMatrixWithoutRow(int row)
        {
            if (row < 0 || row >= this.RowsCount)
            {
                throw new ArgumentException("invalid row index");
            }
            var result = new Matrix<T>(this.RowsCount - 1, this.ColumnsCount);
            result.ForEach((i, j) =>
                result[Operator.Convert<T,int>(i), Operator.Convert<T,int>(j)] = 
                Operator.Convert<T,int>(i) < row ? 
                this[Operator.Convert<T,int>(i), Operator.Convert<T,int>(j)] : this[Operator.Convert<T,int>(i) + 1, Operator.Convert<T,int>(j)]);
            return result;
        }
        private double precalculatedDeterminant = double.NaN;
        
        /// <summary>
        /// Находит детерминант матрицы
        /// </summary>
        /// <returns>Число</returns>
        public T CalculateDeterminant()
        {
            if (!double.IsNaN(this.precalculatedDeterminant))
            {
                return Operator.Convert<double,T>(this.precalculatedDeterminant);
            }
            if (!this.IsSquareMatrix)
            {
                throw new InvalidOperationException("determinant can be calculated only for square matrix");
            }
            if (this.RowsCount == 2)
            {
                return Operator.Subtract(Operator.Multiply(this[0, 0],this[1, 1]),Operator.Multiply(this[0, 1],this[1, 0]));
            }
            dynamic result = 0;
            dynamic one = 1;
            for (var j = 0; j < this.RowsCount; j++)
            {
                result += Operator.Multiply(Operator.Multiply((j % 2 == 1 ? one : -one),this[1, j]),
                    this.CreateMatrixWithoutColumn(j).CreateMatrixWithoutRow(1).CalculateDeterminant());
            }
            
            return result;
        }
        #endregion

        /// <summary>
        /// Проверяет матрицу на вырожденность
        /// </summary>
        /// <param name="matrix">Мартрица</param>
        /// <returns>Логический тип.<code>false</code>-если матрица не вырожденная,<code>true</code>-если матрица
        /// вырожденная</returns>
        public static bool IsDegenerateMatrix(Matrix<T> matrix)
        {
            return Operator.Equal(matrix.CalculateDeterminant(),Operator.Convert<int,T>(0));
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
        public Matrix<int> FillMatrixInOrder()
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
        /// Применяет действие ко всем элементам матрицы
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
        /// Применяет действие ко всем элементам матрицы
        /// </summary>
        /// <param name="action">Делегат с двумя параметром</param>
        public void ForEach(Action<T,T> action)
        {

            if (action != null)
            {
                for(dynamic row = 0;row < this.RowsCount; row++)
                {
                    for(dynamic column = 0;column < this.ColumnsCount; column++) 
                    {
                        action(row,column);
                    }
                }
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
                     outString += $" {this[row, column]} ";
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

        /// <summary>
        /// Освобождает использованные ресурсы
        /// </summary>
        public void Dispose()
        {
            // Не изменяйте этот код.  Разместите код очистки в методе "Dispose(bool disposing)".
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }




    }







}
