using Bushbuckridge.Agents.Collector;
using Bushbuckridge.States;
using Mars.Components.Services.Planning.Implementation;

namespace Bushbuckridge.Goals
{
    /// <summary>
    /// 
    /// </summary>
    public class EvaluateSituationGoal : GoapGoal
    {
        public EvaluateSituationGoal(FirewoodCollector agent) : base(agent.AgentStates)
        {
            AddOrUpdateDesiredState(FirewoodState.Evaluated, true);
        }
    }
}