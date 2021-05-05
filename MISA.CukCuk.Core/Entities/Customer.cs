using MISA.CukCuk.Core.CustomAttribute;
using System;

namespace MISA.CukCuk.Core.Entities
{
    public class Customer
    {
        /// <summary>
        /// Mã ID khách hàng.
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Mã code khách hàng.
        /// </summary>
        [MISARequired("")]
        [MISAMaxLength(20, "")]
        public string CustomerCode { get; set; }

        /// <summary>
        /// Tên khách hàng.
        /// </summary>
        [MISARequired("")]
        public string FullName { get; set; }

        /// <summary>
        /// Giới tính.
        /// </summary>
        public int? Gender { get; set; }

        /// <summary>
        /// Mã thẻ thành viên
        /// </summary>
        public string MemberCardCode { get; set; }

        /// <summary>
        /// Mã Id của Nhóm khách hàng.
        /// </summary>
        public Guid CustomerGroupId { get; set; }

        /// <summary>
        /// số điện thoại của khách hàng.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Ngày sinh của khách hàng.
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Tên công ty.
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Mã số thuế của công ty.
        /// </summary>
        public string CompanyTaxCode { get; set; }

        /// <summary>
        /// Email.
        /// </summary>
        [MISARequired("")]
        [MISAEmail("")]
        public string Email { get; set; }

        /// <summary>
        /// Địa chỉ.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Ghi chú.
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Ngày tạo.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Tạo bởi ai.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày chỉnh sửa.
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Ai là người chỉnh sửa.
        /// </summary>
        public string ModifedBy { get; set; }
    }
}
