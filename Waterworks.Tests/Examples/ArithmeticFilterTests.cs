using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waterworks.Filters;
using Waterworks.Tests.Examples.ArithmeticFilters;

namespace Waterworks.Tests.Examples
{
    public class ArithmeticFilterTests
    {
        private IPipeline<int> buildPipeline(int add, int divide)
        {
            IEnumerable<IProcessFilter<int>> filters = new List<IProcessFilter<int>>()
            {
                new AdditionFilter(add),
                new DivisionFilter(divide)
            };

            return new Pipeline<int>(filters);
        }

        [TestCase(0, 1, 1)]
        public void Given_Valid_Ints_Then_Calculate(int startValue, int add, int divide)
        {
            int expected = startValue + add / divide;
            int actual = startValue;

            bool isValid = buildPipeline(add, divide).Flow(ref actual);

            Assert.IsTrue(isValid);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, 1, 0)]
        public void Given_Invalid_Ints_Then_Calculate(int startValue, int add, int divide)
        {
            bool isValid = buildPipeline(add, divide).Flow(ref startValue);

            Assert.IsFalse(isValid);
        }
    }
}
