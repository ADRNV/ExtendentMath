using MathExtended.Matrices.Structures.CellsCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtended.Matrices.Structures.Columns
{
    /// <summary>
    /// Описывает логику столбца только для чтения
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ReadOnlyColumn<T> : BaseReadOnlyCellsCollection<T> where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        /// <summary>
        /// Создает столбец только для чтения укзанного размера
        /// </summary>
        /// <param name="size">Размер столбца</param>
        public ReadOnlyColumn(int size) : base(size)
        {

        }

        /// <summary>
        /// Создает столбец только для чтения на основе массива
        /// </summary>
        /// <param name="array">Массив</param>
        public ReadOnlyColumn(T[] array) : base(array)
        {

        }

        /// <summary>
        /// Явно приводит <see cref="Column{T}"/> к <see cref="ReadOnlyColumn{T}"/>
        /// делая только для чтения
        /// </summary>
        /// <param name="column">Приводимый столбец</param>
        public static explicit operator ReadOnlyColumn<T>(Column<T> column)
        {
            ReadOnlyColumn<T> readOnlyColumn = new ReadOnlyColumn<T>(column.Size);

            int i = 0;

            readOnlyColumn.ForEach((cell) =>
            {
                column[i] = cell;
            });

            return readOnlyColumn;
        }

    }
}
