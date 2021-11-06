#### [MathExtended](index.md 'index')
### [MathExtended.Matrices](MathExtended_Matrices.md 'MathExtended.Matrices')
## Matrix&lt;T&gt; Class
Описывает основную логику матриц  
```csharp
public class Matrix<T> : MathExtended.Matrices.BaseMatrix<T>
    where T : System.IComparable, System.IFormattable, System.IConvertible, System.IComparable<T>, System.IEquatable<T>
```
#### Type parameters
<a name='MathExtended_Matrices_Matrix_T__T'></a>
`T`  
Числовой тип
  

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [MathExtended.Matrices.BaseMatrix&lt;](MathExtended_Matrices_BaseMatrix_T_.md 'MathExtended.Matrices.BaseMatrix&lt;T&gt;')[T](MathExtended_Matrices_Matrix_T_.md#MathExtended_Matrices_Matrix_T__T 'MathExtended.Matrices.Matrix&lt;T&gt;.T')[&gt;](MathExtended_Matrices_BaseMatrix_T_.md 'MathExtended.Matrices.BaseMatrix&lt;T&gt;') &#129106; Matrix&lt;T&gt;  

| Constructors | |
| :--- | :--- |
| [Matrix(int, int)](MathExtended_Matrices_Matrix_T__Matrix(int_int).md 'MathExtended.Matrices.Matrix&lt;T&gt;.Matrix(int, int)') | Создает матрицу с указанными размерами<br/> |
| [Matrix(T[,])](MathExtended_Matrices_Matrix_T__Matrix(T___).md 'MathExtended.Matrices.Matrix&lt;T&gt;.Matrix(T[,])') | Создает матрицу на основе двумерного массива <br/> |

| Properties | |
| :--- | :--- |
| [IsSquareMatrix](MathExtended_Matrices_Matrix_T__IsSquareMatrix.md 'MathExtended.Matrices.Matrix&lt;T&gt;.IsSquareMatrix') | Квадратность матрицы<br/> |
| [Size](MathExtended_Matrices_Matrix_T__Size.md 'MathExtended.Matrices.Matrix&lt;T&gt;.Size') | Размер матрицы<br/> |

| Methods | |
| :--- | :--- |
| [CalculateDeterminant()](MathExtended_Matrices_Matrix_T__CalculateDeterminant().md 'MathExtended.Matrices.Matrix&lt;T&gt;.CalculateDeterminant()') | Расчитывает детерминант матрицы<br/> |
| [CalculateDeterminantAsync()](MathExtended_Matrices_Matrix_T__CalculateDeterminantAsync().md 'MathExtended.Matrices.Matrix&lt;T&gt;.CalculateDeterminantAsync()') | Расчитывает детерминант матрицы асинхронно<br/> |
| [CreateMatrixWithoutColumn(int)](MathExtended_Matrices_Matrix_T__CreateMatrixWithoutColumn(int).md 'MathExtended.Matrices.Matrix&lt;T&gt;.CreateMatrixWithoutColumn(int)') | Создает матрицу с вычеркнутыми столбцами на основе текущей<br/> |
| [CreateMatrixWithoutRow(int)](MathExtended_Matrices_Matrix_T__CreateMatrixWithoutRow(int).md 'MathExtended.Matrices.Matrix&lt;T&gt;.CreateMatrixWithoutRow(int)') | Создает матрицу с вычеркнутыми строками на основе текущей<br/> |
| [FillInOrder()](MathExtended_Matrices_Matrix_T__FillInOrder().md 'MathExtended.Matrices.Matrix&lt;T&gt;.FillInOrder()') | Заполняет матрицу по порядку:от 1 до размера последнего элемента матрицы<br/> |
| [FillRandom()](MathExtended_Matrices_Matrix_T__FillRandom().md 'MathExtended.Matrices.Matrix&lt;T&gt;.FillRandom()') | Заполняет матрицу случайными целочисленными значениями<br/> |
| [FillRandom(T, T)](MathExtended_Matrices_Matrix_T__FillRandom(T_T).md 'MathExtended.Matrices.Matrix&lt;T&gt;.FillRandom(T, T)') | Заполняет матрицу случайными значениями в определенном диапазоне<br/> |
| [FindRank()](MathExtended_Matrices_Matrix_T__FindRank().md 'MathExtended.Matrices.Matrix&lt;T&gt;.FindRank()') | Находит ранго мартицы<br/> |
| [ForEach(Action&lt;int,int&gt;)](MathExtended_Matrices_Matrix_T__ForEach(System_Action_int_int_).md 'MathExtended.Matrices.Matrix&lt;T&gt;.ForEach(System.Action&lt;int,int&gt;)') | Применяет действия ко всем элементам матрицы<br/> |
| [ForEach(Action&lt;T&gt;)](MathExtended_Matrices_Matrix_T__ForEach(System_Action_T_).md 'MathExtended.Matrices.Matrix&lt;T&gt;.ForEach(System.Action&lt;T&gt;)') | Применяет действия ко всем элементам матрицы<br/> |
| [Pow(Matrix&lt;T&gt;, int)](MathExtended_Matrices_Matrix_T__Pow(MathExtended_Matrices_Matrix_T__int).md 'MathExtended.Matrices.Matrix&lt;T&gt;.Pow(MathExtended.Matrices.Matrix&lt;T&gt;, int)') | Возводит матрицу в степень<br/> |
| [ToSteppedView()](MathExtended_Matrices_Matrix_T__ToSteppedView().md 'MathExtended.Matrices.Matrix&lt;T&gt;.ToSteppedView()') | Приводит матрицу к ступенчатому виду<br/> |
| [ToString()](MathExtended_Matrices_Matrix_T__ToString().md 'MathExtended.Matrices.Matrix&lt;T&gt;.ToString()') | Вывод матрицы в строковом представлении<br/> |
| [Transponate()](MathExtended_Matrices_Matrix_T__Transponate().md 'MathExtended.Matrices.Matrix&lt;T&gt;.Transponate()') | Транспонирует(меняет строки со столбцами) текущую матрицу и возвращает новую<br/> |

| Operators | |
| :--- | :--- |
| [operator +(Matrix&lt;T&gt;, Matrix&lt;T&gt;)](MathExtended_Matrices_Matrix_T__op_Addition(MathExtended_Matrices_Matrix_T__MathExtended_Matrices_Matrix_T_).md 'MathExtended.Matrices.Matrix&lt;T&gt;.op_Addition(MathExtended.Matrices.Matrix&lt;T&gt;, MathExtended.Matrices.Matrix&lt;T&gt;)') | Суммирует две матрицы<br/> |
| [explicit operator Matrix&lt;T&gt;(T[,])](MathExtended_Matrices_Matrix_T__op_ExplicitMathExtended_Matrices_Matrix_T_(T___).md 'MathExtended.Matrices.Matrix&lt;T&gt;.op_Explicit MathExtended.Matrices.Matrix&lt;T&gt;(T[,])') | Явно приводит двумерный массив к [Matrix&lt;T&gt;](MathExtended_Matrices_Matrix_T_.md 'MathExtended.Matrices.Matrix&lt;T&gt;') |
| [explicit operator T[,](Matrix&lt;T&gt;)](MathExtended_Matrices_Matrix_T__op_ExplicitT___(MathExtended_Matrices_Matrix_T_).md 'MathExtended.Matrices.Matrix&lt;T&gt;.op_Explicit T[,](MathExtended.Matrices.Matrix&lt;T&gt;)') | Явно приводит [Matrix&lt;T&gt;](MathExtended_Matrices_Matrix_T_.md 'MathExtended.Matrices.Matrix&lt;T&gt;') к двумерному массиву<br/> |
| [operator *(Matrix&lt;T&gt;, Matrix&lt;T&gt;)](MathExtended_Matrices_Matrix_T__op_Multiply(MathExtended_Matrices_Matrix_T__MathExtended_Matrices_Matrix_T_).md 'MathExtended.Matrices.Matrix&lt;T&gt;.op_Multiply(MathExtended.Matrices.Matrix&lt;T&gt;, MathExtended.Matrices.Matrix&lt;T&gt;)') | Перемножает матрицы<br/> |
| [operator *(Matrix&lt;T&gt;, T)](MathExtended_Matrices_Matrix_T__op_Multiply(MathExtended_Matrices_Matrix_T__T).md 'MathExtended.Matrices.Matrix&lt;T&gt;.op_Multiply(MathExtended.Matrices.Matrix&lt;T&gt;, T)') | Умножает матрицу на число<br/> |
| [operator *(T, Matrix&lt;T&gt;)](MathExtended_Matrices_Matrix_T__op_Multiply(T_MathExtended_Matrices_Matrix_T_).md 'MathExtended.Matrices.Matrix&lt;T&gt;.op_Multiply(T, MathExtended.Matrices.Matrix&lt;T&gt;)') | Умножает матрицу на число<br/> |
| [operator -(Matrix&lt;T&gt;, Matrix&lt;T&gt;)](MathExtended_Matrices_Matrix_T__op_Subtraction(MathExtended_Matrices_Matrix_T__MathExtended_Matrices_Matrix_T_).md 'MathExtended.Matrices.Matrix&lt;T&gt;.op_Subtraction(MathExtended.Matrices.Matrix&lt;T&gt;, MathExtended.Matrices.Matrix&lt;T&gt;)') | Разность матриц<br/> |
