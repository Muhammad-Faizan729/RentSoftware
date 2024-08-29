using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using RentSoftware.Core.Entities;
using RentSoftware.Repository;
using RentSoftware.Service;
using System.Linq;
using System.Threading.Tasks;
using UILayer;

namespace RentSoftware.Tests.RepositoryTest
{
    [TestFixture]
    public class AgentRepositoryTests
    {
        private DbContextOptions<RentSoftwareDbContext> _options;

        [SetUp]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<RentSoftwareDbContext>()
                .UseInMemoryDatabase(databaseName: $"RentSoftware_{System.Guid.NewGuid()}")
                .Options;
        }

        [Test]
        public async Task AddAgentAsync_WhenCalled_StoresAgentInDatabase()
        {
            var agent = new Agent { Name = "test" };

            using (var context = new RentSoftwareDbContext(_options))
            {
                var agentRepository = new AgentRepository(context);
                await agentRepository.AddAgentAsync(agent);
            }

            using (var context = new RentSoftwareDbContext(_options))
            {
                var addedAgent = await context.Agents.FirstOrDefaultAsync(a => a.Name == "test");
                Assert.IsNotNull(addedAgent, "Agent should not be null.");
                Assert.AreEqual("test", addedAgent.Name, "Agent name should match the expected value.");
            }
        }

        [Test]
        public async Task GetAllAgentAsync_WhenCalled_ReturnsAllAgents()
        {
            using (var context = new RentSoftwareDbContext(_options))
            {
                context.Agents.Add(new Agent { Name = "Agent1" });
                context.Agents.Add(new Agent { Name = "Agent2" });
                context.Agents.Add(new Agent { Name = "Agent3" });
                await context.SaveChangesAsync();
            }

            List<Agent> agents;

            using (var context = new RentSoftwareDbContext(_options))
            {
                var agentRepository = new AgentRepository(context);
                agents = (await agentRepository.GetAllAgentAsync()).ToList();
            }

            Assert.IsNotNull(agents, "The result should not be null.");
            Assert.AreEqual(3, agents.Count, "The number of agents returned should match the expected count.");
            Assert.AreEqual("Agent1", agents[0].Name, "The first agent's name should match the expected value.");
            Assert.AreEqual("Agent2", agents[1].Name, "The second agent's name should match the expected value.");
            Assert.AreEqual("Agent3", agents[2].Name, "The third agent's name should match the expected value.");
        }

        [Test]
        public async Task GetAgentByIdAsync_WhenCalled_ReturnAgentToSpecificEnteredId() 
        {
            int agentId;
            using (var context = new RentSoftwareDbContext(_options))
            {
                var agent1 = new Agent { Name = "Agent1" };
                var agent2 = new Agent { Name = "Agent2" };
                var agent3 = new Agent { Name = "Agent3" };

                context.Agents.Add(agent1);
                context.Agents.Add(agent2);
                context.Agents.Add(agent3);
                await context.SaveChangesAsync();

                agentId = agent1.AgentId;
            }

            Agent agent;

            using (var context = new RentSoftwareDbContext(_options))
            {
                var agentRepository = new AgentRepository(context);
                agent = await agentRepository.GetAgentByIdAsync(agentId);
            }

            Assert.IsNotNull(agent, "The agent should not be null");
            Assert.AreEqual("Agent1", agent.Name, "Returning agent must be matched with 'Agent1'");
        }

        [Test]
        public async Task DeleteAgent_WhenCalled_DeleteThePassingAgent()
        {
            var Agent = new Agent();

            using (var context = new RentSoftwareDbContext(_options))
            {
                var agent1 = new Agent { Name = "Agent1" };
                var agent2 = new Agent { Name = "Agent2" };
                var agent3 = new Agent { Name = "Agent3" };

                context.Agents.Add(agent1);
                context.Agents.Add(agent2);
                context.Agents.Add(agent3);
                await context.SaveChangesAsync();

                Agent = agent1;
            }

            using (var context = new RentSoftwareDbContext(_options))
            {
                var agentRepository = new AgentRepository(context);
                await agentRepository.DeleteAgentAsync(Agent);
            }

            using (var context = new RentSoftwareDbContext(_options))
            {
                var deletedAgent = await context.Agents.FindAsync(Agent.AgentId);
                Assert.IsNull(deletedAgent, "The agent should be null after deletion.");
            }
        }
    }
}
