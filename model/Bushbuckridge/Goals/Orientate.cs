using Bushbuckridge.Agents.Collector;
using Bushbuckridge.States;
using Mars.Components.Services.Planning.Implementation;

namespace Bushbuckridge.Goals
{
    public class Orientate : GoapGoal
    {
        private readonly FirewoodCollector _agent;

        public Orientate(FirewoodCollector agent) : base(agent.AgentStates)
        {
            _agent = agent;
            
            AddOrUpdateDesiredState(FirewoodState.Orientated, true);
        }
        
        //TODO erstmal in gebiet laufen, wo genug da ist (neues Ziel)
        
        public new void UpdateRelevance()
        {
//           Relevance = _agent.IsAtExploitableTree() ? 0f : 0.9f;
        }
    }
}