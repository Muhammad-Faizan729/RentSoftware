using RentSoftware.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentSoftware.Core.Repositories
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAllCarAsync();

        Task<Car> GetCarByIdAsync(int id);

        Task AddCarAsync(Car car);

        Task UpdateCarAsync(Car car);

        Task DeleteCarAsync(int id);
    }
}
