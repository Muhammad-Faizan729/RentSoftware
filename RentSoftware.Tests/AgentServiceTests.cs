using Moq;
using RentSoftware.Core.Entities;
using RentSoftware.Core.Repositories;
using RentSoftware.Service;

namespace RentSoftware.Tests
{
    [TestFixture]
    public class AgentServiceTests
    {
        private readonly Mock<IAgentRepository> _mockAgentRepository;
        private readonly AgentService _agentService;

        public AgentServiceTests()
        {
            _mockAgentRepository = new Mock<IAgentRepository>();
            _agentService = new AgentService(_mockAgentRepository.Object);
        }

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
        public async Task AddAgentAsync_should_add_agent()
        {
            //Arrange
            var mockAgent = new Agent()
            {
                Name = "fake-name"
            };

            //Act
            await _agentService.AddAgentAsync(mockAgent);

            //Assert
            _mockAgentRepository.Verify(a => a.AddAgentAsync(It.Is<Agent>(ag => ag.Name == "fake-name")), Times.Once);
        }

        [Test]
        public async Task GetAgentByIdAsync_should_return_agent()
        {
            //Arrange
            var agents = new List<Agent>()
            {
                new Agent() { AgentId = 1, Name = "fake-first-agent" },
                new Agent() { AgentId = 2, Name = "fake-second-agent" },
                new Agent() { AgentId = 3, Name = "fake-third-agent" }
            };
            
            _mockAgentRepository.Setup(a => a.GetAgentByIdAsync(1)).ReturnsAsync(agents.First(a => a.AgentId == 1));

            //Act
            var result = await _agentService.GetAgentByIdAsync(1);

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.AgentId, Is.EqualTo(1));
            Assert.That(result.Name, Is.EqualTo("fake-first-agent"));
        }

        [Test]
        public async Task GetTaskAsync_should_return_agents()
        {
            //Arrange
            var agents = new List<Agent>()
            {
                new Agent() { AgentId = 1, Name = "fake-first-agent" },
                new Agent() { AgentId = 2, Name = "fake-second-agent" },
                new Agent() { AgentId = 3, Name = "fake-third-agent" }
            };

            //Act
            var result = await _agentService.GetAllAgentAsync();

            //Assert
            _mockAgentRepository.Verify(a => a.GetAllAgentAsync(), Times.Once);

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public async Task DeleteAgentAsync_should_delete_agent()
        {
            var RemovedAgent = new Agent()
            {
                Name = "fake-agent"
            };

            await _agentService.DeleteAgentAsync(RemovedAgent);

            _mockAgentRepository.Verify(a => a.DeleteAgentAsync(RemovedAgent), Times.Once);
        }
    }
}