using MISA.CukCuk.Core.CustomAttribute;
using System;

namespace MISA.CukCuk.Core.Entities
{
   
    public class CustomerGroup
    {
        /// <summary>
        /// Mã Id Nhóm khách hàng.
        /// </summary>
        public Guid CustomerGroupId { get; set; }

        /// <summary>
        /// Tên của nhóm khách hàng.
        /// </summary>
        [MISARequired("")]
        public string CustomerGroupName { get; set; }

        /// <summary>
        /// Mô tả.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Ngày tạo.
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Tạo bởi ai.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày chỉnh sửa.
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Ai là người chỉnh sửa.
        /// </summary>
        public string ModifiedBy { get; set; }
    }
}
