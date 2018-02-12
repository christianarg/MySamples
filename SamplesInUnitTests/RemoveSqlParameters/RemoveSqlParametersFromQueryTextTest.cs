using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SamplesTestProyect.RemoveSqlParameters
{
    [TestClass]
    public class RemoveSqlParametersFromQueryTextTest
    {
        [TestMethod]
        public void RemoveParameterFromQueryTest()
        {
            // ASSERT
            string text = "(@P0 nvarchar(4000), @P1 nvarchar(4000), @P2 int, @P3 int, @P4 int)SELECT a.id,b.warehouseId, z.firstName from coso where kk = (select id from trololo)";
            // ACT
            var result = RemoveParametersFromQueryText(text);
            // ARRANGE
            Assert.AreEqual("SELECT a.id,b.warehouseId, z.firstName from coso where kk = (select id from trololo)", result);
        }

        [TestMethod]
        public void QueryWithoutParameterTest()
        {
            // ASSERT
            string text = "(@P0 nvarchar(4000), @P1 nvarchar(4000), @P2 int, @P3 int, @P4 int)SELECT a.id,b.warehouseId, z.firstName from coso where kk = (select id from trololo)";
            // ACT
            var result = RemoveParametersFromQueryText(text);
            // ARRANGE
            Assert.AreEqual("SELECT a.id,b.warehouseId, z.firstName from coso where kk = (select id from trololo)", result);
        }

        /// <summary>
        /// Función cutrilla para si nos viene una query de una dmv quitarle los parámetros que vienen al inicio para ver más fácilmente la query
        /// </summary>
        /// <param name="queryTextWithParams"></param>
        /// <returns></returns>
        public static string RemoveParametersFromQueryText(string queryTextWithParams)
        {
            // Asumimos que no empieza por parámetros
            if (!queryTextWithParams.StartsWith("(@"))
                return queryTextWithParams;

            char currentChar;
            bool found = false;
            int n = 2; // Nos saltamos el (@ que tienen los parámetros
            int lastParamParentesisPosition = -1;
            bool hasInnerOpenedParentesis = false;

            while (!found && n < queryTextWithParams.Length)
            {
                currentChar = queryTextWithParams[n];
                if (currentChar == '(')
                {
                    hasInnerOpenedParentesis = true;
                }
                else if (currentChar == ')')
                {
                    if (!hasInnerOpenedParentesis)
                    {
                        found = true;
                        lastParamParentesisPosition = n;
                    }
                    else
                    {
                        hasInnerOpenedParentesis = false;
                    }
                }

                n++;
            }

            return queryTextWithParams.Remove(0, lastParamParentesisPosition + 1);
        }
    }
}
