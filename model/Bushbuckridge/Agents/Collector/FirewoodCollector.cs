using System;
using System.Collections.Generic;
using Bushbuckridge.Actions;
using Bushbuckridge.Agents.Tree;
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
    public class FirewoodCollector : GeoAgent<FirewoodCollector>
    {
        private readonly Random random = new Random();
        public IGoapAgentStates AgentStates { get; set; }

        private readonly List<IExploitableTree> _treesOfTheDay;
        private readonly GoapPlanner _goapPlanner;

        private readonly FirewoodCollectorLayer _layer;
        private readonly SavannaLayer _treeLayer;
        private KruegerNationalPark.Tree _currentTreeWithDeadwood;
        private KruegerNationalPark.Tree _currentTreeWithAlivewood;
        public override FirewoodCollector AgentReference => this;

        private const double deadMassWorthExploiting = 5;
        private const double aliveMassWorthExploiting = 5;
        private const double woodAmountToReach = 25;

        private double woodAmountCollectedThisTick;

        [PublishForMappingInMars]
        public FirewoodCollector(FirewoodCollectorLayer layer, RegisterAgent register, UnregisterAgent unregister,
            GeoGridEnvironment<GeoAgent<FirewoodCollector>> env, SavannaLayer treeLayer, Guid id,
            double lat, double lon) :
            base(layer, register, unregister, env, new GeoCoordinate(lat, lon), id.ToByteArray())
        {
            _treeLayer = treeLayer;
            _treesOfTheDay = new List<IExploitableTree>();

            AgentStates = new GoapAgentStates();
            AgentStates.AddOrUpdateState(FirewoodState.HasAxe, true);

            _goapPlanner = new GoapPlanner(AgentStates);
            _goapPlanner.AddGoal(new Orientate(this));
            _goapPlanner.AddGoal(new CollectWood(this));
            //_goapPlanner.AddGoal(new HarvestWood(this));
            _goapPlanner.AddGoal(new ReturnWithWood(this));

            //_goapPlanner.AddAction(new GoToTreeWithDeadwoodByFoot(0.5f, "GoToTreeWithDeadwoodByFoot", this));
            // _goapPlanner.AddAction(new GoToTreeWithAlivewoodByFoot(1, "GoToTreeWithAlivewoodByFoot", this));
            _goapPlanner.AddAction(new Explore(this));
            _goapPlanner.AddAction(new CollectDeadWood(this));
            _goapPlanner.AddAction(new CutShoots(this));
            _goapPlanner.AddAction(new CutBranchesCaAn(this));
            _goapPlanner.AddAction(new CutBranchesSb(this));
            _goapPlanner.AddAction(new CutStem(this));
            _goapPlanner.AddAction(new CarryWoodHome(this));
            
        }

        public SavannaLayer Savanna { get; set; }

        protected override IInteraction Reason()
        {
            Refresh();

            return new ReplaningGoapInteraction(_goapPlanner, AgentStates);
        }

        private void Refresh()
        {
            woodAmountCollectedThisTick = 0;
            _treesOfTheDay.Clear();

            //TODO sollen die nicht durch die Ziele neu gesetzt werden?
            //zB neues Ziel bring Holz zurück, dort werden alle States umgesetzt
            AgentStates.States.Clear();
            AgentStates.AddOrUpdateState(FirewoodState.HasEnoughFirewood, false);
            AgentStates.AddOrUpdateState(FirewoodState.IsNearDeadwoodTree, false);
            AgentStates.AddOrUpdateState(FirewoodState.IsNearAlivewoodTree, false);
        }

        public bool CollectDeadWood()
        {
            if (_currentTreeWithDeadwood == null) return false;

            woodAmountCollectedThisTick += _currentTreeWithDeadwood.TakeDeadWoodMass(woodAmountToReach);
            return true;
        }

        public bool CollectAliveWood()
        {
            if (_currentTreeWithAlivewood == null) return false;
            woodAmountCollectedThisTick += _currentTreeWithAlivewood.TakeLivingWoodMass(30);
            return true;
        }

        public bool HasEnoughFirewood()
        {
            return woodAmountCollectedThisTick >= woodAmountToReach;
        }

        public bool CarryWoodHome()
        {
            //TODO check also time 
            Console.WriteLine("CarryWoodHome " + HasEnoughFirewood());
            return HasEnoughFirewood();
        }

        public bool Explore()
        {
            AgentStates.AddOrUpdateState(FirewoodState.HasEnoughFirewood, HasEnoughFirewood());
            AgentStates.AddOrUpdateState(FirewoodState.IsNearDeadwoodTree, false);
            AgentStates.AddOrUpdateState(FirewoodState.IsNearAlivewoodTree, false);

            _currentTreeWithDeadwood = null;
            _currentTreeWithAlivewood = null;
            //TODO wenn neuer Baum genutzt, dann auch Pos dahin verlagern.
            
            
            
            //ursprüngliche Position speichern.
            var trees = _treeLayer._TreeEnvironment.Explore(Latitude, Longitude, 100);
            foreach (var tree in trees)
            {
                if (tree.DeadwoodMass > deadMassWorthExploiting)
                {
                    _currentTreeWithDeadwood = tree;
                    AgentStates.AddOrUpdateState(FirewoodState.IsNearDeadwoodTree, true);
                }

                if (tree.LivingWoodMass > aliveMassWorthExploiting)
                {
                    _currentTreeWithAlivewood = tree;
                    AgentStates.AddOrUpdateState(FirewoodState.IsNearAlivewoodTree, true);
                }

                if (_currentTreeWithDeadwood != null && _currentTreeWithAlivewood != null)
                {
                    return true;
                }
            }

            return _currentTreeWithDeadwood != null || _currentTreeWithAlivewood != null;
        }

        public bool IsAtExploitableTree()
        {
            if (_currentTreeWithDeadwood == null) return false;
            return _currentTreeWithDeadwood.DeadwoodMass >
                   deadMassWorthExploiting; //|| _currentTreeWithDeadwood.AliveMass > aliveMassWorthExploiting;
        }

        public double MeasureDistanceAndStockForDeadwood()
        {
            if (_currentTreeWithDeadwood == null) return 0;
            Console.WriteLine(PerCent(_currentTreeWithDeadwood.DeadwoodMass,
                woodAmountToReach - woodAmountCollectedThisTick));
            return PerCent(_currentTreeWithDeadwood.DeadwoodMass, woodAmountToReach - woodAmountCollectedThisTick);
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

        public bool CutShoots()
        {
            throw new NotImplementedException();
        }
    }
}