using System;
using System.Collections.Generic;
using System.Text;
using AgentCsvGenerator.Config;

namespace AgentCsvGenerator.Generators
{
    public class TreeType
    {
        public string Name { get; }

        public float AmountPerHa { get; }
//        sb, ca, an, xx

        public TreeType(string name, float amountPerHa)
        {
            Name = name;
            AmountPerHa = amountPerHa;
        }
    }

    public class TreeGenerator
    {
        private readonly AreaDefinition _area;
        private static readonly string Delmiter = ";";

        private static readonly Random Random = new Random();

        public TreeGenerator(AreaDefinition area)
        {
            _area = area;
        }

        public string Generate(List<TreeType> types)
        {
            var result = new StringBuilder();
            result.AppendLine("lat" + Delmiter + "lon" + Delmiter + "type" + Delmiter + "mass");

            var latDistanceToHouseholds = 1500 * _area.OneMeterLat;
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
                        for (var i = 0; i < type.AmountPerHa; i++)
                        {
                            result.AppendLine(GenerateTree(type, latDistanceToHouseholds, rasterLatIndex, offsetLon));
                        }
                    }
                }
            }

            return result.ToString();
        }

        private string GenerateTree(TreeType type, double latDistanceToHouseholds, int rasterLatIndex, double offsetLon)
        {
            //TODO noch prüfen, ob was in der nähe, sonst neu
            var offsetLat = _area.North + latDistanceToHouseholds + rasterLatIndex * 100 * _area.OneMeterLat;
            var posLon = offsetLon + _area.OneMeterLon * Random.NextDouble() * 100;
            var posLat = offsetLat + _area.OneMeterLat * Random.NextDouble() * 100;

            return posLat + Delmiter + posLon + Delmiter + type.Name + Delmiter + GenerateMass();
        }

        private static float GenerateMass()
        {
            var category = Random.NextDouble();
            //84% seedlings dazu (so dass am Ende 84% Seedlings sind)
            if (category < 0.84) // seedling
            {
                return Random.Next();
            }

            if (category > 0.98) // adult
            {
                return Random.Next(10, 20) + Random.Next();
            }

            //juvenil
            return Random.Next(0, 9) + Random.Next();
        }
    }
}