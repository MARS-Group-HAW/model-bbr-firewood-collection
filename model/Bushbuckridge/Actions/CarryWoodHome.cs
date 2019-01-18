using Firewood_Collection.States;
using GOAP_Test.Agents;
using Mars.Components.Services.Planning.Implementation;

namespace Firewood_Model_Test.Actions
{
    public class CarryWoodHome : GoapAction
    {
        private readonly FirewoodCollector _agent;

        public CarryWoodHome(FirewoodCollector agent) : base(agent.AgentStates, 10)
        {
            _agent = agent;
            
            AddOrUpdatePrecondition(FirewoodState.HasEnoughFirewood, true);
            AddOrUpdateEffect(FirewoodState.Home, true);
        }

        protected override bool ExecuteAction()
        {
            return _agent.CarryWoodHome();
        }
    }
}