using System;

namespace MathExtended.Exceptions
{
    /// <summary>
    /// Появляется при попытке сложить/вычесть строки разных размеров
    /// </summary>
    public class RowsOfDifferentSizesException : Exception
    {
        private string _message = "Rows must be the same sizes.";

        /// <summary>
        /// Сообщение исключения
        /// </summary>
        public override string Message
        {
            get => _message;
        }
    }
}
