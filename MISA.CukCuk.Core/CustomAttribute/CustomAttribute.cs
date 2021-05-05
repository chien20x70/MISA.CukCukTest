using System;

namespace MISA.CukCuk.Core.CustomAttribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MISARequired : Attribute
    {
        /// <summary>
        /// Chuỗi message lỗi khi trường thông tin chưa nhập.
        /// </summary>
        public string MsgError;
        public MISARequired(string msgError)
        {
            MsgError = msgError;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class MISAMaxLength : Attribute
    {
        /// <summary>
        /// ĐỘ dài lớn nhất của chuỗi.
        /// </summary>
        public int MaxLength;

        /// <summary>
        /// Chuỗi message lỗi khi nhập quá độ dài maxlength.
        /// </summary>
        public string MsgError_MaxLength;
        public MISAMaxLength(int maxLength, string msgError_MaxLength)
        {
            MaxLength = maxLength;
            MsgError_MaxLength = msgError_MaxLength;
        }
    }
}
