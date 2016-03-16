using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamplesTestProyect.Common;
using System.Linq;

namespace SamplesTestProyect.Linq
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void DenormalizeAndQuery()
        {
            var denormalizedProperties = DenormalizeProperties();
            var result = denormalizedProperties
                                        .Where(dp => dp.ContentName == "Name1")
                                        .OrderBy(dp => dp.PropertyValue).ToList();

            Assert.AreEqual(2,result.Count);
            var prop1 = result[0];
            Assert.AreEqual("Val1",prop1.PropertyValue);
            var prop2 = result[1];
            Assert.AreEqual("Val2", prop2.PropertyValue);

        }

        private List<DenormalizedProperty> DenormalizeProperties()
        {
            var result = new List<DenormalizedProperty>();

            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var content in TestData.contents)
            {
                // ReSharper disable once LoopCanBeConvertedToQuery
                foreach (var property in content.Properties)
                {
                    result.Add(new DenormalizedProperty()
                    {
                        ContentId = content.Id,
                        ContentName = content.Name,
                        PropertyName = property.Name,
                        PropertyValue = property.Value

                    });
                }
            }
            return result;
        }
    }

    public class DenormalizedProperty
    {
        public string ContentId { get; set; }
        public string ContentName { get; set; }
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }
    }
}
