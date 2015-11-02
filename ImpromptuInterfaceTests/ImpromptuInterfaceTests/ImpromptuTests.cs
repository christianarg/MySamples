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
            dynamic expando = new ExpandoObject();
            expando.El = "Hola";
            expando.Cosito = "Mostru";

            Assert.AreEqual("Hola", expando.El);
            Assert.AreEqual("Mostru", expando.Cosito);
        }

        [TestMethod]
        public void ActLikeTest()
        {
            dynamic expando = new ExpandoObject();
            //dynamic expando = Build<ExpandoObject>.NewObject(El: "Test", Cosito: "Mostru");
            expando.El = "Hola";
            expando.Cosito = "Mostru";

            IMyCoso micoso = Impromptu.ActLike<IMyCoso>(expando);
            Assert.AreEqual("Hola", micoso.El);
            Assert.AreEqual("Mostru", micoso.Cosito);
        }
    }

    public interface IMyCoso
    {
        string El { get; set; }
        string Cosito { get; set; }
    }


}
