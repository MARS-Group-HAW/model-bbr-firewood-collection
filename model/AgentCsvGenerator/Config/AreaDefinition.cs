namespace AgentCsvGenerator.Config
{
    public class AreaDefinition
    {
        public readonly double West;
        public readonly  double East;
        public readonly  double North;
        public readonly  double South;

        public readonly  double WidthInMeter;
        public readonly  double LengthInMeter;

        public readonly double LatOffsetWithoutAgentsFromNorth;

        public double OneMeterLat => (South - North) / LengthInMeter;

        public double OneMeterLon => (East - West) / WidthInMeter ;

        public AreaDefinition(double west, double east, double north, double south, double widthInMeter,
            double lengthInMeter, double offsetWithoutAgentsFromNorthInM)
        {
            West = west;
            East = east;
            North = north;
            South = south;
            WidthInMeter = widthInMeter;
            LengthInMeter = lengthInMeter;
            LatOffsetWithoutAgentsFromNorth = offsetWithoutAgentsFromNorthInM * OneMeterLat;;
        }
    }
}