using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtended
{
    /// <summary>
    /// Улучшенная версия Random
    /// </summary>
    public class ExtendentRandom : Random
    {
        /// <summary>
        /// Генерирует случайное число типа <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">Числовой тип</typeparam>
        /// <param name="minValue">Нижняя граница</param>
        /// <param name="maxValue">Верхняя граница</param>
        /// <returns><typeparamref name="T"/> Число</returns>
        public T Next<T>(T minValue, T maxValue) where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            return (T)(dynamic)(base.Next((int)(dynamic)minValue, (int)(dynamic)maxValue) + base.NextDouble());
        }

        /// <summary>
        /// Генерирует случайное число типа <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">Числовой тип</typeparam>
        /// <returns><typeparamref name="T"/> Число</returns>
        public T Next<T>() where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            return (T)(dynamic)(base.Next() + base.NextDouble());
        }
    }
}
