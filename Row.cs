using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static  implicit operator Row<T>(T[] array)
        {
            return new Row<T>(array);
        }
    }
}
