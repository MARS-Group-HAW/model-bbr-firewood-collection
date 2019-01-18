using Firewood_Collection.States;
using GOAP_Test.Agents;
using Mars.Components.Services.Planning.Implementation;

namespace FirewoodCollectionv2.Goals
{
    public class ReturnWithWood : GoapGoal
    {
        private readonly FirewoodCollector _agent;

        public ReturnWithWood(FirewoodCollector agent) : base(agent.AgentStates)
        {
            _agent = agent;
            
            AddOrUpdateDesiredState(FirewoodState.Home, true);
            AddOrUpdateDesiredState(FirewoodState.HasEnoughFirewood, true);
        }

        public new void UpdateRelevance()
        {
//            Relevance = 1f; //_agent.HasEnoughFirewood() ? 1f : 0f;
        }
    }
}