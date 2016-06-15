using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using StackExchange.Redis;
using SamplesTestProyect.Common;

namespace SamplesTestProyect.Redis
{
    [TestClass]
    public class RedisTest
    {
        readonly ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("");
        IDatabase db;

        [TestInitialize]
        public void TestInit()
        {
            db = redis.GetDatabase();
            var server = redis.GetServer("");
            server.FlushDatabase();
            //.FlushAllDatabases();
        }

        [TestMethod]
        public void HelloWorld()
        {
            db.StringSet("myKey", "Hello World");

            var value = db.StringGet("myKey");
            Assert.AreEqual("Hello World", value.ToString());
        }

        [TestMethod]
        public void StoreObjectTest()
        {
            db.Set("myHash", new MyClass()
            {
                Id = "pepe",
                MyValue = "MyValue"
            });

            var myClass = db.Get<MyClass>("myHash");

            Assert.IsNotNull(myClass);
            Assert.AreEqual("pepe",myClass.Id);
            Assert.AreEqual("MyValue", myClass.MyValue);
        }


        [TestMethod]
        public void InvalidateDependencies()
        {
            // ARRANGE
            //db.fl
            db.SetAdd("Contents", "Contents-1");

            db.Set("Contents-1", new MyClass()
            {
                Id = "1",
                MyValue = "MyValue"
            });
            db.SetAdd("Contents", "Contents-1");

            db.Set("Contents-2", new MyClass()
            {
                Id = "2",
                MyValue = "MyValue2"
            });
            db.SetAdd("Contents", "Contents-2");

            db.Set("Contents-3", new MyClass()
            {
                Id = "3",
                MyValue = "MyValue3"
            });
            db.SetAdd("Contents", "Contents-3");

            // comprobar precondición
            var contents2 = db.Get<MyClass>("Contents-2");
            Assert.IsNotNull(contents2);

            // ACT
            var values = db.SetMembers("Contents");
            foreach (var val in values)
            {
                db.KeyDelete(val.ToString());
                db.SetRemove("Contents", val);
            }

            // ASSERT
            Assert.IsNull(db.Get<MyClass>("Contents-1"));
            Assert.IsNull(db.Get<MyClass>("Contents-2"));
            Assert.IsNull(db.Get<MyClass>("Contents-3"));
            Assert.AreEqual(0, db.SetMembers("Contents").Length);
        }

        public void ListTest()
        {
            db.ListRightPush("contents", JsonConvert.SerializeObject(TestData.contents[0]));
        }
    }

    public class MyClass
    {
        public string Id { get; set; }
        public string MyValue { get; set; }
    }

    public static class RedisExtensions
    {
        public static T Get<T>(this IDatabase cache, string key)
        {
            var data = cache.StringGet(key);
            if (data.IsNull)
                return default(T);
            return JsonConvert.DeserializeObject<T>(data);
        }

        public static object Get(this IDatabase cache, string key)
        {
            return JsonConvert.DeserializeObject<object>(cache.StringGet(key));
        }

        public static void Set(this IDatabase cache, string key, object value)
        {
            cache.StringSet(key, JsonConvert.SerializeObject(value));
        }
    }
}
