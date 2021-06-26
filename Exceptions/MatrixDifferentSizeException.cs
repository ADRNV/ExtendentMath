using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtended.Exceptions
{
    public class MatrixDifferentSizeException : Exception
    {
        private string message = "Matrices must be the same size";
        public virtual string Message 
        { 
            get => message;
        }
    }
}
