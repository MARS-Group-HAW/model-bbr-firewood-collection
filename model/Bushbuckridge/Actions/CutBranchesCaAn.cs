using Bushbuckridge.Agents.Collector;
using Bushbuckridge.States;
using Mars.Components.Services.Planning.Implementation;

namespace Bushbuckridge.Actions
{
    public class CutBranchesCaAn : GoapAction
    {
        private static readonly int originalCost;
        private readonly FirewoodCollector _agent;

        public CutBranchesCaAn(FirewoodCollector agent) : base(agent.AgentStates, originalCost)
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
            return _agent.CutBranch();
        }
        
        public override void UpdateCost()
        {
            Cost = originalCost + _agent.GetCostForAliveWoodDistance();
        }
    }
}