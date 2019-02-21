using Bushbuckridge.Agents.Collector;
using Bushbuckridge.States;
using Mars.Components.Services.Planning.Implementation;

namespace Bushbuckridge.Goals
{
    public class GoHomeGoal : GoapGoal
    {
        public GoHomeGoal(FirewoodCollector agent) : base(agent.AgentStates)
        {
            AddOrUpdateDesiredState(FirewoodState.Home, true);
            //    AddOrUpdateDesiredState(FirewoodState.HasEnoughFirewood, true);
        }
    }
}