using NUnit.Framework;

namespace CronExpressionParser.Tests
{
    [TestFixture]
    internal class DayOfWeekShould
    {
        [TestCase("1", ExpectedResult = "day of week\t1")]
        [TestCase("3", ExpectedResult = "day of week\t3")]
        [TestCase("7", ExpectedResult = "day of week\t7")]
        public string GivenSimpleNumericInput_ReturnUnalteredDisplayValue(string input)
        {
            var dayOfMonth = new DayOfWeek(input);

            return dayOfMonth.GetDisplayText();
        }

        [TestCase("*/2", ExpectedResult = "day of week\t2 4 6")]
        [TestCase("*/3", ExpectedResult = "day of week\t3 6")]
        [TestCase("*/4", ExpectedResult = "day of week\t4")]
        [TestCase("*", ExpectedResult = "day of week\t1 2 3 4 5 6 7")]
        public string GivenRecurringInput_ReturnExpectedRecurringValue(string input)
        {
            var dayOfMonth = new DayOfWeek(input);

            return dayOfMonth.GetDisplayText();
        }

        [TestCase("1-5", ExpectedResult = "day of week\t1 2 3 4 5")]
        [TestCase("2-4", ExpectedResult = "day of week\t2 3 4")]
        [TestCase("6-7", ExpectedResult = "day of week\t6 7")]
        public string GivenARangeInput_ReturnExpectedRangeValue(string input)
        {
            var dayOfMonth = new DayOfWeek(input);

            return dayOfMonth.GetDisplayText();
        }

        [TestCase("1,5", ExpectedResult = "day of week\t1 5")]
        [TestCase("1,2,7", ExpectedResult = "day of week\t1 2 7")]
        [TestCase("1,2,4,5", ExpectedResult = "day of week\t1 2 4 5")]
        public string GivenMultipleValuesInput_ReturnExpectedMultipleValues(string input)
        {
            var dayOfMonth = new DayOfWeek(input);

            return dayOfMonth.GetDisplayText();
        }
    }
}
