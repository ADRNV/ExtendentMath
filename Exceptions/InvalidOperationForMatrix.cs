using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtended.Exceptions
{
    /// <summary>
    /// Появляется когда матрица не соответствует
    /// 
    /// </summary>
    public class InvalidOperationForMatrix : Exception
    {
        private string message = "This operation is not achievable for the current matrix.";
    }
}
