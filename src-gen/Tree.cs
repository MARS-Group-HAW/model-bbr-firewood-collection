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
		private bool __IsAlive
			 = default(bool);
		internal bool IsAlive { 
			get { return __IsAlive; }
			set{
				if(__IsAlive != value) __IsAlive = value;
			}
		}
		private static string __AN
			 = "an";
		internal static string AN { 
			get { return __AN; }
			set{
				if(__AN != value) __AN = value;
			}
		}
		private static string __CA
			 = "ca";
		internal static string CA { 
			get { return __CA; }
			set{
				if(__CA != value) __CA = value;
			}
		}
		private static string __SB
			 = "sb";
		internal static string SB { 
			get { return __SB; }
			set{
				if(__SB != value) __SB = value;
			}
		}
		private static string __TT
			 = "tt";
		internal static string TT { 
			get { return __TT; }
			set{
				if(__TT != value) __TT = value;
			}
		}
		private static double __SeedlingSurvivalRate
			 = 0.12;
		internal static double SeedlingSurvivalRate { 
			get { return __SeedlingSurvivalRate; }
			set{
				if(System.Math.Abs(__SeedlingSurvivalRate - value) > 0.0000001) __SeedlingSurvivalRate = value;
			}
		}
		private static int __SeedlingsSpawnRatePerYear
			 = 50;
		internal static int SeedlingsSpawnRatePerYear { 
			get { return __SeedlingsSpawnRatePerYear; }
			set{
				if(__SeedlingsSpawnRatePerYear != value) __SeedlingsSpawnRatePerYear = value;
			}
		}
		private static int __DaysPerYear
			 = 365;
		internal static int DaysPerYear { 
			get { return __DaysPerYear; }
			set{
				if(__DaysPerYear != value) __DaysPerYear = value;
			}
		}
		private static int __DaysWithLeaves
			 = 228;
		internal static int DaysWithLeaves { 
			get { return __DaysWithLeaves; }
			set{
				if(__DaysWithLeaves != value) __DaysWithLeaves = value;
			}
		}
		private static double __E
			 = 2.718281828459045;
		internal static double E { 
			get { return __E; }
			set{
				if(System.Math.Abs(__E - value) > 0.0000001) __E = value;
			}
		}
		private static double __PI
			 = 3.14159265359;
		internal static double PI { 
			get { return __PI; }
			set{
				if(System.Math.Abs(__PI - value) > 0.0000001) __PI = value;
			}
		}
		private static double __EarthRadiusInMeters
			 = 6378100.0;
		internal static double EarthRadiusInMeters { 
			get { return __EarthRadiusInMeters; }
			set{
				if(System.Math.Abs(__EarthRadiusInMeters - value) > 0.0000001) __EarthRadiusInMeters = value;
			}
		}
		private string __Species
			 = default(string);
		public string Species { 
			get { return __Species; }
			set{
				if(__Species != value) __Species = value;
			}
		}
		private double __StemDiameter
			 = default(double);
		public double StemDiameter { 
			get { return __StemDiameter; }
			set{
				if(System.Math.Abs(__StemDiameter - value) > 0.0000001) __StemDiameter = value;
			}
		}
		private double __StemHeight
			 = default(double);
		internal double StemHeight { 
			get { return __StemHeight; }
			set{
				if(System.Math.Abs(__StemHeight - value) > 0.0000001) __StemHeight = value;
			}
		}
		private bool __HasLeaves
			 = default(bool);
		internal bool HasLeaves { 
			get { return __HasLeaves; }
			set{
				if(__HasLeaves != value) __HasLeaves = value;
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
		private double __DeadWoodMass
			 = default(double);
		public double DeadWoodMass { 
			get { return __DeadWoodMass; }
			set{
				if(System.Math.Abs(__DeadWoodMass - value) > 0.0000001) __DeadWoodMass = value;
			}
		}
		private KruegerNationalPark.DamageType __MyDamageType
			 = default(KruegerNationalPark.DamageType);
		internal KruegerNationalPark.DamageType MyDamageType { 
			get { return __MyDamageType; }
			set{
				if(__MyDamageType != value) __MyDamageType = value;
			}
		}
		private KruegerNationalPark.TreeAgeGroup __MyTreeAgeGroup
			 = default(KruegerNationalPark.TreeAgeGroup);
		public KruegerNationalPark.TreeAgeGroup MyTreeAgeGroup { 
			get { return __MyTreeAgeGroup; }
			set{
				if(__MyTreeAgeGroup != value) __MyTreeAgeGroup = value;
			}
		}
		private double __LastTickWithPrecipitation
			 = default(double);
		internal double LastTickWithPrecipitation { 
			get { return __LastTickWithPrecipitation; }
			set{
				if(System.Math.Abs(__LastTickWithPrecipitation - value) > 0.0000001) __LastTickWithPrecipitation = value;
			}
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public System.Tuple<double,double> TreePosition() 
		{
			{
			return new System.Tuple<double,double>(base.Position[0],base.Position[1])
					;
			}
			return default(System.Tuple<double,double>);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void InitWoodMass() 
		{
			{
			LivingWoodMass = CalculateLivingWoodMassByDiameter();
			DeadWoodMass = 0.017 * LivingWoodMass
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void UpdateWoodMass() 
		{
			{
			LivingWoodMass = CalculateLivingWoodMassByDiameter();
			DeadWoodMass = DeadWoodMass + GenerateDeadwoodMass()
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public KruegerNationalPark.DamageType CalculateDamageType(double result) 
		{
			{
			double quota = result / LivingWoodMass;
			if(quota > 0.9) {
							{
							return DamageType.Extreme
							;}
					;} else {
							if(quota > 0.1) {
											{
											return DamageType.Moderate
											;}
									;} 
						;};
			return DamageType.No
			;}
			return default(KruegerNationalPark.DamageType);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void UpdatePhotosyntheseActive() 
		{
			{
			if(Equals(Mars.Components.Common.Time.Month((int) Mars.Core.SimulationManager.Entities.SimulationClock.CurrentStep)
			, 10) && Equals(Mars.Components.Common.Time.Day((int) Mars.Core.SimulationManager.Entities.SimulationClock.CurrentStep)
			, 15)) {
							HasLeaves = true
					;} else {
							if(Equals(Mars.Components.Common.Time.Month((int) Mars.Core.SimulationManager.Entities.SimulationClock.CurrentStep)
							, 6) && Equals(Mars.Components.Common.Time.Day((int) Mars.Core.SimulationManager.Entities.SimulationClock.CurrentStep)
							, 15)) {
											HasLeaves = false
									;} 
						;}
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void UpdateTreeAgeGroup() 
		{
			{
			if(StemDiameter >= 1) {
							{
							if(IsJuvenileByStemDiameter()) {
											{
											MyTreeAgeGroup = TreeAgeGroup.Juvenile
											;}
									;} else {
											{
											MyTreeAgeGroup = TreeAgeGroup.Adult
											;}
										;}
							;}
					;} 
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public bool IsJuvenileByStemDiameter() 
		{
			{
			string _switch128_3102 = (Species);
			bool _matched_128_3102 = false;
			bool _fallthrough_128_3102 = false;
			if(!_matched_128_3102 || _fallthrough_128_3102) {
				if(Equals(_switch128_3102, AN)) {
					_matched_128_3102 = true;
					{
					return StemDiameter < 8
					;}
				} else {
					_fallthrough_128_3102 = false;
				}
			}
			if(!_matched_128_3102 || _fallthrough_128_3102) {
				if(Equals(_switch128_3102, CA)) {
					_matched_128_3102 = true;
					{
					return StemDiameter < 10
					;}
				} else {
					_fallthrough_128_3102 = false;
				}
			}
			if(!_matched_128_3102 || _fallthrough_128_3102) {
				if(Equals(_switch128_3102, SB)) {
					_matched_128_3102 = true;
					{
					return StemDiameter < 20
					;}
				} else {
					_fallthrough_128_3102 = false;
				}
			}
			if(!_matched_128_3102 || _fallthrough_128_3102) {
				if(Equals(_switch128_3102, TT)) {
					_matched_128_3102 = true;
					{
					return StemDiameter < 13
					;}
				} else {
					_fallthrough_128_3102 = false;
				}
			}
			;}
			return default(bool);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void Seed() 
		{
			{
			if(HasPrecipitation()) {
							{
							MyTreeAgeGroup = TreeAgeGroup.Seedling;
							if(RandomPropabilitySmallenThan(88 + _Random.Next(12))) {
											{
											Die()
											;}
									;} 
							;}
					;} 
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void Seedling() 
		{
			{
			if(IsFrozen() || IsDried()) {
							{
							Die()
							;}
					;} else {
							if(!Equals(MyDamageType, DamageType.No)) {
											{
											Die()
											;}
									;} else {
											if(HasLeaves) {
															{
															GrowSeedling()
															;}
													;} 
										;}
						;}
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public bool IsFrozen() 
		{
			{
			if(Equals(Species, AN)) {
							return false
					;} ;
			double tempToday = temperature.GetNumberValue(base.Position[1],base.Position[0]);
			return tempToday < 0 && RandomPropabilitySmallenThan(80)
			;}
			return default(bool);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public bool IsDried() 
		{
			{
			if(HasPrecipitation()) {
							{
							LastTickWithPrecipitation = (int) Mars.Core.SimulationManager.Entities.SimulationClock.CurrentStep
							;}
					;} ;
			return LastTickWithPrecipitation + 12 < (int) Mars.Core.SimulationManager.Entities.SimulationClock.CurrentStep
			;}
			return default(bool);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public bool HasPrecipitation() 
		{
			{
			double precipitationToday = precipitation.GetNumberValue(base.Position[1],base.Position[0]);
			return precipitationToday > 1
			;}
			return default(bool);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void Juvenile() 
		{
			{
			if(HasLeaves) {
							{
							if(!Equals(MyDamageType, DamageType.No)) {
											{
											GrowResprouting()
											;}
									;} else {
											{
											GrowJuvenile()
											;}
										;}
							;}
					;} 
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void Adult() 
		{
			{
			if(HasLeaves) {
							{
							if(Equals(MyDamageType, DamageType.No)) {
											{
											GrowAdult(1)
											;}
									;} else {
											if(Equals(MyDamageType, DamageType.Light)) {
															{
															GrowAdult(ReducedTo(90,100))
															;}
													;} else {
															if(Equals(MyDamageType, DamageType.Moderate)) {
																			{
																			GrowAdult(ReducedTo(70,90))
																			;}
																	;} else {
																			if(Equals(MyDamageType, DamageType.Heavy)) {
																							{
																							GrowAdult(ReducedTo(40,70))
																							;}
																					;} else {
																							if(Equals(MyDamageType, DamageType.Extreme)) {
																											{
																											GrowResprouting()
																											;}
																									;} 
																						;}
																		;}
														;}
										;}
							;}
					;} ;
			if(Equals(Mars.Components.Common.Time.Month((int) Mars.Core.SimulationManager.Entities.SimulationClock.CurrentStep)
			, 3) && Equals(Mars.Components.Common.Time.Day((int) Mars.Core.SimulationManager.Entities.SimulationClock.CurrentStep)
			, 15)) {
							{
							SpawnSeedlings()
							;}
					;} 
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void SpawnSeedlings() 
		{
			{
			for(int i = 0;
					 i < SeedlingsSpawnRatePerYear;
					 i++){
					 	{
					 	KruegerNationalPark.Tree seed = new System.Func<KruegerNationalPark.Tree>(() => {
					 	var _target223_5231 = GetRelativePosition(base.Position[0],base.Position[1],_Random.Next(50),_Random.Next(360));
					 	return _SavannaLayer._SpawnTree(_target223_5231.Item1, _target223_5231.Item2);}).Invoke();
					 	seed.SetSpecies(Species);
					 	seed.SetTreeAgeGroup(TreeAgeGroup.Seed)
					 	;}
					 }
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void GrowSeedling() 
		{
			{
			StemDiameter = StemDiameter + 1d / DaysWithLeaves
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void GrowResprouting() 
		{
			{
			GrowJuvenile()
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void GrowJuvenile() 
		{
			{
			string _switch246_5695 = (Species);
			bool _matched_246_5695 = false;
			bool _fallthrough_246_5695 = false;
			if(!_matched_246_5695 || _fallthrough_246_5695) {
				if(Equals(_switch246_5695, AN)) {
					_matched_246_5695 = true;
					{
					GrowJuvenileAn()
					;}
				} else {
					_fallthrough_246_5695 = false;
				}
			}
			if(!_matched_246_5695 || _fallthrough_246_5695) {
				if(Equals(_switch246_5695, CA)) {
					_matched_246_5695 = true;
					{
					GrowJuvenileCa()
					;}
				} else {
					_fallthrough_246_5695 = false;
				}
			}
			if(!_matched_246_5695 || _fallthrough_246_5695) {
				if(Equals(_switch246_5695, SB)) {
					_matched_246_5695 = true;
					{
					GrowJuvenileSb()
					;}
				} else {
					_fallthrough_246_5695 = false;
				}
			}
			if(!_matched_246_5695 || _fallthrough_246_5695) {
				if(Equals(_switch246_5695, TT)) {
					_matched_246_5695 = true;
					{
					GrowJuvenileTt()
					;}
				} else {
					_fallthrough_246_5695 = false;
				}
			}
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void GrowJuvenileAn() 
		{
			{
			StemHeight = CalculateHeightByDiameter(StemDiameter) + RandomBetween(11,36) / DaysWithLeaves;
			StemDiameter = CalculateDiameterByHeight(StemHeight)
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void GrowJuvenileCa() 
		{
			{
			StemDiameter = StemDiameter + (0.08 * StemDiameter + 0.089856) / DaysWithLeaves;
			StemHeight = CalculateHeightByDiameter(StemDiameter)
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void GrowJuvenileSb() 
		{
			{
			StemDiameter = StemDiameter + (-0.068 * StemDiameter + 4.54) / DaysWithLeaves;
			StemHeight = CalculateHeightByDiameter(StemDiameter)
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void GrowJuvenileTt() 
		{
			{
			StemDiameter = StemDiameter + 0.2 / DaysWithLeaves;
			StemHeight = CalculateHeightByDiameter(StemDiameter)
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void GrowAdult(double reduceFactor) 
		{
			{
			string _switch275_6582 = (Species);
			bool _matched_275_6582 = false;
			bool _fallthrough_275_6582 = false;
			if(!_matched_275_6582 || _fallthrough_275_6582) {
				if(Equals(_switch275_6582, AN)) {
					_matched_275_6582 = true;
					{
					GrowAdultAn(reduceFactor)
					;}
				} else {
					_fallthrough_275_6582 = false;
				}
			}
			if(!_matched_275_6582 || _fallthrough_275_6582) {
				if(Equals(_switch275_6582, CA)) {
					_matched_275_6582 = true;
					{
					GrowAdultCa(reduceFactor)
					;}
				} else {
					_fallthrough_275_6582 = false;
				}
			}
			if(!_matched_275_6582 || _fallthrough_275_6582) {
				if(Equals(_switch275_6582, SB)) {
					_matched_275_6582 = true;
					{
					GrowAdultSb(reduceFactor)
					;}
				} else {
					_fallthrough_275_6582 = false;
				}
			}
			if(!_matched_275_6582 || _fallthrough_275_6582) {
				if(Equals(_switch275_6582, TT)) {
					_matched_275_6582 = true;
					{
					GrowAdultTt(reduceFactor)
					;}
				} else {
					_fallthrough_275_6582 = false;
				}
			}
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void GrowAdultAn(double reduceFactor) 
		{
			{
			int maxStemDiameter = 20;
			int growthRate = 1;
			StemDiameter = StemDiameter + StemDiameterGrowthForAdult(maxStemDiameter,growthRate,reduceFactor)
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void GrowAdultCa(double reduceFactor) 
		{
			{
			int maxStemDiameter = 20;
			double growthRate = 0.5;
			StemDiameter = StemDiameter + StemDiameterGrowthForAdult(maxStemDiameter,growthRate,reduceFactor)
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void GrowAdultSb(double reduceFactor) 
		{
			{
			int maxStemDiameter = 50;
			int growthRate = 1;
			StemDiameter = StemDiameter + StemDiameterGrowthForAdult(maxStemDiameter,growthRate,reduceFactor)
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void GrowAdultTt(double reduceFactor) 
		{
			{
			int maxStemDiameter = 30;
			int growthRate = 1;
			StemDiameter = StemDiameter + StemDiameterGrowthForAdult(maxStemDiameter,growthRate,reduceFactor)
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public double StemDiameterGrowthForAdult(double maxStemDiameter, double growthRate, double reduceFactor) 
		{
			{
			return (1 - StemDiameter / maxStemDiameter) * growthRate / DaysWithLeaves * reduceFactor
			;}
			return default(double);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public double CalculateLivingWoodMassByDiameter() 
		{
			{
			if(Equals(MyTreeAgeGroup, TreeAgeGroup.Seed) || Equals(MyTreeAgeGroup, TreeAgeGroup.Seedling)) {
							{
							return 0
							;}
					;} ;
			string _switch315_7928 = (Species);
			bool _matched_315_7928 = false;
			bool _fallthrough_315_7928 = false;
			if(!_matched_315_7928 || _fallthrough_315_7928) {
				if(Equals(_switch315_7928, AN)) {
					_matched_315_7928 = true;
					{
					return Mars.Components.Common.Math.Pow(E, (-3.55 + 3.060 * Mars.Components.Common.Math.Log(StemDiameter)
					)) / 0.6
					;}
				} else {
					_fallthrough_315_7928 = false;
				}
			}
			if(!_matched_315_7928 || _fallthrough_315_7928) {
				if(Equals(_switch315_7928, CA)) {
					_matched_315_7928 = true;
					{
					return Mars.Components.Common.Math.Pow(E, (-3.27 + 2.800 * Mars.Components.Common.Math.Log(StemDiameter)
					)) / 0.6
					;}
				} else {
					_fallthrough_315_7928 = false;
				}
			}
			if(!_matched_315_7928 || _fallthrough_315_7928) {
				if(Equals(_switch315_7928, SB)) {
					_matched_315_7928 = true;
					{
					return Mars.Components.Common.Math.Pow(E, (-3.35 + 2.620 * Mars.Components.Common.Math.Log(StemDiameter)
					)) / 0.6
					;}
				} else {
					_fallthrough_315_7928 = false;
				}
			}
			if(!_matched_315_7928 || _fallthrough_315_7928) {
				if(Equals(_switch315_7928, TT)) {
					_matched_315_7928 = true;
					{
					return Mars.Components.Common.Math.Pow(E, (-3.39 + 2.827 * Mars.Components.Common.Math.Log(StemDiameter)
					)) / 0.6
					;}
				} else {
					_fallthrough_315_7928 = false;
				}
			}
			;}
			return default(double);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public double CalculateDiameterByWoodMass() 
		{
			{
			string _switch324_8310 = (Species);
			bool _matched_324_8310 = false;
			bool _fallthrough_324_8310 = false;
			if(!_matched_324_8310 || _fallthrough_324_8310) {
				if(Equals(_switch324_8310, AN)) {
					_matched_324_8310 = true;
					{
					return Mars.Components.Common.Math.Pow(E, ((3.55 + Mars.Components.Common.Math.Log(LivingWoodMass * 0.6)
					) / 3.060))
					;}
				} else {
					_fallthrough_324_8310 = false;
				}
			}
			if(!_matched_324_8310 || _fallthrough_324_8310) {
				if(Equals(_switch324_8310, CA)) {
					_matched_324_8310 = true;
					{
					return Mars.Components.Common.Math.Pow(E, ((3.27 + Mars.Components.Common.Math.Log(LivingWoodMass * 0.6)
					) / 2.800))
					;}
				} else {
					_fallthrough_324_8310 = false;
				}
			}
			if(!_matched_324_8310 || _fallthrough_324_8310) {
				if(Equals(_switch324_8310, SB)) {
					_matched_324_8310 = true;
					{
					return Mars.Components.Common.Math.Pow(E, ((3.35 + Mars.Components.Common.Math.Log(LivingWoodMass * 0.6)
					) / 2.620))
					;}
				} else {
					_fallthrough_324_8310 = false;
				}
			}
			if(!_matched_324_8310 || _fallthrough_324_8310) {
				if(Equals(_switch324_8310, TT)) {
					_matched_324_8310 = true;
					{
					return Mars.Components.Common.Math.Pow(E, ((3.39 + Mars.Components.Common.Math.Log(LivingWoodMass * 0.6)
					) / 2.827))
					;}
				} else {
					_fallthrough_324_8310 = false;
				}
			}
			;}
			return default(double);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public double GenerateDeadwoodMass() 
		{
			{
			return 0.017 * LivingWoodMass / DaysPerYear
			;}
			return default(double);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void Die() 
		{
			{
			MyTreeAgeGroup = TreeAgeGroup.Death;
			IsAlive = false
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void ResetDamageType() 
		{
			{
			MyDamageType = DamageType.No
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static double Reduce(double growthrate, int min, int max) 
		{
			{
			return growthrate * (min + RandomBetween(min,max)) / 100
			;}
			return default(double);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static double CalculateHeightByDiameter(double stemDiameter) 
		{
			{
			return 11.043 * stemDiameter + 88.326
					;
			}
			return default(double);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static double CalculateDiameterByHeight(double stemHeight) 
		{
			{
			return (stemHeight - 88.326) / 11.043
					;
			}
			return default(double);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static bool RandomPropabilitySmallenThan(int percentage) 
		{
			{
			return _Random.Next(100) < percentage
			;}
			return default(bool);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static double RandomBetween(int min, int max) 
		{
			{
			return _Random.Next(max + 1 - min) + min
			;}
			return default(double);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static double ReducedTo(int minPercentage, int maxPercentag) 
		{
			{
			return RandomBetween(minPercentage,maxPercentag) / 100
			;}
			return default(double);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public System.Tuple<double,double> GetRelativePosition(double originLongitude, double originLatitude, double bearing, double distanceInM) 
		{
			{
			double DegreesToRadians = PI / 180.0;
			double RadiansToDegrees = 180.0 / PI;
			double latA = DegreesToRadians * originLatitude;
			double lonA = originLongitude * DegreesToRadians;
			double radBearing = bearing * DegreesToRadians;
			double cosB = Mars.Components.Common.Math.Cos(distanceInM / EarthRadiusInMeters);
			double cosLatB = Mars.Components.Common.Math.Cos(latA);
			double SinLatA = Mars.Components.Common.Math.Sin(latA);
			double sinB = Mars.Components.Common.Math.Sin(distanceInM / EarthRadiusInMeters);
			double cosBearing = Mars.Components.Common.Math.Cos(radBearing);
			double temp1 = SinLatA * cosB;
			double temp2 = 0;
			double lat = Mars.Components.Common.Math.Asin(temp1 + cosLatB * sinB * cosBearing);
			double SinLat = Mars.Components.Common.Math.Sin(lat);
			double sindBearing = Mars.Components.Common.Math.Sin(radBearing);
			double atan1 = sindBearing * Mars.Components.Common.Math.Sin(distanceInM / EarthRadiusInMeters)
			 * Mars.Components.Common.Math.Cos(latA);
			double cosDistance = Mars.Components.Common.Math.Cos(distanceInM / EarthRadiusInMeters);
			double atan2 = cosDistance - SinLatA * SinLat;
			double lon = lonA + Mars.Components.Common.Math.Atan2(atan1,atan2);
			double latResult = lat * RadiansToDegrees;
			double lonResult = lon * RadiansToDegrees;
			return new System.Tuple<double,double>(lonResult,latResult)
			;}
			return default(System.Tuple<double,double>);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public double TakeDeadWoodMass(
		double mass) {
			{
			double result = default(double);;
			if(mass < DeadWoodMass) {
							{
							result = mass
							;}
					;} else {
							{
							result = DeadWoodMass
							;}
						;};
			DeadWoodMass = DeadWoodMass - result;
			return result
			;}
			
			return default(double);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public double TakeLivingWoodMass(
		double mass) {
			{
			double currentLivingWoodMass = CalculateLivingWoodMassByDiameter();
			double result = default(double);;
			if(mass < currentLivingWoodMass) {
							{
							result = mass
							;}
					;} else {
							{
							result = currentLivingWoodMass
							;}
						;};
			MyDamageType = CalculateDamageType(result);
			LivingWoodMass = LivingWoodMass - result;
			StemDiameter = CalculateDiameterByWoodMass();
			return result
			;}
			
			return default(double);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void SufferDrought() {
			{
			if(!Equals(MyTreeAgeGroup, TreeAgeGroup.Adult) && RandomPropabilitySmallenThan(7)) {
							{
							Die()
							;}
					;} 
			;}
			
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void SetSpecies(
		string species) {
			{
			Species = species
			;}
			
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void SetTreeAgeGroup(
		KruegerNationalPark.TreeAgeGroup treeAgeGroup) {
			{
			MyTreeAgeGroup = treeAgeGroup
			;}
			
			return;
		}
		
		public KruegerNationalPark.SavannaLayer _SavannaLayer { get; set; }
		public KruegerNationalPark.Precipitation _Precipitation { get; set; }
		public KruegerNationalPark.Precipitation precipitation => _Precipitation;
		public KruegerNationalPark.Temperature _Temperature { get; set; }
		public KruegerNationalPark.Temperature temperature => _Temperature;
		
		[Mars.Interfaces.LIFECapabilities.PublishForMappingInMars]
		public Tree (
		System.Guid _id,
		KruegerNationalPark.SavannaLayer _layer,
		Mars.Interfaces.Layer.RegisterAgent _register,
		Mars.Interfaces.Layer.UnregisterAgent _unregister,
		Mars.Components.Environments.GeoGridHashEnvironment<Tree> _TreeEnvironment,
		KruegerNationalPark.Precipitation _Precipitation,
		KruegerNationalPark.Temperature _Temperature
	,	string Species,
		double StemDiameter
	,	double xcor = 0, double ycor = 0, int freq = 1)
		 : base (xcor, ycor)
		{
			_SavannaLayer = _layer;
			ID = _id;
			this.Species = Species;
			this.StemDiameter = StemDiameter;
			this._Precipitation = _Precipitation;
			this._Temperature = _Temperature;
			_SavannaLayer._TreeEnvironment.Insert(this);
			_register(_layer, this, freq);
			{
			MyTreeAgeGroup = TreeAgeGroup.Seedling;
			MyDamageType = DamageType.No;
			UpdateTreeAgeGroup();
			StemHeight = CalculateHeightByDiameter(StemDiameter);
			InitWoodMass()
			;}
		}
		
		public void Tick()
		{
			{
			UpdateTreeAgeGroup();
			UpdatePhotosyntheseActive();
			if(Equals(MyTreeAgeGroup, TreeAgeGroup.Seed)) {
							{
							Seed()
							;}
					;} else {
							if(Equals(MyTreeAgeGroup, TreeAgeGroup.Seedling)) {
											{
											Seedling()
											;}
									;} else {
											if(Equals(MyTreeAgeGroup, TreeAgeGroup.Juvenile)) {
															{
															Juvenile()
															;}
													;} else {
															if(Equals(MyTreeAgeGroup, TreeAgeGroup.Adult)) {
																			{
																			Adult()
																			;}
																	;} 
														;}
										;}
						;};
			UpdateWoodMass();
			ResetDamageType()
			;}
		}
		
		public System.Guid ID { get; }
		public bool Equals(Tree other) => Equals(ID, other.ID);
		public override int GetHashCode() => ID.GetHashCode();
	}
}
