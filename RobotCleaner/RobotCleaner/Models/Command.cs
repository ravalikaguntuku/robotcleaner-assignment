namespace RobotCleaner.Models
{
    public class Command
    {
        public Direction Direction { get; set; }
        public int Steps { get; set; }
    }

    public enum Direction
    {
        East = 'E',
        West = 'W',
        North = 'N',
        South = 'S'
    }
}
