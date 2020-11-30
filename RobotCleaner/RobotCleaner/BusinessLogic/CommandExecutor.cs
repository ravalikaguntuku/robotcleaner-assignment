using System;
using RobotCleaner.Models;
using System.Collections.Generic;

namespace RobotCleaner.BusinessLogic
{
    public class CommandExecutor : ICommandExecutor
    {
        public List<Position> Execute(Command command, Position currentPosition)
        {
            if (IsValueOutOfRange(currentPosition.XCoordinate) || IsValueOutOfRange(currentPosition.YCoordinate))
            {
                return default;
            }

            switch (command.Direction)
            {
                case Direction.East:
                    {
                        return Positions(command.Steps, currentPosition,
                            () => currentPosition.XCoordinate == Constants.MaxCoordinateValue,
                                 position => { position.XCoordinate += 1; });
                    }
                case Direction.West:
                    {
                        return Positions(command.Steps, currentPosition,
                            () => currentPosition.XCoordinate == Constants.MinCoordinateValue,
                            position => { position.XCoordinate -= 1; });
                    }
                case Direction.North:
                    {
                        return Positions(command.Steps, currentPosition,
                            () => currentPosition.YCoordinate == Constants.MaxCoordinateValue,
                            position => { position.YCoordinate += 1; });
                    }
                case Direction.South:
                    {
                        return Positions(command.Steps, currentPosition,
                            () => currentPosition.YCoordinate == Constants.MinCoordinateValue,
                            position => { position.YCoordinate -= 1; });
                    }
                default:
                    return new List<Position>();
            }
        }

        private static List<Position> Positions(int steps, Position currentPosition,
            Func<bool> isValueOnBoundary, Action<Position> takeOneStep)
        {
            return isValueOnBoundary() ? new List<Position> { new Position(currentPosition) } 
                : Execute(steps, currentPosition, isValueOnBoundary, takeOneStep);
        }

        private static List<Position> Execute(int steps, Position currentPosition, Func<bool> isValueOnBoundary, Action<Position> takeOneStep)
        {
            var cleanedPlaces = new List<Position> { new Position(currentPosition) };
            while (steps > 0)
            {
                if (isValueOnBoundary())
                {
                    break;
                }
                takeOneStep(currentPosition);
                cleanedPlaces.Add(new Position(currentPosition));
                steps--;
            }
            return cleanedPlaces;
        }

        private static bool IsValueOutOfRange(int value)
        {
            return value < Constants.MinCoordinateValue || value > Constants.MaxCoordinateValue;
        }

    }
}
