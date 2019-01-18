using System;
using Firewood_Collection.States;
using GOAP_Test.Agents;
using Mars.Components.Services.Planning.Implementation;

namespace Firewood_Model_Test.Actions
{
    public class GoToTreeWithDeadwoodByFoot : GoapAction
    {
        private readonly FirewoodCollector _agent;

        public GoToTreeWithDeadwoodByFoot(FirewoodCollector agent) : base(agent.AgentStates, 10)
        {
            _agent = agent;
            
            AddOrUpdatePrecondition(FirewoodState.WoodstockRaised, false);
            AddOrUpdatePrecondition(FirewoodState.IsNearDeadwoodTree, false);
            
            AddOrUpdateEffect(FirewoodState.IsNearDeadwoodTree, true);
            AddOrUpdateEffect(FirewoodState.AtExploitablePosition, true);
        }

        protected override bool ExecuteAction()
        {
            Console.WriteLine("GoToTreeWithAlivewoodByFoot");
            return false; // _agent.GoToNextDeadwoodTree();
        }
    }
}