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

        public async Task<IEnumerable<Rent>> GetAllRentAsync()
        {
            return await _context.Rents
            .Include(r => r.Car)          
            .Include(r => r.Customer)     
            .Include(r => r.Agent)        
            .ToListAsync();
        }

        public Task UpdateRentAsync(Rent rent)
        {
            throw new NotImplementedException();
        }

        public async Task<Rent> GetRentByIdAsync(int id)
        {
            return await _context.Rents.FindAsync(id);
        }
    }

}
