using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathExtended.Exceptions;

namespace MathExtended
{
    public static class MathExtendent
    {
        public enum PowerOfTrigonometry
        {
            Square = 2,
            Cube = 3,
            Fourth = 4

        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="x"></param>
        /// <returns>Возвращает cэканс x</returns>
        public static double Sec(double x)
        {
            
            return 1 / Math.Cos(x);

        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="x"></param>
        /// <returns>Возвращает коcэканс x</returns>
        public static double Cosec(double x)
        {
            return 1 / Math.Sin(x);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns>Котангенс x</returns>
        public static double Cottan(double x)
        {

            return Math.Cos(x) / Math.Sin(x);
        }

    }

    public class Matrixatrix
    {
        private double maindiagonal;

        private double[,] matrix;

        public double MatrixainDiagonal
        {
            get
            {
                return maindiagonal;
            }

        }

        public double[,]Matrix 
        {
            get => matrix;

            set => matrix = value;
        }

        public Matrixatrix(int size)
        {
            matrix = new double[size,size];
        }

        public Matrixatrix(int rows,int collums)
        {
            matrix = new double[rows,collums];
        }
        #region Matrixatrix Sum

        /// <summary>
        /// Суммирует две матрицы и возвращает 3-ю
        /// </summary>
        /// <param name="matrixA"></param>
        /// <param name="matrixB"></param>
        /// <returns>Сумма A и B</returns>
        public static double[,] SumMatrixatrix(double[,] matrixA,double[,] matrixB)
        {
            var matrixC = new double[matrixA.GetLength(0), matrixB.GetLength(0) - 1];
            
            double[,] summedmatrix = new double[matrixA.GetLength(0),matrixB.GetLength(0)];
           
            if ((matrixA.GetLength(0) != matrixB.GetLength(0)) || (matrixA.GetLength(0) != matrixB.GetLength(0)))
            {
                throw new MatrixDifferentSizeException();
            }

           
            for (var i = 0; i < matrixA.GetLength(0); i++)
            {
                for (var j = 0; j < matrixB.GetLength(0); j++)
                {
                    summedmatrix[i,j] = matrixA[i, j] + matrixB[i, j];
                }
            }

            return summedmatrix;
        }

        public static Matrixatrix operator +(Matrixatrix matrixA, Matrixatrix matrixB)
        {
            var matrixC = new double[matrixA.Matrix.GetLength(0), matrixB.Matrix.GetLength(0) - 1];

            Matrixatrix summedmatrix = new Matrixatrix(matrixA.Matrix.GetLength(0), matrixB.Matrix.GetLength(0));

            if ((matrixA.Matrix.GetLength(0) != matrixB.Matrix.GetLength(0)) || (matrixA.Matrix.GetLength(0) != matrixB.Matrix.GetLength(0)))
            {
                throw new MatrixDifferentSizeException();
            }


            for (var i = 0; i < matrixA.Matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrixB.Matrix.GetLength(0); j++)
                {
                    summedmatrix.Matrix[i, j] = matrixA.Matrix[i, j] + matrixB.Matrix[i, j];
                }
            }

            return summedmatrix;
        }

        #endregion

        #region Matrixatrix Substraction
        public static double[,] SubtractionMatrixatrix(double[,] matrixA, double[,] matrixB)
        {
            var matrixC = new double[matrixA.GetLength(0), matrixB.GetLength(0) - 1];

            double[,] summedmatrix = new double[matrixA.GetLength(0), matrixB.GetLength(0)];

            if ((matrixA.GetLength(0) != matrixB.GetLength(0)) || (matrixA.GetLength(0) != matrixB.GetLength(0)))
            {
                throw new Exception("Matrixatrix different size");
            }


            for (var i = 0; i < matrixA.GetLength(0); i++)
            {
                for (var j = 0; j < matrixB.GetLength(0); j++)
                {
                    summedmatrix[i, j] = matrixA[i, j] + matrixB[i, j];
                }
            }

            return summedmatrix;
        }

        public static Matrixatrix operator - (Matrixatrix matrixA, Matrixatrix matrixB)
        {
            var matrixC = new double[matrixA.Matrix.GetLength(0), matrixB.Matrix.GetLength(0) - 1];

            Matrixatrix summedmatrix = new Matrixatrix(matrixA.Matrix.GetLength(0), matrixB.Matrix.GetLength(0));

            if ((matrixA.Matrix.GetLength(0) != matrixB.Matrix.GetLength(0)) || (matrixA.Matrix.GetLength(0) != matrixB.Matrix.GetLength(0)))
            {
                throw new Exception("Matrixatrix different size");
            }


            for (var i = 0; i < matrixA.Matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrixB.Matrix.GetLength(0); j++)
                {
                    summedmatrix.Matrix[i, j] = matrixA.Matrix[i, j] - matrixB.Matrix[i, j];
                }
            }

            return summedmatrix;
        }

        #endregion
    }

}
