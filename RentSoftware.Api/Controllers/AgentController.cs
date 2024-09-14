using Microsoft.AspNetCore.Mvc;
using RentSoftware.Core.Entities;
using RentSoftware.Core.Services;
using RentSoftware.Service;

namespace RentSoftware.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly IAgentService _agentService;

        public AgentController(IAgentService agentService)
        {
            _agentService = agentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agent>>> GetAllAgentAsync()
        {
            var allAgents = await _agentService.GetAllAgentAsync();
            return Ok(allAgents);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Agent>> GetAgentById(int id)
        {
            var agent = await _agentService.GetAgentByIdAsync(id);

            if (agent == null)
            {
                return BadRequest($"Agent with Id : {id} not found");
            }

            return Ok(agent);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Agent>> UpdateAgent(int id, Agent agent)
        {
            var existingAgent = await _agentService.GetAgentByIdAsync(id);

            if (existingAgent == null)
            {
                return BadRequest($"Agent with Id : {id} not found");
            }

            existingAgent.Name = agent.Name;

            await _agentService.UpdateAgentAsync(existingAgent);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAgent(int id)
        {
            var agent = await _agentService.GetAgentByIdAsync(id);
            if (agent == null)
            {
                return NotFound();
            }

            await _agentService.DeleteAgentAsync(agent);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Agent>> AddAgent(Agent agent)
        {
            if (agent == null)
            {
                return BadRequest("Agent cannot be null.");
            }
            await _agentService.AddAgentAsync(agent);
            return CreatedAtAction(nameof(GetAgentById), new { id = agent.AgentId }, agent);
        }
    }
}
