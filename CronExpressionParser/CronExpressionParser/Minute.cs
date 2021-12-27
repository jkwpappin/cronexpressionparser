public class Minute : CronNumericalArgument
{
    protected override string DisplayName => "minute";
    protected override int MaximumValue => 60;

    public Minute(string argument) : base(argument)
    {
        
    }
}