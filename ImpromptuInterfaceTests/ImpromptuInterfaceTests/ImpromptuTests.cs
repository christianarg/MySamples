using System;
using System.Dynamic;
using ImpromptuInterface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImpromptuInterfaceTests
{
    [TestClass]
    public class ImpromptuTests
    {
        [TestMethod]
        public void ExpandoForlerdosTest()
        {
            var expando = CreateExpando();

            Assert.AreEqual("Hola", expando.El);
            Assert.AreEqual("Mostru", expando.Cosito);
            Assert.AreEqual("HolaMostru", expando.Toma());
        }

        [TestMethod]
        public void ActLikeTest()
        {
            var expando = CreateExpando();

            IMyCoso micoso = Impromptu.ActLike<IMyCoso>(expando);
            Assert.AreEqual("Hola", micoso.El);
            Assert.AreEqual("Mostru", micoso.Cosito);
            Assert.AreEqual("HolaMostru", micoso.Toma());
        }

        private static dynamic CreateExpando()
        {
            dynamic expando = new ExpandoObject();
            expando.El = "Hola";
            expando.Cosito = "Mostru";
            expando.Toma = new Func<string>(() => { return expando.El + expando.Cosito; });
            return expando;
        }
    }

    public interface IMyCoso
    {
        string El { get; set; }
        string Cosito { get; set; }
        string Toma();
    }


}
