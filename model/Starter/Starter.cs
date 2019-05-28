using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using Bushbuckridge.Agents.Collector;
using Mars.Common.Logging;
using Mars.Common.Logging.Enums;
using Mars.Core.ModelContainer.Entities;
using Mars.Core.SimulationStarter;
using SavannaTrees;

public static class Program
{
    public static void Main(string[] args)
    {
        if (args != null && Enumerable.Any(args, s => s.Equals("-l")))
        {
            LoggerFactory.SetLogLevel(LogLevel.Info);
            LoggerFactory.ActivateConsoleLogging();
        }
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
        
        var description = new ModelDescription();
        description.AddLayer<Precipitation>();
        description.AddLayer<Temperature>();

        description.AddLayer<SavannaLayer>();
        description.AddLayer<DroughtLayer>();
        description.AddLayer<HerbivorePressureLayer>();
        description.AddLayer<FirewoodCollectorLayer>();

        description.AddAgent<Rafiki, SavannaLayer>();
        description.AddAgent<Tree, SavannaLayer>();
        description.AddAgent<FirewoodCollector, FirewoodCollectorLayer>();
        var stopwatch = Stopwatch.StartNew();

        var task = SimulationStarter.Start(description, args);
        var loopResults = task.Run();
        Console.WriteLine($"Simulation execution finished after {loopResults.Iterations} steps in seconds: " +
                          stopwatch.Elapsed.Seconds);
           
    }
}