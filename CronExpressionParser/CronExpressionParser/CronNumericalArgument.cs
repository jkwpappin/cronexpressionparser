using CronExpressionParser;

public abstract class CronNumericalArgument : IDisplayCronArgument
{
    private const string RecurringWildcardSpecialCharacter = "*";
    private const string RangeSpecialCharacter = "-";
    private const string ValueSeparatorSpecialCharacter = ",";
    private const string IncrementorSpecialCharacter = "/";
    private const string DisplayValueSeparator = " ";
    private const int DisplayNameFixedLength = 14;
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
        if (argument.StartsWith(RecurringWildcardSpecialCharacter))
        {
            return HandleRecurringIntervals(argument);
        }

        if (argument.Contains(RangeSpecialCharacter))
        {
            return HandleRanges(argument);
        }

        if (argument.Contains(ValueSeparatorSpecialCharacter))
        {
            return HandleMultipleValues(argument);
        }

        return argument;
    }

    private string HandleMultipleValues(string argument)
    {
        var values = argument.Split(ValueSeparatorSpecialCharacter);
        return string.Join(DisplayValueSeparator, values);
    }

    private string HandleRanges(string argument)
    {
        var range = argument.Split(RangeSpecialCharacter);
        int startOfRange = int.Parse(range[0]);
        int endOfRange = int.Parse(range[1]);
        var values = Enumerable.Range(startOfRange, endOfRange - startOfRange + 1);
        return string.Join(DisplayValueSeparator, values);
    }

    private string HandleRecurringIntervals(string argument)
    {
        string parseArgument;
        parseArgument = argument.Substring(1);
        var incrementValue = 1;
        if (parseArgument.StartsWith(IncrementorSpecialCharacter))
        {
            incrementValue = int.Parse(parseArgument.Substring(1));
        }
        var maxRange = CalculateMaxRange(incrementValue);
        var values = Enumerable.Range(StartsAtZero ? 0 : 1, maxRange);

        return string.Join(DisplayValueSeparator, values.Select(index => index * incrementValue));
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
        string spacingSeperator = string.Empty;
        for (int index = DisplayName.Length ; index < DisplayNameFixedLength; index++)
        {
            spacingSeperator += DisplayValueSeparator;
        }
        return $"{DisplayName}{spacingSeperator}{DisplayValue}";
    }
}