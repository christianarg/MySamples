using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplesTestProyect.Common
{

    public class Content
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public List<Property> Properties { get; set; }
    }

    public class Property
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    class TestData
    {
        static TestData()
        {
            TestData.contents.Add(new Content()
            {
                Id = "id1",
                Name = "Name1",
                Properties = new List<Property>()
                {
                    new Property(){Name = "prop1",Value = "Val1"},
                    new Property(){Name = "prop2",Value = "Val2"}
                }
            });

            TestData.contents.Add(new Content()
            {
                Id = "id2",
                Name = "Name3",
                Properties = new List<Property>()
                {
                    new Property(){Name = "prop1",Value = "Val3"},
                    new Property(){Name = "prop2",Value = "Val4"}
                }
            });
        }
        public static List<Content> contents = new List<Content>();
    }
}
