using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CronExpressionParser
{
    public class DayOfMonth : CronNumericalArgument
    {
        protected override string DisplayName => "day of month";
        protected override int MaximumValue => 32;
        protected override bool StartsAtZero => false;
        public DayOfMonth(string argument) : base(argument)
        {
        }
    }
}
