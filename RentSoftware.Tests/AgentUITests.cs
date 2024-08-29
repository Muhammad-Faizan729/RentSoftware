using Moq;
using RentSoftware.Core.Entities;
using RentSoftware.Core.Services;
using System.IO;
using RentSoftware.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UILayer;

namespace RentSoftware.Tests
{
    [TestFixture]
    public class AgentUITests
    {
        private readonly Mock<IAgentService> _mockAgentService; 
        private readonly AgentUI _agentUI;

        public AgentUITests()
        {
            _mockAgentService = new Mock<IAgentService>();
            _agentUI = new AgentUI(_mockAgentService.Object);
        }

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async Task AddNewAgent_should_add_agent()
        {
            //Arrange
            var input = "test";
            var consoleInput = new StringReader(input + Environment.NewLine);
            Console.SetIn(consoleInput);

            //Act
            await _agentUI.AddNewAgent();

            //Assert
            _mockAgentService.Verify(a => a.AddAgentAsync(It.Is<Agent>(ag => ag.Name == "test")), Times.Once);
        }

        [Test]
        public async Task ViewAllAgent_Should_Return_All_Agents()
        {
            //Arrange
            var Agents = new List<Agent>()
            {
                new Agent() { AgentId = 1, Name = "fake-first-agent" },
                new Agent() { AgentId = 2, Name = "fake-second-agent" },
                new Agent() { AgentId = 3, Name = "fake-third-agent" }
            };

            _mockAgentService.Setup(a=>a.GetAllAgentAsync()).ReturnsAsync(Agents); 

            //Act
            using (var stringWriter = new StringWriter())
            {
                var originalConsoleOut = Console.Out;
                Console.SetOut(stringWriter);

                await _agentUI.ViewAllAgents();

                var output = stringWriter.ToString();
                Console.WriteLine("Captured Output:");
                Console.WriteLine(output);

                Assert.That(output, Does.Contain("Agent Id: 1, Name: fake-first-agent"));
                Assert.That(output, Does.Contain("Agent Id: 2, Name: fake-second-agent"));
                Assert.That(output, Does.Contain("Agent Id: 3, Name: fake-third-agent"));
            }

            //Assert
            _mockAgentService.Verify(a => a.GetAllAgentAsync(), Times.Once);
        }

        [Test]
        public async Task UpdateAgent_Should_Update_Agent()
        { 
            //Arrange
            var existingAgents = new List<Agent>()
            {
                new Agent() { AgentId = 1, Name = "fake-first-agent" },
                new Agent() { AgentId = 2, Name = "fake-second-agent" },
                new Agent() { AgentId = 3, Name = "fake-third-agent" }
            };

            _mockAgentService.Setup(a => a.GetAllAgentAsync()).ReturnsAsync(existingAgents);
            _mockAgentService.Setup(a => a.GetAgentByIdAsync(1)).ReturnsAsync(existingAgents.First());
            _mockAgentService.Setup(a => a.UpdateAgentAsync(It.IsAny<Agent>())).Verifiable();

            //Act
            var input = "1" + Environment.NewLine + "AgentOneUpdated" + Environment.NewLine;
            var consoleInput = new StringReader(input);
            Console.SetIn(consoleInput);
         
            await _agentUI.UpdateAgent();

            //Assert
            _mockAgentService.Verify(a => a.UpdateAgentAsync(It.Is<Agent>(ag => ag.AgentId == 1 && ag.Name == "AgentOneUpdated")), Times.Once);

            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
        }

    }
}
