using System;
using System.Collections.Generic;

namespace AdventOfCode.Days
{
    [Day(2020, 4)]
    public class Day04 : BaseDay
    {
        private string[] _lines;
        public override string PartOne(string input)
        {
            const int TARGET = 7;

            uint validPassportCount = 0;
            List<string> checkedEntries = new List<string>();
            List<string> validEntries = new List<string>();

            _lines = input.Split(Environment.NewLine, StringSplitOptions.None);
            foreach(string line in _lines)
            {
                if(string.IsNullOrEmpty(line) || line.Length == 0) // New Passport
                {
                    if (validEntries.Count >= TARGET)
                        ++validPassportCount;

                    validEntries.Clear();
                    checkedEntries.Clear();
                    continue;
                }

                string[] entries = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach(string entry in entries)
                {
                    string[] types = entry.Split(':', StringSplitOptions.RemoveEmptyEntries);
                    if (validEntries.Contains(types[0]) == false && checkedEntries.Contains(types[0]) == false)
                    {
                        validEntries.Add(types[0]);
                    }
                    checkedEntries.Add(types[0]);
                }
            }

            if (validEntries.Count >= TARGET)
                ++validPassportCount;

            return validPassportCount.ToString();

            //return "Failed to find the answer!";
        }

        public static bool ValidateType(string type, string value)
        {
            List<char> characterRange = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f' };
            bool isValid = uint.TryParse(value, out uint valueParsed);
            
            switch (type)
            {
                default:
                case "cid":
                    return false;

                case "byr":
                    return isValid && valueParsed >= 1920 && valueParsed <= 2002;

                case "iyr":
                    return isValid && valueParsed >= 2010 && valueParsed <= 2020;

                case "eyr":
                    return isValid && valueParsed >= 2020 && valueParsed <= 2030;

                case "hgt":
                    isValid = false;
                    string substring = value[0..^2];
                    if (uint.TryParse(substring, out valueParsed))
                    {
                        if (value[^2] == 'i' && value[^1] == 'n') // inches
                        {
                            isValid = valueParsed >= 59 && valueParsed <= 76;
                        }
                        else if (value[^2] == 'c' && value[^1] == 'm') // centimeters
                        {
                            isValid = valueParsed >= 150 && valueParsed <= 193;
                        }
                    }
                    return isValid;

                case "hcl":
                    isValid = false;
                    if (value[0] == '#' && value.Length == 7)
                    {
                        isValid = true;
                        for(int i = 1; i < value.Length; ++i)
                        {
                            if(int.TryParse(value[i].ToString(), out int val))
                            {
                                if (val < 0 || val > 9)
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                if (characterRange.Contains(value[i]) == false)
                                    return false;
                            }
                        }
                    }
                    return isValid;

                case "ecl":
                    List<string> eyeColors = new List<string>() { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
                    return eyeColors.Contains(value);

                case "pid":
                    return isValid && value.Length == 9;
            }
        }

        public override string PartTwo(string input)
        {
            const int TARGET = 7;

            uint validPassportCount = 0;
            List<string> checkedEntries = new List<string>();
            List<string> validEntries = new List<string>();

            _lines = input.Split(Environment.NewLine, StringSplitOptions.None);
            foreach (string line in _lines)
            {
                if (string.IsNullOrEmpty(line) || line.Length == 0) // New Passport
                {
                    if (validEntries.Count >= TARGET)
                        ++validPassportCount;

                    validEntries.Clear();
                    checkedEntries.Clear();
                    continue;
                }

                string[] entries = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach (string entry in entries)
                {
                    string[] types = entry.Split(':', StringSplitOptions.RemoveEmptyEntries);
                    if (validEntries.Contains(types[0]) == false && checkedEntries.Contains(types[0]) == false)
                    {
                        if (ValidateType(types[0], types[1]))
                        {
                            validEntries.Add(types[0]);
                        }
                    }
                    checkedEntries.Add(types[0]);
                }
            }

            if (validEntries.Count >= TARGET)
                ++validPassportCount;

            return validPassportCount.ToString();

            //return "Failed to find the answer!";
        }
    }
}
