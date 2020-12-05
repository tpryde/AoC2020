using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    [Day(2020, 3)]
    public class Day03 : BaseDay
    {
        public override string PartOne(string input)
        {
            _lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            int treeCount = 0;

            for (int i = 0; i < _lines.Length; ++i)
            {
                if(_lines[i][i * 3 % _lines[0].Length] == '#')
                {
                    ++treeCount;
                }
            }
            return treeCount.ToString();
        }

        public override string PartTwo(string input)
        {
            uint result = PartTwo_Naive(input);
            if (result == PartTwo_Improved(input))
                return result.ToString();

            return "Failed to find the answer!";
        }

        private static string[] _lines;
        private static uint GetTreeCount(int run, int fall)
        {
            uint treeCount = 0;
            for (int i = 0; i < _lines.Length; ++i)
            {
                if (i * fall > _lines.Length) break;
                if (_lines[i * fall][i * run % _lines[0].Length] == '#')
                {
                    ++treeCount;
                }
            }
            return treeCount;
        }

        public uint PartTwo_Naive(string input)
        {
            _lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            const int PATH_COUNT = 5;
            int[] run = new int[] { 1, 3, 5, 7, 1 };
            int[] fall = new int[] { 1, 1, 1, 1, 2 };

            uint total = 1;
            for (int i = 0; i < PATH_COUNT; ++i)
            {
                total *= GetTreeCount(run[i], fall[i]);
            }
            return total;
        }
        public uint PartTwo_Improved(string input)
        {
            _lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            (int run, int fall)[] slopes = new (int run, int fall)[] { (1, 1), (3, 1), (5, 1), (7, 1), (1, 2), };
            return slopes.Aggregate(1u, (prod, slope) => prod * GetTreeCount(slope.run, slope.fall));
        }
    }
}
