using System;
using System.Collections.Generic;
using System.IO;
using AgentCsvGenerator.Config;
using AgentCsvGenerator.Generators;

namespace AgentCsvGenerator
{
//    http://www.hamstermap.com/quickmap.php
//    -24.8690,31.1944
//    -24.8239,31.2436
    internal static class AgentCsvGenerator
    {
        private static void Main()
        {
            var area = new AreaDefinition
            {
                // 5km x 5km (2500ha)
                West = 31.194,
                East = 31.244,
                North = -24.824,
                South = -24.870
            };

            var households = new HouseholdGenerator(area).Generate(684);
            SaveContentInFile(Path.Combine("..", "..", "model_input", "household.csv"), households);

            var treeTypes = new List<TreeType>();
            treeTypes.Add(new TreeType("sb", 3));
            treeTypes.Add(new TreeType("ca", 17));
            treeTypes.Add(new TreeType("an", 25));
//            treeTypes.Add(new TreeType("xx", 2250));
            //TODO plus 4ten Baum, der die 98% der restlichen Bäume repräsentiert
            
            var trees = new TreeGenerator(area).Generate(treeTypes);
            SaveContentInFile(Path.Combine("..", "..", "model_input", "tree.csv"), trees);

            Console.WriteLine("Files are generated :)");
        }

        private static void SaveContentInFile(string path, string content)
        {
            File.WriteAllText(path, content);
        }
    }
}