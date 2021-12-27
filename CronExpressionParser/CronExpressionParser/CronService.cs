// See https://aka.ms/new-console-template for more information

using CronExpressionParser;
using DayOfWeek = CronExpressionParser.DayOfWeek;

public class CronService
{
    public async Task<string> Run(string cronExpression)
    {
        var cronArguments = cronExpression.Split(" ");
        var minute = new Minute(cronArguments[0]);
        var hour = new Hour(cronArguments[1]);
        var dayOfMonth = new DayOfMonth(cronArguments[2]);
        var month = new Month(cronArguments[3]);
        var dayOfWeek = new DayOfWeek(cronArguments[4]);
        var cronCommand = new CronCommand(cronArguments[5]);
        return await Task.FromResult(minute.GetDisplayText() + "\n"
        + hour.GetDisplayText() + "\n"
        + dayOfMonth.GetDisplayText() + "\n"
        + month.GetDisplayText() + "\n"
        + dayOfWeek.GetDisplayText() + "\n"
        + cronCommand.GetDisplayText());
    }
}