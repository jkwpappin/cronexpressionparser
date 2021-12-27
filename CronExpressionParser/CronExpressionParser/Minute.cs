public class Minute : CronNumericalArgument
{
    protected override string DisplayName => "minute";
    protected override int MaximumValue => 60;
    protected override bool StartsAtZero => true;

    public Minute(string argument) : base(argument)
    {
        
    }
}