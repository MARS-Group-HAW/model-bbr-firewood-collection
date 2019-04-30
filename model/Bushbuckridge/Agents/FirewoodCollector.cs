using System;
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
        private const double desiredWoodAmountForEachTick = 10;

        private double woodAmountCollectedThisTick;
        public double woodAmountCollectedThisYear { get; private set; }
        public double countOfAbortAndGoHome { get; private set; }
        public double countCutShoots { get; private set; }
        public double countCutBranches { get; private set; }

        [PublishForMappingInMars]
        public FirewoodCollector(ILayer layer, RegisterAgent register, UnregisterAgent unregister,
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
        }

        protected override IInteraction Reason()
        {
            UpdateObserveProperties();

            return IsActiveThisWeek()
                ? new ReplaningGoapInteraction(_goapPlanner, AgentStates)
                : NoActionInteraction.Get;
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
//                Console.WriteLine(woodAmountCollectedThisTick + " -> ");
            woodAmountCollectedThisTick = 0;
        }

        private bool IsActiveThisWeek()
        {
            return _treeLayer.GetCurrentTick() % 3 == 0;
        }

        private bool NextYearHasStarted()
        {
            return _treeLayer.GetCurrentTick() % 366 == 0;
        }

        public bool CollectDeadWood()
        {
            if (_currentTreeWithDeadwood != null)
            {
                woodAmountCollectedThisTick +=
                    _currentTreeWithDeadwood.TakeDeadWoodMass(
                        desiredWoodAmountForEachTick - woodAmountCollectedThisTick);

//                Move(_currentTreeWithDeadwood);
            }

            return true;
        }

        public bool CutBranch()
        {
            if (_currentTreeWithAlivewood != null)
            {
                woodAmountCollectedThisTick +=
                    _currentTreeWithAlivewood.TakeLivingWoodMass(
                        desiredWoodAmountForEachTick - woodAmountCollectedThisTick);

//                Move(_currentTreeWithAlivewood);
                countCutBranches++;
            }

            return true;
        }

        public bool CutShoots()
        {
            if (_currentTreeWithAlivewood != null)
            {
                woodAmountCollectedThisTick +=
                    _currentTreeWithAlivewood.TakeLivingWoodMass(_currentTreeWithAlivewood.LivingWoodMass);

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

            _currentTreeWithAlivewood = FindTree(tree => tree.StemDiameter > treeDiameterWorthExploiting);
            AgentStates.AddOrUpdateState(FirewoodState.IsNearAlivewoodTree, _currentTreeWithAlivewood != null);

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