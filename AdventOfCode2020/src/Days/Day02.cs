using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days
{
    [Day(2020, 2)]
    public class Day02 : BaseDay
    {
        public override string PartOne(string input)
        {
            int naiveResult = PartOne_Naive(input);
            int imprvedResult = PartOne_Improve(input);

            if(naiveResult == imprvedResult)
                return naiveResult.ToString();
            else
                return "Failed to find the answer!";
        }

        private static int PartOne_Naive(string input)
        {
            int validEntries = 0;
            string[] entries = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < entries.Length; ++i)
            {
                string[] rules = entries[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Range legalRange = CreateRange(rules[0]);
                int count = 0;
                for (int j = 0; j < rules[2].Length; ++j)
                {
                    if (rules[2][j] == rules[1][0])
                        ++count;
                }
                if (legalRange.Within(count))
                    ++validEntries;
            }
            return validEntries;
        }

        private static int PartOne_Improve(string input)
        {
            Regex regex = new Regex(@"\d \c");
            string[] entries = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            for(int i = 0; i < entries.Length; ++i)
            {

            }

            return 0;
        }

        private static Range CreateRange(string input)
        {
            string[] values = input.Split('-', StringSplitOptions.RemoveEmptyEntries);
            return new Range(int.Parse(values[0]), int.Parse(values[1]));
        }

        public override string PartTwo(string input)
        {
            int validEntries = 0;
            string[] entries = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < entries.Length; ++i)
            {
                string[] rules = entries[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Range legalRange = CreateRange(rules[0]);

                if (legalRange.Max >= rules[2].Length || legalRange.Min >= rules[2].Length)
                    continue;

                if (rules[2][legalRange.Min] == rules[1][0] || rules[2][legalRange.Max] == rules[1][0])
                {
                    if (rules[2][legalRange.Min] == rules[1][0] && rules[2][legalRange.Max] == rules[1][0])
                    {

                    }
                    else
                    {
                        ++validEntries;
                    }
                }  
            }
            return validEntries.ToString();
        }
    }

    public struct Range
    {
        private readonly int min;
        private readonly int max;

        public int Min => min;
        public int Max => max;

        public bool Within(int x) => x >= min && x <= max;

        public Range(int min, int max)
        {
            this.min = min;
            this.max = max;
        }
    };
}
