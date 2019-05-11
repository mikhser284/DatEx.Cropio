using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatEx.Cropio.BaseAPI
{
    public interface ICropioObject
    {
        Int32 Id { get; set; }

        DateTime CreatedAt { get; set; }

        String GetTextView(Int32 indentLevel);
    }

    public interface ICropioRegularObject : ICropioObject
    {
        DateTime? UpdatedAt { get; set; }
    }

    public interface ICropioDocumentableObject : ICropioRegularObject
    {
    }

    public interface ICropioExtendetObject : ICropioRegularObject
    {
        String Id_External { get; set; }
    }

}
