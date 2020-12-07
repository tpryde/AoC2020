using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    [Day(2020, 7)]
    public class Day07 : BaseDay
    {
        public const string GoldenBagType = "shiny gold";

        private static string[] _lines;
        private static Dictionary<string, Bag> _knownBags = new Dictionary<string, Bag>();
        public override string PartOne(string input)
        {
            _lines = input.Split(Environment.NewLine, StringSplitOptions.None);

            foreach(string line in _lines)
            {
                string[] bags = line.Split("contain", StringSplitOptions.RemoveEmptyEntries);
                string[] words = bags[0].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Bag newBag = new Bag()
                {
                    Type = words[0] + " " + words[1],
                    CanHoldTypes = new Dictionary<string, uint>()
                };

                if (bags[1] != " no other bags.")
                {
                    bags = bags[1].Split(",", StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < bags.Length; ++i)
                    {
                        words = bags[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        for(int j = 0; j < words.Length; j+=4)
                        {
                            int count = int.Parse(words[j]);
                            string type = words[j+1] + " " + words[j+2];

                            newBag.CanHoldTypes[type] = (uint)count;
                        }
                    }
                }
                _knownBags[newBag.Type] = newBag;
            }

            string retVal = "";
            int goldenBagHolderCount = 0;
            foreach(Bag knownBag in _knownBags.Values)
            {
                if(knownBag.Type == GoldenBagType) continue;

                bool canHoldType = false;
                foreach(string type in knownBag.CanHoldTypes.Keys)
                {
                    if (type == GoldenBagType) { canHoldType = true; }
                    if (CanHoldGoldenBag(type)) { canHoldType = true; }
                    if (canHoldType) break;
                }

                if(canHoldType)
                {
                    ++goldenBagHolderCount;
                    retVal += knownBag.Type + " ";
                }
            }
            return goldenBagHolderCount.ToString();
            // return "Failed to find the answer";
        }

        public override string PartTwo(string input)
        {
             _lines = input.Split(Environment.NewLine, StringSplitOptions.None);

            foreach(string line in _lines)
            {
                string[] bags = line.Split("contain", StringSplitOptions.RemoveEmptyEntries);
                string[] words = bags[0].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Bag newBag = new Bag()
                {
                    Type = words[0] + " " + words[1],
                    CanHoldTypes = new Dictionary<string, uint>()
                };

                if (bags[1] != " no other bags.")
                {
                    bags = bags[1].Split(",", StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < bags.Length; ++i)
                    {
                        words = bags[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        for(int j = 0; j < words.Length; j+=4)
                        {
                            uint count = (uint)int.Parse(words[j]);
                            string type = words[j+1] + " " + words[j+2];

                            newBag.CanHoldTypes[type] = count;
                        }
                    }
                }
                _knownBags[newBag.Type] = newBag;
            }

            string retVal = "";
            int goldenBagHolderCount = 0;
            foreach(Bag knownBag in _knownBags.Values)
            {
                if(knownBag.Type == GoldenBagType) continue;

                bool canHoldType = false;
                foreach(string type in knownBag.CanHoldTypes.Keys)
                {
                    if (type == GoldenBagType) { canHoldType = true; }
                    if (CanHoldGoldenBag(type)) { canHoldType = true; }
                    if (canHoldType) break;
                }

                if(canHoldType)
                {
                    ++goldenBagHolderCount;
                    retVal += knownBag.Type + " ";
                }
            }

            uint bagCount = 0;
            foreach ((string type, uint count) in _knownBags[GoldenBagType].CanHoldTypes)
            {
                bagCount += BagCount(type) * count;
            }

            return bagCount.ToString();
            // return "Failed to find the answer";
        }

        private static uint BagCount(string type)
        {
            uint bagCount = 1;
            foreach((string subType, uint count) in _knownBags[type].CanHoldTypes)
            {
                bagCount += BagCount(subType) * count;
            }
            return bagCount;
        }

        private static bool CanHoldGoldenBag(string type)
        {
            if (_knownBags.TryGetValue(type, out Bag bag))
            {
                foreach(string subtype in bag.CanHoldTypes.Keys)
                {
                    if (subtype == GoldenBagType) return true;

                    if (CanHoldGoldenBag(subtype)) return true;
                }
            }
            return false;
        }
    }

    public struct Bag
    {
        public string Type;
        public Dictionary<string, uint> CanHoldTypes;
    };
}
