﻿using Microsoft.EntityFrameworkCore;
using RentSoftware.Core.Entities;
using RentSoftware.Core.Repositories;

namespace RentSoftware.Repository
{
    public class AgentRepository : IAgentRepository
    {
        private readonly RentSoftwareDbContext _context;

        public AgentRepository(RentSoftwareDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task AddAgentAsync(Agent agent)
        {
            await _context.Agents.AddAsync(agent);
            //_context.SaveChanges();
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("An error occurred while saving changes: " + ex.InnerException?.Message);
            }
        }

        public Task DeleteAgentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Agent> GetAgentByIdAsync(int id)
        {
            return await _context.Agents.FindAsync(id);
        }

        public Task<IEnumerable<Agent>> GetAllAgentAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAgentAsync(Agent agent)
        {
            throw new NotImplementedException();
        }
    }
}
