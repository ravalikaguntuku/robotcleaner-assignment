namespace RobotCleaner.Validations
{
    public interface IInputValidator
    {
        bool ValidateCommandCount(int commandCount);
        bool ValidateCoordinate(int coordinate);
        bool ValidateSteps(int steps);
        bool ValidateDirection(char direction);
    }
}
