namespace RobotCleaner
{
    public static class Constants
    {
        public const int MinCommandCount = 0;
        public const int MaxCommandCount = 10000;
        public const int MinCoordinateValue = -100000;
        public const int MaxCoordinateValue = 100000;
        public const int MinStepCount = 1;
        public const int MaxStepCount = 999;
        public static readonly char[] DefinedDirections = { 'E', 'W', 'N', 'S' };
    }
}
