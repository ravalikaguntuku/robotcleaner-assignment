using System;

namespace RobotCleaner.Models
{
    public class Position : IEquatable<Position>
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }

        public Position() { }
        public Position(Position point)
        {
            XCoordinate = point.XCoordinate;
            YCoordinate = point.YCoordinate;
        }

        public bool Equals(Position other) => other != null &&
                                              XCoordinate == other.XCoordinate &&
                                              YCoordinate == other.YCoordinate;

    }
}
