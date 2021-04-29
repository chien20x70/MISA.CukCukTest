using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.CustomAttribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MISARequired: Attribute
    {
        public string MsgError;
        public MISARequired(string msgError)
        {
            MsgError = msgError;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class MISAMaxLength: Attribute
    {
        public int MaxLength;
        public string MsgError_MaxLength;
        public MISAMaxLength(int maxLength, string msgError_MaxLength)
        {
            MaxLength = maxLength;
            MsgError_MaxLength = msgError_MaxLength;
        }
    }
}
