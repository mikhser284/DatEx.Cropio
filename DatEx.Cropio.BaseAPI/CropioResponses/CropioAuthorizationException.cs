using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatEx.Cropio.BaseAPI
{
    public class CropioAuthorizationException : Exception
    {
        public CropioAuthorizationException() { }

        public CropioAuthorizationException(String message) : base(message) { }

        public CropioAuthorizationException(String message, Exception innerException) : base(message, innerException) { }
    }
}
