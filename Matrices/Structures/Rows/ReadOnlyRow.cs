using MathExtended.Matrices.Structures.CellsCollection;
using System;

namespace MathExtended.Matrices.Structures.Rows
{
    /// <summary>
    /// Описывает строку только для чтения
    /// </summary>
    /// <typeparam name="T">Числовой тип</typeparam>
    public class ReadOnlyRow<T> : BaseReadOnlyCellsCollection<T> where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        private BaseCellsCollection<T> RowCells;

        /// <summary>
        /// Создает строку только для чтения определенного размера
        /// </summary>
        /// <param name="size">Размер</param>
        public ReadOnlyRow(int size) : base(size)
        {

        }

        /// <summary>
        /// Создает строку только для чтения на основе массива
        /// </summary>
        /// <param name="array">Массив</param>
        public ReadOnlyRow(T[] array) : base(array)
        {

        }

        /// <summary>
        /// Явно приводит <see cref="Row{T}"/> к <see cref="ReadOnlyRow{T}"/>
        /// Делая пригодным для записи
        /// </summary>
        /// <param name="readOnlyRow">Привидимая строка</param>
        public static explicit operator Row<T>(ReadOnlyRow<T> readOnlyRow)
        {
            Row<T> column = new Row<T>(readOnlyRow.Size);

            int i = 0;

            readOnlyRow.ForEach((cell) =>
            {
                column[i] = cell;
            });

            return column;
        }


    }
}
