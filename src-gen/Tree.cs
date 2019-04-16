namespace KruegerNationalPark {
	using System;
	using System.Linq;
	using System.Collections.Generic;
	// ReSharper disable All
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
		private static double __growthBoosterByClimate
			 = 1.0;
		internal static double growthBoosterByClimate { 
			get { return __growthBoosterByClimate; }
			set{
				if(System.Math.Abs(__growthBoosterByClimate - value) > 0.0000001) __growthBoosterByClimate = value;
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
		private static string __ALL_SPECIES
			 = "ALL";
		internal static string ALL_SPECIES { 
			get { return __ALL_SPECIES; }
			set{
				if(__ALL_SPECIES != value) __ALL_SPECIES = value;
			}
		}
		private static int __SeedlingSurvivalRate
			 = 12;
		internal static int SeedlingSurvivalRate { 
			get { return __SeedlingSurvivalRate; }
			set{
				if(__SeedlingSurvivalRate != value) __SeedlingSurvivalRate = value;
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
		private string __Raster
			 = default(string);
		public string Raster { 
			get { return __Raster; }
			set{
				if(__Raster != value) __Raster = value;
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
		private double __Bark
			 = default(double);
		public double Bark { 
			get { return __Bark; }
			set{
				if(System.Math.Abs(__Bark - value) > 0.0000001) __Bark = value;
			}
		}
		private string __DyingReason
			 = default(string);
		public string DyingReason { 
			get { return __DyingReason; }
			set{
				if(__DyingReason != value) __DyingReason = value;
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
		private KruegerNationalPark.DamageType __MyDamageType
			 = default(KruegerNationalPark.DamageType);
		internal KruegerNationalPark.DamageType MyDamageType { 
			get { return __MyDamageType; }
			set{
				if(__MyDamageType != value) __MyDamageType = value;
			}
		}
		private double __FirstTickAsSeedling
			 = default(double);
		internal double FirstTickAsSeedling { 
			get { return __FirstTickAsSeedling; }
			set{
				if(System.Math.Abs(__FirstTickAsSeedling - value) > 0.0000001) __FirstTickAsSeedling = value;
			}
		}
		private bool __seedSurvivedFirst12Days
			 = default(bool);
		internal bool seedSurvivedFirst12Days { 
			get { return __seedSurvivedFirst12Days; }
			set{
				if(__seedSurvivedFirst12Days != value) __seedSurvivedFirst12Days = value;
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
		public void ReduceBarkBy(double subtrahend) 
		{
			{
			Bark = Bark - subtrahend
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void UpdateOnNewBark() 
		{
			{
			if(Bark < 0) {
							{
							Die("RoundBarked")
							;}
					;} else {
							if(Bark < 0.5) {
											{
											MyDamageType = DamageType.Moderate
											;}
									;} 
						;}
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public double ReduceLivingWoodMassBy(double mass) 
		{
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
			string _switch168_3786 = (Species);
			bool _matched_168_3786 = false;
			bool _fallthrough_168_3786 = false;
			if(!_matched_168_3786 || _fallthrough_168_3786) {
				if(Equals(_switch168_3786, AN)) {
					_matched_168_3786 = true;
					{
					return StemDiameter < 8
					;}
				} else {
					_fallthrough_168_3786 = false;
				}
			}
			if(!_matched_168_3786 || _fallthrough_168_3786) {
				if(Equals(_switch168_3786, CA)) {
					_matched_168_3786 = true;
					{
					return StemDiameter < 10
					;}
				} else {
					_fallthrough_168_3786 = false;
				}
			}
			if(!_matched_168_3786 || _fallthrough_168_3786) {
				if(Equals(_switch168_3786, SB)) {
					_matched_168_3786 = true;
					{
					return StemDiameter < 20
					;}
				} else {
					_fallthrough_168_3786 = false;
				}
			}
			if(!_matched_168_3786 || _fallthrough_168_3786) {
				if(Equals(_switch168_3786, TT)) {
					_matched_168_3786 = true;
					{
					return StemDiameter < 13
					;}
				} else {
					_fallthrough_168_3786 = false;
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
							FirstTickAsSeedling = (int) Mars.Core.SimulationManager.Entities.SimulationClock.CurrentStep;
							if(RandomPropabilitySmallenThan(100 - SeedlingSurvivalRate + _Random.Next(SeedlingSurvivalRate))) {
											{
											Die("RandomProbability")
											;}
									;} else {
											if(IsPopulationDensityExceeded()) {
															{
															Die("PopulationDensity")
															;}
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
			if(IsFrozen()) {
							{
							Die("Frozen")
							;}
					;} else {
							if(IsDried()) {
											{
											Die("Dried")
											;}
									;} else {
											if(!Equals(MyDamageType, DamageType.No)) {
															{
															Die("Damaged")
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
			if(FirstTickAsSeedling + 12 < (int) Mars.Core.SimulationManager.Entities.SimulationClock.CurrentStep) {
							{
							seedSurvivedFirst12Days = HasPrecipitation();
							return false
							;}
					;} ;
			return seedSurvivedFirst12Days
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
					 	var _target275_6296 = GetRelativePosition(base.Position[0],base.Position[1],_Random.Next(50),_Random.Next(360));
					 	return _SavannaLayer._SpawnTree(_target275_6296.Item1, _target275_6296.Item2);}).Invoke();
					 	seed.SetSpecies(Species);
					 	seed.SetTreeAgeGroup(TreeAgeGroup.Seed);
					 	seed.SetRaster(Raster)
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
			string _switch303_6849 = (Species);
			bool _matched_303_6849 = false;
			bool _fallthrough_303_6849 = false;
			if(!_matched_303_6849 || _fallthrough_303_6849) {
				if(Equals(_switch303_6849, AN)) {
					_matched_303_6849 = true;
					{
					GrowJuvenileAn()
					;}
				} else {
					_fallthrough_303_6849 = false;
				}
			}
			if(!_matched_303_6849 || _fallthrough_303_6849) {
				if(Equals(_switch303_6849, CA)) {
					_matched_303_6849 = true;
					{
					GrowJuvenileCa()
					;}
				} else {
					_fallthrough_303_6849 = false;
				}
			}
			if(!_matched_303_6849 || _fallthrough_303_6849) {
				if(Equals(_switch303_6849, SB)) {
					_matched_303_6849 = true;
					{
					GrowJuvenileSb()
					;}
				} else {
					_fallthrough_303_6849 = false;
				}
			}
			if(!_matched_303_6849 || _fallthrough_303_6849) {
				if(Equals(_switch303_6849, TT)) {
					_matched_303_6849 = true;
					{
					GrowJuvenileTt()
					;}
				} else {
					_fallthrough_303_6849 = false;
				}
			}
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void GrowJuvenileAn() 
		{
			{
			StemDiameter = StemDiameter + (-0.068 * StemDiameter + 0.9) / DaysWithLeaves * growthBoosterByClimate
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void GrowJuvenileCa() 
		{
			{
			StemDiameter = StemDiameter + (-0.068 * StemDiameter + 1.2) / DaysWithLeaves * growthBoosterByClimate
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void GrowJuvenileSb() 
		{
			{
			StemDiameter = StemDiameter + (-0.068 * StemDiameter + 1.9) / DaysWithLeaves * growthBoosterByClimate
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void GrowJuvenileTt() 
		{
			{
			StemDiameter = StemDiameter + (-0.068 * StemDiameter + 1.33) / DaysWithLeaves * growthBoosterByClimate
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void GrowAdult(double reduceFactor) 
		{
			{
			string _switch328_7576 = (Species);
			bool _matched_328_7576 = false;
			bool _fallthrough_328_7576 = false;
			if(!_matched_328_7576 || _fallthrough_328_7576) {
				if(Equals(_switch328_7576, AN)) {
					_matched_328_7576 = true;
					{
					GrowAdultAn(reduceFactor)
					;}
				} else {
					_fallthrough_328_7576 = false;
				}
			}
			if(!_matched_328_7576 || _fallthrough_328_7576) {
				if(Equals(_switch328_7576, CA)) {
					_matched_328_7576 = true;
					{
					GrowAdultCa(reduceFactor)
					;}
				} else {
					_fallthrough_328_7576 = false;
				}
			}
			if(!_matched_328_7576 || _fallthrough_328_7576) {
				if(Equals(_switch328_7576, SB)) {
					_matched_328_7576 = true;
					{
					GrowAdultSb(reduceFactor)
					;}
				} else {
					_fallthrough_328_7576 = false;
				}
			}
			if(!_matched_328_7576 || _fallthrough_328_7576) {
				if(Equals(_switch328_7576, TT)) {
					_matched_328_7576 = true;
					{
					GrowAdultTt(reduceFactor)
					;}
				} else {
					_fallthrough_328_7576 = false;
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
		public bool IsPopulationDensityExceeded() 
		{
			{
			return IsTooCloseTo(TreeAgeGroup.Seed,ALL_SPECIES,4) || IsTooCloseTo(TreeAgeGroup.Seedling,ALL_SPECIES,4) || IsTooCloseTo(TreeAgeGroup.Juvenile,AN,32) || IsTooCloseTo(TreeAgeGroup.Juvenile,CA,40) || IsTooCloseTo(TreeAgeGroup.Juvenile,SB,80) || IsTooCloseTo(TreeAgeGroup.Juvenile,TT,52) || IsTooCloseTo(TreeAgeGroup.Adult,AN,80) || IsTooCloseTo(TreeAgeGroup.Adult,CA,80) || IsTooCloseTo(TreeAgeGroup.Adult,SB,200) || IsTooCloseTo(TreeAgeGroup.Adult,TT,120)
			;}
			return default(bool);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public bool IsTooCloseTo(KruegerNationalPark.TreeAgeGroup treeAgeGroup, string species, double minDistance) 
		{
			{
			KruegerNationalPark.Tree tree = new Func<KruegerNationalPark.Tree>(() => {
			Func<KruegerNationalPark.Tree, bool> _predicate374_9224 = new Func<KruegerNationalPark.Tree,bool>((KruegerNationalPark.Tree x) =>  {
					{
					return x.IsTreeAgeGroup(treeAgeGroup)
					 && x.IsSpecies(species)
					;}
					;
					return default(bool);;
			});
			const int _range374_9224 = -1;
			var _source374_9224 = this;
			return _SavannaLayer._TreeEnvironment.Explore(_source374_9224, _range374_9224, 1, _predicate374_9224)?.FirstOrDefault();}).Invoke();
			return !Equals(tree, null) && DistanceTo(tree) < minDistance
			;}
			return default(bool);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public double DistanceTo(KruegerNationalPark.Tree tree) 
		{
			{
			double constant = 111.3;
			double lat = (tree.Ycor()
			 + base.Position[1]) / 2 * 0.01745;
			double dx = constant * Mars.Components.Common.Math.Cos(lat)
			 * (tree.Xcor()
			 - base.Position[0]);
			double dy = constant * (tree.Ycor()
			 - base.Position[1]);
			return 1000 * Mars.Components.Common.Math.Sqrt(dx * dx + dy * dy)
			;}
			return default(double);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public double StemDiameterGrowthForAdult(double maxStemDiameter, double growthRate, double reduceFactor) 
		{
			{
			return (1 - StemDiameter / maxStemDiameter) * growthRate / DaysWithLeaves * reduceFactor * growthBoosterByClimate
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
			string _switch394_10037 = (Species);
			bool _matched_394_10037 = false;
			bool _fallthrough_394_10037 = false;
			if(!_matched_394_10037 || _fallthrough_394_10037) {
				if(Equals(_switch394_10037, AN)) {
					_matched_394_10037 = true;
					{
					return Mars.Components.Common.Math.Pow(E, (-3.55 + 3.060 * Mars.Components.Common.Math.Log(StemDiameter)
					)) / 0.6
					;}
				} else {
					_fallthrough_394_10037 = false;
				}
			}
			if(!_matched_394_10037 || _fallthrough_394_10037) {
				if(Equals(_switch394_10037, CA)) {
					_matched_394_10037 = true;
					{
					return Mars.Components.Common.Math.Pow(E, (-3.27 + 2.800 * Mars.Components.Common.Math.Log(StemDiameter)
					)) / 0.6
					;}
				} else {
					_fallthrough_394_10037 = false;
				}
			}
			if(!_matched_394_10037 || _fallthrough_394_10037) {
				if(Equals(_switch394_10037, SB)) {
					_matched_394_10037 = true;
					{
					return Mars.Components.Common.Math.Pow(E, (-3.35 + 2.620 * Mars.Components.Common.Math.Log(StemDiameter)
					)) / 0.6
					;}
				} else {
					_fallthrough_394_10037 = false;
				}
			}
			if(!_matched_394_10037 || _fallthrough_394_10037) {
				if(Equals(_switch394_10037, TT)) {
					_matched_394_10037 = true;
					{
					return Mars.Components.Common.Math.Pow(E, (-3.39 + 2.827 * Mars.Components.Common.Math.Log(StemDiameter)
					)) / 0.6
					;}
				} else {
					_fallthrough_394_10037 = false;
				}
			}
			;}
			return default(double);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public double CalculateDiameterByWoodMass() 
		{
			{
			string _switch403_10419 = (Species);
			bool _matched_403_10419 = false;
			bool _fallthrough_403_10419 = false;
			if(!_matched_403_10419 || _fallthrough_403_10419) {
				if(Equals(_switch403_10419, AN)) {
					_matched_403_10419 = true;
					{
					return Mars.Components.Common.Math.Pow(E, ((3.55 + Mars.Components.Common.Math.Log(LivingWoodMass * 0.6)
					) / 3.060))
					;}
				} else {
					_fallthrough_403_10419 = false;
				}
			}
			if(!_matched_403_10419 || _fallthrough_403_10419) {
				if(Equals(_switch403_10419, CA)) {
					_matched_403_10419 = true;
					{
					return Mars.Components.Common.Math.Pow(E, ((3.27 + Mars.Components.Common.Math.Log(LivingWoodMass * 0.6)
					) / 2.800))
					;}
				} else {
					_fallthrough_403_10419 = false;
				}
			}
			if(!_matched_403_10419 || _fallthrough_403_10419) {
				if(Equals(_switch403_10419, SB)) {
					_matched_403_10419 = true;
					{
					return Mars.Components.Common.Math.Pow(E, ((3.35 + Mars.Components.Common.Math.Log(LivingWoodMass * 0.6)
					) / 2.620))
					;}
				} else {
					_fallthrough_403_10419 = false;
				}
			}
			if(!_matched_403_10419 || _fallthrough_403_10419) {
				if(Equals(_switch403_10419, TT)) {
					_matched_403_10419 = true;
					{
					return Mars.Components.Common.Math.Pow(E, ((3.39 + Mars.Components.Common.Math.Log(LivingWoodMass * 0.6)
					) / 2.827))
					;}
				} else {
					_fallthrough_403_10419 = false;
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
		public void Die(string reason) 
		{
			{
			DyingReason = reason;
			MyTreeAgeGroup = TreeAgeGroup.Death;
			new System.Action(() => {
				var _target418_10932 = this
				if (target != null) {
					_agent418_10932._Layer_._Unregister(_SavannaLayer, _target418_10932, _target418_10932._executionFrequency);
				}
			}).Invoke()
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
		public void ResetBarkBy(double percent) 
		{
			{
			Bark = Bark + Bark * percent / 100;
			if(Bark > 1.0) {
							{
							Bark = 1.0
							;}
					;} 
			;}
			return;
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
		public static double Reduce(double growthrate, int min, int max) 
		{
			{
			return growthrate * (min + RandomBetween(min,max)) / 100
			;}
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
		public double Xcor() {
			{
			return base.Position[0]
			;}
			
			return default(double);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public double Ycor() {
			{
			return base.Position[1]
			;}
			
			return default(double);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public bool IsTreeAgeGroup(
		KruegerNationalPark.TreeAgeGroup treeAgeGroup) {
			{
			return Equals(MyTreeAgeGroup, treeAgeGroup)
			;}
			
			return default(bool);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public bool IsSpecies(
		string species) {
			{
			return Equals(species, ALL_SPECIES) || Equals(Species, species)
			;}
			
			return default(bool);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void TakeBark(
		double percent) {
			{
			ReduceBarkBy(percent / 100);
			UpdateOnNewBark()
			;}
			
			return;
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
		public double TakePushOver() {
			{
			double result = ReduceLivingWoodMassBy(LivingWoodMass);
			if(RandomPropabilitySmallenThan(50)) {
							{
							Die("PushOver")
							;}
					;} ;
			return result
			;}
			
			return default(double);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public double TakeDamage(
		double mass) {
			{
			return ReduceLivingWoodMassBy(mass)
			;}
			
			return default(double);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public double TakeLivingWoodMass(
		double mass) {
			{
			return ReduceLivingWoodMassBy(mass)
			;}
			
			return default(double);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void SufferDrought() {
			{
			if(!Equals(MyTreeAgeGroup, TreeAgeGroup.Adult) && RandomPropabilitySmallenThan(7)) {
							{
							Die("Drought")
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
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void SetRaster(
		string raster) {
			{
			Raster = raster
			;}
			
			return;
		}
		internal bool _isAlive;
		internal int _executionFrequency;
		
		public KruegerNationalPark.SavannaLayer _Layer_ => _SavannaLayer;
		public KruegerNationalPark.SavannaLayer _SavannaLayer { get; set; }
		public Mars.Components.Environments.GeoGridHashEnvironment<Tree> _TreeEnvironment { get; set; }
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
		double StemDiameter,
		string Raster
	,	double xcor = 0, double ycor = 0, int freq = 1)
		 : base (xcor, ycor)
		{
			_SavannaLayer = _layer;
			ID = _id;
			this.Species = Species;
			this.StemDiameter = StemDiameter;
			this.Raster = Raster;
			this._Precipitation = _Precipitation;
			this._Temperature = _Temperature;
			_SavannaLayer._TreeEnvironment.Insert(this);
			_register(_layer, this, freq);
			_isAlive = true;
			_executionFrequency = freq;
			{
			MyTreeAgeGroup = TreeAgeGroup.Seed;
			MyDamageType = DamageType.No;
			Bark = 1.0;
			UpdateTreeAgeGroup();
			InitWoodMass()
			;}
		}
		
		public void Tick()
		{
			{ if (!_isAlive) return; }
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
			if(Equals(Mars.Components.Common.Time.Month((int) Mars.Core.SimulationManager.Entities.SimulationClock.CurrentStep)
			, 3) && Equals(Mars.Components.Common.Time.Day((int) Mars.Core.SimulationManager.Entities.SimulationClock.CurrentStep)
			, 15)) {
							{
							ResetDamageType();
							ResetBarkBy(30)
							;}
					;} 
			;}
		}
		
		public System.Guid ID { get; }
		public bool Equals(Tree other) => Equals(ID, other.ID);
		public override int GetHashCode() => ID.GetHashCode();
	}
}
