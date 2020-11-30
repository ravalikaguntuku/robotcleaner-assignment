using System.Linq;

namespace RobotCleaner.Validations
{
    public class InputValidator : IInputValidator
    {
        public bool ValidateCommandCount(int commandCount)
        {
            return commandCount >= Constants.MinCommandCount && commandCount <= Constants.MaxCommandCount;
        }

        public bool ValidateCoordinate(int coordinate)
        {
            return coordinate >= Constants.MinCoordinateValue && coordinate <= Constants.MaxCoordinateValue;
        }

        public bool ValidateSteps(int steps)
        {
            return steps >= Constants.MinStepCount && steps <= Constants.MaxStepCount;
        }

        public bool ValidateDirection(char direction)
        {
            return Constants.DefinedDirections.Contains(direction);
        }
    }
}
