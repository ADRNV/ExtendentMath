#### [MathExtended](index.md 'index')
### [MathExtended](MathExtended.md 'MathExtended').[MathExtendent](MathExtended_MathExtendent.md 'MathExtended.MathExtendent')
## MathExtendent.TabulateFunction(double, double, double, Func&lt;double,double&gt;) Method
Проводит табулирование функции  
```csharp
public static MathExtended.TabulateResult TabulateFunction(double x0, double xk, double dx, System.Func<double,double> func);
```
#### Parameters
<a name='MathExtended_MathExtendent_TabulateFunction(double_double_double_System_Func_double_double_)_x0'></a>
`x0` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
Начальное значение
  
<a name='MathExtended_MathExtendent_TabulateFunction(double_double_double_System_Func_double_double_)_xk'></a>
`xk` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
Максимальное значение
  
<a name='MathExtended_MathExtendent_TabulateFunction(double_double_double_System_Func_double_double_)_dx'></a>
`dx` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
Шаг
  
<a name='MathExtended_MathExtendent_TabulateFunction(double_double_double_System_Func_double_double_)_func'></a>
`func` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')  
Табулируемая функции
  
#### Returns
[TabulateResult](MathExtended_TabulateResult.md 'MathExtended.TabulateResult')  
[TabulateResult](MathExtended_TabulateResult.md 'MathExtended.TabulateResult') структура со значениями аргумента и функции
