// See https://aka.ms/new-console-template for more information
if (args.Length == 0)
{
    Console.WriteLine("No argument was provided to the application. You must provide a single string with a cron expression.");
    return;
}
else if (args.Length > 1)
{
    Console.WriteLine("Too many arguments were provided to the application. You must provide a single string with a cron expression.");
    return;
}

var cronService = new CronService();
string cronExpression = args[0];
var cronOutput = await cronService.Run(cronExpression);
Console.Write(cronOutput);
