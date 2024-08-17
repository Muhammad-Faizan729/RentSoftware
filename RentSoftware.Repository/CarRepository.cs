using RentSoftware.Core.Entities;
using RentSoftware.Core.Repositories;

namespace RentSoftware.Repository
{
    public class CarRepository : ICarRepository
    {
        public Task AddCarAsync(Car car)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCarAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Car>> GetAllCarAsync()
        {
            throw new NotImplementedException();
        }

        public Task GetCarByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCarAsync(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
