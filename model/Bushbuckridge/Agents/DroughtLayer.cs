using System;
using System.Diagnostics;
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
        private Stopwatch stopwatch;

        private long CurrentTick { get; set; }

        public DroughtLayer(SavannaLayer savannaLayer, Precipitation precipitation)
        {
            _savannaLayer = savannaLayer;
            _precipitation = precipitation;
             stopwatch = Stopwatch.StartNew();
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
            return precipitationWithinYear < 435;
        }

        public void Tick()
        {
            if (SimulationClock.CurrentTimePoint.Value.Month == 9 && SimulationClock.CurrentTimePoint.Value.Day == 1 &&
                daysSinceLastDroughtTest >= 365)
            {
                Console.WriteLine( SimulationClock.CurrentTimePoint.Value.Year +"("+ precipitationWithinYear + "ml): " + stopwatch.Elapsed.Minutes.ToString("D2") +" minutes " + stopwatch.Elapsed.Seconds.ToString("D2") +" secs " + stopwatch.Elapsed.Milliseconds.ToString("D3") +" millisec");
                stopwatch.Restart();
//                Console.WriteLine( SimulationClock.CurrentTimePoint.Value.Year + " " + (int)precipitationWithinYear);
                if (IsDroughtSituationReached())
                {
                    Console.WriteLine("DROUGHT!!");
                    // fire drought event
                    foreach (var tree in _savannaLayer._TreeAgents.Values)
                    {
                        tree.SufferDrought();
                    }
//                    Parallel.ForEach(_savannaLayer._TreeAgents.Values, tree => tree.SufferDrought());
                }

                precipitationWithinYear = 0;
                daysSinceLastDroughtTest = 0;
            }

//            Console.WriteLine( SimulationClock.CurrentTimePoint.Value.Day + "." +SimulationClock.CurrentTimePoint.Value.Month + " -> " +  _precipitation.GetNumberValue(Territory.TOP_LAT, Territory.LEFT_LONG));
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