﻿// See https://aka.ms/new-console-template for more information

using CronExpressionParser;

public class CronService
{
    public async Task<string> Run(string cronExpression)
    {
        var cronArguments = cronExpression.Split(" ");
        var minute = new Minute(cronArguments[0]);
        var hour = new Hour(cronArguments[1]);
        var dayOfMonth = new DayOfMonth(cronArguments[2]);
        var month = new Month(cronArguments[3]);
        return await Task.FromResult(minute.GetDisplayText()
        + hour.GetDisplayText()
        + dayOfMonth.GetDisplayText()
        + month.GetDisplayText());
    }
}