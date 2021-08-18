using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtended
{
    /// <summary>
    /// Описывает коллекцию ячеек
    /// </summary>
    /// <typeparam name="T">Тип содержиого</typeparam>
    public abstract class BaseCellsCollection<T> where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        private T[] _cells;

        private int _size;

        /// <summary>
        /// Индексатор.По индексу возвращает или задает значение ячейки
        /// </summary>
        /// <param name="index">Индекс элемента</param>
        /// <returns>Элемент по индексу</returns>
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
        /// Размер коллекции
        /// </summary>
        public int Size
        {
            get => _cells.Length;
        }

        /// <summary>
        /// Создает коллекцию с указанным размером
        /// </summary>
        /// <param name="size">Размер коллекции</param>
        public BaseCellsCollection(int size)
        {
            _cells = new T[size];
        }

        /// <summary>
        /// Создает коллекцию ячеек на основе массива
        /// </summary>
        /// <param name="array">Входной массив</param>
        public BaseCellsCollection(T[] array)
        {
            _cells = array;
            _size = array.Length;
        }

        /// <summary>
        /// Применяет действие ко всем элементам
        /// </summary>
        /// <param name="action">Действие</param>
        public virtual void ForEach(Action<int> action)
        {
            for(int item = 0;item < Size - 1;item++)
            {
                action(item);
            }
        }
    }
}
