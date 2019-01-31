﻿using System.Text;
using AgentCsvGenerator.Config;

namespace AgentCsvGenerator.Generators
{
    public class HouseholdGenerator
    {
        private readonly AreaDefinition _area;
        private static readonly string Delmiter = ";";

        public HouseholdGenerator(AreaDefinition area)
        {
            _area = area;
        }

        public string Generate(int householdCount)
        {
            var result = new StringBuilder();
            result.AppendLine("lat" + Delmiter + "lon");

            var lastPositionLat = _area.North;
            var lastPositionLon = _area.West;

            var stepLon = (_area.East - _area.West) / (householdCount / 10);

            for (var i = 0; i < householdCount; i++)
            {
                result.AppendLine(lastPositionLat + Delmiter + lastPositionLon);
                lastPositionLon += stepLon;
                if (lastPositionLon > _area.East)
                {
                    lastPositionLon = _area.West;
                    lastPositionLat += _area.OneMeterLat * 30;
                }
            }

            return result.ToString();
        }
    }
}