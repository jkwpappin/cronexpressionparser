using CronExpressionParser;

public abstract class CronNumericalArgument : IDisplayCronArgument
{
    protected abstract string DisplayName { get; }
    protected string DisplayValue;
    protected abstract int MaximumValue { get; }
    protected abstract bool StartsAtZero { get; }

    public CronNumericalArgument(string argument)
    {
        DisplayValue = ParseArgument(argument);
    }

    private string ParseArgument(string argument)
    {
        if (argument.StartsWith("*"))
        {
            return HandleRecurringIntervals(argument);
        }

        if (argument.Contains("-"))
        {
            return HandleRanges(argument);
        }

        if (argument.Contains(","))
        {
            return HandleMultipleValues(argument);
        }

        return argument;
    }

    private string HandleMultipleValues(string argument)
    {
        var values = argument.Split(",");
        return string.Join(" ", values);
    }

    private string HandleRanges(string argument)
    {
        var range = argument.Split("-");
        int startOfRange = int.Parse(range[0]);
        int endOfRange = int.Parse(range[1]);
        var values = Enumerable.Range(startOfRange, endOfRange - startOfRange + 1);
        return string.Join(" ", values);
    }

    private string HandleRecurringIntervals(string argument)
    {
        string parseArgument;
        parseArgument = argument.Substring(1);
        var incrementValue = 1;
        if (parseArgument.StartsWith("/"))
        {
            incrementValue = int.Parse(parseArgument.Substring(1));
        }
        var maxRange = CalculateMaxRange(incrementValue);
        var values = Enumerable.Range(StartsAtZero ? 0 : 1, maxRange);

        return string.Join(" ", values.Select(index => index * incrementValue));
    }

    private int CalculateMaxRange(int incrementValue)
    {
        var maxRange = (MaximumValue / incrementValue);
        maxRange = (maxRange * incrementValue >= MaximumValue) ? maxRange : maxRange + 1;
        maxRange = StartsAtZero ? maxRange : maxRange - 1;
        return maxRange;
    }

    public string GetDisplayText()
    {
        return $"{DisplayName}\t{DisplayValue}";
    }
}