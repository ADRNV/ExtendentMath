#### [MathExtended](index.md 'index')
### [MathExtended](MathExtended.md 'MathExtended').[MathExtendent](MathExtended_MathExtendent.md 'MathExtended.MathExtendent')
## MathExtendent.TabulateFunction(double, double, double, Func&lt;double,double&gt;, double[], double[]) Method
Проводит табулирование функции  
```csharp
public static void TabulateFunction(double x0, double xk, double dx, System.Func<double,double> func, out double[] xValuesArray, out double[] yValuesArray);
```
#### Parameters
<a name='MathExtended_MathExtendent_TabulateFunction(double_double_double_System_Func_double_double__double___double__)_x0'></a>
`x0` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
Начальное значение
  
<a name='MathExtended_MathExtendent_TabulateFunction(double_double_double_System_Func_double_double__double___double__)_xk'></a>
`xk` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
Максимальное значение
  
<a name='MathExtended_MathExtendent_TabulateFunction(double_double_double_System_Func_double_double__double___double__)_dx'></a>
`dx` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
Шаг
  
<a name='MathExtended_MathExtendent_TabulateFunction(double_double_double_System_Func_double_double__double___double__)_func'></a>
`func` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')  
Табулируемая функции
  
<a name='MathExtended_MathExtendent_TabulateFunction(double_double_double_System_Func_double_double__double___double__)_xValuesArray'></a>
`xValuesArray` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
Массив для значений X
  
<a name='MathExtended_MathExtendent_TabulateFunction(double_double_double_System_Func_double_double__double___double__)_yValuesArray'></a>
`yValuesArray` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
Массив для значений Y
  
