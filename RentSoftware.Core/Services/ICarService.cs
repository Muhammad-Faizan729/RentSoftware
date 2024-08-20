using RentSoftware.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentSoftware.Core.Services
{
    public interface ICarService
    {
        Task<IEnumerable<Car>> GetAllCarAsync();

        Task<Car> GetCarByIdAsync(int id);

        Task AddCarAsync(Car car);

        Task UpdateCarAsync(Car car);

        Task DeleteCarAsync(Car car);
    }
}
