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
        public bool CheckCustomerCodeExist(string customerCode, Guid customerId, HTTPType http);
        public bool CheckPhoneNumberExist(string phoneNumber);
    }
}
