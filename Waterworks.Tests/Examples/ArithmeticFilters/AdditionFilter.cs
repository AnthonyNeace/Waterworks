using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waterworks.Filters;

namespace Waterworks.Tests.Examples.ArithmeticFilters
{
    public class SingleInputAdditionFilter : NullFilter<int>
    {
        private int _add;

        public SingleInputAdditionFilter(int add)
        {
            _add = add;
        }

        public override void Modify(ref int data)
        {
            data += _add;
        }
    }

    public class DualInputAdditionFilter : NullFilter<int, int>
    {
        public override void Modify(int input, ref int output)
        {
            output += input;
        }
    }
}
