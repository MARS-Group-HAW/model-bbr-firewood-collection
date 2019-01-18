using System;
using System.Collections.Generic;
using Bushbuckridge.Goals;
using Mars.Components.Environments.SpatialAPI.Entities.Transformation;
using Mars.Components.Services.Planning.Implementation;
using Mars.Components.Services.Planning.Interfaces;

namespace Bushbuckridge.Agents
{
    public class Household : GoapAgentStates
    {
//        private readonly FirewoodCollector _man, _woman;
        public int ChildCount { get; }

        private readonly IGoapPlanner _goapPlanner;
        private readonly IGoapGoal _sustainEngergySupply;

        private int Energy { get; set; }

        public Household(Dictionary<string, object> initData, Vector3 position, List<FirewoodSite> sites)
        {
//            _man = new FirewoodCollector();
//            _woman = new FirewoodCollector();
            ChildCount = new Random().Next(8);
            Energy = new Random().Next(50); //(int) initData["energy"];

//            AddOrUpdateState(FirewoodState.HasEnoughEnergy, false);

            EvaluateEnergySupply();

            _sustainEngergySupply = new SustainEngerySupplyGoal(this);
            //_sustainEngergySupply.AddAction(new SendFirewoodCollector(0, "Send firewood collector", _woman));

           _goapPlanner = new GoapPlanner(this);
            _goapPlanner.AddGoal(_sustainEngergySupply);
        }

        public void Reason()
        {
            ConsumeEnergy();

            var actionPlan = _goapPlanner.Plan();

            if (actionPlan != null)
            {
                foreach (var action in actionPlan)
                {
                    action.Execute();
                }
            }
            else
            {
                Console.WriteLine("Action list was empty");
            }
        }

        private void ConsumeEnergy()
        {
            Energy -= CalculateEnergyConsumption();
            EvaluateEnergySupply();
        }

        private int CalculateEnergyConsumption()
        {
            const int aveargeChildCount = 5;
            var offset = ChildCount - aveargeChildCount;
            return (IsWinterSeason() ? 20 : 10) + offset * 2;
        }

        private bool IsWinterSeason()
        {
            return true; //TODO calculate season by tick
        }

        private void EvaluateEnergySupply()
        {
//            AddOrUpdateState(FirewoodState.HasEnoughEnergy, Energy > 15);
        }
    }
}