﻿using MiscUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathExtended.Exceptions;
using MathExtended.Matrices.Structures.CellsCollection;
using MathExtended.Matrices.Structures.Columns;
using MathExtended.Matrices.Structures.Rows;

namespace MathExtended.Matrices.Structures.Rows
{
    /// <summary>
    /// Описывает строку
    /// </summary>
    /// <typeparam name="T">Тип содержимого строки</typeparam>
    public class Row<T> : BaseCellsCollection<T> where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
      
        /// <summary>
        /// Создает строку с указанным размером
        /// </summary>
        /// <param name="length"></param>
        public Row(int length) : base(length)
        {

        }

        /// <summary>
        /// Создает строку на основе массива
        /// </summary>
        /// <param name="array"></param>
        public Row(T[] array) : base(array) { }

        /// <summary>
        /// Не явным образом приводит массив к строке
        /// </summary>
        /// <param name="array"></param>
        public static implicit operator Row<T>(T[] array)
        {
            return new Row<T>(array);
        }

        /// <summary>
        /// Умножает число на строку
        /// </summary>
        /// <param name="multiplier">Множитель</param>
        /// <param name="row">Строка</param>
        /// <returns>Умноженная строка</returns>
        public static Row<T> operator * (T multiplier, Row<T> row)
        {
            Row<T> multipliedRow = new Row<T>(row.Size);

            int i = 0;

            row.ForEach((cell) => multipliedRow[i++] = (T)Operator.Multiply(cell, multiplier));

            return multipliedRow;
        }

        /// <summary>
        /// Складывает строки
        /// </summary>
        /// <param name="rowA">Первая строка</param>
        /// <param name="rowB">Вторая строка</param>
        /// <returns>Сумма двух строк</returns>
        public static Row<T> operator + (Row<T> rowA, Row<T> rowB)
        {
            if (rowA.Size == rowB.Size)
            {
                Row<T> summedRow = new Row<T>(rowA.Size);

                int i = 0;

                summedRow.ForEach((cell) =>
                {
                    summedRow[i++] = (T)Operator.Add(rowA[i++], rowB[i++]);
                });

                return summedRow;
            }
            else
            {
                throw new RowsOfDifferentSizesException();
            }
        }

        /// <summary>
        /// Вычетает строки
        /// </summary>
        /// <param name="rowA">Первая строка</param>
        /// <param name="rowB">Вторая строка</param>
        /// <returns>Разность двух строк</returns>
        public static Row<T> operator - (Row<T> rowA, Row<T> rowB)
        {
            if (rowA.Size == rowB.Size)
            {
                Row<T> summedRow = new Row<T>(rowA.Size);
               
                int i = 0;

                summedRow.ForEach((cell) => summedRow[i++] = (T)Operator.Subtract(rowA[i++], rowB[i++]));

                return summedRow;
            }
            else
            {
                throw new RowsOfDifferentSizesException();
            }
        }

        /// <summary>
        /// Умножает строку на столбец
        /// </summary>
        /// <param name="row">Строка</param>
        /// <param name="column">Столбец</param>
        /// <returns><see cref="Matrix{T}"/> результат умножения</returns>
        public static Matrix<T> operator *(Row<T> row, Column<T> column)
        {
            Matrix<T> matrix = new Matrix<T>(row.Size,column.Size);

            for(int i = 0;i < row.Size;i++)
            {
                for(int j = 0;j < column.Size;j++)
                {
                    matrix[i, j] = (T)Operator.Multiply(row[i],column[j]);
                }
            }

            return matrix;
        }

        /// <summary>
        /// Приводит <see cref="ReadOnlyRow{T}"/> к <see cref="Row{T}"/>
        /// делая возможной запись
        /// </summary>
        /// <param name="readOnlyRow">Приводимая строка</param>
        public static explicit operator Row<T>(ReadOnlyRow<T> readOnlyRow)
        {
            Row<T> row = new Row<T>(readOnlyRow.Size);
            
            int i = 0;
           
            readOnlyRow.ForEach((cell) =>
            {
                row[i] = cell;
            });

            return row;
        }

        /// <summary>
        /// Приводит <see cref="Row{T}"/>  к <see cref="ReadOnlyRow{T}"/>
        /// делая возможной запись
        /// </summary>
        /// <param name="row">Приводимая строка</param>
        public static explicit operator ReadOnlyRow<T>(Row<T> row)
        {
            ReadOnlyRow<T> readOnlyRow = new ReadOnlyRow<T>(row._cells);

            return readOnlyRow;
        }

        /// <summary>
        /// Транспонирует строку
        /// </summary>
        /// <returns><see cref="Column{T}"/> Столбец</returns>
        public Column<T> Transponate()
        {
            return new Column<T>(_cells);
        }

    }
}
