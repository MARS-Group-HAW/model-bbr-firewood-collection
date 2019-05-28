using System;
using System.Collections.Generic;
using System.Dynamic;
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
        public int MinAdultDiameter { get; }

        public Species(string name, float seedlingsPerHa, float juvenilesPerHa, float adultPerHa, int minAdultDiameter)
        {
            Name = name;
            SeedlingsPerHa = seedlingsPerHa;
            JuvenilesPerHa = juvenilesPerHa;
            AdultPerHa = adultPerHa;
            MinAdultDiameter = minAdultDiameter;
        }
    }

    public class TreeGenerator
    {
        private readonly AreaDefinition _area;
        private const string Delimiter = ";";

        private static readonly Random Random = new Random();

        public TreeGenerator(AreaDefinition area)
        {
            _area = area;
        }

        public string Generate(List<Species> species, Func<int, int, bool> isEmptyRaster = null, Func<int, int, double> evaluateFilterPercentage = null)
        {
            var result = new StringBuilder();
            result.AppendLine(string.Join(Delimiter, "lat", "lon", "species", "diameter", "raster"));

            const int rasterMeterLength = 100; //raster in 1 ha = 100m x 100m

            var rasterCountLon = _area.WidthInMeter / rasterMeterLength;
            var rasterCountLat = _area.LengthInMeter / rasterMeterLength;

            for (var rasterLonIndex = 0; rasterLonIndex < rasterCountLon; rasterLonIndex++)
            {
                var offsetLon = _area.West + rasterLonIndex * 100 * _area.OneMeterLon;
                for (var rasterLatIndex = 0; rasterLatIndex < rasterCountLat; rasterLatIndex++)
                {
                    if (isEmptyRaster != null && isEmptyRaster.Invoke(rasterLatIndex, rasterLonIndex)) continue;
                    var filterPercentage = evaluateFilterPercentage?.Invoke(rasterLatIndex, rasterLonIndex) ?? 1.0;
                    var offsetLat = _area.North + rasterLatIndex * 100 * _area.OneMeterLat;
                    // Console.WriteLine(GenRasterId(rasterLatIndex,rasterLonIndex));
                    foreach (var aSpecies in species)
                    {
                        for (var i = 0; i < aSpecies.SeedlingsPerHa; i++)
                        {
                            if (IsNotFiltered(filterPercentage))
                            {
                                result.AppendLine(GenerateTree(aSpecies, rasterLatIndex, rasterLonIndex, offsetLat,
                                    offsetLon, GenerateRandomDiameter(0, 0)));
                            }
                        }

                        for (var i = 0; i < aSpecies.JuvenilesPerHa; i++)
                        {
                            if (IsNotFiltered(filterPercentage))
                            {
                                result.AppendLine(GenerateTree(aSpecies, rasterLatIndex, rasterLonIndex, offsetLat,
                                    offsetLon, GenerateRandomDiameter(1, 6)));
                            }
                        }

                        for (var i = 0; i < aSpecies.AdultPerHa; i++)
                        {
                            if (IsNotFiltered(filterPercentage))
                            {
                                result.AppendLine(GenerateTree(aSpecies, rasterLatIndex, rasterLonIndex, offsetLat,
                                    offsetLon,
                                    GenerateRandomDiameter(aSpecies.MinAdultDiameter, aSpecies.MinAdultDiameter + 5)));
                            }
                        }
                    }
                }
            }

            return result.ToString();
        }

        private bool IsNotFiltered(double filterPercentage)
        {
            return Random.NextDouble() <= filterPercentage;
        }

        private string GenerateTree(Species type, int rasterLatIndex, int rasterLonIndex, double offsetLat,
            double offsetLon, float diameter)
        {
            var posLon = offsetLon + _area.OneMeterLon * Random.NextDouble() * 100;
            var posLat = offsetLat + _area.OneMeterLat * Random.NextDouble() * 100;
            var raster = GenRasterId(rasterLatIndex, rasterLonIndex);

            return string.Join(Delimiter, posLat, posLon, type.Name, diameter, raster);
        }

        private static string GenRasterId(int rasterLatIndex, int rasterLonIndex)
        {
            return rasterLonIndex.ToString("D2") + "_" + rasterLatIndex.ToString("D2");
        }

        private static float GenerateRandomDiameter(int min, int max)
        {
            return (float) (Random.Next(min, max) + Random.NextDouble());
        }
    }
}