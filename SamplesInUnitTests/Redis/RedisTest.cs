using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using StackExchange.Redis;
using SamplesTestProyect.Common;
using System.Threading.Tasks;

namespace SamplesTestProyect.Redis
{
    [TestClass]
    public class RedisTest
    {
        const string redisConfiguration = "";
        const string redisServer = "";
        readonly ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(redisConfiguration);
        IDatabase db;

        [TestInitialize]
        public void TestInit()
        {
            db = redis.GetDatabase();
            var server = redis.GetServer(redisServer);
            server.FlushDatabase();
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
            Assert.AreEqual("pepe", myClass.Id);
            Assert.AreEqual("MyValue", myClass.MyValue);
        }


        [TestMethod]
        public void InvalidateDependenciesWithSet()
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

        [TestMethod]
        public void SimpleLua()
        {
            // ARRANGe
            const string Script = "redis.call('set', @key, @value)";
            var prepared = LuaScript.Prepare(Script);
            // ACT
            db.ScriptEvaluate(prepared, new { key = (RedisKey)"mykey", value = 123 });
            // ASSERT
            var value = db.StringGet("mykey");
            Assert.AreEqual("123", value.ToString());
        }

        /// <summary>
        /// Multiple delete atomic:
        /// 
        /// http://stackoverflow.com/questions/4006324/how-to-atomically-delete-keys-matching-a-pattern-using-redis
        /// 
        /// Warning: KEYS puede NO es recomendado ya que es siempre O(N) (lo tiene que recorrer TODO)
        /// http://redis.io/commands/KEYS
        /// </summary>
        [TestMethod]
        public void InvalidateDependenciesWithLua()
        {
            // ARRANGE

            db.Set("Contents-1", new MyClass()
            {
                Id = "1",
                MyValue = "MyValue"
            });

            db.Set("Contents-2", new MyClass()
            {
                Id = "2",
                MyValue = "MyValue2"
            });

            db.Set("Contents-3", new MyClass()
            {
                Id = "3",
                MyValue = "MyValue3"
            });

            // comprobar precondición
            var contents2 = db.Get<MyClass>("Contents-2");
            Assert.IsNotNull(contents2);

            // ACT
            //const string Script = "redis.call('del', unpack(redis.call('keys', 'Contents-*')))";
            //var prepared = LuaScript.Prepare(Script);
            //db.ScriptEvaluate(prepared);

            const string Script = "redis.call('del', unpack(redis.call('keys', @prefix..'*')))";
            var prepared = LuaScript.Prepare(Script);
            db.ScriptEvaluate(prepared, new { prefix = "Contents-" });

            // ASSERT
            Assert.IsNull(db.Get<MyClass>("Contents-1"));
            Assert.IsNull(db.Get<MyClass>("Contents-2"));
            Assert.IsNull(db.Get<MyClass>("Contents-3"));
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
