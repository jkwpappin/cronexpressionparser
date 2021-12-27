using NUnit.Framework;

namespace CronExpressionParser.Tests
{
    internal class MonthShould
    {
        [TestCase("1", ExpectedResult = "month\t1")]
        [TestCase("5", ExpectedResult = "month\t5")]
        [TestCase("12", ExpectedResult = "month\t12")]
        public string GivenSimpleNumericInput_ReturnUnalteredDisplayValue(string input)
        {
            var hour = new Month(input);

            return hour.GetDisplayText();
        }

        [TestCase("*/2", ExpectedResult = "month\t2 4 6 8 10 12")]
        [TestCase("*/3", ExpectedResult = "month\t3 6 9 12")]
        [TestCase("*/6", ExpectedResult = "month\t6 12")]
        [TestCase("*/7", ExpectedResult = "month\t7")]
        [TestCase("*", ExpectedResult = "month\t1 2 3 4 5 6 7 8 9 10 11 12")]
        public string GivenRecurringInput_ReturnExpectedRecurringValue(string input)
        {
            var hour = new Month(input);

            return hour.GetDisplayText();
        }

        [TestCase("1-5", ExpectedResult = "month\t1 2 3 4 5")]
        [TestCase("10-12", ExpectedResult = "month\t10 11 12")]
        [TestCase("4-5", ExpectedResult = "month\t4 5")]
        public string GivenARangeInput_ReturnExpectedRangeValue(string input)
        {
            var hour = new Month(input);

            return hour.GetDisplayText();
        }

        [TestCase("1,5", ExpectedResult = "month\t1 5")]
        [TestCase("1,2,12", ExpectedResult = "month\t1 2 12")]
        [TestCase("2,4,5,9", ExpectedResult = "month\t2 4 5 9")]
        public string GivenMultipleValuesInput_ReturnExpectedMultipleValues(string input)
        {
            var hour = new Month(input);

            return hour.GetDisplayText();
        }
    }
}
