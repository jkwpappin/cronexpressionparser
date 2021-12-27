public class Minute
{
    public string DisplayName = "minute";
    private string argument;
    
    public Minute(string cronArgument)
    {
        argument = cronArgument;
    }

    public string GetDisplayText()
    {
        return $"{DisplayName}\t{ParseArgument()}";
    }

    private string ParseArgument()
    {
        if (argument.StartsWith("*"))
        {
            return HandleRecurringIntervals();
        }

        if (argument.Contains("-"))
        {
            return HandleRanges();
        }

        if (argument.Contains(","))
        {
            return HandleMultipleValues();
        }

        return argument;
    }

    private string HandleRanges()
    {
        return string.Empty;
    }

    private string HandleRecurringIntervals()
    {
        string parseArgument;
        parseArgument = argument.Substring(1);
        var incrementValue = 1;
        if (parseArgument.StartsWith("/"))
        {
            incrementValue = int.Parse(parseArgument.Substring(1));
        }

        var maxRange = (60 / incrementValue);
        maxRange = (maxRange * incrementValue >= 60) ? maxRange - 1 : maxRange;
        var values = Enumerable.Range(1, maxRange);
        string resultString = string.Empty;
        foreach (var index in values)
        {
            var number = index * incrementValue;
            resultString = string.IsNullOrEmpty(resultString) ? $"{number}" : $"{resultString} {number}";
        }

        return resultString;
    }
}