using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtended.Exceptions
{
    /// <summary>
    /// Появляется при попытке перемножить матрицы, с не равным колличеством строк/столбцов первой матрицы и второй
    /// </summary>
    public class TheNumberOfRowsAndColumnsIsDifferentException : Exception
    {
        private string message = "The number of rows and columns in two matrices must be equal";
        /// <summary>
        /// Сообщение исключения
        /// </summary>
        public override string Message => message;
    }
}
