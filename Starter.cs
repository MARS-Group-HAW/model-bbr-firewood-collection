using System;
using System.IO;
using Accord.Math;
using Mars.Core.ModelContainer.Entities;

public static class Program {
    public static void Main(string[] args) {
        if (args != null && System.Linq.Enumerable.Any(args, s => s.Equals("-l")))
        {
            Mars.Common.Logging.LoggerFactory.SetLogLevel(Mars.Common.Logging.Enums.LogLevel.Info);
            Mars.Common.Logging.LoggerFactory.ActivateConsoleLogging();
        }
        var description = new Mars.Core.ModelContainer.Entities.ModelDescription();
        description.AddLayer<KruegerNationalPark.SavannaLayer>();
        description.AddLayer<KruegerNationalPark.Precipitation>();
        description.AddLayer<KruegerNationalPark.Temperature>();
        description.AddAgent<KruegerNationalPark.Tree, KruegerNationalPark.SavannaLayer>();
        var path = Path.Combine("..","src", "config.json");
//            var path = args[0];
        var config = SimulationConfig.Deserialize(path);
        var task = Mars.Core.SimulationStarter.SimulationStarter.Start(description, config);
        var loopResults = task.Run();
        System.Console.WriteLine($"Simulation execution finished after {loopResults.Iterations} steps");
    }
}
