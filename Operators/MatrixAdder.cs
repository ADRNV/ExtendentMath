using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathExtended.Interfaces;

namespace MathExtended.Operators
{
    public class MatrixAdder<T> : IAdd<Matrix<T>>
    {
        public Matrix<object> Add(Matrix<object> a, Matrix<object> b)
        {
            throw new NotImplementedException();
        }
    }
}
