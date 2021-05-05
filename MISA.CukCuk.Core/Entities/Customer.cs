using MISA.CukCuk.Core.CustomAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Entities
{
    public class Customer
    {
        /// <summary>
        /// Mã ID khách hàng
        /// </summary>
        /// Created by: NXCHIEN 05/05/2021
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Mã code khách hàng
        /// </summary>
        /// Created by: NXCHIEN 05/05/2021
        [MISARequired("")]
        [MISAMaxLength(20,"")]
        public string CustomerCode { get; set; }

        /// <summary>
        /// Tên khách hàng
        /// </summary>
        /// Created by: NXCHIEN 05/05/2021
        [MISARequired("")]
        public string FullName { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        /// Created by: NXCHIEN 05/05/2021
        public int? Gender { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// Created by: NXCHIEN 05/05/2021
        public string MemberCardCode { get; set; }

        /// <summary>
        /// Mã Id của Nhóm khách hàng
        /// </summary>
        /// Created by: NXCHIEN 05/05/2021
        public Guid CustomerGroupId { get; set; }

        /// <summary>
        /// số điện thoại của khách hàng
        /// </summary>
        /// Created by: NXCHIEN 05/05/2021
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Ngày sinh của khách hàng
        /// </summary>
        /// Created by: NXCHIEN 05/05/2021
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Tên công ty 
        /// </summary>
        /// Created by: NXCHIEN 05/05/2021
        public string CompanyName { get; set; }

        /// <summary>
        /// Mã số thuế của công ty
        /// </summary>
        /// Created by: NXCHIEN 05/05/2021
        public string CompanyTaxCode { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        /// Created by: NXCHIEN 05/05/2021
        public string Email { get; set; }

        /// <summary>
        /// Địa chỉ 
        /// </summary>
        /// Created by: NXCHIEN 05/05/2021
        public string Address { get; set; }

        /// <summary>
        /// Ghi chú
        /// </summary>
        /// Created by: NXCHIEN 05/05/2021
        public string Note { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        /// Created by: NXCHIEN 05/05/2021
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Tạo bởi ai
        /// </summary>
        /// Created by: NXCHIEN 05/05/2021
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày chỉnh sửa
        /// </summary>
        /// Created by: NXCHIEN 05/05/2021
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Ai là người chỉnh sửa
        /// </summary>
        /// Created by: NXCHIEN 05/05/2021
        public string ModifedBy { get; set; }
    }
}
