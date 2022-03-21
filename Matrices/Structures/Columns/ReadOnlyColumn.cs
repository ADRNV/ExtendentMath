using MathExtended.Matrices.Structures.CellsCollection;
using System;

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
    }
}
