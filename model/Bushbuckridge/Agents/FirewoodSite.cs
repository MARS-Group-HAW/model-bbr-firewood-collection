using System;
using System.Collections.Generic;
using Mars.Components.Environments.SpatialAPI.Entities.Transformation;
using Mars.Interfaces.Agent;

namespace GOAP_Test.Agents
{
    public class FirewoodSite : IAgent
    {
        public Guid ID { get; }
        public Vector3 Position { get; }
        private List<TreeTypeStock> _trees = new List<TreeTypeStock>();

        public FirewoodSite(Dictionary<string, object> initData, Vector3 position)
        {
            Position = position;
            _trees.Add(new TreeTypeStock("Marula", 1650000, 1));
            //  _trees.Add(new TreeTypeStock("Arkacia", 2000000, 1));
            //  _trees.Add(new TreeTypeStock("Ca", 2000000, 1));
        }


        public void Tick()
        {
            //TODO LIFE systematik
            foreach (var tree in _trees)
            {
                tree.Tick();
            }
        }

        public int Harvest(int timeInH)
        {
            //TODO abhägngig von Zeit, Bestand (und Werkzeug)
            return _trees[new Random().Next(_trees.Count - 1)].Harvest(timeInH, false);
        }

        public override string ToString()
        {
            return "Site at " + Position;
        }
    }

    public class TreeTypeStock
    {
        public readonly string Type;
        private readonly double _growthRateFactorInPercent;
        private readonly double _initialAmount;

        public double AmountInKg { get; private set; }
        //TODO Totholz /ca 50%

        public TreeTypeStock(string type, double amountInKg, double growthRateFactorInPercent)
        {
            AmountInKg = amountInKg;
            _initialAmount = amountInKg;
            _growthRateFactorInPercent = growthRateFactorInPercent;
            Type = type;
        }

        public void Tick()
        {
            Regrowth();
        }

        private void Regrowth()
        {
            var before = AmountInKg;
            AmountInKg += _initialAmount * _growthRateFactorInPercent / 100;
            Console.WriteLine(before + " -> " + AmountInKg);
        }

        public int Harvest(int timeInH, bool axe)
        {
            const int harvestInKgPerH = 15;
            var amount = timeInH * harvestInKgPerH;
            AmountInKg -= amount;
            return amount;
        }
    }
}