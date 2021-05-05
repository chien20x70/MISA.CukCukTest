using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Enums;
using MISA.CukCuk.Core.Exceptions;
using MISA.CukCuk.Core.Interfaces.Repository;
using MISA.CukCuk.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Service
{
    public class CustomerService: BaseService<Customer>, ICustomerService
    {
        ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository) :base(customerRepository)
        {
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// Validate dữ liệu riêng tường đối tượng
        /// </summary>
        /// <param name="customer">đối tượng truyền vào</param>
        /// <param name="http">Phương thức Post or PUT</param>
        /// Created By: NXCHIEN 29/04/2021
        protected override void CustomValidate(Customer customer, HTTPType http)
        {
            // Khởi tạo giá trị và gán giá trị
            var customerCode = customer.CustomerCode;
            var customerId = customer.CustomerId;
            var phoneNumber = customer.PhoneNumber;
            // Kiểm tra Mã code khách hàng đã tồn tại hay chưa
            var IsCheckHttpPostOrPut = _customerRepository.CheckCustomerCodeExist(customerCode, customerId, http);
            if (IsCheckHttpPostOrPut == true)
            {
                throw new CustomExceptions(Properties.Resources.Msg_Code_Exist);
            }

            //TODO: Chưa check PhoneNumber theo dạng PUT OR POST
            var phone = _customerRepository.CheckPhoneNumberExist(phoneNumber);
            if (phone)
            {
                throw new CustomExceptions(Properties.Resources.Msg_Phone_Exist);
            }
        }
    }
}
