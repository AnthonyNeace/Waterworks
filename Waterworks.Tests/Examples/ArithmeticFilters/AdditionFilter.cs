using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waterworks.Filters;

namespace Waterworks.Tests.Examples.ArithmeticFilters
{
    public class SingleInputAdditionFilter : NullProcessFilter<int>
    {
        private int _add;

        public SingleInputAdditionFilter(int add)
        {
            _add = add;
        }

        public override void Process(ref int data)
        {
            data += _add;
        }
    }

    public class DualInputAdditionFilter : NullProcessFilter<int, int>
    {
        public override void Process(int input, ref int output)
        {
            output += input;
        }
    }
}
