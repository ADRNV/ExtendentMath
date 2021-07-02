using MathExtended.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathExtended.Interfaces;
using System.Collections;

namespace MathExtended
{
    public class Matrix<T> : IEnumerator<T>
    {
        private T[ ,] matrix;
       
        private T mainDiagonal;
        
        private int rowsCount;
        
        private int collumnsCount;
        
        private bool disposedValue;
        
        private int _position;
        
        private int _position1;  

        public int RowsCount
        {
            get => rowsCount;
        }

        public int CollumnsCount
        {
            get => collumnsCount;
        }


#region IEnumerable
        public T Current
        {
            get
            {
                if (CheckPositionOut(_position,_position1))
                {
                    throw new IndexOutOfRangeException();
                }
                return matrix[_position,_position1];
            }
        }

        object IEnumerator.Current => this.Current;

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var i in matrix)
            {
              yield return i;
            }
        }
        public bool MoveNext()
        {
            if (_position < matrix.GetUpperBound(0) + 1 && _position1 < matrix.Length / matrix.GetUpperBound(1) + 1)
            {
                _position++;
                _position1++;
                return true;
            }
            else
                return false;
        }

        public void Reset()
        {
            _position = -1;
            _position1 = -1;
        }

        #endregion

        public int Lenght
        {
            get => matrix.Length;
        }

        public Matrix(int rows, int collumns)
        {
            rowsCount = rows;

            collumnsCount = collumns;

            matrix = new T[rowsCount,collumns];
        }
       
        private int GetLenght(T[,] matrix)
        {
            return matrix.Length - 1;
        }


        #region Индексатор
        public T this[int index,int index1]
        {
            get
            {
                return matrix[index,index1];
            }
            
            set
            { 
               matrix[index, index1] = value;   
            }
        }
    
        #endregion

        private bool CheckPositionOut(int position, int position1)
        {
            if (position == -1 || position >= matrix.Length || position1 == -1 || position1 >= matrix.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    matrix = null;

                }

                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить метод завершения
                // TODO: установить значение NULL для больших полей
                disposedValue = true;
            }
        }

        // // TODO: переопределить метод завершения, только если "Dispose(bool disposing)" содержит код для освобождения неуправляемых ресурсов
        // ~Matrix()
        // {
        //     // Не изменяйте этот код. Разместите код очистки в методе "Dispose(bool disposing)".
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки в методе "Dispose(bool disposing)".
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
