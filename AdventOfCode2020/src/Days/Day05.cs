using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    [Day(2020, 5)]
    public class Day05 : BaseDay
    {
        private static string[] _lines;

        public override string PartOne(string input)
        {
            _lines = input.Split(Environment.NewLine, StringSplitOptions.None);

            int row = 0;
            int column = 0;
            int highestID = 0;
            for(int i = 0; i < _lines.Length; ++i)
            {
                row = 0;
                column = 0;

                int maxBound = 127;
                int minBound = 0;

                int range() => maxBound - minBound;

                foreach (char element in _lines[i][0..^3])
                {
                    int diff = (int)Math.Round((range() * 0.5f), MidpointRounding.AwayFromZero);

                    if (element == 'B')
                    {
                        minBound += diff;
                    }
                    else // Back
                    {
                        maxBound -= diff;
                    }
                }

                if (minBound != maxBound) return "Failed to find the ROW! " + minBound + " " + maxBound;
                else
                {
                    row = minBound;
                }

                maxBound = 7;
                minBound = 0;

                foreach (char element in _lines[i][^3.._lines[i].Length])
                {
                    int diff = (int)Math.Round((range() * 0.5f), MidpointRounding.AwayFromZero);

                    if (element == 'R')
                    {
                        minBound += diff;
                    }
                    else // Left
                    {
                        maxBound -= diff;
                    }
                }

                if (minBound != maxBound) return "Failed to find the Column!" + minBound + " " + maxBound;
                else
                {
                    column = minBound;
                }

                int ID = row * 8 + column;
                if (highestID < ID)
                    highestID = ID;
            }
            return highestID.ToString() + " ROW: " + row + " COLUMN: " + column;
        }

        public override string PartTwo(string input)
        {
            _lines = input.Split(Environment.NewLine, StringSplitOptions.None);

            int naiveResult = PartTwo_Naive();
            int improvedResult = PartTwo_Improved();

            if (naiveResult != improvedResult)
                return "Failed to find the answer";

            return naiveResult.ToString();
        }

        private static int PartTwo_Naive()
        {
            List<int> IDS = new List<int>();

            int row = 0;
            int column = 0;
            int highestID = 0;
            for (int i = 0; i < _lines.Length; ++i)
            {
                row = 0;
                column = 0;

                int maxBound = 127;
                int minBound = 0;

                int range() => maxBound - minBound;

                foreach (char element in _lines[i][0..^3])
                {
                    int diff = (int)Math.Round((range() * 0.5f), MidpointRounding.AwayFromZero);

                    if (element == 'B')
                    {
                        minBound += diff;
                    }
                    else // Back
                    {
                        maxBound -= diff;
                    }
                }

                if (minBound != maxBound) return -1;
                else
                {
                    row = minBound;
                }

                maxBound = 7;
                minBound = 0;

                foreach (char element in _lines[i][^3.._lines[i].Length])
                {
                    int diff = (int)Math.Round((range() * 0.5f), MidpointRounding.AwayFromZero);

                    if (element == 'R')
                    {
                        minBound += diff;
                    }
                    else // Left
                    {
                        maxBound -= diff;
                    }
                }

                if (minBound != maxBound) return -2;
                else
                {
                    column = minBound;
                }

                int ID = row * 8 + column;
                if (highestID < ID)
                    highestID = ID;

                if (row > 0 && row < 127)
                {
                    IDS.Add(ID);
                }
            }

            highestID = -1;

            IDS.Sort((a, b) => a.CompareTo(b));
            int predictedID = 78;
            foreach (int id in IDS)
            {
                if (id != predictedID)
                {
                    highestID = predictedID;
                    break;
                }
                ++predictedID;
            }
            return highestID;
        }
        private static int PartTwo_Improved()
        {
            const char charB = 'B';
            const char charR = 'R';

            int[] IDs = new int[_lines.Length];
            for (int i = 0; i < _lines.Length; ++i)
            {
                int row = FindMiddleValue(_lines[i][0..^3], 0, 127, charB);
                int column = FindMiddleValue(_lines[i][^3.._lines[i].Length], 0, 7, charR);

                if (row > 0 && row < 127) { IDs[i] = row * 8 + column; }
            }

            Array.Sort(IDs, (a,b) => a.CompareTo(b));

            int predictedID = IDs[0];
            foreach (int id in IDs)
            {
                if (id != predictedID) { break; }
                ++predictedID;
            }
            return predictedID;
        }

        private static int FindMiddleValue(string input, int minBound, int maxBound, char upperChar) // Binary Search?
        {
            int range() => maxBound - minBound;
            foreach (char element in input)
            {
                int diff = range() / 2 + (range() & 1);

                if (element == upperChar) { minBound += diff; }
                else { maxBound -= diff; } // lower 
            }

            if (minBound != maxBound) { return -1; }
            else { return minBound; }
        }
    }
}
