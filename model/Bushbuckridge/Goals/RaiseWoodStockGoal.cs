using Bushbuckridge.Agents.Collector;
using Bushbuckridge.States;
using Mars.Components.Services.Planning.Implementation;

namespace Bushbuckridge.Goals
{
    /// <summary>
    /// 
    /// //TODO erstmal in gebiet laufen, wo genug da ist (neues Ziel)
    /// </summary>
    public class RaiseWoodStockGoal : GoapGoal
    {
        public RaiseWoodStockGoal(FirewoodCollector agent) : base(agent.AgentStates, 0.15f)
        {
            AddOrUpdateDesiredState(FirewoodState.Home, false);
            AddOrUpdateDesiredState(FirewoodState.WoodstockRaised, true);
        }
    }
}