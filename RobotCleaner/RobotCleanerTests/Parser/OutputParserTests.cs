using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotCleaner.Parser;

namespace RobotCleanerTests.Parser
{
    [TestClass]
    public class OutputParserTests
    {
        private readonly OutputParser outputParser;
        public OutputParserTests()
        {
             outputParser = new OutputParser();
        }

        [TestMethod]
        public void OutputShouldBeInFormat()
        {
            var expectedOutput = "=> Cleaned: 4";
            Assert.AreEqual(expectedOutput, outputParser.Parse(4));
        }

        [TestMethod]
        public void OutputShouldNotBeInWrongFormat()
        {
            var outputParser = new OutputParser();
            var expectedOutput = " =>  Cleaned:  4";
            Assert.AreNotEqual(expectedOutput, outputParser.Parse(4));
        }
    }
}