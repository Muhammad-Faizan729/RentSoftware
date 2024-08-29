using Microsoft.EntityFrameworkCore;
using RentSoftware.Core.Entities;
using RentSoftware.Repository;

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
        public async Task AddAgentAsync_should_add_agent_to_database()
        {
            //Arrange
            var agent = new Agent { Name = "fake" };

            using (var context = new RentSoftwareDbContext(_options))
            {
                var agentRepository = new AgentRepository(context);
                await agentRepository.AddAgentAsync(agent);
            }

            using (var context = new RentSoftwareDbContext(_options))
            {
                //Act
                var addedAgent = await context.Agents.FirstOrDefaultAsync(a => a.Name == "fake");

                //Assert
                Assert.IsNotNull(addedAgent, "Agent should not be null.");
                Assert.AreEqual("fake", addedAgent.Name, "Agent name should match the expected value.");
            }
        }

        [Test]
        public async Task GetAllAgentAsync_should_return_agents()
        {
            //Arrange
            using (var context = new RentSoftwareDbContext(_options))
            {
                context.Agents.Add(new Agent { Name = "fake-first-agent" });
                context.Agents.Add(new Agent { Name = "fake-second-agent" });
                context.Agents.Add(new Agent { Name = "fake-third-agent" });
                await context.SaveChangesAsync();
            }

            List<Agent> agents;

            //Act
            using (var context = new RentSoftwareDbContext(_options))
            {
                var agentRepository = new AgentRepository(context);
                agents = (await agentRepository.GetAllAgentAsync()).ToList();
            }

            //Assert
            Assert.IsNotNull(agents, "The result should not be null.");
            Assert.AreEqual(3, agents.Count, "The number of agents returned should match the expected count.");
            Assert.AreEqual("fake-first-agent", agents[0].Name, "The first agent's name should match the expected value.");
            Assert.AreEqual("fake-second-agent", agents[1].Name, "The second agent's name should match the expected value.");
            Assert.AreEqual("fake-third-agent", agents[2].Name, "The third agent's name should match the expected value.");
        }

        [Test]
        public async Task GetAgentByIdAsync_should_return_agent() 
        {
            int agentId;

            //Arrange
            using (var context = new RentSoftwareDbContext(_options))
            {
                var agent1 = new Agent { Name = "fake-first-agent" };
                var agent2 = new Agent { Name = "fake-second-agent" };
                var agent3 = new Agent { Name = "fake-third-agent" };

                context.Agents.Add(agent1);
                context.Agents.Add(agent2);
                context.Agents.Add(agent3);
                await context.SaveChangesAsync();

                agentId = agent1.AgentId;
            }

            Agent agent;

            //Act
            using (var context = new RentSoftwareDbContext(_options))
            {
                var agentRepository = new AgentRepository(context);
                agent = await agentRepository.GetAgentByIdAsync(agentId);
            }

            //Assert
            Assert.IsNotNull(agent, "The agent should not be null");
            Assert.AreEqual("fake-first-agent", agent.Name, "Returning agent must be matched with 'Agent1'");
        }

        [Test]
        public async Task DeleteAgent_should_delete_agent_from_database()
        {
            //Arrange
            var Agent = new Agent();

            using (var context = new RentSoftwareDbContext(_options))
            {
                var agent1 = new Agent { Name = "fake-first-agent" };
                var agent2 = new Agent { Name = "fake-second-agent" };
                var agent3 = new Agent { Name = "fake-third-agent" };

                context.Agents.Add(agent1);
                context.Agents.Add(agent2);
                context.Agents.Add(agent3);
                await context.SaveChangesAsync();

                Agent = agent1;
            }

            //Act
            using (var context = new RentSoftwareDbContext(_options))
            {
                var agentRepository = new AgentRepository(context);
                await agentRepository.DeleteAgentAsync(Agent);
            }

            //Assert
            using (var context = new RentSoftwareDbContext(_options))
            {
                var deletedAgent = await context.Agents.FindAsync(Agent.AgentId);
                Assert.IsNull(deletedAgent, "The agent should be null after deletion.");
            }
        }
    }
}
