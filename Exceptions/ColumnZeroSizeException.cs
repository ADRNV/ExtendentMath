using System;


namespace MathExtended.Exceptions
{
    /// <summary>
    /// Появляется при попытке создать
    /// столбец с нулевыми размерами
    /// </summary>
    public class ColumnZeroSizeException : Exception
    {
        private string _message = "Columns can not be zero size";

        /// <summary>
        /// Сообщение исключения
        /// </summary>
        public override string Message => _message;

    }
}
