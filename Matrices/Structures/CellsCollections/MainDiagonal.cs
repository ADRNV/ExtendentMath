using MathExtended.Matrices.Structures.CellsCollection;
using System;

namespace MathExtended.Matrices.Structures.CellsCollections
{
    /// <summary>
    /// Описывает главную диагональ матрицы
    /// </summary>
    /// <typeparam name="T">Числовой тип</typeparam>
    public class MainDiagonal<T> : BaseReadOnlyCellsCollection<T> where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        /// <summary>
        /// Создает клавную диагональ на основе массива
        /// </summary>
        /// <param name="array">Массив</param>
        public MainDiagonal(T[] array) : base(array)
        {

        }

    }
}
