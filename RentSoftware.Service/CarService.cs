using RentSoftware.Core.Entities;
using RentSoftware.Core.Repositories;
using RentSoftware.Core.Services;
namespace RentSoftware.Service
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public async Task AddCarAsync(Car car)
        {
           await _carRepository.AddCarAsync(car);
        }

        public Task DeleteCarAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Car>> GetAllCarAsync()
        {
           return await _carRepository.GetAllCarAsync();
        }

        public async Task<Car> GetCarByIdAsync(int id)
        {
            return await _carRepository.GetCarByIdAsync(id);
        }

        public Task UpdateCarAsync(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
