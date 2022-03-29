using MathExtended.Exceptions;
using MathExtended.Interfaces;
using MathExtended.Matrices.Extensions;
using MathExtended.Matrices.Structures.CellsCollection;
using MathExtended.Matrices.Structures.CellsCollections;
using MathExtended.Matrices.Structures.Columns;
using MathExtended.Matrices.Structures.Rows;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MathExtended.Matrices
{
    /// <summary>
    /// Базовый класс матрицы.Реализует интерфейс перечисления
    /// и ограничивает принимаемые обобщения до числовых типов (<see cref="int"></see>, <see cref="float"></see>, <see cref="double"></see> и т.д)
    /// </summary>
    /// <typeparam name="T">Числовой тип</typeparam>
    public abstract class BaseMatrix<T> : IEnumerable<T>, IEnumerator<T>, IMatrix<T> where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        /// <summary>
        /// Матрица представляющая собой двумерный массив
        /// </summary>
        protected T[][] matrix;

        private Row<T>[] _rows;

        private Column<T>[] _columns;

        private int _rowsCount;

        private int _columnsCount;

        /// <summary>
        /// Главная диагональ
        /// </summary>
        protected MainDiagonal<T> _mainDiagonal;

        private int _rowPosition = 0;

        private int _columnPosition = -1;

        private bool disposedValue;


        /// <summary>
        /// Создает матрицу с указанными размерами
        /// </summary>
        /// <param name="rows">Количество строк</param>
        /// <param name="columns">Количество столбцов</param>
        public BaseMatrix(int rows, int columns)
        {
            if (!(rows <= 0) && !(columns <= 0))
            {
                _rowsCount = rows;

                _columnsCount = columns;

                InitRows();

                
            }
            else
            {
                throw new MatrixInvalidSizesException();
            }
        }

        /// <summary>
        /// Число матрицы
        /// </summary>
        /// <param name="row">Строка</param>
        /// <param name="column">Столбец</param>
        /// <returns>Число по указанному адресу в матрице</returns>
        public T this[int row, int column]
        {
            get => matrix[row][column];

            set
            {
                matrix[row][column] = value;
            }

        }

        public T[] this[int row]
        {
            get => matrix[row];

            set
            {
                matrix[row] = value;
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
        public MainDiagonal<T> MainDiagonal
        {
            get
            {
                _mainDiagonal = this.FindDiagonal();
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
        protected virtual BaseReadOnlyCellsCollection<T> this[VectorSelector selector, int index]
        {
            get
            {
                if (selector == VectorSelector.Rows)
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

        private void InitRows()
        {
            matrix = new T[RowsCount][];

            for(int row = 0;row < RowsCount;row++)
            {
                matrix[row] = new T[ColumnsCount];
            }
        }

        /// <summary>
        /// Возвращает строку матрицы соответсвующую индексу
        /// </summary>
        /// <param name="rowIndex">Индекс строки</param>
        /// <returns><see cref="Row{T}"/> строка матрицы</returns>
        public Row<T> GetRow(int rowIndex)
        {
            if (rowIndex < RowsCount)
            {
                var fullRow = new List<T>();

                for (int column = 0; column < ColumnsCount; column++)
                {
                    fullRow.Add(this[rowIndex, column]);
                }


                return new Row<T>(fullRow.ToArray());
            }
            else
            {
                throw new IndexOutOfRangeException();
            }


        }

        /// <summary>
        /// Возвращает все строки матрицы
        /// </summary>
        /// <returns>Массив из <see cref="Row{T}"/></returns>
        public Row<T>[] GetRows()
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
            if (index <= row.Size)
            {

                ForEach((r, c) => this[index, c] = row[c]);

            }
            else
            {
                throw new IndexOutOfRangeException();
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

        /// <summary>
        /// Возвращает столбец матрицы по индексу
        /// </summary>
        /// <param name="columnIndex">Индекс столбца</param>
        /// <returns><see cref="Column{T}"/></returns>
        public Column<T> GetColumn(int columnIndex)
        {
            if (columnIndex < ColumnsCount)
            {
                var fullColumn = new List<T>();

                for (int column = 0; column < RowsCount; column++)
                {
                    fullColumn.Add(this[column, columnIndex]);
                }

                return (Column<T>)fullColumn.ToArray();
            }
            else
            {
                throw new IndexOutOfRangeException($"Index {columnIndex} out of the bounds matrix");
            }

        }

        /// <summary>
        /// Возвращает все столбцы матрицы
        /// </summary>
        /// <returns>Массив <see cref="Column{T}"/></returns>
        public Column<T>[] GetColumns()
        {
            Column<T>[] columns = new Column<T>[ColumnsCount];

            ForEach((row, column) => columns[column] = GetColumn(column));

            return columns;
        }

        /// <summary>
        /// Задает столбец матрицы по индексу
        /// </summary>
        /// <param name="columnIndex">Индекс столбца</param>
        /// <param name="column">Стобец</param>
        public void SetColumn(int columnIndex, Column<T> column)
        {
            if (columnIndex <= this.RowsCount - 1)
            {
                ForEach((r, c) => this[r, columnIndex] = column[r]);

            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }


        /// <summary>
        /// Задает столбцы матрицы
        /// </summary>
        /// <param name="columns">Столбцы</param>
        public void SetColumns(Column<T>[] columns)
        {
            ForEach((row, column) => SetColumn(row, columns[row]));
        }

        /// <summary>
        /// Применяет функцию ко всем элементам матрицы
        /// </summary>
        /// <param name="action">Делегат с одним параметром</param>
        protected private void ForEach(Action<int, int> action)
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
        /// Преобразует матрицу в двумерный массив
        /// </summary>
        /// <returns>Двумерный массив</returns>
        public static explicit operator T[][](BaseMatrix<T> matrix)
        {
            return matrix.matrix;
        }



        #region IEnumerable
        /// <summary>
        /// Текуший элемент
        /// </summary>
        public T Current
        {
            get
            {
                return matrix[_rowPosition][_columnPosition];
            }
        }

        object IEnumerator.Current => Current;



        /// <summary>
        /// Перечислитель
        /// </summary>
        /// <returns>Перечислитель матрицы</returns>
        public IEnumerator<T> GetEnumerator()
        {
            foreach(T[] row in matrix)
            {
                foreach(T cell in row)
                {
                    yield return cell;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
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
