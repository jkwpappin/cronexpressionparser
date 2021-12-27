using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace CronExpressionParser.Tests
{
    [TestFixture]
    internal class CronCommandShould
    {
        [TestCase("commandX")]
        [TestCase("/usr/bin/find")]
        [TestCase("explorer.exe")]
        public void GivenAnyArgument_ReturnUnalteredDisplayValue(string argument)
        {
            var expectedValue = "command\t" + argument;

            var command = new CronCommand(argument);

            command.GetDisplayText().Should().Be(expectedValue);
        }

    }
}
