using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Bushbuckridge.Agents.Tree;
using KruegerNationalPark;
using Mars.Components.Agents;
using Mars.Components.Environments;
using Mars.Components.Services;
using Mars.Interfaces.Layer;
using Mars.Interfaces.Layer.Initialization;

namespace Bushbuckridge.Agents.Collector
{
    public class FirewoodCollectorLayer : ISteppedActiveLayer
    {
        private readonly SavannaLayer _savannaLayer;
        private readonly GeoGridEnvironment<GeoAgent<FirewoodCollector>> _environment;

        private ConcurrentDictionary<Guid, FirewoodCollector> _agents;
        private long CurrentTick { get; set; }

        public FirewoodCollectorLayer(SavannaLayer savannaLayer)
        {
            _savannaLayer = savannaLayer;
            _environment =
                new GeoGridEnvironment<GeoAgent<FirewoodCollector>>(-24.8239, -24.8690, 31.1944, 31.2436, 1000);
        }

        public bool InitLayer(TInitData layerInitData, RegisterAgent registerAgentHandle,
            UnregisterAgent unregisterAgentHandle)
        {
            var agentInitConfig = layerInitData.AgentInitConfigs.FirstOrDefault();
            _agents = AgentManager.GetAgentsByAgentInitConfig<FirewoodCollector>(agentInitConfig, registerAgentHandle,
                unregisterAgentHandle,
                new List<ILayer>
                {
                    _savannaLayer,
                    this
                }, _environment);

            Console.WriteLine("[FirewoodCollectorLayer]: Created Agents: " + _agents.Count);
            return true;
        }

        public long GetCurrentTick()
        {
            return CurrentTick;
        }

        public void SetCurrentTick(long currentStep)
        {
            CurrentTick = currentStep;
            Console.WriteLine("-------------- " + currentStep + " --------------");
        }

        public void Tick()
        {
        }

        public void PreTick()
        {
        }

        public void PostTick()
        {
        }
    }
}