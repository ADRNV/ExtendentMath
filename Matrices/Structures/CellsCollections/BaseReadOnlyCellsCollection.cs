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
    public abstract class BaseReadOnlyCellsCollection<T> : IEnumerator<T> where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        private T[] _cells;
        private bool disposedValue;
        private int _position;

        /// <summary>
        /// Индексатор.По индексу возвращает значение ячейки
        /// </summary>
        /// <param name="index">Индекс элемента</param>
        /// <returns>Элемент по индексу</returns>
        public T this[int index] { get => _cells[index];}
        
        /// <summary>
        /// Создает коллекцию ячеек только для чтения с указанным размером
        /// </summary>
        /// <param name="size">Размер коллеции</param>
        public BaseReadOnlyCellsCollection(int size)
        {
            _cells = new T[size];
        }

        /// <summary>
        /// Создает коллецию только для чтения на основе массива
        /// </summary>
        /// <param name="array">Массив</param>
        public BaseReadOnlyCellsCollection(T[] array)
        {
            _cells = array;
        }

        /// <summary>
        /// Применяет действие ко всем элементам
        /// </summary>
        /// <param name="action">Действие</param>
        public virtual void ForEach(Action<T> action)
        {
            foreach (T cell in _cells)
            {
                action(cell);
            }
        }

        /// <summary>
        /// Находит максимальное число среди ячеек
        /// </summary>
        /// <returns>Максимальное значение в последовательности ячеек</returns>
        public virtual T Max() => _cells.Max();


        /// <summary>
        /// Находит минимальное число среди ячеек
        /// </summary>
        /// <returns> Минимальное значение в последовательности ячеек</returns>
        public virtual T Min() => _cells.Min();

        /// <summary>
        /// Проверяет нулевая ли коллекция
        /// </summary>
        /// <returns> <see langword="true"/> - если все ячейки равны нулю, <see langword="false"/> - если хоть одна ячейка не равна нулю </returns>
        public bool IsZero()
        {
            return _cells.All((cell) => cell == (dynamic)0);
        }

        #region IEnumerable
        /// <summary>
        /// Текуший элемент
        /// </summary>
        public T Current
        {
            get
            {
                return _cells[_position];
            }
        }

        object IEnumerator.Current => Current;

        /// <summary>
        /// Размер коллекции
        /// </summary>
        public int Size 
        {
            get => _cells.Length;
        }

        /// <summary>
        /// Перечислитель
        /// </summary>
        /// <returns>Перечислитель матрицы</returns>
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var i in _cells)
            {

                yield return i;
            }
        }

        /// <summary>
        /// Перемещает индексатор на одну позицию вперед
        /// </summary>
        /// <returns>true или false в зависимости ли можно переместить индексатор</returns>
        public bool MoveNext()
        {

            if (_position < this.Size - 1)
            {
                return true;
            }
            else
            {
                return false;
            }



        }

        /// <summary>
        /// Перемещает индексатор в начало матрицы
        /// </summary>
        public void Reset()
        {
            _position = -1;
        }

        /// <summary>
        /// Высвобождает использованные ресурсы
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _cells = null;
                }

                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить метод завершения
                // TODO: установить значение NULL для больших полей
                disposedValue = true;
            }
        }

        // // TODO: переопределить метод завершения, только если "Dispose(bool disposing)" содержит код для освобождения неуправляемых ресурсов
        // ~Matrix()
        // {
        //     // Не изменяйте этот код. Разместите код очистки в методе "Dispose(bool disposing)".
        //     Dispose(disposing: false);
        // }

        /// <summary>
        /// Освобождает использованные ресурсы
        /// </summary>
        public void Dispose()
        {
            // Не изменяйте этот код.  Разместите код очистки в методе "Dispose(bool disposing)".
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
