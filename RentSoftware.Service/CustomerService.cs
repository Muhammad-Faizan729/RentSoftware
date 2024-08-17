using RentSoftware.Core.Entities;
using RentSoftware.Core.Services;

namespace RentSoftware.Service
{
    public class CustomerService : ICustomerService
    {
        public Task AddCustomerAsync(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCustomerAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetAllCustomerAsync()
        {
            throw new NotImplementedException();
        }

        public Task GetCustomerByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCustomerAsync(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
