#### [MathExtended](index.md 'index')
### [MathExtended.Interfaces](MathExtended_Interfaces.md 'MathExtended.Interfaces')
## IMatrix&lt;T&gt; Interface
Определяет основную структуру матрицы  
```csharp
public interface IMatrix<T>
    where T : System.IComparable, System.IFormattable, System.IConvertible, System.IComparable<T>, System.IEquatable<T>
```
#### Type parameters
<a name='MathExtended_Interfaces_IMatrix_T__T'></a>
`T`  
Числовой тип
  

Derived  
&#8627; [BaseMatrix&lt;T&gt;](MathExtended_Matrices_BaseMatrix_T_.md 'MathExtended.Matrices.BaseMatrix&lt;T&gt;')  

| Properties | |
| :--- | :--- |
| [ColumnsCount](MathExtended_Interfaces_IMatrix_T__ColumnsCount.md 'MathExtended.Interfaces.IMatrix&lt;T&gt;.ColumnsCount') | Количество столбцов<br/> |
| [MainDiagonal](MathExtended_Interfaces_IMatrix_T__MainDiagonal.md 'MathExtended.Interfaces.IMatrix&lt;T&gt;.MainDiagonal') | Главная диагональ<br/> |
| [RowsCount](MathExtended_Interfaces_IMatrix_T__RowsCount.md 'MathExtended.Interfaces.IMatrix&lt;T&gt;.RowsCount') | Метод нахождения диагонали<br/> |
| [this[int, int]](MathExtended_Interfaces_IMatrix_T__this_int_int_.md 'MathExtended.Interfaces.IMatrix&lt;T&gt;.this[int, int]') | Индесатор матрицы, получает ячейку в соответсвии с ее адресом в матрице<br/> |
