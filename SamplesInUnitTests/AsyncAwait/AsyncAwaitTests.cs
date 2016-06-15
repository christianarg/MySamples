using System;
using System.IO;
using System.Runtime.Serialization;
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

        [TestMethod]
        public void ReadSync()
        {
            var data = ReadStringAsync().Result;
            Assert.AreEqual(data, "Prueba");
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

        [TestMethod]
        public async Task HandleExceptionAsync()
        {
            bool hapetao = false;
            try
            {
                var data = await PetarAsync();
            }
            catch (MyCustomTestException cex)
            {
                Assert.Fail("Por aqui lamentablemente NO pasa");
            }
            catch (Exception ex)
            {
                hapetao = true;
                Assert.IsTrue(ex is AggregateException);
                Assert.IsTrue(ex.InnerException is MyCustomTestException);
            }
            Assert.IsTrue(hapetao);
        }

        [TestMethod]
        public void HandleExceptionAsync2()
        {
            var task = PetarAsync();
            task.Wait();
            var result = task.Result;
        }

        private async Task<string> PetarAsync()
        {
            var task = Task<string>.Factory.StartNew(() =>
            {
                throw new MyCustomTestException();
            });
            return task.Result;
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

    [Serializable]
    public class MyCustomTestException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public MyCustomTestException()
        {
        }

        public MyCustomTestException(string message) : base(message)
        {
        }

        public MyCustomTestException(string message, Exception inner) : base(message, inner)
        {
        }

        protected MyCustomTestException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
