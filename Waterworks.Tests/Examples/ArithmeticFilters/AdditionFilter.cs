using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waterworks.Filters;

namespace Waterworks.Tests.Examples.ArithmeticFilters
{
    public class AdditionFilter : NullProcessFilter<int>
    {
        private int _add;

        public AdditionFilter(int add)
        {
            _add = add;
        }

        public override void Process(ref int data)
        {
            data += _add;
        }
    }
}
