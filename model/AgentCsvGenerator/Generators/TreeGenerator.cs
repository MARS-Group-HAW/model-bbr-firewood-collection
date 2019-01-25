using System;
using System.Collections.Generic;
using System.Text;
using AgentCsvGenerator.Config;

namespace AgentCsvGenerator.Generators
{
    public class TreeType
    {
        public string Name { get; }

        public float SeedlingsHa { get; }
        public float JuvenilesHa { get; }
        public float AdultHa { get; }

        public TreeType(string name, float seedlingsHa, float juvenilesHa, float adultHa)
        {
            Name = name;
            SeedlingsHa = seedlingsHa;
            JuvenilesHa = juvenilesHa;
            AdultHa = adultHa;
        }
    }

    public class TreeGenerator
    {
        private readonly AreaDefinition _area;
        private const string Delmiter = ";";

        private static readonly Random Random = new Random();

        public TreeGenerator(AreaDefinition area)
        {
            _area = area;
        }

        public string Generate(List<TreeType> types)
        {
            var result = new StringBuilder();
            result.AppendLine("lat" + Delmiter + "lon" + Delmiter + "type" + Delmiter + "diameter");

            const int rasterMeterLength = 100; //raster in 1 ha = 100m x 100m

            var rasterCountLon = _area.WidthInMeter / rasterMeterLength;
            var rasterCountLat = (_area.LengthInMeter - 1500) / rasterMeterLength;

            for (var rasterLonIndex = 0; rasterLonIndex < rasterCountLon; rasterLonIndex++)
            {
                var offsetLon = _area.West + rasterLonIndex * 100 * _area.OneMeterLon;
                for (var rasterLatIndex = 0; rasterLatIndex < rasterCountLat; rasterLatIndex++)
                {
                    foreach (var type in types)
                    {
                        for (int i = 0; i < type.SeedlingsHa; i++)
                        {
                            result.AppendLine(GenerateTree(type, rasterLatIndex, offsetLon,
                                GenerateRandomDiameter(0, 0)));
                        }

                        for (int i = 0; i < type.JuvenilesHa; i++)
                        {
                            result.AppendLine(GenerateTree(type, rasterLatIndex, offsetLon,
                                GenerateRandomDiameter(1, 9)));
                        }

                        for (int i = 0; i < type.SeedlingsHa; i++)
                        {
                            result.AppendLine(GenerateTree(type, rasterLatIndex, offsetLon,
                                GenerateRandomDiameter(10, 100)));
                        }
                    }
                }
            }

            return result.ToString();
        }

        private string GenerateTree(TreeType type, int rasterLatIndex, double offsetLon,
            float diameter)
        {
            var offsetLat = _area.North + _area.LatOffsetWithoutAgentsFromNorth + rasterLatIndex * 100 * _area.OneMeterLat;
            var posLon = offsetLon + _area.OneMeterLon * Random.NextDouble() * 100;
            var posLat = offsetLat + _area.OneMeterLat * Random.NextDouble() * 100;

            return posLat + Delmiter + posLon + Delmiter + type.Name + Delmiter + diameter;
        }

        private static float GenerateRandomDiameter(int min, int max)
        {
            return Random.Next(min, max) + Random.Next();
        }
    }
}