using MathExtended.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtended.Matrices.Structures.CellsCollection
{
    /// <summary>
    /// Описывает коллекцию ячеек только для чтения
    /// </summary>
    /// <typeparam name="T">Числовой тип</typeparam>
    public abstract class BaseReadOnlyCellsCollection<T> : BaseCellsCollection<T>,IEnumerator<T> where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        
        /// <summary>
        /// Создает коллекцию ячеек только для чтения с указанным размером
        /// </summary>
        /// <param name="size">Размер коллеции</param>
        public BaseReadOnlyCellsCollection(int size):base(size)
        {
            Cells = new T[size];
        }

        /// <summary>
        /// Создает коллецию только для чтения на основе массива
        /// </summary>
        /// <param name="array">Массив</param>
        public BaseReadOnlyCellsCollection(T[] array):base(array)
        {
            Cells = array;
        }

    }
}
