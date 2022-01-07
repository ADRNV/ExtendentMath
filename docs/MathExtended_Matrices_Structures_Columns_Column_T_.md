#### [MathExtended](index.md 'index')
### [MathExtended.Matrices.Structures.Columns](MathExtended_Matrices_Structures_Columns.md 'MathExtended.Matrices.Structures.Columns')
## Column&lt;T&gt; Class
Описывает столбец матрицы  
```csharp
public class Column<T> : MathExtended.Matrices.Structures.CellsCollection.BaseCellsCollection<T>
    where T : System.IComparable, System.IFormattable, System.IConvertible, System.IComparable<T>, System.IEquatable<T>
```
#### Type parameters
<a name='MathExtended_Matrices_Structures_Columns_Column_T__T'></a>
`T`  
Тип содержимого строки
  

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [MathExtended.Matrices.Structures.CellsCollection.BaseCellsCollection&lt;](MathExtended_Matrices_Structures_CellsCollection_BaseCellsCollection_T_.md 'MathExtended.Matrices.Structures.CellsCollection.BaseCellsCollection&lt;T&gt;')[T](MathExtended_Matrices_Structures_Columns_Column_T_.md#MathExtended_Matrices_Structures_Columns_Column_T__T 'MathExtended.Matrices.Structures.Columns.Column&lt;T&gt;.T')[&gt;](MathExtended_Matrices_Structures_CellsCollection_BaseCellsCollection_T_.md 'MathExtended.Matrices.Structures.CellsCollection.BaseCellsCollection&lt;T&gt;') &#129106; Column&lt;T&gt;  

| Constructors | |
| :--- | :--- |
| [Column(int)](MathExtended_Matrices_Structures_Columns_Column_T__Column(int).md 'MathExtended.Matrices.Structures.Columns.Column&lt;T&gt;.Column(int)') | Создает столбец с указанными размерами<br/> |
| [Column(T[])](MathExtended_Matrices_Structures_Columns_Column_T__Column(T__).md 'MathExtended.Matrices.Structures.Columns.Column&lt;T&gt;.Column(T[])') | Создает столбец на основе массива<br/> |

| Methods | |
| :--- | :--- |
| [Transponate()](MathExtended_Matrices_Structures_Columns_Column_T__Transponate().md 'MathExtended.Matrices.Structures.Columns.Column&lt;T&gt;.Transponate()') | Транспонирует столбец<br/> |

| Operators | |
| :--- | :--- |
| [operator +(Column&lt;T&gt;, Column&lt;T&gt;)](MathExtended_Matrices_Structures_Columns_Column_T__op_Addition(MathExtended_Matrices_Structures_Columns_Column_T__MathExtended_Matrices_Structures_Columns_Column_T_).md 'MathExtended.Matrices.Structures.Columns.Column&lt;T&gt;.op_Addition(MathExtended.Matrices.Structures.Columns.Column&lt;T&gt;, MathExtended.Matrices.Structures.Columns.Column&lt;T&gt;)') | Складывает столбцы<br/> |
| [explicit operator Column&lt;T&gt;(ReadOnlyColumn&lt;T&gt;)](MathExtended_Matrices_Structures_Columns_Column_T__op_ExplicitMathExtended_Matrices_Structures_Columns_Column_T_(MathExtended_Matrices_Structures_Columns_ReadOnlyColumn_T_).md 'MathExtended.Matrices.Structures.Columns.Column&lt;T&gt;.op_Explicit MathExtended.Matrices.Structures.Columns.Column&lt;T&gt;(MathExtended.Matrices.Structures.Columns.ReadOnlyColumn&lt;T&gt;)') | Явно приводит [ReadOnlyColumn&lt;T&gt;](MathExtended_Matrices_Structures_Columns_ReadOnlyColumn_T_.md 'MathExtended.Matrices.Structures.Columns.ReadOnlyColumn&lt;T&gt;') к [Column&lt;T&gt;](MathExtended_Matrices_Structures_Columns_Column_T_.md 'MathExtended.Matrices.Structures.Columns.Column&lt;T&gt;')<br/>Делая пригодным для записи<br/> |
| [explicit operator ReadOnlyColumn&lt;T&gt;(Column&lt;T&gt;)](MathExtended_Matrices_Structures_Columns_Column_T__op_ExplicitMathExtended_Matrices_Structures_Columns_ReadOnlyColumn_T_(MathExtended_Matrices_Structures_Columns_Column_T_).md 'MathExtended.Matrices.Structures.Columns.Column&lt;T&gt;.op_Explicit MathExtended.Matrices.Structures.Columns.ReadOnlyColumn&lt;T&gt;(MathExtended.Matrices.Structures.Columns.Column&lt;T&gt;)') | Явно приводит [Column&lt;T&gt;](MathExtended_Matrices_Structures_Columns_Column_T_.md 'MathExtended.Matrices.Structures.Columns.Column&lt;T&gt;') к [ReadOnlyColumn&lt;T&gt;](MathExtended_Matrices_Structures_Columns_ReadOnlyColumn_T_.md 'MathExtended.Matrices.Structures.Columns.ReadOnlyColumn&lt;T&gt;')<br/>Делая пригодным для записи<br/> |
| [implicit operator Column&lt;T&gt;(T[])](MathExtended_Matrices_Structures_Columns_Column_T__op_ImplicitMathExtended_Matrices_Structures_Columns_Column_T_(T__).md 'MathExtended.Matrices.Structures.Columns.Column&lt;T&gt;.op_Implicit MathExtended.Matrices.Structures.Columns.Column&lt;T&gt;(T[])') | Не явным образом приводит масив к столбцу<br/> |
| [operator *(Column&lt;T&gt;, Row&lt;T&gt;)](MathExtended_Matrices_Structures_Columns_Column_T__op_Multiply(MathExtended_Matrices_Structures_Columns_Column_T__MathExtended_Matrices_Structures_Rows_Row_T_).md 'MathExtended.Matrices.Structures.Columns.Column&lt;T&gt;.op_Multiply(MathExtended.Matrices.Structures.Columns.Column&lt;T&gt;, MathExtended.Matrices.Structures.Rows.Row&lt;T&gt;)') | Умножает столбец на строку<br/> |
| [operator *(Column&lt;T&gt;, T)](MathExtended_Matrices_Structures_Columns_Column_T__op_Multiply(MathExtended_Matrices_Structures_Columns_Column_T__T).md 'MathExtended.Matrices.Structures.Columns.Column&lt;T&gt;.op_Multiply(MathExtended.Matrices.Structures.Columns.Column&lt;T&gt;, T)') | Умножает число на столбец<br/> |
| [operator *(T, Column&lt;T&gt;)](MathExtended_Matrices_Structures_Columns_Column_T__op_Multiply(T_MathExtended_Matrices_Structures_Columns_Column_T_).md 'MathExtended.Matrices.Structures.Columns.Column&lt;T&gt;.op_Multiply(T, MathExtended.Matrices.Structures.Columns.Column&lt;T&gt;)') | Умножает число на столбец<br/> |
| [operator -(Column&lt;T&gt;, Column&lt;T&gt;)](MathExtended_Matrices_Structures_Columns_Column_T__op_Subtraction(MathExtended_Matrices_Structures_Columns_Column_T__MathExtended_Matrices_Structures_Columns_Column_T_).md 'MathExtended.Matrices.Structures.Columns.Column&lt;T&gt;.op_Subtraction(MathExtended.Matrices.Structures.Columns.Column&lt;T&gt;, MathExtended.Matrices.Structures.Columns.Column&lt;T&gt;)') | Вычетает столбцы<br/> |
