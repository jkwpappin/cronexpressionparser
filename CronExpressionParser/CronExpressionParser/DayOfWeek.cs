namespace CronExpressionParser
{
    public class DayOfWeek : CronNumericalArgument
    {
        protected override string DisplayName => "day of week";
        protected override int MaximumValue => 8;
        protected override bool StartsAtZero => false;
        public DayOfWeek(string argument) : base(argument)
        {
        }
    }
}
