using RentSoftware.Core.Entities;
using RentSoftware.Core.Repositories;
using RentSoftware.Core.Services;

namespace RentSoftware.Service
{
    public class RentService : IRentService
    {
        private readonly IRentRepository _rentRepository;

        public RentService(IRentRepository rentRepository)
        {
            _rentRepository = rentRepository;
        }

        public async Task AddRentAsync(Rent rent)
        {
            await _rentRepository.AddRentAsync(rent);
        }

        public Task DeleteRentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Rent>> GetAllRentAsync()
        {
            return await _rentRepository.GetAllRentAsync();
        }

        public async Task<Rent> GetRentByIdAsync(int id)
        {
            return await _rentRepository.GetRentByIdAsync(id);
        }

        public Task UpdateRentAsync(Rent rent)
        {
            throw new NotImplementedException();
        }
    }
}
