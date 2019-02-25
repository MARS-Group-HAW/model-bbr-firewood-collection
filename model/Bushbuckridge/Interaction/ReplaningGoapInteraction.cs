using System;
using System.Collections.Generic;
using System.Linq;
using Bushbuckridge.Goals;
using Mars.Components.Services.Planning.Implementation;
using Mars.Components.Services.Planning.Implementation.ActionCommons;
using Mars.Components.Services.Planning.Interfaces;
using Mars.Components.Services.Planning.Worldstate;
using Mars.Interfaces.Agent;

namespace Bushbuckridge.Agents
{
    public class ReplaningGoapInteraction : IInteraction
    {
        private readonly GoapPlanner _goapPlanner;
        private readonly IGoapAgentStates _states;

        public ReplaningGoapInteraction(GoapPlanner goapPlanner, IGoapAgentStates states)
        {
            _goapPlanner = goapPlanner;
            _states = states;
        }

        public void Execute()
        {
            IList<IGoapAction> actions = new List<IGoapAction>();
            do
            {
                actions = _goapPlanner.Plan();
                var goal = _goapPlanner.SelectedGoal;
//                Console.WriteLine("SELECTED GOAL: " + goal);
//                Print(_states.States.Values);
//                Print(actions);
                foreach (var action in actions)
                {
                    if (!action.Execute())
                    {
                        break;
                    }
                }

                if (goal is ReturnHomeGoal finishingGoal && finishingGoal.IsSatisfied())
                {
                    break;
                }
            } while (actions.Any() && !actions.First().Equals(NoGoalReachableAction.Instance));
        }

        private void Print(IList<IGoapAction> goapActions)
        {
            foreach (var item in goapActions)
            {
                Console.Write(item + ", ");
            }

            Console.WriteLine("--");
        }

        private void Print(Dictionary<IGoapStateKey, GoapStateProperty>.ValueCollection items)
        {
            if (items != null)
            {
                Console.Write("STATES: ");
                foreach (var item in items)
                {
                    Console.Write(item + ", ");
                }

                Console.WriteLine(";");
            }
        }
    }
}