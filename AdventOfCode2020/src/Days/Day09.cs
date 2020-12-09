using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    [Day(2020, 9)]
    public class Day09 : BaseDay
    {
        private const int LENGTH = 25;

        private string[] _lines;
        public override string PartOne(string input)
        {
            _lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            for(int i = LENGTH; i < _lines.Length; ++i)
            {
                ulong targetValue = ulong.Parse(_lines[i]);
                if(!FindPair(targetValue, i))
                {
                    return targetValue.ToString();
                }
            }
            return "Failed to find the answer";
        }

        public override string PartTwo(string input)
        {
            // 57195069
            _lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            ulong targetValue = 57195069;
            for (int lIndex = 0; lIndex < _lines.Length; ++lIndex)
            {
                ulong min = ulong.MaxValue;
                ulong max = 0;

                ulong lValue = ulong.Parse(_lines[lIndex]);
                ulong runningTotal = lValue;
                for (int rIndex = lIndex+1; rIndex < _lines.Length; ++rIndex)
                {
                    ulong rValue = ulong.Parse(_lines[rIndex]);
                    runningTotal += rValue;

                    if (lValue < min) min = lValue;
                    if (rValue < min) min = rValue;

                    if (lValue > max) max = lValue;
                    if (rValue > max) max = rValue;

                    if (runningTotal == targetValue) return (min + max).ToString();
                }
            }
            return "Failed to find the answer";
        }

        private bool FindPair(ulong targetValue, int i)
        {
            string[] subString = new string[LENGTH];
            Array.Copy(_lines, i - LENGTH, subString, 0, LENGTH);

            for (int lIndex = 0; lIndex < subString.Length; ++lIndex)
            {
                ulong lValue = ulong.Parse(subString[lIndex]);
                for (int rIndex = 0; rIndex < subString.Length; ++rIndex)
                {
                    if (lIndex == rIndex) continue;

                    ulong rValue = ulong.Parse(subString[rIndex]);
                    if (lValue + rValue == targetValue) return true;
                }
            }
            return false;
        }
    }
}
