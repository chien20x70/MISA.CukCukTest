using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Exceptions
{
    public class CustomExceptions: Exception
    {
        public CustomExceptions(string msg): base(msg)
        {

        }
    }
}
