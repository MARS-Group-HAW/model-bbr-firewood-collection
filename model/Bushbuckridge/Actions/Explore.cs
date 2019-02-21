using Bushbuckridge.Agents.Collector;
using Bushbuckridge.States;
using Mars.Components.Services.Planning.Implementation;

namespace Bushbuckridge.Actions
{
    public class Explore : GoapAction
    {
        private readonly FirewoodCollector _agent;

        public Explore(FirewoodCollector agent) : base(agent.AgentStates)
        {
            _agent = agent;
            
            AddOrUpdatePrecondition(FirewoodState.TimeIsUp, false);
            AddOrUpdatePrecondition(FirewoodState.HasEnoughFirewood, false);
            
            AddOrUpdateEffect(FirewoodState.Evaluated, false);
            AddOrUpdateEffect(FirewoodState.Home, false);
            AddOrUpdateEffect(FirewoodState.AtExploitablePosition, true);
        }

        protected override bool ExecuteAction()
        {
            return _agent.Explore();
        }
    }
}