using System;


namespace MathExtended.Exceptions
{
    /// <summary>
    /// Появляется при попытке создать строку с нулевой длиной
    /// </summary>
    public class RowZeroSizeException : Exception
    {
        private string _message = "Rows can not be zero size.";

        /// <summary>
        /// Сообщение исключения
        /// </summary>
        public override string Message => _message;
        
    }
}
