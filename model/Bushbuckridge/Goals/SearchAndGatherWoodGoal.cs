using Bushbuckridge.Agents.Collector;
using Bushbuckridge.States;
using Mars.Components.Services.Planning.Implementation;

namespace Bushbuckridge.Goals
{
    /// <summary>
    /// 
    /// //TODO erstmal in gebiet laufen, wo genug da ist (neues Ziel)
    /// </summary>
    public class SearchAndGatherWoodGoal : GoapGoal
    {
        public SearchAndGatherWoodGoal(FirewoodCollector agent) : base(agent.AgentStates)
        {
            AddOrUpdateDesiredState(FirewoodState.WoodstockRaised, true);
        }
    }
}