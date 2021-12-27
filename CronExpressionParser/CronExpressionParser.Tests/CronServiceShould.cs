using FluentAssertions;
using NUnit.Framework;

namespace CronExpressionParser.Tests
{
    [TestFixture]
    public class CronServiceShould
    {
        [Test]
        public async Task GenerateExpectedOutputForTheArgumentsInTheSpecification()
        {
            //Arrange
            var input = "*/15 0 1,15 * 1-5 /usr/bin/find";
            var expectedOutput = "minute        0 15 30 45\n" +
                                 "hour          0\n" +
                                 "day of month  1 15\n" +
                                 "month         1 2 3 4 5 6 7 8 9 10 11 12\n" +
                                 "day of week   1 2 3 4 5\n" +
                                 "command       /usr/bin/find";
            var cronService = new CronService();

            //Act
            var actualOutput = await cronService.Run(input);

            //Assert
            actualOutput.Should().Be(expectedOutput);
        }

        [Test]
        public async Task GenerateExpectedOutputForADifferentSetOfArguments()
        {
            //Arrange
            var input = "1,5 * 1-3 6,12 6-7 /usr/bin/weekendjob";
            var expectedOutput = "minute        1 5\n" +
                                 "hour          0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23\n" +
                                 "day of month  1 2 3\n" +
                                 "month         6 12\n" +
                                 "day of week   6 7\n" +
                                 "command       /usr/bin/weekendjob";
            var cronService = new CronService();

            //Act
            var actualOutput = await cronService.Run(input);

            //Assert
            actualOutput.Should().Be(expectedOutput);
        }
    }
}