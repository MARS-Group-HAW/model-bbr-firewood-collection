using System;
using System.Collections.Generic;
using System.IO;
using Bushbuckridge.Agents.Collector;
using Bushbuckridge.Agents.Tree;
using Mars.Core.ModelContainer.Entities;
using Mars.Core.SimulationStarter;

namespace Bushbuckridge
{
    public static class Starter
    {
        public static void Main(string[] args)
        {
            var description = new ModelDescription();
            description.AddLayer<ExploitableTreeLayer>(new[] {typeof(ExploitableTreeLayer)});
            description.AddAgent<ExploitableTree, ExploitableTreeLayer>();
            
            description.AddLayer<FirewoodCollectorLayer>(new[] {typeof(FirewoodCollectorLayer)});
            description.AddAgent<FirewoodCollector, FirewoodCollectorLayer>();

            var loopResult = SimulationStarter.Start(description, SimulationConfig()).Run();
            
            Console.WriteLine("Happe End! :) after Tick " + loopResult.CurrentTick);
            // Bäume und Sammler leben auf ihren layern
            // werden gleichmäßig in ihren Bereichen platziert
            // sammler finden bäume, können nach spezifischen Kriterien bäume suche
            // sammler fällen bäume
            // wieviel pro tick/tag sammeln?
            // wochenweise, simulationsweise
        }

        private static SimulationConfig SimulationConfig()
        {
            return new SimulationConfig
            {
                Globals =
                {
                    StartPoint = new DateTime(2017, 12, 31, 23, 0, 0),
                    EndPoint = new DateTime(2018, 01, 31),
                    DeltaTUnit = TimeSpanUnit.Days,
                    DeltaT = 1,
                },

                AgentMappings = new List<AgentMapping>
                {
                    new AgentMapping
                    {
                        Name = "FirewoodCollector",
                        File = Path.Combine("..", "..", "model_input", "household.csv"),
                        InstanceCount = 1, //684
                        Options = {{"csvSeparator", ";"}}
                    },
                    new AgentMapping
                    {
                        Name = "ExploitableTree",
                        File = Path.Combine("..", "..", "model_input", "tree.csv"),
                        InstanceCount = 100,
                        Options = {{"csvSeparator", ";"}}
                    }
                }
            };
        }
    }
}