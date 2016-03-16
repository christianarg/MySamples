using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SamplesTestProyect.Iterator
{
    public class Content
    {
        public List<ContentLanguage> ContentLanguages { get; set; }
    }

    public class ContentLanguage
    {
        public Locking Locking { get; set; }
        public Publishing Publishing { get; set; }
    }

    public class Locking
    {
        
    }

    public class Publishing
    {
    }

    public class ContentGraphIterator : IEnumerable
    {
        private Content content;
        
        public ContentGraphIterator(Content content)
        {
            this.content = content;    
        }
        public IEnumerator GetEnumerator()
        {
            yield return content;
            foreach (var lang  in content.ContentLanguages)
            {
                yield return lang;
                yield return lang.Locking;
                yield return lang.Publishing;
            }
        }
    }
   
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            var content2 = new Content();
            var languages = new List<ContentLanguage>();
            content2.ContentLanguages = languages;
            
            var lang1 = new ContentLanguage();
            languages.Add(lang1);

            var lockingLang1 = new Locking();
            var pubLang1 = new Publishing();
            lang1.Locking = lockingLang1;
            lang1.Publishing = pubLang1;

            var iterator = new ContentGraphIterator(content2);
            var iteratedItems = new List<object>();

            foreach (var item in iterator)
            {
                iteratedItems.Add(item);
            }

            Assert.IsTrue(iteratedItems.Contains(content2));
            Assert.IsTrue(iteratedItems.Contains(lang1));
            Assert.IsTrue(iteratedItems.Contains(lockingLang1));
            Assert.IsTrue(iteratedItems.Contains(pubLang1));

        }
    }
}
