using MathExtended.Matrices.Structures.CellsCollection;
using MiscUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtended.Matrices.Structures.CellsCollections
{
    /// <summary>
    /// Class of extensions for <see cref="BaseCellsCollection{T}"/> inheritors
    /// </summary>
    public static class CellsCollectionExtensions
    {
        /// <summary>
        /// Checks if all cells in a <paramref name="cellsCollection"/> are 0
        /// </summary>
        /// <typeparam name="T">Numerical type</typeparam>
        /// <param name="cellsCollection">Cells collection</param>
        /// <returns><see langword="true"/> if all elements equal 0, else <see langword="false"/></returns>
        public static bool IsZero<T>(this BaseCellsCollection<T> cellsCollection) where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            return cellsCollection.All(c => c == (dynamic)0);
        }
    }
}
