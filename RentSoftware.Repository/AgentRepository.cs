using RentSoftware.Core.Entities;
using RentSoftware.Core.Repositories;

namespace RentSoftware.Repository
{
    internal class AgentRepository : IAgentRepository
    {
        public Task AddAgentAsync(Agent agent)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAgentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task GetAgentByIdAsync(int id)
        {
            throw new NotImplementedException();
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
