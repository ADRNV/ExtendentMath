using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtended.Exceptions
{
    public class TheNumberOfRowsAndColumnsIsDifferentException : Exception
    {
        private string message = "The number of rows and columns in two matrices must be equal";

        public override string Message => message;
    }
}
