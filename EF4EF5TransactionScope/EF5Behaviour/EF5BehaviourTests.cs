using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1.EF5Behaviour
{
    [TestClass]
    public class EF5BehaviourTests
    {
        [TestInitialize]
        public void Init()
        {
            using (var ctx = new EF5BehaviourDbContext())
            {
                ctx.Database.Delete();
                ctx.Database.Create();

                ctx.SaveChanges();
            }
        }

        [TestMethod]
        public void When_DetailAddedToMaster_Then_DetailFoundInDbContenxtChangeTracker()
        {
            // ARRANGE
            using (var ctx = new EF5BehaviourDbContext())
            {
                var master = CreateMasterAndAddDetail(ctx);

                // ASSERT

                // Found In ChangeTracker
                Assert.IsTrue(ctx.ChangeTracker.Entries().Any(e => e.Entity == master.Details.First()), "Detail not found in ChnageTracker");
            }
        }

        private static Master CreateMasterAndAddDetail(EF5BehaviourDbContext ctx)
        {
            var master = new Master() {Id = 1};
            ctx.MasterModel.Add(master);

            // ACT
            master.Details = new List<Detail>()
            {
                new Detail()
                {
                    Id = 1
                }
            };
            return master;
        }


        [TestMethod]
        public void When_DetailAddedToMaster_Then_Detail_NOT_FoundInObjectStateManager()
        {
            // ARRANGE
            using (var ctx = new EF5BehaviourDbContext())
            {
                var master = CreateMasterAndAddDetail(ctx);
                var yeOldeObjectContext = ((IObjectContextAdapter)ctx).ObjectContext;

                // A diferencia del ChangeTracker, el ObjectStateManager no encuentra
                // el objeto detalle añadido al objeto master
                Assert.IsFalse(ExistInObjectStateManager(yeOldeObjectContext, master.Details.First()));
            }
        }


        [TestMethod]
        public void When_DetailAddedToMaster_And_CallDetectChanged_Then_Detail_NOT_FoundInObjectStateManager()
        {
            // ARRANGE
            using (var ctx = new EF5BehaviourDbContext())
            {
                var master = CreateMasterAndAddDetail(ctx);
                var yeOldeObjectContext = ((IObjectContextAdapter)ctx).ObjectContext;

                yeOldeObjectContext.DetectChanges();
                Assert.IsTrue(ExistInObjectStateManager(yeOldeObjectContext, master.Details.First()));
            }
        }

        private static IEnumerable<ObjectStateEntry> GetObjectStateEntries(ObjectContext yeOldeObjectContext)
        {
            return yeOldeObjectContext.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Deleted | EntityState.Modified | EntityState.Unchanged);
        }

        private static bool ExistInObjectStateManager(ObjectContext yeOldeObjectContext, object @object)
        {
            return GetObjectStateEntries(yeOldeObjectContext).Any(e => e.Entity == @object);
        }
    }
}
