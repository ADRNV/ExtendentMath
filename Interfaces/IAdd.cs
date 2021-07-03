using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtended.Interfaces
{
    public interface IAdd<T>
    {
        T Add(T a, T b);
    }
}
