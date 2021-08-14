using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtended
{
    class Column<T>
    {
        private T[] _cells;

        private int _height;

        /// <summary>
        /// Индексатор.По индексу возвращает или задает значение ячейки из столбца
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
        public int Height
        {

            get => _cells.Length;
        }

        /// <summary>
        /// Создает строку с указанным размером
        /// </summary>
        /// <param name="height"></param>
        public Column(int height)
        {
            _cells = new T[height];
        }

        public Column(T[] array)
        {
            _cells = array;
            _height = array.Length;
        }

        public static implicit operator Column<T>(T[] array)
        {
            return new Column<T>(array);
        }

    }
}
