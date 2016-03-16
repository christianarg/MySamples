using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SamplesTestProyect.ExplicitInterface
{
      /// <summary>
      ///  Ver description.txt
      /// </summary>
    public interface ILocalizationAggregate
    {
        bool IsPublished { get;}
        void Publish();
    }

    public class Localization : ILocalizationAggregate
    {
        public bool IsPublished { get; private set; }
        
        void ILocalizationAggregate.Publish()
        {
            IsPublished = true;
        }
    }

    [TestClass]
    public class ExplicitInterfaceTest4
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Este método en realidad haría el "fetch" concreto de la BDD
            var localization = GetLocalization<ILocalizationAggregate>();

            localization.Publish();

            Assert.IsTrue(localization.IsPublished);

        }

        private T GetLocalization<T>()
           where T : class
        {
            var localization = new Localization();
            return localization as T;
        }
    }
}
