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
	public class KNPGISRasterShadeLayer : Mars.Components.Layers.GISRasterModelLayer
	{
		private static readonly Mars.Common.Logging.ILogger _Logger = 
					Mars.Common.Logging.LoggerFactory.GetLogger(typeof(KNPGISRasterShadeLayer));
		private static readonly Mars.Components.Common.Random _Random = new Mars.Components.Common.Random();
		public KruegerNationalPark.KNPGISRasterShadeLayer rasterShade => this;
		private int __FullPotential
			 = 100;
		internal int FullPotential { 
			get { return __FullPotential; }
			set{
				if(__FullPotential != value) __FullPotential = value;
			}
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public bool HasFulltPotential(System.Tuple<double,double> coordinate) 
		{
			{
					return Mars.Components.Common.Math.Abs(FullPotential - rasterShade.GetIntegerValue(coordinate.Item1,
					coordinate.Item2
					)
					)
					 < 0.00001
					;
					}
			return default(bool);
		}
	}
}
