using Firewood_Collection.States;
using GOAP_Test.Agents;
using Mars.Components.Services.Planning.Implementation;

namespace Firewood_Model_Test.Actions
{
    public class CutBranchesCaAn : GoapAction
    {
        private readonly FirewoodCollector _agent;

        public CutBranchesCaAn(FirewoodCollector agent) : base(agent.AgentStates, 50)
        {
            _agent = agent;
            
            AddOrUpdatePrecondition(FirewoodState.IsNearAlivewoodTree, true);
            AddOrUpdatePrecondition(FirewoodState.HasAxe, true);
            
            AddOrUpdatePrecondition(FirewoodState.Orientated, true);
            AddOrUpdatePrecondition(FirewoodState.WoodstockRaised, false);
            AddOrUpdatePrecondition(FirewoodState.HasEnoughFirewood, false);

            AddOrUpdateEffect(FirewoodState.Orientated, false);
            AddOrUpdateEffect(FirewoodState.WoodstockRaised, true);
        }

        protected override bool ExecuteAction()
        {
            return _agent.CollectAliveWood();
        }
    }
}