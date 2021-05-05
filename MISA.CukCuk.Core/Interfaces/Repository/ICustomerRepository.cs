using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Interfaces.Repository
{
    public interface ICustomerRepository: IBaseRepository<Customer>
    {
        /// <summary>
        /// Kiểm tra trùng mã CustomerCode
        /// </summary>
        /// <param name="customerCode">mã khách hàng</param>
        /// <param name="customerId">ID khách hàng</param>
        /// <param name="http">Phương thứ POST or PUT</param>
        /// <returns>true or false</returns>
        /// Created by: NXChien 29/04/2021
        public bool CheckCustomerCodeExist(string customerCode, Guid customerId, HTTPType http);

        /// <summary>
        /// Kiểm tra trùng số điện thoại
        /// </summary>
        /// <param name="phoneNumber">số điện thoại</param>
        /// <returns>true or false</returns>
        /// Created by: NXChien 29/04/2021
        public bool CheckPhoneNumberExist(string phoneNumber);
    }
}
