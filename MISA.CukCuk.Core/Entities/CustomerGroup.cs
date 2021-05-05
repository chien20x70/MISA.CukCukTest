using MISA.CukCuk.Core.CustomAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Entities
{
    public class CustomerGroup
    {
        /// <summary>
        /// Mã Id Nhóm khách hàng
        /// </summary>
        /// Created by: NXCHIEN 05/05/2021
        public Guid CustomerGroupId { get; set; }

        /// <summary>
        /// Tên của nhóm khách hàng
        /// </summary>
        /// Created by: NXCHIEN 05/05/2021
        [MISARequired("")]
        public string CustomerGroupName { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        /// Created by: NXCHIEN 05/05/2021
        public string Description { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        /// Created by: NXCHIEN 05/05/2021
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Tạo bởi ai
        /// </summary>
        /// Created by: NXCHIEN 05/05/2021
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày chỉnh sửa
        /// </summary>
        /// Created by: NXCHIEN 05/05/2021
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Ai là người chỉnh sửa
        /// </summary>
        /// Created by: NXCHIEN 05/05/2021
        public string ModifiedBy { get; set; }
    }
}
