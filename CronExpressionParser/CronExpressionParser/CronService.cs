// See https://aka.ms/new-console-template for more information
public class CronService
{
    public async Task<string> Run(string cronExpression)
    {
        var cronArguments = cronExpression.Split(" ");
        var minute = new Minute(cronArguments[0]);
        return await Task.FromResult(minute.DisplayName);
    }
}