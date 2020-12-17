using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace AdventOfCode.Days
{
    [Day(2020, 12)]
    public class Day12 : BaseDay
    {
        private static Instruction[] _instructions;
        public override string PartOne(string input)
        {
            // StringBuilder sb = new StringBuilder();

            AssignInstructions(input);

            Direction direction = Direction.East;
            float positionX = 0;
            float positionY = 0;

            for(int i = 0; i < _instructions.Length; ++i)
            {
                switch(_instructions[i].Direction)
                {
                    case Direction.North:
                        positionY += _instructions[i].Value;
                        break;

                    case Direction.East:
                        positionX += _instructions[i].Value;
                        break;

                    case Direction.South:
                        positionY -= _instructions[i].Value;
                        break;

                    case Direction.West:
                        positionX -= _instructions[i].Value;
                        break;



                    case Direction.Left:
                        {
                            direction = (Direction)(((int)direction - _instructions[i].Value + 4) % 4);
                        }
                        break;

                    case Direction.Right:
                        {
                            direction = (Direction)(((int)direction + _instructions[i].Value + 4) % 4);
                        }
                        break;



                    case Direction.Forward:
                        Vector2 dir = new Vector2(0,0);
                        switch(direction)
                        {
                            case Direction.North:
                                dir.Y = 1;
                                break;

                            case Direction.East:
                                dir.X = 1;
                                break;

                            case Direction.South:
                                dir.Y = -1;
                                break;

                            case Direction.West:
                                dir.X = -1;
                                break;
                        }

                        Vector2 result = dir * _instructions[i].Value;
                        positionX += result.X;
                        positionY += result.Y;
                        break;
                }

                // sb.Append("(" + positionX + " ," + positionY + " ," + ((int)direction * 90).ToString() + ") - " + _instructions[i].Direction.ToString() + "(" + _instructions[i].Value.ToString() + ") - Mahatten: " + (Math.Abs(positionX) + Math.Abs(positionY)).ToString() + Environment.NewLine);
            }

            return (Math.Abs(positionX) + Math.Abs(positionY)).ToString();
            // return sb.ToString();
            // return "Failed to find the answer";
        }

        public override string PartTwo(string input)
        {
            throw new NotImplementedException();
        }

        private static void AssignInstructions(string input)
        {
            string[] lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            _instructions = new Instruction[lines.Length];
            for (int i = 0; i < lines.Length; ++i)
            {
                _instructions[i] = new Instruction(lines[i][0], lines[i][1..^0]);
            }
        }



        private enum Direction
        {
            North = 0,
            East,
            South,
            West,

            Left,
            Right,
            Forward
        }

        private struct Instruction
        {
            public readonly Direction Direction;
            public readonly int Value;

            public Instruction(char direction, string value)
            {
                Direction = direction switch
                {
                    'N' => Direction.North,
                    'E' => Direction.East,
                    'S' => Direction.South,
                    'W' => Direction.West,
                    'L' => Direction.Left,
                    'R' => Direction.Right,
                    'F' => Direction.Forward,
                    _ => throw new NotImplementedException()
                };

                Value = int.Parse(value);
                switch(Direction)
                {
                    default:
                        break;

                    case Direction.Left:
                    case Direction.Right:
                        Value /= 90;
                        break;
                }
            }
        };
    }
}
