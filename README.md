# cronexpressionparser
Cron Expression Parser

Notes on the task:
I spent 3 hours of total time working on the task, git commits might make it appear more due to taking breaks during.
I realise I missed out tests cases for invalid arguments/values being passed in, specifically for when you pass a simple value argument in. 
My test cases ended up mostly just covering happy path scenarios.
E.g. if you pass in "61" as a value for the minutes there's currently no tests for that.
I followed TDD for the task, writing tests first and then following RED GREEN REFACTOR and using Triagulation to improve the design. 
I did start with the simple solution to make the tests Green before trying to look for appropriate design patterns to use.
Tried to follow SOLID, DRY, KISS and OO design principles, and ended up with a relatively simple design where the CronService simply aggregates the display values for each argument, and the class that represents each argument has the responsibility for knowning how to display itself. The numerical arguments inherit from a base class (CronNumericalArgument), which does the parsing of the different types of special characters, with the child classes simply needing to specify what ranges they operate in and their display names.
There is almost certainly some refactoring that could be done to improve readibility/clarity in some areas.
While I have used inheretance as a first pass for the arugment parsing logic, the display logic should probably have moved to a composition based pattern so it could be shared between the numerical and non-numerical arguments, I had introduced an interface IDisplayCronArgument, with the idea that it would lead to some composition and shared display class which would handle the compisition of the display name with it's 14 character fixed length, and the display value, but I ran out of time to get to that refactoring.

Running the ConsoleApp:
To run outside of Visual Studio (e.g. from the command line), please navigate to the folder containing the project file "CronExpressionParser.csproj".
Once you are in the working directory, simply run the command:
dotnet run "<your cron arguments>"
e.g. 
dotnet run "1,5 * 1-3 6,12 6-7 /usr/bin/weekendjob"
You should then see output:
minute  1 5
hour    0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23
day of month    1 2 3
month   6 12
day of week     6 7
command /usr/bin/weekendjob

Running tests:
Navigate to the solution folder (with CronExpressionParser.sln) and run the command: dotnet test
You should then see the tests run and pass:
Test run for C:\Git\cronexpressionparser\cronexpressionparser\CronExpressionParser\CronExpressionParser.Tests\bin\Debug\net6.0\CronExpressionParser.Tests.dll (.NETCoreApp,Version=v6.0)
Microsoft (R) Test Execution Command Line Tool Version 17.0.0
Copyright (c) Microsoft Corporation.  All rights reserved.

Starting test execution, please wait...
A total of 1 test files matched the specified pattern.

Passed!  - Failed:     0, Passed:    73, Skipped:     0, Total:    73, Duration: 29 ms - CronExpressionParser.Tests.dll (net6.0)