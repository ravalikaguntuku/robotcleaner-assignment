using System;
using System.Collections.Generic;
using System.Linq;
using RobotCleaner.Models;
using RobotCleaner.Validations;

namespace RobotCleaner.Parser
{
    public class InputParser : IInputParser
    {
        private readonly InputValidator inputValidator = new InputValidator();
        private readonly IInputReader inputReader;

        public InputParser(IInputReader inputReader)
        {
            this.inputReader = inputReader;
        }

        public (Position position, List<Command> commands) Parse()
        {
            return Parse(inputReader.Read());
        }

        private (Position, List<Command>) Parse(List<string> instructions)
        {
            var startingPosition = ParseStartingPosition(instructions.First());

            var commands = new List<Command>();
            ParseCommands(instructions, commands);

            return (startingPosition, commands);
        }

        private void ParseCommands(IEnumerable<string> instructions, List<Command> commands)
        {
            foreach (var instruction in instructions.Skip(1))
            {
                var subStrings = SplitInput(instruction);

                var direction = Convert.ToChar(subStrings[0]);
                var steps = Convert.ToInt32(subStrings[1]);
                //ValidateCommand(direction,steps);

                commands.Add(new Command
                {
                    Direction = (Direction)direction,
                    Steps = steps
                });
            }
        }

        private Position ParseStartingPosition(string instruction)
        {
            var coordinates = SplitInput(instruction);

            var xCoordinate = Convert.ToInt32(coordinates[0]);
            var yCoordinate = Convert.ToInt32(coordinates[1]);
            //ValidateCoordinates(xCoordinate, yCoordinate);

            return new Position
            {
                XCoordinate = xCoordinate,
                YCoordinate = yCoordinate
            };
        }

        private static string[] SplitInput(string input)
        {
            return input.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        private void ValidateCoordinates(int xCoordinate, int yCoordinate)
        {
            if (!(inputValidator.ValidateCoordinate(xCoordinate) &&
                  inputValidator.ValidateCoordinate(yCoordinate)))
            {
                //Log the validation error or clear console asking user to input correct value
            }
        }

        private void ValidateCommand(char direction, int steps)
        {
            if (!(inputValidator.ValidateDirection(direction) && inputValidator.ValidateSteps(steps)))
            {
                //Log the validation error or clear console asking user to input correct value
            }
        }

     
    }
}
