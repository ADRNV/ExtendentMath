using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtended
{
    /// <summary>
    /// Описывает результат табуляции функции
    /// </summary>
    public struct TabulateResult
    {
        private double[] _x;

        private double[] _y;

        /// <summary>
        /// Значения аргумента
        /// </summary>
        public ReadOnlyCollection<double> X
        {
            get => Array.AsReadOnly(_x);
        }

        /// <summary>
        /// Значения функции
        /// </summary>
        public ReadOnlyCollection<double> Y
        {
            get => Array.AsReadOnly(_y);
        }

        /// <summary>
        /// Инициализирует результат табуляции
        /// </summary>
        /// <param name="x">Значения аргумента</param>
        /// <param name="y">Значения функции</param>
        public TabulateResult(double[] x, double[] y)
        {
            _x = x;
            _y = y;
        }
    }
}
