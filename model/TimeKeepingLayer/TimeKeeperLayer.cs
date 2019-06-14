using System;
using System.Diagnostics;
using Mars.Core.SimulationManager.Entities;
using Mars.Interfaces.Layer;
using Mars.Interfaces.Layer.Initialization;
using SavannaTrees;

namespace TimeKeepingLayer
{
    public class TimeKeeperLayer : ISteppedActiveLayer
    {
        private readonly SavannaLayer _savannaLayer;
        private readonly Stopwatch _stopWatch;
        private long _currentTick;

        public TimeKeeperLayer(SavannaLayer savannaLayer)
        {
            _savannaLayer = savannaLayer;
            _stopWatch = new Stopwatch();
            _stopWatch.Restart();
        }

        public bool InitLayer(TInitData layerInitData, RegisterAgent registerAgentHandle,
            UnregisterAgent unregisterAgentHandle)
        {
            //do nothing
            return true;
        }

        public long GetCurrentTick()
        {
            return _currentTick;
        }

        public void SetCurrentTick(long currentStep)
        {
            _currentTick = currentStep;
        }

        public void Tick()
        {
            if (SimulationClock.CurrentTimePoint.Value.DayOfWeek == DayOfWeek.Monday)
            {
                Console.Write(".");
            }

            if (SimulationClock.CurrentTimePoint.Value.Day == 1)
            {
                Console.Write(" ");
            }

            if (!IsNextYearTick()) return;
            Console.WriteLine();
            Console.WriteLine(SimulationClock.CurrentTimePoint.Value.Year + " in " + _stopWatch.Elapsed.Days + "d " +
                              _stopWatch.Elapsed.Hours + "h " + _stopWatch.Elapsed.Minutes + "m " +
                              _stopWatch.Elapsed.Seconds + "s " +
                              " and tree count: " + _savannaLayer._TreeAgents.Count);
            _stopWatch.Restart();
        }

        private static bool IsNextYearTick()
        {
            return SimulationClock.CurrentTimePoint.Value.Day == SimulationClock.StartTimePoint.Value.Day &&
                   SimulationClock.CurrentTimePoint.Value.Month == SimulationClock.StartTimePoint.Value.Month &&
                   SimulationClock.CurrentTimePoint.Value.Year > SimulationClock.StartTimePoint.Value.Year;
        }

        public void PreTick()
        {
            //do nothing
        }

        public void PostTick()
        {
            //do nothing
        }
    }
}