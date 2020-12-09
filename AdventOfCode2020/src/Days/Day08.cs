using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    [Day(2020, 8)]
    public class Day08 : BaseDay
    {
        private const string ACC = "acc";
        private const string JMP = "jmp";
        private const string NOP = "nop";

        private string[] _lines;
        public override string PartOne(string input)
        {
            List<int> executedIndicies = new List<int>();

            _lines = input.Split(Environment.NewLine, StringSplitOptions.None);
            int index = 0;
            int accumulator = 0;
            while(true)
            {
                if(executedIndicies.Contains(index)) break;

                executedIndicies.Add(index);

                string[] commands = _lines[index].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int value = int.Parse(commands[1]);
                switch(commands[0])
                {
                    default:
                    case NOP:
                        ++index;
                        continue;

                    case ACC:
                        accumulator += value;
                        ++index;
                        continue;

                    case JMP:
                        index += value;
                        continue;
                }
            }
            return accumulator.ToString();
            // return "Failed to find the answer";
        }

        public override string PartTwo(string input)
        {
            _lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            Instruction[] instructions = new Instruction[_lines.Length];

            List<int> attemptedInstructionIndexSwaps = new List<int>();
            List<int> executedInstructionIndicies = new List<int>();

            int accumulator = 0;
            int instructionIndexSwapped = -1;
            for (int index = 0; index < instructions.Length; ++index)
            {
                if (index == instructions.Length) break; // Reached end of instructions

                if (!instructions[index].Initialized)
                {
                    string[] cmd = _lines[index].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    instructions[index] = new Instruction(GetCommand(cmd[0]), cmd[1]);
                }

                // Swap new instruction
                if (instructionIndexSwapped == -1)
                {
                    if (instructions[index].Command == COMMAND.NOP || instructions[index].Command == COMMAND.JMP)
                    {
                        if (attemptedInstructionIndexSwaps.Contains(index) == false)
                        {
                            instructionIndexSwapped = index;
                            attemptedInstructionIndexSwaps.Add(index);
                            instructions[index].SetCommand(instructions[index].Command == COMMAND.JMP ? COMMAND.NOP : COMMAND.JMP);
                        }
                    }
                }
                Instruction instruction = instructions[index];

                // Loop detected
                if (executedInstructionIndicies.Contains(index))
                {
                    instructions[instructionIndexSwapped].ResetCommand();
                    executedInstructionIndicies.Clear();
                    instructionIndexSwapped = -1;
                    accumulator = 0;
                    index = -1;
                    continue;
                }
                executedInstructionIndicies.Add(index);

                // Execute instruction
                switch (instruction.Command)
                {
                    default: // No operation
                        break;

                    case COMMAND.ACC:
                        Accumulate(ref accumulator, instruction.ValueAsInt);
                        continue;

                    case COMMAND.JMP:
                        Jump(ref index, instruction.ValueAsInt);
                        continue;
                }
            }
            return accumulator.ToString();
        }

        #region Commands
        private static COMMAND GetCommand(string type)
        {
            switch (type)
            {
                default: return COMMAND.NOP;
                case ACC: return COMMAND.ACC;
                case JMP: return COMMAND.JMP;
                case NOP: return COMMAND.NOP;
            }
        }

        private static void Jump(ref int index, int value) => index += value - 1;
        private static void Accumulate(ref int runningTotal, int value) => runningTotal += value;
        #endregion

        public enum COMMAND { NOP, ACC, JMP }
        public struct Instruction
        {
            private readonly bool initialized;
            private COMMAND prvCommand;
            
            public COMMAND Command;
            public string Value;
            public int ValueAsInt;

            public bool Initialized => initialized;

            public void ResetCommand() => Command = prvCommand;

            public Instruction(COMMAND cmd, string value)
            {
                initialized = true;

                prvCommand = cmd;
                Command = cmd;
                Value = value;

                if(!int.TryParse(value, out ValueAsInt))
                {
                    ValueAsInt = -1;
                }
            }

            public void SetCommand(COMMAND newCommand)
            {
                prvCommand = Command;
                Command = newCommand;
            }
        };
    }
}
