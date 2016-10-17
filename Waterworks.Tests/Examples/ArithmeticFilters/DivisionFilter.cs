using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waterworks.Filters;

namespace Waterworks.Tests.Examples.ArithmeticFilters
{
    public class DivisionFilter : NullProcessFilter<int>
    {
        private int _divide;

        public DivisionFilter(int divide)
        {
            _divide = divide;
        }

        public override bool Stop(int data)
        {
            return _divide == 0 ? true : false;
        }

        public override void Process(ref int data)
        {
            data /= _divide;
        }
    }
}
