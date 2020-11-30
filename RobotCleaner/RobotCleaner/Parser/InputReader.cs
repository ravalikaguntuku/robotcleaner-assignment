using System;
using System.Collections.Generic;
using RobotCleaner.Validations;

namespace RobotCleaner.Parser
{
    public class InputReader : IInputReader
    {
        public List<string> Read()
        {
            var instructions = new List<string>();

            var commandCount = Convert.ToInt16(Console.ReadLine());
            //Validate(commandCount);

            // Read starting position co-ordinates
            instructions.Add(Console.ReadLine());

            while (commandCount > 0 && commandCount <= 10000)
            {
                instructions.Add(Console.ReadLine());
                commandCount--;
            }
            return instructions;
        }

        private void Validate(int commandCount)
        {
            var inputValidator = new InputValidator();
            if (!inputValidator.ValidateCommandCount(commandCount))
            {
                //Log the validation error or clear console asking user to input correct value
            }
        }

    }
}
