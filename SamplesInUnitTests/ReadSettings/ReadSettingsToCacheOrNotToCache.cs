using System;
using System.Configuration;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SamplesTestProyect.ReadSettings
{
    [TestClass]
    public class ReadSettingsToCacheOrNotToCache
    {
        [TestMethod]
        public void ExecuteTest()
        {
            Console.WriteLine($"{nameof(ConfigurationReader.ReadWithConfigurationManager)}{ConfigurationReader.ReadWithConfigurationManager()}");
            Console.WriteLine($"{nameof(ConfigurationReader.ReadWithLazy)}{ConfigurationReader.ReadWithLazy()}");
            Console.WriteLine($"{nameof(ConfigurationReader.ReadWithLazyWhoopsReadsSettigEveryTimeAnyway)}{ConfigurationReader.ReadWithLazyWhoopsReadsSettigEveryTimeAnyway()}");

        }
    }

    public class ConfigurationReader
    {
        public static Lazy<string> Key2 = new Lazy<string>(() => ConfigurationManager.AppSettings["key2"]);
        public static Lazy<ClassInitializedLazy> Key3Class = new Lazy<ClassInitializedLazy>(() => new ClassInitializedLazy());
        const int numberForExecutions = 1000000;

        public static long ReadWithConfigurationManager()
        {
            var stopWatch = Stopwatch.StartNew();

            for (int i = 0; i < numberForExecutions; i++)
            {
                string setting = ConfigurationManager.AppSettings["key1"];
            }
            stopWatch.Stop();
            return stopWatch.ElapsedMilliseconds;
        }

        public static long ReadWithLazy()
        {
            var stopWatch = Stopwatch.StartNew();

            for (int i = 0; i < numberForExecutions; i++)
            {
                string setting = Key2.Value;
            }
            stopWatch.Stop();
            return stopWatch.ElapsedMilliseconds;
        }

        public static long ReadWithLazyWhoopsReadsSettigEveryTimeAnyway()
        {
            var stopWatch = Stopwatch.StartNew();

            for (int i = 0; i < numberForExecutions; i++)
            {
                string setting = Key3Class.Value.WhoopsReadsSettigEveryTimeAnyway;
            }
            stopWatch.Stop();
            return stopWatch.ElapsedMilliseconds;
        }
    }

    public class ClassInitializedLazy
    {
        public string WhoopsReadsSettigEveryTimeAnyway => ConfigurationManager.AppSettings["key3"];
    }
}
