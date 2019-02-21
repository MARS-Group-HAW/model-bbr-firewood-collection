using Bushbuckridge.Agents.Collector;
using Bushbuckridge.States;
using Mars.Components.Services.Planning.Implementation;

namespace Bushbuckridge.Actions
{
    public class CollectDeadWood : GoapAction
    {
        private readonly FirewoodCollector _agent;

        public CollectDeadWood(FirewoodCollector agent) : base(agent.AgentStates, 10)
        {
            _agent = agent;
            
            AddOrUpdatePrecondition(FirewoodState.AtExploitablePosition, true);
            
            AddOrUpdateEffect(FirewoodState.AtExploitablePosition, false);
            AddOrUpdateEffect(FirewoodState.WoodstockRaised, true);
        }

        protected override bool ExecuteAction()
        {
            return _agent.CollectDeadWood();
        }
    }
}