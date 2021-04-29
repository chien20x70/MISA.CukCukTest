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
        [MISARequired("")]
        public Guid CustomerId { get; set; }
        [MISARequired("")]
        [MISAMaxLength(20,"")]
        public string CustomerCode { get; set; }
        [MISARequired("")]
        public string FullName { get; set; }
        public int? Gender { get; set; }
        public string MemberCardCode { get; set; }
        public Guid CustomerGroupId { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CompanyName { get; set; }
        public string CompanyTaxCode { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifedBy { get; set; }
    }
}
