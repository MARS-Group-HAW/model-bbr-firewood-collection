﻿using Bushbuckridge.Agents.Collector;
using Bushbuckridge.States;
using Mars.Components.Services.Planning.Implementation;

namespace Bushbuckridge.Goals
{
    public class GoHomeGoal : GoapGoal
    {
        private readonly FirewoodCollector _agent;

        public GoHomeGoal(FirewoodCollector agent) : base(agent.AgentStates, 0.1f)
        {
            _agent = agent;
            
            AddOrUpdateDesiredState(FirewoodState.Home, true);
            AddOrUpdateDesiredState(FirewoodState.HasEnoughFirewood, true);
        }

        public new void UpdateRelevance()
        {
//            Relevance = 1f; //_agent.HasEnoughFirewood() ? 1f : 0f;
        }
    }
}