using System;
using System.Linq;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SamplesTestProyect.ParalellForeach
{
    [TestClass]
    public class ParalellForeachTest
    {
        /// <summary>
        /// Comprobamos que si ponemos el MaxDegreeOfParallelism = 1 se comporta igual que un for
        /// </summary>
        [TestMethod]
        public void ExecuteWithNoParallelism()
        {
            // ARRANGE
            const int numberOfElements = 10;

            var orderedList = InitList(numberOfElements);
            var result = new List<int>();

            // ACT
            Parallel.ForEach(orderedList, new ParallelOptions { MaxDegreeOfParallelism = 1 }, (item) =>
            {
                result.Add(item);
                Console.WriteLine(item);
            });

            // ASSERT
            Assert.IsTrue(orderedList.SequenceEqual(result));
        }

        /// <summary>
        /// Comprobamos que si ponemos el MaxDegreeOfParallelism = 1 se comporta igual que un for
        /// </summary>
        [TestMethod]
        public void ExecuteWithParallelism()
        {
            // ARRANGE
            const int numberOfElements = 10;

            var orderedList = InitList(numberOfElements);
            var result = new List<int>();

            // ACT
            Parallel.ForEach(orderedList, (item) =>
            {
                result.Add(item);
                Console.WriteLine(item);
            });

            // ASSERT
            Assert.IsFalse(orderedList.SequenceEqual(result));
        }

        private static List<int> InitList(int numberOfElements)
        {
            var orderedList = new List<int>();

            for (int i = 0; i < numberOfElements; i++)
            {
                orderedList.Add(i);
            }

            return orderedList;
        }
    }
}
