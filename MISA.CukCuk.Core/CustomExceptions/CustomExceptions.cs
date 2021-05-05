using System;

namespace MISA.CukCuk.Core.Exceptions
{
    public class CustomExceptions : Exception
    {
        public CustomExceptions(string msg) : base(msg)
        {
        }
    }
}
