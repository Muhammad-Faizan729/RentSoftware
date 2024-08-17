using RentSoftware.Core.Entities;
using RentSoftware.Core.Services;

namespace RentSoftware.Service
{
    public class RentService : IRentService
    {
        public Task AddRentAsync(Rent rent)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Rent>> GetAllRentAsync()
        {
            throw new NotImplementedException();
        }

        public Task GetRentByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRentAsync(Rent rent)
        {
            throw new NotImplementedException();
        }
    }
}
