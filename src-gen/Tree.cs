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
		private string __TreeType
			 = default(string);
		internal string TreeType { 
			get { return __TreeType; }
			set{
				if(__TreeType != value) __TreeType = value;
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
		private double __DeadwoodMass
			 = default(double);
		public double DeadwoodMass { 
			get { return __DeadwoodMass; }
			set{
				if(System.Math.Abs(__DeadwoodMass - value) > 0.0000001) __DeadwoodMass = value;
			}
		}
		private double __Growthrate
			 = 0.5;
		internal double Growthrate { 
			get { return __Growthrate; }
			set{
				if(System.Math.Abs(__Growthrate - value) > 0.0000001) __Growthrate = value;
			}
		}
		private double __SeedlingGrowthrate
			 = 0.5;
		internal double SeedlingGrowthrate { 
			get { return __SeedlingGrowthrate; }
			set{
				if(System.Math.Abs(__SeedlingGrowthrate - value) > 0.0000001) __SeedlingGrowthrate = value;
			}
		}
		private double __ResproutGrowthrate
			 = 0.5;
		internal double ResproutGrowthrate { 
			get { return __ResproutGrowthrate; }
			set{
				if(System.Math.Abs(__ResproutGrowthrate - value) > 0.0000001) __ResproutGrowthrate = value;
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
		public void UpdatePhotosyntheseActive() 
		{
			{
				if(Object.Equals(Mars.Components.Common.Time.Month((int) Mars.Core.SimulationManager.Entities.SimulationClock.CurrentStep)
				, 10) && Object.Equals(Mars.Components.Common.Time.Day((int) Mars.Core.SimulationManager.Entities.SimulationClock.CurrentStep)
				, 15)) {
								HasLeaves = true
						;} else {
								if(Object.Equals(Mars.Components.Common.Time.Month((int) Mars.Core.SimulationManager.Entities.SimulationClock.CurrentStep)
								, 6) && Object.Equals(Mars.Components.Common.Time.Day((int) Mars.Core.SimulationManager.Entities.SimulationClock.CurrentStep)
								, 15)) {
												HasLeaves = false
										;} 
							;};
			}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void Grow(double growthrate) 
		{
			{
				double mytemp = temperature.GetNumberValue(base.Position[1],base.Position[0]);
					double myPrec = precipitation.GetNumberValue(base.Position[1],base.Position[0]);
					StemDiameter = StemDiameter + StemDiameter * growthrate;
			}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void UpdateTreeStateType() 
		{
			{
				if(StemDiameter < 10) {
								{
									MyTreeStateType = TreeStateType.Juvenile;
								}
						;} else {
								{
									MyTreeStateType = TreeStateType.Adult;
								}
							;};
			}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public double Reduce(double growthrate, int min, int max) 
		{
			{
				return growthrate * (min + _Random.Next(max - min)) / 100;
			}
			return default(double);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void Die() 
		{
			{
				MyTreeStateType = TreeStateType.Death;	IsAlive = false;
			}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void Seedling() 
		{
			{
				if(!Object.ReferenceEquals(MyDamageType, DamageType.No)) {
								{
									Die();
								}
						;} else {
								if(HasLeaves) {
												{
													Grow(SeedlingGrowthrate);
												}
										;} 
							;};
			}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void Juvenile() 
		{
			{
				if(HasLeaves) {
								{
									if(!Object.ReferenceEquals(MyDamageType, DamageType.No)) {
													{
														Grow(ResproutGrowthrate);
													}
											;} else {
													{
														Grow(Growthrate);
													}
												;};
								}
						;} ;
			}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void Adult() 
		{
			{
				if(HasLeaves) {
								{
									if(Object.Equals(MyDamageType, DamageType.No)) {
													{
														Grow(Growthrate);
													}
											;} else {
													if(Object.Equals(MyDamageType, DamageType.Light)) {
																	{
																		Grow(Reduce(Growthrate,90,100));
																	}
															;} else {
																	if(Object.Equals(MyDamageType, DamageType.Moderate)) {
																					{
																						Grow(Reduce(Growthrate,70,90));
																					}
																			;} else {
																					if(Object.Equals(MyDamageType, DamageType.Heavy)) {
																									{
																										Grow(Reduce(Growthrate,40,70));
																									}
																							;} else {
																									if(Object.Equals(MyDamageType, DamageType.Extreme)) {
																													{
																														Grow(ResproutGrowthrate);
																													}
																											;} 
																								;}
																				;}
																;}
												;};
								}
						;} ;
			}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public double TakeDeadWoodMass(
		double mass) {
			{
				double result = default(double);;	if(mass < DeadwoodMass) {
								{
									result = mass;
								}
						;} else {
								{
									result = DeadwoodMass;
								}
							;};	DeadwoodMass = DeadwoodMass - result;	return result;
			}
			
			return default(double);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public double TakeLivingWoodMass(
		double mass) {
			{
				double result = default(double);;	if(mass < LivingWoodMass) {
								result = mass
						;} else {
								result = LivingWoodMass
							;};	LivingWoodMass = LivingWoodMass - result;	return result;
			}
			
			return default(double);;
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
		double StemDiameter
	,	double xcor = 0, double ycor = 0, int freq = 1)
		 : base (xcor, ycor)
		{
			_SavannaLayer = _layer;
			ID = _id;
			this.TreeType = TreeType;
			this.StemDiameter = StemDiameter;
			this._Precipitation = _Precipitation;
			this._Temperature = _Temperature;
			_SavannaLayer._TreeEnvironment.Insert(this);
			_register(_layer, this, freq);
		}
		
		public void Tick()
		{
			{
				UpdateTreeStateType();	UpdatePhotosyntheseActive();	if(Object.Equals(TreeStateType.Seedling, MyTreeStateType)) {
								{
									Seedling();
								}
						;} else {
								if(Object.Equals(TreeStateType.Juvenile, MyTreeStateType)) {
												{
													Juvenile();
												}
										;} else {
												if(Object.Equals(TreeStateType.Adult, MyTreeStateType)) {
																{
																	Adult();
																}
														;} 
											;}
							;};	MyDamageType = DamageType.No;	Console.WriteLine((int) Mars.Core.SimulationManager.Entities.SimulationClock.CurrentStep + " " + StemDiameter);;
			}
		}
		
		public System.Guid ID { get; }
		public bool Equals(Tree other) => Equals(ID, other.ID);
		public override int GetHashCode() => ID.GetHashCode();
	}
}
