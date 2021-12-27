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
        return $"{DisplayName}\t{argument}";
    }
}