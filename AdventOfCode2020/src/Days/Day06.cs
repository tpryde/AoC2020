using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    [Day(2020, 6)]
    public class Day06 : BaseDay
    {
        private static string[] _lines;

        public override string PartOne(string input)
        {
            _lines = input.Split(Environment.NewLine, StringSplitOptions.None);

            int totalAnswers = 0;

            List<char> groupAnswers = new List<char>();
            foreach(string line in _lines)
            {
                if (string.IsNullOrEmpty(line) || line.Length == 0)
                {
                    totalAnswers += groupAnswers.Count;
                    groupAnswers.Clear();

                    continue;
                }

                for (int i = 0; i < line.Length; ++i)
                {
                    if (groupAnswers.Contains(line[i]))
                        continue;

                    groupAnswers.Add(line[i]);
                }
            }

            totalAnswers += groupAnswers.Count;
            return totalAnswers.ToString();
            // return "Failed to find the answer";
        }

        public override string PartTwo(string input)
        {
            _lines = input.Split(Environment.NewLine, StringSplitOptions.None);

            int naiveResult = PartTwo_Naive();
            return naiveResult.ToString();
            // return "Failed to find the answer";
        }

        private static int PartTwo_Naive()
        {
            int totalAnswers = 0;

            int groupSize = 0;
            Dictionary<char, int> groupAnswers = new Dictionary<char, int>();
            foreach (string line in _lines)
            {
                if (string.IsNullOrEmpty(line) || line.Length == 0)
                {
                    foreach ((char key, int count) in groupAnswers)
                    {
                        if (count == groupSize) totalAnswers += 1;
                    }

                    groupAnswers.Clear();
                    groupSize = 0;

                    continue;
                }

                for (int i = 0; i < line.Length; ++i)
                {
                    if (groupAnswers.ContainsKey(line[i])) groupAnswers[line[i]] += 1;
                    else groupAnswers.Add(line[i], 1);
                }
                ++groupSize;
            }

            foreach ((char key, int count) in groupAnswers)
            {
                if (count == groupSize) totalAnswers += 1;
            }
            return totalAnswers;
        }
    }
}
