using MathExtended.Matrices.Structures.CellsCollections;
using System;
using System.Collections.Generic;

namespace MathExtended.Interfaces
{
    /// <summary>
    /// Определяет основную структуру матрицы
    /// </summary>
    /// <typeparam name="T">Числовой тип</typeparam>
    public interface IMatrix<T> : IEnumerable<T>, IEnumerator<T> where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        /// <summary>
        ///  Главная диагональ
        /// </summary>
        MainDiagonal<T> MainDiagonal { get; }

        /// <summary>
        /// Количество строк
        /// </summary>
        int RowsCount { get; }

        /// <summary>
        /// Количество столбцов
        /// </summary>
        int ColumnsCount { get; }

        /// <summary>
        /// Индесатор матрицы, получает ячейку в соответсвии с ее адресом в матрице
        /// </summary>
        /// <param name="row">Индекс строки</param>
        /// <param name="column">Индекс столбца</param>
        /// <returns><typeparamref name="T"/> число по индексу</returns>
        T this[int row, int column]
        {
            get;
            set;
        }


    }
}
