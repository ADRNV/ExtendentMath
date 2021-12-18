using System;

namespace MathExtended.Exceptions
{
    /// <summary>
    /// Появляется при попытке сложить/вычесть матрицы разных размеров
    /// </summary>
    public class MatrixDifferentSizeException : Exception
    {
        private string message = "Matrices must be the same size";
        public override string Message => message;
    }
}
