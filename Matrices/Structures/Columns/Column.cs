using MathExtended.Exceptions;
using MathExtended.Matrices.Structures.CellsCollection;
using MathExtended.Matrices.Structures.Rows;
using MiscUtil;
using System;

namespace MathExtended.Matrices.Structures.Columns
{
    /// <summary>
    /// Описывает столбец матрицы
    /// </summary>
    /// <typeparam name="T">Тип содержимого строки</typeparam>
    public class Column<T> : BaseCellsCollection<T> where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {

        /// <summary>
        /// Создает столбец с указанными размерами
        /// </summary>
        /// <param name="height"></param>
        public Column(int height) : base(height) { }
        /// <summary>
        /// Создает столбец на основе массива
        /// </summary>
        /// <param name="array"></param>
        public Column(T[] array) : base(array) { }

        /// <summary>
        /// Не явным образом приводит масив к столбцу
        /// </summary>
        /// <param name="array">Приводимый массив</param>
        public static implicit operator Column<T>(T[] array)
        {
            return new Column<T>(array);
        }

        /// <summary>
        /// Умножает число на столбец
        /// </summary>
        /// <param name="multiplier">Множитель</param>
        /// <param name="column">Столбец</param>
        /// <returns>Умноженый столбец</returns>
        public static Column<T> operator *(T multiplier, Column<T> column)
        {
            Column<T> multipliedColumn = new Column<T>(column.Size);

            int i = 0;

            column.ForEach((cell) => multipliedColumn[i++] = Operator.Multiply(cell, multiplier));

            return multipliedColumn;
        }

        /// <summary>
        /// Умножает число на столбец
        /// </summary>
        /// <param name="multiplier">Множитель</param>
        /// <param name="column">Столбец</param>
        /// <returns>Умноженный столбец</returns>
        public static Column<T> operator *(Column<T> column, T multiplier)
        {
            Column<T> multipliedColumn = new Column<T>(column.Size);

            int i = 0;

            column.ForEach((cell) => multipliedColumn[i++] = Operator.Multiply(cell, multiplier));

            return multipliedColumn;
        }

        /// <summary>
        /// Складывает столбцы
        /// </summary>
        /// <param name="columnA">Первый столбец</param>
        /// <param name="columnB">Второй столбец</param>
        /// <returns>Сумма двух столбцов</returns>
        public static Column<T> operator +(Column<T> columnA, Column<T> columnB)
        {
            if (columnA.Size == columnB.Size)
            {
                Column<T> summedColumn = new Column<T>(columnA.Size);

                int i = 0;

                summedColumn.ForEach((cell) => summedColumn[i++] = Operator.Add(columnA[i++], columnB[i++]));

                return summedColumn;
            }
            else
            {
                throw new ColumnsOfDifferentSizesException();
            }
        }

        /// <summary>
        /// Вычетает столбцы
        /// </summary>
        /// <param name="columnA">Первый столбец</param>
        /// <param name="columnB">Второй столбец </param>
        /// <returns>Разность двух столбцов</returns>
        public static Column<T> operator -(Column<T> columnA, Column<T> columnB)
        {
            if (columnA.Size == columnB.Size)
            {
                Column<T> summedColumn = new Column<T>(columnA.Size);

                int i = 0;

                summedColumn.ForEach((cell) => summedColumn[i++] = Operator.Subtract(columnA[i++], columnB[i++]));

                return summedColumn;
            }
            else
            {
                throw new ColumnsOfDifferentSizesException();
            }
        }

        /// <summary>
        /// Умножает столбец на строку
        /// </summary>
        /// <param name="column">Столбец</param>
        /// <param name="row">Строка</param>
        /// <returns><see cref="Matrix{T}"/> результат умножения</returns>
        public static Matrix<T> operator *(Column<T> column, Row<T> row)
        {
            if (column.Size != row.Size)
            {
                throw new VectorsDifferentSizeException();
            }
            else
            {
                Matrix<T> matrix = new Matrix<T>(row.Size, column.Size);

                for (int i = 0; i < row.Size; i++)
                {
                    for (int j = 0; j < column.Size; j++)
                    {
                        matrix[i, j] = (T)Operator.Multiply(row[j], column[i]);
                    }
                }

                return matrix;
            }
        }


        /// <summary>
        /// Явно приводит <see cref="ReadOnlyColumn{T}"/> к <see cref="Column{T}"/>
        /// Делая пригодным для записи
        /// </summary>
        /// <param name="readOnlyColumn">Приводимый столбец</param>
        public static explicit operator Column<T>(ReadOnlyColumn<T> readOnlyColumn)
        {
            Column<T> column = new Column<T>(readOnlyColumn.Size);

            int i = 0;

            readOnlyColumn.ForEach((cell) =>
            {
                column[i] = cell;
            });

            return column;
        }

        /// <summary>
        /// Явно приводит <see cref="Column{T}"/> к <see cref="ReadOnlyColumn{T}"/>
        /// Делая пригодным для записи
        /// </summary>
        /// <param name="column">Привидимый столбец</param>
        public static explicit operator ReadOnlyColumn<T>(Column<T> column)
        {
            ReadOnlyColumn<T> readOnlyColumn = new ReadOnlyColumn<T>(column.Cells);

            return readOnlyColumn;
        }

        /// <summary>
        /// Транспонирует столбец
        /// </summary>
        /// <returns><see cref="Row{T}"/> Строка</returns>
        public Row<T> Transponate()
        {
            return new Row<T>(Cells);
        }


    }
}
