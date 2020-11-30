namespace RobotCleaner.Parser
{
    public class OutputParser
    {
        public string Parse(int cleanedPlaces)
        {
            return $"=> Cleaned: {cleanedPlaces}";
        }
    }
}
