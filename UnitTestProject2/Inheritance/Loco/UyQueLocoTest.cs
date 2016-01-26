using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamplesTestProyect.Inheritance.Loco.Common;
using SamplesTestProyect.Inheritance.Loco.WriteModel;
using SamplesTestProyect.Inheritance.Loco.ReadModel;

namespace SamplesTestProyect.Inheritance
{
    [TestClass]
    public class UyQueLocoTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var readModelMaster = new MyReadModelMaster();
            readModelMaster.Detail = new MyReadModelDetail { DetailData = "Hola paco" };
            readModelMaster.GetDetail<MyReadModelDetail>();
            //readModelMaster.GetDetail<MyWriteModelDetail>(); // Fail. Esto es lo que no quiero que me deje hacer

            IMasterCommon masterCommon = readModelMaster;
            IMyReadModelMaster ireadModelMaster = readModelMaster;

        }
    }

}
