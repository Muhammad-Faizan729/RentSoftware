using RentSoftware.Core.Entities;
using RentSoftware.Core.Repositories;

namespace RentSoftware.Repository
{
    public class CustomerRepository : ICustomerRepository
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
