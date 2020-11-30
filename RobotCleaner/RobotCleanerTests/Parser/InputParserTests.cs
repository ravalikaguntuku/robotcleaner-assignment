using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RobotCleaner.Models;
using RobotCleaner.Parser;

namespace RobotCleanerTests.Parser
{
    [TestClass]
    public class InputParserTests
    {
        private readonly IInputParser inputParser;
        private readonly Position actualPosition;
        private readonly List<Command> actualCommands;

        public InputParserTests()
        {
            var inputReader = new Mock<IInputReader>();

            var instructions = GetInstructions();
            inputReader.Setup(x => x.Read()).Returns(instructions);

            inputParser = new InputParser(inputReader.Object);
            (actualPosition, actualCommands) = inputParser.Parse();
        }


        private List<string> GetInstructions()
        {
            var inputList = new List<string>();

            // starting position
            inputList.Add("10 22");

            // commands
            inputList.Add("E 2");
            inputList.Add("N 1");

            return inputList;
        }

        [TestMethod]
        public void XCoordinateOfStartingPositionShouldBeReturned()
        {
           Assert.AreEqual(10, actualPosition.XCoordinate);
        }

        [TestMethod]
        public void YCoordinateOfStartingPositionShouldBeReturned()
        {
            Assert.AreEqual(22, actualPosition.YCoordinate);
        }

        [TestMethod]
        public void CommandCountShouldBeOneCountLessThanInstructions()
        {
            Assert.AreEqual(2,actualCommands.Count);
        }

        [TestMethod]
        public void DirectionShouldBeReturned()
        {
            Assert.AreEqual(Direction.East, actualCommands.First().Direction);
        }

        [TestMethod]
        public void StepsShouldBeReturned()
        {
            Assert.AreEqual(1, actualCommands.Last().Steps);
        }
    }
}