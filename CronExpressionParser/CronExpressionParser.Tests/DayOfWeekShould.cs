using NUnit.Framework;

namespace CronExpressionParser.Tests
{
    [TestFixture]
    internal class DayOfWeekShould
    {
        [TestCase("1", ExpectedResult = "day of week   1")]
        [TestCase("3", ExpectedResult = "day of week   3")]
        [TestCase("7", ExpectedResult = "day of week   7")]
        public string GivenSimpleNumericInput_ReturnUnalteredDisplayValue(string input)
        {
            var dayOfMonth = new DayOfWeek(input);

            return dayOfMonth.GetDisplayText();
        }

        [TestCase("*/2", ExpectedResult = "day of week   2 4 6")]
        [TestCase("*/3", ExpectedResult = "day of week   3 6")]
        [TestCase("*/4", ExpectedResult = "day of week   4")]
        [TestCase("*", ExpectedResult = "day of week   1 2 3 4 5 6 7")]
        public string GivenRecurringInput_ReturnExpectedRecurringValue(string input)
        {
            var dayOfMonth = new DayOfWeek(input);

            return dayOfMonth.GetDisplayText();
        }

        [TestCase("1-5", ExpectedResult = "day of week   1 2 3 4 5")]
        [TestCase("2-4", ExpectedResult = "day of week   2 3 4")]
        [TestCase("6-7", ExpectedResult = "day of week   6 7")]
        public string GivenARangeInput_ReturnExpectedRangeValue(string input)
        {
            var dayOfMonth = new DayOfWeek(input);

            return dayOfMonth.GetDisplayText();
        }

        [TestCase("1,5", ExpectedResult = "day of week   1 5")]
        [TestCase("1,2,7", ExpectedResult = "day of week   1 2 7")]
        [TestCase("1,2,4,5", ExpectedResult = "day of week   1 2 4 5")]
        public string GivenMultipleValuesInput_ReturnExpectedMultipleValues(string input)
        {
            var dayOfMonth = new DayOfWeek(input);

            return dayOfMonth.GetDisplayText();
        }
    }
}
