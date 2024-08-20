
namespace RentSoftware.Core.Entities
{
    public class Agent
    {
        public Agent(int agentId, string name)
        {
            AgentId = agentId;
            Name = name;
        }

        public Agent() { }

        public int AgentId { get; set; }

        public string Name { get; set; }

        public ICollection<Rent> Rents { get; set; }
    }
}
