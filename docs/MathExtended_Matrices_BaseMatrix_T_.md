#### [MathExtended](index.md 'index')
### [MathExtended.Matrices](MathExtended_Matrices.md 'MathExtended.Matrices')
## BaseMatrix&lt;T&gt; Class
Базовый класс матрицы.Реализует интерфейс перечисления  
и ограничивает принимаемые обобщения до числовых типов ([System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32'), [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single'), [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double') и т.д)  
```csharp
public abstract class BaseMatrix<T> :
System.Collections.Generic.IEnumerator<T>,
System.IDisposable,
System.Collections.IEnumerator,
MathExtended.Interfaces.IMatrix<T>
    where T : System.IComparable, System.IFormattable, System.IConvertible, System.IComparable<T>, System.IEquatable<T>
```
#### Type parameters
<a name='MathExtended_Matrices_BaseMatrix_T__T'></a>
`T`  
Числовой тип
  

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; BaseMatrix&lt;T&gt;  

Derived  
&#8627; [Matrix&lt;T&gt;](MathExtended_Matrices_Matrix_T_.md 'MathExtended.Matrices.Matrix&lt;T&gt;')  

Implements [System.Collections.Generic.IEnumerator&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerator-1 'System.Collections.Generic.IEnumerator`1')[T](MathExtended_Matrices_BaseMatrix_T_.md#MathExtended_Matrices_BaseMatrix_T__T 'MathExtended.Matrices.BaseMatrix&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerator-1 'System.Collections.Generic.IEnumerator`1'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable'), [System.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator 'System.Collections.IEnumerator'), [MathExtended.Interfaces.IMatrix&lt;](MathExtended_Interfaces_IMatrix_T_.md 'MathExtended.Interfaces.IMatrix&lt;T&gt;')[T](MathExtended_Matrices_BaseMatrix_T_.md#MathExtended_Matrices_BaseMatrix_T__T 'MathExtended.Matrices.BaseMatrix&lt;T&gt;.T')[&gt;](MathExtended_Interfaces_IMatrix_T_.md 'MathExtended.Interfaces.IMatrix&lt;T&gt;')  

| Constructors | |
| :--- | :--- |
| [BaseMatrix(int, int)](MathExtended_Matrices_BaseMatrix_T__BaseMatrix(int_int).md 'MathExtended.Matrices.BaseMatrix&lt;T&gt;.BaseMatrix(int, int)') | Создает матрицу с указанными размерами<br/> |

| Fields | |
| :--- | :--- |
| [_mainDiagonal](MathExtended_Matrices_BaseMatrix_T___mainDiagonal.md 'MathExtended.Matrices.BaseMatrix&lt;T&gt;._mainDiagonal') | Главная диагональ<br/> |
| [matrix](MathExtended_Matrices_BaseMatrix_T__matrix.md 'MathExtended.Matrices.BaseMatrix&lt;T&gt;.matrix') | Матрица представляющая собой двумерный массив<br/> |

| Properties | |
| :--- | :--- |
| [ColumnsCount](MathExtended_Matrices_BaseMatrix_T__ColumnsCount.md 'MathExtended.Matrices.BaseMatrix&lt;T&gt;.ColumnsCount') | Колличество столбцов в матрице<br/> |
| [Current](MathExtended_Matrices_BaseMatrix_T__Current.md 'MathExtended.Matrices.BaseMatrix&lt;T&gt;.Current') | Текуший элемент<br/> |
| [MainDiagonal](MathExtended_Matrices_BaseMatrix_T__MainDiagonal.md 'MathExtended.Matrices.BaseMatrix&lt;T&gt;.MainDiagonal') | Главная диагональ<br/> |
| [RowsCount](MathExtended_Matrices_BaseMatrix_T__RowsCount.md 'MathExtended.Matrices.BaseMatrix&lt;T&gt;.RowsCount') | Колличество строк в матрице<br/> |
| [this[int, int]](MathExtended_Matrices_BaseMatrix_T__this_int_int_.md 'MathExtended.Matrices.BaseMatrix&lt;T&gt;.this[int, int]') | Число матрицы<br/> |
| [this[VectorSelector, int]](MathExtended_Matrices_BaseMatrix_T__this_MathExtended_Matrices_Structures_CellsCollections_VectorSelector_int_.md 'MathExtended.Matrices.BaseMatrix&lt;T&gt;.this[MathExtended.Matrices.Structures.CellsCollections.VectorSelector, int]') | Возвращает столбец или строку в<br/>зависимости от селектора<br/> |
| [this[VectorSelector]](MathExtended_Matrices_BaseMatrix_T__this_MathExtended_Matrices_Structures_CellsCollections_VectorSelector_.md 'MathExtended.Matrices.BaseMatrix&lt;T&gt;.this[MathExtended.Matrices.Structures.CellsCollections.VectorSelector]') | Возвращает стоки или столбцы в зависимости от селектора<br/> |

| Methods | |
| :--- | :--- |
| [Dispose()](MathExtended_Matrices_BaseMatrix_T__Dispose().md 'MathExtended.Matrices.BaseMatrix&lt;T&gt;.Dispose()') | Освобождает использованные ресурсы<br/> |
| [Dispose(bool)](MathExtended_Matrices_BaseMatrix_T__Dispose(bool).md 'MathExtended.Matrices.BaseMatrix&lt;T&gt;.Dispose(bool)') | Высвобождает использованные ресурсы<br/> |
| [FindDiagonal()](MathExtended_Matrices_BaseMatrix_T__FindDiagonal().md 'MathExtended.Matrices.BaseMatrix&lt;T&gt;.FindDiagonal()') | Находит главную диагональ матрицы<br/> |
| [ForEach(Action&lt;int,int&gt;)](MathExtended_Matrices_BaseMatrix_T__ForEach(System_Action_int_int_).md 'MathExtended.Matrices.BaseMatrix&lt;T&gt;.ForEach(System.Action&lt;int,int&gt;)') | Применяет функцию ко всем элементам матрицы<br/> |
| [GetColumn(int)](MathExtended_Matrices_BaseMatrix_T__GetColumn(int).md 'MathExtended.Matrices.BaseMatrix&lt;T&gt;.GetColumn(int)') | Возвращает столбец матрицы по индексу<br/> |
| [GetColumns()](MathExtended_Matrices_BaseMatrix_T__GetColumns().md 'MathExtended.Matrices.BaseMatrix&lt;T&gt;.GetColumns()') | Возвращает все столбцы матрицы<br/> |
| [GetEnumerator()](MathExtended_Matrices_BaseMatrix_T__GetEnumerator().md 'MathExtended.Matrices.BaseMatrix&lt;T&gt;.GetEnumerator()') | Перечислитель<br/> |
| [GetRow(int)](MathExtended_Matrices_BaseMatrix_T__GetRow(int).md 'MathExtended.Matrices.BaseMatrix&lt;T&gt;.GetRow(int)') | Возвращает строку матрицы соответсвующую индексу<br/> |
| [GetRows()](MathExtended_Matrices_BaseMatrix_T__GetRows().md 'MathExtended.Matrices.BaseMatrix&lt;T&gt;.GetRows()') | Возвращает все строки матрицы<br/> |
| [MoveNext()](MathExtended_Matrices_BaseMatrix_T__MoveNext().md 'MathExtended.Matrices.BaseMatrix&lt;T&gt;.MoveNext()') | Перемещает индексатор на одну позицию вперед<br/> |
| [Reset()](MathExtended_Matrices_BaseMatrix_T__Reset().md 'MathExtended.Matrices.BaseMatrix&lt;T&gt;.Reset()') | Перемещает индексатор в начало матрицы<br/> |
| [SetColumn(int, Column&lt;T&gt;)](MathExtended_Matrices_BaseMatrix_T__SetColumn(int_MathExtended_Matrices_Structures_Columns_Column_T_).md 'MathExtended.Matrices.BaseMatrix&lt;T&gt;.SetColumn(int, MathExtended.Matrices.Structures.Columns.Column&lt;T&gt;)') | Задает столбец матрицы по индексу<br/> |
| [SetColumns(Column&lt;T&gt;[])](MathExtended_Matrices_BaseMatrix_T__SetColumns(MathExtended_Matrices_Structures_Columns_Column_T___).md 'MathExtended.Matrices.BaseMatrix&lt;T&gt;.SetColumns(MathExtended.Matrices.Structures.Columns.Column&lt;T&gt;[])') | Задает столбцы матрицы<br/> |
| [SetRow(Row&lt;T&gt;, int)](MathExtended_Matrices_BaseMatrix_T__SetRow(MathExtended_Matrices_Structures_Rows_Row_T__int).md 'MathExtended.Matrices.BaseMatrix&lt;T&gt;.SetRow(MathExtended.Matrices.Structures.Rows.Row&lt;T&gt;, int)') | Задает строку матрицы по заданному индексу<br/> |
| [SetRows(Row&lt;T&gt;[])](MathExtended_Matrices_BaseMatrix_T__SetRows(MathExtended_Matrices_Structures_Rows_Row_T___).md 'MathExtended.Matrices.BaseMatrix&lt;T&gt;.SetRows(MathExtended.Matrices.Structures.Rows.Row&lt;T&gt;[])') | Задает строки матрицы<br/> |
| [ToArray()](MathExtended_Matrices_BaseMatrix_T__ToArray().md 'MathExtended.Matrices.BaseMatrix&lt;T&gt;.ToArray()') | Преобразует матрицу в двумерный массив<br/> |
