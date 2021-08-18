using System;

namespace MathExtended.Exceptions
{
    /// <summary>
    /// Возникает при попытке создать матрицу
    /// с нулевыми размерами
    /// </summary>
    public class MatrixZeroSizeException : Exception
    {
        private string _message = "Matrices can not be zero size.";

        /// <summary>
        /// Сообщение исключения
        /// </summary>
        public override string Message
        {
            get => _message;
        }
    }
}
