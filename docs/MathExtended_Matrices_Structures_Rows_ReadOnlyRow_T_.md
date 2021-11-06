#### [MathExtended](index.md 'index')
### [MathExtended.Matrices.Structures.Rows](MathExtended_Matrices_Structures_Rows.md 'MathExtended.Matrices.Structures.Rows')
## ReadOnlyRow&lt;T&gt; Class
Описывает строку только для чтения  
```csharp
public class ReadOnlyRow<T> : MathExtended.Matrices.Structures.CellsCollection.BaseReadOnlyCellsCollection<T>
    where T : System.IComparable, System.IFormattable, System.IConvertible, System.IComparable<T>, System.IEquatable<T>
```
#### Type parameters
<a name='MathExtended_Matrices_Structures_Rows_ReadOnlyRow_T__T'></a>
`T`  
Числовой тип
  

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [MathExtended.Matrices.Structures.CellsCollection.BaseReadOnlyCellsCollection&lt;](MathExtended_Matrices_Structures_CellsCollection_BaseReadOnlyCellsCollection_T_.md 'MathExtended.Matrices.Structures.CellsCollection.BaseReadOnlyCellsCollection&lt;T&gt;')[T](MathExtended_Matrices_Structures_Rows_ReadOnlyRow_T_.md#MathExtended_Matrices_Structures_Rows_ReadOnlyRow_T__T 'MathExtended.Matrices.Structures.Rows.ReadOnlyRow&lt;T&gt;.T')[&gt;](MathExtended_Matrices_Structures_CellsCollection_BaseReadOnlyCellsCollection_T_.md 'MathExtended.Matrices.Structures.CellsCollection.BaseReadOnlyCellsCollection&lt;T&gt;') &#129106; ReadOnlyRow&lt;T&gt;  

| Constructors | |
| :--- | :--- |
| [ReadOnlyRow(int)](MathExtended_Matrices_Structures_Rows_ReadOnlyRow_T__ReadOnlyRow(int).md 'MathExtended.Matrices.Structures.Rows.ReadOnlyRow&lt;T&gt;.ReadOnlyRow(int)') | Создает строку только для чтения определенного размера<br/> |
| [ReadOnlyRow(T[])](MathExtended_Matrices_Structures_Rows_ReadOnlyRow_T__ReadOnlyRow(T__).md 'MathExtended.Matrices.Structures.Rows.ReadOnlyRow&lt;T&gt;.ReadOnlyRow(T[])') | Создает строку только для чтения на основе массива<br/> |

| Operators | |
| :--- | :--- |
| [explicit operator Row&lt;T&gt;(ReadOnlyRow&lt;T&gt;)](MathExtended_Matrices_Structures_Rows_ReadOnlyRow_T__op_ExplicitMathExtended_Matrices_Structures_Rows_Row_T_(MathExtended_Matrices_Structures_Rows_ReadOnlyRow_T_).md 'MathExtended.Matrices.Structures.Rows.ReadOnlyRow&lt;T&gt;.op_Explicit MathExtended.Matrices.Structures.Rows.Row&lt;T&gt;(MathExtended.Matrices.Structures.Rows.ReadOnlyRow&lt;T&gt;)') | Явно приводит [Row&lt;T&gt;](MathExtended_Matrices_Structures_Rows_Row_T_.md 'MathExtended.Matrices.Structures.Rows.Row&lt;T&gt;') к [ReadOnlyRow&lt;T&gt;](MathExtended_Matrices_Structures_Rows_ReadOnlyRow_T_.md 'MathExtended.Matrices.Structures.Rows.ReadOnlyRow&lt;T&gt;')<br/>Делая пригодным для записи<br/> |
