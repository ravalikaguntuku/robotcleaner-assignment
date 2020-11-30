using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RobotCleaner.BusinessLogic;
using RobotCleaner.Models;

namespace RobotCleanerTests.BusinessLogic
{
    [TestClass]
    public class CleanerTests
    {
        private readonly ICleaner cleaner;
        private readonly Mock<ICommandExecutor> commandExecutor;
        private readonly Position position;
        private readonly List<Command> commands;
        private readonly int cleanedPlaces;

        public CleanerTests()
        {
            commandExecutor = new Mock<ICommandExecutor>();

            position = new Position { XCoordinate = 10, YCoordinate = 22 };
            commands = new List<Command>
            {
                new Command { Direction = Direction.East, Steps = 2 },
                new Command { Direction = Direction.North, Steps = 1 }
            };

            var eastSideCleanedPositions = new List<Position>
            {
                new Position{XCoordinate = 10,YCoordinate = 22},
                new Position{XCoordinate = 11,YCoordinate = 22},
                new Position{XCoordinate = 12,YCoordinate = 22}
            };

            var northSideCleanedPositions = new List<Position>
            {
                eastSideCleanedPositions.Last(),
                new Position{XCoordinate = 12,YCoordinate = 23}
            };

            commandExecutor.Setup(x => x.Execute(commands.First(), position)).Returns(eastSideCleanedPositions);
            position.XCoordinate = eastSideCleanedPositions.Last().XCoordinate;
            commandExecutor.Setup(x => x.Execute(commands.Last(), position)).Returns(northSideCleanedPositions);

            cleaner = new Cleaner(commandExecutor.Object);
            cleaner.Clean(position, commands);
            cleanedPlaces = cleaner.GetCleanedPositions();
        }

        [TestMethod]
        public void CommandExecutorShouldBeCalledSameAsCommandCount()
        {
            commandExecutor.Verify(x => x.Execute(It.IsAny<Command>(), It.IsAny<Position>()), Times.AtMost(2));
        }

        [TestMethod]
        public void NoOfCleanedPlacesShouldBeReturned()
        {
            Assert.AreEqual(4, cleanedPlaces);
        }
    }
}