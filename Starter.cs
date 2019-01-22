using System;
using System.IO;
using Bushbuckridge.Agents.Collector;
using KruegerNationalPark;
using Mars.Core.ModelContainer.Entities;
using Mars.Core.SimulationStarter;

namespace Bushbuckridge
{
    public static class Starter
    {
        public static void Main(string[] args)
        {
            var description = new ModelDescription();
            description.AddLayer<Precipitation>();
            description.AddLayer<Temperature>();
            
            description.AddLayer<SavannaLayer>();
            description.AddAgent<Tree, SavannaLayer>();

            description.AddLayer<FirewoodCollectorLayer>();
            description.AddAgent<FirewoodCollector, FirewoodCollectorLayer>();

            var path = Path.Combine("src", "config.json");
//            var path = args[0];
            var config = SimulationConfig.Deserialize(path);

            var loopResult = SimulationStarter.Start(description, config).Run();

            Console.WriteLine("Happe End! :) after Tick " + loopResult.CurrentTick);
        }
    }
}