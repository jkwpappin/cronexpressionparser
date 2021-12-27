using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CronExpressionParser
{
    public class DayOfMonth : CronNumericalArgument
    {
        public DayOfMonth(string argument) : base(argument)
        {
        }

        protected override string DisplayName => "day of month";
        protected override int MaximumValue => 32;
    }
}
