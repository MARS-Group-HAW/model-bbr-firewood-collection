using Bushbuckridge.Agents.Collector;
using Bushbuckridge.States;
using Mars.Components.Services.Planning.Implementation;

namespace Bushbuckridge.Actions
{
    public class CutBranchesSb : GoapAction
    {
        private readonly FirewoodCollector _agent;

        public CutBranchesSb(FirewoodCollector agent) : base(agent.AgentStates, 70)
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