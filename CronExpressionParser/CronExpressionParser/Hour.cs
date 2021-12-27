using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CronExpressionParser
{
    public class Hour : CronNumericalArgument
    {
        protected override string DisplayName => "hour";
        protected override int MaximumValue => 24;
        protected override bool StartsAtZero => true;

        public Hour(string argument) : base(argument)
        {
            
        }
    }
}
