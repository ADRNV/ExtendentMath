using System;

namespace MathExtended.Exceptions
{
    /// <summary>
    /// Возникает при попытке операции
    /// над вектор строками/столбцами разных размеров
    /// </summary>
    public class VectorsDifferentSizeException : Exception
    {
        private string _message = "Vector row/column of different sizes";

        /// <summary>
        /// Сообщение исключения
        /// </summary>
        public override string Message => _message;
    }
}
