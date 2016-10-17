using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waterworks.Filters;

namespace Waterworks.Tests.Examples.ArithmeticFilters
{
    public class SingleInputDivisionFilter : NullFilter<int>
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

        public override int Modify(int data)
        {
            return data / _divide;
        }
    }

    public class DualInputDivisionFilter : NullFilter<int, int>
    {
        public override bool Stop(int input, int output)
        {
            return input == 0 ? true : false;
        }

        public override int Modify(int input, int output)
        {
            return output / input;
        }
    }
}
