using FluentAssertions;
using NUnit.Framework;

namespace CronExpressionParser.Tests
{
    [TestFixture]
    public class CronServiceShould
    {
        [Test]
        public async Task GenerateExpectedOutputForTheGivenArgument()
        {
            //Arrange
            var input = "*/15 0 1,15 * 1-5 /usr/bin/find";
            var expectedOutput = "minute\t0 15 30 45\n" +
                                 "hour\t0\n" +
                                 "day\tof month 1 15\n" +
                                 "month\t1 2 3 4 5 6 7 8 9 10 11 12\n" +
                                 "day of week\t1 2 3 4 5\n" +
                                 "command /usr/bin/find";
            var cronService = new CronService();

            //Act
            var actualOutput = await cronService.Run(input);

            //Assert
            actualOutput.Should().Be(expectedOutput);
        }
    }
}