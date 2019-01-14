public static class Program {
	public static void Main(string[] args) {
		if (args != null && System.Linq.Enumerable.Any(args, s => s.Equals("-l")))
		{
			Mars.Common.Logging.LoggerFactory.SetLogLevel(Mars.Common.Logging.Enums.LogLevel.Info);
			Mars.Common.Logging.LoggerFactory.ActivateConsoleLogging();
		}
		var description = new Mars.Core.ModelContainer.Entities.ModelDescription();
		description.AddLayer<KruegerNationalPark.ElephantLayer>();
		description.AddLayer<KruegerNationalPark.SavannaLayer>();
		description.AddLayer<KruegerNationalPark.KNPGISRasterFenceLayer>();
		description.AddLayer<KruegerNationalPark.KNPGISRasterPrecipitationLayer>();
		description.AddLayer<KruegerNationalPark.KNPGISRasterShadeLayer>();
		description.AddLayer<KruegerNationalPark.KNPGISRasterTempLayer>();
		description.AddLayer<KruegerNationalPark.KNPGISRasterVegetationLayer>();
		description.AddLayer<KruegerNationalPark.KNPGISVectorWaterLayer>();
		description.AddAgent<KruegerNationalPark.Elephant, KruegerNationalPark.ElephantLayer>();
		description.AddAgent<KruegerNationalPark.Tree, KruegerNationalPark.SavannaLayer>();
		var task = Mars.Core.SimulationStarter.SimulationStarter.Start(description, args);
		var loopResults = task.Run();
		System.Console.WriteLine($"Simulation execution finished after {loopResults.Iterations} steps");
	}
}
