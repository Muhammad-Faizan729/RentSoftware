using Moq;
using RentSoftware.Core.Entities;
using RentSoftware.Core.Repositories;
using RentSoftware.Repository;
using RentSoftware.Service;

namespace RentSoftware.Tests
{
    [TestFixture]
    public class AgentServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }
        

        [Test]
        [Ignore("Testing")]
        public void Add_AddingTwoValues_ReturnResult()
        {

        }

        [Test]
        public async Task AddAgentAsync_whenCalled_SendAgentToRepository()
        {
            var mockAgentRepository = new Mock<IAgentRepository>();
            var agentService = new AgentService(mockAgentRepository.Object);

            var mockAgent = new Agent()
            {
                Name = "test"
            };

            await agentService.AddAgentAsync(mockAgent);

            mockAgentRepository.Verify(a=>a.AddAgentAsync(It.Is<Agent>(ag=>ag.Name == "test")),Times.Once);
        }

        [Test]
        public async Task GetAgentByIdAsync_PassedIdOne_ReturnAgentWithIdOne()
        {
            var mockAgentRepository = new Mock<IAgentRepository>();
            var agentService = new AgentService(mockAgentRepository.Object);

            var agents = new List<Agent>()
            {
                new Agent() { AgentId = 1, Name = "FirstAgent" },
                new Agent() { AgentId = 2, Name = "SecondAgent" },
                new Agent() { AgentId = 3, Name = "ThirdAgent" }
            };

            mockAgentRepository.Setup(a=>a.GetAllAgentAsync()).ReturnsAsync(agents);
            mockAgentRepository.Setup(a=>a.GetAgentByIdAsync(1)).ReturnsAsync(agents.First(a=>a.AgentId==1));

            var result = await agentService.GetAgentByIdAsync(1);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.AgentId, Is.EqualTo(1));
            Assert.That(result.Name, Is.EqualTo("FirstAgent"));
        }

        [Test]
        public async Task GetTaskAsync_whenCalled_ReturnAllAgents()
        {
            var mockAgentRepository = new Mock<IAgentRepository>();
            var agentService = new AgentService(mockAgentRepository.Object);

            var agents = new List<Agent>()
            {
                new Agent() { AgentId = 1, Name = "FirstAgent" },
                new Agent() { AgentId = 2, Name = "SecondAgent" },
                new Agent() { AgentId = 3, Name = "ThirdAgent" }
            };

            mockAgentRepository.Setup(a => a.GetAllAgentAsync()).ReturnsAsync(agents);

            var result = await agentService.GetAllAgentAsync();

            mockAgentRepository.Verify(a => a.GetAllAgentAsync(), Times.Once);

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public async Task DeleteAgentAsync_WhenCalledOrPassAgentToDelete_RemovedAgent()
        {
            var mockAgentRepository = new Mock<IAgentRepository>();
            var agentService = new AgentService(mockAgentRepository.Object);

            var RemovedAgent = new Agent()
            {
                Name = "test"
            };

            await agentService.DeleteAgentAsync(RemovedAgent);

            mockAgentRepository.Verify(a=>a.DeleteAgentAsync(RemovedAgent), Times.Once);
        }
    }
}