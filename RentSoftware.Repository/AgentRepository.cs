using Microsoft.EntityFrameworkCore;
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

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("An error occurred while saving changes: " + ex.InnerException?.Message);
            }
        }

        public async Task DeleteAgentAsync(Agent agent)
        {
             _context.Agents.Remove(agent);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("An error occurred while Delete Agent: " + ex.InnerException?.Message);
            }
        }

        public async Task<Agent> GetAgentByIdAsync(int id)
        {
            return await _context.Agents.FindAsync(id);
        }

        public async Task<IEnumerable<Agent>> GetAllAgentAsync()
        {
            return await _context.Agents.ToListAsync();
        }

        public async Task UpdateAgentAsync(Agent agent)
        {
            _context.Agents.Attach(agent); 
            _context.Entry(agent).State = EntityState.Modified; 

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("An error occurred while updating the agent: " + ex.InnerException?.Message);
            }
        }
    }
}
