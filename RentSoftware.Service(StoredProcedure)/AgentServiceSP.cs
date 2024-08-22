using RentSoftware.Core.Entities;
using RentSoftware.Core.Repositories;
using RentSoftware.Core.RepositoriesSP;
using RentSoftware.Core.Services;
using RentSoftware.Core.SevicesSP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentSoftware.Service_StoredProcedure_
{
    public class AgentServiceSP : IAgentServiceSP
    {

        private readonly IAgentRepositorySP _agentRepositorySP;

        public AgentServiceSP(IAgentRepositorySP agentRepositorySP)
        {
            _agentRepositorySP = agentRepositorySP;
        }

        public async Task AddAgentAsync(Agent agent)
        {
            await _agentRepositorySP.AddAgentAsync(agent);
        }

        public Task DeleteAgentAsync(Agent agent)
        {
            throw new NotImplementedException();
        }

        public Task<Agent> GetAgentByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Agent>> GetAllAgentAsync()
        {
            return await _agentRepositorySP.GetAllAgentAsync();
        }

        public Task UpdateAgentAsync(Agent agent)
        {
            throw new NotImplementedException();
        }
    }
}
