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

        public override int Modify(int data)
        {
            return data + _add;
        }
    }

    public class DualInputAdditionFilter : NullFilter<int, int>
    {
        public override int Modify(int input, int output)
        {
            return output + input;
        }
    }
}
