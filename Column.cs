using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtended
{
    /// <summary>
    /// Описывает столбцы матрицы
    /// </summary>
    /// <typeparam name="T">Тип содержимого строки</typeparam>
    public class Column<T> : BaseCellsCollection<T> where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        /// <summary>
        /// Создает столбец с указанными размерами
        /// </summary>
        /// <param name="height"></param>
       public Column(int height) : base(height) { }
       /// <summary>
       /// Создает столбец на основе массива
       /// </summary>
       /// <param name="array"></param>
       public Column(T[] array) : base(array) { }

       /// <summary>
       /// Не явным образом приводит масив к столбцу
       /// </summary>
       /// <param name="array">Приводимый массив</param>
       public static implicit operator Column<T>(T[] array)
       {
            return new Column<T>(array);
       }
    }
}
