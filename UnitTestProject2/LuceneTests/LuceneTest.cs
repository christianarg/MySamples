using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lucene.Net.Store;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Index;
using System.Linq;
using System.Collections.Generic;
using Lucene.Net.Documents;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Version = Lucene.Net.Util.Version;
using SamplesTestProyect.Common;

namespace SamplesTestProyect.LuceneTests
{
    [TestClass]
    public class LuceneTest
    {
        

        [TestMethod]
        public void TestMethod1()
        {
            //var directory = new RAMDirectory();
            //var analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);
            //var writer = new IndexWriter(directory, analyzer,new IndexWriter.MaxFieldLength(IndexWriter.DEFAULT_MAX_FIELD_LENGTH));

            //var content = contents[0];

            
            //var document = new Document();
            //document .Add(new Field("id",content.Id,Field.Store.YES,Field.Index.NO));
            //document.Add(new Field("Name", content.Name, Field.Store.YES, Field.Index.ANALYZED));
            //content.Properties.ForEach((property) =>
            //{
            //    document.Add(new Field("PropertyName", property.Name, Field.Store.YES, Field.Index.ANALYZED));
            //    document.Add(new Field("PropertyValue", property.Value, Field.Store.YES, Field.Index.NO));
            //});
            //writer.AddDocument(document);
            //writer.Optimize();
            //writer.Flush(true,true,true);
            //writer.Commit();

            //var queryParser = new QueryParser(Version.LUCENE_30, "postBody", analyzer);
            //var query = queryParser.Parse("Val1");
            //var searcher = new IndexSearcher(directory);
            ////searcher.Search(query,new QueryWrapperFilter()


            ////var analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_CURRENT);
            ////analyzer.
        }

       
    }
}
