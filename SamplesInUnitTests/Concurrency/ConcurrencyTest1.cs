using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SamplesTestProyect.Concurrency
{
    [TestClass]
    public class UnitTest1
    {

        [TestInitialize]
        public void Init()
        {
            using (var ctx = new TestDbContext())
            {
                ctx.Database.ExecuteSqlCommand("Delete from Contents");
                //ctx.Database.Delete();
                //ctx.Database.Create();
            }
        }
        static bool HaPetado = true;
        private const string id = "id";

        [TestMethod]
        public void TestConcurrencyException()
        {
            using (var tx = CreateTransactionScope())
            using (var ctx = new TestDbContext())
            {
                var content = ctx.Contents.SingleOrDefault(c => c.Id == id);
                
                Task.Factory.StartNew(TransaccionEnElMedio);
                Thread.Sleep(2000);

                if (content == null)
                {
                    ctx.Contents.Add(CreateContent(id));
                }
                try
                {
                    ctx.SaveChanges();
                    tx.Complete();
                }
                catch (Exception ex) 
                {
                    Debug.WriteLine(string.Format("Transacción principal ha fallado",ex.ToString()));
                    throw;
                }
            }
            Assert.IsFalse(HaPetado);
        }
        

        private static void TransaccionEnElMedio()
        {
            using (var tx = CreateTransactionScope())
            using (var ctx = new TestDbContext())
            {
                try
                {
                    var content = ctx.Contents.SingleOrDefault(c => c.Id == id);
                    if (content == null)
                    {
                        ctx.Contents.Add(CreateContent(id));
                    }
                    ctx.SaveChanges();
                    tx.Complete();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(string.Format("TransaccionEnElMedio ha fallado", ex.ToString()));

                    throw;
                }
                HaPetado = false;
            }
        }


        private static TransactionScope CreateTransactionScope()
        {
            //return new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.Snapshot });
            return new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.RepeatableRead });
        }

        private static Content CreateContent(string id)
        {
            return new Content() { Id = id, Name = "Hola paco" + id.ToString() };
        }

        [TestMethod]
        public void MyTestMethod()
        {

            Task.Factory.StartNew(() =>
            {
                var mut = new Mutex(true, "translation");
                mut.WaitOne();
            });
            Thread.Sleep(500);
            var mutex = Mutex.OpenExisting("translation");
            Assert.IsNotNull(mutex);
        }
    }
}
