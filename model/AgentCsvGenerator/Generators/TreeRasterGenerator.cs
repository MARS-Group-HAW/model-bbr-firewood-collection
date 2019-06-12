using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using AgentCsvGenerator.Config;

namespace AgentCsvGenerator.Generators
{
    public class TreeRasterGenerator
    {
        private readonly AreaDefinition _area;

        public TreeRasterGenerator(AreaDefinition area)
        {
            _area = area;
        }

        public string Generate(Func<int, int, bool> isEmptyRaster = null)
        {
            var result = new StringBuilder();

            const int rasterMeterLength = 100; //raster in 1 ha = 100m x 100m

            var rasterCountLon = _area.WidthInMeter / rasterMeterLength;
            var rasterCountLat = _area.LengthInMeter / rasterMeterLength;

            var cellsize = Math.Abs(_area.East - _area.West) / rasterCountLat;

            result.AppendLine("ncols " + rasterCountLon);
            result.AppendLine("nrows " + rasterCountLat);
            result.AppendLine("xllcorner " + _area.West);
            result.AppendLine("yllcorner " + _area.South);
            result.AppendLine("cellsize " + cellsize);
            result.AppendLine("nodata_value -9999");

            for (var rasterLatIndex = 0; rasterLatIndex < rasterCountLat; rasterLatIndex++)
            {
                var rows = new List<string>();
                for (var rasterLonIndex = 0; rasterLonIndex < rasterCountLon; rasterLonIndex++)
                {
                    if (isEmptyRaster != null && isEmptyRaster.Invoke(rasterLatIndex, rasterLonIndex))
                    {
                        rows.Add("-1");
                    }
                    else
                    {
                        rows.Add(GenRasterId(rasterLatIndex, rasterLonIndex));
                    }
                }
                result.AppendLine(string.Join(" ",rows));
            }

            return result.ToString();
        }
        
        private static string GenRasterId(int rasterLatIndex, int rasterLonIndex)
        {
            return 1 + rasterLonIndex.ToString("D2") + rasterLatIndex.ToString("D2");
        }
    }
}