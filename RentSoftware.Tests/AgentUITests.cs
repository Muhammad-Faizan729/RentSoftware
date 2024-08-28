using Moq;
using RentSoftware.Core.Entities;
using RentSoftware.Core.Services;
using System.IO;
using RentSoftware.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UILayer;
using Microsoft.VisualStudio.TestPlatform.Utilities;


namespace RentSoftware.Tests
{
    [TestFixture]
    public class AgentUITests
    {

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async Task AddNewAgent_whenCalled_PassAgentToService()
        {
            var agentServiceMock = new Mock<IAgentService>();
            var Agent = new AgentUI(agentServiceMock.Object);

            var input = "test";
            var consoleInput = new StringReader(input + Environment.NewLine);
            Console.SetIn(consoleInput);

            await Agent.AddNewAgent();

            agentServiceMock.Verify(a => a.AddAgentAsync(It.Is<Agent>(ag => ag.Name == "test")), Times.Once);
        }

        [Test]
        public async Task ViewAllAgent_WhenCalled_GetAllAgents()
        {
            var agentServiceMock = new Mock<IAgentService>();
            var agentUI = new AgentUI(agentServiceMock.Object);

            var Agents = new List<Agent>()
            {
                new Agent() { AgentId = 1, Name = "AgentOne" },
                new Agent() { AgentId = 2, Name = "AgentTwo" },
                new Agent() { AgentId = 3, Name = "AgentThree" }
            };

            agentServiceMock.Setup(a=>a.GetAllAgentAsync()).ReturnsAsync(Agents); 

            using (var stringWriter = new StringWriter())
            {
                var originalConsoleOut = Console.Out;
                Console.SetOut(stringWriter);

                await agentUI.ViewAllAgents();

                var output = stringWriter.ToString();
                Console.WriteLine("Captured Output:");
                Console.WriteLine(output);

                Assert.That(output, Does.Contain("Here is List of All Agents"));
                Assert.That(output, Does.Contain("Agent ID: 1, Name: AgentOne"));
                Assert.That(output, Does.Contain("Agent ID: 2, Name: AgentTwo"));
                Assert.That(output, Does.Contain("Agent ID: 3, Name: AgentThree"));
            }
            agentServiceMock.Verify(a => a.GetAllAgentAsync(), Times.Once);
        }

        [Test]
        public async Task UpdateAgent_WhenCalled_UpdatedTheNameOfAgent()
        {
            var agentServiceMock = new Mock<IAgentService>();
            var agentUI = new AgentUI(agentServiceMock.Object);

            var existingAgents = new List<Agent>()
            {
              new Agent() { AgentId = 1, Name = "AgentOne" },
              new Agent() { AgentId = 2, Name = "AgentTwo" },
              new Agent() { AgentId = 3, Name = "AgentThree" }
            };

            agentServiceMock.Setup(a => a.GetAllAgentAsync()).ReturnsAsync(existingAgents);
            agentServiceMock.Setup(a => a.GetAgentByIdAsync(1)).ReturnsAsync(existingAgents.First());
            agentServiceMock.Setup(a => a.UpdateAgentAsync(It.IsAny<Agent>())).Verifiable();

            var input = "1" + Environment.NewLine + "AgentOneUpdated" + Environment.NewLine;
            var consoleInput = new StringReader(input);
            Console.SetIn(consoleInput);
         
            await agentUI.UpdateAgent();

            agentServiceMock.Verify(a => a.UpdateAgentAsync(It.Is<Agent>(ag => ag.AgentId == 1 && ag.Name == "AgentOneUpdated")), Times.Once);

            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
        }

    }
}
