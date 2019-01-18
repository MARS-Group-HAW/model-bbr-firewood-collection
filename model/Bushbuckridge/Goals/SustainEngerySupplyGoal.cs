using Mars.Components.Services.Planning.Implementation;
using Mars.Components.Services.Planning.Interfaces;

namespace Bushbuckridge.Goals
{
    public class SustainEngerySupplyGoal : GoapGoal
    {
        public SustainEngerySupplyGoal(IGoapAgentStates agent) : base(agent)
        {
//            AddOrUpdateDesiredState(FirewoodState.HasEnoughEnergy, true);
        }
    }
}