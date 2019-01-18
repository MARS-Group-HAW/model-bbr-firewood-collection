namespace AgentCsvGenerator.Config
{
    public class AreaDefinition
    {
        public double West = 31.194;
        public double East = 31.244;
        public double North = -24.824;
        public double South = -24.870;

        public double WidthInMeter = 5000;
        public double LengthInMeter = 5000;

        public double OneMeterLat => (South - North) / LengthInMeter;

        public double OneMeterLon => (East - West) / WidthInMeter ;
    }
}