using Bushbuckridge.Agents.Collector;
using Bushbuckridge.States;
using Mars.Components.Services.Planning.Implementation;

namespace Bushbuckridge.Goals
{
    public class ExploreGoal : GoapGoal
    {
        public ExploreGoal(FirewoodCollector agent) : base(agent.AgentStates, 0.2f)
        {
            AddOrUpdateDesiredState(FirewoodState.AtExploitablePosition, true);
            
            AddOrUpdateDesiredState(FirewoodState.Home, false);
            AddOrUpdateDesiredState(FirewoodState.HasEnoughFirewood, false);
        }
    }
}