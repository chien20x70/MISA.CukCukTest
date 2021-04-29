using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces.Repository;
using MISA.CukCuk.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Service
{
    public class CustomerGroupService: BaseService<CustomerGroup>, ICustomerGroupService
    {
        ICustomerGroupRepository _customerGroupRepository;
        public CustomerGroupService(ICustomerGroupRepository customerGroupRepository):base(customerGroupRepository)
        {
            _customerGroupRepository = customerGroupRepository;
        }
    }
}
