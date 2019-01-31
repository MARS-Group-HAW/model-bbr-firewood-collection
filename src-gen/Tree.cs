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
		private string __TreeType
			 = default(string);
		public string TreeType { 
			get { return __TreeType; }
			set{
				if(__TreeType != value) __TreeType = value;
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
		public double StemHeight { 
			get { return __StemHeight; }
			set{
				if(System.Math.Abs(__StemHeight - value) > 0.0000001) __StemHeight = value;
			}
		}
		private bool __HasLeaves
			 = default(bool);
		public bool HasLeaves { 
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
		private static int __DaysPerYear
			 = 365;
		internal static int DaysPerYear { 
			get { return __DaysPerYear; }
			set{
				if(System.Math.Abs(__DaysPerYear - value) > 0.0000001) __DaysPerYear = value;
			}
		}
		private static int __DaysWithLeaves
			 = 228;
		internal static int DaysWithLeaves { 
			get { return __DaysWithLeaves; }
			set{
				if(System.Math.Abs(__DaysWithLeaves - value) > 0.0000001) __DaysWithLeaves = value;
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
		private static int __SeedlingsSpawnRatePerYear
			 = 50;
		internal static int SeedlingsSpawnRatePerYear { 
			get { return __SeedlingsSpawnRatePerYear; }
			set{
				if(System.Math.Abs(__SeedlingsSpawnRatePerYear - value) > 0.0000001) __SeedlingsSpawnRatePerYear = value;
			}
		}
		private KruegerNationalPark.DamageType __MyDamageType
			 = DamageType.No;
		public KruegerNationalPark.DamageType MyDamageType { 
			get { return __MyDamageType; }
			set{
				if(__MyDamageType != value) __MyDamageType = value;
			}
		}
		private KruegerNationalPark.TreeStateType __MyTreeStateType
			 = TreeStateType.Seedling;
		internal KruegerNationalPark.TreeStateType MyTreeStateType { 
			get { return __MyTreeStateType; }
			set{
				if(__MyTreeStateType != value) __MyTreeStateType = value;
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
		public double CalculateHeigth() 
		{
			{
			return 11.043 * StemDiameter + 88.326
					;
			}
			return default(double);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public double CalculateDiameter() 
		{
			{
			return (StemHeight - 88.326) / 11.043
					;
			}
			return default(double);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public KruegerNationalPark.DamageType CalculateDamageType(double result) 
		{
			{
			if(result / LivingWoodMass > 0.9) {
							{
							return DamageType.Extreme
							;}
					;} else {
							if(result / LivingWoodMass > 0.1) {
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
		public void UpdateTreeStateType() 
		{
			{
			if(StemDiameter >= 1) {
							{
							if(IsJuvenileByStemDiameter()) {
											{
											MyTreeStateType = TreeStateType.Juvenile
											;}
									;} else {
											{
											MyTreeStateType = TreeStateType.Adult
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
			if(Equals(TreeType, AN)) {
							{
							return StemDiameter < 8
							;}
					;} else {
							if(Equals(TreeType, CA)) {
											{
											return StemDiameter < 10
											;}
									;} else {
											if(Equals(TreeType, SB)) {
															{
															return StemDiameter < 20
															;}
													;} else {
															if(Equals(TreeType, TT)) {
																			{
																			return StemDiameter < 13
																			;}
																	;} 
														;}
										;}
						;}
			;}
			return default(bool);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void Seedling() 
		{
			{
			double tempToday = temperature.GetNumberValue(base.Position[1],base.Position[0]);
			if(tempToday < 0 && RandomPropabilitySmallenThan(80)) {
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
											Grow(1)
											;}
									;} else {
											if(Equals(MyDamageType, DamageType.Light)) {
															{
															Grow(ReducedTo(90,100))
															;}
													;} else {
															if(Equals(MyDamageType, DamageType.Moderate)) {
																			{
																			Grow(ReducedTo(70,90))
																			;}
																	;} else {
																			if(Equals(MyDamageType, DamageType.Heavy)) {
																							{
																							Grow(ReducedTo(40,70))
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
					 	KruegerNationalPark.Tree seedling = new System.Func<KruegerNationalPark.Tree>(() => {
					 	var _target185_4632 = GetRelativePosition(base.Position[1],base.Position[0],_Random.Next(50),_Random.Next(360));
					 	return _SavannaLayer._SpawnTree(_target185_4632.Item1, _target185_4632.Item2);}).Invoke();
					 	seedling.SetTreeType(TreeType)
					 	;}
					 }
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void GrowSeedling() 
		{
			{
			StemDiameter = StemDiameter + StemDiameter / DaysWithLeaves
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
			if(Equals(TreeType, AN)) {
							{
							GrowAnJuvenile()
							;}
					;} else {
							if(Equals(TreeType, CA)) {
											{
											GrowCaJuvenile()
											;}
									;} else {
											if(Equals(TreeType, SB)) {
															{
															GrowSbJuvenile()
															;}
													;} else {
															if(Equals(TreeType, TT)) {
																			{
																			GrowTtJuvenile()
																			;}
																	;} 
														;}
										;}
						;}
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void GrowAnJuvenile() 
		{
			{
			StemHeight = StemHeight + RandomBetween(11,36) / DaysWithLeaves;
			StemDiameter = CalculateDiameter()
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void GrowCaJuvenile() 
		{
			{
			StemDiameter = StemDiameter + (0.08 * StemDiameter + 0.089856) / DaysWithLeaves;
			StemHeight = CalculateHeigth()
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void GrowSbJuvenile() 
		{
			{
			StemDiameter = StemDiameter + (-0.068 * StemDiameter + 4.54) / DaysWithLeaves;
			StemHeight = CalculateHeigth()
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void GrowTtJuvenile() 
		{
			{
			StemDiameter = StemDiameter + 1 / DaysWithLeaves;
			StemHeight = CalculateHeigth()
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void Grow(double reduceFactor) 
		{
			{
			if(Equals(TreeType, AN)) {
							{
							GrowAn(reduceFactor)
							;}
					;} else {
							if(Equals(TreeType, CA)) {
											{
											GrowCa(reduceFactor)
											;}
									;} else {
											if(Equals(TreeType, SB)) {
															{
															GrowSb(reduceFactor)
															;}
													;} else {
															if(Equals(TreeType, TT)) {
																			{
																			GrowTt(reduceFactor)
																			;}
																	;} 
														;}
										;}
						;};
			double mytemp = temperature.GetNumberValue(base.Position[1],base.Position[0]);
			double myPrec = precipitation.GetNumberValue(base.Position[1],base.Position[0])
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void GrowAn(double reduceFactor) 
		{
			{
			StemDiameter = StemDiameter + 0.04 / DaysWithLeaves * reduceFactor;
			StemHeight = StemHeight + (1 - StemHeight / 16) * RandomBetween(11,32) / DaysWithLeaves * reduceFactor
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void GrowCa(double reduceFactor) 
		{
			{
			StemDiameter = StemDiameter + 0.03 / DaysWithLeaves * reduceFactor;
			StemHeight = StemHeight + (1 - StemHeight / RandomBetween(3,10)) * 0.5 / DaysWithLeaves * reduceFactor
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void GrowSb(double reduceFactor) 
		{
			{
			StemDiameter = StemDiameter + 0.05 / DaysWithLeaves * reduceFactor;
			StemHeight = StemHeight + (1 - StemHeight / 18) * RandomBetween(50,150) / DaysWithLeaves * reduceFactor
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void GrowTt(double reduceFactor) 
		{
			{
			StemDiameter = StemDiameter + (0.04 / DaysWithLeaves) * reduceFactor;
			StemHeight = StemHeight + (1 - StemHeight / 10) * RandomBetween(1,150) / DaysWithLeaves * reduceFactor
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public double CalculateLivingWoodMass() 
		{
			{
			if(Equals(TreeType, AN)) {
							{
							return Mars.Components.Common.Math.Pow(E, (-3.55 + 3.06 * Mars.Components.Common.Math.Log(StemDiameter,E)
							))
							;}
					;} else {
							if(Equals(TreeType, CA)) {
											{
											return Mars.Components.Common.Math.Pow(E, (-3.27 + 2.8 * Mars.Components.Common.Math.Log(StemDiameter,E)
											))
											;}
									;} else {
											if(Equals(TreeType, SB)) {
															{
															return Mars.Components.Common.Math.Pow(E, (-3.35 + 2.62 * Mars.Components.Common.Math.Log(StemDiameter,E)
															))
															;}
													;} else {
															if(Equals(TreeType, TT)) {
																			{
																			return Mars.Components.Common.Math.Pow(E, (-3.39 + 2.827 * Mars.Components.Common.Math.Log(StemDiameter,E)
																			))
																			;}
																	;} 
														;}
										;}
						;}
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
			MyTreeStateType = TreeStateType.Death;
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
		public System.Tuple<double,double> GetRelativePosition(double originLatitude, double originLongitude, double bearing, double distanceInM) 
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
			double currentLivingWoodMass = CalculateLivingWoodMass();
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
			return result
			;}
			
			return default(double);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void SetTreeType(
		string treeType) {
			{
			TreeType = treeType
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
	,	string TreeType,
		double StemDiameter,
		double StemHeight
	,	double xcor = 0, double ycor = 0, int freq = 1)
		 : base (xcor, ycor)
		{
			_SavannaLayer = _layer;
			ID = _id;
			this.TreeType = TreeType;
			this.StemDiameter = StemDiameter;
			this.StemHeight = StemHeight;
			this._Precipitation = _Precipitation;
			this._Temperature = _Temperature;
			_SavannaLayer._TreeEnvironment.Insert(this);
			_register(_layer, this, freq);
			{
			StemHeight = CalculateHeigth()
			;}
		}
		
		public void Tick()
		{
			{
			UpdateTreeStateType();
			UpdatePhotosyntheseActive();
			if(Equals(MyTreeStateType, TreeStateType.Seedling)) {
							{
							Seedling()
							;}
					;} else {
							if(Equals(MyTreeStateType, TreeStateType.Juvenile)) {
											{
											Juvenile()
											;}
									;} else {
											if(Equals(MyTreeStateType, TreeStateType.Adult)) {
															{
															Adult()
															;}
													;} 
										;}
						;};
			ResetDamageType()
			;}
		}
		
		public System.Guid ID { get; }
		public bool Equals(Tree other) => Equals(ID, other.ID);
		public override int GetHashCode() => ID.GetHashCode();
	}
}
