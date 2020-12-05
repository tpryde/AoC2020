using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    [Day(2020, 1)]
    public class Day01 : BaseDay
    {
        public override string PartOne(string input)
        {
            // The correct answer is: 605364

            int naiveResult = PartOne_Naive(input);
            int improvedResult = PartOne_Improved(input);
            if (naiveResult == improvedResult)
                return naiveResult.ToString();
            
            return "Failed to find the answer!";
        }
        private static int PartOne_Naive(string input)
        {
            string[] entries = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            int[] entryIntegers = new int[entries.Length];

            for (int i = 0; i < entryIntegers.Length; ++i)
            {
                entryIntegers[i] = int.Parse(entries[i]);
                if (i == 0) continue;

                for (int j = 0; j < i; ++j)
                {
                    if (entryIntegers[j] + entryIntegers[i] == 2020)
                    {
                        return entryIntegers[j] * entryIntegers[i];
                    }
                }
            }
            return 0;
        }
        private static int PartOne_Improved(string input)
        {
            const int TARGET = 2020;

            var entries = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(e => int.Parse(e)).OrderBy(e => e);

            int lIndex = 0;
            int rIndex = entries.Count() - 1;

            while(rIndex > lIndex)
            {
                int remainingValue = TARGET - entries.ElementAt(lIndex);
                if (remainingValue == entries.ElementAt(rIndex)) // Is the Remaining Value equal to the upper bound element?
                {
                    return (TARGET - remainingValue) * remainingValue;
                }

                if (remainingValue > entries.ElementAt(rIndex - 1)) // Does lower the upper bound remove the potential of finding the next remaining value?
                {
                    ++lIndex; // Increase lower bound
                }
                else
                {
                    --rIndex; // Decrease upper bound
                }
            }


            

            return 0;
        }


        public override string PartTwo(string input)
        {
            // The correct answer is: 128397680

            string[] entries = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            int[] entryIntegers = new int[entries.Length];

            for (int i = 0; i < entryIntegers.Length; ++i)
            {
                entryIntegers[i] = int.Parse(entries[i]);
                if (i <= 1) continue;

                for (int j = 0; j < i; ++j)
                {
                    for(int k = 0; k < j; ++k)
                    {
                        if (entryIntegers[k] + entryIntegers[j] + entryIntegers[i] == 2020)
                        {
                            return (entryIntegers[k] * entryIntegers[j] * entryIntegers[i]).ToString();
                        }
                    }
                }
            }
            return "Failed to find the answer!";
        }
    }
}
