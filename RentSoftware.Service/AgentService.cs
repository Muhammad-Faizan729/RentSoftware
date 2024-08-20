using RentSoftware.Core.Entities;
using RentSoftware.Core.Repositories;
using RentSoftware.Core.Services;

namespace RentSoftware.Service
{
    public class AgentService : IAgentService
    {
        private readonly IAgentRepository _agentRepository;

        public AgentService(IAgentRepository agentRepository)
        {
            _agentRepository = agentRepository;
        }

        public async Task AddAgentAsync(Agent agent)
        {
            await _agentRepository.AddAgentAsync(agent);
        }

        public Task DeleteAgentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Agent> GetAgentByIdAsync(int id)
        {
            return await _agentRepository.GetAgentByIdAsync(id);
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
