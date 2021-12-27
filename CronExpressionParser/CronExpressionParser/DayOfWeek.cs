namespace CronExpressionParser
{
    public class DayOfWeek : CronNumericalArgument
    {
        public DayOfWeek(string argument) : base(argument)
        {
        }

        protected override string DisplayName => "day of week";
        protected override int MaximumValue => 8;
        protected override bool StartsAtZero => false;
    }
}
