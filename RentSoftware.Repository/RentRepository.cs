using Microsoft.EntityFrameworkCore;
using RentSoftware.Core.Entities;
using RentSoftware.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentSoftware.Repository
{
    public class RentRepository : IRentRepository
    {
        private readonly RentSoftwareDbContext _context;

        public RentRepository(RentSoftwareDbContext context)
        {
            _context = context;
        }

        public async Task AddRentAsync(Rent rent)
        {
            await _context.Rents.AddAsync(rent);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("An error occurred while saving changes: " + ex.InnerException?.Message);
            }
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
