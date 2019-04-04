using Bushbuckridge.Agents.Collector;
using Bushbuckridge.States;
using Mars.Components.Services.Planning.Implementation;

namespace Bushbuckridge.Actions
{
    public class CarryWoodHome : GoapAction
    {
        private readonly FirewoodCollector _agent;

        public CarryWoodHome(FirewoodCollector agent) : base(agent.AgentStates, 10)
        {
            _agent = agent;

            AddOrUpdatePrecondition(FirewoodState.HasEnoughFirewood, true);

            AddOrUpdateEffect(FirewoodState.AtExploitablePosition, false);
            AddOrUpdateEffect(FirewoodState.TimeIsUp, false);
            AddOrUpdateEffect(FirewoodState.HasEnoughFirewood, false);
            
            AddOrUpdateEffect(FirewoodState.Home, true);
        }

        protected override bool ExecuteAction()
        {
            return _agent.CarryWoodHome();
        }
    }
}