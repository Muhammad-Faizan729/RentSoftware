using RentSoftware.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentSoftware.Core.RepositoriesSP
{
    public interface IAgentRepositorySP
    {
        Task<IEnumerable<Agent>> GetAllAgentAsync();

        Task<Agent> GetAgentByIdAsync(int id);

        Task AddAgentAsync(Agent agent);

        Task UpdateAgentAsync(Agent agent);

        Task DeleteAgentAsync(Agent agent);
    }
}
