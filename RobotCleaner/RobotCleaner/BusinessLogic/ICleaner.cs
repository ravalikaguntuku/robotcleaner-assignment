using System.Collections.Generic;
using RobotCleaner.Models;

namespace RobotCleaner.BusinessLogic
{
    public interface ICleaner
    {
        void Clean(Position currentPosition, IEnumerable<Command> commands);
        int GetCleanedPositions();
    }
}
