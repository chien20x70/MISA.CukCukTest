using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces.Repository;
using MISA.CukCuk.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCukTest.Base.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class CustomerController : BaseController<Customer>
    {
        ICustomerService _customerService;
        ICustomerRepository _customerRepository;
        public CustomerController(ICustomerService customerService,
        ICustomerRepository customerRepository):base(customerRepository, customerService)
        {
            _customerRepository = customerRepository;
            _customerService = customerService;
        }
    }
}
