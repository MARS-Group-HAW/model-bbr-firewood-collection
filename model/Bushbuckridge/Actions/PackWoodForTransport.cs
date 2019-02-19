using Bushbuckridge.Agents.Collector;
using Bushbuckridge.States;
using Mars.Components.Services.Planning.Implementation;

namespace Bushbuckridge.Actions
{
    public class PackWoodForTransport : GoapAction
    {
        private readonly FirewoodCollector _agent;

        public PackWoodForTransport(FirewoodCollector agent) : base(agent.AgentStates, 10)
        {
            _agent = agent;
            
            AddOrUpdatePrecondition(FirewoodState.WoodstockRaised, true);
            
            AddOrUpdateEffect(FirewoodState.WoodstockRaised, false);
            AddOrUpdateEffect(FirewoodState.AtExploitablePosition, false);
            AddOrUpdateEffect(FirewoodState.HasEnoughFirewood, true);
        }

        protected override bool ExecuteAction()
        {
            return _agent.PackWoodForTransport();
        }
    }
}