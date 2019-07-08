using Bushbuckridge.Agents.Collector;
using Bushbuckridge.States;
using Mars.Components.Services.Planning.Implementation;
using Mars.Mathematics;
using SavannaTrees;

namespace Bushbuckridge.Actions
{
    public class CutStemAction : GoapAction
    {
        private const int originalCost = 100;
        private const double treeDiameterWorthExploiting = 3;

        private readonly FirewoodCollector _agent;
        private Tree _tree;

        public CutStemAction(FirewoodCollector agent) : base(agent.AgentStates, originalCost)
        {
            _agent = agent;

            AddOrUpdatePrecondition(FirewoodState.CaAnTtAdultAvailable, true);
            AddOrUpdatePrecondition(FirewoodState.HasAxe, true);

            AddOrUpdatePrecondition(FirewoodState.HasEnoughFirewood, false);
            AddOrUpdatePrecondition(FirewoodState.WoodstockRaised, false);

            AddOrUpdateEffect(FirewoodState.WoodstockRaised, true);
            AddOrUpdateEffect(FirewoodState.Home, false);
        }

        protected override bool ExecuteAction()
        {
            return _agent.CutBranch(_tree);
        }

        public override void UpdateCost()
        {
            _tree = _agent.FindTree(tree => tree.StemDiameter > treeDiameterWorthExploiting && !tree.IsSpecies("sb"));
            var treeFound = _tree != null;
            AgentStates.AddOrUpdateState(FirewoodState.CaAnTtAdultAvailable, treeFound);

            if (treeFound)
            {
                var distance = (float) Distance.Euclidean(_agent.CollectingPosition[0], _agent.CollectingPosition[1],
                    _tree[0],
                    _tree[1]);
                Cost = originalCost * distance;
            }
        }
    }
}