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
	public class KNPGISRasterFenceLayer : Mars.Components.Layers.GISRasterModelLayer
	{
		private static readonly Mars.Common.Logging.ILogger _Logger = 
					Mars.Common.Logging.LoggerFactory.GetLogger(typeof(KNPGISRasterFenceLayer));
		private static readonly Mars.Components.Common.Random _Random = new Mars.Components.Common.Random();
		public KruegerNationalPark.KNPGISRasterFenceLayer rasterFence => this;
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public bool IsPointInside(System.Tuple<double,double> coordinate) 
		{
			{
					return Mars.Components.Common.Math.Abs(rasterFence.GetNumberValue(coordinate.Item1,
					coordinate.Item2
					)
					 - 1)
					 < 0.0001
					;
					}
			return default(bool);
		}
	}
}
