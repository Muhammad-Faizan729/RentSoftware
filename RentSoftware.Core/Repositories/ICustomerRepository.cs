using RentSoftware.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentSoftware.Core.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomerAsync();

        Task<Customer> GetCustomerByIdAsync(int id);

        Task AddCustomerAsync(Customer customer);

        Task UpdateCustomerAsync(Customer customer);

        Task DeleteCustomerAsync(int id);
    }
}
