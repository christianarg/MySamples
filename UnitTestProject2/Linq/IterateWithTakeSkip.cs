using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SamplesTestProyect.Linq
{
    [TestClass]
    public class IterateWithTakeSkip
    {
        [TestMethod]
        public void Test()
        {
            // ARRANGE
            var myList = new List<int>();
            for (int i = 0; i < 1005; i++)
            {
                myList.Add(i);
            }

            const int cantidadPorTrozo = 100;
            //var result = new List<List<int>>();
            var result = new List<int>();
            // ACT
            for (int i = 0; i < myList.Count; i+=100)
            {
                var amountToSkip = i;
                var skipCountDifference = myList.Count - amountToSkip;

                var ammoutToTake = skipCountDifference < cantidadPorTrozo ? skipCountDifference : cantidadPorTrozo;
                result.AddRange(myList.Skip(amountToSkip).Take(ammoutToTake).ToList());
            }
            // ASSERT
            //Assert.AreEqual(myList.Count / cantidadPorTrozo, result.Count);
            for (int i = 0; i < myList.Count; i++)
            {
                Assert.AreEqual(i, result[i]);
            }
        }
    }
}
