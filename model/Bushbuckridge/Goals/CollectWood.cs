using Firewood_Collection.States;
using GOAP_Test.Agents;
using Mars.Components.Services.Planning.Implementation;

namespace FirewoodCollectionv2.Goals
{
    public class CollectWood : GoapGoal
    {
        private readonly FirewoodCollector _agent;

        public CollectWood(FirewoodCollector agent) : base(agent.AgentStates)
        {
            _agent = agent;
            
            AddOrUpdateDesiredState(FirewoodState.WoodstockRaised, true);
        }
        
        public override void UpdateRelevance()
        {
//            Relevance = _agent.MeasureDistanceAndStockForDeadwood();
        }
    }
}