﻿using System;
using Bushbuckridge.Agents.Collector;
using Bushbuckridge.States;
using Mars.Components.Services.Planning.Implementation;

namespace Bushbuckridge.Actions
{
    public class GoToTreeWithAlivewoodByFoot : GoapAction
    {
        private readonly FirewoodCollector _agent;

        public GoToTreeWithAlivewoodByFoot(FirewoodCollector agent) : base(agent.AgentStates, 0)
        {
            _agent = agent;
            
            AddOrUpdatePrecondition(FirewoodState.WoodstockRaised, false);
            AddOrUpdatePrecondition(FirewoodState.IsNearAlivewoodTree, false);
            
            AddOrUpdateEffect(FirewoodState.IsNearAlivewoodTree, true);
            AddOrUpdateEffect(FirewoodState.AtExploitablePosition, true);
        }

        protected override bool ExecuteAction()
        {
            Console.WriteLine("GoToTreeWithAlivewoodByFoot");
            return false; //_agent.GoToNextDeadwoodTree();
        }
    }
}