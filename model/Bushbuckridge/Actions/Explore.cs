using System;
using Firewood_Collection.States;
using GOAP_Test.Agents;
using Mars.Components.Services.Planning.Implementation;

namespace Firewood_Model_Test.Actions
{
    public class Explore : GoapAction
    {
        private readonly FirewoodCollector _agent;

        public Explore(FirewoodCollector agent) : base(agent.AgentStates, 0)
        {
            _agent = agent;
            
            AddOrUpdateEffect(FirewoodState.WoodstockRaised, false);
            AddOrUpdateEffect(FirewoodState.Orientated, true);
        }

        protected override bool ExecuteAction()
        {
            var explore = _agent.Explore();
            Console.WriteLine("Explore -> "+explore);
            return explore;
        }
    }
}