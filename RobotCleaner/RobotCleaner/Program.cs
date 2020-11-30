using System;
using RobotCleaner.BusinessLogic;
using RobotCleaner.Parser;

namespace RobotCleaner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var inputParser = new InputParser(new InputReader());
                var (position, commands) = inputParser.Parse();

                var cleaner = new Cleaner(new CommandExecutor());
                cleaner.Clean(position, commands);
                var cleanedPlaces = cleaner.GetCleanedPositions();

                Console.Clear();
                var outputParser = new OutputParser();
                Console.WriteLine(outputParser.Parse(cleanedPlaces));

                Console.ReadKey();
            }
            catch (Exception)
            {
                //Log the Exception
            }
        }
    }
}
