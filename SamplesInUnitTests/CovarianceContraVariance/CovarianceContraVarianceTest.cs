using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SamplesTestProyect.CovarianceContraVariance
{
    public interface IData{ }

    public class Data : IData { }

    [TestClass]
    public class CovarianceContraVarianceTest
    {
        List<Data> DataList;
        
        [TestMethod]
        public void CastListOfConcreteClassToInterface_UsingList_ForcesToCast()
        {
            DataList = new List<Data>();
            DataList.Add(new Data());

            List<IData> ilist = DataList.Cast<IData>().ToList();

            Assert.AreEqual(DataList.Single(), ilist.Single());
        }

        [TestMethod]
        public void CastListOfConcreteClassToInterface_UsingIEnumerable_CovarianceAutomatically()
        {
            DataList = new List<Data>();
            DataList.Add(new Data());

            IEnumerable<IData> idataEnum = DataList;

            Assert.AreEqual(DataList.Single(), idataEnum.Single());
        }
    }
}
