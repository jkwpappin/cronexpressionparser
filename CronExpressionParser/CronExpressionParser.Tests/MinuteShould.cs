using NUnit.Framework;

namespace CronExpressionParser.Tests
{
    [TestFixture]
    internal class MinuteShould
    {
        [TestCase("0", ExpectedResult = "minute\t0")]
        [TestCase("15", ExpectedResult = "minute\t15")]
        [TestCase("32", ExpectedResult = "minute\t32")]
        [TestCase("45", ExpectedResult = "minute\t45")]
        [TestCase("59", ExpectedResult = "minute\t59")]
        public string GivenSimpleNumericInput_ReturnExpectedDisplayValue(string input)
        {
            var minute = new Minute(input);

            return minute.GetDisplayText();
        }

        [TestCase("*/15", ExpectedResult = "minute\t0 15 30 45")]
        [TestCase("*/3", ExpectedResult = "minute\t0 3 6 9 12 15 18 21 24 27 30 33 36 39 42 45 48 51 54 57")]
        [TestCase("*/14", ExpectedResult = "minute\t0 14 28 42 56")]
        [TestCase("*", ExpectedResult = "minute\t0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31 32 33 34 35 36 37 38 39 40 41 42 43 44 45 46 47 48 49 50 51 52 53 54 55 56 57 58 59")]
        public string GivenRecurringInput_ReturnExpectedRecurringValue(string input)
        {
            var minute = new Minute(input);

            return minute.GetDisplayText();
        }

        [TestCase("1-5", ExpectedResult = "minute\t1 2 3 4 5")]
        [TestCase("0-2", ExpectedResult = "minute\t0 1 2")]
        [TestCase("44-45", ExpectedResult = "minute\t44 45")]
        public string GivenARangeInput_ReturnExpectedRangeValue(string input)
        {
            var minute = new Minute(input);

            return minute.GetDisplayText();
        }

        [TestCase("1,5", ExpectedResult = "minute\t1 5")]
        [TestCase("0,2,47", ExpectedResult = "minute\t0 2 47")]
        [TestCase("42,44,45,49", ExpectedResult = "minute\t42 44 45 49")]
        public string GivenMultipleValuesInput_ReturnExpectedMultipleValues(string input)
        {
            var minute = new Minute(input);

            return minute.GetDisplayText();
        }
    }
}
