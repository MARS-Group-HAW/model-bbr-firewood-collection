using Mars.Components.Services.Planning.Implementation;
using Mars.Components.Services.Planning.Interfaces;

namespace Firewood_Model_Test.Goals
{
    public class SustainEngerySupplyGoal : GoapGoal
    {
        public SustainEngerySupplyGoal(IGoapAgentStates agent) : base(agent)
        {
//            AddOrUpdateDesiredState(FirewoodState.HasEnoughEnergy, true);
        }
    }
}