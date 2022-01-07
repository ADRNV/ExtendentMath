#### [MathExtended](index.md 'index')
### [MathExtended.Matrices.Structures.CellsCollection](MathExtended_Matrices_Structures_CellsCollection.md 'MathExtended.Matrices.Structures.CellsCollection')
## BaseCellsCollection&lt;T&gt; Class
Описывает коллекцию ячеек  
```csharp
public class BaseCellsCollection<T> :
System.Collections.Generic.IEnumerator<T>,
System.IDisposable,
System.Collections.IEnumerator
    where T : System.IComparable, System.IFormattable, System.IConvertible, System.IComparable<T>, System.IEquatable<T>
```
#### Type parameters
<a name='MathExtended_Matrices_Structures_CellsCollection_BaseCellsCollection_T__T'></a>
`T`  
Числовой тип
  

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; BaseCellsCollection&lt;T&gt;  

Derived  
&#8627; [Column&lt;T&gt;](MathExtended_Matrices_Structures_Columns_Column_T_.md 'MathExtended.Matrices.Structures.Columns.Column&lt;T&gt;')  
&#8627; [Row&lt;T&gt;](MathExtended_Matrices_Structures_Rows_Row_T_.md 'MathExtended.Matrices.Structures.Rows.Row&lt;T&gt;')  

Implements [System.Collections.Generic.IEnumerator&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerator-1 'System.Collections.Generic.IEnumerator`1')[T](MathExtended_Matrices_Structures_CellsCollection_BaseCellsCollection_T_.md#MathExtended_Matrices_Structures_CellsCollection_BaseCellsCollection_T__T 'MathExtended.Matrices.Structures.CellsCollection.BaseCellsCollection&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerator-1 'System.Collections.Generic.IEnumerator`1'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable'), [System.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator 'System.Collections.IEnumerator')  

| Constructors | |
| :--- | :--- |
| [BaseCellsCollection(int)](MathExtended_Matrices_Structures_CellsCollection_BaseCellsCollection_T__BaseCellsCollection(int).md 'MathExtended.Matrices.Structures.CellsCollection.BaseCellsCollection&lt;T&gt;.BaseCellsCollection(int)') | Создает коллекцию с указанным размером<br/> |
| [BaseCellsCollection(T[])](MathExtended_Matrices_Structures_CellsCollection_BaseCellsCollection_T__BaseCellsCollection(T__).md 'MathExtended.Matrices.Structures.CellsCollection.BaseCellsCollection&lt;T&gt;.BaseCellsCollection(T[])') | Создает коллекцию ячеек на основе массива<br/> |

| Properties | |
| :--- | :--- |
| [Cells](MathExtended_Matrices_Structures_CellsCollection_BaseCellsCollection_T__Cells.md 'MathExtended.Matrices.Structures.CellsCollection.BaseCellsCollection&lt;T&gt;.Cells') | Массив ячеек<br/> |
| [Current](MathExtended_Matrices_Structures_CellsCollection_BaseCellsCollection_T__Current.md 'MathExtended.Matrices.Structures.CellsCollection.BaseCellsCollection&lt;T&gt;.Current') | Текуший элемент<br/> |
| [Size](MathExtended_Matrices_Structures_CellsCollection_BaseCellsCollection_T__Size.md 'MathExtended.Matrices.Structures.CellsCollection.BaseCellsCollection&lt;T&gt;.Size') | Размер коллекции<br/> |
| [this[int]](MathExtended_Matrices_Structures_CellsCollection_BaseCellsCollection_T__this_int_.md 'MathExtended.Matrices.Structures.CellsCollection.BaseCellsCollection&lt;T&gt;.this[int]') | Индексатор.По индексу возвращает или задает значение ячейки<br/> |

| Methods | |
| :--- | :--- |
| [Dispose()](MathExtended_Matrices_Structures_CellsCollection_BaseCellsCollection_T__Dispose().md 'MathExtended.Matrices.Structures.CellsCollection.BaseCellsCollection&lt;T&gt;.Dispose()') | Освобождает использованные ресурсы<br/> |
| [Dispose(bool)](MathExtended_Matrices_Structures_CellsCollection_BaseCellsCollection_T__Dispose(bool).md 'MathExtended.Matrices.Structures.CellsCollection.BaseCellsCollection&lt;T&gt;.Dispose(bool)') | Высвобождает использованные ресурсы<br/> |
| [ForEach(Action&lt;T&gt;)](MathExtended_Matrices_Structures_CellsCollection_BaseCellsCollection_T__ForEach(System_Action_T_).md 'MathExtended.Matrices.Structures.CellsCollection.BaseCellsCollection&lt;T&gt;.ForEach(System.Action&lt;T&gt;)') | Применяет действие ко всем элементам<br/> |
| [GetEnumerator()](MathExtended_Matrices_Structures_CellsCollection_BaseCellsCollection_T__GetEnumerator().md 'MathExtended.Matrices.Structures.CellsCollection.BaseCellsCollection&lt;T&gt;.GetEnumerator()') | Перечислитель<br/> |
| [IsZero()](MathExtended_Matrices_Structures_CellsCollection_BaseCellsCollection_T__IsZero().md 'MathExtended.Matrices.Structures.CellsCollection.BaseCellsCollection&lt;T&gt;.IsZero()') | Проверяет нулевая ли коллекция<br/> |
| [Max()](MathExtended_Matrices_Structures_CellsCollection_BaseCellsCollection_T__Max().md 'MathExtended.Matrices.Structures.CellsCollection.BaseCellsCollection&lt;T&gt;.Max()') | Находит максимальное число среди ячеек<br/> |
| [Min()](MathExtended_Matrices_Structures_CellsCollection_BaseCellsCollection_T__Min().md 'MathExtended.Matrices.Structures.CellsCollection.BaseCellsCollection&lt;T&gt;.Min()') | Находит минимальное число среди ячеек<br/> |
| [MoveNext()](MathExtended_Matrices_Structures_CellsCollection_BaseCellsCollection_T__MoveNext().md 'MathExtended.Matrices.Structures.CellsCollection.BaseCellsCollection&lt;T&gt;.MoveNext()') | Перемещает индексатор на одну позицию вперед<br/> |
| [Reset()](MathExtended_Matrices_Structures_CellsCollection_BaseCellsCollection_T__Reset().md 'MathExtended.Matrices.Structures.CellsCollection.BaseCellsCollection&lt;T&gt;.Reset()') | Перемещает индексатор в начало матрицы<br/> |
