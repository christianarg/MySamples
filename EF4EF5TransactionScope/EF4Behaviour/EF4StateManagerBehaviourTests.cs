using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1.EF4Behaviour
{
    [TestClass]
    public class EF4StateManagerBehaviourTests
    {
        [TestMethod]
        public void When_DetailAddedToMaster_Then_DetailIsInObjectStateManager()
        {
            using (var ctx = new Model1Container())
            {
                //ctx.DeleteDatabase();
                ctx.ExecuteStoreCommand("DELETE FROM [EF4DetailSet]");
                ctx.ExecuteStoreCommand("DELETE FROM [EFMasterSet]");

                var master = new EFMaster();
                master.MyProperty = "pepo";
                ctx.EFMasterSet.AddObject(master);

                var detail = new EF4Detail();
                master.EF4Detail.Add(detail);
                Assert.IsTrue(ExistInObjectStateManager(ctx, detail));
                ctx.SaveChanges();

                //ctx.EFMasterSet.a
            }
        }

        [TestMethod]
        public void Given_SurrogateKeys_When_DetailAddedToMaster_Then_DetailIsInObjectStateManager()
        {
            using (var ctx = new Model1Container())
            {
                //ctx.DeleteDatabase();
                ctx.ExecuteStoreCommand("DELETE FROM [EF4SurrogateDetail]");
                ctx.ExecuteStoreCommand("DELETE FROM [EFMasterSurrogate]");

                var master = new EFMasterSurrogate();
                master.MyProperty = "pepo";
                ctx.EFMasterSurrogate.AddObject(master);

                var detail = new EF4SurrogateDetail();
                master.EF4SurrogateDetail.Add(detail);
                Assert.IsTrue(ExistInObjectStateManager(ctx, detail));
                
                ctx.SaveChanges();
            }
        }

        public IEnumerable<ObjectStateEntry> GetObjectStateEntries(ObjectContext ctx)
        {
            return ctx.ObjectStateManager.GetObjectStateEntries(
                EntityState.Added | EntityState.Deleted | EntityState.Modified | EntityState.Unchanged);
        }


        public bool ExistInObjectStateManager<T>(ObjectContext ctx, T entity)
            where T : class
        {
            return GetObjectStateEntries(ctx).Any(e => e.Entity == entity);
        }
    }
}
