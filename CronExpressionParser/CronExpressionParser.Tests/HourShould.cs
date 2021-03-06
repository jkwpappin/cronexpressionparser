using NUnit.Framework;

namespace CronExpressionParser.Tests
{
    [TestFixture]
    internal class HourShould
    {
        [TestCase("0", ExpectedResult = "hour          0")]
        [TestCase("15", ExpectedResult = "hour          15")]
        [TestCase("22", ExpectedResult = "hour          22")]
        public string GivenSimpleNumericInput_ReturnUnalteredDisplayValue(string input)
        {
            var hour = new Hour(input);

            return hour.GetDisplayText();
        }

        [TestCase("*/2", ExpectedResult = "hour          0 2 4 6 8 10 12 14 16 18 20 22")]
        [TestCase("*/3", ExpectedResult = "hour          0 3 6 9 12 15 18 21")]
        [TestCase("*/12", ExpectedResult = "hour          0 12")]
        [TestCase("*", ExpectedResult = "hour          0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23")]
        public string GivenRecurringInput_ReturnExpectedRecurringValue(string input)
        {
            var hour = new Hour(input);

            return hour.GetDisplayText();
        }

        [TestCase("1-5", ExpectedResult = "hour          1 2 3 4 5")]
        [TestCase("0-2", ExpectedResult = "hour          0 1 2")]
        [TestCase("44-45", ExpectedResult = "hour          44 45")]
        public string GivenARangeInput_ReturnExpectedRangeValue(string input)
        {
            var hour = new Hour(input);

            return hour.GetDisplayText();
        }

        [TestCase("1,5", ExpectedResult = "hour          1 5")]
        [TestCase("0,2,47", ExpectedResult = "hour          0 2 47")]
        [TestCase("42,44,45,49", ExpectedResult = "hour          42 44 45 49")]
        public string GivenMultipleValuesInput_ReturnExpectedMultipleValues(string input)
        {
            var hour = new Hour(input);

            return hour.GetDisplayText();
        }
    }
}
