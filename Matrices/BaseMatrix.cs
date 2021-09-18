using MathExtended.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MathExtended.Matrices.Structures.Columns;
using MathExtended.Matrices.Structures.Rows;
using MathExtended.Matrices.Structures.CellsCollections;
using MathExtended.Matrices.Structures.CellsCollection;

namespace MathExtended.Matrices
{
    /// <summary>
    /// Базовый класс матрицы.Реализует интерфейс перечисления
    /// и ограничивает принимаемые обобщения до числовых типов (<see cref="int"></see>, <see cref="float"></see>, <see cref="double"></see> и т.д)
    /// </summary>
    /// <typeparam name="T">Числовой тип</typeparam>
    public abstract class BaseMatrix<T> : IEnumerator<T>, IMatrix<T> where T: IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        /// <summary>
        /// Матрица представляющая собой двумерный массив
        /// </summary>
        protected T[,] matrix;

        private Row<T>[] _rows;

        private Column<T>[] _columns;

        private int _rowsCount;

        private int _columnsCount;

        /// <summary>
        /// Главная диагональ
        /// </summary>
        protected T[] _mainDiagonal;

        private int _rowPosition = 0;

        private int _columnPosition = -1;

        private bool disposedValue;

        /// <summary>
        /// Создает матрицу с указанными размерами
        /// </summary>
        /// <param name="rows">Количество строк</param>
        /// <param name="columns">Количество столбцов</param>
        public BaseMatrix(int rows,int columns)
        {
            _rowsCount = rows;

            _columnsCount = columns;

            matrix = new T[rows,columns];

            _rows = GetRows();

            _columns = GetColumns();
            
        }

        /// <summary>
        /// Число матрицы
        /// </summary>
        /// <param name="row">Строка</param>
        /// <param name="column">Столбец</param>
        /// <returns>Число по указанному адресу в матрице</returns>
        public T this[int row, int column]
        {
            get => matrix[row, column];

            set
            {
                matrix[row, column] = value;
            }

        }

        /// <summary>
        /// Колличество строк в матрице
        /// </summary>
        public int RowsCount
        {
            get => _rowsCount;
        }

        /// <summary>
        /// Колличество столбцов в матрице
        /// </summary>
        public int ColumnsCount
        {
            get => _columnsCount;
        }

        /// <summary>
        /// Главная диагональ
        /// </summary>
        public T[] MainDiagonal
        {
            get
            {
                _mainDiagonal = FindDiagonal();
                return _mainDiagonal;
            }

            protected set
            {
                _mainDiagonal = value;
            }
        }

        /// <summary>
        /// Возвращает столбец или строку в
        /// зависимости от селектора
        /// </summary>
        /// <param name="selector">Селектор векторов</param>
        /// <param name="index">Индекс вектора</param>
        /// <returns>Вектор или строка по индексу</returns>
        public virtual BaseReadOnlyCellsCollection<T> this[VectorSelector selector, int index]
        {
            get
            {
                if(selector == VectorSelector.Rows)
                {
                    return (ReadOnlyRow<T>)_rows[index];
                }
                else
                {
                    return (ReadOnlyColumn<T>)_columns[index];
                }
            }

        }

        /// <summary>
        /// Возвращает стоки или столбцы в зависимости от селектора
        /// </summary>
        /// <param name="selector">Селектор</param>
        /// <returns>Массив строк или столбцов</returns>
        public virtual BaseCellsCollection<T>[] this[VectorSelector selector]
        {
            get
            {
                if (selector == VectorSelector.Rows)
                {
                    return _rows;
                }
                else
                {
                    return _columns;
                }
            }

        }

        private Row<T> GetRow(int rowIndex)
        {
            var fullRow = new Row<T>(RowsCount);

            for (int row = 0; row < ColumnsCount; row++)
            {
                fullRow[row] = this[rowIndex, row];
            }

            return fullRow;
        }

        private Row<T>[] GetRows()
        {
            Row<T>[] rows = new Row<T>[RowsCount];

            for (int row = 0; row < RowsCount; row++)
            {
                rows[row] = GetRow(row);
            }

            return rows;
        }

        /// <summary>
        /// Задает строку матрицы по заданному индексу
        /// </summary>
        /// <param name="row">Строка</param>
        /// <param name="index">Индекс строки</param>
        public void SetRow(Row<T> row, int index)
        {
  
           for (int column = 0; column < this.ColumnsCount; column++)
           {
               this[index, column] = row[column];
           }
            
        }

        /// <summary>
        /// Задает строки матрицы
        /// </summary>
        /// <param name="rows">Строки</param>
        public void SetRows(Row<T>[] rows)
        {
            ForEach((row, column) =>
            {
                if (row <= rows.Length - 1)
                {
                    this[row, column] = rows[row][column];
                }
            });
        }

        private Column<T> GetColumn(int columnIndex)
        {
            var fullColumn = new List<T>();

            for (int row = 0; row < RowsCount; row++)
            {
               fullColumn.Add(this[row, columnIndex]);
            }

            return fullColumn.ToArray();
        }

        private Column<T>[] GetColumns()
        {
            Column<T>[] columns = new Column<T>[ColumnsCount];

            ForEach((row, column) => columns[row] = GetColumn(column));

            return columns;
        }

        /// <summary>
        /// Задает столбец матрицы по индексу
        /// </summary>
        /// <param name="columnIndex">Индекс столбца</param>
        /// <param name="column">Стобец</param>
        public void SetColumn(int columnIndex,Column<T> column)
        {
            if (columnIndex <= this.RowsCount)
            {
                for (int row = 0; row < this.ColumnsCount; row++)
                {
                    this[row, columnIndex] = column[row];
                }
            }
        }
        /// <summary>
        /// Задает столбцы матрицы
        /// </summary>
        /// <param name="columns">Столбцы</param>
        public void SetColumns(Column<T>[] columns)
        {
            ForEach((row, column) => SetColumn(row,columns[row]));
        }

        /// <summary>
        /// Применяет функцию ко всем элементам матрицы
        /// </summary>
        /// <param name="action">Делегат с одним параметром</param>
        private void ForEach(Action<int, int> action)
        {

            if (action == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                Parallel.For(0, this.RowsCount, row =>
                {
                    for (dynamic column = 0; column < this.ColumnsCount; column++)
                    {
                        action(row, column);
                    }
                });
            }

        }


        /// <summary>
        /// Находит главную диагональ матрицы
        /// </summary>
        /// <returns>Массив состоящий из чисел составляющих главную диагональ</returns>
        public T[] FindDiagonal()
        {
            List<T> mainDiagonal = new List<T>();

            ForEach((row, column) =>
            {
                if (row == column)
                {
                    mainDiagonal.Add(this[row, column]);
                }

            });

            return mainDiagonal.ToArray();
        }

        /// <summary>
        /// Преобразует матрицу в двумерный массив
        /// </summary>
        /// <returns>Двумерный массив</returns>
        public virtual T[,] ToArray()
        {
            return matrix;
        }

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

        /// <summary>
        /// Освобождает использованные ресурсы
        /// </summary>
        public void Dispose()
        {
            // Не изменяйте этот код.  Разместите код очистки в методе "Dispose(bool disposing)".
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
