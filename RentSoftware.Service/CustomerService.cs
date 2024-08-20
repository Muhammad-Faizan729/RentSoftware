using RentSoftware.Core.Entities;
using RentSoftware.Core.Repositories;
using RentSoftware.Core.Services;

namespace RentSoftware.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task AddCustomerAsync(Customer customer)
        {
            await _customerRepository.AddCustomerAsync(customer);
        }

        public Task DeleteCustomerAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Customer>> GetAllCustomerAsync()
        {
            return await _customerRepository.GetAllCustomerAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _customerRepository.GetCustomerByIdAsync(id);
        }

        public Task UpdateCustomerAsync(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
