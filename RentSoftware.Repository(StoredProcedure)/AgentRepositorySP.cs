using Microsoft.Data.SqlClient;
using RentSoftware.Core.Entities;
using RentSoftware.Core.Repositories;
using RentSoftware.Core.RepositoriesSP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentSoftware.Repository_StoredProcedure_
{
    public class AgentRepositorySP : IAgentRepositorySP
    {
       // private readonly IAgentRepositorySP _agentRepositorySP;

        string _connectionString = "Server=.\\SQLEXPRESS; Database=RentSoftware; Trusted_Connection=true; TrustServerCertificate=true;";
        public async Task AddAgentAsync(Agent agent)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
               await connection.OpenAsync();

               // var query = "INSERT INTO Agents (Name) Values (@name)";

                using (var command = new SqlCommand("sp_AddAgent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@name", agent.Name);

                    await command.ExecuteNonQueryAsync();
                }
            }
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
            var agents = new List<Agent>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                // Use the stored procedure name instead of the raw SQL query
                using (var command = new SqlCommand("sp_GetAllAgents", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var agent = new Agent
                            {
                                AgentId = reader.GetInt32(reader.GetOrdinal("AgentId")),
                                Name = reader.GetString(reader.GetOrdinal("Name"))
                            };

                            agents.Add(agent);
                        }
                    }
                }
            }

            return agents;
        }


        public Task UpdateAgentAsync(Agent agent)
        {
            throw new NotImplementedException();
        }
    }
}
