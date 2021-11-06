#### [MathExtended](index.md 'index')
### [MathExtended.Matrices.Structures.CellsCollection](MathExtended_Matrices_Structures_CellsCollection.md 'MathExtended.Matrices.Structures.CellsCollection')
## BaseReadOnlyCellsCollection&lt;T&gt; Class
Описывает коллекцию ячеек только для чтения  
```csharp
public abstract class BaseReadOnlyCellsCollection<T> :
System.Collections.Generic.IEnumerator<T>,
System.IDisposable,
System.Collections.IEnumerator
    where T : System.IComparable, System.IFormattable, System.IConvertible, System.IComparable<T>, System.IEquatable<T>
```
#### Type parameters
<a name='MathExtended_Matrices_Structures_CellsCollection_BaseReadOnlyCellsCollection_T__T'></a>
`T`  
Числовой тип
  

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; BaseReadOnlyCellsCollection&lt;T&gt;  

Derived  
&#8627; [MainDiagonal&lt;T&gt;](MathExtended_Matrices_Structures_CellsCollections_MainDiagonal_T_.md 'MathExtended.Matrices.Structures.CellsCollections.MainDiagonal&lt;T&gt;')  
&#8627; [ReadOnlyColumn&lt;T&gt;](MathExtended_Matrices_Structures_Columns_ReadOnlyColumn_T_.md 'MathExtended.Matrices.Structures.Columns.ReadOnlyColumn&lt;T&gt;')  
&#8627; [ReadOnlyRow&lt;T&gt;](MathExtended_Matrices_Structures_Rows_ReadOnlyRow_T_.md 'MathExtended.Matrices.Structures.Rows.ReadOnlyRow&lt;T&gt;')  

Implements [System.Collections.Generic.IEnumerator&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerator-1 'System.Collections.Generic.IEnumerator`1')[T](MathExtended_Matrices_Structures_CellsCollection_BaseReadOnlyCellsCollection_T_.md#MathExtended_Matrices_Structures_CellsCollection_BaseReadOnlyCellsCollection_T__T 'MathExtended.Matrices.Structures.CellsCollection.BaseReadOnlyCellsCollection&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerator-1 'System.Collections.Generic.IEnumerator`1'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable'), [System.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator 'System.Collections.IEnumerator')  

| Constructors | |
| :--- | :--- |
| [BaseReadOnlyCellsCollection(int)](MathExtended_Matrices_Structures_CellsCollection_BaseReadOnlyCellsCollection_T__BaseReadOnlyCellsCollection(int).md 'MathExtended.Matrices.Structures.CellsCollection.BaseReadOnlyCellsCollection&lt;T&gt;.BaseReadOnlyCellsCollection(int)') | Создает коллекцию ячеек только для чтения с указанным размером<br/> |
| [BaseReadOnlyCellsCollection(T[])](MathExtended_Matrices_Structures_CellsCollection_BaseReadOnlyCellsCollection_T__BaseReadOnlyCellsCollection(T__).md 'MathExtended.Matrices.Structures.CellsCollection.BaseReadOnlyCellsCollection&lt;T&gt;.BaseReadOnlyCellsCollection(T[])') | Создает коллецию только для чтения на основе массива<br/> |

| Properties | |
| :--- | :--- |
| [Current](MathExtended_Matrices_Structures_CellsCollection_BaseReadOnlyCellsCollection_T__Current.md 'MathExtended.Matrices.Structures.CellsCollection.BaseReadOnlyCellsCollection&lt;T&gt;.Current') | Текуший элемент<br/> |
| [Size](MathExtended_Matrices_Structures_CellsCollection_BaseReadOnlyCellsCollection_T__Size.md 'MathExtended.Matrices.Structures.CellsCollection.BaseReadOnlyCellsCollection&lt;T&gt;.Size') | Размер коллекции<br/> |
| [this[int]](MathExtended_Matrices_Structures_CellsCollection_BaseReadOnlyCellsCollection_T__this_int_.md 'MathExtended.Matrices.Structures.CellsCollection.BaseReadOnlyCellsCollection&lt;T&gt;.this[int]') | Индексатор.По индексу возвращает значение ячейки<br/> |

| Methods | |
| :--- | :--- |
| [Dispose()](MathExtended_Matrices_Structures_CellsCollection_BaseReadOnlyCellsCollection_T__Dispose().md 'MathExtended.Matrices.Structures.CellsCollection.BaseReadOnlyCellsCollection&lt;T&gt;.Dispose()') | Освобождает использованные ресурсы<br/> |
| [Dispose(bool)](MathExtended_Matrices_Structures_CellsCollection_BaseReadOnlyCellsCollection_T__Dispose(bool).md 'MathExtended.Matrices.Structures.CellsCollection.BaseReadOnlyCellsCollection&lt;T&gt;.Dispose(bool)') | Высвобождает использованные ресурсы<br/> |
| [ForEach(Action&lt;T&gt;)](MathExtended_Matrices_Structures_CellsCollection_BaseReadOnlyCellsCollection_T__ForEach(System_Action_T_).md 'MathExtended.Matrices.Structures.CellsCollection.BaseReadOnlyCellsCollection&lt;T&gt;.ForEach(System.Action&lt;T&gt;)') | Применяет действие ко всем элементам<br/> |
| [GetEnumerator()](MathExtended_Matrices_Structures_CellsCollection_BaseReadOnlyCellsCollection_T__GetEnumerator().md 'MathExtended.Matrices.Structures.CellsCollection.BaseReadOnlyCellsCollection&lt;T&gt;.GetEnumerator()') | Перечислитель<br/> |
| [IsZero()](MathExtended_Matrices_Structures_CellsCollection_BaseReadOnlyCellsCollection_T__IsZero().md 'MathExtended.Matrices.Structures.CellsCollection.BaseReadOnlyCellsCollection&lt;T&gt;.IsZero()') | Проверяет нулевая ли коллекция<br/> |
| [Max()](MathExtended_Matrices_Structures_CellsCollection_BaseReadOnlyCellsCollection_T__Max().md 'MathExtended.Matrices.Structures.CellsCollection.BaseReadOnlyCellsCollection&lt;T&gt;.Max()') | Находит максимальное число среди ячеек<br/> |
| [Min()](MathExtended_Matrices_Structures_CellsCollection_BaseReadOnlyCellsCollection_T__Min().md 'MathExtended.Matrices.Structures.CellsCollection.BaseReadOnlyCellsCollection&lt;T&gt;.Min()') | Находит минимальное число среди ячеек<br/> |
| [MoveNext()](MathExtended_Matrices_Structures_CellsCollection_BaseReadOnlyCellsCollection_T__MoveNext().md 'MathExtended.Matrices.Structures.CellsCollection.BaseReadOnlyCellsCollection&lt;T&gt;.MoveNext()') | Перемещает индексатор на одну позицию вперед<br/> |
| [Reset()](MathExtended_Matrices_Structures_CellsCollection_BaseReadOnlyCellsCollection_T__Reset().md 'MathExtended.Matrices.Structures.CellsCollection.BaseReadOnlyCellsCollection&lt;T&gt;.Reset()') | Перемещает индексатор в начало матрицы<br/> |
