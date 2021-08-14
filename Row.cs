using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtended
{
    public class Row<T>
    {
        private T[] _cells;

        private int _length;

        /// <summary>
        /// Индексатор.По индексу возвращает или задает значение ячейки из строки
        /// </summary>
        /// <param name="index">Индекс элемента</param>
        /// <returns>Элемент <code><see cref="T"/> cell</code></returns>
        public T this[int index]
        {
            get
            {
                return _cells[index];
            }

            set
            {
                _cells[index] = value;
            }
        }

        /// <summary>
        /// Длина строки
        /// </summary>
        public int Length
        {

            get => _cells.Length;
        }

        /// <summary>
        /// Создает строку с указанным размером
        /// </summary>
        /// <param name="length"></param>
        public Row(int length)
        {
            _cells = new T[length];
        }

        public Row(T[] array)
        {
            _cells = array;
            _length = array.Length;
        }

        public static  implicit operator Row<T>(T[] array)
        {
            return new Row<T>(array);
        }


    }
}
