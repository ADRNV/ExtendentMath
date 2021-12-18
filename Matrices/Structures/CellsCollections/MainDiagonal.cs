using MathExtended.Interfaces;
using MathExtended.Matrices.Structures.CellsCollection;
using MathExtended.Matrices.Structures.Rows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public MainDiagonal(T[] array):base(array)
        {

        }

    }
}
