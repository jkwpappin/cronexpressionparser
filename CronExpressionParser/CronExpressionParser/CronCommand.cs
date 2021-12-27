using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CronExpressionParser
{
    public class CronCommand : IDisplayCronArgument
    {
        public CronCommand(string argument)
        {
            Command = argument;
        }

        public string Command { get; }

        public string GetDisplayText()
        {
            return $"command\t{Command}";
        }
    }
}
