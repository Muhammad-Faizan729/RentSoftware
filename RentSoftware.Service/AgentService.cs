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

        public async Task DeleteAgentAsync(Agent agent)
        {
            await _agentRepository.DeleteAgentAsync(agent);
        }

        public async Task<Agent> GetAgentByIdAsync(int id)
        {
            return await _agentRepository.GetAgentByIdAsync(id);
        }

        public async Task<IEnumerable<Agent>> GetAllAgentAsync()
        {
           return await _agentRepository.GetAllAgentAsync();
        }

        public async Task UpdateAgentAsync(Agent agent)
        {
            await _agentRepository.UpdateAgentAsync(agent);
        }
    }
}
