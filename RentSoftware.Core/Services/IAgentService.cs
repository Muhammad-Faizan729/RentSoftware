using RentSoftware.Core.Entities;

namespace RentSoftware.Core.Services
{
    public interface IAgentService
    {
        Task<IEnumerable<Agent>> GetAllAgentAsync();

        Task GetAgentByIdAsync(int id);

        Task AddAgentAsync(Agent agent);

        Task UpdateAgentAsync(Agent agent);

        Task DeleteAgentAsync(int id);
    }
}
