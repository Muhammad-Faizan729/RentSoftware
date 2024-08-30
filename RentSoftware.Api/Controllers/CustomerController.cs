using Microsoft.AspNetCore.Mvc;
using RentSoftware.Core.Entities;
using RentSoftware.Core.Services;

namespace RentSoftware.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet(Name = "GetCustomers")]
        public async Task<IEnumerable<Customer>> Get()
        {
            return await _customerService.GetAllCustomerAsync();
        }
    }
}

