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
	public class Elephant : Mars.Interfaces.Environment.GeoCommon.GeoPosition, Mars.Interfaces.Agent.IMarsDslAgent {
		private static readonly Mars.Common.Logging.ILogger _Logger = 
					Mars.Common.Logging.LoggerFactory.GetLogger(typeof(Elephant));
		private static readonly Mars.Components.Common.Random _Random = new Mars.Components.Common.Random();
		private int __Age
			 = default(int);
		public int Age { 
			get { return __Age; }
			set{
				if(__Age != value) __Age = value;
			}
		}
		private string __Actions
			 = default(string);
		public string Actions { 
			get { return __Actions; }
			set{
				if(__Actions != value) __Actions = value;
			}
		}
		private double __Satiety
			 = 100;
		public double Satiety { 
			get { return __Satiety; }
			set{
				if(System.Math.Abs(__Satiety - value) > 0.0000001) __Satiety = value;
			}
		}
		private double __Hydration
			 = 100;
		public double Hydration { 
			get { return __Hydration; }
			set{
				if(System.Math.Abs(__Hydration - value) > 0.0000001) __Hydration = value;
			}
		}
		private double __BiomassConsumed
			 = default(double);
		public double BiomassConsumed { 
			get { return __BiomassConsumed; }
			set{
				if(System.Math.Abs(__BiomassConsumed - value) > 0.0000001) __BiomassConsumed = value;
			}
		}
		private double __PregnantDuration
			 = default(double);
		public double PregnantDuration { 
			get { return __PregnantDuration; }
			set{
				if(System.Math.Abs(__PregnantDuration - value) > 0.0000001) __PregnantDuration = value;
			}
		}
		private bool __IsPregnant
			 = default(bool);
		public bool IsPregnant { 
			get { return __IsPregnant; }
			set{
				if(__IsPregnant != value) __IsPregnant = value;
			}
		}
		private Mars.Components.Common.MarsList<int> __ReproductionYears
			 = (new Mars.Components.Common.MarsList<int>() { 15,40 });
		internal Mars.Components.Common.MarsList<int> ReproductionYears { 
			get { return __ReproductionYears; }
			set{
				if(__ReproductionYears != value) __ReproductionYears = value;
			}
		}
		private KruegerNationalPark.MattersOfDeathType __MatterOfDeath
			 = default(KruegerNationalPark.MattersOfDeathType);
		public KruegerNationalPark.MattersOfDeathType MatterOfDeath { 
			get { return __MatterOfDeath; }
			set{
				if(__MatterOfDeath != value) __MatterOfDeath = value;
			}
		}
		private KruegerNationalPark.ElephantLifePeriodType __ElephantLifePeriod
			 = default(KruegerNationalPark.ElephantLifePeriodType);
		public KruegerNationalPark.ElephantLifePeriodType ElephantLifePeriod { 
			get { return __ElephantLifePeriod; }
			set{
				if(__ElephantLifePeriod != value) __ElephantLifePeriod = value;
			}
		}
		private KruegerNationalPark.ElephantType __ElephantAgeType
			 = default(KruegerNationalPark.ElephantType);
		public KruegerNationalPark.ElephantType ElephantAgeType { 
			get { return __ElephantAgeType; }
			set{
				if(__ElephantAgeType != value) __ElephantAgeType = value;
			}
		}
		private int __HerdId
			 = default(int);
		internal int HerdId { 
			get { return __HerdId; }
			set{
				if(__HerdId != value) __HerdId = value;
			}
		}
		private string __ElephantTypeString
			 = default(string);
		internal string ElephantTypeString { 
			get { return __ElephantTypeString; }
			set{
				if(__ElephantTypeString != value) __ElephantTypeString = value;
			}
		}
		private bool __IsLeading
			 = default(bool);
		internal bool IsLeading { 
			get { return __IsLeading; }
			set{
				if(__IsLeading != value) __IsLeading = value;
			}
		}
		private bool __HasEatenFruits
			 = default(bool);
		internal bool HasEatenFruits { 
			get { return __HasEatenFruits; }
			set{
				if(__HasEatenFruits != value) __HasEatenFruits = value;
			}
		}
		private Mars.Components.Common.MarsList<System.Tuple<double,double>> __Sources
			 = default(Mars.Components.Common.MarsList<System.Tuple<double,double>>);
		internal Mars.Components.Common.MarsList<System.Tuple<double,double>> Sources { 
			get { return __Sources; }
			set{
				if(__Sources != value) __Sources = value;
			}
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void AddWaterSource(System.Tuple<double,double> coordinate) 
		{
			{
				Sources.Add(coordinate)
				;
			}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public System.Tuple<double,double> GetClosestWaterSource(System.Tuple<double,double> coordinate) 
		{
			{
				return GetClosestWaterSourceInSight(coordinate);
			}
			return default(System.Tuple<double,double>);
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public System.Tuple<double,double> GetClosestWaterSourceInSight(System.Tuple<double,double> coordinate) 
		{
			{
				int agentMaxSizeInKm = 25;	System.Tuple<double,double> waterSource = (new System.Func<Tuple<double, double>>(() => {
				var _sourceMapped42_1102 = coordinate;
				var _source42_1102 = new double[]{_sourceMapped42_1102.Item1, _sourceMapped42_1102.Item2};
				var _range42_1102 = agentMaxSizeInKm;
				var _cell42_1102 = _KNPGISVectorWaterLayer.Explore(_source42_1102, _range42_1102, 1, null).FirstOrDefault();
				if(_cell42_1102 != null) return new Tuple<double, double>(_cell42_1102.Node.Position[0], _cell42_1102.Node.Position[1]); return null;}).Invoke())			;
					Sources.Add(waterSource);
					return waterSource;
			}
			return default(System.Tuple<double,double>);
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public KruegerNationalPark.ElephantLifePeriodType GetElephantLifePeriod() 
		{
			{
				if(Age < 5) {
								return ElephantLifePeriodType.CALF
						;} else {
								if(Age <= 18) {
												return ElephantLifePeriodType.ADOLESCENT
										;} else {
												return ElephantLifePeriodType.ADULT
											;}
							;};
			}
			return default(KruegerNationalPark.ElephantLifePeriodType);
		}
		
		public KruegerNationalPark.ElephantLayer _ElephantLayer { get; set; }
		public KruegerNationalPark.ElephantLayer elephantLayer => _ElephantLayer;
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
		public Elephant (
		System.Guid _id,
		KruegerNationalPark.ElephantLayer _layer,
		Mars.Interfaces.Layer.RegisterAgent _register,
		Mars.Interfaces.Layer.UnregisterAgent _unregister,
		Mars.Components.Environments.GeoGridHashEnvironment<Elephant> _ElephantEnvironment,
		KruegerNationalPark.KNPGISRasterFenceLayer _KNPGISRasterFenceLayer,
		KruegerNationalPark.KNPGISRasterPrecipitationLayer _KNPGISRasterPrecipitationLayer,
		KruegerNationalPark.KNPGISRasterShadeLayer _KNPGISRasterShadeLayer,
		KruegerNationalPark.KNPGISRasterTempLayer _KNPGISRasterTempLayer,
		KruegerNationalPark.KNPGISRasterVegetationLayer _KNPGISRasterVegetationLayer,
		KruegerNationalPark.KNPGISVectorWaterLayer _KNPGISVectorWaterLayer
	,	int HerdId,
		string ElephantTypeString,
		bool IsLeading
	,	double xcor = 0, double ycor = 0, int freq = 1)
		 : base (xcor, ycor)
		{
			_ElephantLayer = _layer;
			ID = _id;
			this.HerdId = HerdId;
			this.ElephantTypeString = ElephantTypeString;
			this.IsLeading = IsLeading;
			this._KNPGISRasterFenceLayer = _KNPGISRasterFenceLayer;
			this._KNPGISRasterPrecipitationLayer = _KNPGISRasterPrecipitationLayer;
			this._KNPGISRasterShadeLayer = _KNPGISRasterShadeLayer;
			this._KNPGISRasterTempLayer = _KNPGISRasterTempLayer;
			this._KNPGISRasterVegetationLayer = _KNPGISRasterVegetationLayer;
			this._KNPGISVectorWaterLayer = _KNPGISVectorWaterLayer;
			_ElephantLayer._ElephantEnvironment.Insert(this);
			_register(_layer, this, freq);
			{
				ElephantAgeType = KruegerNationalPark.ElephantMaps.TypeMap.Get(ElephantTypeString);
					KruegerNationalPark.ElephantType _switch50_1306 = (ElephantAgeType);
				bool _matched_50_1306 = false;
				bool _fallthrough_50_1306 = false;
				if(!_matched_50_1306 || _fallthrough_50_1306) {
					
					_fallthrough_50_1306 = false;
					if(Object.Equals(_switch50_1306, ElephantType.ELEPHANT_NEWBORN)) {
						_matched_50_1306 = true;
						{
							Age = 0;
						}
					}
				}
				if(!_matched_50_1306 || _fallthrough_50_1306) {
					
					_fallthrough_50_1306 = false;
					if(Object.Equals(_switch50_1306, ElephantType.ELEPHANT_CALF)) {
						_matched_50_1306 = true;
						{
							Age = _Random.Next(5) + 1;	ElephantLifePeriod = ElephantLifePeriodType.CALF;
						}
					}
				}
				if(!_matched_50_1306 || _fallthrough_50_1306) {
					
					_fallthrough_50_1306 = false;
					if(Object.Equals(_switch50_1306, ElephantType.ELEPHANT_BULL)) {
						_matched_50_1306 = true;
						{
							Age = elephantLayer.NextNormalDistribution();
								ElephantLifePeriod = GetElephantLifePeriod();
						}
					}
				}
				if(!_matched_50_1306 || _fallthrough_50_1306) {
					
					_fallthrough_50_1306 = false;
					if(Object.Equals(_switch50_1306, ElephantType.ELEPHANT_COW)) {
						_matched_50_1306 = true;
						{
							Age = elephantLayer.NextNormalDistribution();
								ElephantLifePeriod = GetElephantLifePeriod();	if(ReproductionYears.Exists(new Func<int,bool>((int it) =>  {
									{
										return Object.Equals(it, Age)
									;};
									return default(bool);
							}))
							) {
											{
												if(_Random.NextDouble() < 0.8) {
																{
																	IsPregnant = true;	PregnantDuration = _Random.Next(22);
																}
														;} ;
											}
									;} ;
						}
					}
				}
				;
			}
		}
		
		public void Tick()
		{
		}
		
		public System.Guid ID { get; }
		public bool Equals(Elephant other) => Equals(ID, other.ID);
		public override int GetHashCode() => ID.GetHashCode();
	}
}
