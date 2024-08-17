using RentSoftware.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentSoftware.Core.Repositories
{
    public interface IAgentRepository
    {
        Task<IEnumerable<Agent>> GetAllAgentAsync();

        Task GetAgentByIdAsync(int id);

        Task AddAgentAsync(Agent agent);

        Task UpdateAgentAsync(Agent agent);

        Task DeleteAgentAsync(int id);
    }
}
