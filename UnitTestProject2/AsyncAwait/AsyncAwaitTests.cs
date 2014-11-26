using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace SamplesTestProyect.AsyncAwait
{
    [TestClass]
    public class AsyncAwaitTests
    {

        [TestMethod]
        public async Task UltraSimpleAsyncTest()
        {
            var data = await ReadStringAsync();
            Assert.AreEqual(data, "Prueba");
            Directory.GetCurrentDirectory();
        }

        private async Task<string> ReadStringAsync()
        {
            var task = Task.Factory.StartNew(() => "Prueba");

            return task.Result;
        }

        [TestMethod]
        public async Task TestReadFileAsync()
        {
            var data = await ReadFileAsync();
            Assert.AreEqual(data, "Texto de ejemplo");
            Directory.GetCurrentDirectory();
        }

        private async Task<string> ReadFileAsync()
        {
            using (var reader = new StreamReader("AsyncAwait\\ejemplo.txt"))
            {
                string data = await reader.ReadToEndAsync();
                return data;
            }
        }


       

    }
}
