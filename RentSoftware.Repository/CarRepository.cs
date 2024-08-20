using Microsoft.EntityFrameworkCore;
using RentSoftware.Core.Entities;
using RentSoftware.Core.Repositories;

namespace RentSoftware.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly RentSoftwareDbContext _context;

        public CarRepository(RentSoftwareDbContext context)
        {
            _context = context;
        }

        public async Task AddCarAsync(Car car)
        {
            await _context.Cars.AddAsync(car);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("An error occurred while saving changes: " + ex.InnerException?.Message);
            }

        }

        public Task DeleteCarAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Car>> GetAllCarAsync()
        {
           return await _context.Cars.ToListAsync();
        }

        public async Task<Car> GetCarByIdAsync(int id)
        {
            return await _context.Cars.FindAsync(id);
        }

        public async Task UpdateCarAsync(Car car)
        {
            _context.Cars.Attach(car);
            _context.Entry(car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("An error occurred while updating the Car: " + ex.InnerException?.Message);
            }
        }
    }
}
