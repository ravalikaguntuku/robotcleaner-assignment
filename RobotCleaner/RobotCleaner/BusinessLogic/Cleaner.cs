using System.Collections.Generic;
using System.Linq;
using RobotCleaner.Models;

namespace RobotCleaner.BusinessLogic
{
    public class Cleaner : ICleaner
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly List<Position> cleanedPositions = new List<Position>();

        public Cleaner(ICommandExecutor commandExecutor)
        {
            this.commandExecutor = commandExecutor;
        }

        public void Clean(Position currentPosition, IEnumerable<Command> commands)
        {
            foreach (var command in commands)
            {
                var positions = commandExecutor.Execute(command, currentPosition);
                if (positions == null)
                {
                    return;
                }
                if (positions.Any())
                {
                    cleanedPositions.AddRange(positions);
                }
            }
        }

        public int GetCleanedPositions()
        {
            return cleanedPositions.GroupBy(x => new { x.XCoordinate, x.YCoordinate }).Count();
        }
    }
}
