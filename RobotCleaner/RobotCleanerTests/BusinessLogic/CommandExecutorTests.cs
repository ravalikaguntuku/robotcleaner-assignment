using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotCleaner.BusinessLogic;
using RobotCleaner.Models;

namespace RobotCleanerTests.BusinessLogic
{
    [TestClass]
    public class CommandExecutorTests
    {
        public static readonly CommandExecutor commandExecutor;
        static CommandExecutorTests()
        {
            commandExecutor = new CommandExecutor();
        }

        [TestClass]
        public class WhenDirectionIsEast
        {
            private Command command;
            private int cleanedPositions;
            private Position currentPosition;

            [TestInitialize]
            public void Initialize()
            {
                currentPosition = new Position { XCoordinate = 10, YCoordinate = 22 };
                command = new Command { Direction = Direction.East, Steps = 2 };
                cleanedPositions = commandExecutor.Execute(command, currentPosition).Count;
            }

            [TestMethod]
            public void XCoordinateShouldBeIncreasedToSteps()
            {
                Assert.AreEqual(12, currentPosition.XCoordinate);
            }

            [TestMethod]
            public void ÝCoordinateShouldNotBeChanged()
            {
                Assert.AreNotEqual(24, currentPosition.YCoordinate);
            }

            [TestMethod]
            public void NoOfPositionsToBeCleaned()
            {
                Assert.AreEqual(3, cleanedPositions);
            }
        }

        [TestClass]
        public class WhenDirectionIsWest
        {
            private Command command;
            private int cleanedPositions;
            private Position currentPosition;

            [TestInitialize]
            public void Initialize()
            {
                currentPosition = new Position { XCoordinate = -98000, YCoordinate = 22 };
                command = new Command { Direction = Direction.West, Steps = 3000 };
                cleanedPositions = commandExecutor.Execute(command, currentPosition).Count;
            }

            [TestMethod]
            public void XCoordinateShouldNotExceedBounds()
            {
                Assert.AreEqual(-100000, currentPosition.XCoordinate);
            }

            [TestMethod]
            public void ÝCoordinateShouldNotBeChanged()
            {
                Assert.AreNotEqual(24, currentPosition.YCoordinate);
            }

            [TestMethod]
            public void NoOfPositionsToBeCleaned()
            {
                Assert.AreNotEqual(3001, cleanedPositions);
            }
        }

        [TestClass]
        public class WhenDirectionIsNorth
        {
            private Command command;
            private int cleanedPositions;
            private Position currentPosition;

            [TestInitialize]
            public void Initialize()
            {
                currentPosition = new Position { XCoordinate = -100000, YCoordinate = 100000 };
                command = new Command { Direction = Direction.North, Steps = 3000 };
                cleanedPositions = commandExecutor.Execute(command, currentPosition).Count;
            }

            [TestMethod]
            public void XCoordinateShouldNotChange()
            {
                Assert.AreEqual(-100000, currentPosition.XCoordinate);
            }

            [TestMethod]
            public void ÝCoordinateShouldNotBeChanged()
            {
                Assert.AreEqual(100000, currentPosition.YCoordinate);
            }

            [TestMethod]
            public void NoOfPositionsToBeCleaned()
            {
                Assert.AreEqual(1, cleanedPositions);
            }
        }

        [TestClass]
        public class WhenDirectionIsSouth
        {
            private Command command;
            private int cleanedPositions;
            private Position currentPosition;

            [TestInitialize]
            public void Initialize()
            {
                currentPosition = new Position { XCoordinate = -100000, YCoordinate = -97000 };
                command = new Command { Direction = Direction.South, Steps = 3000 };
                cleanedPositions = commandExecutor.Execute(command, currentPosition).Count;
            }

            [TestMethod]
            public void XCoordinateShouldNotChange()
            {
                Assert.AreEqual(-100000, currentPosition.XCoordinate);
            }

            [TestMethod]
            public void ÝCoordinateShouldBeChanged()
            {
                Assert.AreEqual(-100000, currentPosition.YCoordinate);
            }

            [TestMethod]
            public void NoOfPositionsToBeCleaned()
            {
                Assert.AreEqual(3001, cleanedPositions);
            }
        }

    }
}