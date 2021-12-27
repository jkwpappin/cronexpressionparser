using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CronExpressionParser
{
    public class Month : CronNumericalArgument
    {
        protected override string DisplayName => "month";
        protected override int MaximumValue => 13;
        protected override bool StartsAtZero => false;
        public Month(string argument) : base(argument)
        {
        }

    }
}
