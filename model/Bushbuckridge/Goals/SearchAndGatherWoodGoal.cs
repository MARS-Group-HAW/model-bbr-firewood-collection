using Bushbuckridge.Agents.Collector;
using Bushbuckridge.States;
using Mars.Components.Services.Planning.Implementation;

namespace Bushbuckridge.Goals
{
    public class SearchAndGatherWoodGoal : GoapGoal
    {
        private readonly FirewoodCollector _agent;

        public SearchAndGatherWoodGoal(FirewoodCollector agent) : base(agent.AgentStates, 0.2f)
        {
            _agent = agent;
            
            AddOrUpdateDesiredState(FirewoodState.HasEnoughFirewood, true);
        }
        
        //TODO erstmal in gebiet laufen, wo genug da ist (neues Ziel)
        
        public new void UpdateRelevance()
        {
//           Relevance = _agent.IsAtExploitableTree() ? 0f : 0.9f;
        }
    }
}