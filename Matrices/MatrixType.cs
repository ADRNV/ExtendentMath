using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtended.Matrices
{
    /// <summary>
    /// Типо-размерность матрицы
    /// </summary>
    public enum MatrixDimensionType
    {
        /// <summary>
        /// Колличество строк равно колличеству столбцов
        /// </summary>
        RowsEqualColumns = 0,
        /// <summary>
        /// Колличество строк больше столбцов
        /// </summary>
        RowsMatchColumns = 1,
        /// <summary>
        /// Колличество столбцов больше чем строк
        /// </summary>
        ColumnsMatchRows = 2,
    }
}
