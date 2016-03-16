using SamplesTestProyect.Inheritance.Loco.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplesTestProyect.Inheritance.Loco.ReadModel
{

    public class MyReadModelMaster : IMyReadModelMaster
    {
        public MyReadModelDetail Detail { get; set; }

        IDetailCommon IMasterCommon.Detail => this.Detail;

        public T GetDetail<T>() where T : MyReadModelDetail
        {
            return this.Detail as T;
        }

        T IMasterCommon.GetDetail<T>()
        {
            return this.Detail as T;
        }

        //public T GetDetail<T>()
        //    where T : MyReadModelDetail
        //{
        //    return this.Detail as T;
        //}
    }

    public interface IMyReadModelMaster : IMasterCommon
    {
        new MyReadModelDetail Detail { get; set; }
        new T GetDetail<T>() where T : MyReadModelDetail;
    }

    public class MyReadModelDetail : IDetailCommon
    {
        public string DetailData { get; set; }
    }
}
