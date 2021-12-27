namespace CronExpressionParser
{
    public class CronCommand : IDisplayCronArgument
    {
        public CronCommand(string argument)
        {
            Command = argument;
        }

        public string Command { get; }

        public string GetDisplayText()
        {
            return $"command       {Command}";
        }
    }
}
