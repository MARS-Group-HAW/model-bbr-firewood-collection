namespace KruegerNationalPark {
	using System;
	using System.Linq;
	using System.Collections.Generic;
	#pragma warning disable 162
	#pragma warning disable 219
	[System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "InconsistentNaming")]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "UnusedParameter.Local")]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "RedundantNameQualifier")]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "PossibleInvalidOperationException")]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "RedundantCheckBeforeAssignment")]
	public class KNPGISVectorWaterLayer : Mars.Components.Layers.GISVectorModelLayer
	{
		private static readonly Mars.Common.Logging.ILogger _Logger = 
					Mars.Common.Logging.LoggerFactory.GetLogger(typeof(KNPGISVectorWaterLayer));
		private static readonly Mars.Components.Common.Random _Random = new Mars.Components.Common.Random();
		public KruegerNationalPark.KNPGISVectorWaterLayer vectorWater => this;
	}
}
