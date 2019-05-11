using DatEx.Cropio.BaseAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatEx.Cropio.Proxy.Model
{
    public interface ICropioProxyObjBase
    {
        Int32 Id { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
    }

    public interface ICropioProxyObj<T1, T2> where T1 : ICropioObject, ICropioProxyObjBase
    {
        T2 FromCropioObj(T1 obj);
    }
}
