namespace KruegerNationalPark {
	public class ElephantMaps {
		private static readonly Mars.Common.Logging.ILogger _Logger = 
					Mars.Common.Logging.LoggerFactory.GetLogger(typeof(ElephantMaps));
		private static readonly Mars.Components.Common.Random _Random = new Mars.Components.Common.Random();
		private static Mars.Components.Common.MarsMap<string,KruegerNationalPark.ElephantType> __TypeMap
			 = (new Mars.Components.Common.MarsMap<string,KruegerNationalPark.ElephantType>() { new Mars.Components.Common.KeyValue<string, KruegerNationalPark.ElephantType>("ELEPHANT_COW", ElephantType.ELEPHANT_COW),new Mars.Components.Common.KeyValue<string, KruegerNationalPark.ElephantType>("ELEPHANT_BULL", ElephantType.ELEPHANT_BULL),new Mars.Components.Common.KeyValue<string, KruegerNationalPark.ElephantType>("ELEPHANT_CALF", ElephantType.ELEPHANT_CALF),new Mars.Components.Common.KeyValue<string, KruegerNationalPark.ElephantType>("ELEPHANT_NEWBORN", ElephantType.ELEPHANT_NEWBORN) });
		internal static Mars.Components.Common.MarsMap<string,KruegerNationalPark.ElephantType> TypeMap { 
			get { return __TypeMap; }
			set{
				if(__TypeMap != value) __TypeMap = value;
			}
		}
		private static Mars.Components.Common.MarsMap<KruegerNationalPark.ElephantLifePeriodType,double> __HydrationMap
			 = (new Mars.Components.Common.MarsMap<KruegerNationalPark.ElephantLifePeriodType,double>() { new Mars.Components.Common.KeyValue<KruegerNationalPark.ElephantLifePeriodType, double>(ElephantLifePeriodType.CALF, 140.0),new Mars.Components.Common.KeyValue<KruegerNationalPark.ElephantLifePeriodType, double>(ElephantLifePeriodType.ADOLESCENT, 190.0),new Mars.Components.Common.KeyValue<KruegerNationalPark.ElephantLifePeriodType, double>(ElephantLifePeriodType.ADULT, 200.0) });
		internal static Mars.Components.Common.MarsMap<KruegerNationalPark.ElephantLifePeriodType,double> HydrationMap { 
			get { return __HydrationMap; }
			set{
				if(__HydrationMap != value) __HydrationMap = value;
			}
		}
		private static Mars.Components.Common.MarsMap<KruegerNationalPark.ElephantLifePeriodType,double> __SatietyIntakeHourly
			 = (new Mars.Components.Common.MarsMap<KruegerNationalPark.ElephantLifePeriodType,double>() { new Mars.Components.Common.KeyValue<KruegerNationalPark.ElephantLifePeriodType, double>(ElephantLifePeriodType.CALF, 0.009444),new Mars.Components.Common.KeyValue<KruegerNationalPark.ElephantLifePeriodType, double>(ElephantLifePeriodType.ADOLESCENT, 0.01167),new Mars.Components.Common.KeyValue<KruegerNationalPark.ElephantLifePeriodType, double>(ElephantLifePeriodType.ADULT, 0.01167) });
		internal static Mars.Components.Common.MarsMap<KruegerNationalPark.ElephantLifePeriodType,double> SatietyIntakeHourly { 
			get { return __SatietyIntakeHourly; }
			set{
				if(__SatietyIntakeHourly != value) __SatietyIntakeHourly = value;
			}
		}
	}
}
