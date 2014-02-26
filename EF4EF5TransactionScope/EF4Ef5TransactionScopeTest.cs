using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Common;
using System.Transactions;
using System.Data.EntityClient;

namespace UnitTestProject1
{
    /// <summary>
    /// Como hacer que puedan convivir EF4 y EF5 dentro de una misma TransactionScope
    /// sin hace que se promueva a transacción distribuida, por lo que por ejemplo,
    /// no funcionaría en Azure
    /// </summary>
    [TestClass]
    public class EF4Ef5TransactionScopeTest
    {

        [TestInitialize]
        public void Init()
        {
            using (var ctx = new Model1Container1())
            using (var dbCtx = new MyDbContext())
            {
                ctx.DeleteDatabase();
                ctx.CreateDatabase();
                //ctx.Database.Delete();
                //ctx.Database.Create();
                dbCtx.Database.Delete();
                dbCtx.Database.Create();
            }
        }
        //[TestMethod]
        //public void TestMethod1()
        //{
        //    using (var ctx = new Model1Container1())
        //    {

        //        ctx.Entity1Set.Add(new Entity1() { Id = 1, Property1 = "HolaMostro" });
        //        ctx.SaveChanges();
        //    }
        //}

        [TestMethod]
        public void When_Share_Connection_Then_No_Distributed_Transaction_Promoted()
        {
            using (var tx = new TransactionScope())
            using (var ctx = new Model1Container1())
            using (var dbCtx = new MyDbContext((ctx.Connection as EntityConnection).StoreConnection))
            //using (var dbCtx = new MyDbContext())
            {
               
                
                //ctx.Entity1Set.Add(new Entity1() { Id = 1, Property1 = "HolaMostro" });
                ctx.Entity1Set.AddObject(new Entity1() { Id = 1, Property1 = "HolaMostro" });
                
                dbCtx.MyDbEntities.Add(new MyDbEntity() { Id = "1", TheProperty = "TheP" });

                ctx.SaveChanges();
                dbCtx.SaveChanges();
                tx.Complete();
            }
        }
    }
}
