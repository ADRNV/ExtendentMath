using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathExtended.Matrices.Structures.CellsCollection;
using MathExtended.Matrices.Structures.CellsCollections;
using Xunit;

namespace MathExtendentTests.Matrices.Structures.CellsCollection
{
    public class BaseСellsCollectionTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(6)]
        public void InitBaseCellsCollection(int size)
        {
            BaseCellsCollection<double> baseСellsCollection = new BaseCellsCollection<double>(size);

            Assert.Equal(size, baseСellsCollection.Size);
        }

        
        [Fact]
        public void InitBaseCellsCollectionWithInvalidSize()
        {
            Assert.Throws<OverflowException>(() =>
            {
               BaseCellsCollection<decimal> baseCellsCollection = new BaseCellsCollection<decimal>(-1);
            });
        }

        [Theory]
        [InlineData(new double[0] { })]
        [InlineData(new double[3] { 1, 2, 3 })]
        [InlineData(new double[6] { 1, 2, 4, 5, 6, 7 })]
        public void InitBaseCellsCollectionByArray(double[] array)
        {
            BaseCellsCollection<double> row = new BaseCellsCollection<double>(array);

            Assert.Equal(array.Length, row.Size);

            Assert.Equal(array, row);
        }
    }
}
