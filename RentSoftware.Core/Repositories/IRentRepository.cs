using RentSoftware.Core.Entities;

namespace RentSoftware.Core.Repositories
{
    public interface IRentRepository
    {
        Task<IEnumerable<Rent>> GetAllRentAsync();

        Task GetRentByIdAsync(int id);

        Task AddRentAsync(Rent rent);

        Task UpdateRentAsync(Rent rent);

        Task DeleteRentAsync(int id);
    }
}
