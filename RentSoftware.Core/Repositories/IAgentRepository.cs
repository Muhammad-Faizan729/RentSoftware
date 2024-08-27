using RentSoftware.Core.Entities;

namespace RentSoftware.Core.Repositories
{
    public interface IAgentRepository
    {
        Task<IEnumerable<Agent>> GetAllAgentAsync();

        Task<Agent> GetAgentByIdAsync(int id);

        Task AddAgentAsync(Agent agent);

        Task UpdateAgentAsync(Agent agent);

        Task DeleteAgentAsync(Agent agent);
        //void AddCustomerAsync(Customer customer);
    }
}
