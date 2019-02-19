using System;
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
            
            AddOrUpdateEffect(FirewoodState.WoodstockRaised, false);
            AddOrUpdateEffect(FirewoodState.Home, false);
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