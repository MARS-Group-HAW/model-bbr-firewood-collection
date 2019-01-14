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
	public class Tree : Mars.Interfaces.Environment.GeoCommon.GeoPosition, Mars.Interfaces.Agent.IMarsDslAgent {
		private static readonly Mars.Common.Logging.ILogger _Logger = 
					Mars.Common.Logging.LoggerFactory.GetLogger(typeof(Tree));
		private static readonly Mars.Components.Common.Random _Random = new Mars.Components.Common.Random();
		private bool __HasLeaves
			 = default(bool);
		public bool HasLeaves { 
			get { return __HasLeaves; }
			set{
				if(__HasLeaves != value) __HasLeaves = value;
			}
		}
		private double __StemDiameter
			 = default(double);
		internal double StemDiameter { 
			get { return __StemDiameter; }
			set{
				if(System.Math.Abs(__StemDiameter - value) > 0.0000001) __StemDiameter = value;
			}
		}
		private double __Height
			 = default(double);
		public double Height { 
			get { return __Height; }
			set{
				if(System.Math.Abs(__Height - value) > 0.0000001) __Height = value;
			}
		}
		private double __LivingWoodMass
			 = default(double);
		public double LivingWoodMass { 
			get { return __LivingWoodMass; }
			set{
				if(System.Math.Abs(__LivingWoodMass - value) > 0.0000001) __LivingWoodMass = value;
			}
		}
		private double __WoodMass
			 = default(double);
		public double WoodMass { 
			get { return __WoodMass; }
			set{
				if(System.Math.Abs(__WoodMass - value) > 0.0000001) __WoodMass = value;
			}
		}
		private double __DeadwoodMass
			 = default(double);
		public double DeadwoodMass { 
			get { return __DeadwoodMass; }
			set{
				if(System.Math.Abs(__DeadwoodMass - value) > 0.0000001) __DeadwoodMass = value;
			}
		}
		private double __Growthrate
			 = default(double);
		internal double Growthrate { 
			get { return __Growthrate; }
			set{
				if(System.Math.Abs(__Growthrate - value) > 0.0000001) __Growthrate = value;
			}
		}
		private bool __IsMultiStem
			 = default(bool);
		internal bool IsMultiStem { 
			get { return __IsMultiStem; }
			set{
				if(__IsMultiStem != value) __IsMultiStem = value;
			}
		}
		private double __WaterHousehold
			 = default(double);
		internal double WaterHousehold { 
			get { return __WaterHousehold; }
			set{
				if(System.Math.Abs(__WaterHousehold - value) > 0.0000001) __WaterHousehold = value;
			}
		}
		private double __ResproutCapacity
			 = default(double);
		internal double ResproutCapacity { 
			get { return __ResproutCapacity; }
			set{
				if(System.Math.Abs(__ResproutCapacity - value) > 0.0000001) __ResproutCapacity = value;
			}
		}
		private KruegerNationalPark.TreeStateType __TreeState
			 = default(KruegerNationalPark.TreeStateType);
		internal KruegerNationalPark.TreeStateType TreeState { 
			get { return __TreeState; }
			set{
				if(__TreeState != value) __TreeState = value;
			}
		}
		private bool __IsPhotosentheseActive
			 = false;
		internal bool IsPhotosentheseActive { 
			get { return __IsPhotosentheseActive; }
			set{
				if(__IsPhotosentheseActive != value) __IsPhotosentheseActive = value;
			}
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public System.Tuple<double,double> Position() 
		{
			{
					return new System.Tuple<double,double>(base.Position[0],base.Position[1])
					;
					}
			return default(System.Tuple<double,double>);
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void GreenUp() 
		{
			{
					IsPhotosentheseActive = true
					;
					}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void LeaveDrop() 
		{
			{
					IsPhotosentheseActive = false
					;
					}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public double TakeDeadWoodMass(
		double mass) {
			{
				double result = null;	if(mass < DeadwoodMass) {
								{
									result = mass;
								}
						;} else {
								{
									result = DeadwoodMass;
								}
							;};	DeadwoodMass = DeadwoodMass - result;	return result;
			}
			
			return default(double);
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public double TakeLivingWoodMass(
		double mass) {
			{
				double result = null;	if(mass < LivingWoodMass) {
								result = mass
						;} else {
								result = LivingWoodMass
							;};	LivingWoodMass = LivingWoodMass - result;	return result;
			}
			
			return default(double);
		}
		
		public KruegerNationalPark.SavannaLayer _SavannaLayer { get; set; }
		public KruegerNationalPark.KNPGISRasterFenceLayer _KNPGISRasterFenceLayer { get; set; }
		public KruegerNationalPark.KNPGISRasterFenceLayer rasterFence => _KNPGISRasterFenceLayer;
		public KruegerNationalPark.KNPGISRasterPrecipitationLayer _KNPGISRasterPrecipitationLayer { get; set; }
		public KruegerNationalPark.KNPGISRasterPrecipitationLayer rasterPrecipitation => _KNPGISRasterPrecipitationLayer;
		public KruegerNationalPark.KNPGISRasterShadeLayer _KNPGISRasterShadeLayer { get; set; }
		public KruegerNationalPark.KNPGISRasterShadeLayer rasterShade => _KNPGISRasterShadeLayer;
		public KruegerNationalPark.KNPGISRasterTempLayer _KNPGISRasterTempLayer { get; set; }
		public KruegerNationalPark.KNPGISRasterTempLayer rasterTemperature => _KNPGISRasterTempLayer;
		public KruegerNationalPark.KNPGISRasterVegetationLayer _KNPGISRasterVegetationLayer { get; set; }
		public KruegerNationalPark.KNPGISRasterVegetationLayer rasterVegetation => _KNPGISRasterVegetationLayer;
		public KruegerNationalPark.KNPGISVectorWaterLayer _KNPGISVectorWaterLayer { get; set; }
		public KruegerNationalPark.KNPGISVectorWaterLayer vectorWater => _KNPGISVectorWaterLayer;
		
		[Mars.Interfaces.LIFECapabilities.PublishForMappingInMars]
		public Tree (
		System.Guid _id,
		KruegerNationalPark.SavannaLayer _layer,
		Mars.Interfaces.Layer.RegisterAgent _register,
		Mars.Interfaces.Layer.UnregisterAgent _unregister,
		Mars.Components.Environments.GeoGridHashEnvironment<Tree> _TreeEnvironment,
		KruegerNationalPark.KNPGISRasterFenceLayer _KNPGISRasterFenceLayer,
		KruegerNationalPark.KNPGISRasterPrecipitationLayer _KNPGISRasterPrecipitationLayer,
		KruegerNationalPark.KNPGISRasterShadeLayer _KNPGISRasterShadeLayer,
		KruegerNationalPark.KNPGISRasterTempLayer _KNPGISRasterTempLayer,
		KruegerNationalPark.KNPGISRasterVegetationLayer _KNPGISRasterVegetationLayer,
		KruegerNationalPark.KNPGISVectorWaterLayer _KNPGISVectorWaterLayer
	,	double StemDiameter,
		double Height,
		double LivingWoodMass,
		double WoodMass,
		double DeadwoodMass,
		double Growthrate
	,	double xcor = 0, double ycor = 0, int freq = 1)
		 : base (xcor, ycor)
		{
			_SavannaLayer = _layer;
			ID = _id;
			this.StemDiameter = StemDiameter;
			this.Height = Height;
			this.LivingWoodMass = LivingWoodMass;
			this.WoodMass = WoodMass;
			this.DeadwoodMass = DeadwoodMass;
			this.Growthrate = Growthrate;
			this._KNPGISRasterFenceLayer = _KNPGISRasterFenceLayer;
			this._KNPGISRasterPrecipitationLayer = _KNPGISRasterPrecipitationLayer;
			this._KNPGISRasterShadeLayer = _KNPGISRasterShadeLayer;
			this._KNPGISRasterTempLayer = _KNPGISRasterTempLayer;
			this._KNPGISRasterVegetationLayer = _KNPGISRasterVegetationLayer;
			this._KNPGISVectorWaterLayer = _KNPGISVectorWaterLayer;
			_SavannaLayer._TreeEnvironment.Insert(this);
			_register(_layer, this, freq);
		}
		
		public void Tick()
		{
			{
				if(Object.Equals(Mars.Components.Common.Time.Month((int) Mars.Core.SimulationManager.Entities.SimulationClock.CurrentStep)
				, 10) && Object.Equals(Mars.Components.Common.Time.Day((int) Mars.Core.SimulationManager.Entities.SimulationClock.CurrentStep)
				, 15)) {
								HasLeaves = true
						;} ;	if(Object.Equals(Mars.Components.Common.Time.Month((int) Mars.Core.SimulationManager.Entities.SimulationClock.CurrentStep)
				, 6) && Object.Equals(Mars.Components.Common.Time.Day((int) Mars.Core.SimulationManager.Entities.SimulationClock.CurrentStep)
				, 15)) {
								HasLeaves = false
						;} ;	double rate = 0.0;	Console.WriteLine(Mars.Components.Common.Time.Month((int) Mars.Core.SimulationManager.Entities.SimulationClock.CurrentStep)
				);;	Console.WriteLine(Mars.Components.Common.Time.Day((int) Mars.Core.SimulationManager.Entities.SimulationClock.CurrentStep)
				);;	Console.WriteLine((int) Mars.Core.SimulationManager.Entities.SimulationClock.CurrentStep);;	if(Object.Equals(HasLeaves, true)) {
								{
									rate = Growthrate;
								}
						;} else {
								{
									rate = 0;
								}
							;};	if(Height >= KruegerNationalPark.MyConstants.MaxHeight()
				) {
								Height = KruegerNationalPark.MyConstants.MaxHeight()
						;} else {
								{
									Height = Height + rate * Height;	StemDiameter = (Height - 88.326) / 11.043;	LivingWoodMass = (Height * (3.141 * Mars.Components.Common.Math.Pow((StemDiameter / 2), 2)) * KruegerNationalPark.MyConstants.CarbonDensity()
									) / 1000;	DeadwoodMass = DeadwoodMass + LivingWoodMass * 0.01;	WoodMass = DeadwoodMass + LivingWoodMass;
								}
							;};
			}
		}
		
		public System.Guid ID { get; }
		public bool Equals(Tree other) => Equals(ID, other.ID);
		public override int GetHashCode() => ID.GetHashCode();
	}
}
