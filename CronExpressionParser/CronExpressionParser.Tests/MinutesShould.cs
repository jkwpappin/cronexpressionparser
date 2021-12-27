using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CronExpressionParser.Tests
{
    [TestFixture]
    internal class MinutesShould
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
    }
}
