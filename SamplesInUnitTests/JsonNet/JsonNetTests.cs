using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SamplesTestProyect.JsonNet
{
    [TestClass]
    public class JsonNetTests
    {
        [TestMethod]
        public void SerializeWithPrivateCtor()
        {
            var theClass = ClassWithPrivateConstructor.createClass("hola mostro", "pepe");
            var theSerializedClass = JsonConvert.SerializeObject(theClass);

            var theDeserializedClass = JsonConvert.DeserializeObject<ClassWithPrivateConstructor>(theSerializedClass);
        }

        [TestMethod]
        public void IgnoreSerializationWithShouldSerializeMethodTest()
        {
            var foo = new ClassWithShouldIgnore { EstaSi = "Yeah", EstaNo = "Puto" };
            var serialized = JsonConvert.SerializeObject(foo);

            var deserialized = JsonConvert.DeserializeObject<ClassWithShouldIgnore>(serialized);
            Assert.AreEqual(foo.EstaSi, deserialized.EstaSi);
            Assert.AreNotEqual(foo.EstaNo, deserialized.EstaNo);
            Assert.IsNull(deserialized.EstaNo);
        }

        [TestMethod]
        public void IgnoreSerializationWithContractResolverMethodTest()
        {
            var foo = new ClassForContractResolver { EstaSi = "Yeah", EstaNo = "Puto" };
            var serialized = JsonConvert.SerializeObject(foo, new JsonSerializerSettings{ContractResolver = new ShouldSerializeContractResolver()});

            var deserialized = JsonConvert.DeserializeObject<ClassForContractResolver>(serialized);
            Assert.AreEqual(foo.EstaSi, deserialized.EstaSi);
            Assert.AreNotEqual(foo.EstaNo, deserialized.EstaNo);
            Assert.IsNull(deserialized.EstaNo);
        }

		[TestMethod]
		public void CamelCasePropertiesTest()
		{
			// ARRANGE
			var foo = new Foo { Bar = "La concha de tu madre" };
			// ACT
			var serializedFoo = JsonConvert.SerializeObject(foo, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
			var deserializedFoo = JsonConvert.DeserializeObject<Foo>(serializedFoo);
			
			// ASSERT
			Assert.IsTrue(serializedFoo.Contains("bar:"));	// La propiedad es camelcase
			Assert.AreEqual(foo.Bar, deserializedFoo.Bar);	// Aunque deserializemos sin pasar el contractResolver, la clase se deserializa correctamente

		}
    }
	public class Foo
	{
		public string Bar { get; set; }
	}

    public class ClassWithShouldIgnore
    {
        public string EstaSi { get; set; }
        public string EstaNo { get; set; }
        public bool ShouldSerializeEstaNo() { return false; }
    }

    public class ClassForContractResolver
    {
        public string EstaSi { get; set; }
        public string EstaNo { get; set; }
    }

    public class ShouldSerializeContractResolver : DefaultContractResolver
    {
        public new static readonly ShouldSerializeContractResolver Instance = new ShouldSerializeContractResolver();
    
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            if (property.DeclaringType == typeof(ClassForContractResolver) && property.PropertyName == "EstaNo")
            {
                property.ShouldSerialize = instance => false;
            }
    
            return property;
        }
    }

    public class ClassWithPrivateConstructor
    {
        public string Property { get; set; }
        public string Property2 { get; set; }
        public static ClassWithPrivateConstructor createClass(string property, string property2)
        {
            return new ClassWithPrivateConstructor(property, property2);
        }

        [JsonConstructor]
        private ClassWithPrivateConstructor(string property, string property2)
        {
            Property = property;
            Property2 = property2;
        }
    }
}
