using System;
using System.Diagnostics;
using Bushbuckridge.Actions;
using Bushbuckridge.Goals;
using Bushbuckridge.States;
using Mars.Components.Agents;
using Mars.Components.Environments;
using Mars.Components.Services.Planning.Implementation;
using Mars.Components.Services.Planning.Interfaces;
using Mars.Interfaces.Agent;
using Mars.Interfaces.Environment.GeoCommon;
using Mars.Interfaces.Layer;
using Mars.Interfaces.LIFECapabilities;
using SavannaTrees;

namespace Bushbuckridge.Agents.Collector
{
//TODO females sollen min 50 % Totholz sammeln
    // ReSharper disable once ClassNeverInstantiated.Global
    public class FirewoodCollector : GeoAgent<FirewoodCollector>
    {
        public override FirewoodCollector AgentReference => this;
        public IGoapAgentStates AgentStates { get; set; }
        private readonly GoapPlanner _goapPlanner;

        private readonly FirewoodCollectorLayer _layer;
        private readonly SavannaLayer _treeLayer;

        private Tree _currentTreeWithDeadwood;
        private Tree _currentTreeWithAlivewood;

        private const double deadMassWorthExploiting = 1;
        private const double livingMassWorthExploiting = 4;
        private const double treeDiameterWorthExploiting = 3;
        private const double desiredWoodAmountForEachTick = 25;

        private const double woodConsumptionPerDay = 10;
        private double woodAmountInStock;

        private double woodAmountCollectedThisTick;
        public double woodAmountCollectedThisYear { get; private set; }
        public double countOfAbortAndGoHome { get; private set; }
        public double countCutShoots { get; private set; }
        public double countCutBranches { get; private set; }

        [PublishForMappingInMars]
        public FirewoodCollector(FirewoodCollectorLayer layer, RegisterAgent register, UnregisterAgent unregister,
            GeoGridEnvironment<GeoAgent<FirewoodCollector>> env, SavannaLayer treeLayer, Guid id,
            double lat, double lon) :
            base(layer, register, unregister, env, new GeoCoordinate(lat, lon), id.ToByteArray())
        {
            _treeLayer = treeLayer;

            AgentStates = new GoapAgentStates();
            AgentStates.AddOrUpdateState(FirewoodState.HasAxe, true);
            AgentStates.AddOrUpdateState(FirewoodState.HasEnoughFirewood, false);
            AgentStates.AddOrUpdateState(FirewoodState.TimeIsUp, false);

            _goapPlanner = new GoapPlanner(AgentStates);
            var exploreGoal = new ExploreGoal(this);
            var searchAndGatherWoodGoal = new RaiseWoodStockGoal(this);
            var evaluateSituationGoal = new EvaluateSituationGoal(this);
            var goHomeGoal = new ReturnHomeGoal(this);

            _goapPlanner.AddGoal(exploreGoal);
            _goapPlanner.AddGoal(searchAndGatherWoodGoal);
            _goapPlanner.AddGoal(evaluateSituationGoal);
            _goapPlanner.AddGoal(goHomeGoal);

            exploreGoal.AddAction(new Explore(this));

            searchAndGatherWoodGoal.AddAction(new CutShoots(this));
            searchAndGatherWoodGoal.AddAction(new CutBranchesSb(this));
            //searchAndGatherWoodGoal.AddAction(new CutBranchesCaAn(this));
            searchAndGatherWoodGoal.AddAction(new CollectDeadWood(this));

            evaluateSituationGoal.AddAction(new EvaluateAndPackWoodForTransport(this));

            goHomeGoal.AddAction(new CarryWoodHome(this));
            goHomeGoal.AddAction(new AbortAndGoHome(this));

            woodAmountInStock = layer.Random.Next(10, 30);
        }

        protected override IInteraction Reason()
        {
            UpdateObserveProperties();
            ConsumeWood();
            return RequiresWoodStockRefill()
                ? new ReplaningGoapInteraction(_goapPlanner, AgentStates)
                : NoActionInteraction.Get;
        }

        private void ConsumeWood()
        {
            woodAmountInStock -= woodConsumptionPerDay;
        }

        private bool RequiresWoodStockRefill()
        {
            return woodAmountInStock <= woodConsumptionPerDay * 2;
        }

        private void UpdateObserveProperties()
        {
            if (NextYearHasStarted())
            {
                ResetObserveProperties();
            }

            UpdateObservePropertiesForThisTick();
        }

        private void ResetObserveProperties()
        {
            woodAmountCollectedThisYear = 0;
            countOfAbortAndGoHome = 0;
            countCutShoots = 0;
            countCutBranches = 0;
        }

        private void UpdateObservePropertiesForThisTick()
        {
            woodAmountCollectedThisYear += woodAmountCollectedThisTick;
            woodAmountCollectedThisTick = 0;
        }


        private bool NextYearHasStarted()
        {
            return _treeLayer.GetCurrentTick() % 366 == 0;
        }

        public bool CollectDeadWood()
        {
            if (_currentTreeWithDeadwood != null)
            {
                AddWoodToStock(_currentTreeWithDeadwood.TakeDeadWoodMass(
                    desiredWoodAmountForEachTick - woodAmountCollectedThisTick));
//                Move(_currentTreeWithDeadwood);
            }

            return true;
        }

        private void AddWoodToStock(double woodMass)
        {
//            Console.WriteLine("AddWoodToStock("+woodMass+") by "+ new StackTrace().GetFrame(1).GetMethod().Name);
            woodAmountInStock += woodMass;
            woodAmountCollectedThisTick += woodMass;
        }

        public bool CutBranch()
        {
            if (_currentTreeWithAlivewood != null)
            {
                AddWoodToStock(
                    _currentTreeWithAlivewood.TakeLivingWoodMass( Math.Abs(
                        desiredWoodAmountForEachTick - woodAmountCollectedThisTick)));

//                Move(_currentTreeWithAlivewood);
                countCutBranches++;
            }

            return true;
        }

        public bool CutShoots()
        {
            if (_currentTreeWithAlivewood != null)
            {
                AddWoodToStock(_currentTreeWithAlivewood.TakeLivingWoodMass(_currentTreeWithAlivewood.LivingWoodMass));
//                Move(_currentTreeWithAlivewood);
                countCutShoots++;
            }

            return true;
        }

        private MovementAction Move(Tree tree)
        {
            return Mover.SetToPosition(tree.Latitude, tree.Longitude, 0);
        }

        public bool HasEnoughFirewood()
        {
            return woodAmountCollectedThisTick >= desiredWoodAmountForEachTick;
        }

        public bool CarryWoodHome()
        {
//            AgentStates.AddOrUpdateState(FirewoodState.HasEnoughFirewood, HasEnoughFirewood());
            //TODO check also time 
//            Console.WriteLine("CarryWoodHome wood: " + woodAmountCollectedThisTick + "kg");
            return true;
        }

        public bool AbortAndGoHome()
        {
            countOfAbortAndGoHome++;
            return CarryWoodHome();
        }

        public bool Explore()
        {
            AgentStates.AddOrUpdateState(FirewoodState.HasEnoughFirewood, HasEnoughFirewood());

            _currentTreeWithDeadwood = null;
            _currentTreeWithAlivewood = null;
            //TODO wenn neuer Baum genutzt, dann auch Pos dahin verlagern.  
            //TODO ursprüngliche Position speichern.

//            _currentTreeWithDeadwood = FindTree(tree => tree.DeadWoodMass > deadMassWorthExploiting);
            AgentStates.AddOrUpdateState(FirewoodState.IsNearDeadwoodTree, _currentTreeWithDeadwood != null);

            _currentTreeWithAlivewood = FindTree(tree => tree.StemDiameter > treeDiameterWorthExploiting);// && !tree.IsSpecies("sb"));
            var nearAlivewoodTree = _currentTreeWithAlivewood != null;
            AgentStates.AddOrUpdateState(FirewoodState.IsNearAlivewoodTree, nearAlivewoodTree);
            if (nearAlivewoodTree)
            {
                AgentStates.AddOrUpdateState(FirewoodState.IsNearShoot, _currentTreeWithAlivewood.IsTreeAgeGroup(TreeAgeGroup.Juvenile));
            }

            return true;
        }

        private Tree FindTree(Func<Tree, bool> func)
        {
            return _treeLayer._TreeEnvironment.GetNearest(Latitude, Longitude, -1, func);
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