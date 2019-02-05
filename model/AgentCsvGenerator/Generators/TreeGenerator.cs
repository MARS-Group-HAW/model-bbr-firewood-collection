using System;
using System.Collections.Generic;
using System.Text;
using AgentCsvGenerator.Config;

namespace AgentCsvGenerator.Generators
{
    public class Species
    {
        public string Name { get; }

        public float SeedlingsPerHa { get; }
        public float JuvenilesPerHa { get; }
        public float AdultPerHa { get; }

        public Species(string name, float seedlingsPerHa, float juvenilesPerHa, float adultPerHa)
        {
            Name = name;
            SeedlingsPerHa = seedlingsPerHa;
            JuvenilesPerHa = juvenilesPerHa;
            AdultPerHa = adultPerHa;
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

        public string Generate(List<Species> species)
        {
            var result = new StringBuilder();
            result.AppendLine("lat" + Delmiter + "lon" + Delmiter + "species" + Delmiter + "diameter");

            const int rasterMeterLength = 100; //raster in 1 ha = 100m x 100m

            var rasterCountLon = _area.WidthInMeter / rasterMeterLength;
            var rasterCountLat = _area.LengthInMeter / rasterMeterLength;

            for (var rasterLonIndex = 0; rasterLonIndex < rasterCountLon; rasterLonIndex++)
            {
                var offsetLon = _area.West + rasterLonIndex * 100 * _area.OneMeterLon;
                for (var rasterLatIndex = 0; rasterLatIndex < rasterCountLat; rasterLatIndex++)
                {
                    foreach (var aSpecies in species)
                    {
                        for (int i = 0; i < aSpecies.SeedlingsPerHa; i++)
                        {
                            result.AppendLine(GenerateTree(aSpecies, rasterLatIndex, offsetLon,
                                GenerateRandomDiameter(0, 0)));
                        }

                        for (int i = 0; i < aSpecies.JuvenilesPerHa; i++)
                        {
                            result.AppendLine(GenerateTree(aSpecies, rasterLatIndex, offsetLon,
                                GenerateRandomDiameter(1, 9)));
                        }

                        for (int i = 0; i < aSpecies.SeedlingsPerHa; i++)
                        {
                            result.AppendLine(GenerateTree(aSpecies, rasterLatIndex, offsetLon,
                                GenerateRandomDiameter(10, 100)));
                        }
                    }
                }
            }

            return result.ToString();
        }

        private string GenerateTree(Species type, int rasterLatIndex, double offsetLon,
            float diameter)
        {
            var offsetLat = _area.North + _area.LatOffsetWithoutAgentsFromNorth + rasterLatIndex * 100 * _area.OneMeterLat;
            var posLon = offsetLon + _area.OneMeterLon * Random.NextDouble() * 100;
            var posLat = offsetLat + _area.OneMeterLat * Random.NextDouble() * 100;

            return posLat + Delmiter + posLon + Delmiter + type.Name + Delmiter + diameter;
        }

        private static float GenerateRandomDiameter(int min, int max)
        {
            Console.WriteLine((float) (Random.Next(min, max) + Random.NextDouble()));
            return (float) (Random.Next(min, max) + Random.NextDouble());
        }
    }
}