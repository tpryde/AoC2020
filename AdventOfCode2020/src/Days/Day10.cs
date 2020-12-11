using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    [Day(2020, 10)]
    public class Day10 : BaseDay
    {
        private string[] _lines;
        public override string PartOne(string input)
        {
            _lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            GetInputValueArray(out int[] inputValues);
            Array.Sort(inputValues);

            int oneJoltDifferenceCount = 1;
            int threeJoltDifferenceCount = 1;

            int prvValue = inputValues[0];
            for(int i = 1; i < inputValues.Length; ++i)
            {
                int diff = inputValues[i] - prvValue;

                if (diff == 1) ++oneJoltDifferenceCount;
                else if (diff == 3) ++threeJoltDifferenceCount;

                prvValue = inputValues[i];
            }

            return (oneJoltDifferenceCount * threeJoltDifferenceCount).ToString();
        }

        public override string PartTwo(string input)
        {
            _lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            GetInputValueArray(out int[] inputValues);
            Array.Sort(inputValues);

            return GetPossibleArrangementCount(in inputValues).ToString();
            // return "Failed to find the answer";
        }

        private void GetInputValueArray(out int[] inputValues)
        {
            inputValues = new int[_lines.Length];
            for (int i = 0; i < inputValues.Length; ++i)
            {
                inputValues[i] = int.Parse(_lines[i]);
            }
        }

        private static ulong GetPossibleArrangementCount(in int[] inputValues)
        {
            ulong[] permuteMap = new ulong[]{1, 1, 1, 2, 4, 7, 13};

            int currentLength = 1;
            ulong totalPossibleArrangements = 1;

            for (int i = 0; i < inputValues.Length-1; ++i)
            {
                ++currentLength;
                int diff = inputValues[i+1] - inputValues[i];

                if (diff == 3 || i == inputValues.Length - 2)
                {
                    if (i == inputValues.Length - 2) ++currentLength;

                    totalPossibleArrangements *= permuteMap[currentLength];
                    currentLength = 0;
                }
            }
            return totalPossibleArrangements;
        }
    }
}
