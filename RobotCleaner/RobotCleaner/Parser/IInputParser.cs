using RobotCleaner.Models;
using System.Collections.Generic;

namespace RobotCleaner.Parser
{
    public interface IInputParser
    {
        (Position position, List<Command> commands) Parse();
    }
}
