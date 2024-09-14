using RentSoftware.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentSoftware.Core.Services
{
    public interface IRentService
    {
        Task<IEnumerable<Rent>> GetAllRentAsync();

        Task<Rent> GetRentByIdAsync(int id);

        Task AddRentAsync(Rent rent);

        Task UpdateRentAsync(Rent rent);

        Task DeleteRentAsync(int id);
    }
}

