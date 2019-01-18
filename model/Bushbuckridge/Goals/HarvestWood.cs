using Bushbuckridge.Agents.Collector;
using Bushbuckridge.States;
using Mars.Components.Services.Planning.Implementation;

namespace Bushbuckridge.Goals
{
    public class HarvestWood : GoapGoal
    {
        private readonly FirewoodCollector _agent;

        public HarvestWood(FirewoodCollector agent) : base(agent.AgentStates)
        {
            _agent = agent;
            
            AddOrUpdateDesiredState(FirewoodState.WoodstockRaised, true);
        }
        
        public new void UpdateRelevance()
        {
           Relevance = _agent.MeasureDistanceAndStockForAlivewood();
        }
    }
}