using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplesTestProyect.Inheritance.Loco.Common
{
    public interface IMasterCommon
    {
        IDetailCommon Detail { get; }
        T GetDetail<T>() where T : class, IDetailCommon;
    }

    public interface IDetailCommon
    {
        string DetailData { get; set; }
    }
}
