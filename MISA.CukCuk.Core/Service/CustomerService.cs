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
        protected override void CustomValidate(Customer customer, HTTPType http)
        {
            var customerCode = customer.CustomerCode;
            var customerId = customer.CustomerId;
            var phoneNumber = customer.PhoneNumber;
            var IsCheckHttpPostOrPut = _customerRepository.CheckCustomerCodeExist(customerCode, customerId, http);
            if(IsCheckHttpPostOrPut == true)
            {
                throw new CustomExceptions("Mã khách hàng đã tồn tại trên hệ thống!");
            }
            var phone = _customerRepository.CheckPhoneNumberExist(phoneNumber);
            if (phone)
            {
                throw new CustomExceptions("Số điện thoại đã tồn tại trên hệ thống!");
            }
        }
    }
}
