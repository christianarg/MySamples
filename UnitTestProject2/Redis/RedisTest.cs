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
        readonly ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
        IDatabase db;

        [TestInitialize]
        public void TestInit()
        {
            db = redis.GetDatabase();
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
            return JsonConvert.DeserializeObject<T>(cache.StringGet(key));
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
