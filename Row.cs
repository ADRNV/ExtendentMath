using MiscUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathExtended.Exceptions;

namespace MathExtended
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

            

            row.ForEach((cell) => 
            { 
                int i = 0; 
                
                multipliedRow[i++] = Operator.Multiply(cell, multiplier); 
            });

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

                summedRow.ForEach((cell) =>
                {
                    int i = 0;

                    summedRow[i++] = Operator.Add(rowA[i++], rowB[i++]);
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

                summedRow.ForEach((cell) =>
                {
                    int i = 0;

                    summedRow[i++] = Operator.Subtract(rowA[i++], rowB[i++]);
                });

                return summedRow;
            }
            else
            {
                throw new RowsOfDifferentSizesException();
            }
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
