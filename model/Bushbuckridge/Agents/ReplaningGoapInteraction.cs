using System;
using System.Collections.Generic;
using System.Linq;
using Mars.Components.Services.Planning.Implementation;
using Mars.Components.Services.Planning.Implementation.ActionCommons;
using Mars.Components.Services.Planning.Interfaces;
using Mars.Components.Services.Planning.Worldstate;
using Mars.Interfaces.Agent;

namespace FirewoodCollectionv2.Agents
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
            IList<IGoapAction> goapActions = new List<IGoapAction>();
            do
            {
                goapActions = _goapPlanner.Plan();
                var goal = _goapPlanner.SelectedGoal;
                Console.WriteLine(goal + " " + goal.Relevance); //TODO delete
                Print(_states.States.Values);

                foreach (var action in goapActions)
                {
                    action.Execute();
                }
            } while (goapActions.Any() && !goapActions.First().Equals(AllGoalsSatisfiedAction.Instance));
        }

        private void Print(Dictionary<IGoapStateKey, GoapStateProperty>.ValueCollection items)
        {
            if (items != null)
            {
                foreach (var item in items)
                {
                    Console.Write(item + ", ");
                }
                Console.WriteLine("--");
            }
        }
    }
}