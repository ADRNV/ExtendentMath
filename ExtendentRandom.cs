using System;

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
        public T Next<T>(in T minValue,in T maxValue) where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            var minValueCasted = (double)(dynamic)minValue;
            var maxValueCasted = (double)(dynamic)maxValue;
            var random = new Random().NextDouble();
            return (T)(dynamic)((random * minValueCasted) + (1 - random) * maxValueCasted);
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
