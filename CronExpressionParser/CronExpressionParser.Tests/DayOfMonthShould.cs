using NUnit.Framework;

namespace CronExpressionParser.Tests
{
    [TestFixture]
    internal class DayOfMonthShould
    {
        [TestCase("1", ExpectedResult = "day of month\t1")]
        [TestCase("3", ExpectedResult = "day of month\t3")]
        [TestCase("28", ExpectedResult = "day of month\t28")]
        public string GivenSimpleNumericInput_ReturnUnalteredDisplayValue(string input)
        {
            var dayOfMonth = new DayOfMonth(input);

            return dayOfMonth.GetDisplayText();
        }

        [TestCase("*/15", ExpectedResult = "day of month\t15 30")]
        [TestCase("*/3", ExpectedResult = "day of month\t3 6 9 12 15 18 21 24 27 30")]
        [TestCase("*/14", ExpectedResult = "day of month\t14 28")]
        [TestCase("*", ExpectedResult = "day of month\t1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31")]
        public string GivenRecurringInput_ReturnExpectedRecurringValue(string input)
        {
            var dayOfMonth = new DayOfMonth(input);

            return dayOfMonth.GetDisplayText();
        }

        [TestCase("1-5", ExpectedResult = "day of month\t1 2 3 4 5")]
        [TestCase("2-4", ExpectedResult = "day of month\t2 3 4")]
        [TestCase("24-25", ExpectedResult = "day of month\t24 25")]
        public string GivenARangeInput_ReturnExpectedRangeValue(string input)
        {
            var dayOfMonth = new DayOfMonth(input);

            return dayOfMonth.GetDisplayText();
        }

        [TestCase("1,5", ExpectedResult = "day of month\t1 5")]
        [TestCase("1,2,17", ExpectedResult = "day of month\t1 2 17")]
        [TestCase("19,22,24,25", ExpectedResult = "day of month\t19 22 24 25")]
        public string GivenMultipleValuesInput_ReturnExpectedMultipleValues(string input)
        {
            var dayOfMonth = new DayOfMonth(input);

            return dayOfMonth.GetDisplayText();
        }
    }
}
