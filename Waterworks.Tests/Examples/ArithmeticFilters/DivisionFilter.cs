using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waterworks.Filters;

namespace Waterworks.Tests.Examples.ArithmeticFilters
{
    public class SingleInputDivisionFilter : NullProcessFilter<int>
    {
        private int _divide;

        public SingleInputDivisionFilter(int divide)
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

    public class DualInputDivisionFilter : NullProcessFilter<int, int>
    {
        public override bool Stop(int input, int output)
        {
            return input == 0 ? true : false;
        }

        public override void Process(int input, ref int output)
        {
            output /= input;
        }
    }
}
