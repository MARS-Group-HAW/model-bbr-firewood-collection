using System;
using System.Threading.Tasks;
using Bushbuckridge.Config;
using KruegerNationalPark;
using Mars.Core.SimulationManager.Entities;
using Mars.Interfaces.Layer;
using Mars.Interfaces.Layer.Initialization;

namespace Bushbuckridge.Agents.Collector
{
    /// <summary>
    /// If between September and August of the next year, the precipitation is lower than 200 millimeters, then a drought event is generated. 
    /// </summary>
    public class DroughtLayer : ISteppedActiveLayer
    {
        private readonly SavannaLayer _savannaLayer;
        private readonly Precipitation _precipitation;
        private double precipitationWithinYear;
        private double daysSinceLastDroughtTest;

        private long CurrentTick { get; set; }

        public DroughtLayer(SavannaLayer savannaLayer, Precipitation precipitation)
        {
            _savannaLayer = savannaLayer;
            _precipitation = precipitation;
        }

        public bool InitLayer(TInitData layerInitData, RegisterAgent registerAgentHandle,
            UnregisterAgent unregisterAgentHandle)
        {
            return true;
        }

        public long GetCurrentTick()
        {
            return CurrentTick;
        }

        public void SetCurrentTick(long currentStep)
        {
            CurrentTick = currentStep;
        }

        private bool IsDroughtSituationReached()
        {
            return precipitationWithinYear < 200;
        }

        public void Tick()
        {
            if (SimulationClock.CurrentTimePoint.Value.Month == 9 && SimulationClock.CurrentTimePoint.Value.Day == 1 &&
                daysSinceLastDroughtTest >= 365)
            {
                if (IsDroughtSituationReached())
                {
                    // fire drought event
                    Parallel.ForEach(_savannaLayer._TreeAgents.Values, tree => tree.SufferDrought());
                }

                precipitationWithinYear = 0;
                daysSinceLastDroughtTest = 0;
            }

            precipitationWithinYear += _precipitation.GetNumberValue(Territory.TOP_LAT, Territory.LEFT_LONG);
            daysSinceLastDroughtTest++;
        }

        public void PreTick()
        {
        }

        public void PostTick()
        {
        }
    }
}