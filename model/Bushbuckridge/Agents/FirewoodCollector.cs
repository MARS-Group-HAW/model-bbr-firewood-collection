using System;
using System.Collections.Generic;
using System.Linq;
using Bushbuckridge.Actions;
using Bushbuckridge.Goals;
using Bushbuckridge.States;
using KruegerNationalPark;
using Mars.Components.Agents;
using Mars.Components.Environments;
using Mars.Components.Services.Planning.Implementation;
using Mars.Components.Services.Planning.Interfaces;
using Mars.Interfaces.Agent;
using Mars.Interfaces.Environment.GeoCommon;
using Mars.Interfaces.Layer;
using Mars.Interfaces.LIFECapabilities;

namespace Bushbuckridge.Agents.Collector
{
//TODO females sollen min 50 % Totholz sammeln
    // ReSharper disable once ClassNeverInstantiated.Global
    public class FirewoodCollector : GeoAgent<FirewoodCollector>
    {
        public IGoapAgentStates AgentStates { get; set; }

        private readonly GoapPlanner _goapPlanner;

        private readonly FirewoodCollectorLayer _layer;
        private readonly SavannaLayer _treeLayer;
        private Tree _currentTreeWithDeadwood;
        private Tree _currentTreeWithAlivewood;
        public override FirewoodCollector AgentReference => this;

        private const double deadMassWorthExploiting = 1;
        private const double livingMassWorthExploiting = 4;
        private const double treeDiameterWorthExploiting = 3;
        private const double woodAmountToReach = 20;

        public double woodAmountCollectedThisTick { get; private set; }

        [PublishForMappingInMars]
        public FirewoodCollector(ILayer layer, RegisterAgent register, UnregisterAgent unregister,
            GeoGridEnvironment<GeoAgent<FirewoodCollector>> env, SavannaLayer treeLayer, Guid id,
            double lat, double lon) :
            base(layer, register, unregister, env, new GeoCoordinate(lat, lon), id.ToByteArray())
        {
            _treeLayer = treeLayer;

            AgentStates = new GoapAgentStates();
            AgentStates.AddOrUpdateState(FirewoodState.HasAxe, true);

            _goapPlanner = new GoapPlanner(AgentStates);
            var searchAndGatherWoodGoal = new SearchAndGatherWoodGoal(this);
            var evaluateSituationGoal = new EvaluateSituationGoal(this);
            var goHomeGoal = new GoHomeGoal(this);

            _goapPlanner.AddGoal(searchAndGatherWoodGoal);
            _goapPlanner.AddGoal(evaluateSituationGoal);
            _goapPlanner.AddGoal(goHomeGoal);

            searchAndGatherWoodGoal.AddAction(new Explore(this));
            searchAndGatherWoodGoal.AddAction(new CutShoots(this));
            // searchAndGatherWoodGoal.AddAction(new CollectDeadWood(this));

            evaluateSituationGoal.AddAction(new EvaluateAndPackWoodForTransport(this));

            goHomeGoal.AddAction(new CarryWoodHome(this));
            goHomeGoal.AddAction(new AbortAndGoHome(this));
        }

        public SavannaLayer Savanna { get; set; }

        protected override IInteraction Reason()
        {
//            if (_treeLayer.GetCurrentTick() % 7 != 0)
//            {
//                // only activate once a week
//                return new NoActionInteraction();
//            }

            Refresh();

            return new ReplaningGoapInteraction(_goapPlanner, AgentStates);
        }

        private void Refresh()
        {
            woodAmountCollectedThisTick = 0;
            AgentStates.AddOrUpdateState(FirewoodState.HasEnoughFirewood, false);
            AgentStates.AddOrUpdateState(FirewoodState.TimeIsUp, false);

            //TODO sollen die nicht durch die Ziele neu gesetzt werden?
            //zB neues Ziel bring Holz zurück, dort werden alle States umgesetzt
        }

        public bool CollectDeadWood()
        {
            if (_currentTreeWithDeadwood != null)
                woodAmountCollectedThisTick += _currentTreeWithDeadwood.TakeDeadWoodMass(woodAmountToReach);
            return true;
        }

        public bool CollectAliveWood()
        {
            if (_currentTreeWithAlivewood != null)
                woodAmountCollectedThisTick += _currentTreeWithAlivewood.TakeLivingWoodMass(woodAmountToReach);
            return true;
        }

        public bool CutShoots()
        {
            return CollectAliveWood();
        }

        public bool HasEnoughFirewood()
        {
            return woodAmountCollectedThisTick >= woodAmountToReach;
        }

        public bool CarryWoodHome()
        {
            AgentStates.AddOrUpdateState(FirewoodState.HasEnoughFirewood, HasEnoughFirewood());
            //TODO check also time 
            Console.WriteLine("CarryWoodHome wood: " + woodAmountCollectedThisTick + "kg");
            return true;
        }

        public bool Explore()
        {
            AgentStates.AddOrUpdateState(FirewoodState.HasEnoughFirewood, HasEnoughFirewood());

            _currentTreeWithDeadwood = null;
            _currentTreeWithAlivewood = null;
            //TODO wenn neuer Baum genutzt, dann auch Pos dahin verlagern.  
            //TODO ursprüngliche Position speichern.

            _currentTreeWithDeadwood = FindTree(tree => tree.DeadWoodMass > deadMassWorthExploiting);
            AgentStates.AddOrUpdateState(FirewoodState.IsNearDeadwoodTree, _currentTreeWithDeadwood != null);

            _currentTreeWithAlivewood = FindTree(tree => tree.MyTreeAgeGroup.Equals(TreeAgeGroup.Juvenile) &&
                                                         tree.StemDiameter > treeDiameterWorthExploiting);
            AgentStates.AddOrUpdateState(FirewoodState.IsNearAlivewoodTree, _currentTreeWithAlivewood != null);

            return true;
        }

        private Tree FindTree(Func<Tree, bool> func)
        {
            return _treeLayer._TreeEnvironment.GetNearest(Latitude, Longitude, -1, func);
        }

        public bool IsAtExploitableTree()
        {
            if (_currentTreeWithDeadwood == null) return false;
            return _currentTreeWithDeadwood.DeadWoodMass >
                   deadMassWorthExploiting; //|| _currentTreeWithDeadwood.AliveMass > livingMassWorthExploiting;
        }

        public double MeasureDistanceAndStockForDeadwood()
        {
            if (_currentTreeWithDeadwood == null) return 0;
            Console.WriteLine(PerCent(_currentTreeWithDeadwood.DeadWoodMass,
                woodAmountToReach - woodAmountCollectedThisTick));
            return PerCent(_currentTreeWithDeadwood.DeadWoodMass, woodAmountToReach - woodAmountCollectedThisTick);
        }

        public double MeasureDistanceAndStockForAlivewood()
        {
            if (_currentTreeWithDeadwood == null) return 0;
            return PerCent(_currentTreeWithDeadwood.LivingWoodMass, woodAmountToReach - woodAmountCollectedThisTick);
        }

        private static double PerCent(double part, double full)
        {
            return 100d / full * part;
        }

        public bool PackWoodForTransport()
        {
            AgentStates.AddOrUpdateState(FirewoodState.HasEnoughFirewood, HasEnoughFirewood());
            AgentStates.AddOrUpdateState(FirewoodState.TimeIsUp,
                _currentTreeWithDeadwood == null && _currentTreeWithAlivewood == null);
            //TODO or no time anymore
            return true;
        }
    }
}