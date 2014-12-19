using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;


namespace SamplesTestProyect.Mongo
{
    [TestClass]
    public class MongoTests
    {
        [TestMethod]
        public void CreateAndFindObject()
        {
            const string connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("test");
            var collection = database.GetCollection<MyEntity>("MyEntities");
            var newEntity = new MyEntity { Name = "Tom" };
            collection.Insert(newEntity);

            var query = Query<MyEntity>.EQ(e => e.Id, newEntity.Id);
            var entity = collection.FindOne(query);
            Assert.IsNotNull(entity);
            Assert.AreEqual(newEntity.Name,entity.Name);
        }
    }

    public class MyEntity
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
