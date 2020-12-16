using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AdventOfCode.Days
{
    [Day(2020, 11)]
    public class Day11 : BaseDay
    {
        private static Dictionary<Vector2, char> _seats = null;
        public override string PartOne(string input)
        {
            AssignSeats(input);
            Dictionary<Vector2, char> _backBuffer = new Dictionary<Vector2, char>(_seats);

            bool changeMade = true;
            while(changeMade)
            {
                changeMade = false;
                foreach (Vector2 position in _seats.Keys)
                {
                    int personCount = 0;

                    if (_seats.TryGetValue(new Vector2(position.X - 1, position.Y), out char seat)) // Left
                    {
                        if (seat == '#') ++personCount;
                    }
                    if (_seats.TryGetValue(new Vector2(position.X + 1, position.Y), out seat)) // Right
                    {
                        if (seat == '#') ++personCount;
                    }
                    if (_seats.TryGetValue(new Vector2(position.X, position.Y + 1), out seat)) // Up
                    {
                        if (seat == '#') ++personCount;
                    }
                    if (_seats.TryGetValue(new Vector2(position.X, position.Y - 1), out seat)) // Down
                    {
                        if (seat == '#') ++personCount;
                    }

                    if (_seats.TryGetValue(new Vector2(position.X - 1, position.Y - 1), out seat)) // Bottom-Left
                    {
                        if (seat == '#') ++personCount;
                    }
                    if (_seats.TryGetValue(new Vector2(position.X + 1, position.Y - 1), out seat)) // Bottom-Right
                    {
                        if (seat == '#') ++personCount;
                    }
                    if (_seats.TryGetValue(new Vector2(position.X - 1, position.Y + 1), out seat)) // Up-Left
                    {
                        if (seat == '#') ++personCount;
                    }
                    if (_seats.TryGetValue(new Vector2(position.X + 1, position.Y + 1), out seat)) // Up-Right
                    {
                        if (seat == '#') ++personCount;
                    }

                    switch (_seats[position])
                    {
                        default:
                            break;

                        case '#':
                            if (personCount >= 4)
                            {
                                _backBuffer[position] = 'L';
                                changeMade = true;
                            }
                            break;

                        case 'L':
                            if (personCount == 0)
                            {
                                _backBuffer[position] = '#';
                                changeMade = true;
                            }
                            break;
                    }
                }
                _seats = new Dictionary<Vector2, char>(_backBuffer);
            }

            return GetOccupiedSeatCount().ToString();
        }

        public override string PartTwo(string input)
        {
            AssignSeats(input);
            Dictionary<Vector2, char> _backBuffer = new Dictionary<Vector2, char>(_seats);

            bool changeMade = true;
            while (changeMade)
            {
                changeMade = false;
                foreach (Vector2 position in _seats.Keys)
                {
                    int personCount = 0;

                    char seat = GetFirstVisibleSeat(position, new Vector2(-1, 0)); // Left
                    if (seat == '#') ++personCount;

                    seat = GetFirstVisibleSeat(position, new Vector2(1, 0)); // Right
                    if (seat == '#') ++personCount;

                    seat = GetFirstVisibleSeat(position, new Vector2(0, 1)); // Top
                    if (seat == '#') ++personCount;

                    seat = GetFirstVisibleSeat(position, new Vector2(0, -1)); // Bottom
                    if (seat == '#') ++personCount;


                    seat = GetFirstVisibleSeat(position, new Vector2(-1, -1)); // Bottom-Left
                    if (seat == '#') ++personCount;

                    seat = GetFirstVisibleSeat(position, new Vector2(1, -1)); // Bottom-Right
                    if (seat == '#') ++personCount;

                    seat = GetFirstVisibleSeat(position, new Vector2(-1, 1)); // Top-Left
                    if (seat == '#') ++personCount;

                    seat = GetFirstVisibleSeat(position, new Vector2(1, 1)); // Top-Right
                    if (seat == '#') ++personCount;

                    switch (_seats[position])
                    {
                        default:
                            break;

                        case '#':
                            if (personCount >= 5)
                            {
                                _backBuffer[position] = 'L';
                                changeMade = true;
                            }
                            break;

                        case 'L':
                            if (personCount == 0)
                            {
                                _backBuffer[position] = '#';
                                changeMade = true;
                            }
                            break;
                    }
                }
                _seats = new Dictionary<Vector2, char>(_backBuffer);
            }

            return GetOccupiedSeatCount().ToString();
        }

        private static void AssignSeats(string input)
        {
            string[] lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            _seats = new Dictionary<Vector2, char>();

            for(int y = 0; y < lines.Length; ++y)
            {
                for(int x = 0; x < lines[y].Length; ++x)
                {
                    char character = lines[y][x];
                    _seats[new Vector2(x, y)] = character;
                }
            }
        }

        private static int GetOccupiedSeatCount()
        {
            int personCount = 0;
            foreach ((Vector2 position, char character) in _seats)
            {
                if (character == '#') ++personCount;
            }
            return personCount;
        }

        private static char GetFirstVisibleSeat(Vector2 position, Vector2 direction)
        {
            char seat = '.';
            bool seatFound = false;
            while (!seatFound)
            {
                position += direction;
                if (_seats.TryGetValue(position, out seat))
                {
                    if (seat != '.') seatFound = true;
                }
                else seatFound = true;
            }
            return seat;
        }
    }
}
