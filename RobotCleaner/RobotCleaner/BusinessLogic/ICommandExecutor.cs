using System.Collections.Generic;
using RobotCleaner.Models;

namespace RobotCleaner.BusinessLogic
{
    public interface ICommandExecutor
    {
        List<Position> Execute(Command command, Position currentPosition);
    }
}
