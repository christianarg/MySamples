using SamplesTestProyect.Inheritance.Loco.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplesTestProyect.Inheritance.Loco.WriteModel
{
    public interface IMyWriteModelMaster : IMasterCommon
    {
        new MyWriteModelDetail Detail { get; set; }
    }
    public class MyWriteModelMaster : IMyWriteModelMaster
    {
        public MyWriteModelDetail Detail { get; set; }

        IDetailCommon IMasterCommon.Detail => this.Detail;

        public T GetDetail<T>()
            where T : class, IDetailCommon
        {
            return this.Detail as T;
        }
    }


    public class MyWriteModelDetail : IDetailCommon
    {
        public string DetailData { get; set; }
    }
}
